'Clase Agenda con sus atributos / características.
Public Class AgendaEntidades

    Private vIdAgenda As Integer

    Public Property IdAgenda() As Integer
        Get
            Return vIdAgenda
        End Get
        Set(ByVal value As Integer)
            vIdAgenda = value
        End Set
    End Property

    Private vNombreCliente As String

    Public Property NombreCliente() As String
        Get
            Return vNombreCliente
        End Get
        Set(ByVal value As String)
            vNombreCliente = value
        End Set
    End Property

    Private vTematica As String

    Public Property Tematica() As String
        Get
            Return vTematica
        End Get
        Set(ByVal value As String)
            vTematica = value
        End Set
    End Property

    Private vFechaEntrega As Date

    Public Property FechaEntrega() As Date
        Get
            Return vFechaEntrega
        End Get
        Set(ByVal value As Date)
            vFechaEntrega = value
        End Set
    End Property

    Private vPedido As String

    Public Property Pedido() As String
        Get
            Return vPedido
        End Get
        Set(ByVal value As String)
            vPedido = value
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

    Private vFaltante As Decimal

    Public Property Faltante() As Decimal
        Get
            Return vFaltante
        End Get
        Set(ByVal value As Decimal)
            vFaltante = value
        End Set
    End Property

    Private vImporte As Decimal

    Public Property Importe() As Decimal
        Get
            Return vImporte
        End Get
        Set(ByVal value As Decimal)
            vImporte = value
        End Set
    End Property

    Private vComentarios As String

    Public Property Comentarios() As String
        Get
            Return vComentarios
        End Get
        Set(ByVal value As String)
            vComentarios = value
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


