﻿Option Strict On

Imports System.IO

Public Class Steuerung


    Private _player As Player
    Private _playlist As Playlist
    Private _player_gui As Player_GUI
    Private _randomSongs As Boolean = True


    Public Sub New(ByRef playergui As Player_GUI)
        _player_gui = playergui
        _player = New Player(Me)
        _playlist = New Playlist()
        Dim ti As Titel = New Titel("C:\Users\Admin\Desktop\Musikverwaltung TEST\Essential Mix 11-12-2010.mp3")
        Dim ti2 As Titel = New Titel("C:\Users\Admin\Desktop\Musikverwaltung TEST\Katzenjammer - A Kiss Before You Go\02. I Will Dance (When I Walk Away).mp3")
        Dim ti3 As New Titel("K:\Musik\Musik (versch.)\Cro - Easy (2011)\01 Easy.mp3")
        Dim ti4 As New Titel("K:\Musik\Musik (versch.)\Asaf Avidan & the Mojos - One Day - Reckoning Song (Wankelmut Remix)\01. One Day - Reckoning Song (Wankelmut Remix) (Radio Edit).mp3")
        _playlist.addTitel(ti)
        _playlist.addTitel(ti2)
        _playlist.addTitel(ti3)
        _playlist.addTitel(ti4)
        
        fuelleLVPlaylist()

        '_player.playSong("C:\Users\Admin\Desktop\Musikverwaltung TEST\New Age.mp3")

    End Sub
    Public Function getPlayerGUI() As Player_GUI
        Return _player_gui
    End Function

    Public Sub fuelleLVPlaylist()
        _player_gui.lv_Playlist.Items.Clear()
        For Each t As Titel In _playlist.Liste
            _player_gui.lv_Playlist.Items.Add("#" & t.Track & " - " & t.STitel & " - (" & t.Artist & ")")
        Next
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

    Public Sub songAusgewaehlt(ByVal index As Integer)
        _player.loadSong(_playlist.Liste(index))
        _player.playSong()
        _playlist.PlayIndex = index
    End Sub

    Public Sub selectNextSong()
        If _randomSongs Then
            Dim rnd As New Random()
            Dim rndzahl As Integer = CInt(Math.Truncate(rnd.Next(0, (_playlist.Liste.Count - 1) * 100) / 100))
            Dim zahl As Integer = rndzahl
            Do While zahl = _playlist.PlayIndex
                rndzahl = CInt(Math.Truncate(rnd.Next(0, (_playlist.Liste.Count - 1) * 100) / 100))
                zahl = rndzahl
            Loop
            MsgBox(zahl)
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
    End Sub

    Public Sub startSong()
        If _playlist.PlayIndex <> -1 Or _playlist.PlayIndex < _playlist.Liste.Count - 1 Then
            _player.playSong()
        End If
    End Sub
End Class
