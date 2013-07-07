Option Strict On
Public Class Playlist

    Private _liste As New List(Of Titel)
    Private _playindex As Integer = -1

    Public Property Liste As List(Of Titel)
        Get
            Return _liste
        End Get
        Set(value As List(Of Titel))
            _liste = value
        End Set
    End Property
    Public Property Liste(ByVal index As Integer) As Titel
        Get
            Return _liste(index)
        End Get
        Set(value As Titel)
            _liste(index) = value
        End Set
    End Property
    Public Sub addTitel(ByRef titel As Titel)
        _liste.Add(titel)
    End Sub
    Public Sub removeTitel(ByVal index As Integer)
        _liste.RemoveAt(index)
    End Sub

    Public Property PlayIndex As Integer
        Get
            Return _playindex
        End Get
        Set(value As Integer)
            _playindex = value
        End Set
    End Property
End Class
