Imports System.Collections.ObjectModel

Public Class Window10
    Public Property Students As New ObservableCollection(Of StudentWithComment)

    Private Sub InitialData()
        Students.Add(New StudentWithComment With {.Name = "zhangshan", .Sex = "male", .Note = "good student"})
        Students.First.Comments = New ObservableDictionary(Of String, Comment)
        Students.First.Comments.Add("name", New Comment With {.Text = "he is a good student"})
        Students.Add(New StudentWithComment With {.Name = "lisi", .Sex = "male", .Note = "normal student"})
        Students.Add(New StudentWithComment With {.Name = "wangwu", .Sex = "female", .Note = "bad student"})
    End Sub

    Private Sub Window10_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        InitialData()
    End Sub

    Private Sub AddComment(sender As Object, e As RoutedEventArgs)
        If grdMain.SelectedCells.Count > 0 Then
            Dim cell = grdMain.SelectedCells.First
            Dim stu = CType(cell.Item, StudentWithComment)
            Dim key = cell.Column.SortMemberPath

            If stu.Comments Is Nothing Then
                stu.Comments = New ObservableDictionary(Of String, Comment)
            End If
            If Not stu.Comments.ContainsKey(key) Then
                stu.Comments.Add(key, New Comment)
            End If
            popComment.DataContext = stu.Comments(key)
            popComment.PlacementTarget = cell.Column.GetCellContent(cell.Item)
            popComment.IsOpen = True
        End If
    End Sub

    Private Sub RemoveComment(sender As Object, e As RoutedEventArgs)
        If grdMain.SelectedCells.Count > 0 Then
            Dim cell = grdMain.SelectedCells.First
            Dim stu = CType(cell.Item, StudentWithComment)
            Dim key = cell.Column.SortMemberPath
            If stu.Comments IsNot Nothing Then
                stu.Comments.Remove(key)
            End If
        End If
    End Sub
End Class
