Imports System.Windows.Controls.Primitives

Public Class ExpandButton
    Inherits ToggleButton

    Public Sub New()
        CheckedContent = New Path With {.Data = Geometry.Parse("M0,0 L10,0"),
                                        .Stroke = Brushes.Black,
                                        .Stretch = Stretch.Fill,
                                        .Margin = New Thickness(1)}
        UnCheckedContent = New Path With {.Data = Geometry.Parse("M0,0 L10,0 M5,10 L5,-10"),
                                        .Stroke = Brushes.Black,
                                        .Stretch = Stretch.Fill,
                                        .Margin = New Thickness(1)}
    End Sub

    Public Property CheckedContent As Object
    Public Property UnCheckedContent As Object

    Public Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()
        SetContent()
    End Sub

    Private Sub ExpandButton_Checked(sender As Object, e As RoutedEventArgs) Handles Me.Checked
        SetContent()
    End Sub

    Private Sub SetContent()
        If Me.IsChecked Then
            Me.Content = CheckedContent
        Else
            Me.Content = UnCheckedContent
        End If
    End Sub

    Private Sub ExpandButton_Unchecked(sender As Object, e As RoutedEventArgs) Handles Me.Unchecked
        SetContent()
    End Sub
End Class
