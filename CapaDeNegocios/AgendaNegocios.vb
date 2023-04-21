'Capa de Negocios, donde se establece la lógica que utilizara la Agenda.
Public Class AgendaNegocios

    Public Function AltaAgenda(ByVal UnaAgenda As CapaDeEntidades.AgendaEntidades) As Boolean
        'Alta en la base de datos de la Agenda. Donde se establece el formato de la fecha a dar de alta.
        Dim MiConsulta As String = ("INSERT INTO Agenda VALUES('" & UnaAgenda.NombreCliente & "' , '" & UnaAgenda.Tematica & "' , '" & UnaAgenda.FechaEntrega.ToString("MM-dd-yyyy") & "' , '" & UnaAgenda.Pedido & "' , '" & UnaAgenda.Total & "', '" & UnaAgenda.Importe & "' , '" & UnaAgenda.Faltante & "' , '" & UnaAgenda.Comentarios & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function


    Public Function BajaAgenda(ByVal UnaAgenda As CapaDeEntidades.AgendaEntidades) As Boolean
        'Baja de Agenda mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE Agenda Set BajaLogica = 'True' Where IdAgenda = ' " & UnaAgenda.IdAgenda & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodasLasAgendas() As List(Of CapaDeEntidades.AgendaEntidades)
        'Busqueda de todos los datos de la tabla Agenda.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("SELECT * FROM Agenda WHERE BajaLogica = 'False' ORDER BY FechaEntrega")

        Dim MiLista As New List(Of CapaDeEntidades.AgendaEntidades)
        Dim MiAgenda As CapaDeEntidades.AgendaEntidades
        'Creo una lista con los atributos de la Agenda.
        For Each miFila As DataRow In MiDt.Rows
            MiAgenda = New CapaDeEntidades.AgendaEntidades
            MiAgenda.IdAgenda = miFila.Item(0)
            MiAgenda.NombreCliente = miFila.Item(1)
            MiAgenda.Tematica = miFila.Item(2)
            MiAgenda.FechaEntrega = miFila.Item(3)
            MiAgenda.Pedido = miFila.Item(4)
            MiAgenda.Total = miFila.Item(5)
            MiAgenda.Importe = miFila.Item(6)
            MiAgenda.Faltante = miFila.Item(7)
            MiAgenda.Comentarios = miFila.Item(8)
            MiAgenda.BajaLogica = miFila.Item(9)
            MiLista.Add(MiAgenda)
        Next
        Return MiLista
    End Function

    Public Function ModificarAgenda(ByVal UnaAgenda As CapaDeEntidades.AgendaEntidades) As Boolean
        'Modificación de la Agenda a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE Agenda SET Tematica = '" & UnaAgenda.Tematica & "' , FechaEntrega = '" & UnaAgenda.FechaEntrega.ToString("MM-dd-yyyy") & "', Pedido = '" & UnaAgenda.Pedido & "', Total = '" & UnaAgenda.Total & "', Importe = '" & UnaAgenda.Importe & "', Faltante= '" & UnaAgenda.Faltante & "', Comentarios = '" & UnaAgenda.Comentarios & "', BajaLogica = 'False' where IdAgenda = '" & UnaAgenda.IdAgenda & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDMaxAgenda() As List(Of CapaDeEntidades.AgendaEntidades)
        'Búsqueda del máximo ID de la tabla Agenda, para poder usar como ID autoincremental.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdAgenda) +1 from Agenda where BajaLogica = 'False'")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdAgenda) +1 from Agenda where BajaLogica = 'True'")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.AgendaEntidades)
                Dim MiAgenda3 As CapaDeEntidades.AgendaEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiAgenda3 = New CapaDeEntidades.AgendaEntidades
                    MiAgenda3.IdAgenda = 1
                    MiLista3.Add(MiAgenda3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.AgendaEntidades)
            Dim MiAgenda2 As CapaDeEntidades.AgendaEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiAgenda2 = New CapaDeEntidades.AgendaEntidades
                MiAgenda2.IdAgenda = miFila.Item(0)
                MiLista2.Add(MiAgenda2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.AgendaEntidades)
        Dim MiAgenda As CapaDeEntidades.AgendaEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiAgenda = New CapaDeEntidades.AgendaEntidades
            MiAgenda.IdAgenda = miFila.Item(0)
            MiLista.Add(MiAgenda)
        Next
        Return MiLista
    End Function
End Class
