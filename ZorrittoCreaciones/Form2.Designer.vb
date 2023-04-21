<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim PictureBox1 As System.Windows.Forms.PictureBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Dim PictureBox2 As System.Windows.Forms.PictureBox
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.BtnRestaurar = New System.Windows.Forms.Button()
        Me.BtnMinimizar = New System.Windows.Forms.Button()
        Me.BtnMaximizar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BotonProductos = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BotonCompras = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BotonFinanciero = New System.Windows.Forms.Button()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.LabelHora = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.BotonReportes = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BotonVentas = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BotonClientes = New System.Windows.Forms.Button()
        Me.BtnMenu = New System.Windows.Forms.PictureBox()
        Me.TmOcultarMenu = New System.Windows.Forms.Timer(Me.components)
        Me.TmMostrarMenu = New System.Windows.Forms.Timer(Me.components)
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        PictureBox1 = New System.Windows.Forms.PictureBox()
        PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCabecera.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        CType(Me.BtnMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContenedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        PictureBox1.Location = New System.Drawing.Point(0, 27)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New System.Drawing.Size(220, 180)
        PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        PictureBox2.BackColor = System.Drawing.SystemColors.Window
        PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        PictureBox2.Location = New System.Drawing.Point(0, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New System.Drawing.Size(1080, 710)
        PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.Goldenrod
        Me.PanelCabecera.Controls.Add(Me.BtnRestaurar)
        Me.PanelCabecera.Controls.Add(Me.BtnMinimizar)
        Me.PanelCabecera.Controls.Add(Me.BtnMaximizar)
        Me.PanelCabecera.Controls.Add(Me.BtnCerrar)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(1300, 40)
        Me.PanelCabecera.TabIndex = 0
        '
        'BtnRestaurar
        '
        Me.BtnRestaurar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRestaurar.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.BtnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRestaurar.FlatAppearance.BorderSize = 0
        Me.BtnRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BtnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRestaurar.Image = CType(resources.GetObject("BtnRestaurar.Image"), System.Drawing.Image)
        Me.BtnRestaurar.Location = New System.Drawing.Point(1223, 0)
        Me.BtnRestaurar.Name = "BtnRestaurar"
        Me.BtnRestaurar.Size = New System.Drawing.Size(40, 40)
        Me.BtnRestaurar.TabIndex = 3
        Me.BtnRestaurar.UseVisualStyleBackColor = False
        Me.BtnRestaurar.Visible = False
        '
        'BtnMinimizar
        '
        Me.BtnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMinimizar.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.BtnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMinimizar.FlatAppearance.BorderSize = 0
        Me.BtnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BtnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMinimizar.Image = CType(resources.GetObject("BtnMinimizar.Image"), System.Drawing.Image)
        Me.BtnMinimizar.Location = New System.Drawing.Point(1187, 0)
        Me.BtnMinimizar.Name = "BtnMinimizar"
        Me.BtnMinimizar.Size = New System.Drawing.Size(40, 40)
        Me.BtnMinimizar.TabIndex = 2
        Me.BtnMinimizar.UseVisualStyleBackColor = False
        '
        'BtnMaximizar
        '
        Me.BtnMaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMaximizar.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.BtnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMaximizar.FlatAppearance.BorderSize = 0
        Me.BtnMaximizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnMaximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BtnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMaximizar.Image = CType(resources.GetObject("BtnMaximizar.Image"), System.Drawing.Image)
        Me.BtnMaximizar.Location = New System.Drawing.Point(1223, 0)
        Me.BtnMaximizar.Name = "BtnMaximizar"
        Me.BtnMaximizar.Size = New System.Drawing.Size(40, 40)
        Me.BtnMaximizar.TabIndex = 1
        Me.BtnMaximizar.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.FlatAppearance.BorderSize = 0
        Me.BtnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.Location = New System.Drawing.Point(1260, 0)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(40, 40)
        Me.BtnCerrar.TabIndex = 0
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.PanelMenu.Controls.Add(Me.Panel3)
        Me.PanelMenu.Controls.Add(Me.BotonProductos)
        Me.PanelMenu.Controls.Add(Me.Panel5)
        Me.PanelMenu.Controls.Add(Me.BotonCompras)
        Me.PanelMenu.Controls.Add(Me.Panel2)
        Me.PanelMenu.Controls.Add(Me.BotonFinanciero)
        Me.PanelMenu.Controls.Add(Me.LabelFecha)
        Me.PanelMenu.Controls.Add(Me.LabelHora)
        Me.PanelMenu.Controls.Add(Me.Panel6)
        Me.PanelMenu.Controls.Add(Me.BotonReportes)
        Me.PanelMenu.Controls.Add(Me.Panel4)
        Me.PanelMenu.Controls.Add(Me.BotonVentas)
        Me.PanelMenu.Controls.Add(Me.Panel1)
        Me.PanelMenu.Controls.Add(Me.BotonClientes)
        Me.PanelMenu.Controls.Add(PictureBox1)
        Me.PanelMenu.Controls.Add(Me.BtnMenu)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 40)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(220, 710)
        Me.PanelMenu.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel3.BackColor = System.Drawing.Color.Coral
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel3.Location = New System.Drawing.Point(0, 353)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(7, 50)
        Me.Panel3.TabIndex = 3
        '
        'BotonProductos
        '
        Me.BotonProductos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BotonProductos.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BotonProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonProductos.FlatAppearance.BorderSize = 0
        Me.BotonProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.BotonProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonProductos.Font = New System.Drawing.Font("Segoe Print", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonProductos.ForeColor = System.Drawing.Color.White
        Me.BotonProductos.Image = CType(resources.GetObject("BotonProductos.Image"), System.Drawing.Image)
        Me.BotonProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonProductos.Location = New System.Drawing.Point(0, 353)
        Me.BotonProductos.Name = "BotonProductos"
        Me.BotonProductos.Size = New System.Drawing.Size(220, 50)
        Me.BotonProductos.TabIndex = 18
        Me.BotonProductos.Text = "Productos"
        Me.BotonProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotonProductos.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel5.BackColor = System.Drawing.Color.Coral
        Me.Panel5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel5.Location = New System.Drawing.Point(0, 283)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(7, 50)
        Me.Panel5.TabIndex = 3
        '
        'BotonCompras
        '
        Me.BotonCompras.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BotonCompras.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BotonCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonCompras.FlatAppearance.BorderSize = 0
        Me.BotonCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.BotonCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonCompras.Font = New System.Drawing.Font("Segoe Print", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonCompras.ForeColor = System.Drawing.Color.White
        Me.BotonCompras.Image = CType(resources.GetObject("BotonCompras.Image"), System.Drawing.Image)
        Me.BotonCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonCompras.Location = New System.Drawing.Point(0, 283)
        Me.BotonCompras.Name = "BotonCompras"
        Me.BotonCompras.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.BotonCompras.Size = New System.Drawing.Size(220, 50)
        Me.BotonCompras.TabIndex = 16
        Me.BotonCompras.Text = " Compras"
        Me.BotonCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotonCompras.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel2.BackColor = System.Drawing.Color.Coral
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel2.Location = New System.Drawing.Point(0, 488)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(7, 50)
        Me.Panel2.TabIndex = 3
        '
        'BotonFinanciero
        '
        Me.BotonFinanciero.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BotonFinanciero.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BotonFinanciero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonFinanciero.FlatAppearance.BorderSize = 0
        Me.BotonFinanciero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.BotonFinanciero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonFinanciero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonFinanciero.Font = New System.Drawing.Font("Segoe Print", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonFinanciero.ForeColor = System.Drawing.Color.White
        Me.BotonFinanciero.Image = CType(resources.GetObject("BotonFinanciero.Image"), System.Drawing.Image)
        Me.BotonFinanciero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonFinanciero.Location = New System.Drawing.Point(0, 488)
        Me.BotonFinanciero.Name = "BotonFinanciero"
        Me.BotonFinanciero.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.BotonFinanciero.Size = New System.Drawing.Size(217, 50)
        Me.BotonFinanciero.TabIndex = 14
        Me.BotonFinanciero.Text = " Financiero"
        Me.BotonFinanciero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotonFinanciero.UseVisualStyleBackColor = False
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFecha.ForeColor = System.Drawing.SystemColors.Window
        Me.LabelFecha.Location = New System.Drawing.Point(0, 693)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(51, 17)
        Me.LabelFecha.TabIndex = 13
        Me.LabelFecha.Text = "Label2"
        '
        'LabelHora
        '
        Me.LabelHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelHora.AutoSize = True
        Me.LabelHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHora.ForeColor = System.Drawing.SystemColors.Window
        Me.LabelHora.Location = New System.Drawing.Point(164, 690)
        Me.LabelHora.Name = "LabelHora"
        Me.LabelHora.Size = New System.Drawing.Size(51, 17)
        Me.LabelHora.TabIndex = 12
        Me.LabelHora.Text = "Label1"
        '
        'Panel6
        '
        Me.Panel6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel6.BackColor = System.Drawing.Color.Coral
        Me.Panel6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel6.Location = New System.Drawing.Point(0, 561)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(7, 50)
        Me.Panel6.TabIndex = 3
        '
        'BotonReportes
        '
        Me.BotonReportes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BotonReportes.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BotonReportes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonReportes.FlatAppearance.BorderSize = 0
        Me.BotonReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.BotonReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonReportes.Font = New System.Drawing.Font("Segoe Print", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonReportes.ForeColor = System.Drawing.Color.White
        Me.BotonReportes.Image = CType(resources.GetObject("BotonReportes.Image"), System.Drawing.Image)
        Me.BotonReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonReportes.Location = New System.Drawing.Point(0, 561)
        Me.BotonReportes.Name = "BotonReportes"
        Me.BotonReportes.Size = New System.Drawing.Size(220, 50)
        Me.BotonReportes.TabIndex = 10
        Me.BotonReportes.Text = "Reportes"
        Me.BotonReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotonReportes.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel4.BackColor = System.Drawing.Color.Coral
        Me.Panel4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel4.Location = New System.Drawing.Point(0, 421)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(7, 50)
        Me.Panel4.TabIndex = 3
        '
        'BotonVentas
        '
        Me.BotonVentas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BotonVentas.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BotonVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonVentas.FlatAppearance.BorderSize = 0
        Me.BotonVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.BotonVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonVentas.Font = New System.Drawing.Font("Segoe Print", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonVentas.ForeColor = System.Drawing.Color.White
        Me.BotonVentas.Image = CType(resources.GetObject("BotonVentas.Image"), System.Drawing.Image)
        Me.BotonVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonVentas.Location = New System.Drawing.Point(0, 421)
        Me.BotonVentas.Name = "BotonVentas"
        Me.BotonVentas.Size = New System.Drawing.Size(220, 50)
        Me.BotonVentas.TabIndex = 6
        Me.BotonVentas.Text = "Ventas"
        Me.BotonVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotonVentas.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel1.BackColor = System.Drawing.Color.Coral
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(0, 213)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(7, 50)
        Me.Panel1.TabIndex = 3
        '
        'BotonClientes
        '
        Me.BotonClientes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BotonClientes.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.BotonClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BotonClientes.FlatAppearance.BorderSize = 0
        Me.BotonClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.BotonClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.BotonClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonClientes.Font = New System.Drawing.Font("Segoe Print", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonClientes.ForeColor = System.Drawing.Color.White
        Me.BotonClientes.Image = CType(resources.GetObject("BotonClientes.Image"), System.Drawing.Image)
        Me.BotonClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonClientes.Location = New System.Drawing.Point(0, 213)
        Me.BotonClientes.Name = "BotonClientes"
        Me.BotonClientes.Size = New System.Drawing.Size(220, 50)
        Me.BotonClientes.TabIndex = 2
        Me.BotonClientes.Text = "Clientes"
        Me.BotonClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BotonClientes.UseVisualStyleBackColor = False
        '
        'BtnMenu
        '
        Me.BtnMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMenu.Image = CType(resources.GetObject("BtnMenu.Image"), System.Drawing.Image)
        Me.BtnMenu.Location = New System.Drawing.Point(163, 0)
        Me.BtnMenu.Name = "BtnMenu"
        Me.BtnMenu.Size = New System.Drawing.Size(55, 30)
        Me.BtnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BtnMenu.TabIndex = 0
        Me.BtnMenu.TabStop = False
        '
        'TmOcultarMenu
        '
        '
        'TmMostrarMenu
        '
        '
        'PanelContenedor
        '
        Me.PanelContenedor.BackColor = System.Drawing.SystemColors.Window
        Me.PanelContenedor.Controls.Add(PictureBox2)
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PanelContenedor.Location = New System.Drawing.Point(220, 40)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(1080, 710)
        Me.PanelContenedor.TabIndex = 2
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 750)
        Me.Controls.Add(Me.PanelContenedor)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelMenu.PerformLayout()
        CType(Me.BtnMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContenedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents BtnMaximizar As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents PanelMenu As System.Windows.Forms.Panel
    Friend WithEvents BtnMinimizar As System.Windows.Forms.Button
    Friend WithEvents BtnRestaurar As System.Windows.Forms.Button
    Friend WithEvents BtnMenu As System.Windows.Forms.PictureBox
    Friend WithEvents TmOcultarMenu As System.Windows.Forms.Timer
    Friend WithEvents TmMostrarMenu As System.Windows.Forms.Timer
    Friend WithEvents BotonClientes As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents BotonReportes As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BotonVentas As System.Windows.Forms.Button
    Friend WithEvents PanelContenedor As System.Windows.Forms.Panel
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents LabelHora As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BotonFinanciero As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BotonProductos As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BotonCompras As System.Windows.Forms.Button
End Class
