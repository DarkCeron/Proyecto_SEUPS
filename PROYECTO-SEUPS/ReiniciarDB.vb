Imports System.Data.SqlClient
Public Class ReiniciarDB
    Dim Conexion As New SqlConnection
    Dim Comando As New SqlCommand
    Dim ds As New DataSet
    Dim adaptador As New SqlDataAdapter
    Private Sub Reiniciar_Click(sender As Object, e As EventArgs) Handles Reiniciar.Click
        If MessageBox.Show("Desea Reiniciar la base de datos? Ten en cuenta que se perderan todos los datos.", "Reiniciar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Try
                Conexion.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                Conexion.Open()
                Comando.Connection = Conexion
                adaptador.SelectCommand = Comando
                adaptador.SelectCommand.CommandText = "Execute CADB"
                adaptador.Fill(ds, "exe")
                ds.Clear()
                Conexion.Close()
                MsgBox("La Base de datos se reinicio. Seras regresado al menu..")
                MenuPrincipal.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MenuPrincipal.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        MenuPrincipal.Enabled = True
        Me.Close()
    End Sub

    Private Sub ReiniciarDB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Enabled = True
    End Sub
End Class