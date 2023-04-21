'Capa de Negocios, donde se establece la lógica que utilizaran los Artículos.
Public Class ArticuloNegocios

    Public Function AltaArticulo(ByVal UnArticulo As CapaDeEntidades.ArticulosEntidades) As Boolean
        'Alta de Artículo mediante un INSERT en SQL.
        Dim MiConsulta As String = ("INSERT INTO Articulos VALUES('" & UnArticulo.CodigoArticulo & "' , '" & UnArticulo.Nombre & "' ,  '" & UnArticulo.Marca & "' , '" & UnArticulo.Observaciones & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaArticulo(ByVal CodigoArt As String) As Boolean
        'Baja de Artículo mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE Articulos Set BajaLogica = 'True' Where CodigoArticulo = '" & CodigoArt & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodosLosArticulos() As List(Of CapaDeEntidades.ArticulosEntidades)
        'Busqueda de todos los datos de la tabla Artículos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from Articulos where BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ArticulosEntidades)
        Dim MiArticulo As CapaDeEntidades.ArticulosEntidades
        'Creo una lista con los atributos de los Artículos.
        For Each miFila As DataRow In MiDt.Rows
            MiArticulo = New CapaDeEntidades.ArticulosEntidades
            MiArticulo.CodigoArticulo = miFila.Item(0)
            MiArticulo.Nombre = miFila.Item(1)
            MiArticulo.Marca = miFila.Item(2)
            MiArticulo.Observaciones = miFila.Item(3)
            MiLista.Add(MiArticulo)
        Next
        Return MiLista
    End Function

    Public Function BuscarArticulosFiltrados(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.ArticulosEntidades)
        'Busco los Artículos segun un filtro determinado. El cual depende de los diversos parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("Select * from Articulos where BajaLogica = 'False' and Nombre like '" & ValorFiltro & "%' order by Nombre")
        End If

        If Filtro = "Marca" Then
            MiDt = MisDatos.Consultas("Select * from Articulos where BajaLogica = 'False' and Marca like '" & ValorFiltro & "%' order by Marca")
        End If

        If Filtro = "CodigoArticulo" Then
            MiDt = MisDatos.Consultas("Select * from Articulos where BajaLogica = 'False' and CodigoArticulo like '" & ValorFiltro & "%' order by CodigoArticulo")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ArticulosEntidades)
        Dim MiArticulo As CapaDeEntidades.ArticulosEntidades
        'Creo una lista con los atributos de los Artículos.
        For Each miFila As DataRow In MiDt.Rows
            MiArticulo = New CapaDeEntidades.ArticulosEntidades
            MiArticulo.CodigoArticulo = miFila.Item(0)
            MiArticulo.Nombre = miFila.Item(1)
            MiArticulo.Marca = miFila.Item(2)
            MiArticulo.Observaciones = miFila.Item(3)
            MiLista.Add(MiArticulo)
        Next
        Return MiLista
    End Function

    Public Function ModificarArticulo(ByVal UnArticulo As CapaDeEntidades.ArticulosEntidades, ByVal CodigoActual As String)
        'Modificación de los Artículos a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE Articulos SET CodigoArticulo = '" & UnArticulo.CodigoArticulo & "' , Nombre = '" & UnArticulo.Nombre & "', Marca = '" & UnArticulo.Marca & "', Observaciones = '" & UnArticulo.Observaciones & "', BajaLogica = 'False' where CodigoArticulo = '" & CodigoActual & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarCodigosArticulo()
        'Traigo todos los códigos de artículos que no esten dados de baja.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("SELECT CodigoArticulo FROM Articulos WHERE BajaLogica = 'False'")
        Return MiDt
    End Function

    Public Function BuscarCodigosArticuloParaModificacionDeBajaLogica()
        'Traigo todos los códigos de artículos que esten dados de baja, es decir, que tengan el campo BajaLogica en True.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("SELECT CodigoArticulo FROM Articulos WHERE BajaLogica = 'True'")
        Return MiDt
    End Function

    Public Function ModificarArticuloConBajaTrue(ByVal UnArticulo As CapaDeEntidades.ArticulosEntidades, ByVal CodigoActual As String)
        'Función que se utiliza para el alta del Artículo segun tenga o no, un artículo dado de alta con su mismo nombre.
        Dim MiConsulta As String = ("UPDATE Articulos SET Nombre = '" & UnArticulo.Nombre & "', Marca = '" & UnArticulo.Marca & "', Observaciones = '" & UnArticulo.Observaciones & "', BajaLogica = 'False' where CodigoArticulo = '" & CodigoActual & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function ListadoCodArticulos() As List(Of CapaDeEntidades.ArticulosEntidades)
        'Listado de Código de Artículos que no esten dados de baja.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select CodigoArticulo from Articulos where BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ArticulosEntidades)
        Dim MiArticulo As CapaDeEntidades.ArticulosEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiArticulo = New CapaDeEntidades.ArticulosEntidades
            MiArticulo.CodigoArticulo = miFila.Item(0)
            MiLista.Add(MiArticulo)
        Next
        Return MiLista
    End Function
End Class

