<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mantenimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mantenimientos))
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.DGVM = New System.Windows.Forms.DataGridView()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTbuscado = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Fin = New System.Windows.Forms.Button()
        Me.Ini = New System.Windows.Forms.Button()
        Me.Sig = New System.Windows.Forms.Button()
        Me.Ant = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.FoM = New System.Windows.Forms.RadioButton()
        Me.LBLbuscado = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.MTXTimg = New System.Windows.Forms.TextBox()
        Me.Examinar = New System.Windows.Forms.Button()
        Me.MCBXups = New System.Windows.Forms.ComboBox()
        Me.MCBXsuc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MTXTups = New System.Windows.Forms.TextBox()
        Me.MTXTsuc = New System.Windows.Forms.TextBox()
        Me.MTXThora = New System.Windows.Forms.TextBox()
        Me.MTXTanio = New System.Windows.Forms.TextBox()
        Me.MTXTmes = New System.Windows.Forms.TextBox()
        Me.MTXTdia = New System.Windows.Forms.TextBox()
        Me.MTXTfolio = New System.Windows.Forms.TextBox()
        Me.AxAcroVisor = New AxAcroPDFLib.AxAcroPDF()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        CType(Me.DGVM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.AxAcroVisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Eliminar
        '
        Me.Eliminar.Location = New System.Drawing.Point(82, 15)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(71, 24)
        Me.Eliminar.TabIndex = 3
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'DGVM
        '
        Me.DGVM.BackgroundColor = System.Drawing.Color.White
        Me.DGVM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVM.Location = New System.Drawing.Point(0, 225)
        Me.DGVM.Name = "DGVM"
        Me.DGVM.ReadOnly = True
        Me.DGVM.Size = New System.Drawing.Size(536, 205)
        Me.DGVM.TabIndex = 46
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(11, 17)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 13)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Búsqueda por:"
        '
        'TXTbuscado
        '
        Me.TXTbuscado.Location = New System.Drawing.Point(14, 36)
        Me.TXTbuscado.Name = "TXTbuscado"
        Me.TXTbuscado.Size = New System.Drawing.Size(157, 20)
        Me.TXTbuscado.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Fin)
        Me.GroupBox4.Controls.Add(Me.Ini)
        Me.GroupBox4.Controls.Add(Me.Sig)
        Me.GroupBox4.Controls.Add(Me.Ant)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 132)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(266, 48)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Desplazamientos"
        '
        'Fin
        '
        Me.Fin.Location = New System.Drawing.Point(184, 19)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(58, 21)
        Me.Fin.TabIndex = 3
        Me.Fin.Text = "Fin"
        Me.Fin.UseVisualStyleBackColor = True
        '
        'Ini
        '
        Me.Ini.Location = New System.Drawing.Point(10, 19)
        Me.Ini.Name = "Ini"
        Me.Ini.Size = New System.Drawing.Size(58, 21)
        Me.Ini.TabIndex = 2
        Me.Ini.Text = "Inicio"
        Me.Ini.UseVisualStyleBackColor = True
        '
        'Sig
        '
        Me.Sig.Location = New System.Drawing.Point(126, 19)
        Me.Sig.Name = "Sig"
        Me.Sig.Size = New System.Drawing.Size(58, 21)
        Me.Sig.TabIndex = 1
        Me.Sig.Text = "Siguiente"
        Me.Sig.UseVisualStyleBackColor = True
        '
        'Ant
        '
        Me.Ant.Location = New System.Drawing.Point(68, 19)
        Me.Ant.Name = "Ant"
        Me.Ant.Size = New System.Drawing.Size(58, 21)
        Me.Ant.TabIndex = 0
        Me.Ant.Text = "Anterior"
        Me.Ant.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.FoM)
        Me.GroupBox15.Controls.Add(Me.LBLbuscado)
        Me.GroupBox15.Controls.Add(Me.Label30)
        Me.GroupBox15.Controls.Add(Me.TXTbuscado)
        Me.GroupBox15.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(266, 65)
        Me.GroupBox15.TabIndex = 47
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Búsqueda"
        '
        'FoM
        '
        Me.FoM.AutoSize = True
        Me.FoM.Checked = True
        Me.FoM.Location = New System.Drawing.Point(184, 13)
        Me.FoM.Name = "FoM"
        Me.FoM.Size = New System.Drawing.Size(47, 17)
        Me.FoM.TabIndex = 6
        Me.FoM.TabStop = True
        Me.FoM.Text = "Folio"
        Me.FoM.UseVisualStyleBackColor = True
        '
        'LBLbuscado
        '
        Me.LBLbuscado.AutoSize = True
        Me.LBLbuscado.Location = New System.Drawing.Point(93, 18)
        Me.LBLbuscado.Name = "LBLbuscado"
        Me.LBLbuscado.Size = New System.Drawing.Size(58, 13)
        Me.LBLbuscado.TabIndex = 3
        Me.LBLbuscado.Text = "-----------------"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Eliminar)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 77)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(266, 49)
        Me.GroupBox5.TabIndex = 45
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Acciones"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.MTXTimg)
        Me.GroupBox3.Controls.Add(Me.Examinar)
        Me.GroupBox3.Controls.Add(Me.MCBXups)
        Me.GroupBox3.Controls.Add(Me.MCBXsuc)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.MTXTups)
        Me.GroupBox3.Controls.Add(Me.MTXTsuc)
        Me.GroupBox3.Controls.Add(Me.MTXThora)
        Me.GroupBox3.Controls.Add(Me.MTXTanio)
        Me.GroupBox3.Controls.Add(Me.MTXTmes)
        Me.GroupBox3.Controls.Add(Me.MTXTdia)
        Me.GroupBox3.Controls.Add(Me.MTXTfolio)
        Me.GroupBox3.Location = New System.Drawing.Point(280, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 213)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'MTXTimg
        '
        Me.MTXTimg.Location = New System.Drawing.Point(69, 180)
        Me.MTXTimg.Name = "MTXTimg"
        Me.MTXTimg.Size = New System.Drawing.Size(161, 20)
        Me.MTXTimg.TabIndex = 15
        '
        'Examinar
        '
        Me.Examinar.Location = New System.Drawing.Point(2, 184)
        Me.Examinar.Name = "Examinar"
        Me.Examinar.Size = New System.Drawing.Size(61, 23)
        Me.Examinar.TabIndex = 49
        Me.Examinar.Text = "Examinar..."
        Me.Examinar.UseVisualStyleBackColor = True
        '
        'MCBXups
        '
        Me.MCBXups.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MCBXups.FormattingEnabled = True
        Me.MCBXups.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MCBXups.Location = New System.Drawing.Point(69, 153)
        Me.MCBXups.Name = "MCBXups"
        Me.MCBXups.Size = New System.Drawing.Size(162, 21)
        Me.MCBXups.TabIndex = 27
        '
        'MCBXsuc
        '
        Me.MCBXsuc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.MCBXsuc.FormattingEnabled = True
        Me.MCBXsuc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MCBXsuc.Location = New System.Drawing.Point(69, 126)
        Me.MCBXsuc.Name = "MCBXsuc"
        Me.MCBXsuc.Size = New System.Drawing.Size(162, 21)
        Me.MCBXsuc.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(120, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Hora:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "UPS:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Sucursal:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Año:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Mes:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Dia:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(34, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Folio:"
        '
        'MTXTups
        '
        Me.MTXTups.Location = New System.Drawing.Point(69, 154)
        Me.MTXTups.Name = "MTXTups"
        Me.MTXTups.Size = New System.Drawing.Size(161, 20)
        Me.MTXTups.TabIndex = 20
        '
        'MTXTsuc
        '
        Me.MTXTsuc.Location = New System.Drawing.Point(69, 127)
        Me.MTXTsuc.Name = "MTXTsuc"
        Me.MTXTsuc.Size = New System.Drawing.Size(161, 20)
        Me.MTXTsuc.TabIndex = 20
        '
        'MTXThora
        '
        Me.MTXThora.Location = New System.Drawing.Point(157, 71)
        Me.MTXThora.Name = "MTXThora"
        Me.MTXThora.Size = New System.Drawing.Size(59, 20)
        Me.MTXThora.TabIndex = 19
        '
        'MTXTanio
        '
        Me.MTXTanio.Location = New System.Drawing.Point(69, 99)
        Me.MTXTanio.Name = "MTXTanio"
        Me.MTXTanio.Size = New System.Drawing.Size(40, 20)
        Me.MTXTanio.TabIndex = 18
        '
        'MTXTmes
        '
        Me.MTXTmes.Location = New System.Drawing.Point(69, 73)
        Me.MTXTmes.Name = "MTXTmes"
        Me.MTXTmes.Size = New System.Drawing.Size(40, 20)
        Me.MTXTmes.TabIndex = 17
        '
        'MTXTdia
        '
        Me.MTXTdia.Location = New System.Drawing.Point(69, 47)
        Me.MTXTdia.Name = "MTXTdia"
        Me.MTXTdia.Size = New System.Drawing.Size(40, 20)
        Me.MTXTdia.TabIndex = 16
        '
        'MTXTfolio
        '
        Me.MTXTfolio.Location = New System.Drawing.Point(69, 21)
        Me.MTXTfolio.Name = "MTXTfolio"
        Me.MTXTfolio.Size = New System.Drawing.Size(93, 20)
        Me.MTXTfolio.TabIndex = 15
        '
        'AxAcroVisor
        '
        Me.AxAcroVisor.Enabled = True
        Me.AxAcroVisor.Location = New System.Drawing.Point(537, 0)
        Me.AxAcroVisor.Name = "AxAcroVisor"
        Me.AxAcroVisor.OcxState = CType(resources.GetObject("AxAcroVisor.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroVisor.Size = New System.Drawing.Size(346, 430)
        Me.AxAcroVisor.TabIndex = 50
        Me.AxAcroVisor.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(37, 194)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
        Me.CheckBox1.TabIndex = 51
        Me.CheckBox1.Text = "Ver Archivo PDF"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(146, 194)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(73, 17)
        Me.CheckBox2.TabIndex = 51
        Me.CheckBox2.Text = "Ver Datos"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Mantenimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(531, 225)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DGVM)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.AxAcroVisor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Mantenimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimientos"
        CType(Me.DGVM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.AxAcroVisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents DGVM As System.Windows.Forms.DataGridView
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTbuscado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Fin As System.Windows.Forms.Button
    Friend WithEvents Ini As System.Windows.Forms.Button
    Friend WithEvents Sig As System.Windows.Forms.Button
    Friend WithEvents Ant As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MCBXsuc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MTXTsuc As System.Windows.Forms.TextBox
    Friend WithEvents MTXThora As System.Windows.Forms.TextBox
    Friend WithEvents MTXTanio As System.Windows.Forms.TextBox
    Friend WithEvents MTXTmes As System.Windows.Forms.TextBox
    Friend WithEvents MTXTdia As System.Windows.Forms.TextBox
    Friend WithEvents MTXTfolio As System.Windows.Forms.TextBox
    Friend WithEvents MCBXups As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MTXTups As System.Windows.Forms.TextBox
    Friend WithEvents MTXTimg As System.Windows.Forms.TextBox
    Friend WithEvents Examinar As System.Windows.Forms.Button
    Friend WithEvents FoM As System.Windows.Forms.RadioButton
    Friend WithEvents LBLbuscado As System.Windows.Forms.Label
    Friend WithEvents AxAcroVisor As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
End Class
