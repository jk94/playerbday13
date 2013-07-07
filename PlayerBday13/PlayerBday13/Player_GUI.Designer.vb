<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Player_GUI
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lv_Playlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.pb_Cover = New System.Windows.Forms.PictureBox()
        Me.pl_Control = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.pb_Cover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pl_Control.SuspendLayout()
        Me.SuspendLayout()
        '
        'lv_Playlist
        '
        Me.lv_Playlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lv_Playlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lv_Playlist.Dock = System.Windows.Forms.DockStyle.Right
        Me.lv_Playlist.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_Playlist.FullRowSelect = True
        Me.lv_Playlist.Location = New System.Drawing.Point(394, 24)
        Me.lv_Playlist.MultiSelect = False
        Me.lv_Playlist.Name = "lv_Playlist"
        Me.lv_Playlist.Size = New System.Drawing.Size(310, 389)
        Me.lv_Playlist.TabIndex = 0
        Me.lv_Playlist.UseCompatibleStateImageBehavior = False
        Me.lv_Playlist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 307
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(704, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(389, 24)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(5, 389)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'pb_Cover
        '
        Me.pb_Cover.BackColor = System.Drawing.Color.Transparent
        Me.pb_Cover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pb_Cover.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb_Cover.Location = New System.Drawing.Point(0, 24)
        Me.pb_Cover.Name = "pb_Cover"
        Me.pb_Cover.Size = New System.Drawing.Size(389, 389)
        Me.pb_Cover.TabIndex = 3
        Me.pb_Cover.TabStop = False
        '
        'pl_Control
        '
        Me.pl_Control.BackColor = System.Drawing.Color.Transparent
        Me.pl_Control.Controls.Add(Me.Button3)
        Me.pl_Control.Controls.Add(Me.Button2)
        Me.pl_Control.Controls.Add(Me.Button1)
        Me.pl_Control.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pl_Control.Location = New System.Drawing.Point(0, 413)
        Me.pl_Control.Name = "pl_Control"
        Me.pl_Control.Size = New System.Drawing.Size(704, 74)
        Me.pl_Control.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(484, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(52, 52)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(353, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(52, 52)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(413, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 63)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Player_GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(704, 487)
        Me.Controls.Add(Me.pb_Cover)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.lv_Playlist)
        Me.Controls.Add(Me.pl_Control)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(720, 525)
        Me.Name = "Player_GUI"
        Me.Text = "Player"
        CType(Me.pb_Cover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pl_Control.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lv_Playlist As System.Windows.Forms.ListView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pb_Cover As System.Windows.Forms.PictureBox
    Friend WithEvents pl_Control As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

End Class
