Imports System.Collections.ObjectModel
Imports System.ComponentModel

Class MainWindow
    Implements INotifyPropertyChanged

    Private _winHub As New List(Of Window)
    Public ReadOnly Property shots As New ObservableCollection(Of Rectangle)

    Public ReadOnly Property SubCount As Integer
        Get
            Return _winHub.Count
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub ShowSubWin(sender As Object, e As RoutedEventArgs)
        Dim fm As New Window1
        AddHandler fm.Closing, AddressOf SubWinClosing
        AddHandler fm.Deactivated, AddressOf ScreenShot
        _winHub.Add(fm)
        fm.Tag = _winHub.Count
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SubCount"))
        fm.Show()
    End Sub

    Private Sub SubWinClosing(sender As Object, e As CancelEventArgs)
        Dim subWin As Window = sender
        RemoveHandler subWin.Closing, AddressOf SubWinClosing
        RemoveHandler subWin.Deactivated, AddressOf ScreenShot
        _winHub.Remove(subWin)
        Dim query = From s In _shots Where s.Tag = subWin.GetHashCode

        If query.Count = 1 Then
            _shots.Remove(query.First)
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SubCount"))
    End Sub

    Private Sub ScreenShot(sender As Object, e As EventArgs)
        Dim subWin As Window = sender
        Dim rec As New Rectangle With {.Width = lsShots.ActualWidth - 10,
                                        .Height = subWin.ActualHeight}
        Dim vb As New VisualBrush
        vb.Visual = subWin
        rec.Fill = vb
        rec.Tag = subWin.GetHashCode
        _shots.Add(rec)
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        For Each win In _winHub
            RemoveHandler win.Closing, AddressOf SubWinClosing
            RemoveHandler win.Deactivated, AddressOf ScreenShot
            win.Close()
        Next
    End Sub
End Class
