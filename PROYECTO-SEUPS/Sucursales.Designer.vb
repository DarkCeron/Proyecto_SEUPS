<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sucursales
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
        Me.Ini = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.NeS = New System.Windows.Forms.RadioButton()
        Me.IdS = New System.Windows.Forms.RadioButton()
        Me.NsS = New System.Windows.Forms.RadioButton()
        Me.LBLbuscado = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTbuscado = New System.Windows.Forms.TextBox()
        Me.Ant = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Sig = New System.Windows.Forms.Button()
        Me.DGVS = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Modificar = New System.Windows.Forms.Button()
        Me.Nuevo = New System.Windows.Forms.Button()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.STXTnomempresa = New System.Windows.Forms.TextBox()
        Me.STXTestado = New System.Windows.Forms.TextBox()
        Me.STXTciudad = New System.Windows.Forms.TextBox()
        Me.STXTnsuc = New System.Windows.Forms.TextBox()
        Me.STXTid = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Fin = New System.Windows.Forms.Button()
        Me.STXTcalle = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.STXTtelefonosubgerente = New System.Windows.Forms.TextBox()
        Me.STXTtelefono = New System.Windows.Forms.TextBox()
        Me.STXTnombsuc = New System.Windows.Forms.TextBox()
        Me.STXTnombresubgerente = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.STXTtelefonogerente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.STXTnombregerente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxTab = New System.Windows.Forms.CheckBox()
        Me.GroupBox15.SuspendLayout()
        CType(Me.DGVS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ini
        '
        Me.Ini.Location = New System.Drawing.Point(56, 16)
        Me.Ini.Name = "Ini"
        Me.Ini.Size = New System.Drawing.Size(60, 28)
        Me.Ini.TabIndex = 2
        Me.Ini.Text = "Inicio"
        Me.Ini.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.NeS)
        Me.GroupBox15.Controls.Add(Me.IdS)
        Me.GroupBox15.Controls.Add(Me.NsS)
        Me.GroupBox15.Controls.Add(Me.LBLbuscado)
        Me.GroupBox15.Controls.Add(Me.Label30)
        Me.GroupBox15.Controls.Add(Me.TXTbuscado)
        Me.GroupBox15.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(384, 72)
        Me.GroupBox15.TabIndex = 42
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Búsqueda"
        '
        'NeS
        '
        Me.NeS.AutoSize = True
        Me.NeS.Location = New System.Drawing.Point(250, 49)
        Me.NeS.Name = "NeS"
        Me.NeS.Size = New System.Drawing.Size(105, 17)
        Me.NeS.TabIndex = 6
        Me.NeS.TabStop = True
        Me.NeS.Text = "Nombre empresa"
        Me.NeS.UseVisualStyleBackColor = True
        '
        'IdS
        '
        Me.IdS.AutoSize = True
        Me.IdS.Location = New System.Drawing.Point(250, 12)
        Me.IdS.Name = "IdS"
        Me.IdS.Size = New System.Drawing.Size(76, 17)
        Me.IdS.TabIndex = 5
        Me.IdS.TabStop = True
        Me.IdS.Text = "Id sucursal"
        Me.IdS.UseVisualStyleBackColor = True
        '
        'NsS
        '
        Me.NsS.AutoSize = True
        Me.NsS.Location = New System.Drawing.Point(250, 31)
        Me.NsS.Name = "NsS"
        Me.NsS.Size = New System.Drawing.Size(104, 17)
        Me.NsS.TabIndex = 4
        Me.NsS.TabStop = True
        Me.NsS.Text = "Nombre sucursal"
        Me.NsS.UseVisualStyleBackColor = True
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
        Me.TXTbuscado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TXTbuscado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TXTbuscado.Location = New System.Drawing.Point(14, 37)
        Me.TXTbuscado.Name = "TXTbuscado"
        Me.TXTbuscado.Size = New System.Drawing.Size(217, 20)
        Me.TXTbuscado.TabIndex = 0
        '
        'Ant
        '
        Me.Ant.Location = New System.Drawing.Point(122, 17)
        Me.Ant.Name = "Ant"
        Me.Ant.Size = New System.Drawing.Size(60, 28)
        Me.Ant.TabIndex = 0
        Me.Ant.Text = "Anterior"
        Me.Ant.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Nombre Empresa Sucursal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(54, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Estado Sucursal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(54, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Ciudad Sucursal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(49, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Número Sucursal"
        '
        'Sig
        '
        Me.Sig.Location = New System.Drawing.Point(186, 17)
        Me.Sig.Name = "Sig"
        Me.Sig.Size = New System.Drawing.Size(60, 28)
        Me.Sig.TabIndex = 1
        Me.Sig.Text = "Siguiente"
        Me.Sig.UseVisualStyleBackColor = True
        '
        'DGVS
        '
        Me.DGVS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVS.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGVS.GridColor = System.Drawing.Color.Gold
        Me.DGVS.Location = New System.Drawing.Point(0, 131)
        Me.DGVS.Name = "DGVS"
        Me.DGVS.ReadOnly = True
        Me.DGVS.Size = New System.Drawing.Size(739, 175)
        Me.DGVS.TabIndex = 41
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Eliminar)
        Me.GroupBox5.Controls.Add(Me.Modificar)
        Me.GroupBox5.Controls.Add(Me.Nuevo)
        Me.GroupBox5.Controls.Add(Me.Agregar)
        Me.GroupBox5.Controls.Add(Me.Cancelar)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 136)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(384, 53)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Acciones"
        '
        'Eliminar
        '
        Me.Eliminar.Location = New System.Drawing.Point(228, 19)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(71, 24)
        Me.Eliminar.TabIndex = 3
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Modificar
        '
        Me.Modificar.Location = New System.Drawing.Point(151, 19)
        Me.Modificar.Name = "Modificar"
        Me.Modificar.Size = New System.Drawing.Size(71, 24)
        Me.Modificar.TabIndex = 1
        Me.Modificar.Text = "Modificar"
        Me.Modificar.UseVisualStyleBackColor = True
        '
        'Nuevo
        '
        Me.Nuevo.Location = New System.Drawing.Point(74, 19)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(71, 24)
        Me.Nuevo.TabIndex = 0
        Me.Nuevo.Text = "Nuevo"
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'Agregar
        '
        Me.Agregar.Location = New System.Drawing.Point(118, 18)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(66, 27)
        Me.Agregar.TabIndex = 14
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'Cancelar
        '
        Me.Cancelar.Location = New System.Drawing.Point(202, 19)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(66, 24)
        Me.Cancelar.TabIndex = 4
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(62, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Calle sucursal:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(74, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Id Sucursal:"
        '
        'STXTnomempresa
        '
        Me.STXTnomempresa.Location = New System.Drawing.Point(140, 123)
        Me.STXTnomempresa.Name = "STXTnomempresa"
        Me.STXTnomempresa.Size = New System.Drawing.Size(178, 20)
        Me.STXTnomempresa.TabIndex = 20
        '
        'STXTestado
        '
        Me.STXTestado.Location = New System.Drawing.Point(140, 101)
        Me.STXTestado.Name = "STXTestado"
        Me.STXTestado.Size = New System.Drawing.Size(178, 20)
        Me.STXTestado.TabIndex = 19
        '
        'STXTciudad
        '
        Me.STXTciudad.Location = New System.Drawing.Point(140, 79)
        Me.STXTciudad.Name = "STXTciudad"
        Me.STXTciudad.Size = New System.Drawing.Size(178, 20)
        Me.STXTciudad.TabIndex = 18
        '
        'STXTnsuc
        '
        Me.STXTnsuc.Location = New System.Drawing.Point(140, 57)
        Me.STXTnsuc.Name = "STXTnsuc"
        Me.STXTnsuc.Size = New System.Drawing.Size(178, 20)
        Me.STXTnsuc.TabIndex = 17
        '
        'STXTid
        '
        Me.STXTid.Location = New System.Drawing.Point(140, 13)
        Me.STXTid.Name = "STXTid"
        Me.STXTid.Size = New System.Drawing.Size(178, 20)
        Me.STXTid.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Fin)
        Me.GroupBox4.Controls.Add(Me.Ini)
        Me.GroupBox4.Controls.Add(Me.Sig)
        Me.GroupBox4.Controls.Add(Me.Ant)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 82)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(384, 51)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Desplazamientos"
        '
        'Fin
        '
        Me.Fin.Location = New System.Drawing.Point(250, 17)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(60, 28)
        Me.Fin.TabIndex = 3
        Me.Fin.Text = "Fin"
        Me.Fin.UseVisualStyleBackColor = True
        '
        'STXTcalle
        '
        Me.STXTcalle.Location = New System.Drawing.Point(140, 35)
        Me.STXTcalle.Name = "STXTcalle"
        Me.STXTcalle.Size = New System.Drawing.Size(178, 20)
        Me.STXTcalle.TabIndex = 16
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.STXTtelefonosubgerente)
        Me.GroupBox3.Controls.Add(Me.STXTtelefono)
        Me.GroupBox3.Controls.Add(Me.STXTnombsuc)
        Me.GroupBox3.Controls.Add(Me.STXTnombresubgerente)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.STXTtelefonogerente)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.STXTnombregerente)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.STXTnomempresa)
        Me.GroupBox3.Controls.Add(Me.STXTestado)
        Me.GroupBox3.Controls.Add(Me.STXTciudad)
        Me.GroupBox3.Controls.Add(Me.STXTnsuc)
        Me.GroupBox3.Controls.Add(Me.STXTcalle)
        Me.GroupBox3.Controls.Add(Me.STXTid)
        Me.GroupBox3.Location = New System.Drawing.Point(398, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(329, 290)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'STXTtelefonosubgerente
        '
        Me.STXTtelefonosubgerente.Location = New System.Drawing.Point(140, 255)
        Me.STXTtelefonosubgerente.Name = "STXTtelefonosubgerente"
        Me.STXTtelefonosubgerente.Size = New System.Drawing.Size(178, 20)
        Me.STXTtelefonosubgerente.TabIndex = 38
        '
        'STXTtelefono
        '
        Me.STXTtelefono.Location = New System.Drawing.Point(140, 167)
        Me.STXTtelefono.Name = "STXTtelefono"
        Me.STXTtelefono.Size = New System.Drawing.Size(178, 20)
        Me.STXTtelefono.TabIndex = 34
        '
        'STXTnombsuc
        '
        Me.STXTnombsuc.Location = New System.Drawing.Point(140, 145)
        Me.STXTnombsuc.Name = "STXTnombsuc"
        Me.STXTnombsuc.Size = New System.Drawing.Size(178, 20)
        Me.STXTnombsuc.TabIndex = 33
        '
        'STXTnombresubgerente
        '
        Me.STXTnombresubgerente.Location = New System.Drawing.Point(140, 233)
        Me.STXTnombresubgerente.Name = "STXTnombresubgerente"
        Me.STXTnombresubgerente.Size = New System.Drawing.Size(178, 20)
        Me.STXTnombresubgerente.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 258)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Teléfono SubGerente"
        '
        'STXTtelefonogerente
        '
        Me.STXTtelefonogerente.Location = New System.Drawing.Point(140, 211)
        Me.STXTtelefonogerente.Name = "STXTtelefonogerente"
        Me.STXTtelefonogerente.Size = New System.Drawing.Size(178, 20)
        Me.STXTtelefonogerente.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Teléfono Gerente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 236)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Nombre SubGerente"
        '
        'STXTnombregerente
        '
        Me.STXTnombregerente.Location = New System.Drawing.Point(140, 189)
        Me.STXTnombregerente.Name = "STXTnombregerente"
        Me.STXTnombregerente.Size = New System.Drawing.Size(178, 20)
        Me.STXTnombregerente.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Nombre Gerente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Teléfono Sucursal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Nombre Sucursal"
        '
        'CheckBoxTab
        '
        Me.CheckBoxTab.AutoSize = True
        Me.CheckBoxTab.Location = New System.Drawing.Point(9, 282)
        Me.CheckBoxTab.Name = "CheckBoxTab"
        Me.CheckBoxTab.Size = New System.Drawing.Size(76, 17)
        Me.CheckBoxTab.TabIndex = 43
        Me.CheckBoxTab.Text = "Ver Datos."
        Me.CheckBoxTab.UseVisualStyleBackColor = True
        '
        'Sucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(739, 306)
        Me.Controls.Add(Me.CheckBoxTab)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.DGVS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Sucursales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursales"
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.DGVS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ini As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents NeS As System.Windows.Forms.RadioButton
    Friend WithEvents IdS As System.Windows.Forms.RadioButton
    Friend WithEvents NsS As System.Windows.Forms.RadioButton
    Friend WithEvents LBLbuscado As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTbuscado As System.Windows.Forms.TextBox
    Friend WithEvents Ant As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Sig As System.Windows.Forms.Button
    Friend WithEvents DGVS As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Cancelar As System.Windows.Forms.Button
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents Modificar As System.Windows.Forms.Button
    Friend WithEvents Nuevo As System.Windows.Forms.Button
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents STXTnomempresa As System.Windows.Forms.TextBox
    Friend WithEvents STXTestado As System.Windows.Forms.TextBox
    Friend WithEvents STXTciudad As System.Windows.Forms.TextBox
    Friend WithEvents STXTnsuc As System.Windows.Forms.TextBox
    Friend WithEvents STXTid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Fin As System.Windows.Forms.Button
    Friend WithEvents STXTcalle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents STXTtelefonosubgerente As System.Windows.Forms.TextBox
    Friend WithEvents STXTtelefono As System.Windows.Forms.TextBox
    Friend WithEvents STXTnombsuc As System.Windows.Forms.TextBox
    Friend WithEvents STXTnombresubgerente As System.Windows.Forms.TextBox
    Friend WithEvents STXTtelefonogerente As System.Windows.Forms.TextBox
    Friend WithEvents STXTnombregerente As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxTab As System.Windows.Forms.CheckBox
End Class
