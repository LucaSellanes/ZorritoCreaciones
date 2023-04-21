'Capa de Negocios, donde se establece la lógica que utilizara la seccion Financiero.
Public Class FinancieroNegocios
    Public Function BuscarCompras()
        'Busca las todas las Compras de la tabla Compras, con signo negativo, de manera que la sumatoria de las mismas quede restando. Estas se ordenan por la fecha.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("SELECT Fecha, CodigoArticulo ,Nombre, SUM(-PrecioBulto) FROM Compras WHERE Compras.BajaLogica = 'False' GROUP BY Nombre, Fecha, CodigoArticulo ORDER BY Fecha")
        Return MiDt
    End Function

    Public Function BuscarVentas()
        'Busca los datos de las ventas ordenados por fecha. Estos se obtienen con signo positivo.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("SELECT Fecha, DetalleVentas.IdVenta, Clientes.Nombre,  Total FROM DetalleVentas INNER JOIN Ventas ON Ventas.IdVenta = DetalleVentas.IdVenta INNER JOIN Clientes ON Ventas.IdCliente = Clientes.IdCliente AND DetalleVentas.BajaLogica = 'False' GROUP BY total, DetalleVentas.IdVenta, Fecha, Nombre ORDER BY Fecha")
        Return MiDt
    End Function

    Public Function BuscarComprasFiltradas(ByVal Filtro As String, ByVal ValorFiltro As String)
        'Realiza la busqueda de las compras segun el filtro seleccionado. Este se asigna mediante un parametro dentro de un Combobox de la sección Financiero.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "CodigoArticulo" Then
            MiDt = MisDatos.Consultas("SELECT Fecha, CodigoArticulo ,Nombre, SUM(-PrecioBulto) FROM Compras WHERE CodigoArticulo LIKE '" & ValorFiltro & "%' GROUP BY Nombre, Fecha, CodigoArticulo")
        End If

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("SELECT Fecha, CodigoArticulo ,Nombre, SUM(-PrecioBulto) FROM Compras WHERE Nombre LIKE '" & ValorFiltro & "%' GROUP BY Nombre, Fecha, CodigoArticulo")
        End If
        Return MiDt
    End Function

    Public Function BuscarVentasFiltradas(ByVal Filtro As String, ByVal ValorFiltro As String)
        'Realiza la busqueda de las ventas segun el filtro seleccionado. Este se asigna mediante un parametro dentro de un Combobox de la sección Financiero.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("SELECT Fecha, DetalleVentas.IdVenta, Clientes.Nombre, SUM(Total) FROM DetalleVentas INNER JOIN Ventas ON Ventas.IdVenta = DetalleVentas.IdVenta INNER JOIN Clientes ON Ventas.IdCliente = Clientes.IdCliente  AND DetalleVentas.BajaLogica = 'False' WHERE Nombre LIKE '" & ValorFiltro & "%' GROUP BY total, DetalleVentas.IdVenta, Fecha, Nombre ORDER BY Fecha")
        End If

        If Filtro = "IdVenta" Then
            MiDt = MisDatos.Consultas("SELECT Fecha, DetalleVentas.IdVenta, Clientes.Nombre, SUM(Total) FROM DetalleVentas INNER JOIN Ventas ON Ventas.IdVenta = DetalleVentas.IdVenta INNER JOIN Clientes ON Ventas.IdCliente = Clientes.IdCliente AND DetalleVentas.BajaLogica = 'False' WHERE DetalleVentas.IdVenta LIKE '" & ValorFiltro & "%' GROUP BY total, DetalleVentas.IdVenta, Fecha, Nombre ORDER BY Fecha")
        End If
        Return MiDt
    End Function

    Public Function BuscarComprasPorFecha(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        'Busca las compras entre un rango de fechas establecido por el usuario.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("Select * From Compras WHERE Fecha between '" & Fecha1.ToString("MM-dd-yyyy") & "' and '" & Fecha2.ToString("MM-dd-yyyy") & "' and BajaLogica = 'False'")
        Return MiDt
    End Function

    Public Function BuscarVentasPorFecha(ByVal Fecha1 As Date, ByVal Fecha2 As Date)
        'Busca las ventas entre un rango de fechas establecido por el usuario.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos
        MiDt = MisDatos.Consultas("SELECT Fecha, DetalleVentas.IdVenta, Clientes.Nombre, SUM(Total) FROM DetalleVentas INNER JOIN Ventas ON Ventas.IdVenta = DetalleVentas.IdVenta INNER JOIN Clientes ON Ventas.IdCliente = Clientes.IdCliente AND DetalleVentas.BajaLogica = 'False' WHERE Fecha between '" & Fecha1.ToString("MM-dd-yyyy") & "' and '" & Fecha2.ToString("MM-dd-yyyy") & "' GROUP BY total, DetalleVentas.IdVenta, Fecha, Nombre ORDER BY Fecha ")
        Return MiDt
    End Function
End Class

