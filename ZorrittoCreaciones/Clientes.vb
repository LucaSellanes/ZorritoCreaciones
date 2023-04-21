Public Class Clientes

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
        'Al dejar de pasar por el botón Modificar, la fuente del mismo volvera a negro.
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

    Private Sub Button1_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseMove
        'Al pasar por el botón Agenda, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el botón Agenda, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10
        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Deshabilito el Txt del ID
        TextBox5.ReadOnly = True

        'Doy formato deseado al Combo para el filtrado.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Creamos las columnas del Datagrid Clientes.
        Me.DataGridView1.Columns.Add("0", "N° Cliente")
        Me.DataGridView1.Columns.Add("1", "Nombre")
        Me.DataGridView1.Columns.Add("2", "Apellido")
        Me.DataGridView1.Columns.Add("3", "Niño / Niña")
        Me.DataGridView1.Columns.Add("4", "Fecha Cumpleaños")
        Me.DataGridView1.Columns.Add("5", "Años Cumplidos")
        Me.DataGridView1.Columns.Add("6", "Localidad")
        Me.DataGridView1.Columns.Add("7", "Celular")
        Me.DataGridView1.Columns.Add("8", "Fecha Alta")
        Me.DataGridView1.Columns.Add("9", "Comentarios")
        Me.DataGridView1.Columns.Add("10", "Dias hasta Cumple")

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de los Clientes (TextBox5).
        Dim IDClienteNegocios As New CapaDeNegocios.ClientesNegocio
        Dim IDClienteEntidades As New List(Of CapaDeEntidades.ClientesEntidades)

        IDClienteEntidades = IDClienteNegocios.IDMaxCliente()
        IDClienteATxt(IDClienteEntidades)
    End Sub

    Sub IDClienteATxt(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Metodo para insertar el ID de los Clientes al TextBox5.
        Dim Fila As Integer = 0

        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            TextBox5.Text = MiDetalle.IdCliente
        Next
    End Sub

    Sub LlenarGrilla(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Llenamos la grilla del DataGrid Clientes mediante este metodo.
        Dim Fila As Integer = 0

        Dim FechaActual As String = DateTime.Now.ToString("MM dd")
        Dim DiasHastaCumple As Integer

        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(0).Value = MiDetalle.IdCliente
            Me.DataGridView1.Rows(Fila).Cells(1).Value = MiDetalle.Nombre
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.Apellido
            Me.DataGridView1.Rows(Fila).Cells(3).Value = MiDetalle.NombreNinoNina
            Me.DataGridView1.Rows(Fila).Cells(4).Value = MiDetalle.FechaCumpleanos
            Me.DataGridView1.Rows(Fila).Cells(5).Value = MiDetalle.AnosCumplidos
            Me.DataGridView1.Rows(Fila).Cells(6).Value = MiDetalle.Localidad
            Me.DataGridView1.Rows(Fila).Cells(7).Value = MiDetalle.Celular
            Me.DataGridView1.Rows(Fila).Cells(8).Value = MiDetalle.FechaAlta
            Me.DataGridView1.Rows(Fila).Cells(9).Value = MiDetalle.Comentarios

            Dim FechaCumple As String = Me.DataGridView1.Rows(Fila).Cells(4).Value

            FechaCumple = Format(Me.DataGridView1.Rows(Fila).Cells(4).Value, "MM dd")

            'Obtengo el día y mes en un entero, tanto de la fecha actual, como la del cumpleaños.
            Dim FechaActualDia As Integer = Microsoft.VisualBasic.Right(FechaActual, 2)
            Dim FechaActualMes As Integer = Microsoft.VisualBasic.Left(FechaActual, 2)
            Dim FechaCumpleDia As Integer = Microsoft.VisualBasic.Right(FechaCumple, 2)
            Dim FechaCumpleMes As Integer = Microsoft.VisualBasic.Left(FechaCumple, 2)

            Dim FechaActualTotal As Integer
            Dim FechaCumpleTotal As Integer


            'Defino la cantidad de días que tiene cada mes, teniendo en cuenta los años bisiestos.
            Dim Anio As Date = DateTime.Now.ToString
            Dim AnioActual As Integer = Year(Anio)

            Dim DiasAnio As Integer

            If AnioActual Mod 4 = 0 Then
                DiasAnio = 366
            Else
                DiasAnio = 365
            End If

            Dim Enero As Integer = 31
            Dim Febrero As Integer
            If AnioActual Mod 4 = 0 Then
                Febrero = 29
            Else
                Febrero = 28
            End If
            Dim Marzo As Integer = 31
            Dim Abril As Integer = 30
            Dim Mayo As Integer = 31
            Dim Junio As Integer = 30
            Dim Julio As Integer = 31
            Dim Agosto As Integer = 31
            Dim Septiembre As Integer = 30
            Dim Octubre As Integer = 31
            Dim Noviembre As Integer = 30
            Dim Diciembre As Integer = 31

            'Diferencia entre la fecha actual y la del cumpleaños segun el mes en el que estemos y la fecha de cumpleaños.
            If FechaActualMes = 1 Then
                FechaActualTotal = FechaActualDia
            End If

            If FechaCumpleMes = 1 Then
                FechaCumpleTotal = FechaCumpleMes
            End If

            If FechaActualMes = 2 Then
                FechaActualTotal = Enero + FechaActualDia
            End If

            If FechaCumpleMes = 2 Then
                FechaCumpleTotal = Enero + FechaCumpleDia
            End If

            If FechaActualMes = 3 Then
                FechaActualTotal = Enero + Febrero + FechaActualDia
            End If

            If FechaCumpleMes = 3 Then
                FechaCumpleTotal = Enero + Febrero + FechaCumpleDia
            End If

            If FechaActualMes = 4 Then
                FechaActualTotal = Enero + Febrero + Marzo + FechaActualDia
            End If

            If FechaCumpleMes = 4 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + FechaCumpleDia
            End If

            If FechaActualMes = 5 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + FechaActualDia
            End If

            If FechaCumpleMes = 5 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + FechaCumpleDia
            End If

            If FechaActualMes = 6 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + FechaActualDia
            End If

            If FechaCumpleMes = 6 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + FechaCumpleDia
            End If

            If FechaActualMes = 7 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + FechaActualDia
            End If

            If FechaCumpleMes = 7 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + FechaCumpleDia
            End If

            If FechaActualMes = 8 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + FechaActualDia
            End If

            If FechaCumpleMes = 8 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + FechaCumpleDia
            End If

            If FechaActualMes = 9 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + FechaActualDia
            End If

            If FechaCumpleMes = 9 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + FechaCumpleDia
            End If

            If FechaActualMes = 10 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + Septiembre + FechaActualDia
            End If

            If FechaCumpleMes = 10 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + Septiembre + FechaCumpleDia
            End If

            If FechaActualMes = 11 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + Septiembre + Octubre + FechaActualDia
            End If

            If FechaCumpleMes = 11 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + Septiembre + Octubre + FechaCumpleDia
            End If

            If FechaActualMes = 12 Then
                FechaActualTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + Septiembre + Octubre + Noviembre + FechaActualDia
            End If

            If FechaCumpleMes = 12 Then
                FechaCumpleTotal = Enero + Febrero + Marzo + Abril + Mayo + Junio + Julio + Agosto + Septiembre + Octubre + Noviembre + FechaCumpleDia
            End If

            'Calculo para definir la cantidad de dias entre una fecha y otra.
            If FechaActualTotal > FechaCumpleTotal Then
                DiasHastaCumple = (DiasAnio - FechaActualTotal) + FechaCumpleTotal
            Else
                DiasHastaCumple = FechaCumpleTotal - FechaActualTotal
            End If

            Me.DataGridView1.Rows(Fila).Cells(10).Value = DiasHastaCumple

            Fila += 1
        Next
    End Sub

    Sub LimpiarTxtClientes()
        'Metodo para limpiar Textbox de Clientes y establecer el cursor en el TxT1 ("Nombre").
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        DateTimePicker1.Value = Date.Now
        TextBox7.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Botón Alta de Clientes.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Validación para evitar numeros negativos.
        If Val(TextBox4.Text) < 0 Then
            MsgBox("No se permiten numeros negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación de un mínimo de caraceteres para el telefono.
        If TextBox7.Text.Trim.Length <= 7 Then
            MsgBox("El 'Telefono' debe tener al menos 7 cáracteres.", vbInformation, "Error")
            Exit Sub
        End If

        'Validación de un máximo de caraceteres para Años Cumplidos.
        If TextBox4.Text.Trim.Length > 3 Then
            MsgBox("Los 'Años Cumplidos' deben tener un máximo de 3 cáracteres.", vbInformation, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox4.Text) = False Or IsNumeric(TextBox7.Text) = False Then
            MsgBox("El 'Celular' y 'Años Cumplidos' deben ser numericos.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar datos numericos.
        If IsNumeric(TextBox1.Text) = True Or IsNumeric(TextBox2.Text) = True Or IsNumeric(TextBox3.Text) = True Then
            MsgBox("Los nombres y apellidos deben ser datos alfabeticos.", vbCritical, "Error")
            Exit Sub
        End If

        Dim ClienteNegocio As New CapaDeNegocios.ClientesNegocio
        Dim ClienteEntidad As New CapaDeEntidades.ClientesEntidades

        'Creo la fecha del día actual para establecer como fecha de alta del cliente.
        Dim FechaAlta As Date = DateTime.Now.ToString("dd-MM")


        'Paso a la función Alta Clientes, los parámetros de mi objeto segun lo completado en los Textbox.
        ClienteEntidad.IdCliente = TextBox5.Text
        ClienteEntidad.Nombre = TextBox1.Text
        ClienteEntidad.Apellido = TextBox2.Text
        ClienteEntidad.NombreNinoNina = TextBox3.Text
        ClienteEntidad.FechaCumpleanos = DateTimePicker1.Text
        ClienteEntidad.AnosCumplidos = TextBox4.Text
        ClienteEntidad.Localidad = TextBox6.Text
        ClienteEntidad.Celular = Convert.ToInt64(TextBox7.Text)
        ClienteEntidad.FechaAlta = FechaAlta
        ClienteEntidad.Comentarios = TextBox8.Text

        Dim Resultado As Boolean
        Resultado = ClienteNegocio.AltaCliente(ClienteEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El Cliente se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxtClientes()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtClientes()
            Exit Sub
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Botón Baja de Clientes.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar el Cliente seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (RespuestaBaja = DialogResult.No) Then
            Exit Sub
        End If

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID del Cliente seleccionado y con eso podemos dar de baja el mismo.
        Dim ClienteNegocio As New CapaDeNegocios.ClientesNegocio
        Dim ClienteEntidad As New CapaDeEntidades.ClientesEntidades
        Dim Resultado As Boolean

        Dim Seleccionado As Integer = 0
        Seleccionado = DataGridView1.SelectedRows(0).Cells(0).Value()

        ClienteEntidad.IdCliente = Seleccionado
        Resultado = ClienteNegocio.BajaCliente(ClienteEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El Cliente fue eliminado correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxtClientes()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtClientes()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Botón Modificar Clientes.

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
        If Val(TextBox4.Text) < 0 Then
            MsgBox("No se permiten numeros negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación de un mínimo de caraceteres para el telefono.
        If TextBox7.Text.Trim.Length <= 7 Then
            MsgBox("El 'Telefono' debe tener al menos 7 caracteres.", vbInformation, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox4.Text) = False Or IsNumeric(TextBox7.Text) = False Then
            MsgBox("El 'Celular' y 'Años Cumplidos' deben ser numericos.", vbCritical, "Error")
            Exit Sub
        End If

        Dim ClienteNegocio As New CapaDeNegocios.ClientesNegocio
        Dim ClienteEntidad As New CapaDeEntidades.ClientesEntidades

        'Creo la fecha del día actual para establecer como fecha de alta del cliente.
        Dim FechaAlta As Date = DateTime.Now.ToString("dd-MM")

        'Paso a la función Modificar Cliente, los parámetros de mi objeto segun lo completado en los Textbox.
        ClienteEntidad.IdCliente = TextBox5.Text
        ClienteEntidad.Nombre = TextBox1.Text
        ClienteEntidad.Apellido = TextBox2.Text
        ClienteEntidad.NombreNinoNina = TextBox3.Text
        ClienteEntidad.FechaCumpleanos = DateTimePicker1.Text
        ClienteEntidad.AnosCumplidos = TextBox4.Text
        ClienteEntidad.Localidad = TextBox6.Text
        ClienteEntidad.Celular = TextBox7.Text
        ClienteEntidad.FechaAlta = FechaAlta
        ClienteEntidad.Comentarios = TextBox8.Text

        Dim Resultado As Boolean
        Resultado = ClienteNegocio.ModificarCliente(ClienteEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("El Cliente fue modificado correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxtClientes()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtClientes()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Todos los Clientes.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio la grilla e introduzco la funcion para traer todos los Clientes.
        Me.DataGridView1.Rows.Clear()

        Dim ClienteNegocio As New CapaDeNegocios.ClientesNegocio
        Dim ClienteEntidad As New List(Of CapaDeEntidades.ClientesEntidades)

        ClienteEntidad = ClienteNegocio.BuscarTodosLosClientes()
        LlenarGrilla(ClienteEntidad)

        'Limpiamos los Textbox y Combobox de Clientes.
        LimpiarTxtClientes()

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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Boton Borrar Campos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio todos los campos del formulario y dejo el ID Cliente actualizado.
        TextBox1.Text = ""
        TextBox1.Focus()
        TextBox2.Text = ""
        TextBox6.Text = ""
        DateTimePicker1.Value = Date.Now
        TextBox7.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        'Estructuramos el TxT9 para que al estar vacío traiga todos los Clientes. Caso contrario, filtre los mismos segun lo ingresado. 
        Me.DataGridView1.Rows.Clear()

        Dim VariableFiltro As String = ""

        If TextBox5.Text = "" Then
            Dim ClienteNegocio As New CapaDeNegocios.ClientesNegocio
            Dim ClienteEntidad As New List(Of CapaDeEntidades.ClientesEntidades)
            ClienteEntidad = ClienteNegocio.BuscarTodosLosClientes()
            LlenarGrilla(ClienteEntidad)
        End If

        'Parametros de filtrado segun lo establecido en el Combobox1.
        If ComboBox1.Text = "Fecha de Cumpleaños" Then
            Exit Sub
        End If

        If TextBox5.Text <> "" Then
            Dim ClienteNegocio As New CapaDeNegocios.ClientesNegocio
            Dim ClienteEntidad As New List(Of CapaDeEntidades.ClientesEntidades)

            If ComboBox1.Text = "Nombre Niño/Niña" Then
                VariableFiltro = "Nombreninonina"
            End If

            If ComboBox1.Text = "Nombre" Then
                VariableFiltro = "Nombre"
            End If

            If ComboBox1.Text = "Apellido" Then
                VariableFiltro = "Apellido"
            End If

            If ComboBox1.Text = "Localidad" Then
                VariableFiltro = "Localidad"
            End If

            ClienteEntidad = ClienteNegocio.BuscarClientesFiltrados(VariableFiltro, TextBox9.Text)
            LlenarGrilla(ClienteEntidad)
        End If

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
        TextBox5.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
        DateTimePicker1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(4).Value
        TextBox4.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(7).Value
        TextBox8.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(9).Value
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'Evitamos los espacios en el TxT Años Cumplidos.
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        ''Evitamos los espacios en el TxT Celular.
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Boton Agenda.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Agenda" Then
                Form.Close()
            End If
        Next
        AbrirFormEnPanel1(New Agenda)
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'Le doy formato de fecha a las columnas del DataGrid que lo requieren.
        DataGridView1.Columns("4").DefaultCellStyle.Format = "dd/MM"
        DataGridView1.Columns("8").DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub
End Class