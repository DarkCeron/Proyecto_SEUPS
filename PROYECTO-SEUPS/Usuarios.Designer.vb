<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Me.CrearUser = New System.Windows.Forms.Button()
        Me.Regresar = New System.Windows.Forms.Button()
        Me.tsdfcfgb = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTUSER = New System.Windows.Forms.TextBox()
        Me.TXTPASS2 = New System.Windows.Forms.TextBox()
        Me.TXTPASS1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CBXDelete = New System.Windows.Forms.CheckBox()
        Me.CBXInsert = New System.Windows.Forms.CheckBox()
        Me.CBXUpdate = New System.Windows.Forms.CheckBox()
        Me.CBXSelect = New System.Windows.Forms.CheckBox()
        Me.viewpass = New System.Windows.Forms.CheckBox()
        Me.PBCU = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrearUser
        '
        Me.CrearUser.Location = New System.Drawing.Point(8, 119)
        Me.CrearUser.Name = "CrearUser"
        Me.CrearUser.Size = New System.Drawing.Size(83, 23)
        Me.CrearUser.TabIndex = 0
        Me.CrearUser.Text = "Crear"
        Me.CrearUser.UseVisualStyleBackColor = True
        '
        'Regresar
        '
        Me.Regresar.Location = New System.Drawing.Point(97, 119)
        Me.Regresar.Name = "Regresar"
        Me.Regresar.Size = New System.Drawing.Size(83, 23)
        Me.Regresar.TabIndex = 1
        Me.Regresar.Text = "Regresar"
        Me.Regresar.UseVisualStyleBackColor = True
        '
        'tsdfcfgb
        '
        Me.tsdfcfgb.AutoSize = True
        Me.tsdfcfgb.Location = New System.Drawing.Point(26, 15)
        Me.tsdfcfgb.Name = "tsdfcfgb"
        Me.tsdfcfgb.Size = New System.Drawing.Size(46, 13)
        Me.tsdfcfgb.TabIndex = 2
        Me.tsdfcfgb.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Contrasena:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Confirmar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "contrasena:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TXTUSER
        '
        Me.TXTUSER.Location = New System.Drawing.Point(80, 8)
        Me.TXTUSER.Name = "TXTUSER"
        Me.TXTUSER.Size = New System.Drawing.Size(100, 20)
        Me.TXTUSER.TabIndex = 5
        '
        'TXTPASS2
        '
        Me.TXTPASS2.Location = New System.Drawing.Point(80, 69)
        Me.TXTPASS2.Name = "TXTPASS2"
        Me.TXTPASS2.Size = New System.Drawing.Size(100, 20)
        Me.TXTPASS2.TabIndex = 7
        Me.TXTPASS2.UseSystemPasswordChar = True
        '
        'TXTPASS1
        '
        Me.TXTPASS1.Location = New System.Drawing.Point(80, 43)
        Me.TXTPASS1.Name = "TXTPASS1"
        Me.TXTPASS1.Size = New System.Drawing.Size(100, 20)
        Me.TXTPASS1.TabIndex = 8
        Me.TXTPASS1.UseSystemPasswordChar = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CBXDelete)
        Me.GroupBox1.Controls.Add(Me.CBXInsert)
        Me.GroupBox1.Controls.Add(Me.CBXUpdate)
        Me.GroupBox1.Controls.Add(Me.CBXSelect)
        Me.GroupBox1.Location = New System.Drawing.Point(189, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(82, 111)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Permisos"
        '
        'CBXDelete
        '
        Me.CBXDelete.AutoSize = True
        Me.CBXDelete.Location = New System.Drawing.Point(8, 84)
        Me.CBXDelete.Name = "CBXDelete"
        Me.CBXDelete.Size = New System.Drawing.Size(62, 17)
        Me.CBXDelete.TabIndex = 3
        Me.CBXDelete.Text = "Eliminar"
        Me.CBXDelete.UseVisualStyleBackColor = True
        '
        'CBXInsert
        '
        Me.CBXInsert.AutoSize = True
        Me.CBXInsert.Location = New System.Drawing.Point(8, 40)
        Me.CBXInsert.Name = "CBXInsert"
        Me.CBXInsert.Size = New System.Drawing.Size(63, 17)
        Me.CBXInsert.TabIndex = 2
        Me.CBXInsert.Text = "Agregar"
        Me.CBXInsert.UseVisualStyleBackColor = True
        '
        'CBXUpdate
        '
        Me.CBXUpdate.AutoSize = True
        Me.CBXUpdate.Location = New System.Drawing.Point(8, 62)
        Me.CBXUpdate.Name = "CBXUpdate"
        Me.CBXUpdate.Size = New System.Drawing.Size(69, 17)
        Me.CBXUpdate.TabIndex = 1
        Me.CBXUpdate.Text = "Modificar"
        Me.CBXUpdate.UseVisualStyleBackColor = True
        '
        'CBXSelect
        '
        Me.CBXSelect.AutoSize = True
        Me.CBXSelect.Checked = True
        Me.CBXSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBXSelect.Location = New System.Drawing.Point(8, 19)
        Me.CBXSelect.Name = "CBXSelect"
        Me.CBXSelect.Size = New System.Drawing.Size(70, 17)
        Me.CBXSelect.TabIndex = 0
        Me.CBXSelect.Text = "Consultar"
        Me.CBXSelect.UseVisualStyleBackColor = True
        '
        'viewpass
        '
        Me.viewpass.AutoSize = True
        Me.viewpass.Location = New System.Drawing.Point(80, 95)
        Me.viewpass.Name = "viewpass"
        Me.viewpass.Size = New System.Drawing.Size(103, 17)
        Me.viewpass.TabIndex = 10
        Me.viewpass.Text = "Ver contrasenas"
        Me.viewpass.UseVisualStyleBackColor = True
        '
        'PBCU
        '
        Me.PBCU.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PBCU.Location = New System.Drawing.Point(0, 122)
        Me.PBCU.Maximum = 220
        Me.PBCU.Name = "PBCU"
        Me.PBCU.Size = New System.Drawing.Size(276, 23)
        Me.PBCU.TabIndex = 11
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(276, 145)
        Me.Controls.Add(Me.viewpass)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXTPASS1)
        Me.Controls.Add(Me.TXTPASS2)
        Me.Controls.Add(Me.TXTUSER)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tsdfcfgb)
        Me.Controls.Add(Me.Regresar)
        Me.Controls.Add(Me.CrearUser)
        Me.Controls.Add(Me.PBCU)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrearUser As System.Windows.Forms.Button
    Friend WithEvents Regresar As System.Windows.Forms.Button
    Friend WithEvents tsdfcfgb As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTUSER As System.Windows.Forms.TextBox
    Friend WithEvents TXTPASS2 As System.Windows.Forms.TextBox
    Friend WithEvents TXTPASS1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CBXDelete As System.Windows.Forms.CheckBox
    Friend WithEvents CBXInsert As System.Windows.Forms.CheckBox
    Friend WithEvents CBXUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents CBXSelect As System.Windows.Forms.CheckBox
    Friend WithEvents viewpass As System.Windows.Forms.CheckBox
    Friend WithEvents PBCU As System.Windows.Forms.ProgressBar
End Class
