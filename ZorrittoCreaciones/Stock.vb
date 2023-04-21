Public Class Stock

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

    Private Sub Button7_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseMove
        'Al pasar por el Botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button7.ForeColor = Color.White
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        'Al dejar de pasar por el Botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button7.ForeColor = Color.Black
    End Sub

    Private Sub Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Estilo al Combo del filtro.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Se incrementa automáticamente el ID principal.
        ActualizarLabel()

        'Genero un bucle para mostrar el Stock Actual sumando y restando los Ingresos y Egresos de cada fila de mi DataGrid entre si.
        Dim Fila As Integer = 0

        For Each Row As DataGridViewRow In Me.DataGridView1.Rows
            Me.DataGridView1.Rows(Fila).Cells(5).Value = DataGridView1.Rows(Fila).Cells(3).Value - DataGridView1.Rows(Fila).Cells(4).Value
            Fila += 1
        Next
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        'Botón para volver al formulario anterior y cerrar el actual. Además, se actualiza la hora y fecha.
        Me.Close()
        ActualizarLabel()
        AbrirFormEnPanel1(New Compras)
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'Evento para modificar color de fuente y fondo de la columna StockActual, segun determinados valores.

        If Me.DataGridView1.Columns(e.ColumnIndex).Name = "StockActual" Then

            If (Convert.ToInt32(e.Value) = Nothing) Then
                Exit Sub
            End If

            If (Convert.ToInt32(e.Value) <= 10) Then
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.BackColor = Color.Red
            End If

            If (Convert.ToInt32(e.Value) > 10) And (Convert.ToInt32(e.Value) <= 30) Then
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.BackColor = Color.Yellow
            End If

            If (Convert.ToInt32(e.Value) > 30) Then
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.BackColor = Color.YellowGreen
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'Estructuramos el TxT5 para que al estar vacío traiga todo el Stock. Caso contrario, filtre el mismo segun el parametro ingresado. 
        If TextBox1.Text <> "" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            Dim StockNegocio As New CapaDeNegocios.StockNegocio
            Dim StockEntidad As New List(Of CapaDeEntidades.StockEntidades)

            Me.DataGridView1.DataSource = StockNegocio.BuscarStockFiltrado(ComboBox1.Text, TextBox1.Text)
        End If

        If TextBox1.Text = "" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            Dim StockNegocio As New CapaDeNegocios.StockNegocio
            Dim StockEntidad As New List(Of CapaDeEntidades.StockEntidades)
            Me.DataGridView1.DataSource = StockNegocio.BuscarStock()
        End If

        'Genero un bucle para mostrar el Stock Actual sumando y restando los Ingresos y Egresos entre si, de cada fila de mi DataGrid.
        Dim Fila As Integer = 0
        For Each Row As DataGridViewRow In Me.DataGridView1.Rows
            Me.DataGridView1.Rows(Fila).Cells(5).Value = DataGridView1.Rows(Fila).Cells(3).Value - DataGridView1.Rows(Fila).Cells(4).Value
            Fila += 1
        Next

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Todos.

        'Vacio el DataSource del DataGrid.
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        Dim TodoStock As String = "CodigoArticulo"

        Dim StockNegocios As New CapaDeNegocios.StockNegocio
        Me.DataGridView1.DataSource = StockNegocios.BuscarStock()

        'Genero un bucle para mostrar el Stock Actual sumando y restando los Ingresos y Egresos entre si, de cada fila de mi DataGrid.
        Dim Fila As Integer = 0

        For Each Row As DataGridViewRow In Me.DataGridView1.Rows
            Me.DataGridView1.Rows(Fila).Cells(5).Value = DataGridView1.Rows(Fila).Cells(3).Value - DataGridView1.Rows(Fila).Cells(4).Value
            Fila += 1
        Next

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row2 As DataGridViewRow = DataGridView1.CurrentRow
        If Row2 Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView1.Rows(0).Selected = False
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Condición para que al pulsar el DataGrid sin ningun dato cargado, no se produzcan errores y finalice el proceso.
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If
    End Sub
End Class