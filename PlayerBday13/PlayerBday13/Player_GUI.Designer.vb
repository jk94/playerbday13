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
        Me.pl_Control = New System.Windows.Forms.Panel()
        Me.btn_Mute = New System.Windows.Forms.Button()
        Me.trb_Volume = New System.Windows.Forms.TrackBar()
        Me.cb_Random = New System.Windows.Forms.CheckBox()
        Me.btn_Next = New System.Windows.Forms.Button()
        Me.btn_Previous = New System.Windows.Forms.Button()
        Me.btn_Play = New System.Windows.Forms.Button()
        Me.pb_Cover = New System.Windows.Forms.PictureBox()
        Me.pl_Control.SuspendLayout()
        CType(Me.trb_Volume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Cover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lv_Playlist
        '
        Me.lv_Playlist.AllowDrop = True
        Me.lv_Playlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lv_Playlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lv_Playlist.Dock = System.Windows.Forms.DockStyle.Right
        Me.lv_Playlist.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_Playlist.ForeColor = System.Drawing.Color.Gray
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
        'pl_Control
        '
        Me.pl_Control.BackColor = System.Drawing.Color.Transparent
        Me.pl_Control.Controls.Add(Me.btn_Mute)
        Me.pl_Control.Controls.Add(Me.trb_Volume)
        Me.pl_Control.Controls.Add(Me.cb_Random)
        Me.pl_Control.Controls.Add(Me.btn_Next)
        Me.pl_Control.Controls.Add(Me.btn_Previous)
        Me.pl_Control.Controls.Add(Me.btn_Play)
        Me.pl_Control.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pl_Control.Location = New System.Drawing.Point(0, 413)
        Me.pl_Control.Name = "pl_Control"
        Me.pl_Control.Size = New System.Drawing.Size(704, 74)
        Me.pl_Control.TabIndex = 4
        '
        'btn_Mute
        '
        Me.btn_Mute.BackgroundImage = Global.PlayerBday13.My.Resources.Resources.unmute
        Me.btn_Mute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Mute.FlatAppearance.BorderSize = 0
        Me.btn_Mute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Mute.Location = New System.Drawing.Point(218, 22)
        Me.btn_Mute.Name = "btn_Mute"
        Me.btn_Mute.Size = New System.Drawing.Size(32, 32)
        Me.btn_Mute.TabIndex = 5
        Me.btn_Mute.UseVisualStyleBackColor = True
        '
        'trb_Volume
        '
        Me.trb_Volume.Location = New System.Drawing.Point(12, 17)
        Me.trb_Volume.Maximum = 100
        Me.trb_Volume.Name = "trb_Volume"
        Me.trb_Volume.Size = New System.Drawing.Size(200, 45)
        Me.trb_Volume.TabIndex = 4
        Me.trb_Volume.TickFrequency = 100
        Me.trb_Volume.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.trb_Volume.Value = 50
        '
        'cb_Random
        '
        Me.cb_Random.AutoSize = True
        Me.cb_Random.Location = New System.Drawing.Point(634, 50)
        Me.cb_Random.Name = "cb_Random"
        Me.cb_Random.Size = New System.Drawing.Size(67, 19)
        Me.cb_Random.TabIndex = 3
        Me.cb_Random.Text = "zufällig"
        Me.cb_Random.UseVisualStyleBackColor = True
        '
        'btn_Next
        '
        Me.btn_Next.BackgroundImage = Global.PlayerBday13.My.Resources.Resources._next
        Me.btn_Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Next.FlatAppearance.BorderSize = 0
        Me.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Next.Location = New System.Drawing.Point(387, 12)
        Me.btn_Next.Name = "btn_Next"
        Me.btn_Next.Size = New System.Drawing.Size(52, 52)
        Me.btn_Next.TabIndex = 2
        Me.btn_Next.UseVisualStyleBackColor = True
        '
        'btn_Previous
        '
        Me.btn_Previous.BackgroundImage = Global.PlayerBday13.My.Resources.Resources.previous
        Me.btn_Previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Previous.FlatAppearance.BorderSize = 0
        Me.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Previous.Location = New System.Drawing.Point(256, 12)
        Me.btn_Previous.Name = "btn_Previous"
        Me.btn_Previous.Size = New System.Drawing.Size(52, 52)
        Me.btn_Previous.TabIndex = 1
        Me.btn_Previous.UseVisualStyleBackColor = True
        '
        'btn_Play
        '
        Me.btn_Play.BackgroundImage = Global.PlayerBday13.My.Resources.Resources.play
        Me.btn_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Play.FlatAppearance.BorderSize = 0
        Me.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Play.Location = New System.Drawing.Point(316, 6)
        Me.btn_Play.Name = "btn_Play"
        Me.btn_Play.Size = New System.Drawing.Size(64, 63)
        Me.btn_Play.TabIndex = 0
        Me.btn_Play.UseVisualStyleBackColor = True
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
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(720, 525)
        Me.Name = "Player_GUI"
        Me.Text = "Player"
        Me.pl_Control.ResumeLayout(False)
        Me.pl_Control.PerformLayout()
        CType(Me.trb_Volume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Cover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lv_Playlist As System.Windows.Forms.ListView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pb_Cover As System.Windows.Forms.PictureBox
    Friend WithEvents pl_Control As System.Windows.Forms.Panel
    Friend WithEvents btn_Next As System.Windows.Forms.Button
    Friend WithEvents btn_Previous As System.Windows.Forms.Button
    Friend WithEvents btn_Play As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cb_Random As System.Windows.Forms.CheckBox
    Friend WithEvents trb_Volume As System.Windows.Forms.TrackBar
    Friend WithEvents btn_Mute As System.Windows.Forms.Button

End Class
