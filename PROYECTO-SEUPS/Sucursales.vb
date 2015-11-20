Imports System.Data.SqlClient
Public Class Sucursales
    Dim CS As New SqlConnection
    Dim Comando As New SqlCommand
    Dim datos As New DataSet
    Dim adaptador As New SqlDataAdapter
    Dim BSsucursales As New BindingSource

    Dim TGD As New Integer
    Private Sub Sucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGVS.Visible = False
        'Se deshabilitan los textbox
        STXTid.Enabled = False
        STXTcalle.Enabled = False
        STXTnsuc.Enabled = False
        STXTciudad.Enabled = False
        STXTestado.Enabled = False
        STXTnomempresa.Enabled = False
        STXTnombsuc.Enabled = False
        STXTtelefono.Enabled = False
        STXTnombregerente.Enabled = False
        STXTtelefonogerente.Enabled = False
        STXTnombresubgerente.Enabled = False
        STXTtelefonosubgerente.Enabled = False
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
        CS.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
        Try
            CS.Open()
            Comando.CommandText = "select * from SUCURSALES"
            Comando.Connection = CS
            adaptador.SelectCommand = Comando
            adaptador.Fill(datos, "SUCURSALES")

            BSsucursales.DataSource = datos
            BSsucursales.DataMember = "SUCURSALES"
            DGVS.DataSource = BSsucursales

            'Relacionar txt'  'fuente y con que se relaciona'
            STXTid.DataBindings.Add("text", BSsucursales, "ID_SUC")
            STXTcalle.DataBindings.Add("text", BSsucursales, "CALLE_SUC")
            STXTnsuc.DataBindings.Add("text", BSsucursales, "NUM_SUC")
            STXTciudad.DataBindings.Add("text", BSsucursales, "CIU_SUC")
            STXTestado.DataBindings.Add("text", BSsucursales, "ESTADO_SUC")
            STXTnomempresa.DataBindings.Add("text", BSsucursales, "NOM_EMP_SUC")
            STXTnombsuc.DataBindings.Add("text", BSsucursales, "NOM_SUC")
            STXTtelefono.DataBindings.Add("text", BSsucursales, "TEL_SUC")
            STXTnombregerente.DataBindings.Add("text", BSsucursales, "NOM_GEREN_SUC")
            STXTtelefonogerente.DataBindings.Add("text", BSsucursales, "TEL_GEREN_SUC")
            STXTnombresubgerente.DataBindings.Add("text", BSsucursales, "NOM_SUBGEREN_SUC")
            STXTtelefonosubgerente.DataBindings.Add("text", BSsucursales, "TEL_SUBGEREN_SUC")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Sucursales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CS.Close()
        MenuPrincipal.Enabled = True
    End Sub
    Private Sub Ant_Click(sender As Object, e As EventArgs) Handles Ant.Click
        Try
            BSsucursales.MovePrevious()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Sig_Click(sender As Object, e As EventArgs) Handles Sig.Click
        Try
            BSsucursales.MoveNext()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ini_Click(sender As Object, e As EventArgs) Handles Ini.Click
        Try
            BSsucursales.MoveFirst()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fin_Click(sender As Object, e As EventArgs) Handles Fin.Click
        Try
            BSsucursales.MoveLast()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IdS_CheckedChanged(sender As Object, e As EventArgs) Handles IdS.CheckedChanged
        LBLbuscado.Text = "Id sucursal"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub NsS_CheckedChanged(sender As Object, e As EventArgs) Handles NsS.CheckedChanged
        LBLbuscado.Text = "Nombre sucursal"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub NeS_CheckedChanged(sender As Object, e As EventArgs) Handles NeS.CheckedChanged
        LBLbuscado.Text = "Nombre empresa"
        TXTbuscado.Enabled = True
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click
        Dim I = STXTid.Text
        If MessageBox.Show("Desea eliminar el registro " & I & " ?", "Confirmacion de eliminacion.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Dim idelete As New SqlCommand
            Dim CE As New SqlConnection
            Try
                CE.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CE.Open()
                idelete.Connection = CE
                idelete.CommandText = "DELETE FROM SUCURSALES WHERE ID_SUC = '" & I & "'"
                idelete.ExecuteNonQuery()
                BSsucursales.RemoveCurrent() 'remove dgv
                MsgBox("Registro Eliminado Exitosamente...")
                CE.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        'agregamos el nuevo
        BSsucursales.AddNew()
        'Deshabilitamos la busqueda
        TXTbuscado.Enabled = False
        IdS.Enabled = False
        NsS.Enabled = False
        NeS.Enabled = False
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
        STXTid.Text = ""
        STXTcalle.Text = ""
        STXTnsuc.Text = ""
        STXTciudad.Text = ""
        STXTestado.Text = ""
        STXTnomempresa.Text = ""
        STXTnombsuc.Text = ""
        STXTtelefono.Text = ""
        STXTnombregerente.Text = ""
        STXTtelefonogerente.Text = ""
        STXTnombresubgerente.Text = ""
        STXTtelefonosubgerente.Text = ""
        'Habilitamos la edicion de textbox
        STXTid.Enabled = True
        STXTcalle.Enabled = True
        STXTnsuc.Enabled = True
        STXTciudad.Enabled = True
        STXTestado.Enabled = True
        STXTnomempresa.Enabled = True
        STXTnombsuc.Enabled = True
        STXTtelefono.Enabled = True
        STXTnombregerente.Enabled = True
        STXTtelefonogerente.Enabled = True
        STXTnombresubgerente.Enabled = True
        STXTtelefonosubgerente.Enabled = True
        'Cambia la bariable a 1 q indica al guardado como <<NUEVO>>
        Try
            TGD = 1

            'desabilitamos el DGB
            DGVS.Enabled = False
            'agregamos otro
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click
        'Deshabilitamos la busqueda
        TXTbuscado.Enabled = False
        IdS.Enabled = False
        NsS.Enabled = False
        NeS.Enabled = False
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
        'STXTid.Text = ""
        'STXTcalle.Text = ""
        'STXTnsuc.Text = ""
        'STXTciudad.Text = ""
        'STXTestado.Text = ""
        'STXTnomempresa.Text = ""
        'STXTnombsuc.Text = ""
        'STXTtelefono.Text = ""
        'STXTnombregerente.Text = ""
        'STXTtelefonogerente.Text = ""
        'STXTnombresubgerente.Text = ""
        'STXTtelefonosubgerente.Text = ""
        'Habilitamos la edicion de textbox
        ' STXTid.Enabled = True
        STXTcalle.Enabled = True
        STXTnsuc.Enabled = True
        STXTciudad.Enabled = True
        STXTestado.Enabled = True
        STXTnomempresa.Enabled = True
        STXTnombsuc.Enabled = True
        STXTtelefono.Enabled = True
        STXTnombregerente.Enabled = True
        STXTtelefonogerente.Enabled = True
        STXTnombresubgerente.Enabled = True
        STXTtelefonosubgerente.Enabled = True
        'Cambia la bariable a 2 q indica al guardado como <<MODIFICAR>>
        Try
            TGD = 2

            'desabilitamos el DGB
            DGVS.Enabled = False
            'agregamos otro
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        BSsucursales.EndEdit()
        If TGD = 1 Then
            '-------------------------------------------------------------------------------------
            Dim iincert As New SqlCommand
            Dim CI As New SqlConnection
            Try
                CI.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CI.Open()
                iincert.Connection = CI
                iincert.CommandText = "insert into SUCURSALES values('" & STXTid.Text & "','" & STXTcalle.Text & "','" & STXTnsuc.Text & "','" & STXTciudad.Text & "','" & STXTestado.Text & "','" & STXTnomempresa.Text & "','" & STXTnombsuc.Text & "','" & STXTtelefono.Text & "','" & STXTnombregerente.Text & "','" & STXTtelefonogerente.Text & "','" & STXTnombresubgerente.Text & "','" & STXTtelefonosubgerente.Text & "')"
                iincert.ExecuteNonQuery()
                BSsucursales.EndEdit()
                'habilitamos el DGB
                DGVS.Enabled = True

                Refresh()
                MsgBox("Registro guardado exitosamente..")
                CI.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '-------------------------------------------------------------------------------------
        End If
        If TGD = 2 Then
            '-------------------------------------------------------------------------------------
            Dim iupdate As New SqlCommand
            Dim CU As New SqlConnection
            Try
                CU.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CU.Open()
                iupdate.Connection = CU
                iupdate.CommandText = "update SUCURSALES set CALLE_SUC='" & STXTcalle.Text & "', NUM_SUC = '" & STXTnsuc.Text & "', CIU_SUC='" & STXTciudad.Text & "',ESTADO_SUC='" & STXTestado.Text & "', NOM_EMP_SUC='" & STXTnomempresa.Text & "', NOM_SUC='" & STXTnombsuc.Text & "', TEL_SUC='" & STXTtelefono.Text & "', NOM_GEREN_SUC ='" & STXTnombregerente.Text & "', TEL_GEREN_SUC ='" & STXTtelefonogerente.Text & "', NOM_SUBGEREN_SUC='" & STXTnombresubgerente.Text & "', TEL_SUBGEREN_SUC='" & STXTtelefonosubgerente.Text & "' where ID_SUC='" & STXTid.Text & "'"
                iupdate.ExecuteNonQuery()
                BSsucursales.EndEdit()
                'habilitamos el DGB
                DGVS.Enabled = True

                Refresh()
                MsgBox("Registro modificado exitosamente..")
                CU.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '-------------------------------------------------------------------------------------
        End If


        'habilitamos la busqueda
        TXTbuscado.Enabled = True
        IdS.Enabled = True
        NsS.Enabled = True
        NeS.Enabled = True
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
        STXTid.Enabled = False
        STXTcalle.Enabled = False
        STXTnsuc.Enabled = False
        STXTciudad.Enabled = False
        STXTestado.Enabled = False
        STXTnomempresa.Enabled = False
        STXTnombsuc.Enabled = False
        STXTtelefono.Enabled = False
        STXTnombregerente.Enabled = False
        STXTtelefonogerente.Enabled = False
        STXTnombresubgerente.Enabled = False
        STXTtelefonosubgerente.Enabled = False
        'Cambia la bariable a 0 para reiniciarla
        TGD = 0
        DGVS.Enabled = True
    End Sub

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        'Cancelamos la edicion
        BSsucursales.CancelEdit()
        'habilitamos el DGB
        DGVS.Enabled = True
        'habilitamos la busqueda
        TXTbuscado.Enabled = True
        IdS.Enabled = True
        NsS.Enabled = True
        NeS.Enabled = True
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
        STXTid.Enabled = False
        STXTcalle.Enabled = False
        STXTnsuc.Enabled = False
        STXTciudad.Enabled = False
        STXTestado.Enabled = False
        STXTnomempresa.Enabled = False
        STXTnombsuc.Enabled = False
        STXTtelefono.Enabled = False
        STXTnombregerente.Enabled = False
        STXTtelefonogerente.Enabled = False
        STXTnombresubgerente.Enabled = False
        STXTtelefonosubgerente.Enabled = False
        'Cambia la bariable a 0 para reiniciarla
        TGD = 0
    End Sub



    Private Sub TXTbuscado_TextChanged(sender As Object, e As EventArgs) Handles TXTbuscado.TextChanged
        Dim dat = ""
        Try
            If IdS.Checked = True Then
                dat = "ID_SUC"
            ElseIf NsS.Checked = True Then
                dat = "NOM_SUC"
            ElseIf NeS.Checked = True Then
                dat = "NOM_EMP_SUC"
            End If
            BSsucursales.Filter = dat & " like '%" & TXTbuscado.Text & "%'"
            Dim conn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            Dim cmd As New SqlCommand("Select " & dat & " from SUCURSALES where " & dat & " like '%" & TXTbuscado.Text & "%'", conn)
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

    Private Sub CheckBoxTab_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTab.CheckedChanged
        If (CheckBoxTab.Checked) Then
            Me.Height = 515
            DGVS.Visible = True
        Else
            Me.Height = 345
            DGVS.Visible = False
        End If
    End Sub

    Private Sub STXTid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTid.KeyPress
        Numero(STXTid, 8, e)
    End Sub

    Private Sub STXTcalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTcalle.KeyPress
        Letra(STXTcalle, 50, e)
    End Sub

    Private Sub STXTnsuc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTnsuc.KeyPress
        Numero(STXTnsuc, 5, e)
    End Sub

    Private Sub STXTciudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTciudad.KeyPress
        Letra(STXTciudad, 20, e)
    End Sub

    Private Sub STXTestado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTestado.KeyPress
        Letra(STXTestado, 10, e)
    End Sub

    Private Sub STXTnomempresa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTnomempresa.KeyPress
        Letra(STXTnomempresa, 30, e)
    End Sub

    Private Sub STXTnombsuc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTnombsuc.KeyPress
        Letra(STXTnombsuc, 30, e)
    End Sub

    Private Sub STXTtelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTtelefono.KeyPress
        Numero(STXTtelefono, 15, e)
    End Sub

    Private Sub STXTnombregerente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTnombregerente.KeyPress
        Letra(STXTnombregerente, 30, e)
    End Sub

    Private Sub STXTtelefonogerente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTtelefonogerente.KeyPress
        Numero(STXTtelefonogerente, 15, e)
    End Sub

    Private Sub STXTnombresubgerente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTnombresubgerente.KeyPress
        Letra(STXTnombresubgerente, 30, e)
    End Sub

    Private Sub STXTtelefonosubgerente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles STXTtelefonosubgerente.KeyPress
        Numero(STXTtelefonosubgerente , 15, e)
    End Sub

    Private Sub TXTbuscado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTbuscado.KeyPress
        Numero(TXTbuscado, 50, e)
    End Sub
End Class