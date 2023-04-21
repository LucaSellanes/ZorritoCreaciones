'Capa de Negocios, donde se establece la lógica que utilizaran los Clientes.
Public Class ClientesNegocio
    Public Function AltaCliente(ByVal UnCliente As CapaDeEntidades.ClientesEntidades) As Boolean
        'Alta de Cliente mediante un INSERT en SQL.
        Dim MiConsulta As String = ("INSERT INTO Clientes VALUES('" & UnCliente.Nombre & "' , '" & UnCliente.Apellido & "' , '" & UnCliente.NombreNinoNina & "' , '" & UnCliente.FechaCumpleanos.ToString("MM-dd-2020") & "' , '" & UnCliente.AnosCumplidos & "' , '" & UnCliente.Localidad & "' , '" & UnCliente.Celular & "' , '" & UnCliente.FechaAlta.ToString("MM-dd-yyyy") & "' , '" & UnCliente.Comentarios & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaCliente(ByVal UnCliente As CapaDeEntidades.ClientesEntidades) As Boolean
        'Baja de Cliente mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE Clientes Set BajaLogica = 'True' Where IdCliente = ' " & UnCliente.IdCliente & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodosLosClientes() As List(Of CapaDeEntidades.ClientesEntidades)
        'Busqueda de todos los datos de la tabla Clientes ordenados por Nombre.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from Clientes where BajaLogica = 'False' order by Nombre")

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades
        'Creo una lista con los atributos de los Clientes.
        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.IdCliente = miFila.Item(0)
            MiCliente.Nombre = miFila.Item(1)
            MiCliente.Apellido = miFila.Item(2)
            MiCliente.NombreNinoNina = miFila.Item(3)
            MiCliente.FechaCumpleanos = miFila.Item(4)
            MiCliente.AnosCumplidos = miFila.Item(5)
            MiCliente.Localidad = miFila.Item(6)
            MiCliente.Celular = miFila.Item(7)
            MiCliente.FechaAlta = miFila.Item(8)
            MiCliente.Comentarios = miFila.Item(9)
            MiCliente.BajaLogica = miFila.Item(10)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function BuscarClientesFiltrados(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.ClientesEntidades)
        'Busco los Clientes segun un filtro determinado. El cual depende de los diversos parametros asignados.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("Select * from Clientes where BajaLogica = 'False' and Nombre like '" & ValorFiltro & "%' order by Nombre")
        End If

        If Filtro = "Apellido" Then
            MiDt = MisDatos.Consultas("Select * from Clientes where BajaLogica = 'False' and Apellido like '" & ValorFiltro & "%' order by Apellido")
        End If

        If Filtro = "Localidad" Then
            MiDt = MisDatos.Consultas("Select * from Clientes where BajaLogica = 'False' and Localidad like '" & ValorFiltro & "%' order by Localidad")
        End If

        If Filtro = "Nombreninonina" Then
            MiDt = MisDatos.Consultas("Select * from Clientes where BajaLogica = 'False' and Nombreninonina like '" & ValorFiltro & "%' order by Nombreninonina")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.IdCliente = miFila.Item(0)
            MiCliente.Nombre = miFila.Item(1)
            MiCliente.Apellido = miFila.Item(2)
            MiCliente.NombreNinoNina = miFila.Item(3)
            MiCliente.FechaCumpleanos = miFila.Item(4)
            MiCliente.AnosCumplidos = miFila.Item(5)
            MiCliente.Localidad = miFila.Item(6)
            MiCliente.Celular = miFila.Item(7)
            MiCliente.FechaAlta = miFila.Item(8)
            MiCliente.Comentarios = miFila.Item(9)
            MiCliente.BajaLogica = miFila.Item(10)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function ModificarCliente(ByVal Uncliente As CapaDeEntidades.ClientesEntidades) As Boolean
        'Modificación de los Clientes a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE Clientes SET Nombre = '" & Uncliente.Nombre & "' ,  Apellido = '" & Uncliente.Apellido & "', NombreNinoNina = '" & Uncliente.NombreNinoNina & "', FechaCumpleanos = '" & Uncliente.FechaCumpleanos.ToString("MM-dd-yyyy") & "', AnosCumplidos = '" & Uncliente.AnosCumplidos & "', Localidad = '" & Uncliente.Localidad & "', Celular = '" & Uncliente.Celular & "', FechaAlta = '" & Uncliente.FechaAlta.ToString("MM-dd-yyyy") & "', Comentarios = '" & Uncliente.Comentarios & "', BajaLogica = 'False' where IdCliente = '" & Uncliente.IdCliente & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDMaxCliente() As List(Of CapaDeEntidades.ClientesEntidades)
        'Búsqueda del máximo ID de la tabla Clientes, para poder usar como ID autoincremental.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdCliente) +1 from Clientes where BajaLogica = 'False'")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdCliente) +1 from Clientes where BajaLogica = 'True'")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.ClientesEntidades)
                Dim MiCliente3 As CapaDeEntidades.ClientesEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiCliente3 = New CapaDeEntidades.ClientesEntidades
                    MiCliente3.IdCliente = 1
                    MiLista3.Add(MiCliente3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.ClientesEntidades)
            Dim MiCliente2 As CapaDeEntidades.ClientesEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiCliente2 = New CapaDeEntidades.ClientesEntidades
                MiCliente2.IdCliente = miFila.Item(0)
                MiLista2.Add(MiCliente2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows

            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.IdCliente = miFila.Item(0)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function ComboNombreCliente() As List(Of CapaDeEntidades.ClientesEntidades)
        'Función para mostrar el Nombre y Apellido de todos los Clientes en la sección Ventas, que esten dados de alta.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("SELECT Nombre + ' ' + Apellido FROM clientes WHERE BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.Nombre = miFila.Item(0)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function IDCliente(ByVal NombreApellido As String) As List(Of CapaDeEntidades.ClientesEntidades)
        'Traigo el ID del Cliente segun el Nombre y Apellido del mismo.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select IdCliente from Clientes where Nombre + ' ' + Apellido = '" & NombreApellido & "' AND BajaLogica = 'False'")

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.IdCliente = miFila.Item(0)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function NombreClienteSegunIdDelCliente(ByVal IDVenta As Integer) As List(Of CapaDeEntidades.ClientesEntidades)
        'A partir del ID del Cliente, traemos de la base el Nombre y Apellido asociado a una Venta en particular.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("SELECT Nombre + ' ' + Apellido from Clientes INNER JOIN Ventas ON Clientes.IdCliente = Ventas.IdCliente and Ventas.IdVenta = '" & IDVenta & "'")

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.Nombre = miFila.Item(0)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function TodosLosNombresDelCliente() As List(Of CapaDeEntidades.ClientesEntidades)
        'Busqueda de todos los Nombres y Apellidos de los Clientes. Esto se usa para tener en vista los nombres de los clientes a los cuales se les hizo una venta, en la sección Ventas.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select Nombre + ' ' + Apellido AS Clientes FROM Clientes, Ventas WHERE Clientes.IdCliente = Ventas.IdCliente and Ventas.BajaLogica = 'False' Order by Ventas.Fecha")

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.Nombre = miFila.Item(0)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function

    Public Function NombresDelClienteFiltrados(ByVal Filtro As String, ByVal ValorFiltro As String) As List(Of CapaDeEntidades.ClientesEntidades)
        'Busco el Nombre y Apellido del cliente en una misma cadena, segun un filtro determinado. El cual depende del parametro asignado.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        If Filtro = "IdVenta" Then
            MiDt = MisDatos.Consultas("Select Nombre + ' ' + Apellido AS Clientes FROM Clientes, Ventas WHERE Clientes.IdCliente = Ventas.IdCliente AND Ventas.IdVenta LIKE '" & ValorFiltro & "%' AND Ventas.BajaLogica = 'False' ORDER BY Ventas.Fecha")
        End If

        If Filtro = "Nombre" Then
            MiDt = MisDatos.Consultas("Select Nombre + ' ' + Apellido AS Clientes FROM Clientes, Ventas WHERE Clientes.IdCliente = Ventas.IdCliente AND Clientes.Nombre LIKE '" & ValorFiltro & "%' AND Ventas.BajaLogica = 'False' ORDER BY Ventas.Fecha")
        End If

        If Filtro = "Apellido" Then
            MiDt = MisDatos.Consultas("Select Nombre + ' ' + Apellido AS Clientes FROM Clientes, Ventas WHERE Clientes.IdCliente = Ventas.IdCliente AND Clientes.Apellido LIKE '" & ValorFiltro & "%' AND Ventas.BajaLogica = 'False' ORDER BY Ventas.Fecha")
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ClientesEntidades)
        Dim MiCliente As CapaDeEntidades.ClientesEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCliente = New CapaDeEntidades.ClientesEntidades
            MiCliente.Nombre = miFila.Item(0)
            MiLista.Add(MiCliente)
        Next
        Return MiLista
    End Function
End Class
