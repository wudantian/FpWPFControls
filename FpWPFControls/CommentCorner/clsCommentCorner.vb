Public Class CommentCorner
    Inherits Shape

    Public Shared ReadOnly Property MouseDoubleClickEvent As RoutedEvent = EventManager.RegisterRoutedEvent("MouseDoubleClick", RoutingStrategy.Direct, GetType(RoutedEventHandler), GetType(CommentCorner))

    Public Custom Event MouseDoubleClick As RoutedEventHandler
        AddHandler(value As RoutedEventHandler)
            Me.AddHandler(MouseDoubleClickEvent, value)
        End AddHandler
        RemoveHandler(value As RoutedEventHandler)
            Me.RemoveHandler(MouseDoubleClickEvent, value)
        End RemoveHandler
        RaiseEvent(sender As Object, e As RoutedEventArgs)

        End RaiseEvent
    End Event

    Protected Overrides ReadOnly Property DefiningGeometry As Geometry
        Get
            Dim geometry = New StreamGeometry
            geometry.FillRule = FillRule.EvenOdd

            Using c As StreamGeometryContext = geometry.Open
                c.BeginFigure(New Point(0, 0), True, True)
                c.LineTo(New Point(10, 10), True, True)
                c.LineTo(New Point(10, 0), True, True)
                c.LineTo(New Point(0, 0), True, True)
            End Using

            geometry.Freeze()
            Return geometry
        End Get
    End Property

    Private Sub OnMouseDoubleClick()
        Dim args = New RoutedEventArgs(MouseDoubleClickEvent, Me)
        [RaiseEvent](args)
    End Sub

    Private Sub CommentCorner_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseLeftButtonDown
        OnMouseDoubleClick()
    End Sub
End Class
