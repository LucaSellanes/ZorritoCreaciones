Public Class Compras

    'Variable que utilizo como interruptor, es decir, segun la pase a True o False, se activan ciertos procesos.
    Public ValidacionFormatoTxt7 As Boolean = False

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

    Private Sub Button6_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.MouseMove
        'Al pasar por el botón Borrar Stock, la fuente del mismo cambiara a blanco.
        Button6.ForeColor = Color.White
    End Sub

    Private Sub Button6_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.MouseLeave
        'Al dejar de pasar por el botón Stock, la fuente del mismo volvera a negro.
        Button6.ForeColor = Color.Black
    End Sub

    Private Sub Button7_Mousemove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseMove
        'Al pasar por el botón Artículos, la fuente del mismo cambiara a blanco.
        Button7.ForeColor = Color.White
    End Sub

    Private Sub Button7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseLeave
        'Al dejar de pasar por el botón Articulos, la fuente del mismo volvera a negro.
        Button7.ForeColor = Color.Black
    End Sub

    Private Sub MateriaPrima_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Centramos el título en el form.
        Label1.Left = (Me.Width - Label1.Width) / 2
        Label1.Top = 10

        'Deshabilito los TxT que traen datos automaticamente (ID, Nombre ,Marca, Observaciones y Precio Unitario).
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox7.ReadOnly = True

        'Ajustamos el contenido del Datagrid al formulario.
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Centramos datos de las columnas y contenido del Datagrid.
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Creamos las columnas del Datagrid Compras.
        Me.DataGridView1.Columns.Add("0", "N° Compra")
        Me.DataGridView1.Columns.Add("1", "Cod. Artículo")
        Me.DataGridView1.Columns.Add("2", "Fecha")
        Me.DataGridView1.Columns.Add("3", "Marca")
        Me.DataGridView1.Columns.Add("4", "Nombre")
        Me.DataGridView1.Columns.Add("5", "Observaciones")
        Me.DataGridView1.Columns.Add("6", "Cant. Por bulto")
        Me.DataGridView1.Columns.Add("7", "Precio Bulto")
        Me.DataGridView1.Columns.Add("8", "Precio Unitario")

        'Asigno formato a los Combos.
        ComboBox1.DropDownStyle = 2
        ComboBox2.DropDownStyle = 2
        ComboBox2.SelectedIndex = 0

        ''Traigo todos los Codigos de Artículo al cargar el formulario.
        'Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
        'Dim ArticuloEntidad As New List(Of CapaDeEntidades.ArticulosEntidades)

        'ArticuloEntidad = ArticuloNegocio.ListadoCodArticulos()
        'CodigoArticuloACombo1(ArticuloEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Le doy formato numerico y de moneda a las celdas de costos del DataGrid.
        DataGridView1.Columns(8).DefaultCellStyle.Format = "$" & "######.00"
        DataGridView1.Columns(7).DefaultCellStyle.Format = "$" & "######.00"

        'Determina que separacion decimal usa el sistema.   
        Dim SepDecimal As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        'Cambiamos la separacion decimal por defecto del sistema, por la misma que utilizo en la base de datos (de coma a punto).
        Dim CambioDecimal As New Globalization.CultureInfo("es-ES")
        CambioDecimal.NumberFormat.CurrencyDecimalSeparator = "."
        CambioDecimal.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture = CambioDecimal
    End Sub

    Private Sub IDAutoincremental()
        'Metodo para incrementar automáticamente el ID de la Agenda (TxT1).
        Dim IDNegocios As New CapaDeNegocios.ComprasNegocio
        Dim IDEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        IDEntidades = IDNegocios.IDCompra()
        IDCompraATxt(IDEntidades)
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        Form2.LabelFecha.Refresh()
        Form2.LabelHora.Refresh()
    End Sub

    Sub IDCompraATxt(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Asignamos el ID Compra al TxT1.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            TextBox1.Text = MiDetalle.IdCompra
        Next
    End Sub

    Sub LlenarGrilla(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Llenamos la grilla del DataGrid Compras mediante este metodo.
        Dim Fila As Integer = 0

        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(Fila).Cells(0).Value = MiDetalle.IdCompra
            Me.DataGridView1.Rows(Fila).Cells(1).Value = MiDetalle.CodigoArticulo
            Me.DataGridView1.Rows(Fila).Cells(2).Value = MiDetalle.Fecha
            Me.DataGridView1.Rows(Fila).Cells(3).Value = MiDetalle.Marca
            Me.DataGridView1.Rows(Fila).Cells(4).Value = MiDetalle.Nombre
            Me.DataGridView1.Rows(Fila).Cells(5).Value = MiDetalle.Observaciones
            Me.DataGridView1.Rows(Fila).Cells(6).Value = MiDetalle.CantidadPorBulto
            Me.DataGridView1.Rows(Fila).Cells(7).Value = MiDetalle.PrecioBulto
            Me.DataGridView1.Rows(Fila).Cells(8).Value = MiDetalle.PrecioUnitario
            Fila += 1
        Next
    End Sub

    Sub LimpiarTxtCompras()
        'Metodo para limpiar Txt de Compras.
        ComboBox1.SelectedIndex = -1
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Boton para Alta de Compras.

        ValidacionFormatoTxt7 = True

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Validación para evitar numeros negativos.
        If Val(TextBox5.Text) < 0 Or Val(TextBox6.Text) < 0 Then
            MsgBox("No se permiten numeros negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Or TextBox7.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox5.Text) = False Or IsNumeric(TextBox6.Text) = False Then
            MsgBox("El Precio y la Cantidad deben ser numericos.", vbCritical, "Error")
            Exit Sub
        End If

        'Comienza el Ingreso de Stock por primera vez. Esto genera que al dar de alta una Compra, tambien se haga lo propio para el Stock, ya que esa compra es parte del Stock actual.
        Dim StockNegocios As New CapaDeNegocios.StockNegocio
        Dim StockEntidades As New CapaDeEntidades.StockEntidades

        'Paso a la función Alta Stock, los parámetros de mi objeto segun lo completado en los Textbox.
        StockEntidades.CodigoArticulo = ComboBox1.Text
        StockEntidades.Nombre = TextBox3.Text
        StockEntidades.Marca = TextBox2.Text
        StockEntidades.IngresoStock = TextBox5.Text

        'Determinar si el Codigo de Artículo se encuentra en uso o no, mediante un DataTable.
        'Creo un DataTable y le asigno lo obtenido por la funcion BuscarCodigosArticulo. Luego paso el Cod. Art. que se introduce
        'al dar de alta un nuevo Artículo, del Combo1 a "CodigoNuevo". Por ultimo, si ese Codigo Artículo ya existe,
        'en lugar de un INSERT se hace un UPDATE de la cantidad de stock, caso contrario, se hace el INSERT.
        Dim Codigos As New DataTable
        Dim CodigoNegocios As New CapaDeNegocios.ComprasNegocio
        Dim CodigoNuevo As String
        CodigoNuevo = ComboBox1.Text

        Codigos = CodigoNegocios.BuscarCodigosArticulosCompras()
        Dim ResultadoCodigo As DataRow() = Codigos.Select("CodigoArticulo= '" & CodigoNuevo & "'")

        If ResultadoCodigo.Length <> 0 Then
            'UPDATE:
            Dim Resultado2 As Boolean
            Resultado2 = StockNegocios.UpdateParaIngresoStockEnCompras(TextBox5.Text, ComboBox1.Text)
        Else
            'INSERT:
            Dim Resultado1 As Boolean
            Resultado1 = StockNegocios.AltaStockCompras(StockEntidades)
        End If
        'Finaliza el proceso del Ingreso de Stock y continuo con el procedimiento de la Compra.

        Dim ComprasNegocios As New CapaDeNegocios.ComprasNegocio
        Dim ComprasEntidades As New CapaDeEntidades.ComprasEntidades

        'Paso a la función Alta Compra, los parámetros de mi objeto segun lo completado en los Textbox.
        ComprasEntidades.IdCompra = TextBox1.Text
        ComprasEntidades.Fecha = DateTimePicker1.Text
        ComprasEntidades.CodigoArticulo = ComboBox1.Text
        ComprasEntidades.Marca = TextBox2.Text
        ComprasEntidades.Nombre = TextBox3.Text
        ComprasEntidades.Observaciones = TextBox4.Text
        ComprasEntidades.CantidadPorBulto = Val(TextBox5.Text)
        ComprasEntidades.PrecioBulto = CDec(TextBox6.Text)
        ComprasEntidades.PrecioUnitario = CDec(TextBox7.Text)

        Dim Resultado As Boolean
        Resultado = ComprasNegocios.AltaCompras(ComprasEntidades)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()
        ValidacionFormatoTxt7 = False

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("La Compra se dio de alta correctamente.", vbInformation, "Alta exitosa")
            LimpiarTxtCompras()
        Else
            MsgBox("La Compra ya existe. Ingrese una distinta.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Sub LlenadoTextbox1(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Asignamos el ID Compra al TxT1.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            TextBox1.Text = MiDetalle.IdCompra
        Next
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        'Estructuramos el TxT5 (Cant. Por Bulto) para que segun tome ciertos valores, se desencadenen ciertos procesos.

        'Evitamos que la cantidad sea nula o cero.
        If TextBox5.Text.StartsWith("0") Then
            TextBox5.Clear()
            MsgBox("La Cantidad por Bulto no puede ser cero.", vbCritical, "Error")
            Exit Sub
        End If

        'Si el TxT5 esta vacío, se limpian el TxT6 (Precio Por Bulto) y TxT7 (Precio Unitario), para luego salir del proceso, es decir, no se ejecute ninguna otra acción.
        If TextBox5.Text = "" Then
            TextBox6.Clear()
            TextBox7.Clear()
            Exit Sub
        End If

        'Si el usuario esta ubicado en el TxT5 y tenemos el interruptor (ValidacionFormatoTxt7) en False, se hace el cálculo del TxT7, a partir de los valores del TxT6 y TxT5.
        If TextBox5.Focused = True Then
            If ValidacionFormatoTxt7 = False Then
                Me.TextBox7.Clear()
                TextBox7.Text = Val(TextBox6.Text) / Val(TextBox5.Text)
                TextBox7.Text = Math.Round(Convert.ToDecimal(TextBox7.Text), 2)
            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        'Estructuramos el TxT5 (Precio Por Bulto) para que segun tome ciertos valores, se desencadenen ciertos procesos.
        If TextBox6.Text = "" Then
            TextBox5.Clear()
            TextBox7.Clear()
            Exit Sub
        End If

        'Si el usuario esta ubicado en el TxT6 y tenemos el interruptor (ValidacionFormatoTxt7) en False, se hace el cálculo del TxT7, a partir de los valores del TxT6 y TxT5.
        If TextBox6.Focused = True Then
            If ValidacionFormatoTxt7 = False Then
                Me.TextBox7.Clear()
                TextBox7.Text = Val(TextBox6.Text) / Val(TextBox5.Text)
                TextBox7.Text = Math.Round(Convert.ToDecimal(TextBox7.Text), 2)
            End If
        End If
    End Sub

    Private Sub FormatoText7()
        'Metodo para dar al TxT (Precio Unitario) formato decimal y pasamos a cero.
        Dim PrecioUnit As Decimal
        Me.TextBox7.Clear()
        PrecioUnit = Val(TextBox7.Text)
        PrecioUnit = 0
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Boton para Mostrar Todas las Compras.

        'Activación de la variable que usamos como interruptor.
        ValidacionFormatoTxt7 = True


        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Formateamos TxT7.
        FormatoText7()

        Me.DataGridView1.Rows.Clear()

        Dim ComprasNegocio As New CapaDeNegocios.ComprasNegocio
        Dim ComprasEntidad As New List(Of CapaDeEntidades.ComprasEntidades)

        ComprasEntidad = ComprasNegocio.BuscarTodasLasCompras()

        LlenarGrilla(ComprasEntidad)

        'Limpiamos los Textbox y Combobox de Compras.
        LimpiarTxtCompras()

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
        Dim Row As DataGridViewRow = DataGridView1.CurrentRow
        If Row Is Nothing Then
            MsgBox("No hay datos cargados para mostrar.", vbCritical, "Error")
        Else
            Me.DataGridView1.Rows(0).Selected = False
        End If
        ValidacionFormatoTxt7 = False
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Boton para baja de un Compra.

        'Si no se seleccionó ninguna fila, para evitar un error, alertamos al usuario con un mensaje y cerramos el proceso.
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un item de la lista para llevar a cabo la acción.", vbCritical, "Error")
            Exit Sub
        End If

        'Consulta al usuario si esta seguro de querer eliminar el registro. Si la respuesta es no, se cancela el proceso. Caso contrario, continua.
        Dim RespuestaBaja As DialogResult
        RespuestaBaja = MessageBox.Show("¿Esta seguro que desea eliminar la Compra seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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

        'Comienzo la parte 1 de la modificacion del Inreso de Stock por Compras. 
        'Genero el UPDATE en SQL para poder restar la cantidad que ya tiene ese registro del Stock.
        Dim StockNegocios1 As New CapaDeNegocios.StockNegocio
        Dim StockEntidades1 As New CapaDeEntidades.StockEntidades

        Dim ColumnaSeleccionada As Integer = 0
        ColumnaSeleccionada = DataGridView1.SelectedRows(0).Cells(6).Value()

        Dim Resultado1 As Boolean
        Resultado1 = StockNegocios1.ModificarStockComprasParte1(ColumnaSeleccionada, ComboBox1.Text)
        'Final de la parte 1 de la modificacion del Egreso de Stock por Venta.


        'Pasamos la fila seleccionada por el usuario a una variable. Luego esa variable la usamos para identificar el ID del Cliente seleccionado y con eso podemos dar de baja el mismo.
        Dim Seleccionado As Integer = 0

        Seleccionado = DataGridView1.SelectedRows(0).Cells(0).Value()

        Dim ComprasNegocio As New CapaDeNegocios.ComprasNegocio
        Dim ComprasEntidad As New CapaDeEntidades.ComprasEntidades
        Dim Resultado As Boolean

        ComprasEntidad.IdCompra = Seleccionado
        Resultado = ComprasNegocio.BajaCompra(ComprasEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True Then
            MsgBox("La Compra fue eliminada correctamente.", vbInformation, "Eliminación exitosa")
            LimpiarTxtCompras()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtCompras()
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Boton para modificar Compra.

        'Activación de la variable que usamos como interruptor.
        ValidacionFormatoTxt7 = True

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Evitamos que se autoseleccione una fila al cargar el Datagrid. Y en caso de que este vacio, esta accion no se activa, ya que tira error en ese caso.
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

        'Validación para evitar numeros negativos.
        If Val(TextBox5.Text) < 0 Or Val(TextBox6.Text) < 0 Then
            MsgBox("No se permiten numeros negativos", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar campos vacíos.
        If TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Or TextBox7.Text = "" Then
            MsgBox("No debe dejar campos vacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Validación para evitar datos no numericos.
        If IsNumeric(TextBox5.Text) = False Or IsNumeric(TextBox6.Text) = False Then
            MsgBox("El Precio y los Costos deben ser numericos.", vbCritical, "Error")
            Exit Sub
        End If

        Dim CompraNegocio As New CapaDeNegocios.ComprasNegocio
        Dim CompraEntidad As New CapaDeEntidades.ComprasEntidades

        'Paso a la función Modificar Compra, los parámetros de mi objeto segun lo completado en los Textbox.
        CompraEntidad.IdCompra = TextBox1.Text
        CompraEntidad.CodigoArticulo = ComboBox1.Text
        CompraEntidad.Fecha = DateTimePicker1.Text
        CompraEntidad.Marca = TextBox2.Text
        CompraEntidad.Nombre = TextBox3.Text
        CompraEntidad.Observaciones = TextBox4.Text
        CompraEntidad.CantidadPorBulto = TextBox5.Text
        CompraEntidad.PrecioBulto = CDec(TextBox6.Text)
        CompraEntidad.PrecioUnitario = CDec(TextBox7.Text)

        Dim Resultado As Boolean

        'Comienzo la parte 1 de la modificación del Inreso de Stock por Compras. 
        'Genero el UPDATE en SQL para poder restar la cantidad que ya tiene ese registro del Stock.
        Dim StockNegocios1 As New CapaDeNegocios.StockNegocio
        Dim StockEntidades1 As New CapaDeEntidades.StockEntidades

        Dim ColumnaSeleccionada As Integer = 0
        ColumnaSeleccionada = DataGridView1.SelectedRows(0).Cells(6).Value()

        Dim Resultado1 As Boolean
        Resultado1 = StockNegocios1.ModificarStockComprasParte1(ColumnaSeleccionada, ComboBox1.Text)
        'Final de la parte 1 de la modificacion del Egreso de Stock por Venta.

        'Comienzo de la Modificacion de Stock (Parte 2).
        Dim StockNegocios As New CapaDeNegocios.StockNegocio
        Dim StockEntidades As New CapaDeEntidades.StockEntidades

        'Paso a la función Modificar Stock, los parámetros de mi objeto segun lo completado en los Textbox.
        StockEntidades.CodigoArticulo = ComboBox1.Text
        StockEntidades.Nombre = TextBox3.Text
        StockEntidades.Marca = TextBox2.Text
        StockEntidades.IngresoStock = TextBox5.Text

        Dim Resultado2 As Boolean
        Resultado2 = StockNegocios.ModificarStockComprasParte2(TextBox5.Text, ComboBox1.Text)
        'Finalización la Modificacion de Stock(Parte 2).

        Resultado = CompraNegocio.ModificarCompra(CompraEntidad)

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Mensaje al finalizar el proceso, segun se haya hecho correctamente o no. Ademas, se limpian los TxT.
        If Resultado = True And Resultado = True Then
            MsgBox("La Compra fue modificada correctamente.", vbInformation, "Modificación exitosa")
            LimpiarTxtCompras()
        Else
            MsgBox("Ocurrio un error, contactese con Soporte por favor", vbCritical, "Error")
            LimpiarTxtCompras()
        End If
        ValidacionFormatoTxt7 = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Boton Borrar Campos.

        'Activación de la variable que usamos como interruptor.
        ValidacionFormatoTxt7 = True

        'Actualizamos la fecha y hora.
        ActualizarLabel()

        'Metodo para limpiar Textbox de Compras.
        ComboBox1.SelectedIndex = -1
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        'Se incrementa automáticamente el ID principal.
        IDAutoincremental()

        'Desactivación de la variable que usamos como interruptor.
        ValidacionFormatoTxt7 = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Boton Stock.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Stock" Then
                Form.Close()
            End If
        Next
        AbrirFormEnPanel1(New Stock)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Boton Artículos.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Articulos" Then
                Form.Close()
            End If
        Next
        AbrirFormEnPanel1(New Articulos)
    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        'Activación de la variable que usamos como interruptor.
        ValidacionFormatoTxt7 = True


        'Traigo la Marca al desatarse el evento del Combo1 segun el Código Artículo.
        Dim MarcaNegocio As New CapaDeNegocios.ComprasNegocio
        Dim MarcaEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        MarcaEntidades = MarcaNegocio.MarcaSegunCodArticulo(ComboBox1.Text)
        MarcaACombo2(MarcaEntidades)

        'Traigo el Nombres al desatarse el evento del Combo1 segun el Código Artículo.
        Dim NombreNegocio As New CapaDeNegocios.ComprasNegocio
        Dim NombreEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        NombreEntidades = NombreNegocio.NombreSegunCodArticulo(ComboBox1.Text)
        NombreATxT3(NombreEntidades)

        'Traigo las observaciones al desatarse el evento del Combo1 segun el Código Artículo.
        Dim ObservacionNegocio As New CapaDeNegocios.ComprasNegocio
        Dim ObservacionEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        ObservacionEntidades = ObservacionNegocio.ObservacionSegunCodArticulo(ComboBox1.Text)
        ObservacionATxT4(ObservacionEntidades)

        'Desactivación de la variable que usamos como interruptor.
        ValidacionFormatoTxt7 = False
    End Sub

    Sub CodigoArticuloACombo1(ByVal ListaDetalles As List(Of CapaDeEntidades.ArticulosEntidades))
        'Metodo para asignar el Código Artículo al Combo1.
        For Each MiDetalle As CapaDeEntidades.ArticulosEntidades In ListaDetalles
            ComboBox1.Items.Add(MiDetalle.CodigoArticulo)
        Next
    End Sub

    Sub MarcaACombo2(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Metodo para asignar la Marca al TxT2.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            TextBox2.Text = MiDetalle.Marca
        Next
    End Sub

    Sub NombreATxT3(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Metodo para asignar el Nombre al TxT3.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            TextBox3.Text = MiDetalle.Nombre
        Next
    End Sub

    Sub ObservacionATxT4(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Metodo para asignar las Observaciones al TxT4.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            TextBox4.Text = MiDetalle.Observaciones
        Next
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        'Estructuramos el TxT9 para que al estar vacío traiga todas las Compras. Caso contrario, filtre las mismas segun lo ingresado. 

        Me.DataGridView1.Rows.Clear()

        If TextBox9.Text = "" Then

            Dim ComprasNegocio As New CapaDeNegocios.ComprasNegocio
            Dim ComprasEntidad As New List(Of CapaDeEntidades.ComprasEntidades)
            ComprasEntidad = ComprasNegocio.BuscarTodasLasCompras()
            LlenarGrilla(ComprasEntidad)
        End If

        If TextBox9.Text <> "" Then
            Dim CompraNegocio As New CapaDeNegocios.ComprasNegocio
            Dim CompraEntidad As New List(Of CapaDeEntidades.ComprasEntidades)

            CompraEntidad = CompraNegocio.BuscarComprasFiltradas(ComboBox2.Text, TextBox9.Text)
            LlenarGrilla(CompraEntidad)
        End If
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectionChangeCommitted
        'Evento para que al seleccionar la Fecha del Combo2, se bloquee el filtro y se activen los RadioButtons.
        If ComboBox2.Text = "Fecha" Then
            TextBox9.Enabled = False
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        End If

        If ComboBox2.Text <> "Fecha" Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            TextBox9.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        'Segun la fecha seleccionada en los calendarios, se actualiza en tiempo de ejecución la función para mostrar las Compras segun el rango seleccionado.
        If ComboBox2.Text = "Fecha" Then
            If RadioButton2.Checked = True Then
                Me.DataGridView1.Rows.Clear()
                Dim CompraNegocio As New CapaDeNegocios.ComprasNegocio
                Dim CompraEntidad As New List(Of CapaDeEntidades.ComprasEntidades)

                CompraEntidad = CompraNegocio.BuscarComprasPorFecha(CDate(DateTimePicker2.Text), CDate(DateTimePicker3.Text))

                LlenarGrilla(CompraEntidad)
            End If
        End If
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        'Segun la fecha seleccionada en los calendarios, se actualiza en tiempo de ejecución la función para mostrar las Compras segun el rango seleccionado.
        If ComboBox2.Text = "Fecha" Then

            If RadioButton2.Checked = True Then
                Me.DataGridView1.Rows.Clear()
                Dim CompraNegocio As New CapaDeNegocios.ComprasNegocio
                Dim CompraEntidad As New List(Of CapaDeEntidades.ComprasEntidades)

                CompraEntidad = CompraNegocio.BuscarComprasPorFecha(CDate(DateTimePicker2.Text), CDate(DateTimePicker3.Text))
                LlenarGrilla(CompraEntidad)
            End If
        End If
    End Sub

    Sub CodArtDadoDeBajaACombo(ByVal ListaDetalles As List(Of CapaDeEntidades.ComprasEntidades))
        'Metodo para asignar el Código Artículo eliminado al Combo1.
        For Each MiDetalle As CapaDeEntidades.ComprasEntidades In ListaDetalles
            ComboBox1.Items.Add(MiDetalle.CodigoArticulo)
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

        'Utilizo esta estructura para que los nombres de los Artículos que esten dados de baja, se puedan visualizar en el combo1 de todas maneras.
        Dim CodArtParaDataGridNegocios As New CapaDeNegocios.ComprasNegocio
        Dim CodArtParaDataGridEntidades As New List(Of CapaDeEntidades.ComprasEntidades)

        CodArtParaDataGridEntidades = CodArtParaDataGridNegocios.CodArtSegunDataGridCompras(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(0).Value)
        CodArtDadoDeBajaACombo(CodArtParaDataGridEntidades)


        'Completamos los TxT y Combos con el contenido de la fila seleccionada.
        TextBox1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(0).Value
        ComboBox1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(1).Value
        DateTimePicker1.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(2).Value
        TextBox2.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(3).Value
        TextBox3.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(4).Value
        TextBox4.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(5).Value
        TextBox5.Text = DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(6).Value
        TextBox6.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(7).Value)
        TextBox7.Text = CDec(DataGridView1.Rows(NumeroDeFilaSeleccionada).Cells(8).Value)
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'Estructuramos el TxT 6 (Precio por Bulto).

        'Cambiamos la coma por un punto.
        If e.KeyChar = "," Then e.KeyChar = "."

        'Impedimos los espacios.
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If

        'Establecemos que antes de completar el Precio Por Bulto, se debe completar la Cantidad por Bulto (TxT5).
        If Char.IsLetterOrDigit(e.KeyChar) And TextBox5.Text = "" Then
            e.Handled = True
            MsgBox("Primero debe completar la 'Cantidad por Bulto'.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        'Estructuramos el TxT5 (Cantidad por Bulto), impidiendo los espacios.
        If Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
            MsgBox("No se permiten espacios.", vbCritical, "Error")
            Exit Sub
        End If
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Me.ComboBox1.Items.Clear()

        'Traigo todos los Codigos de Artículo al desplegar el Combo1.
        Dim ArticuloNegocio As New CapaDeNegocios.ArticuloNegocios
        Dim ArticuloEntidad As New List(Of CapaDeEntidades.ArticulosEntidades)

        ArticuloEntidad = ArticuloNegocio.ListadoCodArticulos()
        CodigoArticuloACombo1(ArticuloEntidad)


        If ComboBox1.Items.Count <= 0 Then
            MsgBox("No hay ningún artículo cargado aún.", vbCritical, "Error")
            ComboBox1.Enabled = False
            Exit Sub
        End If
    End Sub
End Class