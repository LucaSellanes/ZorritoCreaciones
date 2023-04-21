'Clase Artículos con sus atributos / características.
Public Class ArticulosEntidades

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

    Private vObservaciones As String

    Public Property Observaciones() As String
        Get
            Return vObservaciones
        End Get
        Set(ByVal value As String)
            vObservaciones = value
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
