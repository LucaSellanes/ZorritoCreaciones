'Clase Clientes con sus atributos / características.
Public Class ClientesEntidades

    Private vIdCliente As Integer

    Public Property IdCliente() As Integer
        Get
            Return vIdCliente
        End Get
        Set(ByVal value As Integer)
            vIdCliente = value
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

    Private vApellido As String

    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property

    Private vNombreNinoNina As String

    Public Property NombreNinoNina() As String
        Get
            Return vNombreNinoNina
        End Get
        Set(ByVal value As String)
            vNombreNinoNina = value
        End Set
    End Property

    Private vFechaCumpleanos As Date

    Public Property FechaCumpleanos() As Date
        Get
            Return vFechaCumpleanos
        End Get
        Set(ByVal value As Date)
            vFechaCumpleanos = value
        End Set
    End Property

    Private vAnosCumplidos As Integer

    Public Property AnosCumplidos() As Integer
        Get
            Return vAnosCumplidos
        End Get
        Set(ByVal value As Integer)
            vAnosCumplidos = value
        End Set
    End Property

    Private vLocalidad As String

    Public Property Localidad() As String
        Get
            Return vLocalidad
        End Get
        Set(ByVal value As String)
            vLocalidad = value
        End Set
    End Property

    Private vCelular As Int64

    Public Property Celular() As Int64
        Get
            Return vCelular
        End Get
        Set(ByVal value As Int64)
            vCelular = value
        End Set
    End Property

    Private vFechaAlta As Date

    Public Property FechaAlta() As Date
        Get
            Return vFechaAlta
        End Get
        Set(ByVal value As Date)
            vFechaAlta = value
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



