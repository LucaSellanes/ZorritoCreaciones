'Capa de Negocios, donde se establece la lógica que utilizaran las Compras.
Public Class ComprasNegocio
    Public Function AltaCompras(ByVal UnaCompra As CapaDeEntidades.ComprasEntidades) As Boolean
        'Alta de una Compra mediante un INSERT en SQL.
        Dim MiConsulta As String = ("INSERT INTO Compras VALUES('" & UnaCompra.CodigoArticulo & "' , '" & UnaCompra.Fecha.ToString("MM-dd-yyyy") & "' , '" & UnaCompra.Marca & "' , '" & UnaCompra.Nombre & "' ,  '" & UnaCompra.Observaciones & "' , '" & UnaCompra.CantidadPorBulto & "' , '" & UnaCompra.PrecioBulto & "' , '" & UnaCompra.PrecioUnitario & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaCompra(ByVal UnaCompra As CapaDeEntidades.ComprasEntidades) As Boolean
        'Baja de Compra mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE Compras Set BajaLogica = 'True' Where IdCompra = ' " & UnaCompra.IdCompra & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodasLasCompras() As List(Of CapaDeEntidades.ComprasEntidades)
        'Busqueda de todos los datos de la tabla Compras.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from Compras where BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades
        'Creo una lista con los atributos de las Compras.
        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.IdCompra = miFila.Item(0)
            MiCompra.CodigoArticulo = miFila.Item(1)
            MiCompra.Fecha = miFila.Item(2)
            MiCompra.Marca = miFila.Item(3)
            MiCompra.Nombre = miFila.Item(4)
            MiCompra.Observaciones = miFila.Item(5)
            MiCompra.CantidadPorBulto = miFila.Item(6)
            MiCompra.PrecioBulto = miFila.Item(7)
            MiCompra.PrecioUnitario = miFila.Item(8)
            MiCompra.BajaLogica = miFila.Item(9)
            MiLista.Add(MiCompra)
        Next
        Return MiLista
    End Function

    Public Function BuscarComprasFiltradas(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.ComprasEntidades)
        'Busco las Compras segun un filtro determinado. El cual depende de los diversos parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("Select * from Compras where BajaLogica = 'False' and Nombre like '" & ValorFiltro & "%' order by Nombre")
        End If

        If Filtro = "Marca" Then
            MiDt = MisDatos.Consultas("Select * from Compras where BajaLogica = 'False' and Marca like '" & ValorFiltro & "%' order by Marca")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.IdCompra = miFila.Item(0)
            MiCompra.CodigoArticulo = miFila.Item(1)
            MiCompra.Fecha = miFila.Item(2)
            MiCompra.Marca = miFila.Item(3)
            MiCompra.Nombre = miFila.Item(4)
            MiCompra.Observaciones = miFila.Item(5)
            MiCompra.CantidadPorBulto = miFila.Item(6)
            MiCompra.PrecioBulto = miFila.Item(7)
            MiCompra.PrecioUnitario = miFila.Item(9)
            MiCompra.BajaLogica = miFila.Item(9)
            MiLista.Add(MiCompra)
        Next
        Return MiLista
    End Function

    Public Function BuscarComprasPorFecha(ByVal Fecha1 As Date, ByVal Fecha2 As Date) As List(Of CapaDeEntidades.ComprasEntidades)
        'Busco los Clientes segun un rango de fechas determinado.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * From Compras WHERE Fecha between '" & Fecha1.ToString("MM-dd-yyyy") & "' and '" & Fecha2.ToString("MM-dd-yyyy") & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.IdCompra = miFila.Item(0)
            MiCompra.CodigoArticulo = miFila.Item(1)
            MiCompra.Fecha = miFila.Item(2)
            MiCompra.Marca = miFila.Item(3)
            MiCompra.Nombre = miFila.Item(4)
            MiCompra.Observaciones = miFila.Item(5)
            MiCompra.CantidadPorBulto = miFila.Item(6)
            MiCompra.PrecioBulto = miFila.Item(7)
            MiCompra.PrecioUnitario = miFila.Item(9)
            MiCompra.BajaLogica = miFila.Item(9)
            MiLista.Add(MiCompra)
        Next
        Return MiLista
    End Function

    Public Function ModificarCompra(ByVal UnaCompra As CapaDeEntidades.ComprasEntidades) As Boolean
        'Modificación de las Compras a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE Compras SET CodigoArticulo = '" & UnaCompra.CodigoArticulo & "' , Fecha = '" & UnaCompra.Fecha.ToString("MM-dd-yyyy") & "' , Marca = '" & UnaCompra.Marca & "', Nombre = '" & UnaCompra.Nombre & "', Observaciones = '" & UnaCompra.Observaciones & "', CantidadPorBulto = '" & UnaCompra.CantidadPorBulto & "', PrecioBulto = '" & CDec(UnaCompra.PrecioBulto) & "', PrecioUnitario = '" & CDec(UnaCompra.PrecioUnitario) & "', BajaLogica = 'False' where IdCompra = '" & UnaCompra.IdCompra & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDCompra() As List(Of CapaDeEntidades.ComprasEntidades)
        'Búsqueda del máximo ID de la tabla Compras, para poder usar como ID autoincremental.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdCompra) +1 from Compras")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdCompra) +1 from Compras")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.ComprasEntidades)
                Dim MiCompra3 As CapaDeEntidades.ComprasEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiCompra3 = New CapaDeEntidades.ComprasEntidades
                    MiCompra3.IdCompra = 1
                    MiLista3.Add(MiCompra3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.ComprasEntidades)
            Dim MiCompra2 As CapaDeEntidades.ComprasEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiCompra2 = New CapaDeEntidades.ComprasEntidades
                MiCompra2.IdCompra = miFila.Item(0)
                MiLista2.Add(MiCompra2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.IdCompra = miFila.Item(0)
            MiLista.Add(MiCompra)
        Next
        Return MiLista

    End Function

    Public Function ComboNombreArticulos() As List(Of CapaDeEntidades.ComprasEntidades)
        'Busco todos los Nombres de los Artículos y los traslado a un Combobox establecido en la sección Composición Productos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("SELECT Nombre FROM Compras WHERE BajaLogica = 'False' ORDER BY Nombre")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.Nombre = miFila.Item(0)
            MiLista.Add(MiCompra)
        Next
        Return MiLista
    End Function

    Public Function CostoCompoProd(ByVal Codigo As String) As List(Of CapaDeEntidades.ComprasEntidades)
        'Busca el Precio Unitario de la tabla Compras, segun el nombre del Artículo que le asignamos como parametro.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select PrecioUnitario from Compras where CodigoArticulo = '" & Codigo & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.PrecioUnitario = miFila.Item(0)
            MiLista.Add(MiCompra)
        Next
        Return MiLista
    End Function

    Public Function CodigoArticuloSegunNombre(ByVal Nombre As String) As List(Of CapaDeEntidades.ComprasEntidades)
        'Trae un DT invidivual para los nombres de las Compras, que se va a anexar al DT principal de la sección Composición Producto (Datagrid3).
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select CodigoArticulo from Articulos where Nombre = '" & Nombre & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.CodigoArticulo = miFila.Item(0)
            MiLista.Add(MiCompra)
        Next
        Return MiLista
    End Function

    Public Function NombreArticulo() As List(Of CapaDeEntidades.ComprasEntidades)
        'Busqueda del Nombre de los Artículos de la tabla Composición Productos, segun esten dados de alta en Compras tambien.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Nombre FROM Articulos INNER JOIN ComposicionProductos ON ComposicionProductos.CodigoArticulo = Articulos.CodigoArticulo WHERE ComposicionProductos.BajaLogica = 'False' ORDER BY IdComposicionProducto")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiCompra As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompra = New CapaDeEntidades.ComprasEntidades
            MiCompra.Nombre = miFila.Item(0)
            MiLista.Add(MiCompra)
        Next
        Return MiLista

    End Function

    Public Function MarcaSegunCodArticulo(ByVal Codigo As String) As List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Marca from Articulos where CodigoArticulo = '" & Codigo & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiMarca As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiMarca = New CapaDeEntidades.ComprasEntidades
            MiMarca.Marca = miFila.Item(0)
            MiLista.Add(MiMarca)
        Next
        Return MiLista
    End Function

    Public Function NombreSegunCodArticulo(ByVal Codigo As String) As List(Of CapaDeEntidades.ComprasEntidades)
        'Busco el Nombre del Artículo, segun el código del mismo, el cual le paso mediante un parametro.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Nombre from Articulos where CodigoArticulo = '" & Codigo & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiNombre As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiNombre = New CapaDeEntidades.ComprasEntidades
            MiNombre.Nombre = miFila.Item(0)
            MiLista.Add(MiNombre)
        Next
        Return MiLista
    End Function

    Public Function ObservacionSegunCodArticulo(ByVal Codigo As String) As List(Of CapaDeEntidades.ComprasEntidades)
        'Busco las Observaciones de un Artículo, segun el código del mismo, enviado mediante un parametro.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Observaciones from Articulos where CodigoArticulo = '" & Codigo & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiNombre As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiNombre = New CapaDeEntidades.ComprasEntidades
            MiNombre.Observaciones = miFila.Item(0)
            MiLista.Add(MiNombre)
        Next
        Return MiLista
    End Function

    Public Function BuscarCodigosArticulosCompras()
        'Busco todos los Códigos de Artículo de la tabla Compras, que no esten dados de baja. Esto se usa para la verificación en el Codigo Artículo, al dar de alta Stock.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("Select CodigoArticulo from Compras where BajaLogica = 'False'")
        Return MiDt
    End Function


    Public Function CodArtSegunDataGridCompras(ByVal NumCompra As Integer) As List(Of CapaDeEntidades.ComprasEntidades)
        'Busca el Código de Artículo dado de baja, segun el N° de compra que se le envíe mediante el parametro NumCompra.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select CodigoArticulo from Compras where IdCompra = '" & NumCompra & "'")

        Dim MiLista As New List(Of CapaDeEntidades.ComprasEntidades)
        Dim MiArticulo As CapaDeEntidades.ComprasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiArticulo = New CapaDeEntidades.ComprasEntidades
            MiArticulo.CodigoArticulo = miFila.Item(0)
            MiLista.Add(MiArticulo)
        Next
        Return MiLista
    End Function











End Class