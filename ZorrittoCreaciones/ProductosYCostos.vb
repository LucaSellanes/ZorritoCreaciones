Public Class ProductosYCostos

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

    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        'Al pasar por el Botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el Botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub ProductosYCostos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Estilo al Combo del filtro.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Botón Mostrar Todos.

        'Vaciamos el DataSource y lo refrescamos.
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        Dim ProductosYCostosNegocios As New CapaDeNegocios.ProductosYCostosNegocios
        Me.DataGridView1.DataSource = ProductosYCostosNegocios.BuscarProductosYCostos()

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView1.Rows(0).Selected = False
            'Formato decimales para Datagrid.
            DataGridView1.Columns(2).DefaultCellStyle.Format = "$" & "######.00"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'Estructuramos el TxT1 para que al estar vacío traiga todos los Productos y Costos. Caso contrario, filtre los mismos segun el parametro ingresado. 
        If TextBox1.Text <> "" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            Dim ProductosYCostosNegocios As New CapaDeNegocios.ProductosYCostosNegocios

            Me.DataGridView1.DataSource = ProductosYCostosNegocios.BuscarProductosYCostosFiltrado(ComboBox1.Text, TextBox1.Text)
            'Formato decimales para Datagrid.
            DataGridView1.Columns(2).DefaultCellStyle.Format = "$" & "######.00"
        End If

        If TextBox1.Text = "" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            Dim ProductosYCostosNegocios As New CapaDeNegocios.ProductosYCostosNegocios
            Me.DataGridView1.DataSource = ProductosYCostosNegocios.BuscarProductosYCostos()
            'Formato decimales para Datagrid.
            DataGridView1.Columns(2).DefaultCellStyle.Format = "$" & "######.00"
        End If
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        'Botón para volver al formulario anterior y cerrar el actual. Además, se actualiza la hora y fecha.
        Me.Close()
        ActualizarLabel()
        AbrirFormEnPanel1(New Productos)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error error y finalice el proceso.
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If
    End Sub
End Class