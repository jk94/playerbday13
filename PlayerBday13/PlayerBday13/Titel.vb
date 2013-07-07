Option Strict On
Imports System.IO
Imports TagLib
Public Class Titel

    Private _location As String


    Public Sub New(ByVal location As String)
        Me.Location = location

        Dim mFile As TagLib.File = Nothing
        Try
            mFile = TagLib.File.Create(location)
        Catch ex As Exception
        End Try
    End Sub

    Public Property Location As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
        End Set
    End Property

    Public Property Cover(ByVal pwidth As Integer, ByVal pheight As Integer) As Drawing.Image
        Get
            Dim img As Drawing.Image
            'Albumcover
            If MFile.Tag.Pictures.Length >= 1 Then
                Dim bin As Byte() = DirectCast(MFile.Tag.Pictures(0).Data.Data, Byte())
                img = Drawing.Image.FromStream(New MemoryStream(bin)).GetThumbnailImage(pwidth, pheight, Nothing, System.IntPtr.Zero)
            Else : img = My.Resources.DefaultCover
            End If

            Return img
        End Get
        Private Set(value As Drawing.Image)

        End Set
    End Property

    Public Property STitel As String
        Get
            Dim ret As String = ""
            If MFile.Tag.Title <> "" Then
                ret = MFile.Tag.Title
            Else
                ret = Location
            End If
            Return ret
        End Get
        Private Set(value As String)

        End Set
    End Property
    Public Property Artist As String
        Get
            Return MFile.Tag.FirstPerformer
        End Get
        Private Set(value As String)

        End Set
    End Property
    Public Property Album As String
        Get
            Return MFile.Tag.Album
        End Get
        Private Set(value As String)

        End Set
    End Property
    Public Property BPM As String
        Get
            Return MFile.Tag.BeatsPerMinute.ToString()
        End Get
        Private Set(value As String)

        End Set
    End Property
    Public Property Track As String
        Get
            Return MFile.Tag.Track.ToString()
        End Get
        Private Set(value As String)

        End Set
    End Property

    Private Property MFile As TagLib.File
        Get
            Dim mf As TagLib.File = Nothing
            Try
                mf = TagLib.File.Create(Location)
            Catch ex As Exception
            End Try

            Return mf
        End Get
        Set(value As TagLib.File)

        End Set
    End Property

End Class
