Imports System.Globalization

Public Class BooleanToVisibilityConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        If CBool(value) Then
            Return Visibility.Visible
        Else
            If parameter Is Nothing Then
                Return Visibility.Collapsed
            Else
                Return Visibility.Hidden
            End If
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return value
    End Function
End Class
