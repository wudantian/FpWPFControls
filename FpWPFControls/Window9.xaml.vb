Public Class Window9
    Private Sub AddTab(sender As Object, e As RoutedEventArgs)
        Dim ls As New List(Of Student) From {
            New Student With {.Name = "张三"},
            New Student With {.Name = "李四"},
            New Student With {.Name = "王五"}
        }

        _bar.ItemSource = ls
        _bar.OnTabClose = New TabBar.TabCloseDelegate(AddressOf CloseTab)
    End Sub

    Private Sub CloseTab(obj As Object, ByRef isClosed As Boolean)
        If MessageBox.Show("Delete?", "Del", MessageBoxButton.YesNo) = MessageBoxResult.Yes Then
            isClosed = True
        Else
            isClosed = False
        End If
    End Sub

    Private Sub AddTab2(sender As Object, e As RoutedEventArgs)
        Dim ls As New List(Of Student) From {
            New Student With {.Name = "aaaa"},
            New Student With {.Name = "bbb"},
            New Student With {.Name = "ccc"}
        }

        _bar.ItemSource = ls
    End Sub
End Class
