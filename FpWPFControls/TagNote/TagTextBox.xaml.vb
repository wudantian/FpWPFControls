Imports System.Collections.ObjectModel
Imports System.ComponentModel
Public Class TagTextBox
    Implements INotifyPropertyChanged
    Private _noteString As String
    Private _tagsString As String
    Private _text As String
    Private _isReadOnly As Boolean = False

    Public Shared TextProperty As DependencyProperty =
        DependencyProperty.Register("Text", GetType(String), GetType(TagTextBox),
                   New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf TextChangedCallBack)))

    Private Shared Sub TextChangedCallBack(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim box = CType(d, TagTextBox)
        If e.NewValue Is Nothing Then
            box.Text = String.Empty
        Else
            box.Text = e.NewValue.ToString
        End If
    End Sub


    Public Property Text As String
        Get
            Return $"{_bar.TagsNote}{_noteString}"
        End Get
        Set
            Debug.Print("text box text")
            _text = Value
            SetValue(TextProperty, Value)
            ReadText(_text)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("TagsString"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NoteString"))
        End Set
    End Property

    Public ReadOnly Property TagsString As String
        Get
            Return _tagsString
        End Get
    End Property

    Public Property NoteString As String
        Get
            Return _noteString
        End Get
        Set(value As String)
            _noteString = value
            SetValue(TextProperty, Me.Text)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NoteString"))
            'RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
        End Set
    End Property

    Public Property IsReadOnly As Boolean
        Get
            Return _IsReadOnly
        End Get
        Set
            _IsReadOnly = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsReadOnly"))
        End Set
    End Property

    Public ReadOnly Property ActiveTag As TagNote
        Get
            Return _bar.ActiveTag
        End Get
    End Property

    Public ReadOnly Property SelectedText As String
        Get
            Return _txt.SelectedText
        End Get
    End Property


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    'Private Sub ReadText()
    '    If _text IsNot Nothing AndAlso _text.Length > 0 Then
    '        Dim pos As Integer = _text.LastIndexOf("}"c)
    '        If pos = -1 Then
    '            _noteString = _text
    '        Else
    '            _tagsString = _text.Substring(0, pos + 1)
    '            _noteString = _text.Substring(pos + 1)
    '        End If
    '    End If
    'End Sub

    Private Sub ReadText(str As String)
        Dim tagStrBuilder As New Text.StringBuilder
        If str IsNot Nothing AndAlso str.Length > 0 Then
            Dim startPos As Integer = str.IndexOf("{"c)
            Dim endPos As Integer = 0
            Do While startPos > -1
                endPos = str.IndexOf("}"c, startPos + 1)
                If endPos > 0 Then
                    tagStrBuilder.Append(str.Substring(startPos, endPos - startPos + 1))
                    str = str.Remove(startPos, endPos - startPos + 1)
                    startPos = str.IndexOf("{"c)
                Else
                    Exit Do
                End If
            Loop
        End If
        If tagStrBuilder.Length > 0 Then
            Me.NoteString = str
            _bar.ClearTags()
            _bar.AddTags(tagStrBuilder.ToString)
        Else
            Me.NoteString = str
        End If
    End Sub

    Private Sub _txt_KeyUp(sender As Object, e As KeyEventArgs) Handles _txt.KeyUp
        If e.Key = Key.Enter Then
            '_txt.Text = AppendTags(_txt.Text)
            ReadText(_txt.Text)
        End If
    End Sub

    Private Sub TagsChanged()
        _tagsString = _bar.TagsNote
        SetValue(TextProperty, Me.Text)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
    End Sub
End Class
