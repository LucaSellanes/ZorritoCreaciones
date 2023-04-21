'Capa de Negocios, donde se establece la lógica que utilizara el Detalle Ventas.
Public Class DetalleVentasNegocios

    Public Function AltaDetalleVenta(ByVal UnDetalle As CapaDeEntidades.DetalleVentasEntidades) As Boolean
        'Alta de un Detalle Ventas mediante un INSERT en SQL.
        Dim MiConsulta As String = ("INSERT INTO DetalleVentas VALUES('" & UnDetalle.IdVenta & "' , '" & UnDetalle.IdProducto & "' , '" & CDec(UnDetalle.Cantidad) & "' , '" & CDec(UnDetalle.Total) & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaDetalleVenta(ByVal UnDetalle As CapaDeEntidades.DetalleVentasEntidades) As Boolean
        'Baja de Detalle Venta mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE DetalleVentas Set BajaLogica = 'True' Where IdDetalleVenta = '" & UnDetalle.IdDetalleVentas & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodosLosDetalles(ByVal IDProducto As Integer) As List(Of CapaDeEntidades.DetalleVentasEntidades)
        'Busqueda de todos los datos de la tabla Detalle Ventas.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from DetalleVentas where BajaLogica = 'False' order by IdDetalleVenta")

        Dim MiLista As New List(Of CapaDeEntidades.DetalleVentasEntidades)
        Dim MiDetalle As CapaDeEntidades.DetalleVentasEntidades
        'Creo una lista con los atributos de los Detalle Ventas.
        For Each miFila As DataRow In MiDt.Rows
            MiDetalle = New CapaDeEntidades.DetalleVentasEntidades
            MiDetalle.IdDetalleVentas = miFila.Item(0)
            MiDetalle.IdVenta = miFila.Item(1)
            MiDetalle.IdProducto = miFila.Item(2)
            MiDetalle.Cantidad = miFila.Item(3)
            MiDetalle.Total = miFila.Item(4)
            MiDetalle.BajaLogica = miFila.Item(5)
            MiLista.Add(MiDetalle)
        Next
        Return MiLista
    End Function

    Public Function BuscarDetallesFiltrados(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.DetalleVentasEntidades)
        'Busco los Detalles de las Ventas segun un filtro determinado. El cual depende de los diversos parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "IdVenta" Then
            MiDt = MisDatos.Consultas("Select * from DetalleVentas where BajaLogica = 'False' and IdVenta like '" & ValorFiltro & "%' order by IdVenta")
        End If

        If Filtro = "Cantidad" Then
            MiDt = MisDatos.Consultas("Select * from DetalleVentas where BajaLogica = 'False' and Cantidad like '" & ValorFiltro & "%' order by Cantidad")
        End If

        If Filtro = "IdProducto" Then
            Dim FiltroProductos As Integer
            If IsNumeric(Filtro) = True Then
                FiltroProductos = CInt(Filtro)
            End If
            MiDt = MisDatos.Consultas("Select * from DetalleVentas where BajaLogica = 'False' and IdProducto like '" & ValorFiltro & "%' order by IdProducto")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.DetalleVentasEntidades)
        Dim MiDetalle As CapaDeEntidades.DetalleVentasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiDetalle = New CapaDeEntidades.DetalleVentasEntidades
            MiDetalle.IdDetalleVentas = miFila.Item(0)
            MiDetalle.IdVenta = miFila.Item(1)
            MiDetalle.IdProducto = miFila.Item(2)
            MiDetalle.Cantidad = miFila.Item(3)
            MiDetalle.Total = miFila.Item(4)
            MiDetalle.BajaLogica = miFila.Item(5)
            MiLista.Add(MiDetalle)
        Next
        Return MiLista
    End Function

    Public Function ModificarDetalleVenta(ByVal UnDetalle As CapaDeEntidades.DetalleVentasEntidades) As Boolean
        'Modificación del Detalle Venta a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE DetalleVentas SET IdVenta = '" & UnDetalle.IdVenta & "' ,  IdProducto = '" & UnDetalle.IdProducto & "', Cantidad = '" & UnDetalle.Cantidad & "', Total = '" & UnDetalle.Total & "', BajaLogica = 'False' where IdDetalleVenta = '" & UnDetalle.IdDetalleVentas & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDMaxDetalleVenta() As List(Of CapaDeEntidades.DetalleVentasEntidades)
        'Búsqueda del máximo ID de la tabla Detalle Venta, para poder usar como ID autoincremental.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdDetalleVenta) +1 from DetalleVentas where BajaLogica = 'False'")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdDetalleVenta) +1 from DetalleVentas where BajaLogica = 'True'")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.DetalleVentasEntidades)
                Dim MiDetalle3 As CapaDeEntidades.DetalleVentasEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiDetalle3 = New CapaDeEntidades.DetalleVentasEntidades
                    MiDetalle3.IdDetalleVentas = 1
                    MiLista3.Add(MiDetalle3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.DetalleVentasEntidades)
            Dim MiDetalle2 As CapaDeEntidades.DetalleVentasEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiDetalle2 = New CapaDeEntidades.DetalleVentasEntidades
                MiDetalle2.IdDetalleVentas = miFila.Item(0)
                MiLista2.Add(MiDetalle2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.DetalleVentasEntidades)
        Dim MiDetalle As CapaDeEntidades.DetalleVentasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiDetalle = New CapaDeEntidades.DetalleVentasEntidades
            MiDetalle.IdDetalleVentas = miFila.Item(0)
            MiLista.Add(MiDetalle)
        Next
        Return MiLista
    End Function

    Public Function BajaDetalleVentaSegunIDVenta(ByVal IdVenta As Integer) As Boolean
        'Baja de los Detalles Venta, asociados a un ID Venta. Esto se logra desde la sección Ventas.
        Dim MiConsulta As String = ("UPDATE DetalleVentas Set BajaLogica = 'True' WHERE DetalleVentas.IdVenta = '" & IdVenta & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function
End Class

