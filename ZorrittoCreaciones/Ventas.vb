Public Class Ventas

    Private Sub AbrirFormEnPanel1(ByVal FormHijo As Object)
        If Form2.PanelContenedor.Controls.Count > 0 Then
            Form2.PanelContenedor.Controls.RemoveAt(0)
            'Declaramos variable tipo Form que es el parametro de entrada.
        End If
        Dim fh As Form = TryCast(FormHijo, Form)
        'Con esto indicamos que el Form no es de nivel superior.
        fh.TopLevel = False
        'Quitamos los bordes al Form.
        fh.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Acoplamos todo el Form al PanelContenedor
        fh.Dock = DockStyle.Fill
        'Agregamos los controles del Form al PanelContenedor
        Form2.PanelContenedor.Controls.Add(fh)
        'El  PanelContenedor tendra los datos del formulario.
        Form2.PanelContenedor.Tag = fh
        'Mostramos el formulario.
        fh.Show()
    End Sub

    Private Sub Button1_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseMove
        'Al pasar por el botón Detalle de Ventas, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el botón Detalle de Ventas, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseMove
        'Al pasar por el botón Borrar Campos, la fuente del mismo cambiara a blanco.
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        'Al dejar de pasar por el botón Borrar Campos, la fuente del mismo volvera a negro.
        Button5.ForeColor = Color.Black
    End Sub

    Private Sub Button10_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.MouseMove
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button10.ForeColor = Color.White
    End Sub

    Private Sub Button10_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
        Button10.ForeColor = Color.Black
    End Sub

    Private Sub Button9_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseMove
        'Al pasar por el botón Modificar, la fuente del mismo cambiara a blanco.
        Button9.ForeColor = Color.White
    End Sub

    Private Sub Button9_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
        'Al dejar de pasar por el botón Modificar, la fuente del mismo volvera a negro.
        Button9.ForeColor = Color.Black
    End Sub

    Private Sub Button8_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseMove
        'Al pasar por el botón Baja, la fuente del mismo cambiara a blanco.
        Button8.ForeColor = Color.White
    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        'Al dejar de pasar por el botón Baja, la fuente del mismo volvera a negro.
        Button8.ForeColor = Color.Black
    End Sub

    Private Sub Button7_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseMove
        'Al pasar por el botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button7.ForeColor = Color.White
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        'Al dejar de pasar por el botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button7.ForeColor = Color.Black
    End Sub

    Private Sub Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Deshabilito los TxT correspondientes a ID.
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Creamos las columnas del Datagrid Ventas.
        Me.DataGridView1.Columns.Add("0", "N° de Venta")
        Me.DataGridView1.Columns.Add("1", "N° Cliente")
        Me.DataGridView1.Columns.Add("2", "Nombre Cliente")
        Me.DataGridView1.Columns.Add("3", "Fecha")

        'Asigno al Combo1 estilo y le paso los Nombres de los Clientes con el Metodo ListaClientesACombo.
        Me.ComboBox1.Items.Clear()
        Dim combo1 As String
        combo1 = ComboBox1.Text
        ComboBox1.DropDownStyle = 2
        ComboBox2.DropDownStyle = 2

        Dim ComboNegocios As New CapaDeNegocios.ClientesNegocio
        Dim ComboEntidades As New List(Of CapaDeEntidades.ClientesEntidades)

        ComboEntidades = ComboNegocios.ComboNombreCliente()
        ListaClientesACombo(ComboEntidades)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
    End Sub

    Sub ListaClientesACombo(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Asigno al Combo1 los Nombres de los clientes.
        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            ComboBox1.Items.Add(MiDetalle.Nombre)
        Next
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Sub LimpiarTxTVentas()
        'Metodo para limpiar Combo y DatatimePicker.
        ComboBox1.SelectedIndex = -1
        DateTimePicker1.Value = Date.Now
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Boton Alta Ventas.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Validación para evitar campos vacíos.
        If ComboBox1.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        Dim ClienteNegocio As New CapaDeNegocios.VentasNegocio
        Dim ClienteEntidad As New CapaDeEntidades.VentasEntidades

        'Paso a la función Alta Venta, los parámetros de mi objeto segun lo completado en los Textbox.
        ClienteEntidad.IdVenta = TextBox1.Text
        ClienteEntidad.IdCliente = TextBox2.Text
        ClienteEntidad.Fecha = DateTimePicker1.Text

        Dim Resultado As Boolean
        Resultado = ClienteNegocio.AltaVenta(ClienteEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("La venta se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxTVentas()
        Else
            MsgBox("La venta ya existe. Ingrese una distinto.", vbCritical, "Error")
            LimpiarTxTVentas()
            Exit Sub
        End If
    End Sub

    Sub IDClienteSegunNombre(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Asigno al TxT2 el ID del Cliente.
        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            TextBox2.Text = MiDetalle.IdCliente
        Next
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        'Se completa el Txt2 con el ID correspondiente al nombre que se establece en el Combo1.
        Dim IDClienteNegocios As New CapaDeNegocios.ClientesNegocio
        Dim IDClienteEntidades As New List(Of CapaDeEntidades.ClientesEntidades)

        IDClienteEntidades = IDClienteNegocios.IDCliente(ComboBox1.Text)
        IDClienteSegunNombre(IDClienteEntidades)
    End Sub

    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de las Ventas (TextBox1).
        Dim IDVentaNegocios As New CapaDeNegocios.VentasNegocio
        Dim IDVentaEntidades As New List(Of CapaDeEntidades.VentasEntidades)

        IDVentaEntidades = IDVentaNegocios.IDVenta()
        IDVentaATxT(IDVentaEntidades)
    End Sub

    Sub IDVentaATxT(ByVal ListaDetalles As List(Of CapaDeEntidades.VentasEntidades))
        'Asignamos el ID Venta al TxT1.
        For Each MiDetalle As CapaDeEntidades.VentasEntidades In ListaDetalles
            TextBox1.Text = MiDetalle.IdVenta
        Next
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Botón para Baja de un Venta.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar la Venta seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (RespuestaBaja = DialogResult.No) Then
            Exit Sub
        End If

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al seleccionar un boton y que no este cargado el Datagrid. En caso de pasar esto, se cerrara el proceso con un mensajer alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        Dim VentaNegocio As New CapaDeNegocios.VentasNegocio
        Dim VentaEntidad As New CapaDeEntidades.VentasEntidades
        Dim Resultado As Boolean

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID de la Venta seleccionada y con eso podemos dar de baja la misma.
        Dim Seleccionado As Integer = 0
        Seleccionado = DataGridView1.SelectedRows(0).Cells(0).Value()

        'Comienzo de la Baja de todos los Detalles de la Venta, asociados al ID Venta.
        Dim DetalleVentaNegocio As New CapaDeNegocios.DetalleVentasNegocios
        Dim DetalleVentaEntidad As New CapaDeEntidades.DetalleVentasEntidades
        Dim DetalleResultado As Boolean

        DetalleVentaEntidad.IdVenta = Seleccionado
        DetalleResultado = DetalleVentaNegocio.BajaDetalleVentaSegunIDVenta(Seleccionado)
        'Final de la Baja de los Detalles de las Ventas.

        VentaEntidad.IdVenta = Seleccionado
        Resultado = VentaNegocio.BajaVenta(VentaEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("La venta fue eliminada correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxTVentas()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxTVentas()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Botón Modificar Ventas.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al seleccionar un boton y que no este cargado el Datagrid. En caso de pasar esto, se cerrara el proceso con un mensajer alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción pulsando la flecha a la izquierda del comienzo cada fila", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If ComboBox1.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        Dim VentaNegocio As New CapaDeNegocios.VentasNegocio
        Dim VentaEntidad As New CapaDeEntidades.VentasEntidades

        'Paso a la función Modificar Venta, los parámetros de mi objeto segun lo completado en los Textbox.
        VentaEntidad.IdVenta = TextBox1.Text
        VentaEntidad.IdCliente = TextBox2.Text
        VentaEntidad.Fecha = DateTimePicker1.Text

        Dim Resultado As Boolean

        Resultado = VentaNegocio.ModificarVenta(VentaEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("La venta fue modificada correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxTVentas()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxTVentas()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Todos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio la grilla e introduzco la función para traer todas las Ventas.
        Me.DataGridView1.Rows.Clear()

        'Cargo la grilla con los datos de la Venta.
        Dim VentaNegocio As New CapaDeNegocios.VentasNegocio
        Dim VentaEntidad As New List(Of CapaDeEntidades.VentasEntidades)
        VentaEntidad = VentaNegocio.BuscarTodasLasVentas()
        LlenarGrilla(VentaEntidad)

        'Cargo la grilla con todos los nombres de las ventas, sin filtro alguno.
        Dim NombreNegocio As New CapaDeNegocios.ClientesNegocio
        Dim NombreEntidad As New List(Of CapaDeEntidades.ClientesEntidades)
        NombreEntidad = NombreNegocio.TodosLosNombresDelCliente()
        NombresDeClientesADataGrid(NombreEntidad)

        'Limpio los TxT del formulario de Ventas.
        LimpiarTxTVentas()

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView1.Rows(0).Selected = False
        End If
    End Sub

    Sub NombresDeClientesADataGrid(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Llenamos la Grilla del DataGrid con el nombre de los clientes.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.Nombre
            Fila += 1
        Next
    End Sub

    Sub LlenarGrilla(ByVal ListaDetalles As List(Of CapaDeEntidades.VentasEntidades))
        'Llenamos la grilla del DataGrid de Ventas.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.VentasEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(0).Value = MiDetalle.IdVenta
            Me.DataGridView1.Rows(Fila).Cells(1).Value = MiDetalle.IdCliente
            Me.DataGridView1.Rows(Fila).Cells(3).Value = MiDetalle.Fecha
            Fila += 1
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Botón Detalle de Ventas.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "DetalleVentas" Then
                Form.Close()
            End If
        Next

        AbrirFormEnPanel1(New DetalleVentas)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Usamos el evento para que al seleccionar una fila del DataGrid, los Txt tomen los valores de dicha fila.
        Dim NumeroDeFilaSeleccionada As Integer
        Dim ValidacionCeldaVacia As String

        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error y salgamos del proceso.
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        NumeroDeFilaSeleccionada = DataGridView1.CurrentRow.Index
        ValidacionCeldaVacia = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(0).Value

        If ValidacionCeldaVacia = Nothing Then
            MsgBox("La fila seleccionada no contiene datos.", vbCritical, "Error")
            Exit Sub
        End If

        'Completamos los TxT y Combos con el contenido de la fila seleccionada.
        TextBox1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        ComboBox1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        DateTimePicker1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        'Estructuramos el TxT3 para que al estar vacío traiga todas las Ventas. Caso contrario, filtre las mismas segun el parametro ingresado. 

        Dim VariableFiltro As String = ""

        'Limpio la grilla e introduzco la funcion para traer todos las Ventas.
        Me.DataGridView1.Rows.Clear()

        If TextBox3.Text = "" Then
            'Cargo la grilla con los datos de la Venta.
            Dim VentaNegocio As New CapaDeNegocios.VentasNegocio
            Dim VentaEntidad As New List(Of CapaDeEntidades.VentasEntidades)
            VentaEntidad = VentaNegocio.BuscarTodasLasVentas()
            LlenarGrilla(VentaEntidad)

            'Cargo la grilla con todos los nombres de las ventas, sin filtro alguno.
            Dim NombreNegocio As New CapaDeNegocios.ClientesNegocio
            Dim NombreEntidad As New List(Of CapaDeEntidades.ClientesEntidades)
            NombreEntidad = NombreNegocio.TodosLosNombresDelCliente()
            NombresDeClientesADataGrid(NombreEntidad)
        End If


        If TextBox3.Text <> "" Then
            Dim VentaNegocio As New CapaDeNegocios.VentasNegocio
            Dim VentaEntidad As New List(Of CapaDeEntidades.VentasEntidades)

            Dim NombreNegocio As New CapaDeNegocios.ClientesNegocio
            Dim NombreEntidad As New List(Of CapaDeEntidades.ClientesEntidades)

            If ComboBox2.Text = "N° de Venta" Then
                VariableFiltro = "IdVenta"
                'Cargo la grilla con los datos de la Venta filtrados segun IdVenta.
                VentaEntidad = VentaNegocio.BuscarVentasFiltradas(VariableFiltro, TextBox3.Text)

                'Cargo la grilla con los datos del Cliente filtrados segun IdVenta.
                NombreEntidad = NombreNegocio.NombresDelClienteFiltrados(VariableFiltro, TextBox3.Text)

                'Metodos para llenar las grillas con ambas tablas obtenidas.
                LlenarGrilla(VentaEntidad)
                NombresDeClientesADataGrid(NombreEntidad)
            End If

            If ComboBox2.Text = "Nombre" Or ComboBox2.Text = "Apellido" Then
                VariableFiltro = ComboBox2.Text

                'Cargo la grilla con los datos de la Venta filtrados segun IdVenta.
                VentaEntidad = VentaNegocio.BuscarVentasFiltradas(VariableFiltro, TextBox3.Text)

                'Cargo la grilla con los datos del Cliente filtrados segun IdVenta.
                NombreEntidad = NombreNegocio.NombresDelClienteFiltrados(VariableFiltro, TextBox3.Text)

                'Metodos para llenar las grillas con ambas tablas obtenidas.
                LlenarGrilla(VentaEntidad)
                NombresDeClientesADataGrid(NombreEntidad)
            End If
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Botón Borrar Campos.

        'Reestablezco Combo, TxT y DateTimePicker.
        ComboBox1.SelectedIndex = -1
        TextBox2.Text = ""
        DateTimePicker1.Text = Date.Now

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        'Si al desplegar el Combo no hay informaci♀n cargada para mostrar, lo indica mediante un mensaje y termina el proceso.
        If ComboBox1.Items.Count <= 0 Then
            MsgBox("No hay ningún cliente cargado aún.", vbCritical, "Error")
            ComboBox1.Enabled = False
            Exit Sub
        End If
    End Sub
End Class