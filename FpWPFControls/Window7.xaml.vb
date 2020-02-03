Imports System.Collections.ObjectModel

Public Class Window7

    Public Property Students As New ObservableCollection(Of Student)

    Private Sub Initialdata()
        Students.Add(New Student With {
            .Name = "wang",
            .Sex = "male",
            .Note = "good {good}{better}student"
        })
        Students.Add(New Student With {
            .Name = "li xiang",
            .Sex = "femal",
            .Note = "normal student"
        })
        Students.Add(New Student With {
            .Name = "zhang qi",
            .Sex = "male",
            .Note = "bad student"
        })

    End Sub

    Private Sub Window7_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Initialdata()
    End Sub

    Private Sub Filter(sender As Object, e As RoutedEventArgs)
        If dgdMain.SelectedCells.Count > 0 Then
            Dim cell As DataGridCellInfo = dgdMain.SelectedCells.First
            If cell.Column.SortMemberPath = "Note" Then
                Dim content = cell.Column.GetCellContent(cell.Item)
                Dim child = VisualTreeHelper.GetChild(content, 0)
                If TypeOf (child) Is TagTextBlock Then
                    Dim key As String = CType(child, TagTextBlock).ActiveTag.Text
                    Debug.Print(key)
                End If
            End If
        End If
    End Sub

    Private Sub LoadTags(sender As Object, e As RoutedEventArgs)
        If Not myPopup.IsOpen Then
            _tagList.AddTags("{test}{简单,9}{没有结算,4}")
            myPopup.IsOpen = True
        End If
    End Sub

    Private Sub ClosePopup(sender As Object, e As DependencyPropertyChangedEventArgs)
        If Not myPopup.IsFocused Then
            myPopup.IsOpen = False
        End If
    End Sub
End Class
