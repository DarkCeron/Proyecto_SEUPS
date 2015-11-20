<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Respaldos
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
        Me.Respaldar = New System.Windows.Forms.Button()
        Me.Restaurar = New System.Windows.Forms.Button()
        Me.PBR = New System.Windows.Forms.ProgressBar()
        Me.Regresar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Respaldar
        '
        Me.Respaldar.Location = New System.Drawing.Point(11, 12)
        Me.Respaldar.Name = "Respaldar"
        Me.Respaldar.Size = New System.Drawing.Size(106, 32)
        Me.Respaldar.TabIndex = 0
        Me.Respaldar.Text = "Respaldar"
        Me.Respaldar.UseVisualStyleBackColor = True
        '
        'Restaurar
        '
        Me.Restaurar.Location = New System.Drawing.Point(133, 12)
        Me.Restaurar.Name = "Restaurar"
        Me.Restaurar.Size = New System.Drawing.Size(106, 32)
        Me.Restaurar.TabIndex = 1
        Me.Restaurar.Text = "Restaurar"
        Me.Restaurar.UseVisualStyleBackColor = True
        '
        'PBR
        '
        Me.PBR.BackColor = System.Drawing.Color.Gold
        Me.PBR.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PBR.ForeColor = System.Drawing.Color.Lime
        Me.PBR.Location = New System.Drawing.Point(0, 0)
        Me.PBR.Maximum = 80
        Me.PBR.Name = "PBR"
        Me.PBR.Size = New System.Drawing.Size(371, 49)
        Me.PBR.TabIndex = 2
        '
        'Regresar
        '
        Me.Regresar.Location = New System.Drawing.Point(255, 12)
        Me.Regresar.Name = "Regresar"
        Me.Regresar.Size = New System.Drawing.Size(106, 32)
        Me.Regresar.TabIndex = 3
        Me.Regresar.Text = "Regresar"
        Me.Regresar.UseVisualStyleBackColor = True
        '
        'Respaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(371, 49)
        Me.ControlBox = False
        Me.Controls.Add(Me.Regresar)
        Me.Controls.Add(Me.Restaurar)
        Me.Controls.Add(Me.Respaldar)
        Me.Controls.Add(Me.PBR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Respaldos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respaldos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Respaldar As System.Windows.Forms.Button
    Friend WithEvents Restaurar As System.Windows.Forms.Button
    Friend WithEvents PBR As System.Windows.Forms.ProgressBar
    Friend WithEvents Regresar As System.Windows.Forms.Button
End Class
