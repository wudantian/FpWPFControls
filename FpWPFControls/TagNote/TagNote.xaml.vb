Imports System.ComponentModel

Public Class TagNote
    Implements INotifyPropertyChanged

    Public Delegate Sub CloseTagDelegate(tag As TagNote)
    Public Delegate Sub FocusTagDelegate(tag As TagNote)

    Public Property OnCloseTag As CloseTagDelegate
    Public Property OnFocusTag As FocusTagDelegate

    Private _note As String
    Public Property Note As String
        '格式为{text,colorindex}
        Get
            Return ToNote()
        End Get
        Set(value As String)
            ReadFromNote(value)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Note"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("BackGroundColor"))
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

    Private _backColor As Color
    Public ReadOnly Property BackGroundColor As Color
        Get
            Return _backColor
        End Get
    End Property

    Private _textColor As Color
    Public ReadOnly Property TextColor As Color
        Get
            Return _textColor
        End Get
    End Property

    Private _colorIndex As Integer = 0
    Public Property ColorIndex As Integer
        Get
            Return _ColorIndex
        End Get
        Set
            _ColorIndex = Value
            Select Case _colorIndex
                Case 1
                    _textColor = Colors.Black
                    _backColor = ColorConverter.ConvertFromString("#FFEEDC39")
                Case 2
                    _textColor = Colors.Black
                    _backColor = ColorConverter.ConvertFromString("#FFFF9A61")
                Case 3
                    _textColor = Colors.Black
                    _backColor = ColorConverter.ConvertFromString("#FF52EE39")
                Case 4
                    _textColor = Colors.Black
                    _backColor = ColorConverter.ConvertFromString("#FFC79DFE")
                Case 5
                    _textColor = Colors.White
                    _backColor = ColorConverter.ConvertFromString("#FF9B8C06")
                Case 6
                    _textColor = Colors.White
                    _backColor = ColorConverter.ConvertFromString("#FFD35209")
                Case 7
                    _textColor = Colors.White
                    _backColor = ColorConverter.ConvertFromString("#FF1F9F0A")
                Case 8
                    _textColor = Colors.White
                    _backColor = ColorConverter.ConvertFromString("#FF0D93DE")
                Case 9
                    _textColor = Colors.White
                    _backColor = ColorConverter.ConvertFromString("#FF8E40F2")
                Case Else
                    _textColor = Colors.Black
                    _backColor = ColorConverter.ConvertFromString("#FF7AC8F4")
            End Select
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("BackGroundColor"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ColorIndex"))
        End Set
    End Property

    Public Property IsReadOnly As Boolean = False

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

    Private _isEdit As Boolean

    Public Property IsEdit As Boolean
        Get
            Return _isEdit
        End Get
        Set
            _isEdit = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsEdit"))
        End Set
    End Property

    Private Function ToNote() As String
        Return $"{{{Me.Text.Trim},{Me.ColorIndex}}}"
    End Function

    Private Sub ReadFromNote(value As String)
        Dim tmps As IEnumerable(Of String)
        If value.First = "{"c AndAlso value.Last = "}"c AndAlso value.Length > 3 Then
            tmps = value.Substring(1, value.Length - 2).Split(","c, "，"c)
        Else
            tmps = value.Split(","c, "，"c)
        End If

        If tmps.Count > 0 Then

            Me.Text = tmps.First.Trim
            If tmps.Count = 2 Then
                Integer.TryParse(tmps.Last, Me.ColorIndex)
            Else
                Me.ColorIndex = 0
            End If
        Else
            Me.Text = "Err"
        End If
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub CloseTag(sender As Object, e As RoutedEventArgs)
        If OnCloseTag IsNot Nothing Then
            OnCloseTag.Invoke(Me)
        End If
    End Sub

    Private Sub ChangeEditCondition(sender As Object, e As MouseButtonEventArgs)
        If Not IsReadOnly Then
            Me.IsEdit = Not Me.IsEdit
        End If
    End Sub

    Private Sub OnFocus(sender As Object, e As RoutedEventArgs)
        Me.IsActive = True
        If OnFocusTag IsNot Nothing Then
            OnFocusTag.Invoke(Me)
        End If
    End Sub

    Private Sub OnFocus(sender As Object, e As MouseButtonEventArgs)
        Me.IsActive = True
        Me.Focus()
    End Sub

    Private Sub OnLost(sender As Object, e As RoutedEventArgs)
        If Me.IsActive Then
            Me.IsActive = False
            Me.IsEdit = False
        End If
        If OnFocusTag IsNot Nothing Then
            OnFocusTag.Invoke(Me)
        End If
    End Sub
End Class
