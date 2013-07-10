Imports Un4seen.Bass

Public Class Player

    Dim _stream As Integer
    Dim _control As Steuerung
    Dim _titelname As String = ""
    Dim WithEvents _tmr As Timer
    Dim _VolumeBeforeMute As Integer

    Public Sub New(ByRef control As Steuerung)
        Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, Nothing)
        Bass.BASS_ChannelSetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, 0.5)
        _control = control
        _tmr = New Timer()
        _tmr.Interval = 10
    End Sub


    Public Sub playSong()
        stopSong()
        Bass.BASS_ChannelPlay(_stream, False)
        _tmr.Start()
    End Sub

    Public Sub loadSong(ByRef titel As Titel)
        stopSong()
        _stream = Bass.BASS_StreamCreateFile(titel.Location, 0, 0, BASSFlag.BASS_STREAM_AUTOFREE Or BASSFlag.BASS_STREAM_PRESCAN)
        _control.getPlayerGUI().pb_Cover.BackgroundImage = titel.Cover(1000, 1000)
        _titelname = titel.STitel
    End Sub

    Public Sub stopSong()
        _tmr.Stop()
        If getStatus() <> BASSActive.BASS_ACTIVE_STOPPED Then Bass.BASS_ChannelStop(_stream)
    End Sub

    Public Sub pauseSong()
        Bass.BASS_ChannelPause(_stream)
    End Sub

    Public Sub resumeSong()
        Bass.BASS_ChannelPlay(_stream, False)
    End Sub

    Public Function getStatus() As BASSActive
        Return Bass.BASS_ChannelIsActive(_stream)
    End Function

    Public Sub streamEnded()
        _control.selectNextSong()
        _control.startSong()
    End Sub

    Public Function getDauer() As String
        Return Un4seen.Bass.Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(_stream, Bass.BASS_ChannelGetLength(_stream)), "MMSS")
    End Function

    Public Function getZeit() As String
        Return Un4seen.Bass.Utils.FixTimespan(Bass.BASS_ChannelBytes2Seconds(_stream, Bass.BASS_ChannelGetPosition(_stream)), "MMSS")
    End Function
    Public Property Volume As Integer
        Get
            'Return Bass.BASS_GetVolume() * 100
            Return Bass.BASS_ChannelGetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, 100)
        End Get
        Set(value As Integer)
            Bass.BASS_ChannelSetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, value / 100)
            'Bass.BASS_SetVolume(value / 100)
        End Set
    End Property
    Public Sub Mute()
        _VolumeBeforeMute = Volume
        Volume = 0
    End Sub
    Public Sub UnMute()
        Volume = _VolumeBeforeMute
    End Sub

    Private Sub tmr_tick(sender As System.Object, e As System.EventArgs) Handles _tmr.Tick
        Dim comTime As Integer = Bass.BASS_ChannelGetLength(_stream)
        Dim aktTime As Integer = Bass.BASS_ChannelGetPosition(_stream)
        If comTime <= aktTime Then
            _tmr.Stop()
            streamEnded()
        End If
        _control.getPlayerGUI.Text = getZeit() & "/" & getDauer()
        _control.getPlayerGUI.Text += " - " & _titelname
    End Sub
End Class
