Imports System.Data.SqlClient
Public Class UPSs
    Dim CU As New SqlConnection
    Dim Comando As New SqlCommand
    Dim datos As New DataSet
    Dim adaptador As New SqlDataAdapter
    Dim BSups As New BindingSource

    Dim TDG As New Integer
    Private Sub UPSs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CU.Close()
        MenuPrincipal.Enabled = True
    End Sub
    Private Sub UPSs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGVU.Visible = False
        Me.UCBXbat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.UCBXsuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        UCBXsuc.Visible = False
        UCBXbat.Visible = False
        'Se deshabilitan los textbox
        UTXTid.Enabled = False
        UTXTidsuc.Enabled = False
        UTXTserie.Enabled = False
        UTXTmarca.Enabled = False
        UTXTmodelo.Enabled = False
        UTXTidbat.Enabled = False
        'se ajustan los botones de Acciones
        Nuevo.Visible = True
        Modificar.Visible = True
        Eliminar.Visible = True
        Agregar.Visible = False
        Cancelar.Visible = False
        'se ajustan los botones de desplazamientos
        Ant.Enabled = True
        Sig.Enabled = True
        Ini.Enabled = True
        Fin.Enabled = True
        'se ajustan la busqueda
        TXTbuscado.Enabled = False
        LBLbuscado.Enabled = True
        'Establecer la conexioncon sql
        CU.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
        Try
            CU.Open()
            Comando.CommandText = "select * from UPS"
            Comando.Connection = CU
            adaptador.SelectCommand = Comando
            adaptador.Fill(datos, "UPS")

            BSups.DataSource = datos
            BSups.DataMember = "UPS"
            DGVU.DataSource = BSups

            'Relacionar txt'  'fuente y con que se relaciona'
            UTXTid.DataBindings.Add("text", BSups, "ID_UPS")
            UTXTidsuc.DataBindings.Add("text", BSups, "ID_SUC")
            UCBXsuc.DataBindings.Add("text", BSups, "ID_SUC")
            UTXTserie.DataBindings.Add("text", BSups, "SERIE_UPS")
            UTXTmarca.DataBindings.Add("text", BSups, "MARCA_UPS")
            UTXTmodelo.DataBindings.Add("text", BSups, "MOD_UPS")
            UTXTidbat.DataBindings.Add("text", BSups, "ID_BAT")
            UCBXbat.DataBindings.Add("text", BSups, "ID_BAT")
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
                    UCBXsuc.Items.Add(dt.Rows(i).Item("ID_SUC"))
                Next
            End If
            cnn.Close()
        End Using


        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select ID_BAT from BATERIAS"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen BATERIAS. Agrega Algunas Primero..", MsgBoxStyle.Critical)
            Else
                For i = 0 To dt.Rows.Count - 1
                    UCBXbat.Items.Add(dt.Rows(i).Item("ID_BAT"))
                Next
            End If
            cnn.Close()
        End Using

    End Sub
    Private Sub Ant_Click(sender As Object, e As EventArgs) Handles Ant.Click
        Try
            BSups.MovePrevious()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Sig_Click(sender As Object, e As EventArgs) Handles Sig.Click
        Try
            BSups.MoveNext()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ini_Click(sender As Object, e As EventArgs) Handles Ini.Click
        Try
            BSups.MoveFirst()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fin_Click(sender As Object, e As EventArgs) Handles Fin.Click
        Try
            BSups.MoveLast()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IuU_CheckedChanged(sender As Object, e As EventArgs) Handles IuU.CheckedChanged
        LBLbuscado.Text = "Id ups"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub IsU_CheckedChanged(sender As Object, e As EventArgs) Handles IsU.CheckedChanged
        LBLbuscado.Text = "Id sucursal"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub IbU_CheckedChanged(sender As Object, e As EventArgs) Handles IbU.CheckedChanged
        LBLbuscado.Text = "Id bateria"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub TXTbuscado_TextChanged(sender As Object, e As EventArgs) Handles TXTbuscado.TextChanged
        Dim dat = ""
        Try
            If IuU.Checked = True Then
                dat = "ID_UPS"
            End If
            If IsU.Checked = True Then
                dat = "ID_SUC"
            End If
            If IbU.Checked = True Then
                dat = "ID_BAT"
            End If
            BSups.Filter = dat & " like '%" & TXTbuscado.Text & "%'"
            Dim conn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            Dim cmd As New SqlCommand("Select " & dat & " from UPS where " & dat & " like '%" & TXTbuscado.Text & "%'", conn)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "lista")
            Dim col As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)(dat).ToString())
            Next
            TXTbuscado.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTbuscado.AutoCompleteCustomSource = col
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click

        Dim IU = UTXTid.Text
        If MessageBox.Show("Desea eliminar el registro " & IU & " ?", "Confirmacion de eliminacion.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Dim idelete As New SqlCommand
            Dim CE As New SqlConnection
            Try
                CE.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CE.Open()
                idelete.Connection = CE
                idelete.CommandText = "DELETE FROM ups WHERE ID_ups = '" & IU & "'"
                idelete.ExecuteNonQuery()
                BSups.RemoveCurrent() 'remove dgv
                MsgBox("Registro Eliminado Exitosamente...")
                CE.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        BSups.AddNew()
        'des oculta combobox
        UTXTidbat.Visible = False
        UTXTidsuc.Visible = False
        'Se limpian los textbox
        UTXTid.Text = ""
        UTXTidsuc.Text = ""
        UTXTserie.Text = ""
        UTXTmarca.Text = ""
        UTXTmodelo.Text = ""
        UTXTidbat.Text = ""
        'Se habilitan los textbox
        UTXTid.Enabled = True
        'UTXTidsuc.Enabled = True
        UTXTserie.Enabled = True
        UTXTmarca.Enabled = True
        UTXTmodelo.Enabled = True
        'UTXTidbat.Enabled = True
        UCBXbat.Visible = True
        UCBXsuc.Visible = True
        'se ajustan los botones de Acciones
        Nuevo.Visible = False
        Modificar.Visible = False
        Eliminar.Visible = False
        Agregar.Visible = True
        Cancelar.Visible = True
        'se ajustan los botones de desplazamientos
        Ant.Enabled = False
        Sig.Enabled = False
        Ini.Enabled = False
        Fin.Enabled = False
        'se ajustan la busqueda
        TXTbuscado.Enabled = False
        IuU.Enabled = False
        IsU.Enabled = False
        IbU.Enabled = False
        'çambiamos la bariable que indica guardado
        TDG = 1
        DGVU.Enabled = False
    End Sub

    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click
        'des oculta combobox
        UTXTidbat.Visible = False
        UTXTidsuc.Visible = False
        'Se limpian los textbox
        'UTXTid.Text = ""
        'UTXTidsuc.Text = ""
        'UTXTserie.Text = ""
        'UTXTmarca.Text = ""
        'UTXTmodelo.Text = ""
        'UTXTidbat.Text = ""
        'Se habilitan los textbox
        'UTXTid.Enabled = True
        'UTXTidsuc.Enabled = True
        UTXTserie.Enabled = True
        UTXTmarca.Enabled = True
        UTXTmodelo.Enabled = True
        'UTXTidbat.Enabled = True
        UCBXbat.Visible = True
        UCBXsuc.Visible = True
        'se ajustan los botones de Acciones
        Nuevo.Visible = False
        Modificar.Visible = False
        Eliminar.Visible = False
        Agregar.Visible = True
        Cancelar.Visible = True
        'se ajustan los botones de desplazamientos
        Ant.Enabled = False
        Sig.Enabled = False
        Ini.Enabled = False
        Fin.Enabled = False
        'se ajustan la busqueda
        TXTbuscado.Enabled = False
        IuU.Enabled = False
        IsU.Enabled = False
        IbU.Enabled = False
        'çambiamos la bariable que indica guardado
        TDG = 2
        DGVU.Enabled = False
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        'MsgBox(PCBXsuc.Text) 'CORRECTO
        BSups.EndEdit()
        If TDG = 1 Then
            '-------------------------------------------------------------------------------------
            Dim iincert As New SqlCommand
            Dim CI As New SqlConnection
            Try
                CI.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CI.Open()
                iincert.Connection = CI
                iincert.CommandText = "insert into UPS values('" & UTXTid.Text & "','" & UCBXsuc.Text & "','" & UTXTserie.Text & "','" & UTXTmarca.Text & "','" & UTXTmodelo.Text & "','" & UCBXbat.Text & "')"
                iincert.ExecuteNonQuery()
                BSups.EndEdit()
                'habilitamos el DGB
                DGVU.Enabled = True

                Refresh()
                MsgBox("Registro guardado exitosamente..")
                CI.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '-------------------------------------------------------------------------------------
        End If
        If TDG = 2 Then
            '-------------------------------------------------------------------------------------
            Dim iupdate As New SqlCommand
            Dim CU As New SqlConnection
            Try
                CU.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CU.Open()
                iupdate.Connection = CU
                iupdate.CommandText = "update UPS set ID_SUC='" & UCBXsuc.Text & "', SERIE_UPS = '" & UTXTserie.Text & "',MARCA_UPS='" & UTXTmarca.Text & "',MOD_UPS='" & UTXTmodelo.Text & "', ID_BAT='" & UCBXbat.Text & "' where ID_UPS='" & UTXTid.Text & "'"
                iupdate.ExecuteNonQuery()
                BSups.EndEdit()
                'habilitamos el DGB
                DGVU.Enabled = True

                Refresh()
                MsgBox("Registro modificado exitosamente..")
                CU.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '-------------------------------------------------------------------------------------
        End If


        'des oculta combobox
        UTXTidbat.Visible = True
        UTXTidsuc.Visible = True
        'Se limpian los textbox
        'UTXTid.Text = ""
        'UTXTidsuc.Text = ""
        'UTXTserie.Text = ""
        'UTXTmarca.Text = ""
        'UTXTmodelo.Text = ""
        'UTXTidbat.Text = ""
        'Se habilitan los textbox
        UTXTid.Enabled = False
        UTXTidsuc.Enabled = False
        UTXTserie.Enabled = False
        UTXTmarca.Enabled = False
        UTXTmodelo.Enabled = False
        'UTXTidbat.Enabled = True
        UCBXbat.Visible = False
        UCBXsuc.Visible = False
        'se ajustan los botones de Acciones
        Nuevo.Visible = True
        Modificar.Visible = True
        Eliminar.Visible = True
        Agregar.Visible = False
        Cancelar.Visible = False
        'se ajustan los botones de desplazamientos
        Ant.Enabled = True
        Sig.Enabled = True
        Ini.Enabled = True
        Fin.Enabled = True
        'se ajustan la busqueda
        TXTbuscado.Enabled = True
        IuU.Enabled = True
        IsU.Enabled = True
        IbU.Enabled = True
        'çambiamos la bariable que reinicia
        TDG = 0
        DGVU.Enabled = True
    End Sub
    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        BSups.CancelEdit()
        'des oculta combobox
        UTXTidbat.Visible = True
        UTXTidsuc.Visible = True
        'Se limpian los textbox
        'UTXTid.Text = ""
        'UTXTidsuc.Text = ""
        'UTXTserie.Text = ""
        'UTXTmarca.Text = ""
        'UTXTmodelo.Text = ""
        'UTXTidbat.Text = ""
        'Se habilitan los textbox
        UTXTid.Enabled = False
        UTXTidsuc.Enabled = False
        UTXTserie.Enabled = False
        UTXTmarca.Enabled = False
        UTXTmodelo.Enabled = False
        'UTXTidbat.Enabled = True
        UCBXbat.Visible = False
        UCBXsuc.Visible = False
        'se ajustan los botones de Acciones
        Nuevo.Visible = True
        Modificar.Visible = True
        Eliminar.Visible = True
        Agregar.Visible = False
        Cancelar.Visible = False
        'se ajustan los botones de desplazamientos
        Ant.Enabled = True
        Sig.Enabled = True
        Ini.Enabled = True
        Fin.Enabled = True
        'se ajustan la busqueda
        TXTbuscado.Enabled = True
        IuU.Enabled = True
        IsU.Enabled = True
        IbU.Enabled = True
        'çambiamos la bariable que reinicia
        TDG = 0
        DGVU.Enabled = True
    End Sub

    Private Sub CheckBoxtab_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxtab.CheckedChanged
        If (CheckBoxtab.Checked) Then
            Me.Height = 425
            DGVU.Visible = True
        Else
            Me.Height = 260
            DGVU.Visible = False
        End If
    End Sub

    Private Sub UTXTid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UTXTid.KeyPress
        Numero(UTXTid, 8, e)
    End Sub

    Private Sub UTXTserie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UTXTserie.KeyPress
        LetraYNumero(UTXTserie, 25, e)
    End Sub

    Private Sub UTXTmarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UTXTmarca.KeyPress
        LetraYNumero(UTXTmarca, 25, e)
    End Sub

    Private Sub UTXTmodelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UTXTmodelo.KeyPress
        LetraYNumero(UTXTmodelo, 25, e)
    End Sub
End Class