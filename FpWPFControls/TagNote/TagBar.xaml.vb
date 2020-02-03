Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class TagBar
    Implements INotifyPropertyChanged

    Public Event HaveDeletedTags()

    Public Shared TagsNoteProperty As DependencyProperty =
        DependencyProperty.Register("TagsNote", GetType(String), GetType(TagBar),
                   New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.AffectsRender,
                                                 New PropertyChangedCallback(AddressOf TagsNoteChangedCallBack)))

    Private Shared Sub TagsNoteChangedCallBack(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim bar = CType(d, TagBar)
        If e.NewValue Is Nothing Then
            bar.TagsNote = String.Empty
        Else
            bar.TagsNote = e.NewValue.ToString
        End If
    End Sub

    Private _tagsNote As String
    Public Property TagsNote As String
        Get
            Return ToTagsString()
        End Get
        Set(value As String)
            _tagsNote = value
            SetValue(TagsNoteProperty, value)
            Tags.Clear()
            AddTags(_tagsNote)
        End Set
    End Property

    Public Property Tags As New ObservableCollection(Of TagNote)

    Private _tag As TagNote
    Public ReadOnly Property ActiveTag As TagNote
        Get
            If Tags.Count > 0 Then
                Return Tags.FirstOrDefault(Function(t) t.IsActive)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property IsReadonly As Boolean = False

    Public Property IsKeepFocus As Boolean = False

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub AddTags(str As String)
        Dim tmps() As String = str.Split(New Char() {"{"c, "}"c})
        If tmps IsNot Nothing AndAlso tmps.Count > 0 Then
            For Each n In tmps
                If n.Trim.Length > 0 Then
                    Dim tag As New TagNote With
                        {.Note = n,
                        .OnCloseTag = AddressOf DeleteTag,
                        .OnFocusTag = AddressOf FocusTag,
                        .IsReadOnly = Me.IsReadonly
                        }
                    Tags.Add(tag)
                End If
            Next
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("TagsNote"))
        RaiseEvent HaveDeletedTags()
    End Sub

    Public Sub ClearTags()
        Tags.Clear()
    End Sub

    Private Sub DeleteTag(tag As TagNote)
        Tags.Remove(tag)
        RaiseEvent HaveDeletedTags()
    End Sub

    Private Sub FocusTag(tag As TagNote)
        If _tag IsNot Nothing AndAlso _tag IsNot tag Then
            _tag.IsActive = False
        End If
        _tag = tag
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ActiveTag"))
    End Sub

    Private Function ToTagsString() As String
        Dim tagStr As New Text.StringBuilder
        For Each t In Tags
            tagStr.Append(t.Note)
        Next
        Return tagStr.ToString
    End Function

    Private Sub LostTagsFocus(sender As Object, e As RoutedEventArgs)
        If IsKeepFocus AndAlso Me.ActiveTag Is Nothing Then
            _tag.IsActive = True
        End If
    End Sub
End Class
