Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class Connection
    Private _port As Integer
    Private _Listener As TcpListener
    Private _Client As TcpClient
    Private _ipendpoint As Net.IPEndPoint
    Private _thrServer As New System.Threading.Thread(AddressOf runServer)
    Private _control As Steuerung
    Private _playerGUI As Player_GUI
    Public Event incomingMessage As EventHandler
    Public CancelFlag As Boolean = False
    Private _stream As NetworkStream

    
    Delegate Sub DoCommandDelegate(ByVal Target As Player_GUI, ByVal Target2 As Steuerung, ByVal message As String)

    Public Sub New(port As Integer, ByRef steuerung As Steuerung, ByRef gui As Player_GUI)
        _port = port
        _control = steuerung
        _playerGUI = gui
        _thrServer.Start()
    End Sub

    Public Sub stopServer()
        _thrServer.IsBackground = True
    End Sub
    Public Sub runServer()

        Try
            _ipendpoint = New Net.IPEndPoint(IPAddress.Any, _port)
            _Listener = New TcpListener(_ipendpoint)

            _Listener.Start()

            Dim bytes(1024) As Byte
            Dim data As String = Nothing
            While True
                ' Perform a blocking call to accept requests.
                ' You could also user server.AcceptSocket() here.
                _Client = _Listener.AcceptTcpClient
                data = Nothing

                ' Get a stream object for reading and writing
                Dim stream As NetworkStream = _Client.GetStream()
                _stream = stream
                Dim connected As String = "Connected!"
                stream.Write(System.Text.Encoding.ASCII.GetBytes(connected), 0, connected.Length)
                Dim i As Int32

                ' Loop to receive all the data sent by the client.
                i = stream.Read(bytes, 0, bytes.Length)
                While (i <> 0 And CancelFlag <> True)
                    ' Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)

                    ' Hier hast du den empfangenen string data

                    Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes("")
                    Dim amsg As String = ""
                    Select Case data.ToLower()
                        Case "hallo"
                            amsg = "Hallo Benutzer"
                        Case "bye"
                            amsg = "Tschüss"
                    End Select
                    RaiseEvent incomingMessage(Me, New RemoteEventArgs(data.ToLower()))
                    msg = System.Text.Encoding.ASCII.GetBytes(amsg)
                    'Anschließend  gibst du die antwort:

                    'stream.Write(msg, 0, msg.Length)

                    i = stream.Read(bytes, 0, bytes.Length)

                End While

                ' Shutdown and end connection
                _Client.Close()

            End While
        Catch e As SocketException
            Console.WriteLine("SocketException: {0}", e)
        Finally
            _Listener.Stop()

        End Try

    End Sub

    Private Function Connection_incomingMessage(sender As Object, e As RemoteEventArgs) As String Handles Me.incomingMessage
        Dim retmsg As String = ""
        Dim commands As String() = {"isplaying", "ismute", "isshuffle", "getvolume", "getcurrentsong", "getplaylist"}
        If commands.Contains(e.Msg.ToLower()) Then
            Select Case e.Msg.ToLower()
                Case "isplaying"
                    Dim state As Integer = _control.remoteGetPlaystate()
                    If state = 1 Then
                        retmsg = "isplaying:::playing"
                    ElseIf state = 3 Then
                        retmsg = "isplaying:::paused"
                    Else
                        retmsg = "isplaying:::else"
                    End If
                Case "ismute"
                    Dim state As Boolean = _control.getMute()

                    If state Then
                        retmsg = "ismute:::true"
                    Else
                        retmsg = "ismute:::false"
                    End If
                Case "isshuffle"
                    Dim state As Boolean = _control.getRandom()
                    If state Then
                        retmsg = "isshuffle:::true"
                    Else
                        retmsg = "isshuffle:::false"
                    End If
                Case "getvolume"
                    retmsg = "getvolume:::" & _control.getVolume().ToString()
                Case "getcurrentsong"
                    Try
                        retmsg = "getcurrentsong:::" & _control.getCurrentSong().STitel & ";;;" & _control.getCurrentSong().Artist & ";;;" & _control.getCurrentSong().Dauer
                    Catch
                    End Try
                Case "getplaylist"
                    Dim pl As List(Of Titel) = _control.getPlaylist()
                    retmsg = "getplaylist"
                    For Each ti As Titel In pl
                        retmsg += ":::" & ti.STitel & ";;;" & ti.Artist & ";;;" & ti.Dauer
                    Next
                Case Else

            End Select
            Dim msg = System.Text.Encoding.ASCII.GetBytes(retmsg & vbNewLine)
            _stream.Write(msg, 0, msg.Length)
        Else
            _playerGUI.entscheideAktion(e)
        End If
        Return retmsg
    End Function
End Class

Public Class RemoteEventArgs
    Inherits EventArgs
    Sub New(pmsg As String)
        Msg = pmsg
        MsgBox(Msg)
    End Sub
    Public Property Msg As String
End Class