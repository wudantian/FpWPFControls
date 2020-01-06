Imports System.ComponentModel

Public Class TagBox
    Implements INotifyPropertyChanged


    Private _dics As New Dictionary(Of Integer, String)
    Public ReadOnly Property Tags As Dictionary(Of Integer, String)
        Get
            Return _dics
        End Get
    End Property
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub ResetTags()
        _pos = 0
        If _dics.Count > 0 Then
            Tag = _dics.ElementAtOrDefault(_pos).Value
        Else
            Tag = String.Empty
        End If
    End Sub

    Private _pos As Integer = 0
    Private Sub ChangeTag(sender As Object, e As MouseButtonEventArgs)
        ChangeTag(True)
    End Sub

    Private Sub ChangeTag2(sender As Object, e As MouseWheelEventArgs)
        ChangeTag(e.Delta > 0)
    End Sub

    Private Sub ChangeTag(blnPlus As Boolean)
        If _dics.Count > 0 Then

            If blnPlus Then
                _pos += 1
                If _pos > _dics.Count - 1 Then _pos = 0
            Else
                _pos -= 1
                If _pos < 0 Then _pos = _dics.Count - 1
            End If
            Tag = _dics.ElementAtOrDefault(_pos).Value
        End If
    End Sub
End Class
