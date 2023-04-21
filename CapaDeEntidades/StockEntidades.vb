'Clase Stock con sus atributos / características.
Public Class StockEntidades
    Private vCodigoArticulo As String

    Public Property CodigoArticulo() As String
        Get
            Return vCodigoArticulo
        End Get
        Set(ByVal value As String)
            vCodigoArticulo = value
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

    Private vMarca As String

    Public Property Marca() As String
        Get
            Return vMarca
        End Get
        Set(ByVal value As String)
            vMarca = value
        End Set
    End Property

    Private vIngresoStock As Integer

    Public Property IngresoStock() As Integer
        Get
            Return vIngresoStock
        End Get
        Set(ByVal value As Integer)
            vIngresoStock = value
        End Set
    End Property

    Private vEgresoStock As Integer

    Public Property EgresoStock() As Integer
        Get
            Return vEgresoStock
        End Get
        Set(ByVal value As Integer)
            vEgresoStock = value
        End Set
    End Property

    Private vStockActual As Integer

    Public Property StockActual() As Integer
        Get
            Return vStockActual
        End Get
        Set(ByVal value As Integer)
            vStockActual = value
        End Set
    End Property
End Class
