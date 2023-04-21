Public Class VentasNegocio

    Public Function AltaVenta(ByVal UnaVenta As CapaDeEntidades.VentasEntidades) As Boolean
        Dim MiConsulta As String = ("INSERT INTO Ventas VALUES('" & UnaVenta.IdCliente & "' , '" & UnaVenta.Fecha.ToString("MM-dd-yyyy") & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaVenta(ByVal UnaVenta As CapaDeEntidades.VentasEntidades) As Boolean
        Dim MiConsulta As String = ("UPDATE Ventas Set BajaLogica = 'True' Where IdVenta = ' " & UnaVenta.IdVenta & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodasLasVentas() As List(Of CapaDeEntidades.VentasEntidades)
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from Ventas where BajaLogica = 'False' order by Fecha")

        Dim MiLista As New List(Of CapaDeEntidades.VentasEntidades)
        Dim MiVenta As CapaDeEntidades.VentasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiVenta = New CapaDeEntidades.VentasEntidades
            MiVenta.IdVenta = miFila.Item(0)
            MiVenta.IdCliente = miFila.Item(1)
            MiVenta.Fecha = miFila.Item(2)
            MiVenta.BajaLogica = miFila.Item(3)
            MiLista.Add(MiVenta)
        Next
        Return MiLista
    End Function

    Public Function BuscarVentasFiltradas(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.VentasEntidades)
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "IdVenta" Then
            MiDt = MisDatos.Consultas("SELECT * FROM Ventas WHERE BajaLogica = 'False' AND Ventas.IdVenta LIKE '" & ValorFiltro & "%' ORDER BY Fecha")
        End If

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("SELECT IdVenta, Ventas.IdCliente, Fecha FROM Ventas INNER JOIN Clientes ON Ventas.IdCliente = Clientes.IdCliente WHERE Ventas.BajaLogica = 'False' AND Clientes.Nombre LIKE '" & ValorFiltro & "%' ORDER BY Fecha")
        End If

        If Filtro = "Apellido" Then
            MiDt = MisDatos.Consultas("SELECT IdVenta, Ventas.IdCliente, Fecha FROM Ventas INNER JOIN Clientes ON Ventas.IdCliente = Clientes.IdCliente WHERE Ventas.BajaLogica = 'False' AND Clientes.Apellido LIKE '" & ValorFiltro & "%' ORDER BY Fecha")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.VentasEntidades)
        Dim MiVenta As CapaDeEntidades.VentasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiVenta = New CapaDeEntidades.VentasEntidades
            MiVenta.IdVenta = miFila.Item(0)
            MiVenta.IdCliente = miFila.Item(1)
            MiVenta.Fecha = miFila.Item(2)
            MiLista.Add(MiVenta)
        Next
        Return MiLista
    End Function

    Public Function ModificarVenta(ByVal UnaVenta As CapaDeEntidades.VentasEntidades) As Boolean
        Dim MiConsulta As String = ("UPDATE Ventas SET IdCliente = '" & UnaVenta.IdCliente & "' ,  Fecha = '" & UnaVenta.Fecha & "', BajaLogica = 'False' where IdVenta = '" & UnaVenta.IdCliente & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDVenta() As List(Of CapaDeEntidades.VentasEntidades)
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdVenta) +1 from Ventas where BajaLogica = 'False'")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdVenta) +1 from Ventas where BajaLogica = 'True'")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.VentasEntidades)
                Dim MiVenta3 As CapaDeEntidades.VentasEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiVenta3 = New CapaDeEntidades.VentasEntidades
                    MiVenta3.IdVenta = 1
                    MiLista3.Add(MiVenta3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.VentasEntidades)
            Dim MiVenta2 As CapaDeEntidades.VentasEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiVenta2 = New CapaDeEntidades.VentasEntidades
                MiVenta2.IdVenta = miFila.Item(0)
                MiLista2.Add(MiVenta2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.VentasEntidades)
        Dim MiVenta As CapaDeEntidades.VentasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiVenta = New CapaDeEntidades.VentasEntidades
            MiVenta.IdVenta = miFila.Item(0)
            MiLista.Add(MiVenta)
        Next
        Return MiLista
    End Function

    Public Function IDVentaSegunCombo() As List(Of CapaDeEntidades.VentasEntidades)
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select IdVenta from Ventas where BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.VentasEntidades)
        Dim MiVenta As CapaDeEntidades.VentasEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiVenta = New CapaDeEntidades.VentasEntidades
            MiVenta.IdVenta = miFila.Item(0)
            MiLista.Add(MiVenta)
        Next
        Return MiLista
    End Function
End Class
