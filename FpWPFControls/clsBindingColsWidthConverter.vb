Imports System.Globalization

Public Class BindingColsWidthConverter
    Implements IMultiValueConverter

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        If values Is Nothing Then
            Throw New ArgumentNullException
        Else
            Dim width As Double = 0
            For Each one In values
                width += one
            Next

            Return New GridLength(width)
        End If
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
