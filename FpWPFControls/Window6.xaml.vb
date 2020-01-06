Public Class Window6
    Private Sub Initialdata()
        Dim result1 As New VCalvScreen With {.P = 1.0345, .Pc = 15, .C = 120, .V = 5321,
                                            .P20 = 1.0234, .VCF = 0.987, .Weight = 35.23
        }
        Dim result2 As New VCalvScreen With {.P = 1.0345, .Pc = 15, .C = 120, .V = 5321,
                                            .P20 = 1.0234, .VCF = 0.987, .Weight = 35.23
        }

        palValues.Children.Add(result1)
        palValues.Children.Add(result2)
    End Sub

    Private Sub Window6_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        'Initialdata()
    End Sub

    Private Sub AddValue(sender As Object, e As RoutedEventArgs)
        Dim result As New VCalvScreen With {.P = 1.0345, .Pc = 15, .C = 120, .V = 5321,
                                            .P20 = 1.0234, .VCF = 0.987, .Weight = 35.23
        }
        palValues.Children.Add(result)
        palValues.Children.Add(New VCalvScreen)
        vewScroll.ScrollToEnd()
    End Sub
End Class
