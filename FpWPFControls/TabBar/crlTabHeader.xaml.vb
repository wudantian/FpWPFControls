Imports System.ComponentModel

Public Class crlTabHeader
    Implements INotifyPropertyChanged

    Public Shared HeaderProperty As DependencyProperty =
        DependencyProperty.Register("Header", GetType(String), GetType(crlTabHeader))

    Private _isShowClose As Boolean
    Private _header As String

    Public Property Header As String
        Get
            Return _header
        End Get
        Set
            _header = Value
            SetValue(HeaderProperty, Value)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Header"))
        End Set
    End Property

    Public Event CloseButtonClick(sender As Object, e As RoutedEventArgs)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property IsShowClose As Boolean
        Get
            Return _isShowClose
        End Get
        Set
            _isShowClose = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("IsShowClose"))
        End Set
    End Property

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        RaiseEvent CloseButtonClick(Me, e)
    End Sub

    Public Sub New(header As String)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.Header = header
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Private Sub ShowClose(sender As Object, e As MouseEventArgs)
        IsShowClose = True
    End Sub

    Private Sub HideClose(sender As Object, e As MouseEventArgs)
        IsShowClose = False
    End Sub
End Class
