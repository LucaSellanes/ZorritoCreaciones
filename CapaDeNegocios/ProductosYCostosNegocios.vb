'Capa de Negocios, donde se establece la lógica que utilizara en Productos y Costos.
Public Class ProductosYCostosNegocios

    Public Function BuscarProductosYCostos()
        'Busqueda de todos los datos de la tabla Productos y Costos.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("Select Productos.Idproducto AS 'N° de Producto', Nombre, SUM(CostoTotal) AS 'Costo Total' FROM ComposicionProductos INNER JOIN Productos ON ComposicionProductos.IdProducto = Productos.IdProducto WHERE ComposicionProductos.BajaLogica = 'False' AND Productos.BajaLogica = 'False' GROUP BY Nombre, Productos.IdProducto")
        Return MiDt
    End Function

    Public Function BuscarProductosYCostosFiltrado(ByVal Filtro As String, ByVal ValorFiltro As String)
        'Busco los Productos y Costos segun un filtro determinado. El cual depende del parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("Select Productos.Idproducto AS 'N° de Producto', Nombre, SUM(CostoTotal) AS 'Costo Total' FROM ComposicionProductos INNER JOIN Productos ON ComposicionProductos.IdProducto = Productos.IdProducto WHERE Nombre LIKE '" & ValorFiltro & "%' AND ComposicionProductos.BajaLogica = 'False' AND Productos.BajaLogica = 'False' GROUP BY Nombre, Productos.IdProducto")
        End If
        Return MiDt
    End Function
End Class
