Option Strict On
Imports Un4seen.Bass
Public Class Player_GUI

    Dim _steuerung As Steuerung


    Private Sub Player_GUI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _steuerung = New Steuerung(Me)
        lv_Playlist.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub Player_GUI_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Text = Me.Width & "x" & Me.Height
    End Sub

    Private Sub lv_Playlist_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lv_Playlist.MouseDoubleClick
        If lv_Playlist.SelectedItems.Count > 0 Then
            _steuerung.songAusgewaehlt(lv_Playlist.SelectedIndices(0))
        End If
    End Sub

    Private Sub Splitter1_LocationChanged(sender As Object, e As System.EventArgs) Handles Splitter1.LocationChanged
        lv_Playlist.Columns(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub
End Class
