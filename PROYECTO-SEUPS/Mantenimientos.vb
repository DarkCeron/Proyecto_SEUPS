Imports System.Data.SqlClient
Imports AxAcroPDFLib
Public Class Mantenimientos
    Dim CM As New SqlConnection
    Dim Comando As New SqlCommand
    Dim datos As New DataSet
    Dim adaptador As New SqlDataAdapter
    Dim MSmant As New BindingSource

    Dim TDG As New Integer
    Private Sub Mantenimientos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AxAcroVisor.Visible = False
        CM.Close()
        MenuPrincipal.Enabled = True
    End Sub

    Private Sub Mantenimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Examinar.Enabled = False
        MTXTimg.Enabled = False
        Me.MCBXups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        MCBXsuc.Visible = False
        MCBXups.Visible = False
        'Se deshabilitan los textbox
        MTXTfolio.Enabled = False
        MTXTdia.Enabled = False
        MTXTmes.Enabled = False
        MTXTanio.Enabled = False
        MTXThora.Enabled = False
        MTXTsuc.Enabled = False
        MTXTups.Enabled = False
        'se ajustan los botones de Acciones
        Eliminar.Enabled = True
        'se ajustan los botones de desplazamientos
        Ant.Enabled = True
        Sig.Enabled = True
        Ini.Enabled = True
        Fin.Enabled = True
        'se ajustan la busqueda
        TXTbuscado.Enabled = True
        LBLbuscado.Enabled = True
        'Establecer la conexioncon sql
        CM.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
        Try
            CM.Open()
            Comando.CommandText = "select * from MANTENIMIENTO"
            Comando.Connection = CM
            adaptador.SelectCommand = Comando
            adaptador.Fill(datos, "MANTENIMIENTO")

            MSmant.DataSource = datos
            MSmant.DataMember = "MANTENIMIENTO"
            DGVM.DataSource = MSmant

            'Relacionar txt'  'fuente y con que se relaciona'
            MTXTfolio.DataBindings.Add("text", MSmant, "FOLIO_MANT")
            MTXTdia.DataBindings.Add("text", MSmant, "DIA_MANT")
            MTXTmes.DataBindings.Add("text", MSmant, "MES_MANT")
            MTXTanio.DataBindings.Add("text", MSmant, "ANIO_MANT")
            MTXThora.DataBindings.Add("text", MSmant, "HORA_MANT")
            MTXTsuc.DataBindings.Add("text", MSmant, "ID_SUC")
            MTXTups.DataBindings.Add("text", MSmant, "ID_UPS")
            MTXTimg.DataBindings.Add("text", MSmant, "IMG_MANT")

            MCBXsuc.DataBindings.Add("text", MSmant, "ID_SUC")
            MCBXups.DataBindings.Add("text", MSmant, "ID_UPS")
            Me.AxAcroVisor.src = MTXTimg.Text
            Me.AxAcroVisor.setShowToolbar(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select ID_SUC from SUCURSALES"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen Sucursales. Agrega Algunas Primero..", MsgBoxStyle.Critical)
            Else
                For i = 0 To dt.Rows.Count - 1
                    MCBXsuc.Items.Add(dt.Rows(i).Item("ID_SUC"))
                Next
            End If
            cnn.Close()
        End Using


        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select ID_UPS from UPS"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen BATERIAS. Agrega Algunas Primero..", MsgBoxStyle.Critical)
            Else
                For i = 0 To dt.Rows.Count - 1
                    MCBXups.Items.Add(dt.Rows(i).Item("ID_UPS"))
                Next
            End If
            cnn.Close()
        End Using

    End Sub

    Private Sub MTXTimg_TextChanged(sender As Object, e As EventArgs) Handles MTXTimg.TextChanged
        ' AxAcroVisor.src = MTXTimg.Text
        Me.AxAcroVisor.src = MTXTimg.Text
    End Sub
    Private Sub Ant_Click(sender As Object, e As EventArgs) Handles Ant.Click
        Try
            MSmant.MovePrevious()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Sig_Click(sender As Object, e As EventArgs) Handles Sig.Click
        Try
            MSmant.MoveNext()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ini_Click(sender As Object, e As EventArgs) Handles Ini.Click
        Try
            MSmant.MoveFirst()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fin_Click(sender As Object, e As EventArgs) Handles Fin.Click
        Try
            MSmant.MoveLast()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TXTbuscado_TextChanged(sender As Object, e As EventArgs) Handles TXTbuscado.TextChanged
        If FoM.Checked Then
            MSmant.Filter = "FOLIO_MANT like '%" & TXTbuscado.Text & "%'"
        End If
    End Sub

    Private Sub FoM_CheckedChanged(sender As Object, e As EventArgs) Handles FoM.CheckedChanged
        LBLbuscado.Text = "Folio"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Dim IU = MTXTfolio.Text
        If MessageBox.Show("Desea eliminar el registro " & IU & " ?", "Confirmacion de eliminacion.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Dim idelete As New SqlCommand
            Dim CE As New SqlConnection
            Try
                CE.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CE.Open()
                idelete.Connection = CE
                idelete.CommandText = "DELETE FROM MANTENIMIENTO WHERE FOLIO_MANT = '" & IU & "'"
                idelete.ExecuteNonQuery()

                Try
                    My.Computer.FileSystem.DeleteFile(MTXTimg.Text)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                MSmant.RemoveCurrent() 'remove datos del datagv dgv
                MsgBox("Registro y Archivo eliminados Exitosamente...")
                CE.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Me.Width = 900
            AxAcroVisor.Visible = True
        Else
            Me.Width = 547
            AxAcroVisor.Visible = False
        End If
        If (CheckBox2.Checked) Then
            AxAcroVisor.Height = 430
        Else
            AxAcroVisor.Height = 225
        End If
        Me.StartPosition = FormStartPosition.CenterScreen
        AxAcroVisor.Refresh()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            Me.Height = 468
        Else
            Me.Height = 263
        End If
        If (CheckBox2.Checked) Then
            AxAcroVisor.Height = 430
        Else
            AxAcroVisor.Height = 225
        End If
        Me.StartPosition = FormStartPosition.CenterScreen
        AxAcroVisor.Refresh()
    End Sub

    Private Sub TXTbuscado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTbuscado.KeyPress
        LetraYNumero(TXTbuscado, 50, e)
    End Sub
End Class