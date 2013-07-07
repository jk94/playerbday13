Imports Un4seen.Bass
Public Delegate Sub onEnding(ByVal handle As Integer, ByVal channel As Integer, ByVal data As Integer, ByVal user As Integer)

Public Class Player

    Dim _stream As Integer
    Dim _streamLength As Integer
    Dim _control As Steuerung
    Public Sub New(ByRef control As Steuerung)
        Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_CPSPEAKERS, IntPtr.Zero, Nothing)
        _control = control
    End Sub


    Public Sub playSong()
        stopSong()
        Bass.BASS_ChannelPlay(_stream, False)
    End Sub

    Public Sub loadSong(ByRef titel As Titel)
        stopSong()
        _stream = Bass.BASS_StreamCreateFile(titel.Location, 0, 0, BASSFlag.BASS_STREAM_AUTOFREE Or BASSFlag.BASS_STREAM_PRESCAN)
        _streamLength = CInt(Bass.BASS_ChannelGetLength(_stream) - 1)
        Bass.BASS_ChannelSetSync(_stream, BASSSync.BASS_SYNC_END, _streamLength, New SYNCPROC(AddressOf onEnding), 1)
        _control.getPlayerGUI().pb_Cover.BackgroundImage = titel.Cover(1000, 1000)
    End Sub

    Public Sub stopSong()
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

    Public Sub onEnding(ByVal handle As Integer, ByVal channel As Integer, ByVal data As Integer, ByVal user As Integer)
        MessageBox.Show("Track ended!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Debugger.Break()
    End Sub

End Class
