Imports System.Data.SqlClient
Public Class Usuarios
    Dim Conexion As New SqlConnection
    Dim Comando As New SqlCommand
    Dim ds As New DataSet
    Dim adaptador As New SqlDataAdapter
    Private Sub Usuarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Enabled = True
    End Sub

    Private Sub Regresar_Click(sender As Object, e As EventArgs) Handles Regresar.Click
        Me.Close()
        MenuPrincipal.Enabled = True
    End Sub

    Private Sub viewpass_CheckedChanged(sender As Object, e As EventArgs) Handles viewpass.CheckedChanged
        If viewpass.Checked = True Then
            TXTPASS1.UseSystemPasswordChar = False
            TXTPASS2.UseSystemPasswordChar = False
        Else
            TXTPASS1.UseSystemPasswordChar = True
            TXTPASS2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PBCU.Visible = False
    End Sub

    Private Sub CrearUser_Click(sender As Object, e As EventArgs) Handles CrearUser.Click
        If TXTPASS1.Text = TXTPASS2.Text Then
            Try
                Conexion.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                Conexion.Open()
                Comando.Connection = Conexion
                adaptador.SelectCommand = Comando

                PBCU.Visible = True

                adaptador.SelectCommand.CommandText = " create login " & TXTUSER.Text & " with password='" & TXTPASS1.Text & "'"
                adaptador.Fill(ds, "login")
                PBCU.Value = 10

                adaptador.SelectCommand.CommandText = " create user " & TXTUSER.Text
                adaptador.Fill(ds, "user")
                PBCU.Value = 20

                If CBXSelect.Checked Then
                    adaptador.SelectCommand.CommandText = "GRANT select ON OBJECT::BATERIAS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "select1")
                    PBCU.Value = 30
                    adaptador.SelectCommand.CommandText = "GRANT select ON OBJECT::SUCURSALES TO " & TXTUSER.Text
                    adaptador.Fill(ds, "select2")
                    PBCU.Value = 40
                    adaptador.SelectCommand.CommandText = "GRANT select ON OBJECT::UPS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "select3")
                    PBCU.Value = 50
                    adaptador.SelectCommand.CommandText = "GRANT select ON OBJECT::PROGRAMA TO " & TXTUSER.Text
                    adaptador.Fill(ds, "select4")
                    PBCU.Value = 60
                    adaptador.SelectCommand.CommandText = "GRANT select ON OBJECT::MANTENIMIENTO TO " & TXTUSER.Text
                    adaptador.Fill(ds, "select5")
                    PBCU.Value = 70
                End If

                If CBXInsert.Checked Then
                    adaptador.SelectCommand.CommandText = "GRANT insert ON OBJECT::BATERIAS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "insert1")
                    PBCU.Value = 80
                    adaptador.SelectCommand.CommandText = "GRANT insert ON OBJECT::SUCURSALES TO " & TXTUSER.Text
                    adaptador.Fill(ds, "insert2")
                    PBCU.Value = 90
                    adaptador.SelectCommand.CommandText = "GRANT insert ON OBJECT::UPS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "insert3")
                    PBCU.Value = 100
                    adaptador.SelectCommand.CommandText = "GRANT insert ON OBJECT::PROGRAMA TO " & TXTUSER.Text
                    adaptador.Fill(ds, "insert4")
                    PBCU.Value = 110
                    adaptador.SelectCommand.CommandText = "GRANT insert ON OBJECT::MANTENIMIENTO TO " & TXTUSER.Text
                    adaptador.Fill(ds, "insert5")
                    PBCU.Value = 120
                End If

                If CBXDelete.Checked Then
                    adaptador.SelectCommand.CommandText = "GRANT delete ON OBJECT::BATERIAS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "delete1")
                    PBCU.Value = 130
                    adaptador.SelectCommand.CommandText = "GRANT delete ON OBJECT::SUCURSALES TO " & TXTUSER.Text
                    adaptador.Fill(ds, "delete2")
                    PBCU.Value = 140
                    adaptador.SelectCommand.CommandText = "GRANT delete ON OBJECT::UPS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "delete3")
                    PBCU.Value = 150
                    adaptador.SelectCommand.CommandText = "GRANT delete ON OBJECT::PROGRAMA TO " & TXTUSER.Text
                    adaptador.Fill(ds, "delete4")
                    PBCU.Value = 160
                    adaptador.SelectCommand.CommandText = "GRANT delete ON OBJECT::MANTENIMIENTO TO " & TXTUSER.Text
                    adaptador.Fill(ds, "delete5")
                    PBCU.Value = 170
                End If

                If CBXUpdate.Checked Then
                    adaptador.SelectCommand.CommandText = "GRANT update ON OBJECT::BATERIAS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "update1")
                    PBCU.Value = 180
                    adaptador.SelectCommand.CommandText = "GRANT update ON OBJECT::SUCURSALES TO " & TXTUSER.Text
                    adaptador.Fill(ds, "update2")
                    PBCU.Value = 190
                    adaptador.SelectCommand.CommandText = "GRANT update ON OBJECT::UPS TO " & TXTUSER.Text
                    adaptador.Fill(ds, "update3")
                    PBCU.Value = 200
                    adaptador.SelectCommand.CommandText = "GRANT update ON OBJECT::PROGRAMA TO " & TXTUSER.Text
                    adaptador.Fill(ds, "update4")
                    PBCU.Value = 210
                    adaptador.SelectCommand.CommandText = "GRANT update ON OBJECT::MANTENIMIENTO TO " & TXTUSER.Text
                    adaptador.Fill(ds, "update5")
                    PBCU.Value = 220
                End If

                PBCU.Visible = False

                MsgBox("Usuario creado Correctamente")
                CBXInsert.Checked = False
                CBXUpdate.Checked = False
                CBXDelete.Checked = False
                CBXSelect.Checked = False

                TXTPASS1.Text = ""
                TXTPASS2.Text = ""
                TXTUSER.Text = ""
                ds.Clear()
                Conexion.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conexion.Close()
            End Try
        Else
            MsgBox("Las Contraseñas no coinciden")
        End If
    End Sub
End Class