Public Class CommentCorner
    Inherits Shape

    Protected Overrides ReadOnly Property DefiningGeometry As Geometry
        Get
            '            StreamGeometry Geometry = New StreamGeometry();
            'Using (StreamGeometryContext c = geometry.Open())
            '{
            'c.BeginFigure(New Point(200, 200), True, True);
            'c.LineTo(New Point(175, 50), True, True);
            'From the Library of Lee Bogdanoff
            'Download at WoweBook.Com
            'ptg
            '18 CHAPTER 2 The Diverse Visual Class Structure
            'c.ArcTo(New Point(50, 150), New Size(1, 1), 0, True,
            'SweepDirection.Counterclockwise, True, True);
            'c.LineTo(New Point(200, 200), True, True);
            '}
            'Return Geometry;
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
End Class
