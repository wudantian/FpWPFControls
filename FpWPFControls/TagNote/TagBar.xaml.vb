Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class TagBar
    Implements INotifyPropertyChanged

    Private _tagsNote As String
    Public Property TagsNote As String
        Get
            Return _tagsNote
        End Get
        Set(value As String)
            _tagsNote = value
            BuildTags()
        End Set
    End Property

    Public Property Tags As New ObservableCollection(Of TagNote)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub BuildTags()
        Tags.Clear()
        Dim tmps() As String = _tagsNote.Split(New Char() {"{"c, "}"c})
        If tmps IsNot Nothing AndAlso tmps.Count > 0 Then
            For Each n In tmps
                If n.Trim.Length > 0 Then
                    Dim tag As New TagNote With {.Note = n}
                    Tags.Add(tag)
                End If
            Next
        End If
    End Sub
End Class
