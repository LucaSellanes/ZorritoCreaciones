Imports System.Runtime.InteropServices

Public Class Form2
    'Imports para permitir mover el formulario.
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        'Botón Cerrar.
        Me.Close()
    End Sub

    Private Sub BtnMaximizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMaximizar.Click
        'Botón Maximizar.

        'Al tocar maximizar, desaparece dicho botón y aparece en su lugar el de Restaurar.
        BtnMaximizar.Visible = False
        BtnRestaurar.Visible = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BtnRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRestaurar.Click
        'Botón Restaurar.

        'Al tocar Restaurar, desaparece dicho botón y aparece en su lugar el de maximizar.
        BtnRestaurar.Visible = False
        BtnMaximizar.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub BtnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimizar.Click
        'Botón Minimizar.

        'Minimiza el programa.
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PanelCabecera_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelCabecera.MouseMove
        'Metodo para permitir mover el formulario desde el panel de cabecera.
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub TmOcultarMenu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmOcultarMenu.Tick
        'Mostrar/Ocultar menu. Si esta desplegado se contrae. Y si se encuentra retraído, se extiende.
        If PanelMenu.Width <= 60 Then
            Me.TmOcultarMenu.Enabled = False
        Else
            Me.PanelMenu.Width = PanelMenu.Width - 20
        End If
    End Sub

    Private Sub TmMostrarMenu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmMostrarMenu.Tick
        'Mostrar/Ocultar menu. Si esta desplegado se contrae. Y si se encuentra retraído, se extiende.
        If PanelMenu.Width >= 220 Then
            Me.TmMostrarMenu.Enabled = False
        Else
            Me.PanelMenu.Width = PanelMenu.Width + 20
        End If
    End Sub

    Private Sub BtnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMenu.Click
        ActualizarLabel()
        If PanelMenu.Width = 220 Then
            TmOcultarMenu.Enabled = True
            LabelHora.Visible = False
        ElseIf PanelMenu.Width = 60 Then
            LabelHora.Visible = True
            TmMostrarMenu.Enabled = True
        End If
    End Sub

    Private Sub AbrirFormEnPanel1(ByVal FormHijo As Object)
        'Metodo para abrir otros formularios dentro del form principal.
        If Me.PanelContenedor.Controls.Count > 0 Then
            Me.PanelContenedor.Controls.RemoveAt(0)
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
        Me.PanelContenedor.Controls.Add(fh)
        'El  PanelContenedor tendra los datos del formulario.
        Me.PanelContenedor.Tag = fh
        'Mostramos el formulario.
        fh.Show()
    End Sub

    Private Sub BotonClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonClientes.Click
        'Botón Clientes.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Clientes" Then
                Form.Close()
            End If
        Next

        'El metodo tendra como parametro la creacion del objeto tipo Form.
        AbrirFormEnPanel1(New Clientes)
        ActualizarLabel()
    End Sub

    Private Sub BotonProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Botón Productos.

        AbrirFormEnPanel1(New Productos)
        ActualizarLabel()
    End Sub


    Private Sub BotonMatPrima_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Botón Compras.

        AbrirFormEnPanel1(New Compras)
        ActualizarLabel()
    End Sub

    Private Sub BotonVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonVentas.Click
        'Botón Ventas.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Ventas" Then
                Form.Close()
            End If
        Next

        AbrirFormEnPanel1(New Ventas)
        ActualizarLabel()
    End Sub

    Private Sub PanelMenu_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelMenu.Paint
        LabelHora.Text = DateTime.Now.ToString("HH:mm")
        LabelFecha.Text = DateTime.Now.ToString("dd - MM -yyyy")
    End Sub

    Private Sub ActualizarLabel()
        'Metodo para actualizar fecha y hora.
        LabelFecha.Refresh()
        LabelHora.Refresh()
    End Sub

    Private Sub BtnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonReportes.Click
        'Botón Reportes.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Reportes" Then
                Form.Close()
            End If
        Next

        AbrirFormEnPanel1(New Reportes)
        ActualizarLabel()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonFinanciero.Click
        'Botón Financiero.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Financiero" Then
                Form.Close()
            End If
        Next

        AbrirFormEnPanel1(New Financiero)
        ActualizarLabel()
    End Sub

    Private Sub BotonProductos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonProductos.Click
        'Botón Productos.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Productos" Then
                Form.Close()
            End If
        Next

        AbrirFormEnPanel1(New Productos)
        ActualizarLabel()
    End Sub

    Private Sub BotonCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonCompras.Click
        'Botón Compras.

        'Creo una lista con los formularios activos y cierro todos excepto el Form2 (Form padre) y el form que se esta por abrir.
        Dim ListaFormularios As New List(Of Form)
        For Each F As Form In Application.OpenForms
            ListaFormularios.Add(F)
        Next

        For Each Form In ListaFormularios
            If Form.Name <> "Form2" And Form.Name <> "Compras" Then
                Form.Close()
            End If
        Next

        AbrirFormEnPanel1(New Compras)
        ActualizarLabel()
    End Sub
End Class