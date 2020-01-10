Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class TagBar
    Implements INotifyPropertyChanged

    Private _tagsNote As String
    Public Property TagsNote As String
        Get
            Return ToTagsString()
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
                    Dim tag As New TagNote With
                        {.Note = n,
                        .OnCloseTag = AddressOf DeleteTag
                        }
                    Tags.Add(tag)
                End If
            Next
        End If
    End Sub

    Private Sub DeleteTag(tag As TagNote)
        Tags.Remove(tag)
    End Sub

    Private Function ToTagsString() As String
        Dim tagStr As New Text.StringBuilder
        For Each t In Tags
            tagStr.Append(t.Note)
        Next
        Return tagStr.ToString
    End Function

    Private Sub UserControl_LostFocus(sender As Object, e As RoutedEventArgs)
        For Each t In Tags
            If t.IsActive Then t.IsActive = False
        Next
    End Sub

    Private Sub UserControl_MouseDown(sender As Object, e As MouseButtonEventArgs)
        Me.Focus()
    End Sub
End Class
