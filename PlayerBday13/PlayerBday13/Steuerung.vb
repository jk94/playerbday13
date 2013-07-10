Option Strict On

Imports System.IO

Public Class Steuerung


    Private _player As Player
    Private _playlist As Playlist
    Private _player_gui As Player_GUI
    Private _randomSongs As Boolean = True
    Private _muted As Boolean = False
    Private fnt As Font
    Private _serverconnection As Connection


    Public Sub New(ByRef playergui As Player_GUI)
        _player_gui = playergui
        fnt = _player_gui.lv_Playlist.Font
        _player = New Player(Me)
        _playlist = New Playlist()
        
        fuelleLVPlaylist()

        _serverconnection = New Connection(1234, Me, getPlayerGUI())
    End Sub
    Public Sub shutdown()
        _serverconnection.stopServer()
    End Sub
    Public Function getPlayerGUI() As Player_GUI
        Return _player_gui
    End Function

    Public Sub fuelleLVPlaylist()
        _player_gui.lv_Playlist.Items.Clear()
        For Each t As Titel In _playlist.Liste
            _player_gui.lv_Playlist.Items.Add("#" & t.Track & " - " & t.STitel & " - (" & t.Artist & ")")
        Next
        If _playlist.PlayIndex >= 0 And _playlist.PlayIndex < _player_gui.lv_Playlist.Items.Count Then setPlaylistTitelActive(_playlist.PlayIndex)
        _player_gui.lv_Playlist.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub
    Public Sub ChangePlaystate()
        Select Case _player.getStatus()
            Case Un4seen.Bass.BASSActive.BASS_ACTIVE_PAUSED
                _player.resumeSong()
                _player_gui.btn_Play.BackgroundImage = My.Resources.play
            Case Un4seen.Bass.BASSActive.BASS_ACTIVE_PLAYING
                _player.pauseSong()
                _player_gui.btn_Play.BackgroundImage = My.Resources.pause
            Case Un4seen.Bass.BASSActive.BASS_ACTIVE_STALLED
            Case Un4seen.Bass.BASSActive.BASS_ACTIVE_STOPPED
            Case Else

        End Select
    End Sub

    Public Sub setRandom(ByVal rndm As Boolean)
        _randomSongs = rndm
    End Sub
    Public Function getRandom() As Boolean
        Return _randomSongs
    End Function
    Public Sub setMuted()
        _player.mute()
    End Sub
    Public Function getMute() As Boolean
        Return _muted
    End Function
    Public Function toogleMute() As Boolean
        If _muted Then
            _player.UnMute()
            _muted = False
        Else
            _player.Mute()
            _muted = True
        End If
        Return _muted
    End Function
    Public Sub songAusgewaehlt(ByVal index As Integer)
        _player.loadSong(_playlist.Liste(index))
        _playlist.PlayIndex = index
        _player.playSong()
        resetPlaylistColor()
        setPlaylistTitelActive(_playlist.PlayIndex)
    End Sub

    Public Sub selectNextSong()
        If _randomSongs Then
            Dim rnd As New Random()
            Dim rndzahl As Integer = CInt(Math.Truncate(rnd.Next(0, (_playlist.Liste.Count) * 100) / 100))
            Dim zahl As Integer = rndzahl
            Do While zahl = _playlist.PlayIndex
                rndzahl = CInt(Math.Truncate(rnd.Next(0, (_playlist.Liste.Count - 1) * 100) / 100))
                zahl = rndzahl
            Loop
            'MsgBox(zahl)
            _playlist.PlayIndex = zahl
            _player.loadSong(_playlist.Liste(_playlist.PlayIndex))
        Else
            If _playlist.PlayIndex < _playlist.Liste.Count - 1 Then
                _playlist.PlayIndex += 1
            Else
                _playlist.PlayIndex = 0
            End If
            _player.loadSong(_playlist.Liste(_playlist.PlayIndex))
        End If
        _player_gui.lv_Playlist.Items(_playlist.PlayIndex).Selected = True
        _player_gui.lv_Playlist.Select()
    End Sub

    Public Sub startSong()
        If _playlist.PlayIndex <> -1 Or _playlist.PlayIndex < _playlist.Liste.Count - 1 Then
            _player.playSong()
            resetPlaylistColor()
            setPlaylistTitelActive(_playlist.PlayIndex)
        End If
    End Sub
    Public Sub setVolume(ByVal wertinProzent As Integer)
        _player.Volume = wertinProzent
    End Sub
    Public Function getVolume() As Integer
        Return _player.Volume
    End Function
    Public Sub resetPlaylistColor()
        For Each item As ListViewItem In _player_gui.lv_Playlist.Items
            item.ForeColor = Color.Gray
            item.Font = fnt
        Next
    End Sub
    Public Sub setPlaylistTitelActive(index As Integer)
        Try
            _player_gui.lv_Playlist.Items(index).ForeColor = Color.Black
            Dim fnt2 = New Font(fnt.FontFamily, fnt.Size, FontStyle.Bold)
            _player_gui.lv_Playlist.Items(index).Font = fnt2
        Catch ex As Exception
        End Try
    End Sub

    Public Sub addTitelToList(ByRef titel As Titel)
        _playlist.addTitel(titel)
        fuelleLVPlaylist()
    End Sub
    Public Sub addTitelToList(ByRef titelliste As List(Of Titel))
        For Each ti As Titel In titelliste
            _playlist.addTitel(ti)
        Next
        fuelleLVPlaylist()
    End Sub

#Region "Operationen Remote"
    Public Sub remoteStarteSong()
        Try
            If _playlist.Liste.Count > 0 Then
                If _playlist.PlayIndex <> -1 And _playlist.PlayIndex < _playlist.Liste.Count Then
                    _player.loadSong(_playlist.Liste(_playlist.PlayIndex))
                    _player.playSong()
                    resetPlaylistColor()
                    setPlaylistTitelActive(_playlist.PlayIndex)
                End If
            End If
        Catch
        End Try
    End Sub
    Public Sub remoteToggleRandom()
        Try
            setRandom(Not getRandom())
            _player_gui.cb_Random.Checked = getRandom()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub waehleAktion(e As RemoteEventArgs)

        Select Case e.Msg
            Case "chrnd"
                remoteToggleRandom()
            Case "play"
                remoteStarteSong()
            Case "shutdown"
                _player_gui.Close()
            Case Else

        End Select

    End Sub
#End Region
End Class
