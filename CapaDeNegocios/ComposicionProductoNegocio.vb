'Capa de Negocios, donde se establece la lógica que utilizara la Composición de los Productos.
Public Class ComposicionProductoNegocio
    Public Function AltaComposicion(ByVal IDProd As Integer, ByVal UnaComp As CapaDeEntidades.ComposicionProductosEntidades) As Boolean
        'Alta de Composición Producto mediante un INSERT en SQL.
        Dim MiConsulta As String = ("INSERT INTO ComposicionProductos VALUES('" & IDProd & "' , '" & UnaComp.CodigoArticulo & "' , '" & UnaComp.CantidadMateriaPrima & "' ,  '" & UnaComp.Costo & "' , '" & UnaComp.CostoTotal & "' , 'False')")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BajaComposicion(ByVal UnaComp As CapaDeEntidades.ComposicionProductosEntidades) As Boolean
        'Baja de Composición Productos mediante un UPDATE en SQL pasando el valor BajaLogica de False a True.
        Dim MiConsulta As String = ("UPDATE ComposicionProductos Set BajaLogica = 'True' Where IdComposicionProducto = ' " & UnaComp.IdComposicionProducto & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function BuscarTodaComposicion() As List(Of CapaDeEntidades.ComposicionProductosEntidades)
        'Busqueda de todos los datos de la tabla Composición Productos ordenados por ID.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select * from ComposicionProductos where BajaLogica = 'False' order by IdComposicionProducto")

        Dim MiLista As New List(Of CapaDeEntidades.ComposicionProductosEntidades)
        Dim MiUsuario As CapaDeEntidades.ComposicionProductosEntidades
        'Creo una lista con los atributos de los Clientes.
        For Each miFila As DataRow In MiDt.Rows
            MiUsuario = New CapaDeEntidades.ComposicionProductosEntidades
            MiUsuario.IdComposicionProducto = miFila.Item(0)
            MiUsuario.IdProducto = miFila.Item(1)
            MiUsuario.CodigoArticulo = miFila.Item(2)
            MiUsuario.CantidadMateriaPrima = miFila.Item(3)
            MiUsuario.Costo = miFila.Item(4)
            MiUsuario.CostoTotal = miFila.Item(5)
            MiUsuario.BajaLogica = miFila.Item(6)
            MiLista.Add(MiUsuario)
        Next
        Return MiLista
    End Function

    Public Function ModificarComposicion(ByVal UnaComp As CapaDeEntidades.ComposicionProductosEntidades, ByVal IDProd As Integer, ByVal CodigoArticulo As String) As Boolean
        'Modificación de la Composición Productos a traves de un UPDATE donde reescribo todos los campos.
        Dim MiConsulta As String = ("UPDATE ComposicionProductos SET IdProducto = '" & IDProd & "' , CodigoArticulo = '" & CodigoArticulo & "' , CantidadMateriaPrima = '" & UnaComp.CantidadMateriaPrima & "' ,  Costo = '" & UnaComp.Costo & "' , CostoTotal = '" & UnaComp.CostoTotal & "' , BajaLogica = 'False' where IdComposicionProducto = '" & UnaComp.IdComposicionProducto & "'")
        Dim MisDatos As New CapaDeDatos.Datos
        MisDatos.Ejecutar(MiConsulta)
        Return True
    End Function

    Public Function IDCompoProd() As List(Of CapaDeEntidades.ComposicionProductosEntidades)
        'Búsqueda del máximo ID de la tabla Composición Productos, para poder usar como ID autoincremental.
        Dim MiDt As New DataTable
        Dim MisDatos As New CapaDeDatos.Datos

        MiDt = MisDatos.Consultas("Select MAX(IdComposicionProducto) +1 from ComposicionProductos where BajaLogica = 'False'")

        'Si inicia esta funcion, y no hay ningun ID con BajaLogica en False, el valor va a ser Null (porque esta vacío). En ese caso, toma el mayor ID con BajaLogica = True y le suma 1.
        If IsDBNull(MiDt.Rows.Item(0)(0)) Then

            MiDt = MisDatos.Consultas("Select MAX(IdComposicionProducto) +1 from ComposicionProductos where BajaLogica = 'True'")

            'Si es la primera vez que se inicia esta funcion, el valor va a ser Null (porque esta vacío). En ese caso, se completa con "1" el ID.
            If IsDBNull(MiDt.Rows.Item(0)(0)) Then
                Dim MiLista3 As New List(Of CapaDeEntidades.ComposicionProductosEntidades)
                Dim MiCompo3 As CapaDeEntidades.ComposicionProductosEntidades

                For Each miFila As DataRow In MiDt.Rows
                    MiCompo3 = New CapaDeEntidades.ComposicionProductosEntidades
                    MiCompo3.IdComposicionProducto = 1
                    MiLista3.Add(MiCompo3)
                Next
                Return MiLista3
                Exit Function
            End If

            Dim MiLista2 As New List(Of CapaDeEntidades.ComposicionProductosEntidades)
            Dim MiCompo2 As CapaDeEntidades.ComposicionProductosEntidades

            For Each miFila As DataRow In MiDt.Rows
                MiCompo2 = New CapaDeEntidades.ComposicionProductosEntidades
                MiCompo2.IdComposicionProducto = miFila.Item(0)
                MiLista2.Add(MiCompo2)
            Next
            Return MiLista2
            Exit Function
        End If

        Dim MiLista As New List(Of CapaDeEntidades.ComposicionProductosEntidades)
        Dim MiCompo As CapaDeEntidades.ComposicionProductosEntidades

        For Each miFila As DataRow In MiDt.Rows
            MiCompo = New CapaDeEntidades.ComposicionProductosEntidades
            MiCompo.IdComposicionProducto = miFila.Item(0)
            MiLista.Add(MiCompo)
        Next
        Return MiLista
    End Function
End Class
