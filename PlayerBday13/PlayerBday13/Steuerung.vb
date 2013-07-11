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
    Public Function getCurrentSong() As Titel
        Dim erg As Titel = New Titel("\")
        If _playlist.PlayIndex >= 0 And _playlist.PlayIndex < _playlist.Liste.Count Then erg = _playlist.Liste(_playlist.PlayIndex)
        Return erg
    End Function
    Public Function getPlaylist() As List(Of Titel)
        Return _playlist.Liste
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
    Public Sub setMuted(mute As Boolean)
        _muted = mute
        If _muted Then
            _player.Mute()
        Else
            _player.UnMute()
        End If

    End Sub
    Public Function getMute() As Boolean
        Return _muted
    End Function
    Public Function toogleMute() As Boolean
        setMuted(Not _muted)
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
    Public Sub setVolume(sender As System.Object, ByVal wertinProzent As Integer)
        If sender.Equals(_player_gui) Then
            _player.Volume = wertinProzent
        ElseIf sender.Equals(Me) Then
            _player.Volume = wertinProzent
            _player_gui.trb_Volume.Value = wertinProzent

        End If
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
    Public Function remoteGetPlaystate() As Integer
        Return _player.getStatus()
    End Function
    Public Sub remoteResumeSong()
        Try
            _player.resumeSong()
        Catch
        End Try
    End Sub
    Public Sub remoteStarteSong(index As Integer)
        Try
            If _playlist.Liste.Count > 0 Then
                If index > -1 And index < _playlist.Liste.Count Then
                    _player.loadSong(_playlist.Liste(index))
                    _player.playSong()
                    _playlist.PlayIndex = index
                    resetPlaylistColor()
                    setPlaylistTitelActive(index)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remoteToggleRandom()
        Try
            setRandom(Not getRandom())
            _player_gui.cb_Random.Checked = getRandom()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remoteShuffleOn()
        Try
            setRandom(True)
            _player_gui.cb_Random.Checked = True
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remoteShuffleOff()
        Try
            setRandom(False)
            _player_gui.cb_Random.Checked = False
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remoteNext()
        Try
            selectNextSong()
            startSong()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remoteSetVolume(wert As Integer)
        Try
            setVolume(Me, wert)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remotePause()
        Try
            _player.pauseSong()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub remoteMute()
        Try
            setMuted(True)
            _player_gui.btn_Mute.BackgroundImage = My.Resources.mute
        Catch ex As Exception
        End Try
    End Sub
    Public Sub remoteUnmute()
        Try
            setMuted(False)
            _player_gui.btn_Mute.BackgroundImage = My.Resources.unmute
        Catch ex As Exception
        End Try
    End Sub
    Public Sub waehleAktion(e As RemoteEventArgs)
        Dim spliter As String() = Split(e.Msg, ":::")
        Dim command As String = spliter(0)
        Dim daten As String = ""
        For i = 1 To spliter.Length - 1
            If i < spliter.Length - 1 Then
                daten += spliter(i) & ":::"
            Else
                daten += spliter(i)
            End If

        Next


        Select Case command.ToLower()
            Case "chshuffle"
                remoteToggleRandom()
            Case "shuffleon"
                remoteShuffleOn()
            Case "shuffleoff"
                remoteShuffleOff()
            Case "mute"
                remoteMute()
            Case "unmute"
                remoteUnmute()
            Case "play"
                daten.Trim()
                If daten.Equals("") Then
                    remoteResumeSong()
                Else
                    remoteStarteSong(CInt(daten))
                End If
            Case "pause"
                remotePause()
            Case "next"
                remoteNext()
            Case "volume"
                remoteSetVolume(CInt(daten))
            Case "shutdown"
                _player_gui.Close()
            Case Else

        End Select

    End Sub
#End Region


End Class
