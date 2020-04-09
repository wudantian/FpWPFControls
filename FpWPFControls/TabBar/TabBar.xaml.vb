Imports System.Collections.ObjectModel

Public Class TabBar
    Private _itemSource As IEnumerable(Of Object)
    Public Property Tabs As New ObservableCollection(Of crlTabHeader)

    Public Property DispPlanName As String
    Public Delegate Sub TabCloseDelegate(obj As Object, ByRef isClose As Boolean)

    Public Property OnTabClose As TabCloseDelegate

    Public Property ItemSource As IEnumerable(Of Object)
        Get
            Return _ItemSource
        End Get
        Set
            _itemSource = Value
            Tabs.Clear()
            If Value IsNot Nothing Then
                For Each one In Value
                    Dim tmp As New crlTabHeader
                    AddHandler tmp.CloseButtonClick, AddressOf TabClosed
                    tmp.Tag = one
                    tmp.Header = one.ToString
                    Tabs.Add(tmp)
                Next
            End If
        End Set
    End Property

    Private Sub TabClosed(sender As Object, e As RoutedEventArgs)
        If Me.OnTabClose IsNot Nothing Then
            Dim tab = CType(sender, crlTabHeader)
            Dim isClose As Boolean = True
            Me.OnTabClose.Invoke(tab.Tag, isClose)
            If isClose Then
                Tabs.Remove(tab)
            End If
        End If
    End Sub
End Class
