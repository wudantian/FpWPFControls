Public Class Window4
    Private Sub InitialTags(sender As Object, e As RoutedEventArgs)
        myTag.Tags.Add(1, "A")
        myTag.Tags.Add(2, "B")
        myTag.Tags.Add(3, "C")
        myTag.Tags.Add(4, "D")
        myTag.Tags.Add(5, "E")
        myTag.ResetTags()
    End Sub
End Class
