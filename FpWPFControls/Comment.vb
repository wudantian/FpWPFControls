Imports System.ComponentModel
Public Class Comment
    Implements INotifyPropertyChanged

    Private _text As String

    Public Property Text As String
        Get
            Return _Text
        End Get
        Set
            _text = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Text"))
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Overrides Function ToString() As String
        Return Me.Text
    End Function
End Class
