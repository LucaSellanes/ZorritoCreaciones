Public Class DetalleVentas

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
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button2_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseMove
        'Al pasar por el botón Modificar, la fuente del mismo cambiara a blanco.
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        'Al dejar de pasar por el botón Modificar, la fuente del mismo volvera a negro.
        Button2.ForeColor = Color.Black
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

    Private Sub Button5_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseMove
        'Al pasar por el botón Borrar Campos, la fuente del mismo cambiara a blanco.
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        'Al dejar de pasar por el botón Borrar Campos, la fuente del mismo volvera a negro.
        Button5.ForeColor = Color.Black
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Botón para Alta de Detalle Ventas.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Validación para evitar campos vacíos.
        If ComboBox3.Text = "" Or ComboBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        Dim DetalleNegocio As New CapaDeNegocios.DetalleVentasNegocios
        Dim DetalleEntidad As New CapaDeEntidades.DetalleVentasEntidades

        'Paso a la función Alta Detalle Venta, los parámetros de mi objeto segun lo completado en los Textbox.
        DetalleEntidad.IdDetalleVentas = TextBox1.Text
        DetalleEntidad.IdVenta = ComboBox3.Text
        DetalleEntidad.IdProducto = TextBox7.Text
        DetalleEntidad.Cantidad = Val(ComboBox2.Text)
        DetalleEntidad.Total = CDec(TextBox3.Text)

        Dim Resultado As Boolean
        Resultado = DetalleNegocio.AltaDetalleVenta(DetalleEntidad)

        'Comienzo del egreso de Stock por Venta, para restar la cantidad vendida al Stock Actual.
        Dim StockNegocios As New CapaDeNegocios.StockNegocio
        Dim StockEntidades As New CapaDeEntidades.StockEntidades

        Dim Resultado1 As Boolean
        Resultado1 = StockNegocios.AltaDetalleVentaStock(ComboBox2.Text, TextBox1.Text, StockEntidades)
        'Final del egreso de Stock por Venta.

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El Detalle de Venta se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxTDetalleVentas()
        Else
            MsgBox("El Detalle de Venta ya existe. Ingrese uno distinto.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de los Detalles Ventas (TextBox1).
        Dim IDDetalleNegocios As New CapaDeNegocios.DetalleVentasNegocios
        Dim IDDetalleEntidades As New List(Of CapaDeEntidades.DetalleVentasEntidades)

        IDDetalleEntidades = IDDetalleNegocios.IDMaxDetalleVenta()
        IDDetalleATxT(IDDetalleEntidades)
    End Sub

    Sub IDDetalleATxT(ByVal ListaDetalles As List(Of CapaDeEntidades.DetalleVentasEntidades))
        'Asignamos el ID Detalle Ventas, al TxT1.
        For Each MiDetalle As CapaDeEntidades.DetalleVentasEntidades In ListaDetalles
            TextBox1.Text = MiDetalle.IdDetalleVentas
        Next
    End Sub

    Sub LimpiarTxTDetalleVentas()
        'Metodo para limpiar Textbox de Detalle Ventas y establecer el cursor en el Combo3 ("N° de Venta").
        ComboBox3.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox3.Text = ""
        ComboBox3.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Botón Modificar en DetalleVentas.

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
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción pulsando la flecha a la izquierda del comienzo cada fila", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If ComboBox3.Text = "" Or ComboBox2.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Comienzo la parte 1 de la modificación del Egreso de Stock en el Detalle Ventas. 
        'Genero el UPDATE en SQL para poder restar la cantidad que ya tiene ese registro del Stock.
        Dim StockNegocios1 As New CapaDeNegocios.StockNegocio
        Dim StockEntidades1 As New CapaDeEntidades.StockEntidades

        Dim CantidadAModificar As Integer = 0
        CantidadAModificar = DataGridView1.SelectedRows(0).Cells(3).Value()

        Dim IdDetalleVenta As Integer = 0
        IdDetalleVenta = DataGridView1.SelectedRows(0).Cells(0).Value()

        Dim Resultado1 As Boolean
        Resultado1 = StockNegocios1.ModificarStockDetalleVentaParte1(CantidadAModificar, IdDetalleVenta)
        'Final de la parte 1 de la modificación del Egreso de Stock por Venta.

        Dim DetalleNegocio As New CapaDeNegocios.DetalleVentasNegocios
        Dim DetalleEntidad As New CapaDeEntidades.DetalleVentasEntidades

        'Paso a la función Modificar Detalle Venta, los parámetros de mi objeto segun lo completado en los Textbox.
        DetalleEntidad.IdDetalleVentas = TextBox1.Text
        DetalleEntidad.IdVenta = ComboBox3.Text
        DetalleEntidad.IdProducto = TextBox7.Text
        DetalleEntidad.Cantidad = ComboBox2.Text
        DetalleEntidad.Total = CDec(TextBox5.Text)

        Dim Resultado As Boolean
        Resultado = DetalleNegocio.ModificarDetalleVenta(DetalleEntidad)

        'Comienzo del egreso de Stock por Venta.
        Dim StockNegocios As New CapaDeNegocios.StockNegocio
        Dim StockEntidades As New CapaDeEntidades.StockEntidades

        Dim Resultado2 As Boolean
        Resultado2 = StockNegocios.AltaDetalleVentaStock(ComboBox2.Text, TextBox1.Text, StockEntidades)
        'Final del egreso de Stock por Venta.

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("El Detalle de Venta fue modificado correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxTDetalleVentas()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxTDetalleVentas()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Botón para Baja de DetalleVenta.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar el Detalle de Venta seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

        'Comienzo la parte 1 de la modificación del Egrsso de Stock en el Detalle Ventas. 
        'Genero el UPDATE en SQL para poder restar la cantidad que ya tiene ese registro del Stock.
        Dim StockNegocios1 As New CapaDeNegocios.StockNegocio
        Dim StockEntidades1 As New CapaDeEntidades.StockEntidades

        Dim CantidadAModificar As Integer = 0
        CantidadAModificar = DataGridView1.SelectedRows(0).Cells(3).Value()

        Dim IdDetalleVenta As Integer = 0
        IdDetalleVenta = DataGridView1.SelectedRows(0).Cells(0).Value()

        Dim Resultado1 As Boolean
        Resultado1 = StockNegocios1.ModificarStockDetalleVentaParte1(CantidadAModificar, IdDetalleVenta)
        'Final de la parte 1 de la modificación del Egreso de Stock por Venta.

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID del Detalle Venta seleccionado y con eso podemos dar de baja el mismo.
        Dim Seleccionado As Integer = 0
        Seleccionado = DataGridView1.SelectedRows(0).Cells(0).Value()

        Dim DetalleNegocio As New CapaDeNegocios.DetalleVentasNegocios
        Dim DetalleEntidad As New CapaDeEntidades.DetalleVentasEntidades
        Dim Resultado As Boolean

        DetalleEntidad.IdDetalleVentas = Seleccionado
        Resultado = DetalleNegocio.BajaDetalleVenta(DetalleEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El Detalle de Venta fue eliminado correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxTDetalleVentas()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxTDetalleVentas()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Botón Mostrar Todos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()
        TextBox3.Text = ""

        'Limpio la grilla e introduzco la funcion para traer todos los Detalle Ventas.
        Me.DataGridView1.Rows.Clear()

        Dim DetalleNegocio As New CapaDeNegocios.DetalleVentasNegocios
        Dim DetalleEntidad As New List(Of CapaDeEntidades.DetalleVentasEntidades)

        DetalleEntidad = DetalleNegocio.BuscarTodosLosDetalles(Val(TextBox7.Text))

        LlenarGrilla(DetalleEntidad)

        'Limpiamos los Textbox y Combobox de Detalle Ventas.
        LimpiarTxTDetalleVentas()

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

    Sub NombresDeProductosADataGrid(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Llenamos la grilla del DataGrid DetalleVentas con la lista de Productos.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.Nombre
            Fila += 1
        Next
    End Sub

    Sub LlenarGrilla(ByVal ListaDetalles As List(Of CapaDeEntidades.DetalleVentasEntidades))
        'Llenamos la grilla del DataGrid de Detalle Ventas.
        Dim Fila As Integer = 0

        For Each MiDetalle As CapaDeEntidades.DetalleVentasEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(0).Value = MiDetalle.IdDetalleVentas
            Me.DataGridView1.Rows(Fila).Cells(1).Value = MiDetalle.IdVenta
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.IdProducto
            Me.DataGridView1.Rows(Fila).Cells(3).Value = MiDetalle.Cantidad
            Me.DataGridView1.Rows(Fila).Cells(4).Value = MiDetalle.Total
            'Agregamos el Total en la última columna de manera manual, multiplicando Cantidad * Precio Unitario.
            DataGridView1.Rows(Fila).Cells.Item(5).Value = DataGridView1.Rows(Fila).Cells(4).Value * DataGridView1.Rows(Fila).Cells(3).Value
            Fila += 1
        Next
    End Sub

    Private Sub DetalleVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'El Combo2 por defecto se encuentra inhabilitado. Pero esto cambia, al tener valores seleccionados en el Combo1 y en el 3.
        ComboBox2.Enabled = False

        If ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
            ComboBox2.Enabled = True
        End If


        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Deshabilito los TxT correspondientes a los ID y el Precio Venta (Txt5).
        TextBox1.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True
        TextBox3.ReadOnly = True

        'Le doy estilo deseado al Combo del filtro y al de Cantidad.
        ComboBox4.DropDownStyle = 2
        ComboBox4.SelectedIndex = 0
        ComboBox2.DropDownStyle = 2

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Creamos las columnas del Datagrid Detalle Ventas.
        Me.DataGridView1.Columns.Add("0", "N° Detalle Venta")
        Me.DataGridView1.Columns.Add("1", "Venta")
        Me.DataGridView1.Columns.Add("2", "Producto")
        Me.DataGridView1.Columns.Add("3", "Cantidad")
        Me.DataGridView1.Columns.Add("4", "Precio Unitario")
        Me.DataGridView1.Columns.Add("5", "Total")

        'Le doy formato numerico y de moneda a las columnas de los Costos y el Precio.
        DataGridView1.Columns(4).DefaultCellStyle.Format = "$" & "######.00"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "$" & "######.00"

        'Cargamos el Combobox2 (Cantidad) con valores.
        For i = 1 To 200
            ComboBox2.Items.Add(i)
        Next

        'Asigno al Combo1 estilo y le paso los Nombres de los Productos con el Metodo ListaProductosACombo.
        Me.ComboBox1.Items.Clear()
        Dim combo1 As String
        combo1 = ComboBox1.Text
        ComboBox1.DropDownStyle = 2

        Dim ComboNegocios As New CapaDeNegocios.ProductoNegocio
        Dim ComboEntidades As New List(Of CapaDeEntidades.ProductoEntidades)

        ComboEntidades = ComboNegocios.ComboNombreProd()
        ListaProductosACombo(ComboEntidades)

        'Asigno al Combo3 estilo y le paso el N° de venta (ID) con el Metodo .
        Me.ComboBox3.Items.Clear()
        Dim combo3 As String
        combo3 = ComboBox3.Text
        ComboBox3.DropDownStyle = 2

        Dim ComboNegocios3 As New CapaDeNegocios.VentasNegocio
        Dim ComboEntidades3 As New List(Of CapaDeEntidades.VentasEntidades)

        ComboEntidades3 = ComboNegocios3.IDVentaSegunCombo
        IDVentaSegunVentas(ComboEntidades3)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
    End Sub

    Sub IDVentaSegunVentas(ByVal ListaDetalles As List(Of CapaDeEntidades.VentasEntidades))
        'Metodo para asignar al Combo3 el ID de la venta.
        For Each MiDetalle As CapaDeEntidades.VentasEntidades In ListaDetalles
            ComboBox3.Items.Add(MiDetalle.IdVenta)
        Next
    End Sub

    Sub ListaProductosACombo(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asigno al Combo1 el nombre del Producto.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            ComboBox1.Items.Add(MiDetalle.Nombre)
        Next
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        'Botón para volver al formulario anterior y cerrar el actual. Además, se actualiza la hora y fecha.
        Me.Close()
        ActualizarLabel()
        AbrirFormEnPanel1(New ventas)
    End Sub

    Private Sub ComboBox3_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectionChangeCommitted
        'Se completa el Txt6 con el nombre del Cliente correspondiente al que se establece en el Combo3.
        Dim IDClienteNegocios As New CapaDeNegocios.ClientesNegocio
        Dim IDClienteEntidades As New List(Of CapaDeEntidades.ClientesEntidades)

        IDClienteEntidades = IDClienteNegocios.NombreClienteSegunIdDelCliente(ComboBox3.Text)
        NombreClienteSegunCombo3(IDClienteEntidades)

        'Habilito la Cantidad, una vez que se complete el Producto y el N° de la venta.
        If ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
            ComboBox2.Enabled = True
        End If
    End Sub

    Sub NombreClienteSegunCombo3(ByVal ListaDetalles As List(Of CapaDeEntidades.ClientesEntidades))
        'Metodo para asignar al Txt6 el nombre del cliente al cual le corresponde la Venta al cambiar el Combo3.
        For Each MiDetalle As CapaDeEntidades.ClientesEntidades In ListaDetalles
            TextBox6.Text = MiDetalle.Nombre
        Next
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        'Esto actualiza el Precio Venta cada vez que desplegamos el Combo1 y su evento.
        TextBox5.Text = ""

        'Se completa el Txt7 con el ID correspondiente al nombre que se establece en el Combo1.
        Dim IDProdNegocios As New CapaDeNegocios.ProductoNegocio
        Dim IDProdEntidades As New List(Of CapaDeEntidades.ProductoEntidades)

        IDProdEntidades = IDProdNegocios.IDProductoSegunNombre(ComboBox1.Text)
        IDProdSegunNombre(IDProdEntidades)

        'El evento del Combo1, determina el Precio de Venta de la Composicion del Producto en el Txt5
        Dim IDMatPrimaNegocios2 As New CapaDeNegocios.ProductoNegocio
        Dim IDMatPrimaEntidades2 As New List(Of CapaDeEntidades.ProductoEntidades)

        IDMatPrimaEntidades2 = IDMatPrimaNegocios2.PrecioProdSegunNombre(TextBox7.Text)
        PrecioVentaProducto(IDMatPrimaEntidades2)

        'Habilito la Cantidad, una vez que se complete el Producto y el N° de la venta.
        If ComboBox1.SelectedIndex > -1 And ComboBox3.SelectedIndex > -1 Then
            ComboBox2.Enabled = True
        End If
    End Sub

    Sub PrecioVentaProducto(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asigno al TxT5 el Precio de Venta.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            TextBox5.Text = MiDetalle.PrecioVenta
        Next
    End Sub

    Sub IDProdSegunNombre(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asigno al TxT el ID Producto.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            TextBox7.Text = MiDetalle.IdProducto
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Botón Borrar Campos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio todos los campos del formulario y dejo el ID DetalleVenta actualizado.
        ComboBox2.Text = ""
        TextBox5.Text = ""
        TextBox3.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectionChangeCommitted
        'Al cambiar el valor del Combo2, actualizo el TxT3 con el Precio Venta Total, y le doy formato numerico.
        Dim PrecioVentaTotal As Decimal
        PrecioVentaTotal = CDec(TextBox5.Text) * Val(ComboBox2.SelectedItem)
        Me.TextBox3.Text = Format(PrecioVentaTotal, "#,###,##0.00")
    End Sub

    Sub NombreProductoSegunID(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asignamos al Combo1 el Nombre del Producto.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            ComboBox1.Text = MiDetalle.Nombre
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
        ComboBox3.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        TextBox7.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        ComboBox2.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
        TextBox5.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(4).Value)
        TextBox3.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(5).Value)

        'Se carga el TxT6 con el Nombre del Cliente segun el ID de la Venta relacionada al mismo.
        Dim IDProdNegocios As New CapaDeNegocios.ClientesNegocio
        Dim IDProdEntidades As New List(Of CapaDeEntidades.ClientesEntidades)

        IDProdEntidades = IDProdNegocios.NombreClienteSegunIdDelCliente(ComboBox3.Text)
        NombreClienteSegunCombo3(IDProdEntidades)

        'Se carga el Combo1 con el Nombre del Producto segun el ID del Producto respecto a la venta del mismo.
        Dim NombreProdNegocios As New CapaDeNegocios.ProductoNegocio
        Dim NombreProdEntidades As New List(Of CapaDeEntidades.ProductoEntidades)

        NombreProdEntidades = NombreProdNegocios.NombreProdSegunID(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value)
        NombreProductoSegunID(NombreProdEntidades)

        'Se completa el Txt7 con el ID correspondiente al nombre que se establece en el Combo1.
        Dim IDProdNegocios2 As New CapaDeNegocios.ProductoNegocio
        Dim IDProdEntidades2 As New List(Of CapaDeEntidades.ProductoEntidades)

        IDProdEntidades2 = IDProdNegocios2.IDProductoSegunNombre(ComboBox1.Text)
        IDProdSegunNombre(IDProdEntidades2)
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        'Estructuramos el TxT9 para que al estar vacío traiga todos los Clientes. Caso contrario, filtre los mismos segun el parametro ingresado. 
        Me.DataGridView1.Rows.Clear()

        'Determino los filtros segun lo seleccionado en el Combo4, y de esta manera evito que los nombres del Combo cambien.
        Dim VariableFiltro As String = ""

        If ComboBox4.Text = "N° de Venta" Then
            VariableFiltro = "IdVenta"

        End If

        If ComboBox4.Text = "Cantidad" Then
            VariableFiltro = "Cantidad"
        End If

        If ComboBox4.Text = "N° de Producto" Then
            VariableFiltro = "IdProducto"
        End If


        If TextBox9.Text = "" Then
            Dim DetalleNegocio As New CapaDeNegocios.DetalleVentasNegocios
            Dim DetallEntidad As New List(Of CapaDeEntidades.DetalleVentasEntidades)
            DetallEntidad = DetalleNegocio.BuscarDetallesFiltrados(VariableFiltro, TextBox9.Text)
            LlenarGrilla(DetallEntidad)
        End If

        If TextBox9.Text <> "" Then
            Dim DetalleNegocio As New CapaDeNegocios.DetalleVentasNegocios
            Dim DetallEntidad As New List(Of CapaDeEntidades.DetalleVentasEntidades)
            DetallEntidad = DetalleNegocio.BuscarDetallesFiltrados(VariableFiltro, TextBox9.Text)
            LlenarGrilla(DetallEntidad)
        End If
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        'Si al desplegar el Combo no hay informaci♀n cargada para mostrar, lo indica mediante un mensaje y termina el proceso.
        If ComboBox1.Items.Count <= 0 Then
            MsgBox("No hay ningún producto cargado aún.", vbCritical, "Error")
            ComboBox1.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub ComboBox3_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
        'Si al desplegar el Combo no hay informaci♀n cargada para mostrar, lo indica mediante un mensaje y termina el proceso.
        If ComboBox3.Items.Count <= 0 Then
            MsgBox("No hay ninguna venta cargada aún.", vbCritical, "Error")
            ComboBox3.Enabled = False
            Exit Sub
        End If
    End Sub
End Class