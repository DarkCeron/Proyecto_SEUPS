<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UPSs
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UTXTmodelo = New System.Windows.Forms.TextBox()
        Me.UTXTidbat = New System.Windows.Forms.TextBox()
        Me.UTXTmarca = New System.Windows.Forms.TextBox()
        Me.UTXTserie = New System.Windows.Forms.TextBox()
        Me.UTXTid = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.UCBXsuc = New System.Windows.Forms.ComboBox()
        Me.UCBXbat = New System.Windows.Forms.ComboBox()
        Me.UTXTidsuc = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Fin = New System.Windows.Forms.Button()
        Me.Ini = New System.Windows.Forms.Button()
        Me.Sig = New System.Windows.Forms.Button()
        Me.Ant = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.IsU = New System.Windows.Forms.RadioButton()
        Me.IbU = New System.Windows.Forms.RadioButton()
        Me.IuU = New System.Windows.Forms.RadioButton()
        Me.LBLbuscado = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXTbuscado = New System.Windows.Forms.TextBox()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.DGVU = New System.Windows.Forms.DataGridView()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Modificar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Nuevo = New System.Windows.Forms.Button()
        Me.CheckBoxtab = New System.Windows.Forms.CheckBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.DGVU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "ID Batería:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Modelo ups:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(52, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Marca ups:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Serie ups:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "ID sucursal:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(74, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Id ups:"
        '
        'UTXTmodelo
        '
        Me.UTXTmodelo.Location = New System.Drawing.Point(137, 123)
        Me.UTXTmodelo.Name = "UTXTmodelo"
        Me.UTXTmodelo.Size = New System.Drawing.Size(178, 20)
        Me.UTXTmodelo.TabIndex = 20
        '
        'UTXTidbat
        '
        Me.UTXTidbat.Location = New System.Drawing.Point(137, 149)
        Me.UTXTidbat.Name = "UTXTidbat"
        Me.UTXTidbat.Size = New System.Drawing.Size(178, 20)
        Me.UTXTidbat.TabIndex = 19
        '
        'UTXTmarca
        '
        Me.UTXTmarca.Location = New System.Drawing.Point(137, 97)
        Me.UTXTmarca.Name = "UTXTmarca"
        Me.UTXTmarca.Size = New System.Drawing.Size(178, 20)
        Me.UTXTmarca.TabIndex = 18
        '
        'UTXTserie
        '
        Me.UTXTserie.Location = New System.Drawing.Point(137, 71)
        Me.UTXTserie.Name = "UTXTserie"
        Me.UTXTserie.Size = New System.Drawing.Size(178, 20)
        Me.UTXTserie.TabIndex = 17
        '
        'UTXTid
        '
        Me.UTXTid.Location = New System.Drawing.Point(137, 19)
        Me.UTXTid.Name = "UTXTid"
        Me.UTXTid.Size = New System.Drawing.Size(178, 20)
        Me.UTXTid.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.UCBXsuc)
        Me.GroupBox3.Controls.Add(Me.UCBXbat)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.UTXTmodelo)
        Me.GroupBox3.Controls.Add(Me.UTXTidbat)
        Me.GroupBox3.Controls.Add(Me.UTXTmarca)
        Me.GroupBox3.Controls.Add(Me.UTXTserie)
        Me.GroupBox3.Controls.Add(Me.UTXTidsuc)
        Me.GroupBox3.Controls.Add(Me.UTXTid)
        Me.GroupBox3.Location = New System.Drawing.Point(400, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(329, 189)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'UCBXsuc
        '
        Me.UCBXsuc.FormattingEnabled = True
        Me.UCBXsuc.Location = New System.Drawing.Point(137, 45)
        Me.UCBXsuc.Name = "UCBXsuc"
        Me.UCBXsuc.Size = New System.Drawing.Size(178, 21)
        Me.UCBXsuc.TabIndex = 29
        '
        'UCBXbat
        '
        Me.UCBXbat.FormattingEnabled = True
        Me.UCBXbat.Location = New System.Drawing.Point(137, 148)
        Me.UCBXbat.Name = "UCBXbat"
        Me.UCBXbat.Size = New System.Drawing.Size(178, 21)
        Me.UCBXbat.TabIndex = 28
        '
        'UTXTidsuc
        '
        Me.UTXTidsuc.Location = New System.Drawing.Point(137, 45)
        Me.UTXTidsuc.Name = "UTXTidsuc"
        Me.UTXTidsuc.Size = New System.Drawing.Size(178, 20)
        Me.UTXTidsuc.TabIndex = 16
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Fin)
        Me.GroupBox4.Controls.Add(Me.Ini)
        Me.GroupBox4.Controls.Add(Me.Sig)
        Me.GroupBox4.Controls.Add(Me.Ant)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 79)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(384, 51)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Desplazamientos"
        '
        'Fin
        '
        Me.Fin.Location = New System.Drawing.Point(252, 18)
        Me.Fin.Name = "Fin"
        Me.Fin.Size = New System.Drawing.Size(73, 24)
        Me.Fin.TabIndex = 3
        Me.Fin.Text = "Fin"
        Me.Fin.UseVisualStyleBackColor = True
        '
        'Ini
        '
        Me.Ini.Location = New System.Drawing.Point(14, 18)
        Me.Ini.Name = "Ini"
        Me.Ini.Size = New System.Drawing.Size(73, 24)
        Me.Ini.TabIndex = 2
        Me.Ini.Text = "Inicio"
        Me.Ini.UseVisualStyleBackColor = True
        '
        'Sig
        '
        Me.Sig.Location = New System.Drawing.Point(171, 18)
        Me.Sig.Name = "Sig"
        Me.Sig.Size = New System.Drawing.Size(73, 24)
        Me.Sig.TabIndex = 1
        Me.Sig.Text = "Siguiente"
        Me.Sig.UseVisualStyleBackColor = True
        '
        'Ant
        '
        Me.Ant.Location = New System.Drawing.Point(92, 18)
        Me.Ant.Name = "Ant"
        Me.Ant.Size = New System.Drawing.Size(73, 24)
        Me.Ant.TabIndex = 0
        Me.Ant.Text = "Anterior"
        Me.Ant.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.IsU)
        Me.GroupBox15.Controls.Add(Me.IbU)
        Me.GroupBox15.Controls.Add(Me.IuU)
        Me.GroupBox15.Controls.Add(Me.LBLbuscado)
        Me.GroupBox15.Controls.Add(Me.Label30)
        Me.GroupBox15.Controls.Add(Me.TXTbuscado)
        Me.GroupBox15.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(384, 75)
        Me.GroupBox15.TabIndex = 42
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Búsqueda"
        '
        'IsU
        '
        Me.IsU.AutoSize = True
        Me.IsU.Location = New System.Drawing.Point(254, 30)
        Me.IsU.Name = "IsU"
        Me.IsU.Size = New System.Drawing.Size(76, 17)
        Me.IsU.TabIndex = 6
        Me.IsU.TabStop = True
        Me.IsU.Text = "Id sucursal"
        Me.IsU.UseVisualStyleBackColor = True
        '
        'IbU
        '
        Me.IbU.AutoSize = True
        Me.IbU.Location = New System.Drawing.Point(254, 48)
        Me.IbU.Name = "IbU"
        Me.IbU.Size = New System.Drawing.Size(71, 17)
        Me.IbU.TabIndex = 5
        Me.IbU.TabStop = True
        Me.IbU.Text = "Id batería"
        Me.IbU.UseVisualStyleBackColor = True
        '
        'IuU
        '
        Me.IuU.AutoSize = True
        Me.IuU.Location = New System.Drawing.Point(254, 12)
        Me.IuU.Name = "IuU"
        Me.IuU.Size = New System.Drawing.Size(54, 17)
        Me.IuU.TabIndex = 4
        Me.IuU.TabStop = True
        Me.IuU.Text = "Id ups"
        Me.IuU.UseVisualStyleBackColor = True
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
        Me.Agregar.Location = New System.Drawing.Point(127, 19)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(66, 24)
        Me.Agregar.TabIndex = 14
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = True
        '
        'DGVU
        '
        Me.DGVU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVU.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGVU.Location = New System.Drawing.Point(0, 49)
        Me.DGVU.Name = "DGVU"
        Me.DGVU.ReadOnly = True
        Me.DGVU.Size = New System.Drawing.Size(739, 172)
        Me.DGVU.TabIndex = 41
        '
        'Cancelar
        '
        Me.Cancelar.Location = New System.Drawing.Point(225, 20)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(66, 24)
        Me.Cancelar.TabIndex = 4
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Location = New System.Drawing.Point(265, 21)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(71, 24)
        Me.Eliminar.TabIndex = 3
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Modificar
        '
        Me.Modificar.Location = New System.Drawing.Point(173, 20)
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
        Me.GroupBox5.Location = New System.Drawing.Point(8, 136)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(386, 57)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Acciones"
        '
        'Nuevo
        '
        Me.Nuevo.Location = New System.Drawing.Point(80, 19)
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(71, 24)
        Me.Nuevo.TabIndex = 0
        Me.Nuevo.Text = "Nuevo"
        Me.Nuevo.UseVisualStyleBackColor = True
        '
        'CheckBoxtab
        '
        Me.CheckBoxtab.AutoSize = True
        Me.CheckBoxtab.Location = New System.Drawing.Point(7, 196)
        Me.CheckBoxtab.Name = "CheckBoxtab"
        Me.CheckBoxtab.Size = New System.Drawing.Size(76, 17)
        Me.CheckBoxtab.TabIndex = 43
        Me.CheckBoxtab.Text = "Ver Datos."
        Me.CheckBoxtab.UseVisualStyleBackColor = True
        '
        'UPSs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(739, 221)
        Me.Controls.Add(Me.CheckBoxtab)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox15)
        Me.Controls.Add(Me.DGVU)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UPSs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UPSs"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.DGVU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UTXTmodelo As System.Windows.Forms.TextBox
    Friend WithEvents UTXTidbat As System.Windows.Forms.TextBox
    Friend WithEvents UTXTmarca As System.Windows.Forms.TextBox
    Friend WithEvents UTXTserie As System.Windows.Forms.TextBox
    Friend WithEvents UTXTid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents UTXTidsuc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Fin As System.Windows.Forms.Button
    Friend WithEvents Ini As System.Windows.Forms.Button
    Friend WithEvents Sig As System.Windows.Forms.Button
    Friend WithEvents Ant As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents IsU As System.Windows.Forms.RadioButton
    Friend WithEvents IbU As System.Windows.Forms.RadioButton
    Friend WithEvents IuU As System.Windows.Forms.RadioButton
    Friend WithEvents LBLbuscado As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTbuscado As System.Windows.Forms.TextBox
    Friend WithEvents Agregar As System.Windows.Forms.Button
    Friend WithEvents DGVU As System.Windows.Forms.DataGridView
    Friend WithEvents Cancelar As System.Windows.Forms.Button
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents Modificar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Nuevo As System.Windows.Forms.Button
    Friend WithEvents UCBXsuc As System.Windows.Forms.ComboBox
    Friend WithEvents UCBXbat As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxtab As System.Windows.Forms.CheckBox
End Class
