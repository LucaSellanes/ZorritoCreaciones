Public Class Productos

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
        'Al pasar por el botón Detalle de Productos, la fuente del mismo cambiara a blanco.
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        'Al dejar de pasar por el botón Detalle de Productos, la fuente del mismo volvera a negro.
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button2_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseMove
        'Al pasar por el botón Productos y Costos, la fuente del mismo cambiara a blanco.
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        'Al dejar de pasar por el botón Productos y Costos, la fuente del mismo volvera a negro.
        Button2.ForeColor = Color.Black
    End Sub


    Private Sub Button5_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseMove
        'Al pasar por el botón Borrar Campos, la fuente del mismo cambiara a blanco.
        Button5.ForeColor = Color.White
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        'Al dejar de pasar por el botón Borrar Campos, la fuente del mismo volvera a negro.
        Button5.ForeColor = Color.Black
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

    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Le doy estilo deseado al Combo.
        ComboBox1.DropDownStyle = 2
        ComboBox1.SelectedIndex = 0

        'Deshabilito el Txt del ID
        TextBox8.ReadOnly = True

        'Ajustamos el contenido del Datagrid al formulario
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Creamos las columnas del Datagrid Productos.
        Me.DataGridView2.Columns.Add("0", "N° Producto")
        Me.DataGridView2.Columns.Add("1", "Nombre")
        Me.DataGridView2.Columns.Add("2", "Precio Venta")
        Me.DataGridView2.Columns.Add("3", "Descripcion")

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Le doy formato numerico y de moneda a la columna Precio Venta del DataGrid. Y al Txt PrecioVenta.
        DataGridView2.Columns(2).DefaultCellStyle.Format = "$" & "######.00"

        Dim PrecioVenta As Decimal
        Me.TextBox2.Text = Format(PrecioVenta, "#,###,##0.00")

        'Determina que separacion decimal usa el sistema.   
        Dim SepDecimal As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        'Cambiamos la separacion decimal por defecto del sistema, por la misma que utilizo en la base de datos (de coma a punto).
        Dim CambioDecimal As New Globalization.CultureInfo("es-ES")
        CambioDecimal.NumberFormat.CurrencyDecimalSeparator = "."
        CambioDecimal.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = CambioDecimal
    End Sub

    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de los Productos (TextBox8).
        Dim IDNegociosProd As New CapaDeNegocios.ProductoNegocio
        Dim IDEntidadesProd As New List(Of CapaDeEntidades.ProductoEntidades)

        IDEntidadesProd = IDNegociosProd.IDProducto()
        IDProductoATxT(IDEntidadesProd)
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Sub IDProductoATxT(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Asigno el ID Producto al TxT8.
        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            TextBox8.Text = MiDetalle.IdProducto
        Next
    End Sub

    Sub LlenarGrilla2(ByVal ListaDetalles As List(Of CapaDeEntidades.ProductoEntidades))
        'Llenamos la grilla del DataGrid de Productos.
        Dim Fila As Integer = 0

        For Each MiDetalle As CapaDeEntidades.ProductoEntidades In ListaDetalles
            Me.DataGridView2.Rows.Add()
            Me.DataGridView2.Rows(Fila).Cells(0).Value = MiDetalle.IdProducto
            Me.DataGridView2.Rows(Fila).Cells(1).Value = MiDetalle.Nombre
            Me.DataGridView2.Rows(Fila).Cells(2).Value = MiDetalle.PrecioVenta
            Me.DataGridView2.Rows(Fila).Cells(3).Value = MiDetalle.Descripcion
            Fila += 1
        Next
    End Sub

    Sub LimpiarTxtProductos()
        'Metodo para limpiar Textbox de Productos y establecer el cursor en N° 9 ("Nombre").
        TextBox2.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox9.Focus()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Botón Alta de Productos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Validación para evitar campos vacíos.
        If TextBox9.Text = "" Or TextBox2.Text = "" Then
            MsgBox("El Nombre y el Precio no pueden estar vacíos.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar numeros negativos.
        If Val(TextBox2.Text) < 0 Or Val(TextBox2.Text) = 0 Then
            MsgBox("El precio no puede ser menor a 0", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox2.Text) = False Then
            MsgBox("El Precio Venta debe ser numerico.", vbCritical, "Error")
            Exit Sub
        End If

        'Determinar si el Nombre del Producto se encuentra en uso, mediante un DataTable. Creo un DataTable y le asigno lo obtenido 
        'por la lógica establecida. Luego paso el Código Artículo que se introduce
        'al dar de alta un nuevo Artículo, del TxT1 a "NombreNuevo". Por ultimo, busco si existe o no, el contenido del TxT1
        'dentro de mi Tabla de SQL. Si existe, aparece un error, de lo contrario se puede seguir con el procedimiento.
        Dim Nombres As New DataTable
        Dim NombreNegocios As New CapaDeNegocios.ProductoNegocio
        Dim NombreNuevo As String
        NombreNuevo = TextBox9.Text

        Nombres = NombreNegocios.BuscarNombreProductos()

        Dim ResultadoCodigo As DataRow() = Nombres.Select("Nombre= '" & NombreNuevo & "'")

        If ResultadoCodigo.Length <> 0 Then
            MsgBox("El Nombre del Porducto ya fue asignado. Utilice otro por favor.", vbCritical, "Error")
            Exit Sub
        End If

        Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
        Dim ProductoEntidad As New CapaDeEntidades.ProductoEntidades

        'Paso a la función Alta Producto, los parámetros de mi objeto segun lo completado en los Textbox.
        ProductoEntidad.IdProducto = TextBox8.Text
        ProductoEntidad.Nombre = TextBox9.Text
        ProductoEntidad.PrecioVenta = CDec(TextBox2.Text)
        ProductoEntidad.Descripcion = TextBox10.Text

        Dim Resultado As Boolean
        Resultado = ProductoNegocio.AltaProducto(ProductoEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El producto se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxtProductos()
        Else
            MsgBox("El producto ya existe. Ingrese uno distinto.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Boton Modificar Productos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al puslar el botón y que no este cargado el Datagrid. En caso de pasar esto, se cerrará el proceso con un mensaje alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView2.CurrentRow
        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView2.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción pulsando la flecha a la izquierda del comienzo cada fila", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox9.Text = "" Or TextBox2.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
        Dim ProductoEntidad As New CapaDeEntidades.ProductoEntidades

        'Paso a la función Modificar Producto, los parámetros de mi objeto segun lo completado en los Textbox.
        ProductoEntidad.IdProducto = TextBox8.Text
        ProductoEntidad.Nombre = TextBox9.Text
        ProductoEntidad.PrecioVenta = CDec(TextBox2.Text)
        ProductoEntidad.Descripcion = TextBox10.Text

        Dim Resultado As Boolean

        Resultado = ProductoNegocio.ModificarProducto(ProductoEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("El producto fue modificado correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxtProductos()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtProductos()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Boton Baja Productos.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView2.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar el Producto seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (RespuestaBaja = DialogResult.No) Then
            Exit Sub
        End If

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos problemas al seleccionar un boton y que no este cargado el Datagrid. En caso de pasar esto, se cerrara el proceso con un mensajer alertando lo ocurrido.
        Dim Row As DataGridViewRow = DataGridView2.CurrentRow

        If Row Is Nothing Then
            MsgBox("Debe cargar la lista y seleccionar un item para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID del Producto seleccionado y con eso podemos dar de baja el mismo.
        Dim Seleccionado As Integer = 0
        Seleccionado = DataGridView2.SelectedRows(0).Cells(0).Value()

        Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
        Dim ProductoEntidad As New CapaDeEntidades.ProductoEntidades
        Dim Resultado As Boolean

        ProductoEntidad.IdProducto = Seleccionado
        Resultado = ProductoNegocio.BajaProducto(ProductoEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("El producto fue eliminado correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxtProductos()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtProductos()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Botón Mostrar Todos los Productos.

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Limpio la grilla e introduzco la funcion para traer todos los Productos.
        Me.DataGridView2.Rows.Clear()

        Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
        Dim ProductoEntidad As New List(Of CapaDeEntidades.ProductoEntidades)

        ProductoEntidad = ProductoNegocio.BuscarTodosLosProductos()
        LlenarGrilla2(ProductoEntidad)

        'Limpiamos los Textbox y Combobox de Detalle Ventas.
        LimpiarTxtProductos()

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView2.CurrentRow
        If Row Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView2.Rows(0).Selected = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Botón Detalle de Productos.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "ComposicionProductos" Then
                Form.Close()
            End If
        Next

        'Actualizamos la fecha y hora.
        ActualizarLabel()
        AbrirFormEnPanel1(New ComposicionProductos)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Botón Borrar Campos.
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox2.Text = ""
        TextBox9.Focus()
        ActualizarLabel()
        IDAutoincremental()
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'Usamos el evento para que al seleccionar una fila del DataGrid, los Txt tomen los valores de dicha fila.
        Dim NumeroDeFilaSeleccionada As Integer
        Dim ValidacionCeldaVacia As String

        'Condición para que al tocar el DataGrid sin ningun dato cargado, no se produzca un error y salgamos del proceso.
        If DataGridView2.RowCount = 0 Then
            Exit Sub
        End If

        NumeroDeFilaSeleccionada = DataGridView2.CurrentRow.Index
        ValidacionCeldaVacia = DataGridView2.Rows(NumeroDeFilaSeleccionada).Cells(0).Value

        If ValidacionCeldaVacia = Nothing Then
            MsgBox("La fila seleccionada no contiene datos.", vbCritical, "Error")
            Exit Sub
        End If

        'Completamos los TxT y Combos con el contenido de la fila seleccionada.
        TextBox8.Text = DataGridView2.Rows(NumeroDeFilaSeleccionada).Cells(0).Value
        TextBox9.Text = DataGridView2.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        TextBox2.Text = CDec(DataGridView2.Rows(NumeroDeFilaSeleccionada).Cells(2).Value)
        TextBox10.Text = DataGridView2.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        'Estructuramos el TxT9 para que al estar vacío traiga todos los Productos. Caso contrario, filtre los mismos segun el parametro ingresado. 
        Me.DataGridView2.Rows.Clear()

        If TextBox9.Text = "" Then
            Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
            Dim ProductoEntidad As New List(Of CapaDeEntidades.ProductoEntidades)
            ProductoEntidad = ProductoNegocio.BuscarTodosLosProductos()
            LlenarGrilla2(ProductoEntidad)
        End If

        If TextBox9.Text <> "" Then
            Dim ProductoNegocio As New CapaDeNegocios.ProductoNegocio
            Dim ProductoEntidad As New List(Of CapaDeEntidades.ProductoEntidades)
            ProductoEntidad = ProductoNegocio.BuscarProductosFiltrados(ComboBox1.Text, TextBox1.Text)
            LlenarGrilla2(ProductoEntidad)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "ComposicionProductos" Then
                Form.Close()
            End If
        Next

        'Actualizamos la fecha y hora.
        ActualizarLabel()
        AbrirFormEnPanel1(New ProductosYCostos)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'Precio Venta.

        'Cambiamos la coma por un punto.
        If e.KeyChar = "," Then e.KeyChar = "."

        'Evitamos espacios.
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

End Class