Imports System.ComponentModel

Public Class VCalvScreen
    Implements INotifyPropertyChanged

    Private _pc As Single?
    Public Property Pc As Single?
        Get
            Return _pc
        End Get
        Set(value As Single?)
            _pc = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Pc"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowPc"))
        End Set
    End Property

    Public ReadOnly Property IsShowPc As Visibility
        Get
            If _pc.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Private _p As Single?
    Public Property P As Single?
        Get
            Return _p
        End Get
        Set(value As Single?)
            _p = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("P"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowP"))
        End Set
    End Property

    Public ReadOnly Property IsShowP As Visibility
        Get
            If _p.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Private _p20 As Single?
    Public Property P20 As Single?
        Get
            Return _p20
        End Get
        Set(value As Single?)
            _p20 = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("P20"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowP20"))
        End Set
    End Property

    Public ReadOnly Property IsShowP20 As Visibility
        Get
            If _p20.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Private _c As Single?
    Public Property C As Single?
        Get
            Return _c
        End Get
        Set(value As Single?)
            _c = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("C"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowC"))
        End Set
    End Property

    Public ReadOnly Property IsShowC As Visibility
        Get
            If _c.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Private _v As Integer?
    Public Property V As Integer?
        Get
            Return _v
        End Get
        Set(value As Integer?)
            _v = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("V"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowV"))
        End Set
    End Property

    Public ReadOnly Property IsShowV As Visibility
        Get
            If _v.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Private _vCF As Single?
    Public Property VCF As Single?
        Get
            Return _vCF
        End Get
        Set(value As Single?)
            _vCF = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("VCF"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowVCF"))
        End Set
    End Property

    Public ReadOnly Property IsShowVCF As Visibility
        Get
            If _vCF.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Private _weight As Single?
    Public Property Weight As Single?
        Get
            Return _weight
        End Get
        Set(value As Single?)
            _weight = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Weight"))
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowWeight"))
        End Set
    End Property

    Public ReadOnly Property IsShowWeight As Visibility
        Get
            If _weight.HasValue Then
                Return Visibility.Visible
            Else
                Return Visibility.Collapsed
            End If
        End Get
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


End Class
