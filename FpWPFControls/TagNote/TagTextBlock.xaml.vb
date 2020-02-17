Imports System.Collections.ObjectModel
Imports System.ComponentModel
Public Class TagTextBlock
    Implements INotifyPropertyChanged

    Private _text As String
    Private _noteString As String

    Public Shared TextProperty As DependencyProperty =
        DependencyProperty.Register("Text", GetType(String), GetType(TagTextBlock),
                   New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.AffectsRender, New PropertyChangedCallback(AddressOf TextChangedCallBack)))

    Private Shared Sub TextChangedCallBack(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim box = CType(d, TagTextBlock)
        If e.NewValue Is Nothing Then
            box.Text = String.Empty
        Else
            box.Text = e.NewValue.ToString
        End If
    End Sub

    Public Property Text As String
        Get
            Return $"{_bar.TagsNote}{NoteString}"
        End Get
        Set
            Debug.Print("set text")
            _text = Value
            SetValue(TextProperty, Value)
            ReadText(Value)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
        End Set
    End Property

    Public Property TagsString As String

    Public Property NoteString As String
        Get
            Return _NoteString
        End Get
        Set
            Debug.Print("set note")
            _noteString = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("NoteString"))
        End Set
    End Property
    Public ReadOnly Property ActiveTag As TagNote
        Get
            Return _bar.ActiveTag
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

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
        _bar.ClearTags()
        If tagStrBuilder.Length > 0 Then
            Me.NoteString = str
            _bar.AddTags(tagStrBuilder.ToString)
        Else
            Me.NoteString = str
        End If
    End Sub

    Private Sub TagTextBlock_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Debug.Print("loaded text block")
    End Sub

    Private Sub TagTextBlock_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        Debug.Print("initial text block")
    End Sub
End Class
