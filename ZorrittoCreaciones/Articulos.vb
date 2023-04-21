Public Class Articulos

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

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Private Sub Button1_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseMove
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button3_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseMove
        'Al pasar por el botón Baja, la fuente del mismo cambiara a blanco.
        Button3.ForeColor = Color.White
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        'Al dejar de pasar por el botón Baja, la fuente del mismo volvera a negro.
        Button3.ForeColor = Color.Black
    End Sub

    Private Sub Button4_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseMove
        'Al pasar por el botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button4.ForeColor = Color.White
    End Sub

    Private Sub Button4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        'Al dejar de pasar por el botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button4.ForeColor = Color.Black
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        'Al dejar de pasar por el botón Borrar Campos, la fuente del mismo volvera a negro.
        Button5.ForeColor = Color.Black
    End Sub

    Private Sub Button5_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseMove
        'Al pasar por el botón Borrar Campos, la fuente del mismo cambiara a blanco.
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

       
        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Creamos las columnas del Datagrid Artículos.
        Me.DataGridView1.Columns.Add("0", "Código Articulo")
        Me.DataGridView1.Columns.Add("1", "Nombre")
        Me.DataGridView1.Columns.Add("2", "Marca")
        Me.DataGridView1.Columns.Add("3", "Observaciones")

        'Le doy estilo deseado al Combo y dejo un elemento de inicio para evitar errores.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        'Botón para volver al formulario anterior y cerrar el actual. Además, se actualiza la hora y fecha.
        Me.Close()
        ActualizarLabel()
        AbrirFormEnPanel1(New Compras)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Botón para Alta de Artículos.
        ActualizarLabel()

        'Validación para evitar numeros negativos.
        If Val(TextBox1.Text) < 0 Then
            MsgBox("No se permiten códigos negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Determinar si el Código de Artículo se encuentra en uso o no, mediante un DataTable. Para ello,
        'Creo un DataTable y le asigno lo obtenido por la función BuscarCodigosArticulo. Luego paso el Código Artículo que se introduce
        'al dar de alta un nuevo Artículo, del TxT1 a "CodigoNuevo". Por ultimo, busco si existe o no, el contenido del TxT1
        'dentro de mi Tabla de SQL. Si existe, aparece un error, de lo contrario se puede seguir con el procedimiento.
        Dim Codigos As New DataTable
        Dim CodigoNegocios As New CapaDeNegocios.ArticuloNegocios
        Dim CodigoNuevo As String
        CodigoNuevo = TextBox1.Text

        Codigos = CodigoNegocios.BuscarCodigosArticulo()
        Dim ResultadoCodigo As DataRow() = Codigos.Select("CodigoArticulo= '" & CodigoNuevo & "'")

        If ResultadoCodigo.Length <> 0 Then
            MsgBox("El Codigo de Artículo fue asignado. Utilice otro por favor.", vbCritical, "Error")
            Exit Sub
        End If

        'De pasar el filtro anterior, nos aseguramos que no exista el CodigoArticulo dado de alta, evitando asi la duplicacion de la Primary Key.
        'Ahora, se va a establecer la lógica necesaria para que, de existir el CodigoArticulo que el usuario quiere ingresar, y el mismo
        'se encuentra con BajaLogica = True, como no podemos darlo de alta porque ya existe en la base, le pasamos el True a False, y 
        'hacemos un UPDATE del registro existente, dejandolo activo y evitando el duplicado de datos.

        Codigos = CodigoNegocios.BuscarCodigosArticuloParaModificacionDeBajaLogica()
        ResultadoCodigo = Codigos.Select("CodigoArticulo= '" & CodigoNuevo & "'")

        If ResultadoCodigo.Length = 1 Then
            Dim ArticuloNegocio1 As New CapaDeNegocios.ArticuloNegocios
            Dim ArticuloEntidades1 As New CapaDeEntidades.ArticulosEntidades

            ArticuloEntidades1.Nombre = TextBox2.Text
            ArticuloEntidades1.Marca = TextBox3.Text
            ArticuloEntidades1.Observaciones = TextBox4.Text
            Dim Resultado1 As Boolean
            Resultado1 = ArticuloNegocio1.ModificarArticuloConBajaTrue(ArticuloEntidades1, TextBox1.Text)

            MsgBox("El Artículo se dio de alta correctamente.", vbInformation, "Alta exitosa")
            Exit Sub
        End If


        'Paso los parámetros de mi objeto segun lo completado en los Textbox para el alta del Artículo.
        Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
        Dim ArticuloEntidades As New CapaDeEntidades.ArticulosEntidades

        ArticuloEntidades.CodigoArticulo = TextBox1.Text
        ArticuloEntidades.Nombre = TextBox2.Text
        ArticuloEntidades.Marca = TextBox3.Text
        ArticuloEntidades.Observaciones = TextBox4.Text

        Dim Resultado As Boolean
        Resultado = ArticuloNegocio.AltaArticulo(ArticuloEntidades)

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El Artículo se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxtCompras()
        Else
            MsgBox("El Artículo ya existe. Ingrese uno distinto.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Sub LimpiarTxtCompras()
        'Metodo para limpiar los Txt.
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Botón para Baja de Artículos.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar el Artículo seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (RespuestaBaja = DialogResult.No) Then
            Exit Sub
        End If

        ActualizarLabel()

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID del Artículo seleccionado y con eso podemos dar de baja el mismo.
        Dim Seleccionado As String
        Seleccionado = DataGridView1.SelectedRows(0).Cells(0).Value()

        Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
        Dim ArticuloEntidades As New CapaDeEntidades.ArticulosEntidades
        Dim Resultado As Boolean

        Resultado = ArticuloNegocio.BajaArticulo(Seleccionado)

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El Artículo fue eliminada correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxtCompras()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtCompras()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Botón Mostrar Todos los Articulos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio la grilla e introduzco la funcion para mostrar todos los pedidos de la Agenda.
        Me.DataGridView1.Rows.Clear()


        Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
        Dim ArticulosEntidades As New List(Of CapaDeEntidades.ArticulosEntidades)

        ArticulosEntidades = ArticuloNegocio.BuscarTodosLosArticulos()

        LlenarGrilla(ArticulosEntidades)

        'Limpiamos los Textbox y Combobox de Artículos.
        LimpiarTxtCompras()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView1.Rows(0).Selected = False
        End If
    End Sub

    Sub LlenarGrilla(ByVal ListaDetalles As List(Of CapaDeEntidades.ArticulosEntidades))
        'Llenamos la grilla del DataGrid Artículos mediante este metodo.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ArticulosEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(0).Value = MiDetalle.CodigoArticulo
            Me.DataGridView1.Rows(Fila).Cells(1).Value = MiDetalle.Nombre
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.Marca
            Me.DataGridView1.Rows(Fila).Cells(3).Value = MiDetalle.Observaciones
            Fila += 1
        Next
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        'Estructuramos el TxT5 para que al estar vacío traiga todos los Artículos. Caso contrario, filtre los mismos segun lo ingresado. 
        Me.DataGridView1.Rows.Clear()

        If TextBox5.Text = "" Then
            Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
            Dim ArticuloEntidad As New List(Of CapaDeEntidades.ArticulosEntidades)
            ArticuloEntidad = ArticuloNegocio.BuscarTodosLosArticulos()
            LlenarGrilla(ArticuloEntidad)
        End If

        If TextBox5.Text <> "" Then
            Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
            Dim ArticuloEntidad As New List(Of CapaDeEntidades.ArticulosEntidades)
            ArticuloEntidad = ArticuloNegocio.BuscarArticulosFiltrados(ComboBox1.Text, TextBox5.Text)
            LlenarGrilla(ArticuloEntidad)
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Usamos el evento para que al seleccionar una fila del DataGrid Artículos, los Txt tomen los valores de dicha fila.
        Dim NumeroDeFilaSeleccionada As Integer
        Dim ValidacionCeldaVacia As String

        'Condición para que al pulsar el DataGrid sin ningun dato cargado, evitemos errores y finalice el proceso.
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
        TextBox3.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Botón Borrar Campos, el cual vacia los TxT del formulario y actualiza la hora y fecha.
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ActualizarLabel()
    End Sub
End Class