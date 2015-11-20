<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programa
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PTXTidsuc = New System.Windows.Forms.TextBox()
        Me.PTXTanio = New System.Windows.Forms.TextBox()
        Me.PTXTmes = New System.Windows.Forms.TextBox()
        Me.PTXTid = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PTXThora = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP = New System.Windows.Forms.DateTimePicker()
        Me.PCBXsuc = New System.Windows.Forms.ComboBox()
        Me.PTXTdia = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Fin = New System.Windows.Forms.Button()
        Me.Ini = New System.Windows.Forms.Button()
        Me.Sig = New System.Windows.Forms.Button()
        Me.Ant = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.SuP = New System.Windows.Forms.RadioButton()
        Me.LBLbuscado = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTbuscado = New System.Windows.Forms.TextBox()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.DGVP = New System.Windows.Forms.DataGridView()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Modificar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Nuevo = New System.Windows.Forms.Button()
        Me.CheckBoxTab = New System.Windows.Forms.CheckBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.DGVP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(221, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Hora:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Sucursal:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Id Programado:"
        '
        'PTXTidsuc
        '
        Me.PTXTidsuc.Location = New System.Drawing.Point(77, 73)
        Me.PTXTidsuc.Name = "PTXTidsuc"
        Me.PTXTidsuc.Size = New System.Drawing.Size(136, 20)
        Me.PTXTidsuc.TabIndex = 20
        '
        'PTXTanio
        '
        Me.PTXTanio.Location = New System.Drawing.Point(173, 171)
        Me.PTXTanio.Name = "PTXTanio"
        Me.PTXTanio.Size = New System.Drawing.Size(40, 20)
        Me.PTXTanio.TabIndex = 18
        '
        'PTXTmes
        '
        Me.PTXTmes.Location = New System.Drawing.Point(127, 171)
        Me.PTXTmes.Name = "PTXTmes"
        Me.PTXTmes.Size = New System.Drawing.Size(40, 20)
        Me.PTXTmes.TabIndex = 17
        '
        'PTXTid
        '
        Me.PTXTid.Location = New System.Drawing.Point(105, 19)
        Me.PTXTid.Name = "PTXTid"
        Me.PTXTid.Size = New System.Drawing.Size(191, 20)
        Me.PTXTid.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PTXThora)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.DTP)
        Me.GroupBox3.Controls.Add(Me.PCBXsuc)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.PTXTidsuc)
        Me.GroupBox3.Controls.Add(Me.PTXTanio)
        Me.GroupBox3.Controls.Add(Me.PTXTmes)
        Me.GroupBox3.Controls.Add(Me.PTXTdia)
        Me.GroupBox3.Controls.Add(Me.PTXTid)
        Me.GroupBox3.Location = New System.Drawing.Point(393, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(306, 113)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'PTXThora
        '
        Me.PTXThora.Location = New System.Drawing.Point(262, 73)
        Me.PTXThora.Mask = "00:00"
        Me.PTXThora.Name = "PTXThora"
        Me.PTXThora.Size = New System.Drawing.Size(34, 20)
        Me.PTXThora.TabIndex = 30
        Me.PTXThora.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Fecha"
        '
        'DTP
        '
        Me.DTP.Location = New System.Drawing.Point(65, 45)
        Me.DTP.Name = "DTP"
        Me.DTP.Size = New System.Drawing.Size(231, 20)
        Me.DTP.TabIndex = 28
        '
        'PCBXsuc
        '
        Me.PCBXsuc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PCBXsuc.FormattingEnabled = True
        Me.PCBXsuc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PCBXsuc.Location = New System.Drawing.Point(77, 73)
        Me.PCBXsuc.Name = "PCBXsuc"
        Me.PCBXsuc.Size = New System.Drawing.Size(136, 21)
        Me.PCBXsuc.TabIndex = 27
        '
        'PTXTdia
        '
        Me.PTXTdia.Location = New System.Drawing.Point(83, 171)
        Me.PTXTdia.Name = "PTXTdia"
        Me.PTXTdia.Size = New System.Drawing.Size(40, 20)
        Me.PTXTdia.TabIndex = 16
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Fin)
        Me.GroupBox4.Controls.Add(Me.Ini)
        Me.GroupBox4.Controls.Add(Me.Sig)
        Me.GroupBox4.Controls.Add(Me.Ant)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 82)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(384, 53)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Desplazamientos"
        '
        'Fin
        '
        Me.Fin.Location = New System.Drawing.Point(222, 18)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(64, 26)
        Me.Fin.TabIndex = 3
        Me.Fin.Text = "Fin"
        Me.Fin.UseVisualStyleBackColor = True
        '
        'Ini
        '
        Me.Ini.Location = New System.Drawing.Point(6, 19)
        Me.Ini.Name = "Ini"
        Me.Ini.Size = New System.Drawing.Size(64, 26)
        Me.Ini.TabIndex = 2
        Me.Ini.Text = "Inicio"
        Me.Ini.UseVisualStyleBackColor = True
        '
        'Sig
        '
        Me.Sig.Location = New System.Drawing.Point(150, 19)
        Me.Sig.Name = "Sig"
        Me.Sig.Size = New System.Drawing.Size(64, 26)
        Me.Sig.TabIndex = 1
        Me.Sig.Text = "Siguiente"
        Me.Sig.UseVisualStyleBackColor = True
        '
        'Ant
        '
        Me.Ant.Location = New System.Drawing.Point(78, 19)
        Me.Ant.Name = "Ant"
        Me.Ant.Size = New System.Drawing.Size(64, 26)
        Me.Ant.TabIndex = 0
        Me.Ant.Text = "Anterior"
        Me.Ant.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.SuP)
        Me.GroupBox15.Controls.Add(Me.LBLbuscado)
        Me.GroupBox15.Controls.Add(Me.Label30)
        Me.GroupBox15.Controls.Add(Me.TXTbuscado)
        Me.GroupBox15.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(384, 74)
        Me.GroupBox15.TabIndex = 42
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Búsqueda"
        '
        'SuP
        '
        Me.SuP.AutoSize = True
        Me.SuP.Location = New System.Drawing.Point(256, 38)
        Me.SuP.Name = "SuP"
        Me.SuP.Size = New System.Drawing.Size(76, 17)
        Me.SuP.TabIndex = 6
        Me.SuP.TabStop = True
        Me.SuP.Text = "Id sucursal" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.SuP.UseVisualStyleBackColor = True
        '
        'LBLbuscado
        '
        Me.LBLbuscado.AutoSize = True
        Me.LBLbuscado.Location = New System.Drawing.Point(93, 21)
        Me.LBLbuscado.Name = "LBLbuscado"
        Me.LBLbuscado.Size = New System.Drawing.Size(58, 13)
        Me.LBLbuscado.TabIndex = 3
        Me.LBLbuscado.Text = "-----------------"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(11, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 13)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Búsqueda por:"
        '
        'TXTbuscado
        '
        Me.TXTbuscado.Location = New System.Drawing.Point(14, 37)
        Me.TXTbuscado.Name = "TXTbuscado"
        Me.TXTbuscado.Size = New System.Drawing.Size(217, 20)
        Me.TXTbuscado.TabIndex = 0
        '
        'Agregar
        '
        Me.Agregar.Location = New System.Drawing.Point(99, 16)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(66, 24)
        Me.Agregar.TabIndex = 14
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'DGVP
        '
        Me.DGVP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGVP.Location = New System.Drawing.Point(0, 28)
        Me.DGVP.Name = "DGVP"
        Me.DGVP.ReadOnly = True
        Me.DGVP.Size = New System.Drawing.Size(709, 188)
        Me.DGVP.TabIndex = 41
        '
        'Cancelar
        '
        Me.Cancelar.Location = New System.Drawing.Point(184, 16)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(66, 24)
        Me.Cancelar.TabIndex = 4
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Location = New System.Drawing.Point(224, 16)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(71, 24)
        Me.Eliminar.TabIndex = 3
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Modificar
        '
        Me.Modificar.Location = New System.Drawing.Point(132, 16)
        Me.Modificar.Name = "Modificar"
        Me.Modificar.Size = New System.Drawing.Size(71, 24)
        Me.Modificar.TabIndex = 1
        Me.Modificar.Text = "Modificar"
        Me.Modificar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Cancelar)
        Me.GroupBox5.Controls.Add(Me.Eliminar)
        Me.GroupBox5.Controls.Add(Me.Modificar)
        Me.GroupBox5.Controls.Add(Me.Nuevo)
        Me.GroupBox5.Controls.Add(Me.Agregar)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 144)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(384, 49)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Acciones"
        '
        'Nuevo
        '
        Me.Nuevo.Location = New System.Drawing.Point(51, 16)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(71, 24)
        Me.Nuevo.TabIndex = 0
        Me.Nuevo.Text = "Nuevo"
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'CheckBoxTab
        '
        Me.CheckBoxTab.AutoSize = True
        Me.CheckBoxTab.Location = New System.Drawing.Point(3, 197)
        Me.CheckBoxTab.Name = "CheckBoxTab"
        Me.CheckBoxTab.Size = New System.Drawing.Size(76, 17)
        Me.CheckBoxTab.TabIndex = 44
        Me.CheckBoxTab.Text = "Ver Datos."
        Me.CheckBoxTab.UseVisualStyleBackColor = True
        '
        'Programa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(709, 216)
        Me.Controls.Add(Me.CheckBoxTab)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.DGVP)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Programa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programa"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.DGVP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PTXTidsuc As System.Windows.Forms.TextBox
    Friend WithEvents PTXTanio As System.Windows.Forms.TextBox
    Friend WithEvents PTXTmes As System.Windows.Forms.TextBox
    Friend WithEvents PTXTid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PTXTdia As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Fin As System.Windows.Forms.Button
    Friend WithEvents Ini As System.Windows.Forms.Button
    Friend WithEvents Sig As System.Windows.Forms.Button
    Friend WithEvents Ant As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents SuP As System.Windows.Forms.RadioButton
    Friend WithEvents LBLbuscado As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTbuscado As System.Windows.Forms.TextBox
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents DGVP As System.Windows.Forms.DataGridView
    Friend WithEvents Cancelar As System.Windows.Forms.Button
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents Modificar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Nuevo As System.Windows.Forms.Button
    Friend WithEvents PCBXsuc As System.Windows.Forms.ComboBox
    Friend WithEvents DTP As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxTab As System.Windows.Forms.CheckBox
    Friend WithEvents PTXThora As System.Windows.Forms.MaskedTextBox
End Class
