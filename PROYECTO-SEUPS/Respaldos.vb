Imports System.Data.SqlClient
Public Class Respaldos
    Dim Respalda As New SqlCommand
    Dim conexion As New SqlConnection
    Private Sub Respaldos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Enabled = True
    End Sub
    Private Sub Respaldar_Click(sender As Object, e As EventArgs) Handles Respaldar.Click
        Regresar.Visible = False
        PBR.Visible = True
        PBR.Value = 0
        Dim SFD As New SaveFileDialog()
        SFD.Filter = "BAK Files (*.bak*)|*.bak"
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            Try
                PBR.Value = 10
                Dim fm As String = SFD.FileName()
                PBR.Value = 20
                conexion.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=master; User id=" & Usuario & "; password=" & Contrasena & ";"
                PBR.Value = 30
                conexion.Open()
                PBR.Value = 40
                Respalda.Connection = conexion
                PBR.Value = 50
                Respalda.CommandText = "backup database SEUPS to disk = '" & fm & "'"
                PBR.Value = 60
                Respalda.ExecuteNonQuery()
                PBR.Value = 70
                conexion.Close()
                PBR.Value = 80
                MsgBox("Base de Datos Respaldada Exitosamente...")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Regresar.Visible = True
        PBR.Visible = False
        PBR.Value = 0
    End Sub
    Private Sub Restaurar_Click(sender As Object, e As EventArgs) Handles Restaurar.Click
        Regresar.Visible = False
        PBR.Visible = True
        PBR.Value = 0
        Dim OFD As New OpenFileDialog()
        OFD.Filter = "BAK Files (*.bak*)|*.bak"
        If OFD.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            Try
                PBR.Value = 10
                Dim fm As String = OFD.FileName()
                PBR.Value = 20
                conexion.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=master; User id=" & Usuario & "; password=" & Contrasena & ";"
                PBR.Value = 30
                conexion.Open()
                PBR.Value = 40
                Respalda.Connection = conexion
                PBR.Value = 50
                Respalda.CommandText = "restore database SEUPS from disk = '" & fm & "'"
                PBR.Value = 60
                Respalda.ExecuteNonQuery()
                PBR.Value = 70
                conexion.Close()
                PBR.Value = 80
                MsgBox("Base de Datos Restaurada Exitosamente...")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Regresar.Visible = True
        PBR.Visible = False
        PBR.Value = 0
    End Sub

    Private Sub Respaldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Regresar.Visible = True
        PBR.Visible = False
        PBR.Value = 0
    End Sub

    Private Sub Regresar_Click(sender As Object, e As EventArgs) Handles Regresar.Click
        Me.Close()
    End Sub
End Class