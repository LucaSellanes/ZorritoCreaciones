'Clase Composicion de Productos con sus atributos / características.
Public Class ComposicionProductosEntidades
    Private vIdComposicionProducto As Integer

    Public Property IdComposicionProducto() As Integer
        Get
            Return vIdComposicionProducto
        End Get
        Set(ByVal value As Integer)
            vIdComposicionProducto = value
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

    Private vCodigoArticulo As String

    Public Property CodigoArticulo() As String
        Get
            Return vCodigoArticulo
        End Get
        Set(ByVal value As String)
            vCodigoArticulo = value
        End Set
    End Property

    Private vCantidadMateriaPrima As Decimal

    Public Property CantidadMateriaPrima() As Decimal
        Get
            Return vCantidadMateriaPrima
        End Get
        Set(ByVal value As Decimal)
            vCantidadMateriaPrima = value
        End Set
    End Property

    Private vCosto As Decimal

    Public Property Costo() As Decimal
        Get
            Return vCosto
        End Get
        Set(ByVal value As Decimal)
            vCosto = value
        End Set
    End Property

    Private vCostoTotal As Decimal

    Public Property CostoTotal() As Decimal
        Get
            Return vCostoTotal
        End Get
        Set(ByVal value As Decimal)
            vCostoTotal = value
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
