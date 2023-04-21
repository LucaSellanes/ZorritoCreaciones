Public Class Financiero

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
        'Al pasar por el botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button7_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseMove
        'Al pasar por el botón Mostrar Todos, la fuente del mismo cambiara a blanco.
        Button7.ForeColor = Color.White
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        'Al dejar de pasar por el botón Mostrar Todos, la fuente del mismo volvera a negro.
        Button7.ForeColor = Color.Black
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Private Sub Financiero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Doy formato a los Combos y establezco un elemento de inicio preestablecido para prevenir errores.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox2.DropDownStyle = 2

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Oculto los Labels que se usan de pasaje para calcular el Saldo Final.
        Label22.Visible = False
        Label33.Visible = False

        'Establezco los labels de totales en cero.
        Label2.Text = "0"
        Label3.Text = "0"

        'Si los DataGrid estan vacíos, los labels pasan a cero.
        If DataGridView1.RowCount = 0 Then
            Label2.Text = "0"
        End If
        If DataGridView2.RowCount = 0 Then
            Label3.Text = "0"
        End If

        'Doy formato predeterminado a los RadioButton.
        RadioButton1.Checked = True
        RadioButton2.Checked = True
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'Estructuramos el TxT1 para que al estar vacío traiga todas las Compras. Caso contrario, filtre las mismas segun lo ingresado. 
        If TextBox1.Text <> "" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
            Me.DataGridView1.DataSource = FinancieroNegocio.BuscarComprasFiltradas(ComboBox1.Text, TextBox1.Text)
        End If

        If TextBox1.Text = "" Then
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()
            Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
            Me.DataGridView1.DataSource = FinancieroNegocio.BuscarCompras()
        End If

        'Cambiamos los encabezados de las columnas de ambos datagrid. Esto se hace ya que al traer directamente un DataTable de SQL, nos trae por defecto, los nombres de las columnas.
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Fecha"
            .Columns(1).HeaderCell.Value = "Codigo Articulo"
            .Columns(2).HeaderCell.Value = "Nombre Articulo"
            .Columns(3).HeaderCell.Value = "Importe"
        End With

        If DataGridView1.RowCount > 0 Then
            'Calcular Total del Datagrid1 (Compras)
            Dim Total As Decimal = 0
            Dim cont As Integer = 0
            Dim Col As Integer = Me.DataGridView1.CurrentCell.ColumnIndex

            For Each Row As DataGridViewRow In Me.DataGridView1.Rows
                Total += Val(Row.Cells(3).Value)
            Next
            Label2.Text = Total
            Convert.ToDecimal(Label2.Text)
            'Formato decimales para Datagrid.
            DataGridView1.Columns(3).DefaultCellStyle.Format = "$" & "######.00"
        End If

        If DataGridView1.RowCount = 0 Then
            Label2.Text = "0"
        End If
        If DataGridView2.RowCount = 0 Then
            Label3.Text = "0"
        End If


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Todos en Compras.

        'Vaciamos el DataSource del DataGrid y lo refrescamos para prevenir errores en el proceso.
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
        Me.DataGridView1.DataSource = FinancieroNegocio.BuscarCompras()

        'Cambiamos los encabezados de las columnas de ambos datagrid. Esto se hace ya que al traer directamente un DataTable de SQL, nos trae por defecto, los nombres de las columnas.
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Fecha"
            .Columns(1).HeaderCell.Value = "Codigo Articulo"
            .Columns(2).HeaderCell.Value = "Nombre Articulo"
            .Columns(3).HeaderCell.Value = "Importe"
        End With

        'Formato decimales para Datagrid.
        DataGridView1.Columns(3).DefaultCellStyle.Format = "$" & "######.00"


        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error y salgamos del proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
            Exit Sub
        End If

        'Calcular Total del Datagrid1 (Compras)
        Dim Total As Decimal = 0
        Dim cont As Integer = 0
        Dim Col As Integer = Me.DataGridView1.CurrentCell.ColumnIndex

        For Each Row As DataGridViewRow In Me.DataGridView1.Rows
            Total += Val(Row.Cells(3).Value)
        Next

        'Doy formato al Label2 de decimal.
        Label2.Text = Total
        Convert.ToDecimal(Label2.Text)

        'Si los DataGrids estan vacíos, los Labels pasan a cero.
        If DataGridView1.RowCount = 0 Then
            Label2.Text = "0"
        End If
        If DataGridView2.RowCount = 0 Then
            Label3.Text = "0"
        End If

        'Evitamos que se autoseleccione una fila al cargar el Datagrid.
        Me.DataGridView1.Rows(0).Selected = False
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        'Estructuramos el TxT2 para que al estar vacío traiga todas las ventas. Caso contrario, filtre las mismas segun lo ingresado. 

        Dim VariableFiltro As String = ""

        If TextBox2.Text <> "" Then
            If ComboBox2.Text = "N° Detalle Venta" Then
                VariableFiltro = "IdVenta"
            End If

            If ComboBox2.Text = "Nombre Cliente" Then
                VariableFiltro = "Nombre"
            End If

            DataGridView2.DataSource = Nothing
            DataGridView2.Refresh()

            Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
            Me.DataGridView2.DataSource = FinancieroNegocio.BuscarVentasFiltradas(VariableFiltro, TextBox2.Text)
        End If

        If TextBox2.Text = "" Then
            DataGridView2.DataSource = Nothing
            DataGridView2.Refresh()

            Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
            Me.DataGridView2.DataSource = FinancieroNegocio.BuscarVentas()
        End If

        'Cambiamos los encabezados de las columnas de ambos datagrid. Esto se hace ya que al traer directamente un DataTable de SQL, nos trae por defecto, los nombres de las columnas.
        With DataGridView2
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Fecha"
            .Columns(1).HeaderCell.Value = "N° Det. Venta"
            .Columns(2).HeaderCell.Value = "Nombre Cliente"
            .Columns(3).HeaderCell.Value = "Importe"
        End With

        If DataGridView2.RowCount > 0 Then
            'Calcular Total del Datagrid2 (Ventas)
            Dim Total2 As Decimal = 0
            Dim cont2 As Integer = 0
            Dim Col2 As Integer = Me.DataGridView2.CurrentCell.ColumnIndex

            For Each Row As DataGridViewRow In Me.DataGridView2.Rows
                Total2 += Val(Row.Cells(3).Value)
            Next
            Label3.Text = Total2
            Convert.ToDecimal(Label3.Text)
            'Formato decimales para Datagrid.
            DataGridView2.Columns(3).DefaultCellStyle.Format = "$" & "######.00"
        End If

        'Si los DataGrids estan vacíos, los Labels pasan a cero.
        If DataGridView1.RowCount = 0 Then
            Label2.Text = "0"
        End If
        If DataGridView2.RowCount = 0 Then
            Label3.Text = "0"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Botón Mostrar Todos en Ventas.

        'Vaciamos el DataSource del DataGrid y lo refrescamos para prevenir errores en el proceso.
        DataGridView2.DataSource = Nothing
        DataGridView2.Refresh()

        Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
        Me.DataGridView2.DataSource = FinancieroNegocio.BuscarVentas()

        'Cambiamos los encabezados de las columnas de ambos datagrid. Esto se hace ya que al traer directamente un DataTable de SQL, nos trae por defecto, los nombres de las columnas.
        With DataGridView2
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Fecha"
            .Columns(1).HeaderCell.Value = "N° Det. Venta"
            .Columns(2).HeaderCell.Value = "Nombre Cliente"
            .Columns(3).HeaderCell.Value = "Importe"
        End With

        'Formato decimales para Datagrid.
        DataGridView2.Columns(3).DefaultCellStyle.Format = "$" & "######.00"

        If DataGridView2.SelectedRows.Count = 0 Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
            Exit Sub
        End If

        'Calcular Total del Datagrid2 (Ventas)
        Dim Total2 As Decimal = 0
        Dim cont2 As Integer = 0 'PARA CONTADOR DE PARTIDAS
        Dim Col2 As Integer = Me.DataGridView2.CurrentCell.ColumnIndex

        For Each Row As DataGridViewRow In Me.DataGridView2.Rows
            Total2 += Val(Row.Cells(3).Value)
        Next

        'Doy formato al Label3 de decimal.
        Label3.Text = Total2
        Convert.ToDecimal(Label3.Text)

        'Si los DataGrids estan vacíos, los Labels pasan a cero.
        If DataGridView1.RowCount = 0 Then
            Label2.Text = "0"
        End If
        If DataGridView2.RowCount = 0 Then
            Label3.Text = "0"
        End If
        'Evitamos que se autoseleccione una fila al cargar el Datagrid.
        Me.DataGridView2.Rows(0).Selected = False
    End Sub

    Private Sub Label3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.TextChanged
        'Al cambiar el valor del Label3(Total Ventas), se calcula automáticamente el Saldo Final.
        Dim Total As Decimal = 0
        Dim cont As Integer = 0

        'Sumatoria del Total, a partir de lo que cargue el DataGrid.
        For Each Row As DataGridViewRow In Me.DataGridView1.Rows
            Total += Val(Row.Cells(3).Value)
            Label22.Text = Total
        Next

        'Calcular Total del Datagrid2 (Ventas)
        Dim Total22 As Decimal = 0
        Dim cont2 As Integer = 0 'PARA CONTADOR DE PARTIDAS


        For Each Row As DataGridViewRow In Me.DataGridView2.Rows
            Total22 += Val(Row.Cells(3).Value)
            Label33.Text = Total22
        Next

        'Calculamos SaldoFinal a partir de los sub totales.
        Dim SaldoFinal As Decimal = (Val(Total) + Val(Total22))

        'Damos formato decimal.
        Label9.Text = SaldoFinal.ToString
        Convert.ToDecimal(Label9.Text)
    End Sub

    Private Sub Label2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.TextChanged
        'Al cambiar el valor del Label2(Total Compras), se calcula automáticamente el Saldo Final.
        Dim Total As Decimal = 0
        Dim cont As Integer = 0

        For Each Row As DataGridViewRow In Me.DataGridView1.Rows
            Total += Val(Row.Cells(3).Value)
            Label22.Text = Total
        Next

        'Calcular Total del Datagrid2 (Ventas)
        Dim Total22 As Decimal = 0
        Dim cont2 As Integer = 0 'PARA CONTADOR DE PARTIDAS


        For Each Row As DataGridViewRow In Me.DataGridView2.Rows
            Total22 += Val(Row.Cells(3).Value)
            Label33.Text = Total22
        Next

        'Calculamos el Saldo Final
        Dim SaldoFinal As Decimal = (Val(Total) + Val(Total22))

        'Le aplicamos formato decimal.
        Label9.Text = SaldoFinal.ToString
        Convert.ToDecimal(Label9.Text)
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        'Si el filtro de Compras por el cual se va a buscar es por fecha, entonces se desactiva el cuadro de texto para el filtro, y se permite usar solamente los RadioButtons.
        If ComboBox1.Text = "Fecha" Then
            TextBox1.Enabled = False
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        End If

        'Si el filtro es disinto a fecha, se activa el cuadro de texto para el filtro, permitiendo su uso.
        If ComboBox1.Text <> "Fecha" Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            TextBox1.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        'Si el filtro de Ventas por el cual se va a buscar es por fecha, entonces se desactiva el cuadro de texto para el filtro, y se permite usar solamente los RadioButtons.
        If ComboBox2.Text = "Fecha" Then
            TextBox2.Enabled = False
            RadioButton4.Checked = True
            RadioButton3.Checked = False
        End If

        'Si el filtro es disinto a fecha, se activa el cuadro de texto para el filtro, permitiendo su uso.
        If ComboBox2.Text <> "Fecha" Then
            RadioButton4.Checked = False
            RadioButton3.Checked = True
            TextBox2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        'Si el RadioButton1 se activa, el 2 se desactiva.
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        'Si el RadioButton2 se activa, el 1 se desactiva.
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        'Si el RadioButton3 se activa, el 4 se desactiva.
        If RadioButton3.Checked = True Then
            RadioButton4.Checked = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        'Si el RadioButton4 se activa, el 3 se desactiva.
        If RadioButton4.Checked = True Then
            RadioButton3.Checked = False
        End If
    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged
        'Busqueda por fecha en tiempo de ejecución al seleccionar un rango de fechas en los calendarios.
        If ComboBox2.Text = "Fecha" Then
            If RadioButton4.Checked = True Then

                DataGridView2.DataSource = Nothing
                DataGridView2.Refresh()
                Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
                Me.DataGridView2.DataSource = FinancieroNegocio.BuscarVentasPorFecha(CDate(DateTimePicker4.Text), CDate(DateTimePicker1.Text))
                'Formato decimales para Datagrid.
                DataGridView2.Columns(3).DefaultCellStyle.Format = "$" & "######.00"
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        'Busqueda por fecha en tiempo de ejecución al seleccionar un rango de fechas en los calendarios.
        If ComboBox2.Text = "Fecha" Then

            If RadioButton4.Checked = True Then
                DataGridView2.DataSource = Nothing
                DataGridView2.Refresh()
                Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
                Me.DataGridView2.DataSource = FinancieroNegocio.BuscarVentasPorFecha(CDate(DateTimePicker4.Text), CDate(DateTimePicker1.Text))
                'Formato decimales para Datagrid.
                DataGridView2.Columns(3).DefaultCellStyle.Format = "$" & "######.00"
            End If
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        'Busqueda por fecha en tiempo de ejecución al seleccionar un rango de fechas en los calendarios.
        If ComboBox1.Text = "Fecha" Then

            If RadioButton2.Checked = True Then
                DataGridView1.DataSource = Nothing
                DataGridView1.Refresh()
                Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
                Me.DataGridView1.DataSource = FinancieroNegocio.BuscarVentasPorFecha(CDate(DateTimePicker2.Text), CDate(DateTimePicker3.Text))
                'Formato decimales para Datagrid.
                DataGridView1.Columns(3).DefaultCellStyle.Format = "$" & "######.00"
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error y salgamos del proceso.
        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error y salgamos del proceso.
        If DataGridView2.RowCount = 0 Then
            Exit Sub
        End If
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        'Busqueda por fecha en tiempo de ejecución al seleccionar un rango de fechas en los calendarios.
        If ComboBox1.Text = "Fecha" Then
            If RadioButton2.Checked = True Then
                DataGridView1.DataSource = Nothing
                DataGridView1.Refresh()
                Dim FinancieroNegocio As New CapaDeNegocios.FinancieroNegocios
                Me.DataGridView1.DataSource = FinancieroNegocio.BuscarVentasPorFecha(CDate(DateTimePicker2.Text), CDate(DateTimePicker3.Text))
                'Formato decimales para Datagrid.
                DataGridView1.Columns(3).DefaultCellStyle.Format = "$" & "######.00"
            End If
        End If
    End Sub
End Class