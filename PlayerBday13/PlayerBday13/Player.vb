Option Strict On
Imports Un4seen.Bass
Public Class Player


    Dim _stream As Integer
    Dim _control As Steuerung
    Public Sub New(ByRef control As Steuerung)
        Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, IntPtr.Zero, Nothing)
        _control = control
    End Sub


    Public Sub playSong(ByRef titel As Titel)
        stopSong()
        _stream = Bass.BASS_StreamCreateFile(titel.Location, 0, 0, BASSFlag.BASS_STREAM_AUTOFREE Or BASSFlag.BASS_STREAM_PRESCAN)
        _control.getPlayerGUI().pb_Cover.BackgroundImage = titel.Cover(1000, 1000)
        Bass.BASS_ChannelPlay(_stream, False)
    End Sub

    Public Sub stopSong()
        Bass.BASS_ChannelStop(_stream)
    End Sub

    Public Sub pauseSong()
        Bass.BASS_ChannelPause(_stream)
    End Sub

    Public Sub resumeSong()
        Bass.BASS_ChannelPlay(_stream, False)
    End Sub
End Class
