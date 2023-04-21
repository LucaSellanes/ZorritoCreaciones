'Capa de Negocios, donde se establece la lógica que utilizara el Stock.
Public Class StockNegocio

    Public Function AltaStockCompras(ByVal UnStock As CapaDeEntidades.StockEntidades) As Boolean
        'Egreso de mercadería al hacer una compra. Esto aumenta valores de IngresoStock.
        Dim MiConsulta As String = ("INSERT INTO Stock VALUES('" & UnStock.CodigoArticulo & "' , '" & UnStock.Nombre & "' , '" & UnStock.Marca & "' , '" & UnStock.IngresoStock & "' , '" & UnStock.EgresoStock & "', '" & UnStock.StockActual & "')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function UpdateParaIngresoStockEnCompras(ByVal CantidadComprada As Integer, ByVal CodigoArticulo As String) As Boolean
        'Esta función se lleva a cabo al dar de alta la Compra de un Artículo ya existente en la base. Entonces se suma a la cantidad que previamente tiene se Artículo, la nueva cantidad comprada.
        Dim MiConsulta As String = ("UPDATE Stock SET IngresoStock = IngresoStock + '" & CantidadComprada & "' WHERE CodigoArticulo = '" & CodigoArticulo & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function ModificarStockComprasParte1(ByVal Cantidad As Integer, ByVal CodigoArticulo As String) As Boolean
        'Esta función se lleva a cabo al modificar la Compra de un Artículo. Entonces se resta a la cantidad de esa compra ala cantidad total del Artículo segun su Código.
        Dim MiConsulta As String = ("UPDATE Stock SET IngresoStock = IngresoStock - '" & Cantidad & "' WHERE CodigoArticulo = '" & CodigoArticulo & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function ModificarStockComprasParte2(ByVal Cantidad As Integer, ByVal CodigoArticulo As String) As Boolean
        'Esta función se lleva a cabo al modificar la Compra de un Artículo. Se inicia al terminar la parte 1, y lo que hace es sumar a la cantidad existente, el nuevo ingreso de stock si lo hay.
        Dim MiConsulta As String = ("UPDATE Stock SET IngresoStock = IngresoStock + '" & Cantidad & "' WHERE CodigoArticulo = '" & CodigoArticulo & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function AltaDetalleVentaStock(ByVal CantVenta As Integer, ByVal IdDetalleVenta As Integer, ByVal UnStock As CapaDeEntidades.StockEntidades) As Boolean
        'Modificación del EgresoStock, al cargar una venta. Se multiplica la cantidad vendida del producto, por la cantidad de Compra que lleva,
        'y se actualiza el stock a partir de esto.
        Dim MiConsulta As String = ("UPDATE Stock SET EgresoStock = EgresoStock + ('" & CantVenta & "' * CantidadMateriaPrima) FROM Stock INNER JOIN ComposicionProductos ON ComposicionProductos.CodigoArticulo = Stock.CodigoArticulo INNER JOIN Productos ON ComposicionProductos.Idproducto = Productos.IdProducto INNER JOIN DetalleVentas ON Productos.IdProducto = DetalleVentas.IdProducto AND DetalleVentas.IdDetalleVenta = '" & IdDetalleVenta & "' WHERE ComposicionProductos.BajaLogica = 'False'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function ModificarStockDetalleVentaParte1(ByVal CantVenta As Integer, ByVal IdDetalleVenta As String) As Boolean
        'Al egreso de Stock, le restamos la nueva salida del Stock. Generando asi la actualizacion de los datos, ante una baja o modificación del Detalle Venta.
        Dim MiConsulta As String = ("UPDATE Stock SET EgresoStock = EgresoStock - ('" & CantVenta & "' * CantidadMateriaPrima) FROM Stock INNER JOIN ComposicionProductos ON ComposicionProductos.CodigoArticulo = Stock.CodigoArticulo INNER JOIN Productos ON ComposicionProductos.Idproducto = Productos.IdProducto INNER JOIN DetalleVentas ON Productos.IdProducto = DetalleVentas.IdProducto AND DetalleVentas.IdDetalleVenta ='" & IdDetalleVenta & "' WHERE ComposicionProductos.BajaLogica =  'False'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarStock()
        'Trae todos los datos de la tabla Stock ordenados por nombre.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("SELECT CodigoArticulo, Nombre, Marca, IngresoStock, EgresoStock, StockActual FROM Stock GROUP BY  CodigoArticulo, nombre, marca, IngresoStock, EgresoStock, StockActual	ORDER BY Nombre")
        Return MiDt
    End Function

    Public Function BuscarStockFiltrado(ByVal Filtro As String, ByVal ValorFiltro As String)
        'Busco el Stock segun un filtro determinado. El cual depende de los diversos parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "CodigoArticulo" Then
            MiDt = MisDatos.Consultas("SELECT CodigoArticulo, Nombre, Marca, IngresoStock, EgresoStock, StockActual FROM Stock WHERE CodigoArticulo LIKE '" & ValorFiltro & "%' GROUP BY  CodigoArticulo, nombre, marca, IngresoStock, EgresoStock, StockActual ORDER BY Nombre")
        End If

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("SELECT CodigoArticulo, Nombre, Marca, IngresoStock, EgresoStock, StockActual FROM Stock WHERE Nombre LIKE '" & ValorFiltro & "%' GROUP BY  CodigoArticulo, nombre, marca, IngresoStock, EgresoStock, StockActual ORDER BY Nombre")
        End If

        If Filtro = "Marca" Then
            MiDt = MisDatos.Consultas("SELECT CodigoArticulo, Nombre, Marca, IngresoStock, EgresoStock, StockActual FROM Stock WHERE Marca LIKE '" & ValorFiltro & "%' GROUP BY  CodigoArticulo, nombre, marca, IngresoStock, EgresoStock, StockActual ORDER BY Nombre")
        End If
        Return MiDt
    End Function
End Class
