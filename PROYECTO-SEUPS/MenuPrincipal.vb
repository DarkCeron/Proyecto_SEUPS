Imports System.IO

Public Class MenuPrincipal
    Private Sub BateriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BateriasToolStripMenuItem.Click
        Me.Enabled = False
        Baterias.Show()
    End Sub

    Private Sub MenuPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            End 'Se sale del programa
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub ProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramaToolStripMenuItem.Click
        Me.Enabled = False
        Programa.Show()
    End Sub

    Private Sub RespaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        Me.Enabled = False
        Respaldos.Show()
    End Sub
    Private Sub SalirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        If MessageBox.Show("Desea Salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Try
                End 'Se sale del programa
            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If
    End Sub
    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Me.Enabled = False
        Usuarios.Show()
    End Sub
    Private Sub SucursalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucursalesToolStripMenuItem.Click
        Me.Enabled = False
        Sucursales.Show()
    End Sub

    Private Sub InformeProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        'Me.Enabled = False
        'ReportePrograma.Show()
    End Sub

    Private Sub UPSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPSToolStripMenuItem.Click
        Me.Enabled = False
        UPSs.Show()
    End Sub
    Private Sub ReporteParaEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteParaEmpresaToolStripMenuItem.Click
        Me.Enabled = False
        ReporteEmpresa.Show()
    End Sub

    Private Sub ReporteParaClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteParaClienteToolStripMenuItem.Click
        Me.Enabled = False
        ReporteCliente.Show()
    End Sub

    Private Sub BorrarBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        Me.Enabled = False
        ReiniciarDB.Show()
    End Sub

    Private Sub MantenimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientosToolStripMenuItem.Click
        Me.Enabled = False
        Mantenimientos.Show()
    End Sub

    Private Sub CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarCarpetaDondeSeAlmacenanArchivosToolStripMenuItem.Click
        FBD.Description = "Seleccione la carpeta que cotendra los archivos pdf."
        If FBD.ShowDialog() = 1 Then
            FolderOutput = FBD.SelectedPath
            FolderOutput = Replace(FolderOutput, vbCrLf, "")
            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo = "C:\configuracion.txt"
            Try
                If File.Exists(PathArchivo) Then
                    strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If
                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
                strStreamWriter.WriteLine(FolderOutput)
                strStreamWriter.Close() ' cerramos
                MsgBox("Carpeta de almacenamiento: " & FBD.SelectedPath & vbCrLf & "Tus antiguos archivos no se eliminaron..")
            Catch exx As Exception
                MsgBox("Error al Guardar la informacion en el archivo. " & exx.ToString, MsgBoxStyle.Critical, Application.ProductName)
                Try
                    strStreamWriter.Close() ' cerramos
                Catch exss As Exception

                End Try

            End Try
        End If
    End Sub
End Class