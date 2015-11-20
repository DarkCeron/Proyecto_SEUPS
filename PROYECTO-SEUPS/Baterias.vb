Imports System.Data.SqlClient
Public Class Baterias
    Dim CB As New SqlConnection
    Dim Comando As New SqlCommand
    Dim datos As New DataSet
    Dim adaptador As New SqlDataAdapter
    Dim BSbaterias As New BindingSource

    Dim TDG As New Integer
    Private Sub Baterias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Se deshabilitan los textbox
        BTXTid.Enabled = False
        BTXTmod.Enabled = False
        BTXTserie.Enabled = False
        BTXTmarca.Enabled = False
        BTXTcapa.Enabled = False
        BTXTcant.Enabled = False
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
        CB.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
        Try
            CB.Open()
            Comando.CommandText = "select * from BATERIAS"
            Comando.Connection = CB
            adaptador.SelectCommand = Comando
            adaptador.Fill(datos, "BATERIAS")

            BSbaterias.DataSource = datos
            BSbaterias.DataMember = "BATERIAS"
            DGVB.DataSource = BSbaterias

            'Relacionar txt'  'fuente y con que se relaciona'
            BTXTid.DataBindings.Add("text", BSbaterias, "ID_BAT")
            BTXTmod.DataBindings.Add("text", BSbaterias, "MODE_BAT")
            BTXTserie.DataBindings.Add("text", BSbaterias, "SERIE_BAT")
            BTXTmarca.DataBindings.Add("text", BSbaterias, "MARCA_BAT")
            BTXTcapa.DataBindings.Add("text", BSbaterias, "CAPACIDAD_BAT")
            BTXTcant.DataBindings.Add("text", BSbaterias, "CANTI_BAT")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Baterias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CB.Close()
        MenuPrincipal.Enabled = True
    End Sub
    Private Sub Ant_Click(sender As Object, e As EventArgs) Handles Ant.Click
        Try
            BSbaterias.MovePrevious()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Sig_Click(sender As Object, e As EventArgs) Handles Sig.Click
        Try
            BSbaterias.MoveNext()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ini_Click(sender As Object, e As EventArgs) Handles Ini.Click
        Try
            BSbaterias.MoveFirst()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fin_Click(sender As Object, e As EventArgs) Handles Fin.Click
        Try
            BSbaterias.MoveLast()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TXTbuscado_TextChanged(sender As Object, e As EventArgs) Handles TXTbuscado.TextChanged
        Dim dat = ""
        Try
            If MoB.Checked = True Then
                dat = "MODE_BAT"
            ElseIf MaB.Checked = True Then
                dat = "MARCA_BAT"
            ElseIf CaB.Checked = True Then
                dat = "CAPACIDAD_BAT"
            End If
            BSbaterias.Filter = dat & " like '%" & TXTbuscado.Text & "%'"
            Dim conn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            Dim cmd As New SqlCommand("Select " & dat & " from BATERIAS where " & dat & " like '%" & TXTbuscado.Text & "%'", conn)
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
    Private Sub MoB_CheckedChanged(sender As Object, e As EventArgs) Handles MoB.CheckedChanged
        TXTbuscado.Enabled = True
        LBLbuscado.Text = "Modelo de la bateria"
    End Sub
    Private Sub MaB_CheckedChanged(sender As Object, e As EventArgs) Handles MaB.CheckedChanged
        TXTbuscado.Enabled = True
        LBLbuscado.Text = "Marca de la bateria"
    End Sub
    Private Sub CaB_CheckedChanged(sender As Object, e As EventArgs) Handles CaB.CheckedChanged
        TXTbuscado.Enabled = True
        LBLbuscado.Text = "Capacidad de la bateria"
    End Sub
    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click

        Dim IB = BTXTid.Text
        If MessageBox.Show("Desea eliminar el registro " & IB & " ?", "Confirmacion de eliminacion.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Dim idelete As New SqlCommand
            Dim CE As New SqlConnection
            Try
                CE.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CE.Open()
                idelete.Connection = CE
                idelete.CommandText = "DELETE FROM BATERIAS WHERE ID_BAT = '" & IB & "'"
                idelete.ExecuteNonQuery()
                BSbaterias.RemoveCurrent() 'remove dgv
                MsgBox("Registro Eliminado Exitosamente...")
                CE.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click

        'agregamos el nuevo
        BSbaterias.AddNew()
        'Deshabilitamos la busqueda
        TXTbuscado.Enabled = False
        MoB.Enabled = False
        MaB.Enabled = False
        CaB.Enabled = False
        'Deshabilitamos los desplazamientos
        Ant.Enabled = False
        Sig.Enabled = False
        Ini.Enabled = False
        Fin.Enabled = False
        'deshabilitamos acciones principales
        Nuevo.Visible = False
        Modificar.Visible = False
        Eliminar.Visible = False
        'Habilitamos las confirmaciones
        Agregar.Visible = True
        Cancelar.Visible = True
        'Limpiamos los datos de los textbox
        BTXTid.Text = ""
        BTXTmod.Text = ""
        BTXTserie.Text = ""
        BTXTmarca.Text = ""
        BTXTcapa.Text = ""
        BTXTcant.Text = ""
        'Habilitamos la edicion de textbox
        BTXTid.Enabled = True
        BTXTmod.Enabled = True
        BTXTserie.Enabled = True
        BTXTmarca.Enabled = True
        BTXTcapa.Enabled = True
        BTXTcant.Enabled = True
        'Cambia la bariable a 1 q indica al guardado como <<NUEVO>>
        Try
            TDG = 1

            'desabilitamos el DGB
            DGVB.Enabled = False
            'agregamos otro
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click
        'Modificar
        '?????
        'Deshabilitamos la busqueda
        TXTbuscado.Enabled = False
        MoB.Enabled = False
        MaB.Enabled = False
        CaB.Enabled = False
        'Deshabilitamos los desplazamientos
        Ant.Enabled = False
        Sig.Enabled = False
        Ini.Enabled = False
        Fin.Enabled = False
        'deshabilitamos acciones principales
        Nuevo.Visible = False
        Modificar.Visible = False
        Eliminar.Visible = False
        'Habilitamos las confirmaciones
        Agregar.Visible = True
        Cancelar.Visible = True
        'Habilitamos la edicion de textbox
        'BTXTid.Enabled = True
        BTXTmod.Enabled = True
        BTXTserie.Enabled = True
        BTXTmarca.Enabled = True
        BTXTcapa.Enabled = True
        BTXTcant.Enabled = True
        'desabilitamos el DGB
        DGVB.Enabled = False
        'Cambia la bariable a 1 q indica al guardado como <<MODIFICAR>>
        TDG = 2
    End Sub
    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        BSbaterias.EndEdit()
        If TDG = 1 Then
            '-------------------------------------------------------------------------------------
            Dim iincert As New SqlCommand
            Dim CI As New SqlConnection
            Try
                CI.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CI.Open()
                iincert.Connection = CI
                iincert.CommandText = "insert into BATERIAS values('" & BTXTid.Text & "','" & BTXTmod.Text & "','" & BTXTserie.Text & "','" & BTXTmarca.Text & "','" & BTXTcapa.Text & "','" & BTXTcant.Text & "')"
                iincert.ExecuteNonQuery()
                BSbaterias.EndEdit()
                'habilitamos el DGB
                DGVB.Enabled = True

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
                iupdate.CommandText = "update BATERIAS set MODE_BAT='" & BTXTmod.Text & "', SERIE_BAT = '" & BTXTserie.Text & "',MARCA_BAT='" & BTXTmarca.Text & "',CAPACIDAD_BAT='" & BTXTcapa.Text & "', CANTI_BAT='" & BTXTcant.Text & "' where ID_BAT='" & BTXTid.Text & "'"
                iupdate.ExecuteNonQuery()
                BSbaterias.EndEdit()
                'habilitamos el DGB
                DGVB.Enabled = True

                Refresh()
                MsgBox("Registro guardado exitosamente..")
                CU.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '-------------------------------------------------------------------------------------
        End If


        'habilitamos la busqueda
        TXTbuscado.Enabled = True
        MoB.Enabled = True
        MaB.Enabled = True
        CaB.Enabled = True
        'habilitamos los desplazamientos
        Ant.Enabled = True
        Sig.Enabled = True
        Ini.Enabled = True
        Fin.Enabled = True
        'habilitamos acciones principales
        Nuevo.Visible = True
        Modificar.Visible = True
        Eliminar.Visible = True
        'desHabilitamos las confirmaciones
        Agregar.Visible = False
        Cancelar.Visible = False
        'Limpiamos los datos de los textbox '<< MEJOR NO ESTO CAUSA EL FALLO DE LAS CASILLAS CAMBIEN A DATOS EN BLANCO  >>
        'BTXTid.Text = ""
        'BTXTmod.Text = ""
        'BTXTserie.Text = ""
        'BTXTmarca.Text = ""
        'BTXTcapa.Text = ""
        'BTXTcant.Text = ""
        'desHabilitamos la edicion de textbox
        BTXTid.Enabled = False
        BTXTmod.Enabled = False
        BTXTserie.Enabled = False
        BTXTmarca.Enabled = False
        BTXTcapa.Enabled = False
        BTXTcant.Enabled = False
        'Cambia la bariable a 0 para reiniciarla
        TDG = 0
        DGVB.Enabled = True
    End Sub
    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        'Cancelamos la edicion
        BSbaterias.CancelEdit()
        'habilitamos el DGB
        DGVB.Enabled = True
        'habilitamos la busqueda
        TXTbuscado.Enabled = True
        MoB.Enabled = True
        MaB.Enabled = True
        CaB.Enabled = True
        'habilitamos los desplazamientos
        Ant.Enabled = True
        Sig.Enabled = True
        Ini.Enabled = True
        Fin.Enabled = True
        'habilitamos acciones principales
        Nuevo.Visible = True
        Modificar.Visible = True
        Eliminar.Visible = True
        'desHabilitamos las confirmaciones
        Agregar.Visible = False
        Cancelar.Visible = False
        'Limpiamos los datos de los textbox     '<< MEJOR NO ESTO CAUSA EL FALLO DE LAS CASILLAS CAMBIEN A DATOS EN BLANCO  >>
        'BTXTid.Text = ""
        'BTXTmod.Text = ""
        'BTXTserie.Text = ""
        'BTXTmarca.Text = ""
        'BTXTcapa.Text = ""
        'BTXTcant.Text = ""
        'desHabilitamos la edicion de textbox
        BTXTid.Enabled = False
        BTXTmod.Enabled = False
        BTXTserie.Enabled = False
        BTXTmarca.Enabled = False
        BTXTcapa.Enabled = False
        BTXTcant.Enabled = False
        'Cambia la bariable a 0 para reiniciarla
        TDG = 0
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked) Then
            DGVB.Visible = True
            Me.Width = 669
            Me.Height = 413
        Else
            DGVB.Visible = False
            Me.Width = 669
            Me.Height = 246
        End If
    End Sub

    Private Sub BTXTid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BTXTid.KeyPress
        Numero(BTXTid, 8, e)
    End Sub

    Private Sub BTXTmod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BTXTmod.KeyPress
        LetraYNumero(BTXTmod, 15, e)
    End Sub

    Private Sub BTXTserie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BTXTserie.KeyPress
        LetraYNumero(BTXTserie, 20, e)
    End Sub

    Private Sub BTXTmarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BTXTmarca.KeyPress
        LetraYNumero(BTXTmarca, 20, e)
    End Sub

    Private Sub BTXTcapa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BTXTcapa.KeyPress
        LetraYNumero(BTXTcapa, 30, e)
    End Sub

    Private Sub BTXTcant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BTXTcant.KeyPress
        Numero(BTXTcant, 8, e)
    End Sub

    Private Sub TXTbuscado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTbuscado.KeyPress
        LetraYNumero(TXTbuscado, 50, e)
    End Sub
End Class