Imports System.Windows.Controls.Primitives

Public Class ComboBoxWithFoot2
    Inherits ComboBox

    Private _foot As New ContentPresenter

    Public Property Foot As DependencyObject
        Get
            Return _foot.Content
        End Get
        Set(value As DependencyObject)
            _foot.Content = value
        End Set
    End Property

    Public Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()
        Dim pop As Popup = GetTemplateChild("PART_Popup")
        If pop.Child IsNot Nothing Then
            Dim chd As DependencyObject = pop.Child
            If VisualTreeHelper.GetChildrenCount(chd) > 0 Then
                Dim bd As Border = VisualTreeHelper.GetChild(chd, 0)

                Dim vw As DependencyObject = bd.Child

                Dim gd As New Grid
                gd.RowDefinitions.Add(New RowDefinition())
                gd.RowDefinitions.Add(New RowDefinition With {.Height = New GridLength(0, GridUnitType.Auto)})

                gd.Children.Add(_foot)
                Grid.SetRow(_foot, 1)
                bd.Child = gd
                gd.Children.Add(vw)
                Grid.SetRow(vw, 0)
            End If
        End If
    End Sub
End Class
