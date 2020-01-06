Public Class Window5
    Private Sub Window5_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Calendar.LockMonths(0) = True
        Calendar.LockMonths(1) = True
        Calendar.LockMonths(2) = True
        Calendar.LockMonths(3) = True
        Calendar.LockMonths(4) = True
        Calendar.LockMonths(5) = True
    End Sub

    Private Sub HaveChangedYear(Year As Integer)
        Debug.Print($"have changed year {Year}")
    End Sub

    Private Sub HaveLockChangedMonth(Month As Integer, Locked As Boolean)
        Debug.Print($"have lock changed month {Month} {Locked}")
    End Sub
End Class
