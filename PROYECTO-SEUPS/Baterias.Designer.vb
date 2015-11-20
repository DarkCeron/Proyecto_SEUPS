<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Baterias
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
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.MaB = New System.Windows.Forms.RadioButton()
        Me.CaB = New System.Windows.Forms.RadioButton()
        Me.MoB = New System.Windows.Forms.RadioButton()
        Me.LBLbuscado = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTbuscado = New System.Windows.Forms.TextBox()
        Me.DGVB = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Modificar = New System.Windows.Forms.Button()
        Me.Nuevo = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Fin = New System.Windows.Forms.Button()
        Me.Ini = New System.Windows.Forms.Button()
        Me.Sig = New System.Windows.Forms.Button()
        Me.Ant = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BTXTcapa = New System.Windows.Forms.TextBox()
        Me.BTXTcant = New System.Windows.Forms.TextBox()
        Me.BTXTmarca = New System.Windows.Forms.TextBox()
        Me.BTXTserie = New System.Windows.Forms.TextBox()
        Me.BTXTmod = New System.Windows.Forms.TextBox()
        Me.BTXTid = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox15.SuspendLayout()
        CType(Me.DGVB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.MaB)
        Me.GroupBox15.Controls.Add(Me.CaB)
        Me.GroupBox15.Controls.Add(Me.MoB)
        Me.GroupBox15.Controls.Add(Me.LBLbuscado)
        Me.GroupBox15.Controls.Add(Me.Label30)
        Me.GroupBox15.Controls.Add(Me.TXTbuscado)
        Me.GroupBox15.Location = New System.Drawing.Point(6, 8)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(297, 61)
        Me.GroupBox15.TabIndex = 0
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Búsqueda"
        '
        'MaB
        '
        Me.MaB.AutoSize = True
        Me.MaB.Location = New System.Drawing.Point(173, 23)
        Me.MaB.Name = "MaB"
        Me.MaB.Size = New System.Drawing.Size(92, 17)
        Me.MaB.TabIndex = 3
        Me.MaB.TabStop = True
        Me.MaB.Text = "Marca batería"
        Me.MaB.UseVisualStyleBackColor = True
        '
        'CaB
        '
        Me.CaB.AutoSize = True
        Me.CaB.Location = New System.Drawing.Point(173, 40)
        Me.CaB.Name = "CaB"
        Me.CaB.Size = New System.Drawing.Size(113, 17)
        Me.CaB.TabIndex = 4
        Me.CaB.TabStop = True
        Me.CaB.Text = "Capacidad batería"
        Me.CaB.UseVisualStyleBackColor = True
        '
        'MoB
        '
        Me.MoB.AutoSize = True
        Me.MoB.Location = New System.Drawing.Point(173, 6)
        Me.MoB.Name = "MoB"
        Me.MoB.Size = New System.Drawing.Size(97, 17)
        Me.MoB.TabIndex = 2
        Me.MoB.TabStop = True
        Me.MoB.Text = "Modelo batería"
        Me.MoB.UseVisualStyleBackColor = True
        '
        'LBLbuscado
        '
        Me.LBLbuscado.AutoSize = True
        Me.LBLbuscado.Location = New System.Drawing.Point(78, 21)
        Me.LBLbuscado.Name = "LBLbuscado"
        Me.LBLbuscado.Size = New System.Drawing.Size(58, 13)
        Me.LBLbuscado.TabIndex = 3
        Me.LBLbuscado.Text = "-----------------"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 21)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Busqueda por:"
        '
        'TXTbuscado
        '
        Me.TXTbuscado.Location = New System.Drawing.Point(9, 37)
        Me.TXTbuscado.Name = "TXTbuscado"
        Me.TXTbuscado.Size = New System.Drawing.Size(158, 20)
        Me.TXTbuscado.TabIndex = 1
        '
        'DGVB
        '
        Me.DGVB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGVB.Location = New System.Drawing.Point(0, 45)
        Me.DGVB.Name = "DGVB"
        Me.DGVB.ReadOnly = True
        Me.DGVB.Size = New System.Drawing.Size(653, 163)
        Me.DGVB.TabIndex = 0
        Me.DGVB.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Cancelar)
        Me.GroupBox5.Controls.Add(Me.Agregar)
        Me.GroupBox5.Controls.Add(Me.Eliminar)
        Me.GroupBox5.Controls.Add(Me.Modificar)
        Me.GroupBox5.Controls.Add(Me.Nuevo)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 136)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(296, 53)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Acciones"
        '
        'Cancelar
        '
        Me.Cancelar.Location = New System.Drawing.Point(139, 19)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(66, 24)
        Me.Cancelar.TabIndex = 4
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'Agregar
        '
        Me.Agregar.Location = New System.Drawing.Point(58, 19)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(66, 24)
        Me.Agregar.TabIndex = 3
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Location = New System.Drawing.Point(169, 18)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(71, 24)
        Me.Eliminar.TabIndex = 2
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Modificar
        '
        Me.Modificar.Location = New System.Drawing.Point(92, 18)
        Me.Modificar.Name = "Modificar"
        Me.Modificar.Size = New System.Drawing.Size(71, 24)
        Me.Modificar.TabIndex = 1
        Me.Modificar.Text = "Modificar"
        Me.Modificar.UseVisualStyleBackColor = True
        '
        'Nuevo
        '
        Me.Nuevo.Location = New System.Drawing.Point(15, 18)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(71, 24)
        Me.Nuevo.TabIndex = 0
        Me.Nuevo.Text = "Nuevo"
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Fin)
        Me.GroupBox4.Controls.Add(Me.Ini)
        Me.GroupBox4.Controls.Add(Me.Sig)
        Me.GroupBox4.Controls.Add(Me.Ant)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 77)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(296, 55)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Desplazamientos"
        '
        'Fin
        '
        Me.Fin.Location = New System.Drawing.Point(220, 21)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(69, 24)
        Me.Fin.TabIndex = 3
        Me.Fin.Text = "Fin"
        Me.Fin.UseVisualStyleBackColor = True
        '
        'Ini
        '
        Me.Ini.Location = New System.Drawing.Point(6, 21)
        Me.Ini.Name = "Ini"
        Me.Ini.Size = New System.Drawing.Size(69, 24)
        Me.Ini.TabIndex = 0
        Me.Ini.Text = "Inicio"
        Me.Ini.UseVisualStyleBackColor = True
        '
        'Sig
        '
        Me.Sig.Location = New System.Drawing.Point(149, 21)
        Me.Sig.Name = "Sig"
        Me.Sig.Size = New System.Drawing.Size(69, 24)
        Me.Sig.TabIndex = 2
        Me.Sig.Text = "Siguiente"
        Me.Sig.UseVisualStyleBackColor = True
        '
        'Ant
        '
        Me.Ant.Location = New System.Drawing.Point(77, 21)
        Me.Ant.Name = "Ant"
        Me.Ant.Size = New System.Drawing.Size(69, 24)
        Me.Ant.TabIndex = 1
        Me.Ant.Text = "Anterior"
        Me.Ant.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.BTXTcapa)
        Me.GroupBox3.Controls.Add(Me.BTXTcant)
        Me.GroupBox3.Controls.Add(Me.BTXTmarca)
        Me.GroupBox3.Controls.Add(Me.BTXTserie)
        Me.GroupBox3.Controls.Add(Me.BTXTmod)
        Me.GroupBox3.Controls.Add(Me.BTXTid)
        Me.GroupBox3.Location = New System.Drawing.Point(309, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(329, 189)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Cantidad batería:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Capacidad batería:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Marca batería:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(45, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Serie batería:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(34, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Modelo batería:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(60, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Id batería:"
        '
        'BTXTcapa
        '
        Me.BTXTcapa.Location = New System.Drawing.Point(137, 123)
        Me.BTXTcapa.Name = "BTXTcapa"
        Me.BTXTcapa.Size = New System.Drawing.Size(178, 20)
        Me.BTXTcapa.TabIndex = 4
        '
        'BTXTcant
        '
        Me.BTXTcant.Location = New System.Drawing.Point(137, 149)
        Me.BTXTcant.Name = "BTXTcant"
        Me.BTXTcant.Size = New System.Drawing.Size(178, 20)
        Me.BTXTcant.TabIndex = 5
        '
        'BTXTmarca
        '
        Me.BTXTmarca.Location = New System.Drawing.Point(137, 97)
        Me.BTXTmarca.Name = "BTXTmarca"
        Me.BTXTmarca.Size = New System.Drawing.Size(178, 20)
        Me.BTXTmarca.TabIndex = 3
        '
        'BTXTserie
        '
        Me.BTXTserie.Location = New System.Drawing.Point(137, 71)
        Me.BTXTserie.Name = "BTXTserie"
        Me.BTXTserie.Size = New System.Drawing.Size(178, 20)
        Me.BTXTserie.TabIndex = 2
        '
        'BTXTmod
        '
        Me.BTXTmod.Location = New System.Drawing.Point(137, 45)
        Me.BTXTmod.Name = "BTXTmod"
        Me.BTXTmod.Size = New System.Drawing.Size(178, 20)
        Me.BTXTmod.TabIndex = 1
        '
        'BTXTid
        '
        Me.BTXTid.Location = New System.Drawing.Point(137, 19)
        Me.BTXTid.Name = "BTXTid"
        Me.BTXTid.Size = New System.Drawing.Size(178, 20)
        Me.BTXTid.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(7, 191)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(73, 17)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Ver Datos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Baterias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(653, 208)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.DGVB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Baterias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Baterías"
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.DGVB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents MaB As System.Windows.Forms.RadioButton
    Friend WithEvents CaB As System.Windows.Forms.RadioButton
    Friend WithEvents MoB As System.Windows.Forms.RadioButton
    Friend WithEvents LBLbuscado As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTbuscado As System.Windows.Forms.TextBox
    Friend WithEvents DGVB As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Cancelar As System.Windows.Forms.Button
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents Modificar As System.Windows.Forms.Button
    Friend WithEvents Nuevo As System.Windows.Forms.Button
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Fin As System.Windows.Forms.Button
    Friend WithEvents Ini As System.Windows.Forms.Button
    Friend WithEvents Sig As System.Windows.Forms.Button
    Friend WithEvents Ant As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BTXTcapa As System.Windows.Forms.TextBox
    Friend WithEvents BTXTcant As System.Windows.Forms.TextBox
    Friend WithEvents BTXTmarca As System.Windows.Forms.TextBox
    Friend WithEvents BTXTserie As System.Windows.Forms.TextBox
    Friend WithEvents BTXTmod As System.Windows.Forms.TextBox
    Friend WithEvents BTXTid As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
