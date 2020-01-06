Imports System.ComponentModel

Public Class FindBox
    Implements INotifyPropertyChanged

    Public Event FindButtonClick(sender As Object, key As String)

    Private _key As String
    Public Property Key As String
        Get
            Return _key
        End Get
        Set(value As String)
            _key = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Key"))
        End Set
    End Property

    Public Property ContextMenus As ContextMenu

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub FindClick(sender As Object, e As RoutedEventArgs)
        RaiseEvent FindButtonClick(Me, Key)
    End Sub
End Class
