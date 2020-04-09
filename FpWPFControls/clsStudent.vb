Imports System.ComponentModel

Public Class Student
    Implements INotifyPropertyChanged

    Private _Name As String
    Private _Sex As String
    Private _Note As String

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set
            _Name = Value
            OnPopertyChanged("Name")
        End Set
    End Property

    Public Property Sex As String
        Get
            Return _Sex
        End Get
        Set
            _Sex = Value
            OnPopertyChanged("Sex")
        End Set
    End Property

    Public Property Note As String
        Get
            Return _Note
        End Get
        Set
            _Note = Value
            OnPopertyChanged("Note")
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub OnPopertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
End Class
