Imports System.Collections.ObjectModel

Public Class Window13
    Private Sub Window13_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim cols() As DataGridColumn = {grdMain.Columns(0), grdMain.Columns(1), grdMain.Columns(2)}
        SetTitleWidth(grdTitle.ColumnDefinitions.First, cols)
        SetTitleWidth(grdTitle.ColumnDefinitions(1), {grdMain.Columns(3)})
        SetTitleWidth(grdTitle.ColumnDefinitions(2), {grdMain.Columns(4), grdMain.Columns(5)})

        Dim sViewer = GetScrollViewer(grdMain)
        AddHandler sViewer.ScrollChanged, AddressOf DatagridScroll
    End Sub

    Private Sub DatagridScroll(sender As Object, e As ScrollChangedEventArgs)
        Debug.Print($"horizontalchange {e.HorizontalChange}")
        Debug.Print($"horizontaloffset {e.HorizontalOffset}")
        grdTitle.Margin = New Thickness(-e.HorizontalOffset, 0, 0, 0)
    End Sub

    Private Function GetScrollViewer(obj As DependencyObject) As ScrollViewer
        If TypeOf (obj) Is ScrollViewer Then
            Return CType(obj, ScrollViewer)
        End If
        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(obj)
            Dim result = GetScrollViewer(VisualTreeHelper.GetChild(obj, i))
            If result IsNot Nothing Then
                Return result
            End If
        Next
        Return Nothing
    End Function

    Private Sub SetTitleWidth(colDef As ColumnDefinition, cols() As DataGridColumn)
        Dim bind As New MultiBinding With {.Converter = New BindingColsWidthConverter}
        For Each col In cols
            bind.Bindings.Add(New Binding With {.ElementName = "grdMain",
                              .Path = New PropertyPath($"Columns[{grdMain.Columns.IndexOf(col)}].ActualWidth")})
        Next

        colDef.SetBinding(ColumnDefinition.WidthProperty, bind)
    End Sub

    Public Property TestDatasource As New ObservableCollection(Of List(Of Integer)) From {New List(Of Integer) From {1, 2, 3, 4, 5, 6},
                                                                                            New List(Of Integer) From {23, 45, 12, 84, 34, 68},
                                                                                            New List(Of Integer) From {23, 45, 12, 84, 34, 68},
                                                                                            New List(Of Integer) From {23, 45, 12, 84, 34, 68},
                                                                                            New List(Of Integer) From {23, 45, 12, 84, 34, 68}}
End Class
