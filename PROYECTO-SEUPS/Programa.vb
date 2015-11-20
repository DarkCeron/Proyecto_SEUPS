Imports System.Data.SqlClient
Public Class Programa
    Dim CP As New SqlConnection
    Dim Comando As New SqlCommand
    Dim datos As New DataSet
    Dim adaptador As New SqlDataAdapter
    Dim BSprograma As New BindingSource

    Dim TGD As New Integer
    Private Sub Programa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DGVP.Visible = False
        DTP.Enabled = False
        Me.PCBXsuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        'se oculta combobox
        PCBXsuc.Visible = False
        PTXTidsuc.Visible = True
        'Se deshabilitan los textbox
        PTXTid.Enabled = False
        PTXTdia.Enabled = False
        PTXTmes.Enabled = False
        PTXTanio.Enabled = False
        PTXThora.Enabled = False
        PTXTidsuc.Enabled = False
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
        SuP.Enabled = True
        'Establecer la conexioncon sql
        CP.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
        Try

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
                        PCBXsuc.Items.Add(dt.Rows(i).Item("ID_SUC"))
                    Next
                End If
                cnn.Close()
            End Using

            CP.Open()
            Comando.CommandText = "select * from PROGRAMA"
            Comando.Connection = CP
            adaptador.SelectCommand = Comando
            adaptador.Fill(datos, "PROGRAMA")

            BSprograma.DataSource = datos
            BSprograma.DataMember = "PROGRAMA"
            DGVP.DataSource = BSprograma

            'Relacionar txt'  'fuente y con que se relaciona'
            PTXTid.DataBindings.Add("text", BSprograma, "ID_PRO")
            PTXTdia.DataBindings.Add("text", BSprograma, "DIA_PRO")
            PTXTmes.DataBindings.Add("text", BSprograma, "MES_PRO")
            PTXTanio.DataBindings.Add("text", BSprograma, "ANIO_PRO")
            PTXThora.DataBindings.Add("text", BSprograma, "HORA_PRO")
            PTXTidsuc.DataBindings.Add("text", BSprograma, "ID_SUC")
            PCBXsuc.DataBindings.Add("text", BSprograma, "ID_SUC")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Programa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CP.Close()
        MenuPrincipal.Enabled = True
    End Sub

    Private Sub Ant_Click(sender As Object, e As EventArgs) Handles Ant.Click
        Try
            BSprograma.MovePrevious()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Sig_Click(sender As Object, e As EventArgs) Handles Sig.Click
        Try
            BSprograma.MoveNext()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Ini_Click(sender As Object, e As EventArgs) Handles Ini.Click
        Try
            BSprograma.MoveFirst()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fin_Click(sender As Object, e As EventArgs) Handles Fin.Click
        Try
            BSprograma.MoveLast()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles Eliminar.Click

        Dim IP = PTXTid.Text
        If MessageBox.Show("Desea eliminar el registro " & IP & " ?", "Confirmacion de eliminacion.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Dim idelete As New SqlCommand
            Dim CE As New SqlConnection
            Try
                CE.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CE.Open()
                idelete.Connection = CE
                idelete.CommandText = "DELETE FROM PROGRAMA WHERE ID_PRO = '" & IP & "'"
                idelete.ExecuteNonQuery()
                BSprograma.RemoveCurrent() 'remove dgv
                MsgBox("Registro Eliminado Exitosamente...")
                CE.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        BSprograma.AddNew()
        Me.DTP.Enabled = True
        'des oculta combobox
        PCBXsuc.Visible = True
        PTXTidsuc.Visible = False
        'Se limpian los textbox
        PTXTid.Text = ""
        PTXTdia.Text = ""
        PTXTmes.Text = ""
        PTXTanio.Text = ""
        PTXThora.Text = ""
        PTXTidsuc.Text = ""
        'Se habilitan los textbox
        PTXTid.Enabled = True
        PTXTdia.Enabled = True
        PTXTmes.Enabled = True
        PTXTanio.Enabled = True
        PTXThora.Enabled = True
        PTXTidsuc.Enabled = True
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
        SuP.Enabled = False
        'çambiamos la bariable que indica guardado
        TGD = 1
        DGVP.Enabled = False
    End Sub
    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click
        Me.DTP.Enabled = True
        'des oculta combobox
        PCBXsuc.Visible = True
        PTXTidsuc.Visible = False
        'Se limpian los textbox 'NO SE MODIFICAN XQ SE MODIFICAN
        'PTXTid.Text = ""
        'PTXTdia.Text = ""
        'PTXTmes.Text = ""
        'PTXTanio.Text = ""
        'PTXThora.Text = ""
        'PTXTidsuc.Text = ""
        'Se habilitan los textbox
        'PTXTid.Enabled = True
        PTXTdia.Enabled = True
        PTXTmes.Enabled = True
        PTXTanio.Enabled = True
        PTXThora.Enabled = True
        PTXTidsuc.Enabled = True
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
        SuP.Enabled = False
        'çambiamos la bariable que indica MODIFICACION
        TGD = 2
        DGVP.Enabled = False
    End Sub

    Private Sub SuP_CheckedChanged(sender As Object, e As EventArgs) Handles SuP.CheckedChanged
        TXTbuscado.Enabled = True
        LBLbuscado.Text = "Id de Sucursal"
    End Sub
    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        'MsgBox(PCBXsuc.Text) 'CORRECTO
        DTP.Enabled = False
        BSprograma.EndEdit()
        If TGD = 1 Then
            '-------------------------------------------------------------------------------------
            Dim iincert As New SqlCommand
            Dim CI As New SqlConnection
            Try
                CI.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
                CI.Open()
                iincert.Connection = CI
                iincert.CommandText = "insert into PROGRAMA values('" & PTXTid.Text & "','" & PTXTdia.Text & "','" & PTXTmes.Text & "','" & PTXTanio.Text & "','" & PTXThora.Text & "','" & PCBXsuc.Text & "')"
                iincert.ExecuteNonQuery()
                BSprograma.EndEdit()
                'habilitamos el DGB
                DGVP.Enabled = True

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
                iupdate.CommandText = "update PROGRAMA set DIA_PRO='" & PTXTdia.Text & "', MES_PRO = '" & PTXTmes.Text & "',ANIO_PRO='" & PTXTanio.Text & "',HORA_PRO='" & PTXThora.Text & "', ID_SUC='" & PTXTidsuc.Text & "' where ID_PRO='" & PTXTid.Text & "'"
                iupdate.ExecuteNonQuery()
                BSprograma.EndEdit()
                'habilitamos el DGB
                DGVP.Enabled = True

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
        PCBXsuc.Enabled = True
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
        PTXTid.Enabled = False
        PTXTdia.Enabled = False
        PTXTmes.Enabled = False
        PTXTanio.Enabled = False
        PTXThora.Enabled = False
        PTXTidsuc.Enabled = False
        'Cambia la bariable a 0 para reiniciarla
        TGD = 0
        DGVP.Enabled = True
        PTXTidsuc.Visible = True
        PCBXsuc.Visible = False
        SuP.Enabled = True
    End Sub
    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        BSprograma.CancelEdit()
        DTP.Enabled = True
        DTP.Enabled = False
        'habilitamos la busqueda
        TXTbuscado.Enabled = True
        PCBXsuc.Enabled = True
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
        PTXTid.Enabled = False
        PTXTdia.Enabled = False
        PTXTmes.Enabled = False
        PTXTanio.Enabled = False
        PTXThora.Enabled = False
        PTXTidsuc.Enabled = False
        'Cambia la bariable a 0 para reiniciarla
        TGD = 0
        DGVP.Enabled = True
        PTXTidsuc.Visible = True
        PCBXsuc.Visible = False
        SuP.Enabled = True
    End Sub

    Private Sub TXTbuscado_TextChanged(sender As Object, e As EventArgs) Handles TXTbuscado.TextChanged
        If SuP.Checked = True Then
            BSprograma.Filter = "ID_SUC like '%" & TXTbuscado.Text & "%'"
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DTP.ValueChanged
        PTXTdia.Text = DTP.Value.Day
        PTXTmes.Text = DTP.Value.Month
        PTXTanio.Text = DTP.Value.Year
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTab.CheckedChanged
        If (CheckBoxTab.Checked) Then
            Me.Height = 445
            DGVP.Visible = True
        Else
            Me.Height = 255
            DGVP.Visible = False
        End If
    End Sub

    Private Sub PTXTanio_TextChanged(sender As Object, e As EventArgs) Handles PTXTanio.TextChanged
        Try
            DTP.Value = PTXTdia.Text & "-" & PTXTmes.Text & "-" & PTXTanio.Text
        Catch ex As Exception
            DTP.Value = Now.Day & "-" & Now.Month & "-" & Now.Year
            PTXTdia.Text = Now.Day
            PTXTmes.Text = Now.Month
            PTXTanio.Text = Now.Year
        End Try

    End Sub

    Private Sub PTXTid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTXTid.KeyPress
        Numero(PTXTid, 8, e)
    End Sub
End Class