'Clase Compras con sus atributos / características.
Public Class ComprasEntidades
    Private vIdCompra As Integer

    Public Property IdCompra() As Integer
        Get
            Return vIdCompra
        End Get
        Set(ByVal value As Integer)
            vIdCompra = value
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

    Private vFecha As Date

    Public Property Fecha() As Date
        Get
            Return vFecha
        End Get
        Set(ByVal value As Date)
            vFecha = value
        End Set
    End Property

    Private vMarca As String

    Public Property Marca() As String
        Get
            Return vMarca
        End Get
        Set(ByVal value As String)
            vMarca = value
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

    Private vObservaciones As String

    Public Property Observaciones() As String
        Get
            Return vObservaciones
        End Get
        Set(ByVal value As String)
            vObservaciones = value
        End Set
    End Property

    Private vCantidadPorBulto As Integer

    Public Property CantidadPorBulto() As Integer
        Get
            Return vCantidadPorBulto
        End Get
        Set(ByVal value As Integer)
            vCantidadPorBulto = value
        End Set
    End Property

    Private vPrecioBulto As Decimal

    Public Property PrecioBulto() As Decimal
        Get
            Return vPrecioBulto
        End Get
        Set(ByVal value As Decimal)
            vPrecioBulto = value
        End Set
    End Property

    Private vPrecioUnitario As Decimal

    Public Property PrecioUnitario() As Decimal
        Get
            Return vPrecioUnitario
        End Get
        Set(ByVal value As Decimal)
            vPrecioUnitario = value
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
