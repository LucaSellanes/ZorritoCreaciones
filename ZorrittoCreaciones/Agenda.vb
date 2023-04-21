Public Class Agenda

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

    Private Sub Button7_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseMove
        'Al pasar por el botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button7.ForeColor = Color.White
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        'Al dejar de pasar por el botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button7.ForeColor = Color.Black
    End Sub

    Private Sub Button8_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseMove
        'Al pasar por el botón Baja, la fuente del mismo cambiara a blanco.
        Button8.ForeColor = Color.White
    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        'Al dejar de pasar por el botón Baja, la fuente del mismo volvera a negro.
        Button8.ForeColor = Color.Black
    End Sub

    Private Sub Button9_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseMove
        'Al pasar por el botón Modificar, la fuente del mismo cambiara a blanco.
        Button9.ForeColor = Color.White
    End Sub

    Private Sub Button9_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
        'Al dejar de pasar por el boton Modificar, la fuente del mismo volvera a negro.
        Button9.ForeColor = Color.Black
    End Sub

    Private Sub Button10_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.MouseMove
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button10.ForeColor = Color.White
    End Sub

    Private Sub Button10_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
        Button10.ForeColor = Color.Black
    End Sub

    Private Sub Button5_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseMove
        'Al pasar por el botón Borrar Campos, la fuente del mismo cambiara a blanco.
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        'Al dejar de pasar por el botón Borrar Campos, la fuente del mismo volvera a negro.
        Button5.ForeColor = Color.Black
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        'Botón para volver al formulario anterior y cerrar el actual. Además, se actualiza la hora y fecha.
        Me.Close()
        ActualizarLabel()
        AbrirFormEnPanel1(New Clientes)
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Private Sub Agenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título en el form.
        Label1.Left = (((Me.Width - 760) - Label1.Width) / 2) + 35
        Label1.Top = 10

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Doy formato a los Combos y establezco un elemento de inicio preestablecido para evitar errores.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0

        'Deshabilito el Txt del ID y de lo Restante a abonar.
        TextBox1.ReadOnly = True
        TextBox7.ReadOnly = True

        'Creamos las columnas del Datagrid Agenda.
        Me.DataGridView1.Columns.Add("N° Agenda", "N° Agenda")
        Me.DataGridView1.Columns.Add("Cliente", "Cliente")
        Me.DataGridView1.Columns.Add("Temática", "Temática")
        Me.DataGridView1.Columns.Add("Fecha Entrega", "Fecha Entrega")
        Me.DataGridView1.Columns.Add("Pedido", "Pedido")
        Me.DataGridView1.Columns.Add("Total", "Total")
        Me.DataGridView1.Columns.Add("Seña", "Seña")
        Me.DataGridView1.Columns.Add("Faltante", "Faltante")
        Me.DataGridView1.Columns.Add("Comentarios", "Comentarios")

        'Llenamos el combo1 con el nombre y apellido de los clientes.
        Me.ComboBox1.Items.Clear()
        Dim ComboNegocios As New CapaDeNegocios.ClientesNegocio
        Dim ComboEntidades As New List(Of CapaDeEntidades.ClientesEntidades)
        ComboEntidades = ComboNegocios.ComboNombreCliente()
        ListaClientesACombo(ComboEntidades)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Le doy formato numerico y de moneda a la columna Precio Venta del DataGrid. Y al Txt PrecioVenta.
        DataGridView1.Columns(5).DefaultCellStyle.Format = "$" & "######.00"
        DataGridView1.Columns(7).DefaultCellStyle.Format = "$" & "######.00"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "$" & "######.00"

        'Damos los TxT formato al Importe, Total y Faltante.
        Dim Importe, Total, Faltante As Decimal
        Me.TextBox4.Text = Format(Importe, "#,###,##0.00")
        Me.TextBox4.Text = Format(Total, "#,###,##0.00")
        Me.TextBox4.Text = Format(Faltante, "#,###,##0.00")

        'Determina que separacion decimal usa el sistema.   
        Dim SepDecimal As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        'Cambiamos la separacion decimal por defecto del sistema, por la misma que utilizo en la base de datos (de coma a punto).
        Dim CambioDecimal As New Globalization.CultureInfo("es-ES")
        CambioDecimal.NumberFormat.CurrencyDecimalSeparator = "."
        CambioDecimal.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = CambioDecimal
    End Sub

    Sub ListaClientesACombo(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Metodo para llenar el Combo1 con el nombre de los clientes.
        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            ComboBox1.Items.Add(MiDetalle.Nombre)
        Next
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Cambiamos la coma por un punto en la temática.
        If e.KeyChar = "," Then e.KeyChar = "."

        'Evitamos espacios en la temática.
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Botón Alta de Agenda.

        'Validación para evitar numeros negativos.
        If Val(TextBox4.Text) < 0 Or Val(TextBox6.Text) < 0 Or Val(TextBox7.Text) < 0 Then
            MsgBox("No se permiten numeros negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox4.Text) = False Or IsNumeric(TextBox6.Text) = False Or IsNumeric(TextBox7.Text) = False Then
            MsgBox("La seña debe ser un dato numerico.", vbCritical, "Error")
            Exit Sub
        End If

        'Paso a la función Alta Agenda, los parámetros de mi objeto segun lo completado en los Textbox.
        Dim AgendaNegocio As New CapaDeNegocios.AgendaNegocios
        Dim AgendaEntidad As New CapaDeEntidades.AgendaEntidades

        AgendaEntidad.IdAgenda = TextBox1.Text
        AgendaEntidad.NombreCliente = ComboBox1.Text
        AgendaEntidad.Tematica = TextBox2.Text
        AgendaEntidad.FechaEntrega = DateTimePicker1.Text
        AgendaEntidad.Pedido = TextBox3.Text
        AgendaEntidad.Total = CDec(TextBox6.Text)
        AgendaEntidad.Importe = CDec(TextBox4.Text)
        AgendaEntidad.Faltante = CDec(TextBox7.Text)
        AgendaEntidad.Comentarios = TextBox5.Text

        Dim Resultado As Boolean
        Resultado = AgendaNegocio.AltaAgenda(AgendaEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El pedido se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxtAgenda()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtAgenda()
            Exit Sub
        End If
    End Sub


    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de la Agenda (TextBox1).
        Dim IDAgendaNegocios As New CapaDeNegocios.AgendaNegocios
        Dim IDAgendaEntidades As New List(Of CapaDeEntidades.AgendaEntidades)

        IDAgendaEntidades = IDAgendaNegocios.IDMaxAgenda()
        IdAgendaATxt(IDAgendaEntidades)
    End Sub

    Sub IdAgendaATxt(ByVal ListaDetalles As List(Of CapaDeEntidades.AgendaEntidades))
        'Metodo para asignar el ID al Textbox1.
        For Each MiDetalle As CapaDeEntidades.AgendaEntidades In ListaDetalles
            TextBox1.Text = MiDetalle.IdAgenda
        Next
    End Sub

    Sub LimpiarTxtAgenda()
        'Metodo para limpiar los Textboxs de Agenda.
        TextBox1.Text = ""
        ComboBox1.SelectedIndex = -1
        TextBox2.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        DateTimePicker1.Value = Date.Now
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Botón Modificar Agenda.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar numeros negativos.
        If Val(TextBox4.Text) < 0 Or Val(TextBox6.Text) < 0 Or Val(TextBox7.Text) < 0 Then
            MsgBox("No se permiten numeros negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox4.Text) = False Or IsNumeric(TextBox6.Text) = False Or IsNumeric(TextBox7.Text) = False Then
            MsgBox("La seña debe ser un dato numerico.", vbCritical, "Error")
            Exit Sub
        End If

        'Paso a la función Modificar Agenda, los parámetros de mi objeto segun lo completado en los Textbox.
        Dim AgendaNegocio As New CapaDeNegocios.AgendaNegocios
        Dim AgendaEntidad As New CapaDeEntidades.AgendaEntidades

        AgendaEntidad.IdAgenda = TextBox1.Text
        AgendaEntidad.NombreCliente = ComboBox1.Text
        AgendaEntidad.Tematica = TextBox2.Text
        AgendaEntidad.FechaEntrega = DateTimePicker1.Text
        AgendaEntidad.Pedido = TextBox3.Text
        AgendaEntidad.Total = CDec(TextBox6.Text)
        AgendaEntidad.Importe = CDec(TextBox4.Text)
        AgendaEntidad.Faltante = CDec(TextBox7.Text)
        AgendaEntidad.Comentarios = TextBox5.Text

        Dim Resultado As Boolean
        Resultado = AgendaNegocio.ModificarAgenda(AgendaEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("El pedido fue modificado correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxtAgenda()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtAgenda()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Botón Baja de Agenda.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar el pedido seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (RespuestaBaja = DialogResult.No) Then
            Exit Sub
        End If

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID de la Agenda seleccionada y con eso podemos dar de baja la misma.
        Dim AgendaNegocio As New CapaDeNegocios.AgendaNegocios
        Dim AgendaEntidad As New CapaDeEntidades.AgendaEntidades
        Dim Resultado As Boolean

        Dim Seleccionado As Integer = 0
        Seleccionado = DataGridView1.SelectedRows(0).Cells(0).Value()

        AgendaEntidad.IdAgenda = Seleccionado
        Resultado = AgendaNegocio.BajaAgenda(AgendaEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El pedido fue eliminado correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxtAgenda()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtAgenda()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Toda la Agenda.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio la grilla e introduzco la funcion para mostrar todos los pedidos de la Agenda.
        Me.DataGridView1.Rows.Clear()

        Dim AgendaNegocio As New CapaDeNegocios.AgendaNegocios
        Dim AgendaEntidad As New List(Of CapaDeEntidades.AgendaEntidades)

        AgendaEntidad = AgendaNegocio.BuscarTodasLasAgendas()
        LlenarGrilla(AgendaEntidad)

        'Limpiamos los Textbox y Combobox de Agenda.
        LimpiarTxtAgenda()

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


    Sub LlenarGrilla(ByVal ListaDetalles As List(Of CapaDeEntidades.AgendaEntidades))
        'Llenamos la grilla del DataGrid de la Agenda mediante este metodo.
        Dim Fila As Integer = 0

        For Each MiDetalle As CapaDeEntidades.AgendaEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(0).Value = MiDetalle.IdAgenda
            Me.DataGridView1.Rows(Fila).Cells(1).Value = MiDetalle.NombreCliente
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.Tematica
            Me.DataGridView1.Rows(Fila).Cells(3).Value = MiDetalle.FechaEntrega
            Me.DataGridView1.Rows(Fila).Cells(4).Value = MiDetalle.Pedido
            Me.DataGridView1.Rows(Fila).Cells(5).Value = MiDetalle.Total
            Me.DataGridView1.Rows(Fila).Cells(6).Value = MiDetalle.Importe
            Me.DataGridView1.Rows(Fila).Cells(7).Value = MiDetalle.Faltante
            Me.DataGridView1.Rows(Fila).Cells(8).Value = MiDetalle.Comentarios
            Fila += 1
        Next
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
        ComboBox1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        DateTimePicker1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(4).Value
        TextBox6.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(5).Value)
        TextBox4.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(6).Value)
        TextBox7.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(7).Value)
        TextBox5.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(8).Value
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'Cambiamos la coma por un punto en el TxT Seña y evitamos los espacios.
        If e.KeyChar = "," Then e.KeyChar = "."

        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'Cambiamos la coma por un punto en el TxT Total y evitamos los espacios.
        If e.KeyChar = "," Then e.KeyChar = "."

        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        'Estructuramos el TxT6, indicando que no puede comenzar con cero. A su vez, cada vez que se modifique, cambiara el TxT7 y el 4.
        If TextBox6.Text.StartsWith("0") Then
            TextBox6.Clear()
            MsgBox("El Total no puede ser cero.", vbCritical, "Error")
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            TextBox4.Clear()
            TextBox7.Clear()
            Exit Sub
        End If

        If TextBox6.Text <> "" Then
            TextBox7.Clear()
            TextBox7.Text = Val(TextBox6.Text) - Val(TextBox4.Text)
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        'Estructuramos el TxT4, para que al estar vacio se limpien los demas TxT (Total y Faltante) y para que al tener contenido, se calcule el Faltante a Abonar.
        If TextBox4.Text = "" Then
            TextBox6.Clear()
            TextBox7.Clear()
            Exit Sub
        End If

        If TextBox4.Text <> "" Then
            TextBox7.Clear()
            TextBox7.Text = Val(TextBox6.Text) - Val(TextBox4.Text)
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Botón Borrar Campos. El cual limpia todos los campos del formulario y deja el ID Agenda actualizado.
        LimpiarTxtAgenda()
        IDAutoincremental()
    End Sub
End Class