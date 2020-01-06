Imports System.ComponentModel

Public Class TagNote
    Implements INotifyPropertyChanged

    Public Delegate Sub CloseTagDelegate()


    Public Property OnCloseTag As CloseTagDelegate

    Private _note As String
    Public Property Note As String
        '格式为text:backgroudcolor,textcolor
        Get
            Return ToNote()
        End Get
        Set(value As String)
            ReadFromNote(value)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Note"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("BackGroudColor"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("TextColor"))
        End Set
    End Property

    Private _text As String = "TagNote"
    Public Property Text As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
        End Set
    End Property

    Private _backGroudColor As Color = ColorConverter.ConvertFromString("#FF0078D7")
    Public Property BackGroudColor As Color
        Get
            Return _backGroudColor
        End Get
        Set(value As Color)
            _backGroudColor = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("BackGroudColor"))
        End Set
    End Property

    Private _textColor As Color = ColorConverter.ConvertFromString("#FF000000")
    Public Property TextColor As Color
        Get
            Return _textColor
        End Get
        Set(value As Color)
            _textColor = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("TextColor"))
        End Set
    End Property

    Private _isActive As Boolean = False
    Public Property IsActive As Boolean
        Get
            Return _isActive
        End Get
        Set(value As Boolean)
            _isActive = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsActive"))
        End Set
    End Property

    Private Function ToNote() As String
        Return $"{Me.Text.Trim}:{Me.BackGroudColor.ToString},{Me.TextColor.ToString}"
    End Function

    Private Sub ReadFromNote(value As String)
        Dim tmps = value.Split(New Char() {"{"c, "}"c, ":"c, ","c})
        If tmps.Count > 0 Then
            Me.Text = tmps.First.Trim
            If tmps.Count > 1 Then
                Me.BackGroudColor = ColorConverter.ConvertFromString(tmps(1))
            End If
            If tmps.Count > 2 Then
                Me.TextColor = ColorConverter.ConvertFromString(tmps(2))
            End If
        End If
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub ChangeActive(sender As Object, e As MouseButtonEventArgs)
        Me.IsActive = Not Me.IsActive
    End Sub

    Private Sub CloseTag(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
