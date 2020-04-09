Imports System.Collections.ObjectModel

Public Class Window12
    Public Property MyTitles As New ObservableCollection(Of String)

    Private Sub Window12_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        MyTitles.Add("tab1")
        MyTitles.Add("tab2")
    End Sub
End Class
