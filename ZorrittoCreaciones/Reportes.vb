Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Reportes

    Dim VTituloInforme As String

    Private Sub Reportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título, combo y Label2 en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Le doy el formato al Combo del Reporte.
        ComboBox1.DropDownStyle = 2
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Cargo la conexión.
        Dim ConnString = "Data Source=.\;Initial Catalog= Zorrito;Integrated Security=TRUE"

        If ComboBox1.Text = "Clientes" Then
            'Defino el nombre del informe segun lo seleccionado en el Combo1.
            VTituloInforme = "CLIENTES"

            'Establezco la conexión a la base de datos para que me traiga la tabla correspondiente a la consulta hecha con columnas y filtros especificados.
            Dim sql As String = "SELECT Nombre, Apellido, NombreNinoNina, FechaCumpleanos, AnosCumplidos, Localidad, Celular, FechaAlta, Comentarios FROM Clientes WHERE BajaLogica = 'False' ORDER BY FechaAlta"
            Dim ds1 As DataSet
            Dim da1 As SqlDataAdapter
            Dim Conn As SqlConnection = New SqlConnection(ConnString)
            Conn.Open()
            da1 = New SqlDataAdapter(sql, Conn)
            Dim ds As DataSet = New DataSet()
            Dim datasource As ReportDataSource
            ds1 = New DataSet("ClientesDataSet")
            da1.Fill(ds1, "ClientesDataSet")
            datasource = New ReportDataSource("ClientesDataSet", ds1.Tables(0))

            'Limpio el ReportViewer, le agrego las tablas obtenidas y especifico la ubicacion del Reportviewer (directorio).
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Clientes.rdlc")

            'Cargo los parametros en el ReportViewer segun la lista de parametros creada, y el metodo Fill del TableAdapter Clientes.
            Dim ListaParametros As New List(Of ReportParameter)
            ListaParametros.Add(New ReportParameter("fecha", Now))
            ListaParametros.Add(New ReportParameter("tituloinforme", VTituloInforme))
            ReportViewer1.LocalReport.SetParameters(ListaParametros)
        End If

        If ComboBox1.Text = "Compras" Then
            'Defino el nombre del informe segun lo seleccionado en el Combo1.
            VTituloInforme = "COMPRAS"

            'Establezco la conexion a la base de datos para que me traiga la tabla correspondiente a la consulta hecha con columnas y filtros especificados.
            Dim sql As String = "SELECT CodigoArticulo, Nombre, Marca, CantidadPorBulto, PrecioBulto, PrecioUnitario, Observaciones FROM Compras WHERE Compras.BajaLogica = 'False' ORDER BY Nombre"
            Dim ds1 As DataSet
            Dim da1 As SqlDataAdapter
            Dim Conn As SqlConnection = New SqlConnection(ConnString)
            Conn.Open()
            da1 = New SqlDataAdapter(sql, Conn)
            Dim ds As DataSet = New DataSet()
            Dim datasource As ReportDataSource
            ds1 = New DataSet("ComprasDataSet")
            da1.Fill(ds1, "ComprasDataSet")
            datasource = New ReportDataSource("ComprasDataSet", ds1.Tables(0))

            'Limpio el ReportViewer, le agrego las tablas obtenidas y especifico la ubicacion del Reportviewer (directorio).
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Compras.rdlc")

            'Cargo los parametros en el ReportViewer segun la lista de parametros creada, y el metodo Fill del TableAdapter Clientes.
            Dim ListaParametros As New List(Of ReportParameter)
            ListaParametros.Add(New ReportParameter("fecha", Now))
            ListaParametros.Add(New ReportParameter("tituloinforme", VTituloInforme))
            ReportViewer1.LocalReport.SetParameters(ListaParametros)
        End If

        If ComboBox1.Text = "Productos" Then
            VTituloInforme = "PRODUCTOS"
            Dim sql As String = "SELECT * FROM Productos WHERE BajaLogica = 'False' ORDER BY IdProducto"
            Dim ds1 As DataSet
            Dim da1 As SqlDataAdapter

            Dim Conn As SqlConnection = New SqlConnection(ConnString)
            Conn.Open()
            da1 = New SqlDataAdapter(sql, Conn)
            Dim ds As DataSet = New DataSet()
            Dim datasource As ReportDataSource
            ds1 = New DataSet("ProductosDataSet")
            da1.Fill(ds1, "ProductosDataSet")
            datasource = New ReportDataSource("ProductosDataSet", ds1.Tables(0))
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource)

            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Productos.rdlc")

            'Conexion para obtener Datatable de la ComposicionProductos.
            Dim sql2 As String = "SELECT SUM(CostoTotal) AS 'Costo', PrecioVenta FROM ComposicionProductos INNER JOIN Productos ON Productos.IdProducto = ComposicionProductos.IdProducto WHERE Productos.BajaLogica = 'False' AND ComposicionProductos.BajaLogica = 'False' GROUP BY PrecioVenta, Productos.IdProducto ORDER BY  Productos.IdProducto"
            Dim ds12 As DataSet
            Dim da12 As SqlDataAdapter

            Dim Conn2 As SqlConnection = New SqlConnection(ConnString)
            Conn2.Open()
            da12 = New SqlDataAdapter(sql2, Conn2)
            Dim ds2 As DataSet = New DataSet()
            Dim datasource2 As ReportDataSource
            ds12 = New DataSet("CompoDataSet3")
            da12.Fill(ds12, "CompoDataSet3")
            datasource2 = New ReportDataSource("CompoDataSet3", ds12.Tables(0))
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource2)


            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Productos.rdlc")

            'Conexion para obtener Datatable de la Rentabilidad
            Dim sql3 As String = "SELECT PrecioVenta - SUM(CostoTotal) AS 'RentaPesos', (PrecioVenta - SUM(CostoTotal)) * 100 / SUM(CostoTotal) AS 'RentaPorcentaje' FROM ComposicionProductos INNER JOIN Productos ON Productos.IdProducto = ComposicionProductos.IdProducto WHERE Productos.BajaLogica = 'False' AND ComposicionProductos.BajaLogica = 'False' GROUP BY PrecioVenta, Productos.IdProducto ORDER BY Productos.IdProducto"
            Dim ds13 As DataSet
            Dim da13 As SqlDataAdapter

            Dim Conn3 As SqlConnection = New SqlConnection(ConnString)
            Conn3.Open()
            da13 = New SqlDataAdapter(sql3, Conn3)
            Dim ds3 As DataSet = New DataSet()
            Dim datasource3 As ReportDataSource
            ds13 = New DataSet("RentabilidadDataSet")
            da13.Fill(ds13, "RentabilidadDataSet")
            datasource3 = New ReportDataSource("RentabilidadDataSet", ds13.Tables(0))

            Me.ReportViewer1.LocalReport.DataSources.Add(datasource3)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Productos.rdlc")
            'Cargo los parametros en el ReportViewer segun la lista de parametros creada, y el metodo Fill del TableAdapter Clientes.
            Dim ListaParametros As New List(Of ReportParameter)
            ListaParametros.Add(New ReportParameter("fecha", Now))
            ListaParametros.Add(New ReportParameter("tituloinforme", VTituloInforme))
            ReportViewer1.LocalReport.SetParameters(ListaParametros)
        End If


        If ComboBox1.Text = "Stock" Then
            VTituloInforme = "STOCK"
            'Conexion para obtener Datatable del STOCK.
            Dim sql4 As String = "SELECT CodigoArticulo, Nombre, Marca, IngresoStock, EgresoStock, (IngresoStock - EgresoStock) AS StockActual FROM Stock ORDER BY CodigoArticulo"
            Dim ds14 As DataSet
            Dim da14 As SqlDataAdapter

            Dim Conn4 As SqlConnection = New SqlConnection(ConnString)
            Conn4.Open()
            da14 = New SqlDataAdapter(sql4, Conn4)
            Dim ds4 As DataSet = New DataSet()
            Dim datasource4 As ReportDataSource
            ds14 = New DataSet("TablaStockDataSet")
            da14.Fill(ds14, "TablaStockDataSet")
            datasource4 = New ReportDataSource("TablaStockDataSet", ds14.Tables(0))

            Me.ReportViewer1.LocalReport.DataSources.Add(datasource4)

            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Stock.rdlc")


            'Cargo los parametros en el ReportViewer segun la lista de parametros creada, y el metodo Fill del TableAdapter Clientes.
            Dim ListaParametros As New List(Of ReportParameter)
            ListaParametros.Add(New ReportParameter("fecha", Now))
            ListaParametros.Add(New ReportParameter("tituloinforme", VTituloInforme))
            ReportViewer1.LocalReport.SetParameters(ListaParametros)
        End If

        If ComboBox1.Text = "Ventas" Then
            VTituloInforme = "VENTAS"
            'Conexion para obtener Datatable de VENTAS.
            Dim sql As String = "SELECT Fecha FROM Ventas INNER JOIN DetalleVentas ON DetalleVentas.IdVenta = Ventas.IdVenta WHERE Ventas.BajaLogica = 'False' AND DetalleVentas.BajaLogica = 'False'"
            Dim ds1 As DataSet
            Dim da1 As SqlDataAdapter

            Dim Conn As SqlConnection = New SqlConnection(ConnString)
            Conn.Open()
            da1 = New SqlDataAdapter(sql, Conn)
            Dim ds As DataSet = New DataSet()
            Dim datasource As ReportDataSource
            ds1 = New DataSet("VentasParaVentasDataSet")
            da1.Fill(ds1, "VentasParaVentasDataSet")
            datasource = New ReportDataSource("VentasParaVentasDataSet", ds1.Tables(0))
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Ventas.rdlc")

            'Conexion para obtener Datatable de los CLIENTES.
            Dim sql2 As String = "SELECT Nombre, Apellido FROM Clientes INNER JOIN Ventas ON Ventas.IdCliente = Clientes.IdCliente INNER JOIN DetalleVentas ON DetalleVentas.IdVenta = Ventas.IdVenta WHERE Ventas.BajaLogica = 'False' AND DetalleVentas.BajaLogica = 'False' ORDER BY DetalleVentas.IdDetalleVenta"
            Dim ds12 As DataSet
            Dim da12 As SqlDataAdapter
            Dim Conn2 As SqlConnection = New SqlConnection(ConnString)
            Conn2.Open()
            da12 = New SqlDataAdapter(sql2, Conn2)
            Dim ds2 As DataSet = New DataSet()
            Dim datasource2 As ReportDataSource
            ds12 = New DataSet("DataSet1")
            da12.Fill(ds12, "DataSet1")
            datasource2 = New ReportDataSource("DataSet1", ds12.Tables(0))
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource2)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Ventas.rdlc")

            'Conexion para obtener Datatable de los PRODUCTOS.
            Dim sql22 As String = "SELECT Nombre FROM Productos INNER JOIN DetalleVentas ON DetalleVentas.Idproducto = Productos.IdProducto WHERE DetalleVentas.BajaLogica = 'False' ORDER BY DetalleVentas.IdDetalleVenta"
            Dim ds122 As DataSet
            Dim da122 As SqlDataAdapter
            Dim Conn22 As SqlConnection = New SqlConnection(ConnString)
            Conn22.Open()
            da122 = New SqlDataAdapter(sql22, Conn22)
            Dim ds22 As DataSet = New DataSet()
            Dim datasource22 As ReportDataSource
            ds122 = New DataSet("ProductosParaVentasDataSet")
            da122.Fill(ds122, "ProductosParaVentasDataSet")
            datasource22 = New ReportDataSource("ProductosParaVentasDataSet", ds122.Tables(0))
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource22)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Ventas.rdlc")

            'Conexion para obtener Datatable de los DetalleVentas.
            Dim sql23 As String = "SELECT IdVenta, IdDetalleVenta, Cantidad, Total FROM DetalleVentas WHERE BajaLogica = 'False' ORDER BY IdDetalleVenta"
            Dim ds123 As DataSet
            Dim da123 As SqlDataAdapter
            Dim Conn23 As SqlConnection = New SqlConnection(ConnString)
            Conn23.Open()
            da123 = New SqlDataAdapter(sql23, Conn23)
            Dim ds23 As DataSet = New DataSet()
            Dim datasource23 As ReportDataSource
            ds123 = New DataSet("DetalleVentasParaVentasDataSet")
            da123.Fill(ds123, "DetalleVentasParaVentasDataSet")
            datasource23 = New ReportDataSource("DetalleVentasParaVentasDataSet", ds123.Tables(0))
            Me.ReportViewer1.LocalReport.DataSources.Add(datasource23)
            Me.ReportViewer1.LocalReport.ReportPath = ("C:\Users\Luca\documents\visual studio 2010\Projects\ZorrittoCreaciones\ZorrittoCreaciones\Ventas.rdlc")


            'Cargo los parametros en el ReportViewer segun la lista de parametros creada, y el metodo Fill del TableAdapter Clientes.
            Dim ListaParametros As New List(Of ReportParameter)
            ListaParametros.Add(New ReportParameter("fecha", Now))
            ListaParametros.Add(New ReportParameter("tituloinforme", VTituloInforme))
            ReportViewer1.LocalReport.SetParameters(ListaParametros)
        End If
        'Refrescamos el ReportViewer.
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
