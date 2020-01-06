Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Controls.Primitives

Public Class MonthCalendar
    Implements INotifyPropertyChanged

    Public Event YearChanged(Year As Integer)
    Public Event MonthLockChanged(Month As Integer, Locked As Boolean)
    Private _year As Integer = Now.Year
    Public Property Year As Integer
        Get
            Return _year
        End Get
        Set(value As Integer)
            _year = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Year"))
        End Set
    End Property

    Public ReadOnly Property LockMonths As New ObservableCollection(Of Boolean) From {False, False, False, False, False, False,
                                                                                        False, False, False, False, False, False}

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub MinusYear(sender As Object, e As RoutedEventArgs)
        Year -= 1
        RaiseEvent YearChanged(Year)
    End Sub

    Private Sub AddYear(sender As Object, e As RoutedEventArgs)
        Year += 1
        RaiseEvent YearChanged(Year)
    End Sub

    Private Sub LockMonthChanged(sender As Object, e As RoutedEventArgs)
        Dim bt As ToggleButton = CType(sender, ToggleButton)
        RaiseEvent MonthLockChanged(CInt(bt.Content), bt.IsChecked)
    End Sub
End Class
