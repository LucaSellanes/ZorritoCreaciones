'Capa de Negocios, donde se establece la lógica que utilizara el Producto.
Public Class ProductoNegocio

    Public Function AltaProducto(ByVal UnProducto As CapaDeEntidades.ProductoEntidades) As Boolean
        'Alta de un Producto mediante un INSERT en SQL.
        Dim MiConsulta As String = ("INSERT INTO Productos VALUES('" & UnProducto.Nombre & "' , '" & UnProducto.PrecioVenta & "' , '" & UnProducto.Descripcion & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaProducto(ByVal UnProducto As CapaDeEntidades.ProductoEntidades) As Boolean
        'Baja de Producto mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE Productos Set BajaLogica = 'True' Where IdProducto = ' " & UnProducto.IdProducto & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodosLosProductos() As List(Of CapaDeEntidades.ProductoEntidades)
        'Busqueda de todos los datos de la tabla Productos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from Productos where BajaLogica = 'False' order by Nombre")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProducto As CapaDeEntidades.ProductoEntidades
        'Creo una lista con los atributos de los Productos.
        For Each miFila As DataRow In MiDt.Rows
            MiProducto = New CapaDeEntidades.ProductoEntidades
            MiProducto.IdProducto = miFila.Item(0)
            MiProducto.Nombre = miFila.Item(1)
            MiProducto.PrecioVenta = miFila.Item(2)
            MiProducto.Descripcion = miFila.Item(3)
            MiProducto.BajaLogica = miFila.Item(4)
            MiLista.Add(MiProducto)
        Next
        Return MiLista
    End Function

    Public Function ComboNombreProd() As List(Of CapaDeEntidades.ProductoEntidades)
        'Carga los nombres de los Productos dados de alta, en la sección Composición de Productos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Nombre from Productos where BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProducto As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiProducto = New CapaDeEntidades.ProductoEntidades
            MiProducto.Nombre = miFila.Item(0)
            MiLista.Add(MiProducto)
        Next
        Return MiLista
    End Function

    Public Function BuscarNombreProductos()
        'Busca los nombres de los Productos dados de alta. Esto se usa en el Alta de un Producto, para evitar duplicados en los nombres de los mismos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("Select Nombre from Productos where BajaLogica = 'False'")
        Return MiDt
    End Function

    Public Function BuscarProductosFiltrados(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.ProductoEntidades)
        'Busco los Productos segun un filtro determinado. El cual depende de los diversos parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("Select * from Productos where BajaLogica = 'False' and Nombre like '" & ValorFiltro & "%' order by Nombre")
        End If

        If Filtro = "Descripcion" Then
            MiDt = MisDatos.Consultas("Select * from Productos where BajaLogica = 'False' and Descripcion like '" & ValorFiltro & "%' order by Descripcion")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProducto As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiProducto = New CapaDeEntidades.ProductoEntidades
            MiProducto.IdProducto = miFila.Item(0)
            MiProducto.Nombre = miFila.Item(1)
            MiProducto.PrecioVenta = miFila.Item(2)
            MiProducto.Descripcion = miFila.Item(3)
            MiProducto.BajaLogica = miFila.Item(4)
            MiLista.Add(MiProducto)
        Next
        Return MiLista
    End Function

    Public Function ModificarProducto(ByVal UnProducto As CapaDeEntidades.ProductoEntidades) As Boolean
        'Modificación de los Productos a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE Productos SET Nombre = '" & UnProducto.Nombre & "' , PrecioVenta = '" & UnProducto.PrecioVenta & "' ,  Descripcion = '" & UnProducto.Descripcion & "', BajaLogica = 'False' where IdProducto = '" & UnProducto.IdProducto & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDProducto() As List(Of CapaDeEntidades.ProductoEntidades)
        'Búsqueda del máximo ID de la tabla Productos, para poder usar como ID autoincremental.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdProducto) +1 from Productos where BajaLogica = 'False'")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdProducto) +1 from Productos where BajaLogica = 'True'")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.ProductoEntidades)
                Dim MiProd3 As CapaDeEntidades.ProductoEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiProd3 = New CapaDeEntidades.ProductoEntidades
                    MiProd3.IdProducto = 1
                    MiLista3.Add(MiProd3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.ProductoEntidades)
            Dim MiProd2 As CapaDeEntidades.ProductoEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiProd2 = New CapaDeEntidades.ProductoEntidades
                MiProd2.IdProducto = miFila.Item(0)
                MiLista2.Add(MiProd2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProd As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiProd = New CapaDeEntidades.ProductoEntidades
            MiProd.IdProducto = miFila.Item(0)
            MiLista.Add(MiProd)
        Next
        Return MiLista

    End Function

    Public Function IDProductoSegunNombre(ByVal Nombre As String) As List(Of CapaDeEntidades.ProductoEntidades)
        'Trae el ID del Producto segun el Nombre pasado mediante un parametro. Esto se utiliza en la sección Composición de Productos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select IdProducto from Productos where Nombre = '" & Nombre & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProducto As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiProducto = New CapaDeEntidades.ProductoEntidades
            MiProducto.IdProducto = miFila.Item(0)
            MiLista.Add(MiProducto)
        Next
        Return MiLista
    End Function

    Public Function NombreProdSegunID(ByVal ID As Integer) As List(Of CapaDeEntidades.ProductoEntidades)
        'Trae un DataTable invidivual para los nombres de los productos, que se va a anexar al DataTable principal (Datagrid3).
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("SELECT Productos.Nombre FROM ComposicionProductos INNER JOIN Compras ON ComposicionProductos.CodigoArticulo = Compras.CodigoArticulo INNER JOIN Productos ON '" & ID & "' = Productos.IdProducto WHERE ComposicionProductos.BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProducto As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiProducto = New CapaDeEntidades.ProductoEntidades
            MiProducto.Nombre = miFila.Item(0)
            MiLista.Add(MiProducto)
        Next
        Return MiLista
    End Function

    Public Function ProductosParaComposicionProductos() As List(Of CapaDeEntidades.ProductoEntidades)
        'Inserto los nombres de los productos en el DataGridView de Detalle Ventas, segun el ID que se les haya registrado en la Ventas
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Nombre FROM Productos, ComposicionProductos WHERE Productos.IdProducto = ComposicionProductos.IdProducto and ComposicionProductos.BajaLogica = 'False' ORDER BY ComposicionProductos.IdComposicionProducto")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiProducto As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiProducto = New CapaDeEntidades.ProductoEntidades
            MiProducto.Nombre = miFila.Item(0)
            MiLista.Add(MiProducto)
        Next
        Return MiLista
    End Function

    Public Function PrecioProdSegunNombre(ByVal ID As Integer) As List(Of CapaDeEntidades.ProductoEntidades)
        'Trae el Precio de Venta del Producto segun el ID del mismo asignado como parametro.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("SELECT Precioventa FROM Productos WHERE Productos.IdProducto = '" & ID & "' and BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiPrecio As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiPrecio = New CapaDeEntidades.ProductoEntidades
            MiPrecio.PrecioVenta = miFila.Item(0)
            MiLista.Add(MiPrecio)
        Next
        Return MiLista
    End Function

    Public Function TodosLosPreciosDeVenta() As List(Of CapaDeEntidades.ProductoEntidades)
        'Trae una Tabla individual con el Precio de Venta de cada Producto para acoplar al Datagrid de Detalle de Productos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select PrecioVenta FROM Productos INNER JOIN ComposicionProductos ON ComposicionProductos.IdProducto = Productos.IdProducto WHERE ComposicionProductos.BajaLogica = 'False'  ORDER BY IdComposicionProducto")

        Dim MiLista As New List(Of CapaDeEntidades.ProductoEntidades)
        Dim MiPrecio As CapaDeEntidades.ProductoEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiPrecio = New CapaDeEntidades.ProductoEntidades
            MiPrecio.PrecioVenta = miFila.Item(0)
            MiLista.Add(MiPrecio)
        Next
        Return MiLista
    End Function
End Class
