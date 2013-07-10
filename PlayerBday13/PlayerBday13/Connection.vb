﻿Imports System.Net
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

    Private Sub Connection_incomingMessage(sender As Object, e As System.EventArgs) Handles Me.incomingMessage
        _playerGUI.entscheideAktion(e)
    End Sub
End Class

Public Class RemoteEventArgs
    Inherits EventArgs
    Sub New(pmsg As String)
        Msg = pmsg
    End Sub
    Public Property Msg As String
End Class