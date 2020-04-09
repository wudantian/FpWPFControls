Imports System.Globalization

Public Class DictionaryToVisibilityConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        If TypeOf (value) Is Dictionary(Of String, Comment) Then
            If parameter Is Nothing Then
                Return Visibility.Collapsed
            Else
                Dim key = parameter.ToString
                Dim dic = CType(value, Dictionary(Of String, Comment))
                If dic.ContainsKey(key) Then
                    Return Visibility.Visible
                Else
                    Return Visibility.Collapsed
                End If
            End If
        Else
            Return Visibility.Collapsed
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return value
    End Function
End Class
