'Clase Detalle de Ventas con sus atributos / características.
Public Class DetalleVentasEntidades

    Private vIdDetalleVentas As Integer

    Public Property IdDetalleVentas() As Integer
        Get
            Return vIdDetalleVentas
        End Get
        Set(ByVal value As Integer)
            vIdDetalleVentas = value
        End Set
    End Property

    Private vIdVenta As Integer

    Public Property IdVenta() As Integer
        Get
            Return vIdVenta
        End Get
        Set(ByVal value As Integer)
            vIdVenta = value
        End Set
    End Property

    Private vIdProducto As Integer

    Public Property IdProducto() As Integer
        Get
            Return vIdProducto
        End Get
        Set(ByVal value As Integer)
            vIdProducto = value
        End Set
    End Property

    Private vCantidad As Integer

    Public Property Cantidad() As Integer
        Get
            Return vCantidad
        End Get
        Set(ByVal value As Integer)
            vCantidad = value
        End Set
    End Property

    Private vTotal As Decimal

    Public Property Total() As Decimal
        Get
            Return vTotal
        End Get
        Set(ByVal value As Decimal)
            vTotal = value
        End Set
    End Property

    Private vBajaLogica As Boolean

    Public Property BajaLogica() As Boolean
        Get
            Return vBajaLogica
        End Get
        Set(ByVal value As Boolean)
            vBajaLogica = value
        End Set
    End Property

End Class
