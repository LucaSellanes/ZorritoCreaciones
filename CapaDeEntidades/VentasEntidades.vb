'Clase Ventas con sus atributos / características.
Public Class VentasEntidades

    Private vIdVenta As Integer

    Public Property IdVenta() As Integer
        Get
            Return vIdVenta
        End Get
        Set(ByVal value As Integer)
            vIdVenta = value
        End Set
    End Property

    Private vIdCliente As Integer

    Public Property IdCliente() As Integer
        Get
            Return vIdCliente
        End Get
        Set(ByVal value As Integer)
            vIdCliente = value
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
