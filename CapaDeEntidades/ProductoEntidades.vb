'Clase Productos con sus atributos / características.
Public Class ProductoEntidades
    Private vIdProducto As Integer

    Public Property IdProducto() As Integer
        Get
            Return vIdProducto
        End Get
        Set(ByVal value As Integer)
            vIdProducto = value
        End Set
    End Property

    Private vNombre As String

    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vDescripcion As String

    Public Property Descripcion() As String
        Get
            Return vDescripcion
        End Get
        Set(ByVal value As String)
            vDescripcion = value
        End Set
    End Property

    Private vPrecioVenta As Decimal

    Public Property PrecioVenta() As Decimal
        Get
            Return vPrecioVenta
        End Get
        Set(ByVal value As Decimal)
            vPrecioVenta = value
        End Set
    End Property

    Private vBajaLogica As Integer

    Public Property BajaLogica() As Integer
        Get
            Return vBajaLogica
        End Get
        Set(ByVal value As Integer)
            vBajaLogica = value
        End Set
    End Property
End Class
