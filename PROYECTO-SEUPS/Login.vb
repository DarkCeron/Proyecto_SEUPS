Imports System.Data.SqlClient
Imports System.IO

Public Class Login
    Dim C As New SqlConnection
    Private Sub BACEPTAR_Click(sender As Object, e As EventArgs) Handles BACEPTAR.Click
        Try
            Usuario = TXTuser.Text
            Contrasena = TXTpass.Text
            Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=master; User id=" & Usuario & "; password=" & Contrasena & ";")
                Dim iincert As New SqlCommand
                cnn.Open()
                iincert.Connection = cnn

                iincert.CommandText = "if db_id('SEUPS') is null begin CREATE DATABASE SEUPS end;"
                iincert.ExecuteNonQuery()

                cnn.Close()
            End Using
            Using cn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
                Dim iincert As New SqlCommand
                cn.Open()
                iincert.Connection = cn
                iincert.CommandText = "if object_id('BATERIAS' , 'U') is null begin create table BATERIAS(ID_BAT Varchar (8) primary key not null,MODE_BAT Varchar (15) not null,SERIE_BAT Varchar (20) not null,MARCA_BAT Varchar (20) not null,CAPACIDAD_BAT Varchar (30) not null,CANTI_BAT Varchar (80) not null) end;"
                iincert.ExecuteNonQuery() 'baterias

                iincert.CommandText = "if object_id('SUCURSALES' , 'U') is null begin create table SUCURSALES(ID_SUC Varchar (8) primary key not null,CALLE_SUC Varchar (50) not null,NUM_SUC Varchar (5) not null,CIU_SUC Varchar (20) not null,ESTADO_SUC Varchar (10) not null,NOM_EMP_SUC Varchar (30) not null,NOM_SUC Varchar (30) not null,TEL_SUC Varchar (15) not null,NOM_GEREN_SUC Varchar (30) not null,TEL_GEREN_SUC Varchar (15) not null,NOM_SUBGEREN_SUC Varchar (30) not null,TEL_SUBGEREN_SUC Varchar (15) not null,) end;"
                iincert.ExecuteNonQuery() 'sucursales

                iincert.CommandText = "if object_id('UPS' , 'U') is null begin create table UPS(ID_UPS Varchar (8)primary key not null,ID_SUC Varchar (8) not null,SERIE_UPS Varchar (20) not null,MARCA_BAT Varchar (20) not null,MOD_BAT Varchar (15) not null,ID_BAT Varchar (8) not null,foreign key (ID_SUC) references SUCURSALES(ID_SUC),foreign key (ID_BAT) references BATERIAS(ID_BAT),) end;"
                iincert.ExecuteNonQuery() 'ups

                iincert.CommandText = "if object_id('MANTENIMIENTO' , 'U') is null begin create table MANTENIMIENTO(FOLIO_MANT Varchar (15) primary key not null,DIA_MANT Varchar (2) not null,MES_MANT Varchar (9) not null,ANIO_MANT Varchar (4) not null,HORA_MANT Varchar (8) not null,ID_SUC Varchar (8) not null,ID_UPS Varchar (8) not null,IMG_MANT Varchar (MAX) not null,BAT_UTIL Varchar (15) not null,foreign key (ID_SUC) references SUCURSALES(ID_SUC),foreign key (ID_UPS) references UPS(ID_UPS)) end;"
                iincert.ExecuteNonQuery() 'mantenimiento

                iincert.CommandText = "if object_id('PROGRAMA' , 'U') is null begin create table PROGRAMA(ID_PRO Varchar (8) primary key not null,DIA_PRO Varchar (2) not null,MES_PRO Varchar (9) not null,ANIO_PRO Varchar (4) not null,HORA_PRO Varchar (8) not null,ID_SUC Varchar (8) not null,foreign key (ID_SUC) references SUCURSALES(ID_SUC)) end;"
                iincert.ExecuteNonQuery() 'programa

                cn.Close()
            End Using
            Me.Hide()
            MenuPrincipal.Show()
        Catch ex As Exception
        End Try

        Try
            FolderOutput = My.Computer.FileSystem.ReadAllText("C:\configuracion.txt")
            FolderOutput = Replace(FolderOutput, vbCrLf, "")

            Dim hide_file_info As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(FolderOutput)
            'hide_file_info.IsReadOnly = True
            hide_file_info.Attributes = hide_file_info.Attributes Or IO.FileAttributes.Hidden

        Catch ex As Exception
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

                Catch exx As Exception
                    MsgBox("Error al Guardar la ingormacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                    Try
                        strStreamWriter.Close() ' cerramos
                    Catch exss As Exception

                    End Try

                End Try
            End If

        End Try
       
    End Sub
    Private Sub BSALIR_Click(sender As Object, e As EventArgs) Handles BSALIR.Click
        If MessageBox.Show("Desea Salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            End 'Se sale del programa
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXTuser.Text = "sa"
        TXTpass.Text = "sa"
    End Sub

    Private Sub TXTuser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTuser.KeyPress
        Letra(TXTuser, 20, e)
    End Sub

    Private Sub TXTpass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTpass.KeyPress
        LetraYNumero(TXTpass, 20, e)
    End Sub
End Class