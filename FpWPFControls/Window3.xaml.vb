Public Class Window3
    Private Sub ShowMenu(sender As Object, key As String)
        Dim fbox As FindBox = sender
        fbox.ContextMenus.IsOpen = True
    End Sub
End Class
