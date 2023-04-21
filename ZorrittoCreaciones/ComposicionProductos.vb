Public Class ComposicionProductos

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
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button7.ForeColor = Color.White
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
        Button7.ForeColor = Color.Black
    End Sub

    Private Sub Button8_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseMove
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button8.ForeColor = Color.White
    End Sub

    Private Sub Button8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
        Button8.ForeColor = Color.Black
    End Sub

    Private Sub Button9_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseMove
        'Al pasar por el botón Alta, la fuente del mismo cambiara a blanco.
        Button9.ForeColor = Color.White
    End Sub

    Private Sub Button9_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseLeave
        'Al dejar de pasar por el botón Alta, la fuente del mismo volvera a negro.
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

    Private Sub ComposicionProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'El Combo3 por defecto se encuentra inhabilitado. Pero esto cambia, al tener valores seleccionados en el Combo1 y en el 2.
        ComboBox3.Enabled = False

        If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 Then
            ComboBox3.Enabled = True
        End If

        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Deshabilito los Txt correspondientes a ID y a los costos.
        TextBox11.ReadOnly = True
        TextBox15.ReadOnly = True
        TextBox16.ReadOnly = True
        TextBox1.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox14.ReadOnly = True

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Creamos las columnas del Datagrid Composicion Productos.
        Me.DataGridView3.Columns.Add("0", "N° Comp. Producto")
        Me.DataGridView3.Columns.Add("1", "N° Producto")
        Me.DataGridView3.Columns.Add("2", "Nombre Producto")
        Me.DataGridView3.Columns.Add("3", "Cod. Artículo")
        Me.DataGridView3.Columns.Add("4", "Nombre Artículo")
        Me.DataGridView3.Columns.Add("5", "Cant. Materia Prima")
        Me.DataGridView3.Columns.Add("6", "Costo")
        Me.DataGridView3.Columns.Add("7", "Costo Total")
        Me.DataGridView3.Columns.Add("8", "Precio Venta")

        'Le doy formato numerico y de moneda a las columnas de los Costos y el Precio.
        DataGridView3.Columns(6).DefaultCellStyle.Format = "$" & "######.00"
        DataGridView3.Columns(7).DefaultCellStyle.Format = "$" & "######.00"
        DataGridView3.Columns(8).DefaultCellStyle.Format = "$" & "######.00"

        Dim CostoUnitario As Decimal
        Me.TextBox12.Text = Format(CostoUnitario, "#,###,##0.00")
        Dim CostoTotal As Decimal
        Me.TextBox1.Text = Format(CostoTotal, "#,###,##0.00")

        'Asigno al Combo1 estilo y le paso los Nombres de los Productos con el Metodo ListaProductosACombo.
        Me.ComboBox1.Items.Clear()
        Dim combo1 As String
        combo1 = ComboBox1.Text
        ComboBox1.DropDownStyle = 2

        Dim ComboNegocios As New CapaDeNegocios.ProductoNegocio
        Dim ComboEntidades As New List(Of CapaDeEntidades.ProductoEntidades)

        ComboEntidades = ComboNegocios.ComboNombreProd()
        ListaProductosACombo(ComboEntidades)

        'Le doy estilo y contenido al Combo Cantidad.
        ComboBox3.DropDownStyle = 2
        For i = 0 To 200
            ComboBox3.Items.Add(i)
        Next

        'Asigno al Combo2 estilo y le paso los Nombres de las Materias Primas con el Metodo ListaMatPrimaACombo.
        Me.ComboBox2.Items.Clear()
        Dim combo2 As String
        combo2 = ComboBox2.Text
        ComboBox2.DropDownStyle = 2

        Dim ComboNegocios2 As New CapaDeNegocios.ComprasNegocio
        Dim ComboEntidades2 As New List(Of CapaDeEntidades.ComprasEntidades)

        ComboEntidades2 = ComboNegocios2.ComboNombreArticulos()
        NombreArticulosACombo(ComboEntidades2)
    End Sub

    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de la ComposicionProducto (TxT).
        Dim IDNegociosCompoProd As New CapaDeNegocios.ComposicionProductoNegocio
        Dim IDEntidadesCompoProd As New List(Of CapaDeEntidades.ComposicionProductosEntidades)

        IDEntidadesCompoProd = IDNegociosCompoProd.IDCompoProd()
        AumentarIDCompoProd(IDEntidadesCompoProd)
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Sub LimpiarTxtCompoProd()
        'Limpio todos los campos del formulario y dejo el ID ComposicionProducto actualizado.
        TextBox12.Text = ""
        TextBox14.Text = ""
        TextBox1.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

    Sub NombreArticulosACombo(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Lleno el Combo2 con el Nombre de los Artículos.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            ComboBox2.Items.Add(MiDetalle.Nombre)
        Next
    End Sub

    Sub ListaProductosACombo(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Paso el contenido de la lista creada, al textbox6 para mostrar el ID autoincremental.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            ComboBox1.Items.Add(MiDetalle.Nombre)
        Next
    End Sub

    Sub AumentarIDCompoProd(ByVal ListaDetalles As List(Of CapaDeEntidades.ComposicionProductosEntidades))
        'Asigno al TxT11 el ID de la Composición Producto.
        For Each MiDetalle As CapaDeEntidades.ComposicionProductosEntidades In ListaDetalles
            TextBox11.Text = MiDetalle.IdComposicionProducto
        Next
    End Sub

    Sub LlenadoTextbox11(ByVal ListaDetalles As List(Of CapaDeEntidades.ComposicionProductosEntidades))
        'Creamos una lista para poder asignale el ID de la Composicion Producto, el cual luego pasar al Txt11 (ID).
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ComposicionProductosEntidades In ListaDetalles
            TextBox11.Text = MiDetalle.IdComposicionProducto
        Next
    End Sub

    Sub LlenarGrillaData3NombreProducto(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Llenamos la columa Nombre Producto con el nombre correspondiente.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            Me.DataGridView3.Rows(Fila).Cells(2).Value = MiDetalle.Nombre
            Fila += 1
        Next
    End Sub

    Sub LlenarGrillaData3(ByVal ListaDetalles As List(Of CapaDeEntidades.ComposicionProductosEntidades))
        'Usamos el evento para que al seleccionar una fila del DataGrid, los Txt tomen los valores de dicha fila.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ComposicionProductosEntidades In ListaDetalles
            Me.DataGridView3.Rows.Add()
            Me.DataGridView3.Rows(Fila).Cells(0).Value = MiDetalle.IdComposicionProducto
            Me.DataGridView3.Rows(Fila).Cells(1).Value = MiDetalle.IdProducto
            Me.DataGridView3.Rows(Fila).Cells(3).Value = MiDetalle.CodigoArticulo
            Me.DataGridView3.Rows(Fila).Cells(5).Value = MiDetalle.CantidadMateriaPrima
            Me.DataGridView3.Rows(Fila).Cells(6).Value = MiDetalle.Costo
            Me.DataGridView3.Rows(Fila).Cells(7).Value = MiDetalle.CostoTotal
            Fila += 1
        Next
    End Sub

    Sub LlenarGrillaDataConNombreArticulo(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Asignamos al DataGrid el Nombre del Artículo.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            Me.DataGridView3.Rows(Fila).Cells(4).Value = MiDetalle.Nombre
            Fila += 1
        Next
    End Sub

    Sub CodArticuloSegunNombre(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Asignamos al TxT16 el Código del Artículo.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            TextBox16.Text = MiDetalle.CodigoArticulo
        Next
    End Sub

    Sub IDProdSegunNombre(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asignamos al TxT15 el ID del Producto.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            TextBox15.Text = MiDetalle.IdProducto
        Next
    End Sub

    Sub CostoUnitATxt(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Asigno al TxT12 el Costo Unitario.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            Dim CostoUnitario As Decimal
            CostoUnitario = MiDetalle.PrecioUnitario
            TextBox12.Text = CostoUnitario
        Next
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectionChangeCommitted
        If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 Then
            ComboBox3.Enabled = True
        End If

        Me.TextBox1.Clear()

        'El evento del Combo2, nos determina el ID de la Compra en el Txt16
        Dim IDCompraNegocios As New CapaDeNegocios.ComprasNegocio
        Dim IDCompraEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        IDCompraEntidades = IDCompraNegocios.CodigoArticuloSegunNombre(ComboBox2.Text)
        CodArticuloSegunNombre(IDCompraEntidades)

        'Indico el Costo Unitario del producto seleccionado.
        Dim CostoNegocios As New CapaDeNegocios.ComprasNegocio
        Dim CostoEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        CostoEntidades = CostoNegocios.CostoCompoProd(TextBox16.Text)
        CostoUnitATxt(CostoEntidades)

        'Evitamos errores, estableciendo que si el Combo3 se encuentra vacio, no se ejecute el calculo del Costo Total.
        If ComboBox3.Text = "" Then
            Exit Sub
        Else
            'Calculo el Costo Total (Costo unitario x Cantidad Materia Prima)
            Dim CostoTotal As Decimal
            CostoTotal = CDec(TextBox12.Text) * CDec(ComboBox3.Text)
            Me.TextBox1.Text = Format(CostoTotal, "#,###,##0.00")
        End If
    End Sub

    Sub PrecioVentaSegunID(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asigno al TxT14 el Precio Venta.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            TextBox14.Text = MiDetalle.PrecioVenta
        Next
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Botón Alta ComposicionProductos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Validación para evitar campos vacíos.
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        Dim CompoProdNegocio As New CapaDeNegocios.ComposicionProductoNegocio
        Dim CompoProdEntidad As New CapaDeEntidades.ComposicionProductosEntidades

        'Paso a la función Alta ComposicionProductos, los parámetros de mi objeto segun lo completado en los Textbox.
        CompoProdEntidad.IdComposicionProducto = TextBox11.Text
        CompoProdEntidad.IdProducto = TextBox15.Text
        CompoProdEntidad.CodigoArticulo = TextBox16.Text
        CompoProdEntidad.CantidadMateriaPrima = ComboBox3.Text
        CompoProdEntidad.CostoTotal = TextBox1.Text
        CompoProdEntidad.Costo = TextBox12.Text

        Dim Resultado As Boolean
        Resultado = CompoProdNegocio.AltaComposicion(TextBox15.Text, CompoProdEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El detalle del producto se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxtCompoProd()
        Else
            MsgBox("El detalle del producto ya existe. Ingrese uno distinto.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Botón Modificar ComposicionProductos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView3.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView3.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción pulsando la flecha a la izquierda del comienzo cada fila", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        Dim CompoProdNegocio As New CapaDeNegocios.ComposicionProductoNegocio
        Dim CompoProdEntidad As New CapaDeEntidades.ComposicionProductosEntidades

        'Paso a la función Modificar ComposicionProducto, los parámetros de mi objeto segun lo completado en los Textbox.
        CompoProdEntidad.IdComposicionProducto = TextBox11.Text
        CompoProdEntidad.IdProducto = TextBox15.Text
        CompoProdEntidad.CodigoArticulo = TextBox16.Text
        CompoProdEntidad.CantidadMateriaPrima = ComboBox3.Text
        CompoProdEntidad.Costo = CDec(TextBox12.Text)
        CompoProdEntidad.CostoTotal = CDec(TextBox1.Text)

        Dim CompoProdNegocios As New CapaDeNegocios.ComposicionProductoNegocio
        Dim CompoProdEntidades As New List(Of CapaDeEntidades.ComposicionProductosEntidades)

        Dim Resultado As Boolean

        Resultado = CompoProdNegocio.ModificarComposicion(CompoProdEntidad, TextBox15.Text, TextBox16.Text)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("La composicion del producto fue modificada correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxtCompoProd()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtCompoProd()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Botón Baja ComposicionProductos.

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar la Composición del Producto seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (RespuestaBaja = DialogResult.No) Then
            Exit Sub
        End If

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView3.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView3.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción pulsando la flecha a la izquierda del comienzo cada fila", vbCritical, "Error")
            Exit Sub
        End If

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID de la ComposicionProductos seleccionada y con eso podemos dar de baja la misma.
        Dim Seleccionado As Integer = 0
        Seleccionado = DataGridView3.SelectedRows(0).Cells(0).Value()

        Dim CompoProdNegocios As New CapaDeNegocios.ComposicionProductoNegocio
        Dim CompoProdEntidades As New CapaDeEntidades.ComposicionProductosEntidades
        Dim Resultado As Boolean

        CompoProdEntidades.IdComposicionProducto = Seleccionado
        Resultado = CompoProdNegocios.BajaComposicion(CompoProdEntidades)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("La composicion del producto fue eliminada correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxtCompoProd()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtCompoProd()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Todos en ComposicionProductos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio la grilla e introduzco la funcion para traer toda la ComposicionProductos.
        Me.DataGridView3.Rows.Clear()

        Dim UsuarioNegocio As New CapaDeNegocios.ComposicionProductoNegocio
        Dim UsuarioEntidad As New List(Of CapaDeEntidades.ComposicionProductosEntidades)

        UsuarioEntidad = UsuarioNegocio.BuscarTodaComposicion()
        LlenarGrillaData3(UsuarioEntidad)

        'Traigo todo lo establecido en la funcion NombreMatPrimaSegunID. 
        Dim UsuarioNegocio3 As New CapaDeNegocios.ComprasNegocio
        Dim UsuarioEntidad3 As New List(Of CapaDeEntidades.ComprasEntidades)

        UsuarioEntidad3 = UsuarioNegocio3.NombreArticulo()
        LlenarGrillaDataConNombreArticulo(UsuarioEntidad3)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Traigo la lista de Nombres de los Productos para luego pasarla al DataGrid.
        Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
        Dim ProductoEntidad As New List(Of CapaDeEntidades.ProductoEntidades)
        ProductoEntidad = ProductoNegocio.ProductosParaComposicionProductos()
        NombresParaCompoADataGrid(ProductoEntidad)

        'Traigo la lista de PrecioVenta de los Productos para luego pasarla al DataGrid.
        Dim ProductoNegocio2 As New CapaDeNegocios.ProductoNegocio
        Dim ProductoEntidad2 As New List(Of CapaDeEntidades.ProductoEntidades)
        ProductoEntidad2 = ProductoNegocio2.TodosLosPreciosDeVenta()
        PreciosVentaADataGrid(ProductoEntidad2)

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView3.CurrentRow
        If Row Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView3.Rows(0).Selected = False
        End If
    End Sub

    Sub PreciosVentaADataGrid(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Inserto el PrecioVenta al DataGrid.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            Me.DataGridView3.Rows(Fila).Cells(8).Value = MiDetalle.PrecioVenta
            Fila += 1
        Next
    End Sub

    Sub NombresParaCompoADataGrid(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Inserto los Productos al DataGrid.
        Dim Fila As Integer = 0
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            Me.DataGridView3.Rows(Fila).Cells(2).Value = MiDetalle.Nombre
            Fila += 1
        Next
    End Sub

    Private Sub BtnVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVolver.Click
        'Botón para volver al formulario anterior y cerrar el actual. Además, se actualiza la hora y fecha.
        Me.Close()
        ActualizarLabel()
        AbrirFormEnPanel1(New Productos)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Boton Borrar Campos.

        'Limpio todos los campos del formulario y dejo el ID ComposicionProductos actualizado.
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        TextBox12.Text = ""
        TextBox1.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Actualizamos la fecha y hora.
        ActualizarLabel()
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        If ComboBox1.SelectedIndex > -1 And ComboBox2.SelectedIndex > -1 Then
            ComboBox3.Enabled = True
        End If

        If ComboBox1.Items.Count <= 0 Then
            ComboBox1.Enabled = False
        End If

        If ComboBox2.Items.Count <= 0 Then
            ComboBox2.Enabled = False
        End If

        'Traigo el ID del Producto segun el nombre seleccionado.
        Dim UsuarioNegocio As New CapaDeNegocios.ProductoNegocio
        Dim UsuarioEntidad As New List(Of CapaDeEntidades.ProductoEntidades)

        UsuarioEntidad = UsuarioNegocio.IDProductoSegunNombre(ComboBox1.Text)
        IDProdATxT(UsuarioEntidad)

        'Trae el Precio Venta del Producto seleccionado segun el ID del mismo.
        Dim PrecioProductoNegocio As New CapaDeNegocios.ProductoNegocio
        Dim PrecioProductoEntidades As New List(Of CapaDeEntidades.ProductoEntidades)

        PrecioProductoEntidades = PrecioProductoNegocio.PrecioProdSegunNombre(TextBox15.Text)
        PrecioVentaSegunID(PrecioProductoEntidades)
    End Sub

    Sub IDProdATxT(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asigno el ID del Producto, al TxT15 (N° Producto).
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            TextBox15.Text = MiDetalle.IdProducto
        Next
    End Sub

    Private Sub ComboBox3_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectionChangeCommitted
        'Evento para que segun la el Nombre del Artículo, nos indique el CostoUnitario de la misma (TxT12).
        Me.TextBox12.Clear()
        Me.TextBox1.Clear()

        Dim CostoNegocios As New CapaDeNegocios.ComprasNegocio
        Dim CostoEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        CostoEntidades = CostoNegocios.CostoCompoProd(TextBox16.Text)
        CostoUnitATxt(CostoEntidades)




        'Calculo el Costo Total (Costo unitario x Cantidad Materia Prima)
        Dim CostoTotal As Decimal
        CostoTotal = CDec(TextBox12.Text) * Val(ComboBox3.Text)
        Me.TextBox1.Text = Format(CostoTotal, "#,###,##0.00")
    End Sub

    Private Sub DataGridView3_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        'Usamos el evento para que al seleccionar una fila del DataGrid, los Txt tomen los valores de dicha fila.
        Dim NumeroDeFilaSeleccionada As Integer
        Dim ValidacionCeldaVacia As String

        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error y salgamos del proceso.
        If DataGridView3.RowCount = 0 Then
            Exit Sub
        End If

        NumeroDeFilaSeleccionada = DataGridView3.CurrentRow.Index
        ValidacionCeldaVacia = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(0).Value

        If ValidacionCeldaVacia = Nothing Then
            MsgBox("La fila seleccionada no contiene datos.", vbCritical, "Error")
            Exit Sub
        End If

        'Completamos los TxT y Combos con el contenido de la fila seleccionada.
        TextBox11.Text = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(0).Value
        TextBox15.Text = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        ComboBox1.Text = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        TextBox16.Text = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
        ComboBox2.Text = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(4).Value
        ComboBox3.Text = Val(DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(5).Value)
        TextBox12.Text = CDec(DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(6).Value)
        TextBox1.Text = CDec(DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(7).Value)
        TextBox14.Text = DataGridView3.Rows(NumeroDeFilaSeleccionada).Cells(8).Value
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        'Si al desplegar el Combo no hay informaci♀n cargada para mostrar, lo indica mediante un mensaje y termina el proceso.
        If ComboBox1.Items.Count <= 0 Then
            MsgBox("No hay ningún producto cargado aún.", vbCritical, "Error")
            ComboBox1.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub ComboBox2_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
        'Si al desplegar el Combo no hay informaci♀n cargada para mostrar, lo indica mediante un mensaje y termina el proceso.
        If ComboBox2.Items.Count <= 0 Then
            MsgBox("No hay ningún artículo cargado aún.", vbCritical, "Error")
            ComboBox1.Enabled = False
            Exit Sub
        End If
    End Sub
End Class