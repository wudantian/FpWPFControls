Imports System.ComponentModel

Public Class ObservableDictionary(Of T1, T2)
    Implements IDictionary(Of T1, T2)
    Implements INotifyPropertyChanged

    Private _dic As Dictionary(Of T1, T2)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New()
        _dic = New Dictionary(Of T1, T2)
    End Sub

    Default Public Property Item(key As T1) As T2 Implements IDictionary(Of T1, T2).Item
        Get
            If key Is Nothing Then
                Throw New ArgumentNullException("key")
            End If
            Dim value As T2
            _dic.TryGetValue(key, value)
            Return value
        End Get
        Set(value As T2)
            If (key Is Nothing) Then
                Throw New ArgumentNullException("key")
            End If
            _dic(key) = value
            FireDictionaryChanged()
        End Set
    End Property

    Public ReadOnly Property Keys As ICollection(Of T1) Implements IDictionary(Of T1, T2).Keys
        Get
            Return _dic.Keys
        End Get
    End Property

    Public ReadOnly Property Values As ICollection(Of T2) Implements IDictionary(Of T1, T2).Values
        Get
            Return _dic.Values
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements ICollection(Of KeyValuePair(Of T1, T2)).Count
        Get
            Return _dic.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of KeyValuePair(Of T1, T2)).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Private Sub FireDictionaryChanged()
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Nothing))
    End Sub

    Public Sub Add(key As T1, value As T2) Implements IDictionary(Of T1, T2).Add
        _dic.Add(key, value)
        FireDictionaryChanged()
    End Sub

    Public Sub Add(item As KeyValuePair(Of T1, T2)) Implements ICollection(Of KeyValuePair(Of T1, T2)).Add
        _dic.Add(item.Key, item.Value)
        FireDictionaryChanged()
    End Sub

    Public Sub Clear() Implements ICollection(Of KeyValuePair(Of T1, T2)).Clear
        _dic.Clear()
        FireDictionaryChanged()
    End Sub

    Public Sub CopyTo(array() As KeyValuePair(Of T1, T2), arrayIndex As Integer) Implements ICollection(Of KeyValuePair(Of T1, T2)).CopyTo
        Throw New NotImplementedException()
    End Sub

    Public Function ContainsKey(key As T1) As Boolean Implements IDictionary(Of T1, T2).ContainsKey
        Return _dic.ContainsKey(key)
    End Function

    Public Function Remove(key As T1) As Boolean Implements IDictionary(Of T1, T2).Remove
        Dim result = _dic.Remove(key)
        FireDictionaryChanged()
        Return result
    End Function

    Public Function Remove(item As KeyValuePair(Of T1, T2)) As Boolean Implements ICollection(Of KeyValuePair(Of T1, T2)).Remove
        Dim result = _dic.Remove(item.Key)
        FireDictionaryChanged()
        Return result
    End Function

    Public Function TryGetValue(key As T1, ByRef value As T2) As Boolean Implements IDictionary(Of T1, T2).TryGetValue
        Return _dic.TryGetValue(key, value)
    End Function

    Public Function Contains(item As KeyValuePair(Of T1, T2)) As Boolean Implements ICollection(Of KeyValuePair(Of T1, T2)).Contains
        Return _dic.Contains(item)
    End Function

    Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of T1, T2)) Implements IEnumerable(Of KeyValuePair(Of T1, T2)).GetEnumerator
        Return _dic.GetEnumerator
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return _dic.GetEnumerator
    End Function
End Class
