<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.TXTuser = New System.Windows.Forms.TextBox()
        Me.TXTpass = New System.Windows.Forms.TextBox()
        Me.BACEPTAR = New System.Windows.Forms.Button()
        Me.BSALIR = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXTuser
        '
        Me.TXTuser.BackColor = System.Drawing.Color.White
        Me.TXTuser.ForeColor = System.Drawing.Color.Maroon
        Me.TXTuser.Location = New System.Drawing.Point(115, 354)
        Me.TXTuser.Name = "TXTuser"
        Me.TXTuser.Size = New System.Drawing.Size(100, 20)
        Me.TXTuser.TabIndex = 0
        '
        'TXTpass
        '
        Me.TXTpass.BackColor = System.Drawing.Color.White
        Me.TXTpass.ForeColor = System.Drawing.Color.Maroon
        Me.TXTpass.Location = New System.Drawing.Point(115, 380)
        Me.TXTpass.Name = "TXTpass"
        Me.TXTpass.Size = New System.Drawing.Size(100, 20)
        Me.TXTpass.TabIndex = 1
        Me.TXTpass.UseSystemPasswordChar = True
        '
        'BACEPTAR
        '
        Me.BACEPTAR.BackColor = System.Drawing.Color.White
        Me.BACEPTAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BACEPTAR.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.BACEPTAR.FlatAppearance.CheckedBackColor = System.Drawing.Color.Maroon
        Me.BACEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BACEPTAR.ForeColor = System.Drawing.Color.Maroon
        Me.BACEPTAR.Location = New System.Drawing.Point(221, 353)
        Me.BACEPTAR.Name = "BACEPTAR"
        Me.BACEPTAR.Size = New System.Drawing.Size(75, 23)
        Me.BACEPTAR.TabIndex = 2
        Me.BACEPTAR.Text = "Aceptar"
        Me.BACEPTAR.UseVisualStyleBackColor = False
        '
        'BSALIR
        '
        Me.BSALIR.BackColor = System.Drawing.Color.White
        Me.BSALIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BSALIR.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.BSALIR.FlatAppearance.CheckedBackColor = System.Drawing.Color.Maroon
        Me.BSALIR.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BSALIR.ForeColor = System.Drawing.Color.Maroon
        Me.BSALIR.Location = New System.Drawing.Point(221, 379)
        Me.BSALIR.Name = "BSALIR"
        Me.BSALIR.Size = New System.Drawing.Size(75, 23)
        Me.BSALIR.TabIndex = 3
        Me.BSALIR.Text = "Salir"
        Me.BSALIR.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-225, -92)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(788, 523)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 383)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Contraseña:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(55, 357)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Usuario:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(338, 430)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BSALIR)
        Me.Controls.Add(Me.BACEPTAR)
        Me.Controls.Add(Me.TXTpass)
        Me.Controls.Add(Me.TXTuser)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TXTuser As System.Windows.Forms.TextBox
    Friend WithEvents TXTpass As System.Windows.Forms.TextBox
    Friend WithEvents BACEPTAR As System.Windows.Forms.Button
    Friend WithEvents BSALIR As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
