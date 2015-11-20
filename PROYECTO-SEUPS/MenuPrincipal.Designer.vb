<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BateriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SucursalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesDeMantenimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteParaEmpresaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteParaClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem22 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Snow
        Me.MenuStrip1.BackgroundImage = CType(resources.GetObject("MenuStrip1.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BateriasToolStripMenuItem, Me.SucursalesToolStripMenuItem, Me.UPSToolStripMenuItem, Me.ProgramaToolStripMenuItem, Me.MantenimientosToolStripMenuItem, Me.ReportesDeMantenimientoToolStripMenuItem, Me.ToolStripMenuItem19, Me.ToolStripMenuItem13, Me.ToolStripMenuItem12})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(138, 236)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'BateriasToolStripMenuItem
        '
        Me.BateriasToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.BateriasToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BateriasToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.BateriasToolStripMenuItem.Image = CType(resources.GetObject("BateriasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BateriasToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BateriasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BateriasToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.BateriasToolStripMenuItem.Name = "BateriasToolStripMenuItem"
        Me.BateriasToolStripMenuItem.Size = New System.Drawing.Size(125, 29)
        Me.BateriasToolStripMenuItem.Text = "Baterías"
        '
        'SucursalesToolStripMenuItem
        '
        Me.SucursalesToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.SucursalesToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SucursalesToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.SucursalesToolStripMenuItem.Image = CType(resources.GetObject("SucursalesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SucursalesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SucursalesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SucursalesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.SucursalesToolStripMenuItem.Name = "SucursalesToolStripMenuItem"
        Me.SucursalesToolStripMenuItem.Size = New System.Drawing.Size(125, 29)
        Me.SucursalesToolStripMenuItem.Text = "Sucursales"
        '
        'UPSToolStripMenuItem
        '
        Me.UPSToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.UPSToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UPSToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.UPSToolStripMenuItem.Image = CType(resources.GetObject("UPSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UPSToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UPSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UPSToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.UPSToolStripMenuItem.Name = "UPSToolStripMenuItem"
        Me.UPSToolStripMenuItem.Size = New System.Drawing.Size(125, 27)
        Me.UPSToolStripMenuItem.Text = "UPS"
        '
        'ProgramaToolStripMenuItem
        '
        Me.ProgramaToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.ProgramaToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgramaToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.ProgramaToolStripMenuItem.Image = CType(resources.GetObject("ProgramaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProgramaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ProgramaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ProgramaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ProgramaToolStripMenuItem.Name = "ProgramaToolStripMenuItem"
        Me.ProgramaToolStripMenuItem.Size = New System.Drawing.Size(125, 29)
        Me.ProgramaToolStripMenuItem.Text = "Programa"
        '
        'MantenimientosToolStripMenuItem
        '
        Me.MantenimientosToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.MantenimientosToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MantenimientosToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.MantenimientosToolStripMenuItem.Image = CType(resources.GetObject("MantenimientosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MantenimientosToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MantenimientosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MantenimientosToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.MantenimientosToolStripMenuItem.Name = "MantenimientosToolStripMenuItem"
        Me.MantenimientosToolStripMenuItem.Size = New System.Drawing.Size(125, 29)
        Me.MantenimientosToolStripMenuItem.Text = "Mantenimientos"
        '
        'ReportesDeMantenimientoToolStripMenuItem
        '
        Me.ReportesDeMantenimientoToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.ReportesDeMantenimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteParaEmpresaToolStripMenuItem, Me.ReporteParaClienteToolStripMenuItem})
        Me.ReportesDeMantenimientoToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportesDeMantenimientoToolStripMenuItem.ForeColor = System.Drawing.Color.DarkRed
        Me.ReportesDeMantenimientoToolStripMenuItem.Image = CType(resources.GetObject("ReportesDeMantenimientoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ReportesDeMantenimientoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ReportesDeMantenimientoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReportesDeMantenimientoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ReportesDeMantenimientoToolStripMenuItem.Name = "ReportesDeMantenimientoToolStripMenuItem"
        Me.ReportesDeMantenimientoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReportesDeMantenimientoToolStripMenuItem.Size = New System.Drawing.Size(125, 29)
        Me.ReportesDeMantenimientoToolStripMenuItem.Text = "Reportes"
        '
        'ReporteParaEmpresaToolStripMenuItem
        '
        Me.ReporteParaEmpresaToolStripMenuItem.Name = "ReporteParaEmpresaToolStripMenuItem"
        Me.ReporteParaEmpresaToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ReporteParaEmpresaToolStripMenuItem.Text = "Reporte para Empresa"
        '
        'ReporteParaClienteToolStripMenuItem
        '
        Me.ReporteParaClienteToolStripMenuItem.Name = "ReporteParaClienteToolStripMenuItem"
        Me.ReporteParaClienteToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ReporteParaClienteToolStripMenuItem.Text = "Reporte para Cliente"
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem19.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem20, Me.ToolStripMenuItem21, Me.ToolStripMenuItem22, Me.CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem})
        Me.ToolStripMenuItem19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem19.ForeColor = System.Drawing.Color.DarkRed
        Me.ToolStripMenuItem19.Image = CType(resources.GetObject("ToolStripMenuItem19.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripMenuItem19.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem19.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        Me.ToolStripMenuItem19.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem19.Size = New System.Drawing.Size(125, 29)
        Me.ToolStripMenuItem19.Text = "Configuración"
        '
        'ToolStripMenuItem20
        '
        Me.ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        Me.ToolStripMenuItem20.Size = New System.Drawing.Size(344, 22)
        Me.ToolStripMenuItem20.Text = "Usuarios"
        '
        'ToolStripMenuItem21
        '
        Me.ToolStripMenuItem21.Name = "ToolStripMenuItem21"
        Me.ToolStripMenuItem21.Size = New System.Drawing.Size(344, 22)
        Me.ToolStripMenuItem21.Text = "Respaldos"
        '
        'ToolStripMenuItem22
        '
        Me.ToolStripMenuItem22.Name = "ToolStripMenuItem22"
        Me.ToolStripMenuItem22.Size = New System.Drawing.Size(344, 22)
        Me.ToolStripMenuItem22.Text = "Borrar Base de Datos."
        '
        'CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem
        '
        Me.CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem.Name = "CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem"
        Me.CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem.Size = New System.Drawing.Size(344, 22)
        Me.CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem.Text = "Cambiar Carpeta donde se almacenan archivos."
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem13.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem14, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16, Me.ToolStripMenuItem17, Me.ToolStripMenuItem18})
        Me.ToolStripMenuItem13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem13.ForeColor = System.Drawing.Color.DarkRed
        Me.ToolStripMenuItem13.Image = CType(resources.GetObject("ToolStripMenuItem13.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripMenuItem13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem13.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(125, 29)
        Me.ToolStripMenuItem13.Text = "Informes"
        Me.ToolStripMenuItem13.Visible = False
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Enabled = False
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem14.Text = "Informe Baterias"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Enabled = False
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem15.Text = "Informe Sucursales"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Enabled = False
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem16.Text = "Informe UPS"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem17.Text = "Informe Programa"
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Enabled = False
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(201, 22)
        Me.ToolStripMenuItem18.Text = "Informe mantenimiento"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem12.ForeColor = System.Drawing.Color.DarkRed
        Me.ToolStripMenuItem12.Image = CType(resources.GetObject("ToolStripMenuItem12.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripMenuItem12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem12.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(125, 29)
        Me.ToolStripMenuItem12.Text = "Salir"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(388, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(199, 143)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans Unicode", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(176, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(346, 135)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Administrador de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reportes SEUPS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Crimson
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(564, 236)
        Me.ControlBox = False
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuPrincipal"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Principal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents BateriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SucursalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UPSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgramaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesDeMantenimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReporteParaEmpresaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteParaClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MantenimientosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
End Class
