Public Class Window8
    Private Sub LoadData(sender As Object, e As RoutedEventArgs)
        Dim cbo As ComboBoxWithFoot2 = CType（sender, ComboBoxWithFoot2)
        cbo.ItemsSource = New String() {"items 1", "items 2", "items 3"}
    End Sub
End Class
