Imports System.ComponentModel

Public Class frmNewTag
    Implements INotifyPropertyChanged

    Private _title As String

    Public Property TagTitle As String
        Get
            Return _title
        End Get
        Set
            _title = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("TagTitle"))
            SampleTags = $"{{{_title},0}}
                            {{{_title},1}}
                            {{{_title},2}}
                            {{{_title},3}}
                            {{{_title},4}}
                            {{{_title},5}}
                            {{{_title},6}}
                            {{{_title},7}}
                            {{{_title},8}}
                            {{{_title},9}} "

            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("SampleTags"))
        End Set
    End Property

    Public Property SampleTags As String

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
End Class
