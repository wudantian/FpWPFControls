Imports System.ComponentModel

Public Class StudentWithComment
    Inherits Student

    Private _comments As ObservableDictionary(Of String, Comment)

    Public Property Comments As ObservableDictionary(Of String, Comment)
        Get
            Return _comments
        End Get
        Set
            _comments = Value
            OnPopertyChanged("Comments")
        End Set
    End Property
End Class
