Option Strict On
Imports Un4seen.Bass
Public Class Player_GUI

    Dim _steuerung As Steuerung

    Private Sub Player_GUI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _steuerung = New Steuerung(Me)
        lv_Playlist.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        cb_Random.Checked = True
    End Sub

    Private Sub Player_GUI_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Text = Me.Width & "x" & Me.Height
        btn_Play.Left = CInt(Math.Round(pl_Control.Width / 2) - Math.Round(btn_Play.Width / 2))
        btn_Previous.Left = btn_Play.Left - btn_Previous.Width - 8
        btn_Next.Left = btn_Play.Left + btn_Play.Width + 8
        cb_Random.Left = pl_Control.Width - cb_Random.Width - 2
        btn_Mute.Left = btn_Previous.Left - btn_Mute.Width - 8
        trb_Volume.Width = btn_Mute.Left - 5
    End Sub

    Private Sub lv_Playlist_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lv_Playlist.MouseDoubleClick
        If lv_Playlist.SelectedItems.Count > 0 Then
            _steuerung.songAusgewaehlt(lv_Playlist.SelectedIndices(0))
        End If
    End Sub

    Private Sub Splitter1_LocationChanged(sender As Object, e As System.EventArgs) Handles Splitter1.LocationChanged
        lv_Playlist.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub btn_Play_Click(sender As System.Object, e As System.EventArgs) Handles btn_Play.Click
        _steuerung.ChangePlaystate()
    End Sub

    Private Sub btn_Next_Click(sender As System.Object, e As System.EventArgs) Handles btn_Next.Click
        _steuerung.selectNextSong()
        _steuerung.startSong()
    End Sub

    Private Sub cb_Random_CheckStateChanged(sender As Object, e As System.EventArgs) Handles cb_Random.CheckStateChanged
        _steuerung.setRandom(cb_Random.Checked)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TrackBar1_Scroll(sender As System.Object, e As System.EventArgs) Handles trb_Volume.Scroll
        _steuerung.setVolume(trb_Volume.Value)
    End Sub
End Class
