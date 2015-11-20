Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.SqlClient

Public Class ReporteEmpresa
    Dim ultimo = 0
    Private Sub ReporteEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button_Generar_reporte.Enabled = False
        'X aumenta de 0 3xx y en Y  comienza de forma inversa es decir: Y- el valor donde lo quiero ubicar
        'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, TextBox216.Text, X , Y , ROTACION) 'folio
        Dim rutas = Dir(Replace(FolderOutput, vbCrLf, "") & "\*.pdf")
        Do While rutas <> ""
            Dim t As Integer
            Try
                t = CInt(Int((rutas.ToString).Replace("-E.pdf", "")))
                If t > ultimo Then
                    ultimo = t
                End If
            Catch ex As Exception
            End Try
            rutas = Dir()
        Loop
        TextBox_Folio.Text = ultimo + 1

        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select ID_UPS from UPS"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen UPS. Agrega Algunas Primero..", MsgBoxStyle.Critical)
            Else
                For i = 0 To dt.Rows.Count - 1
                    ComboBoxU_UPS.Items.Add(dt.Rows(i).Item("ID_UPS"))
                Next
            End If
            cnn.Close()
        End Using

        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select NOM_SUC from SUCURSALES"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No existen SUCURSALES. Agrega Algunas Primero..", MsgBoxStyle.Critical)
            Else
                For i = 0 To dt.Rows.Count - 1
                    ComboBoxS_Direccion.Items.Add(dt.Rows(i).Item("NOM_SUC"))
                Next
            End If
            cnn.Close()
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Generar_reporte.Click
        Dim ruta As Integer
        Save.FileName = FolderOutput & "\" & TextBox_Folio.Text & "-E.pdf"

        If ruta = 2 Then GoTo salir
        Try
            Kill(Save.FileName)
        Catch ex As Exception
        End Try

        'incertar en mantenimientos un reporte
        Dim iincert As New SqlCommand
        Dim CI As New SqlConnection
        Try
            CI.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
            CI.Open()
            iincert.Connection = CI
            iincert.CommandText = "insert into MANTENIMIENTO values('" & TextBox_Folio.Text & "-E','" & DateTimePicker_Fecha.Value.Day.ToString() & "','" & DateTimePicker_Fecha.Value.Month.ToString() & "','" & DateTimePicker_Fecha.Value.Year.ToString() & "','" & DateTimePicker_Fecha.Value.Hour.ToString() & ":" & DateTimePicker_Fecha.Value.Minute.ToString() & "','" & TextBox2_dir1.Text & "','" & ComboBoxU_UPS.Text & "','" & Save.FileName & "')"
            iincert.ExecuteNonQuery()
            MsgBox("Registro guardado exitosamente..")
            CI.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo salir
        End Try
        'fin incertar en mantenimientos...

        Dim oDoc As New iTextSharp.text.Document(PageSize.LETTER, 40, 20, 0, 0)
        Dim pdfw As iTextSharp.text.pdf.PdfWriter
        Dim cb As PdfContentByte
        Dim linea As PdfContentByte
        Dim rectangulo As PdfContentByte
        Dim fuente As iTextSharp.text.pdf.BaseFont
        Dim NombreArchivo As String = Save.FileName

        Try

            pdfw = PdfWriter.GetInstance(oDoc, New FileStream(NombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            oDoc.Open() 'Apertura del documento.
            cb = pdfw.DirectContent
            linea = pdfw.DirectContent
            rectangulo = pdfw.DirectContent

            oDoc.NewPage() 'Agregamos una pagina.
            cb.BeginText() 'Iniciamos el flujo de bytes.

            'Instanciamos el objeto para la tipo de letra.
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)

            Try
                Dim png As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("C:\Users\ACER\Pictures\IMG_FINAL_HD.JPG")
                png.ScaleAbsolute(611, 787)
                png.SetAbsolutePosition(0, 0)
                cb.AddImage(png)
            Catch ex As Exception
            End Try
            'Bloque de codigo para llenado
            If (CheckBox_inspeccion.Checked) Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "X", 402, 788 - 111, 0) 'Checkbox de inspeccion
            ElseIf (CheckBox_preventivo.Checked) Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "X", 467, 788 - 111, 0) 'Checkbox de preventivo
            ElseIf CheckBox_correctivo.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "X", 533, 788 - 111, 0) 'Checkbox de correctivo
            ElseIf CheckBo_garantia.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "X", 591, 788 - 111, 0) 'Checkbox de garantia

            End If
            Dim hour As String = Now.ToString("HH:mm")
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox1_cliente.Text, 79, 788 - 147, 0) 'Cliente 12
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_dir1.Text, 79, 788 - 159, 0) 'Direccion 1
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox3_dir2.Text, 79, 788 - 170, 0) 'Direccion 2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_atencion.Text, 79, 788 - 182, 0) 'Atencion

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (Me.DateTimePicker_Fecha.Value.ToString).Split(New Char() {" "c})(0).ToString.Replace(".", ""), 99, 788 - 193, 0) 'fecha

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_hora.Text + ":" + TextBox_minutos.Text, 200, 788 - 193, 0) 'Hora de llegada
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, hour, 278, 788 - 194, 0) 'Hora de salida

            'MEDICIONES EN LA ENTRADA DEL UPS
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL1_v_F1_2.Text, 99, 788 - 215, 0) 'Voltajes f1-2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL1_v_F3_1.Text, 99, 788 - 227, 0) 'Voltajes f1-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL2_v_F2_3.Text, 164, 788 - 216, 0) 'Voltajes f2-3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL2_v_F2_N.Text, 164, 788 - 228, 0) 'Voltajes f2-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL3_v_F3_1.Text, 229, 788 - 217, 0) 'Voltajes f3-1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL3_v_F3_N.Text, 229, 788 - 229, 0) 'Voltajes f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL4_hz_Frec.Text, 292, 788 - 218, 0) 'Voltajes f3-1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL4_hz_N_T.Text, 292, 788 - 230, 0) 'Voltajes f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL1_c_F1.Text, 95, 788 - 239, 0) 'Corriente f1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL3_c_F3.Text, 159, 788 - 240, 0) 'Corriente f2

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL2_c_F2.Text, 225, 788 - 240, 0) 'Corriente f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxEL4_c_N.Text, 287, 788 - 240, 0) 'Corriente n

            'MEDICIONES EN LA SALIDA DEL UPS
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL1_v_F1_2.Text, 99, 788 - 274, 0) 'Voltajes f1-2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL1_v_F3_1.Text, 99, 788 - 286, 0) 'Voltajes f1-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL2_v_F2_3.Text, 164, 788 - 274, 0) 'Voltajes f2-3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL2_v_F2_N.Text, 164, 788 - 286, 0) 'Voltajes f2-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL3_v_F3_1.Text, 229, 788 - 275, 0) 'Voltajes f3-1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL3_v_F3_N.Text, 229, 788 - 287, 0) 'Voltajes f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL4_hz_Frec.Text, 292, 788 - 276, 0) 'Voltajes f3-1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL4_hz_N_T.Text, 292, 788 - 288, 0) 'Voltajes f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL1_c_F1.Text, 95, 788 - 297, 0) 'Corriente f1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL2_c_F2.Text, 159, 788 - 298, 0) 'Corriente f2

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL3_c_F3.Text, 225, 788 - 299, 0) 'Corriente f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxSL4_c_N.Text, 287, 788 - 299, 0) 'Corriente n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Porce_Carga.Text, 159, 788 - 310, 0) 'Porcentaje de carga

            'ACTIVIDADES DEL MANTENIMIENTO PREVENTIVO
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL3_v_F3_1.Text, 99, 788 - 342, 0) 'Voltajes f1-2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL2_v_F2_N.Text, 99, 788 - 354, 0) 'Voltajes f1-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL1_v_F1_N.Text, 164, 788 - 343, 0) 'Voltajes f2-3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL3_v_F3_N.Text, 164, 788 - 355, 0) 'Voltajes f2-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL2_v_F2_N.Text, 229, 788 - 343, 0) 'Voltajes f3-1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL1_hz_Frec.Text, 229, 788 - 355, 0) 'Voltajes f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL3_v_F3_N.Text, 292, 788 - 344, 0) 'Voltajes f3-1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxGL2_v_N_T.Text, 292, 788 - 356, 0) 'Voltajes f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, RichTextBoxG_observaciones.Text, 75, 788 - 366, 0) 'Observaciones


            'ACTIVIDADES DEL MANTENIMIENTO PREVENTIVO ("REVISION")
            If RadioButton_Rec_Rev_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 88, 788 - 422, 0) 'RECTIFICADOR. SI
            ElseIf RadioButton_Rec_Rev_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 122, 788 - 422, 0) 'RECTIFICADOR. NO
            End If
            If RadioButton_Inv_Rev_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 88, 788 - 432, 0) 'INVERSOR. SI
            ElseIf RadioButton_Inv_Rev_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 122, 788 - 432, 0) 'INVERSOR. NO
            End If

            If RadioButton_Bypa_Rev_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 88, 788 - 444, 0) 'ByPass. SI
            ElseIf RadioButton_Bypa_Rev_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 122, 788 - 444, 0) 'ByPass. NO
            End If

            If RadioButton_Vent_Rev_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 88, 788 - 455, 0) 'VENTILADORES. SI
            ElseIf RadioButton_Vent_Rev_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 122, 788 - 455, 0) 'VENTILADORES. NO
            End If

            If RadioButton_Bat_Rev_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 88, 788 - 466, 0) 'BATERIAS. SI
            ElseIf RadioButton_Bat_Rev_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 122, 788 - 466, 0) 'BATERIAS. NO
            End If

            If RadioButton_Conec_Rev_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 88, 788 - 477, 0) 'CONEXIONES. SI
            ElseIf RadioButton_Conec_Rev_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 122, 788 - 477, 0) 'CONEXIONES. NO
            End If

            'ACTIVIDADES DEL MANTENIMIENTO PREVENTIVO ("PRUEBAS")24
            If RadioButton_Rec_Pru_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 154, 788 - 422, 0) 'RECTIFICADOR. SI
            ElseIf RadioButton_Rec_Pru_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 188, 788 - 422, 0) 'RECTIFICADOR. NO
            End If
            If RadioButton_Inv_Pru_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 154, 788 - 432, 0) 'INVERSOR. SI
            ElseIf RadioButton_Inv_Pru_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 188, 788 - 432, 0) 'INVERSOR. NO
            End If

            If RadioButton_Bypa_Pru_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 154, 788 - 444, 0) 'ByPass. SI
            ElseIf RadioButton_Bypa_Pru_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 188, 788 - 444, 0) 'ByPass. NO
            End If

            If RadioButton_Vent_Pru_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 154, 788 - 455, 0) 'VENTILADORES. SI
            ElseIf RadioButton_Vent_Pru_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 188, 788 - 455, 0) 'VENTILADORES. NO
            End If

            If RadioButton_Bat_Pru_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 154, 788 - 466, 0) 'BATERIAS. SI
            ElseIf RadioButton_Bat_Pru_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 188, 788 - 466, 0) 'BATERIAS. NO
            End If

            If RadioButton_Conec_Pru_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 154, 788 - 477, 0) 'CONEXIONES. SI
            ElseIf RadioButton_Conec_Pru_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 188, 788 - 477, 0) 'CONEXIONES. NO
            End If

            'ACTIVIDADES DEL MANTENIMIENTO PREVENTIVO ("AJUSTES")32 1 2 y 2
            If RadioButton_Rec_Aju_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 220, 788 - 423, 0) 'RECTIFICADOR. SI
            ElseIf RadioButton_Rec_Aju_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 254, 788 - 423, 0) 'RECTIFICADOR. NO
            End If
            If RadioButton_Inv_Aju_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 220, 788 - 434, 0) 'INVERSOR. SI
            ElseIf RadioButton_Inv_Aju_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 254, 788 - 434, 0) 'INVERSOR. NO
            End If

            If RadioButton_Bypa_Aju_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 220, 788 - 446, 0) 'ByPass. SI
            ElseIf RadioButton_Bypa_Aju_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 254, 788 - 446, 0) 'ByPass. NO
            End If

            If RadioButton_Vent_Aju_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 220, 788 - 457, 0) 'VENTILADORES. SI
            ElseIf RadioButton_Vent_Aju_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 254, 788 - 457, 0) 'VENTILADORES. NO
            End If

            If RadioButton_Bat_Aju_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 220, 788 - 468, 0) 'BATERIAS. SI
            ElseIf RadioButton_Bat_Aju_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 254, 788 - 468, 0) 'BATERIAS. NO
            End If

            If RadioButton_Conec_Aju_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 220, 788 - 479, 0) 'CONEXIONES. SI
            ElseIf RadioButton_Conec_Aju_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 254, 788 - 479, 0) 'CONEXIONES. NO
            End If

            'ACTIVIDADES DEL MANTENIMIENTO PREVENTIVO ("LIMPIEZA")32 1 2 y 2
            If RadioButton_Rec_Lim_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 286, 788 - 422, 0) 'RECTIFICADOR. SI
            ElseIf RadioButton_Rec_Lim_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 318, 788 - 422, 0) 'RECTIFICADOR. NO
            End If
            If RadioButton_Inv_Lim_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 286, 788 - 434, 0) 'INVERSOR. SI
            ElseIf RadioButton_Inv_Lim_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 318, 788 - 434, 0) 'INVERSOR. NO
            End If

            If RadioButton_Bypa_Lim_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 286, 788 - 446, 0) 'ByPass. SI
            ElseIf RadioButton_Bypa_Lim_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 318, 788 - 446, 0) 'ByPass. NO
            End If

            If RadioButton_Vent_Lim_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 286, 788 - 457, 0) 'VENTILADORES. SI
            ElseIf RadioButton_Vent_Lim_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 318, 788 - 457, 0) 'VENTILADORES. NO
            End If

            If RadioButton_Bat_Lim_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 286, 788 - 468, 0) 'BATERIAS. SI
            ElseIf RadioButton_Bat_Lim_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 318, 788 - 468, 0) 'BATERIAS. NO
            End If

            If RadioButton_Conec_Lim_SI.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 286, 788 - 479, 0) 'CONEXIONES. SI
            ElseIf RadioButton_Conec_Lim_NO.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 318, 788 - 479, 0) 'CONEXIONES. NO
            End If



            'ACTIVIDADES DE MANTENIMIENTO PREVENTIVO("OBSERVACIONES")
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, RichTextBoxIE_Observaciones.Text, 74, 788 - 512, 0)

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Utilizadas.Text, 137, 788 - 535, 0) 'REFACCIONES UTILIZADAS
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Necesarias.Text, 268, 788 - 535, 0) 'REFACCIONES NECESARIAS

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Partida_1.Text, 10, 788 - 555, 0) 'PARTIDA 1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Partida_2.Text, 10, 788 - 567, 0) 'PARTIDA 2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Partida_3.Text, 10, 788 - 578, 0) 'PARTIDA 3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Partida_4.Text, 10, 788 - 590, 0) 'PARTIDA 4

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Cantidad_1.Text, 43, 788 - 555, 0) 'CANTIDAD 1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Cantidad_2.Text, 43, 788 - 567, 0) 'CANTIDAD 2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Cantidad_3.Text, 43, 788 - 578, 0) 'CANTIDAD 3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Cantidad_4.Text, 43, 788 - 590, 0) 'CANTIDAD 4

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Descripcion_1.Text, 78, 788 - 556, 0) 'DESCRIPCION 1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Descripcion_1.Text, 78, 788 - 567, 0) 'DESCRIPCION 2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Descripcion_1.Text, 78, 788 - 578, 0) 'DESCRIPCION 3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Descripcion_1.Text, 78, 788 - 590, 0) 'DESCRIPCION 4

            'EQUIPO, MARCA, MODELO, ETC
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Equipo.Text, 407, 788 - 139, 0) 'EQUIPO
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Marca.Text, 407, 788 - 150, 0) 'MARCA
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Modelo.Text, 407, 788 - 161, 0) 'MODELO
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Serie.Text, 407, 788 - 172, 0) 'SERIE
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_Capacidad.Text, 407, 788 - 183, 0) 'CAPACIDAD

            'SECCION DE VOLTAJE ENT/SAL
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_v_Entrada.Text, 435, 788 - 195, 0) 'ENTRADA
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ref_Nec_v_Salida.Text, 528, 788 - 196, 0) 'SALIDA

            'SECCION DE BATERIAS
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_Modelo.Text, 407, 788 - 218, 0) 'MODELO
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_Capacidad.Text, 407, 788 - 229, 0) 'CAPACIDAD
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_Cantidad.Text, 538, 788 - 219, 0) 'CANTIDAD
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_Bancos.Text, 538, 788 - 230, 0) 'BANCOS

            'BUS DE C.D.
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_BusCD_Flotacion_L2.Text, 538, 788 - 266, 0) 'CORRIENTE FLOTACION
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_BusCD_Descarga_L2.Text, 538, 788 - 277, 0) 'CORRIENTE DESCARGA

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_BusCD_Flotacion_L1.Text, 475, 788 - 266, 0) 'VOLTAJE FLOTACION
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Bat_BusCD_Descarga_L1.Text, 475, 788 - 277, 0) 'VOLTAJE DESCARGA



            'VOLTAJES DE BATERÍAS
            'BANCO 1A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_1.Text, 351, 788 - 334, 0) '1A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_2.Text, 351, 788 - 345, 0) '2A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_3.Text, 351, 788 - 356, 0) '3A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_4.Text, 351, 788 - 367, 0) '4A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_5.Text, 351, 788 - 378, 0) '5A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_6.Text, 351, 788 - 391, 0) '6A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_7.Text, 351, 788 - 402, 0) '7A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_8.Text, 351, 788 - 413, 0) '8A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_9.Text, 351, 788 - 424, 0) '9A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_10.Text, 351, 788 - 435, 0) '10A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_11.Text, 351, 788 - 446, 0) '11A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_12.Text, 351, 788 - 457, 0) '12A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_13.Text, 351, 788 - 468, 0) '13A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_14.Text, 351, 788 - 479, 0) '14A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_15.Text, 351, 788 - 490, 0) '15A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_16.Text, 351, 788 - 501, 0) '16A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_17.Text, 351, 788 - 513, 0) '17A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_18.Text, 351, 788 - 525, 0) '18A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_19.Text, 351, 788 - 536, 0) '19A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_20.Text, 351, 788 - 547, 0) '20A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_21.Text, 351, 788 - 559, 0) '21A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_22.Text, 351, 788 - 571, 0) '22A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_23.Text, 351, 788 - 582, 0) '23A

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_1.Text, 378, 788 - 334, 0) '1B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_2.Text, 378, 788 - 345, 0) '2B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_3.Text, 378, 788 - 356, 0) '3B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_4.Text, 378, 788 - 367, 0) '4B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_5.Text, 378, 788 - 378, 0) '5B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_6.Text, 378, 788 - 391, 0) '6B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_7.Text, 378, 788 - 402, 0) '7B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_8.Text, 378, 788 - 413, 0) '8B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_9.Text, 378, 788 - 424, 0) '9B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_10.Text, 378, 788 - 435, 0) '10B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_11.Text, 378, 788 - 446, 0) '11B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_12.Text, 378, 788 - 457, 0) '12B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_13.Text, 378, 788 - 468, 0) '13B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_14.Text, 378, 788 - 479, 0) '14B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_15.Text, 378, 788 - 490, 0) '15B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_16.Text, 378, 788 - 501, 0) '16B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_17.Text, 378, 788 - 513, 0) '17B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_18.Text, 378, 788 - 525, 0) '18B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_19.Text, 378, 788 - 536, 0) '19B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_20.Text, 378, 788 - 547, 0) '20B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_21.Text, 378, 788 - 559, 0) '21B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_22.Text, 378, 788 - 571, 0) '22B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_23.Text, 378, 788 - 582, 0) '23B
            'FIN

            'BANCO 1B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_24.Text, 415, 788 - 334, 0) '1A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_25.Text, 415, 788 - 345, 0) '2A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_26.Text, 415, 788 - 356, 0) '3A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_27.Text, 415, 788 - 367, 0) '4A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_28.Text, 415, 788 - 378, 0) '5A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_29.Text, 415, 788 - 391, 0) '6A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_30.Text, 415, 788 - 402, 0) '7A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_31.Text, 415, 788 - 413, 0) '8A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_32.Text, 415, 788 - 424, 0) '9A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_33.Text, 415, 788 - 435, 0) '10A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_34.Text, 415, 788 - 446, 0) '11A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_35.Text, 415, 788 - 457, 0) '12A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_36.Text, 415, 788 - 468, 0) '13A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_37.Text, 415, 788 - 479, 0) '14A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_38.Text, 415, 788 - 490, 0) '15A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_39.Text, 415, 788 - 501, 0) '16A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Flota_L1_40.Text, 415, 788 - 513, 0) '17A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox94.Text, 415, 788 - 525, 0) '18A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox92.Text, 415, 788 - 536, 0) '19A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox90.Text, 415, 788 - 547, 0) '20A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox88.Text, 415, 788 - 559, 0) '21A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox86.Text, 415, 788 - 571, 0) '22A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox84.Text, 415, 788 - 582, 0) '23A

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_24.Text, 441, 788 - 334, 0) '1B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_25.Text, 441, 788 - 345, 0) '2B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_26.Text, 441, 788 - 356, 0) '3B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_27.Text, 441, 788 - 367, 0) '4B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_28.Text, 441, 788 - 378, 0) '5B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_29.Text, 441, 788 - 391, 0) '6B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_30.Text, 441, 788 - 402, 0) '7B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_31.Text, 441, 788 - 413, 0) '8B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_32.Text, 441, 788 - 424, 0) '9B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_33.Text, 441, 788 - 435, 0) '10B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_34.Text, 441, 788 - 446, 0) '11B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_35.Text, 441, 788 - 457, 0) '12B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_36.Text, 441, 788 - 468, 0) '13B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_37.Text, 441, 788 - 479, 0) '14B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_38.Text, 441, 788 - 490, 0) '15B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_39.Text, 441, 788 - 501, 0) '16B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Desc_L2_40.Text, 441, 788 - 513, 0) '17B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 441, 788 - 525, 0) '18B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 441, 788 - 536, 0) '19B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 441, 788 - 547, 0) '20B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 441, 788 - 559, 0) '21B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 441, 788 - 571, 0) '22B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 441, 788 - 582, 0) '23B
            'FIN

            'BANCO 2A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_1.Text, 482, 788 - 334, 0) '1A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_2.Text, 482, 788 - 345, 0) '2A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_3.Text, 482, 788 - 356, 0) '3A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_4.Text, 482, 788 - 367, 0) '4A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_5.Text, 482, 788 - 378, 0) '5A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_6.Text, 482, 788 - 391, 0) '6A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_7.Text, 482, 788 - 402, 0) '7A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_8.Text, 482, 788 - 413, 0) '8A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_9.Text, 482, 788 - 424, 0) '9A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_10.Text, 482, 788 - 435, 0) '10A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_11.Text, 482, 788 - 446, 0) '11A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_12.Text, 482, 788 - 457, 0) '12A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_13.Text, 482, 788 - 468, 0) '13A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_14.Text, 482, 788 - 479, 0) '14A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_15.Text, 482, 788 - 490, 0) '15A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_16.Text, 482, 788 - 501, 0) '16A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_17.Text, 482, 788 - 513, 0) '17A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_18.Text, 482, 788 - 525, 0) '18A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_19.Text, 482, 788 - 536, 0) '19A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_20.Text, 482, 788 - 547, 0) '20A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_21.Text, 482, 788 - 559, 0) '21A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_22.Text, 482, 788 - 571, 0) '22A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_23.Text, 482, 788 - 582, 0) '23A

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_1.Text, 508, 788 - 334, 0) '1B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_2.Text, 508, 788 - 345, 0) '2B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_3.Text, 508, 788 - 356, 0) '3B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_4.Text, 508, 788 - 367, 0) '4B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_5.Text, 508, 788 - 378, 0) '5B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_6.Text, 508, 788 - 391, 0) '6B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_7.Text, 508, 788 - 402, 0) '7B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_8.Text, 508, 788 - 413, 0) '8B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_9.Text, 508, 788 - 424, 0) '9B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_10.Text, 508, 788 - 435, 0) '10B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_11.Text, 508, 788 - 446, 0) '11B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_12.Text, 508, 788 - 457, 0) '12B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_13.Text, 508, 788 - 468, 0) '13B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_14.Text, 508, 788 - 479, 0) '14B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_15.Text, 508, 788 - 490, 0) '15B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_16.Text, 508, 788 - 501, 0) '16B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_17.Text, 508, 788 - 513, 0) '17B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_18.Text, 508, 788 - 525, 0) '18B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_19.Text, 508, 788 - 536, 0) '19B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_20.Text, 508, 788 - 547, 0) '20B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_21.Text, 508, 788 - 559, 0) '21B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_22.Text, 508, 788 - 571, 0) '22B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_23.Text, 508, 788 - 582, 0) '23B
            'FIN

            'BANCO 2B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_24.Text, 548, 788 - 334, 0) '1A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_25.Text, 548, 788 - 345, 0) '2A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_26.Text, 548, 788 - 356, 0) '3A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_27.Text, 548, 788 - 367, 0) '4A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_28.Text, 548, 788 - 378, 0) '5A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_29.Text, 548, 788 - 391, 0) '6A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_30.Text, 548, 788 - 402, 0) '7A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_31.Text, 548, 788 - 413, 0) '8A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_32.Text, 548, 788 - 424, 0) '9A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_33.Text, 548, 788 - 435, 0) '10A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_34.Text, 548, 788 - 446, 0) '11A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_35.Text, 548, 788 - 457, 0) '12A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_36.Text, 548, 788 - 468, 0) '13A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_37.Text, 548, 788 - 479, 0) '14A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_38.Text, 548, 788 - 490, 0) '15A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_39.Text, 548, 788 - 501, 0) '16A
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L1_40.Text, 548, 788 - 513, 0) '17A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox97.Text, 548, 788 - 525, 0) '18A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox97.Text, 548, 788 - 536, 0) '19A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox97.Text, 548, 788 - 547, 0) '20A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox97.Text, 548, 788 - 559, 0) '21A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox97.Text, 548, 788 - 571, 0) '22A
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox97.Text, 548, 788 - 582, 0) '23A

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_24.Text, 574, 788 - 334, 0) '1B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_25.Text, 574, 788 - 345, 0) '2B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_26.Text, 574, 788 - 356, 0) '3B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_27.Text, 574, 788 - 367, 0) '4B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_28.Text, 574, 788 - 378, 0) '5B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_29.Text, 574, 788 - 391, 0) '6B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_30.Text, 574, 788 - 402, 0) '7B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_31.Text, 574, 788 - 413, 0) '8B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_32.Text, 574, 788 - 424, 0) '9B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_33.Text, 574, 788 - 435, 0) '10B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_34.Text, 574, 788 - 446, 0) '11B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_35.Text, 574, 788 - 457, 0) '12B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_36.Text, 574, 788 - 468, 0) '13B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_37.Text, 574, 788 - 479, 0) '14B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_38.Text, 574, 788 - 490, 0) '15B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_39.Text, 574, 788 - 501, 0) '16B
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Flota_L12_40.Text, 574, 788 - 513, 0) '17B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 788 - 525, 0) '18B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 788 - 536, 0) '19B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 788 - 547, 0) '20B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 788 - 559, 0) '21B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 788 - 571, 0) '22B
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 574, 788 - 582, 0) '23B
            'FIN

            'BANCO 1 RESISTENCIA
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco1_Resistencia.Text, 384, 788 - 592, 0) 'OHMS

            'BANCO 2 RESISTENCIA
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Banco2_Resistencia.Text, 508, 788 - 594, 0) 'OHMS

            'TRABAJO REALIZADO
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, RichTextBox_Trabajo_realizado.Text, 10, 172, 0) 'PARTIDA 4

            '¿COMO EVALUARÍA NUESTRO SERVICIO?
            If RadioButton_Excelente.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 340, 78, 0) 'EXCELENTE
            ElseIf RadioButton_Bueno.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 413, 78, 0) 'BUENO
            ElseIf RadioButton_Regular.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 488, 77, 0) 'REGULAR
            ElseIf RadioButton_Deficiente.Checked Then
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 566, 76, 0) 'DEFICIENTE
            End If


            'Fin de bloque de codigo para llenado
            cb.SetColorFill(BaseColor.RED)
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, TextBox_Folio.Text, 572, 788 - 93, 0) 'folio 
            cb.SetColorFill(BaseColor.BLACK)
            cb.EndText() 'Fin del flujo de bytes.


            'oDoc.NewPage() 'Agregamos una pagina.
            cb.BeginText() 'Iniciamos el flujo de bytes.
            'Instanciamos el objeto para la tipo de letra.
            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont
            cb.SetFontAndSize(fuente, 8)
            'Try
            '    Dim png As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("C:\IMG_FINAL_HD1.JPG")
            '    png.ScaleAbsolute(611, 787)
            '    png.SetAbsolutePosition(0, 0)
            '    cb.AddImage(png)
            'Catch ex As Exception
            'End Try



            'aqui codigo
            cb.EndText() 'Fin del flujo de bytes.

            pdfw.Flush() 'Forzamos vaciamiento del buffer.
            oDoc.Close() 'Cerramos el documento.
            MsgBox("Pdf creado Correctamente...")

        Catch ex As Exception
            'Si hubo una excepcion y el archivo existe …
            If File.Exists(NombreArchivo) Then
                'Cerramos el documento si esta abierto.
                'Y asi desbloqueamos el archivo para su eliminacion.
                If oDoc.IsOpen Then oDoc.Close()
                Try
                    File.Delete(NombreArchivo) '… lo eliminamos de disco.
                Catch exx As Exception
                End Try
            End If
            MsgBox("Pdf NO creado Correctamente...")
            'Throw New Exception("Error al generar archivo PDF (" & ex.Message & ")")
        Finally
            cb = Nothing
            pdfw = Nothing
            oDoc = Nothing
        End Try


salir:
    End Sub

    Private Sub ReporteEmpresa_clossing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Enabled = True
    End Sub

    Private Sub ComboBoxS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxS_Direccion.SelectedIndexChanged
        If ((ComboBoxS_Direccion.Text = "")) Then
        Else
            If ((ComboBoxU_UPS.Text = "")) Then
            Else
                Button_Generar_reporte.Enabled = True
                'MsgBox("Habilitando boton....")
            End If
        End If

        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select ID_SUC from SUCURSALES WHERE NOM_SUC = '" + ComboBoxS_Direccion.Text + "'"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            TextBox2_dir1.Text = dt.Rows(0).Item("ID_SUC")
            cnn.Close()
        End Using
    End Sub

    Private Sub ComboBoxU_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxU_UPS.SelectedIndexChanged
        If ((ComboBoxS_Direccion.Text = "")) Then
        Else
            If ((ComboBoxU_UPS.Text = "")) Then
            Else
                Button_Generar_reporte.Enabled = True
                'MsgBox("Habilitando boton....")
            End If
        End If
    End Sub

    Private Sub TextBox1_client_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1_cliente.KeyPress
        Letras(TextBox1_cliente, 25, e)
    End Sub

    Private Sub TextBox_aten_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_atencion.KeyPress
        Letras(TextBox_atencion, 25, e)
    End Sub

    Private Sub TextBox_hora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_hora.KeyPress
        Numero(TextBox_hora, 2, e)
    End Sub

    Private Sub TextBox_minutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_minutos.KeyPress
        Numero(TextBox_minutos, 2, e)
    End Sub
    'MEDICIONES EN LA ENTRADA DEL UPS 1 A
    Private Sub TextBox23_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL1_v_F1_2.KeyPress
        Numero(TextBoxEL1_v_F1_2, 5, e)
    End Sub

    Private Sub TextBox21_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL1_v_F3_1.KeyPress
        Numero(TextBoxEL1_v_F3_1, 5, e)
    End Sub




    Private Sub TextBox19_c_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL1_c_F1.KeyPress
        Numero(TextBoxEL1_c_F1, 5, e)
    End Sub

    Private Sub TextBox22_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL2_v_F2_3.KeyPress
        Numero(TextBoxEL2_v_F2_3, 5, e)
    End Sub

    Private Sub TextBox20_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL2_v_F2_N.KeyPress
        Numero(TextBoxEL2_v_F2_N, 5, e)
    End Sub

    Private Sub TextBox18_c_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL2_c_F2.KeyPress
        Numero(TextBoxEL2_c_F2, 5, e)
    End Sub

    Private Sub TextBox223_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL3_v_F3_1.KeyPress
        Numero(TextBoxEL3_v_F3_1, 5, e)
    End Sub

    Private Sub TextBox221_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL3_v_F3_N.KeyPress
        Numero(TextBoxEL3_v_F3_N, 5, e)
    End Sub

    Private Sub TextBox17_c_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL3_c_F3.KeyPress
        Numero(TextBoxEL3_c_F3, 5, e)
    End Sub

    Private Sub TextBox222_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL4_hz_Frec.KeyPress
        Numero(TextBoxEL4_hz_Frec, 5, e)
    End Sub

    Private Sub TextBox220_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL4_hz_N_T.KeyPress
        Numero(TextBoxEL4_hz_N_T, 5, e)
    End Sub

    Private Sub TextBox16_c_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEL4_c_N.KeyPress
        Numero(TextBoxEL4_c_N, 5, e)
    End Sub

    'MEDICIONES EN LA ENTRADA DEL UPS 1 B

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL1_v_F1_2.KeyPress
        Numero(TextBoxSL1_v_F1_2, 5, e)
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL1_v_F3_1.KeyPress
        Numero(TextBoxSL1_v_F3_1, 5, e)
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL1_c_F1.KeyPress
        Numero(TextBoxSL1_c_F1, 5, e)
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL2_v_F2_3.KeyPress
        Numero(TextBoxSL2_v_F2_3, 5, e)
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL2_v_F2_N.KeyPress
        Numero(TextBoxSL2_v_F2_N, 5, e)
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL2_c_F2.KeyPress
        Numero(TextBoxSL2_c_F2, 5, e)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL3_v_F3_1.KeyPress
        Numero(TextBoxSL3_v_F3_1, 5, e)
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL3_v_F3_N.KeyPress
        Numero(TextBoxSL3_v_F3_N, 5, e)
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL3_c_F3.KeyPress
        Numero(TextBoxSL3_c_F3, 5, e)
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL4_hz_Frec.KeyPress
        Numero(TextBoxSL4_hz_Frec, 5, e)
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL4_hz_N_T.KeyPress
        Numero(TextBoxSL4_hz_N_T, 5, e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSL4_c_N.KeyPress
        Numero(TextBoxSL4_c_N, 5, e)
    End Sub

    Private Sub TextBox16_pc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Porce_Carga.KeyPress
        Numero(TextBox_Porce_Carga, 10, e)
    End Sub

    'VOLTAJE DE GENERACION DE EMERGENCIA

    Private Sub TextBox32_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL1_v_F1_2.KeyPress
        Numero(TextBoxGL1_v_F1_2, 5, e)
    End Sub

    Private Sub TextBox29_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL1_v_F1_N.KeyPress
        Numero(TextBoxGL1_v_F1_N, 5, e)
    End Sub

    Private Sub TextBox26_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL1_hz_Frec.KeyPress
        Numero(TextBoxGL1_hz_Frec, 5, e)
    End Sub

    Private Sub TextBox31_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3GL2_v_F2_N.KeyPress
        Numero(TextBox3GL2_v_F2_N, 5, e)
    End Sub

    Private Sub TextBox28_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL2_v_F2_N.KeyPress
        Numero(TextBoxGL2_v_F2_N, 5, e)
    End Sub

    Private Sub TextBox25_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL2_v_N_T.KeyPress
        Numero(TextBoxGL2_v_N_T, 5, e)
    End Sub

    Private Sub TextBox30_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL3_v_F3_1.KeyPress
        Numero(TextBoxGL3_v_F3_1, 5, e)
    End Sub

    Private Sub TextBox27_v_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxGL3_v_F3_N.KeyPress
        Numero(TextBoxGL3_v_F3_N, 5, e)
    End Sub

    'OBSERVACIONES  
    Private Sub RichTextBox1_observaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBoxG_observaciones.KeyPress
        LetrasCamText(RichTextBoxG_observaciones, 200, e)
    End Sub

    'INSTALACION ELECTRICA "OBSERVACIONES"

    Private Sub RichTextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBoxIE_Observaciones.KeyPress
        LetrasCamText(RichTextBoxIE_Observaciones, 200, e)
    End Sub

    'REFACCIONES NECESARIAS

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Utilizadas.KeyPress
        Numero(TextBox_Ref_Nec_Utilizadas, 3, e)
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Necesarias.KeyPress
        Numero(TextBox_Ref_Nec_Necesarias, 3, e)
    End Sub

    Private Sub TextBox25_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Partida_1.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Partida_1, 8, e)
    End Sub

    Private Sub TextBox27_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Partida_2.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Partida_2, 8, e)
    End Sub

    Private Sub TextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Partida_3.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Partida_3, 8, e)
    End Sub

    Private Sub TextBox31_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Partida_4.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Partida_4, 8, e)
    End Sub

    Private Sub TextBox26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Cantidad_1.KeyPress
        Numero(TextBox_Ref_Nec_Necesarias, 6, e)
    End Sub

    Private Sub TextBox28_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Cantidad_2.KeyPress
        Numero(TextBox_Ref_Nec_Cantidad_2, 6, e)
    End Sub

    Private Sub TextBox30_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Cantidad_3.KeyPress
        Numero(TextBox_Ref_Nec_Cantidad_3, 6, e)
    End Sub

    Private Sub TextBox32_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Cantidad_4.KeyPress
        Numero(TextBox_Ref_Nec_Cantidad_4, 6, e)
    End Sub

    Private Sub TextBox33_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Descripcion_1.KeyPress
        Letras(TextBox_Ref_Nec_Descripcion_1, 50, e)
    End Sub

    Private Sub TextBox34_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Descripcion_2.KeyPress
        Letras(TextBox_Ref_Nec_Descripcion_2, 50, e)
    End Sub

    Private Sub TextBox35_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Descripcion_3.KeyPress
        Letras(TextBox_Ref_Nec_Descripcion_3, 50, e)
    End Sub

    Private Sub TextBox36_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Descripcion_4.KeyPress
        Letras(TextBox_Ref_Nec_Descripcion_4, 50, e)
    End Sub

    Private Sub TextBox37_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Descripcion.KeyPress
        Letras(TextBox_Ref_Nec_Descripcion, 50, e)
    End Sub

    Private Sub TextBox38_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Equipo.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Descripcion_1, 50, e)
    End Sub

    Private Sub TextBox39_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Marca.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Marca, 50, e)
    End Sub

    Private Sub TextBox40_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Modelo.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Modelo, 20, e)
    End Sub

    Private Sub TextBox41_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Serie.KeyPress
        LetraYNumero(TextBox_Ref_Nec_Serie, 20, e)
    End Sub

    'BANCO 1 A
    Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_Capacidad.KeyPress
        Numero(TextBox_Ref_Nec_Capacidad, 6, e)
    End Sub

    Private Sub TextBox43_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_v_Entrada.KeyPress
        Numero(TextBox_Ref_Nec_v_Entrada, 6, e)
    End Sub

    Private Sub TextBox44_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ref_Nec_v_Salida.KeyPress
        Numero(TextBox_Ref_Nec_v_Salida, 6, e)
    End Sub

    Private Sub TextBox45_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_Modelo.KeyPress
        LetraYNumero(TextBox_Bat_Modelo, 20, e)
    End Sub

    Private Sub TextBox48_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_Capacidad.KeyPress
        Numero(TextBox_Bat_Capacidad, 6, e)
    End Sub

    Private Sub TextBox46_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_Cantidad.KeyPress
        Numero(TextBox_Bat_Cantidad, 6, e)
    End Sub

    Private Sub TextBox47_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_Bancos.KeyPress
        Numero(TextBox_Bat_Bancos, 8, e)
    End Sub

    Private Sub TextBox56_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_BusCD_Flotacion_L1.KeyPress
        Numero(TextBox_Bat_BusCD_Flotacion_L1, 6, e)
    End Sub

    Private Sub TextBox52_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_BusCD_Descarga_L1.KeyPress
        Numero(TextBox_Bat_BusCD_Descarga_L1, 6, e)
    End Sub

    Private Sub TextBox55_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_BusCD_Flotacion_L2.KeyPress
        Numero(TextBox_Bat_BusCD_Flotacion_L2, 6, e)
    End Sub

    Private Sub TextBox51_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Bat_BusCD_Descarga_L2.KeyPress
        Numero(TextBox_Bat_BusCD_Descarga_L2, 6, e)
    End Sub

    Private Sub TextBox53_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_1.KeyPress
        Numero(TextBox_Banco1_Flota_L1_1, 4, e)
    End Sub

    Private Sub TextBox60_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_2.KeyPress
        Numero(TextBox_Banco1_Flota_L1_2, 4, e)
    End Sub

    Private Sub TextBox62_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_3.KeyPress
        Numero(TextBox_Banco1_Flota_L1_3, 4, e)
    End Sub

    Private Sub TextBox64_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_4.KeyPress
        Numero(TextBox_Banco1_Flota_L1_4, 4, e)
    End Sub

    Private Sub TextBox66_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_5.KeyPress

    End Sub

    Private Sub TextBox68_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_6.KeyPress
        Numero(TextBox_Banco1_Flota_L1_6, 4, e)
    End Sub

    Private Sub TextBox70_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_7.KeyPress
        Numero(TextBox_Banco1_Flota_L1_7, 4, e)
    End Sub

    Private Sub TextBox72_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_8.KeyPress
        Numero(TextBox_Banco1_Flota_L1_8, 4, e)
    End Sub

    Private Sub TextBox74_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_9.KeyPress
        Numero(TextBox_Banco1_Flota_L1_9, 4, e)
    End Sub

    Private Sub TextBox76_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_10.KeyPress
        Numero(TextBox_Banco1_Flota_L1_19, 4, e)
    End Sub

    Private Sub TextBox54_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_1.KeyPress
        Numero(TextBox_Banco1_Desc_L2_1, 4, e)
    End Sub

    Private Sub TextBox59_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_2.KeyPress
        Numero(TextBox_Banco1_Desc_L2_2, 4, e)
    End Sub

    Private Sub TextBox61_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_3.KeyPress
        Numero(TextBox_Banco1_Desc_L2_3, 4, e)
    End Sub

    Private Sub TextBox63_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_4.KeyPress
        Numero(TextBox_Banco1_Desc_L2_4, 4, e)
    End Sub

    Private Sub TextBox65_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_5.KeyPress
        Numero(TextBox_Banco1_Desc_L2_5, 4, e)
    End Sub

    Private Sub TextBox67_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_6.KeyPress
        Numero(TextBox_Banco1_Desc_L2_6, 4, e)
    End Sub

    Private Sub TextBox69_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_7.KeyPress
        Numero(TextBox_Banco1_Desc_L2_7, 4, e)
    End Sub

    Private Sub TextBox71_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_8.KeyPress
        Numero(TextBox_Banco1_Desc_L2_8, 4, e)
    End Sub

    Private Sub TextBox73_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_9.KeyPress
        Numero(TextBox_Banco1_Desc_L2_9, 4, e)
    End Sub

    Private Sub TextBox75_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_10.KeyPress
        Numero(TextBox_Banco1_Desc_L2_10, 4, e)
    End Sub

    Private Sub TextBox94_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_11.KeyPress
        Numero(TextBox_Banco1_Flota_L1_11, 4, e)
    End Sub

    Private Sub TextBox92_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_12.KeyPress
        Numero(TextBox_Banco1_Flota_L1_12, 4, e)
    End Sub

    Private Sub TextBox90_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_13.KeyPress
        Numero(TextBox_Banco1_Flota_L1_13, 4, e)
    End Sub

    Private Sub TextBox88_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_14.KeyPress
        Numero(TextBox_Banco1_Flota_L1_14, 4, e)
    End Sub

    Private Sub TextBox86_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_15.KeyPress
        Numero(TextBox_Banco1_Flota_L1_15, 4, e)
    End Sub

    Private Sub TextBox84_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_16.KeyPress
        Numero(TextBox_Banco1_Flota_L1_16, 4, e)
    End Sub

    Private Sub TextBox82_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_17.KeyPress
        Numero(TextBox_Banco1_Flota_L1_17, 4, e)
    End Sub

    Private Sub TextBox80_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_18.KeyPress
        Numero(TextBox_Banco1_Flota_L1_18, 4, e)
    End Sub

    Private Sub TextBox78_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_19.KeyPress
        Numero(TextBox_Banco1_Flota_L1_19, 4, e)
    End Sub

    Private Sub TextBox58_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_20.KeyPress
        Numero(TextBox_Banco1_Flota_L1_20, 4, e)
    End Sub

    Private Sub TextBox93_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_11.KeyPress
        Numero(TextBox_Banco1_Desc_L2_11, 4, e)
    End Sub

    Private Sub TextBox91_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_12.KeyPress
        Numero(TextBox_Banco1_Desc_L2_12, 4, e)
    End Sub

    Private Sub TextBox89_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_13.KeyPress
        Numero(TextBox_Banco1_Desc_L2_13, 4, e)
    End Sub

    Private Sub TextBox87_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_14.KeyPress
        Numero(TextBox_Banco1_Desc_L2_14, 4, e)
    End Sub

    Private Sub TextBox85_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_15.KeyPress
        Numero(TextBox_Banco1_Desc_L2_15, 4, e)
    End Sub

    Private Sub TextBox83_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_16.KeyPress
        Numero(TextBox_Banco1_Desc_L2_16, 4, e)
    End Sub

    Private Sub TextBox81_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_17.KeyPress
        Numero(TextBox_Banco1_Desc_L2_17, 4, e)
    End Sub

    Private Sub TextBox79_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_18.KeyPress
        Numero(TextBox_Banco1_Desc_L2_18, 4, e)
    End Sub

    Private Sub TextBox77_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_19.KeyPress
        Numero(TextBox_Banco1_Desc_L2_19, 4, e)
    End Sub

    Private Sub TextBox57_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_20.KeyPress
        Numero(TextBox_Banco1_Desc_L2_20, 4, e)
    End Sub

    'BANCO 1 B

    Private Sub TextBox134_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_21.KeyPress
        Numero(TextBox_Banco1_Flota_L1_21, 4, e)
    End Sub

    Private Sub TextBox132_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_22.KeyPress
        Numero(TextBox_Banco1_Flota_L1_22, 4, e)
    End Sub

    Private Sub TextBox130_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_23.KeyPress
        Numero(TextBox_Banco1_Flota_L1_23, 4, e)
    End Sub

    Private Sub TextBox128_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_24.KeyPress
        Numero(TextBox_Banco1_Flota_L1_24, 4, e)
    End Sub

    Private Sub TextBox126_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_25.KeyPress
        Numero(TextBox_Banco1_Flota_L1_25, 4, e)
    End Sub

    Private Sub TextBox124_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_26.KeyPress
        Numero(TextBox_Banco1_Flota_L1_26, 4, e)
    End Sub

    Private Sub TextBox122_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_27.KeyPress
        Numero(TextBox_Banco1_Flota_L1_27, 4, e)
    End Sub

    Private Sub TextBox120_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_28.KeyPress
        Numero(TextBox_Banco1_Flota_L1_28, 4, e)
    End Sub

    Private Sub TextBox118_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_29.KeyPress
        Numero(TextBox_Banco1_Flota_L1_29, 4, e)
    End Sub

    Private Sub TextBox116_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_30.KeyPress
        Numero(TextBox_Banco1_Flota_L1_30, 4, e)
    End Sub

    Private Sub TextBox133_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_21.KeyPress
        Numero(TextBox_Banco1_Desc_L2_21, 4, e)
    End Sub

    Private Sub TextBox131_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_22.KeyPress
        Numero(TextBox_Banco1_Desc_L2_22, 4, e)
    End Sub

    Private Sub TextBox129_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_23.KeyPress
        Numero(TextBox_Banco1_Desc_L2_23, 4, e)
    End Sub

    Private Sub TextBox127_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_24.KeyPress
        Numero(TextBox_Banco1_Desc_L2_24, 4, e)
    End Sub

    Private Sub TextBox125_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_25.KeyPress
        Numero(TextBox_Banco1_Desc_L2_25, 4, e)
    End Sub

    Private Sub TextBox123_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_26.KeyPress
        Numero(TextBox_Banco1_Desc_L2_26, 4, e)
    End Sub

    Private Sub TextBox121_MouseEnter(sender As Object, e As EventArgs) Handles TextBox_Banco1_Desc_L2_27.MouseEnter
        Numero(TextBox_Banco1_Desc_L2_27, 4, e)
    End Sub

    Private Sub TextBox119_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_28.KeyPress
        Numero(TextBox_Banco1_Desc_L2_28, 4, e)
    End Sub

    Private Sub TextBox117_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_29.KeyPress
        Numero(TextBox_Banco1_Desc_L2_29, 4, e)
    End Sub

    Private Sub TextBox115_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_30.KeyPress
        Numero(TextBox_Banco1_Desc_L2_30, 4, e)
    End Sub

    Private Sub TextBox114_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_31.KeyPress
        Numero(TextBox_Banco1_Flota_L1_31, 4, e)
    End Sub

    Private Sub TextBox112_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_32.KeyPress
        Numero(TextBox_Banco1_Flota_L1_32, 4, e)
    End Sub

    Private Sub TextBox110_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_33.KeyPress
        Numero(TextBox_Banco1_Flota_L1_33, 4, e)
    End Sub

    Private Sub TextBox108_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_34.KeyPress
        Numero(TextBox_Banco1_Flota_L1_34, 4, e)
    End Sub

    Private Sub TextBox106_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_35.KeyPress
        Numero(TextBox_Banco1_Flota_L1_35, 4, e)
    End Sub

    Private Sub TextBox104_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_36.KeyPress
        Numero(TextBox_Banco1_Flota_L1_36, 4, e)
    End Sub

    Private Sub TextBox102_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_37.KeyPress
        Numero(TextBox_Banco1_Flota_L1_37, 4, e)
    End Sub

    Private Sub TextBox100_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_38.KeyPress
        Numero(TextBox_Banco1_Flota_L1_38, 4, e)
    End Sub

    Private Sub TextBox98_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_39.KeyPress
        Numero(TextBox_Banco1_Flota_L1_39, 4, e)
    End Sub

    Private Sub TextBox96_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Flota_L1_40.KeyPress
        Numero(TextBox_Banco1_Flota_L1_40, 4, e)
    End Sub

    Private Sub TextBox113_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_31.KeyPress
        Numero(TextBox_Banco1_Desc_L2_31, 4, e)
    End Sub

    Private Sub TextBox111_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_32.KeyPress
        Numero(TextBox_Banco1_Desc_L2_32, 4, e)
    End Sub

    Private Sub TextBox109_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_33.KeyPress
        Numero(TextBox_Banco1_Desc_L2_33, 4, e)
    End Sub

    Private Sub TextBox107_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_34.KeyPress
        Numero(TextBox_Banco1_Desc_L2_34, 4, e)
    End Sub

    Private Sub TextBox105_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_35.KeyPress
        Numero(TextBox_Banco1_Desc_L2_35, 4, e)
    End Sub

    Private Sub TextBox103_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_36.KeyPress
        Numero(TextBox_Banco1_Desc_L2_36, 4, e)
    End Sub

    Private Sub TextBox101_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_37.KeyPress
        Numero(TextBox_Banco1_Desc_L2_37, 4, e)
    End Sub

    Private Sub TextBox99_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_38.KeyPress
        Numero(TextBox_Banco1_Desc_L2_38, 4, e)
    End Sub

    Private Sub TextBox97_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_39.KeyPress
        Numero(TextBox_Banco1_Desc_L2_39, 4, e)
    End Sub

    Private Sub TextBox95_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Desc_L2_40.KeyPress
        Numero(TextBox_Banco1_Desc_L2_40, 4, e)
    End Sub

    Private Sub TextBox216_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco1_Resistencia.KeyPress
        Numero(TextBox_Banco1_Resistencia, 6, e)
    End Sub

    'BANCO 2 A
    Private Sub TextBox214_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_1.KeyPress
        Numero(TextBox_Banco2_Flota_L1_1, 4, e)
    End Sub

    Private Sub TextBox212_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_2.KeyPress
        Numero(TextBox_Banco2_Flota_L1_2, 4, e)
    End Sub

    Private Sub TextBox210_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_3.KeyPress
        Numero(TextBox_Banco2_Flota_L1_3, 4, e)
    End Sub

    Private Sub TextBox208_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_4.KeyPress
        Numero(TextBox_Banco2_Flota_L1_4, 4, e)
    End Sub

    Private Sub TextBox206_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_5.KeyPress
        Numero(TextBox_Banco2_Flota_L1_5, 4, e)
    End Sub

    Private Sub TextBox204_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_6.KeyPress
        Numero(TextBox_Banco2_Flota_L1_6, 4, e)
    End Sub

    Private Sub TextBox202_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_7.KeyPress
        Numero(TextBox_Banco2_Flota_L1_7, 4, e)
    End Sub

    Private Sub TextBox200_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_8.KeyPress
        Numero(TextBox_Banco2_Flota_L1_8, 4, e)
    End Sub

    Private Sub TextBox198_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_9.KeyPress
        Numero(TextBox_Banco2_Flota_L1_9, 4, e)
    End Sub

    Private Sub TextBox196_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_10.KeyPress
        Numero(TextBox_Banco2_Flota_L1_10, 4, e)
    End Sub

    Private Sub TextBox213_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_1.KeyPress
        Numero(TextBox_Banco2_Flota_L12_1, 4, e)
    End Sub

    Private Sub TextBox211_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_2.KeyPress
        Numero(TextBox_Banco2_Flota_L12_2, 4, e)
    End Sub

    Private Sub TextBox209_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_3.KeyPress
        Numero(TextBox_Banco2_Flota_L12_3, 4, e)
    End Sub

    Private Sub TextBox207_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_4.KeyPress
        Numero(TextBox_Banco2_Flota_L12_4, 4, e)
    End Sub

    Private Sub TextBox205_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_5.KeyPress
        Numero(TextBox_Banco2_Flota_L12_5, 4, e)
    End Sub

    Private Sub TextBox203_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_6.KeyPress
        Numero(TextBox_Banco2_Flota_L12_6, 4, e)
    End Sub

    Private Sub TextBox201_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_7.KeyPress
        Numero(TextBox_Banco2_Flota_L12_7, 4, e)
    End Sub

    Private Sub TextBox199_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_8.KeyPress
        Numero(TextBox_Banco2_Flota_L12_8, 4, e)
    End Sub

    Private Sub TextBox197_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_9.KeyPress
        Numero(TextBox_Banco2_Flota_L12_9, 4, e)
    End Sub

    Private Sub TextBox195_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_10.KeyPress
        Numero(TextBox_Banco2_Flota_L12_10, 4, e)
    End Sub

    Private Sub TextBox194_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_11.KeyPress
        Numero(TextBox_Banco2_Flota_L1_11, 4, e)
    End Sub

    Private Sub TextBox192_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_12.KeyPress
        Numero(TextBox_Banco2_Flota_L1_12, 4, e)
    End Sub

    Private Sub TextBox190_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_13.KeyPress
        Numero(TextBox_Banco2_Flota_L1_13, 4, e)
    End Sub

    Private Sub TextBox188_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_14.KeyPress
        Numero(TextBox_Banco2_Flota_L1_14, 4, e)
    End Sub

    Private Sub TextBox186_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_15.KeyPress
        Numero(TextBox_Banco2_Flota_L1_15, 4, e)
    End Sub

    Private Sub TextBox184_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_16.KeyPress
        Numero(TextBox_Banco2_Flota_L1_16, 4, e)
    End Sub

    Private Sub TextBox182_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_17.KeyPress
        Numero(TextBox_Banco2_Flota_L1_17, 4, e)
    End Sub

    Private Sub TextBox180_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_18.KeyPress
        Numero(TextBox_Banco2_Flota_L1_18, 4, e)
    End Sub

    Private Sub TextBox178_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_19.KeyPress
        Numero(TextBox_Banco2_Flota_L1_19, 4, e)
    End Sub

    Private Sub TextBox176_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_20.KeyPress
        Numero(TextBox_Banco2_Flota_L1_20, 4, e)
    End Sub

    Private Sub TextBox193_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_11.KeyPress
        Numero(TextBox_Banco2_Flota_L12_11, 4, e)
    End Sub

    Private Sub TextBox191_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_12.KeyPress
        Numero(TextBox_Banco2_Flota_L12_12, 4, e)
    End Sub

    Private Sub TextBox189_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_13.KeyPress
        Numero(TextBox_Banco2_Flota_L12_13, 4, e)
    End Sub

    Private Sub TextBox187_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_14.KeyPress
        Numero(TextBox_Banco2_Flota_L12_14, 4, e)
    End Sub

    Private Sub TextBox185_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_15.KeyPress
        Numero(TextBox_Banco2_Flota_L12_15, 4, e)
    End Sub

    Private Sub TextBox183_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_16.KeyPress
        Numero(TextBox_Banco2_Flota_L12_16, 4, e)
    End Sub

    Private Sub TextBox181_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_17.KeyPress
        Numero(TextBox_Banco2_Flota_L12_17, 4, e)
    End Sub

    Private Sub TextBox179_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_18.KeyPress
        Numero(TextBox_Banco2_Flota_L12_18, 4, e)
    End Sub

    Private Sub TextBox177_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_19.KeyPress
        Numero(TextBox_Banco2_Flota_L12_19, 4, e)
    End Sub

    Private Sub TextBox175_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_20.KeyPress
        Numero(TextBox_Banco2_Flota_L12_20, 4, e)
    End Sub

    'BANCO 2 B

    Private Sub TextBox174_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_21.KeyPress
        Numero(TextBox_Banco2_Flota_L1_21, 4, e)
    End Sub

    Private Sub TextBox172_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_22.KeyPress
        Numero(TextBox_Banco2_Flota_L1_22, 4, e)
    End Sub

    Private Sub TextBox170_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_23.KeyPress
        Numero(TextBox_Banco2_Flota_L1_23, 4, e)
    End Sub

    Private Sub TextBox168_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_24.KeyPress
        Numero(TextBox_Banco2_Flota_L1_24, 4, e)
    End Sub

    Private Sub TextBox166_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_25.KeyPress
        Numero(TextBox_Banco2_Flota_L1_25, 4, e)
    End Sub

    Private Sub TextBox164_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_26.KeyPress

    End Sub

    Private Sub TextBox162_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_27.KeyPress
        Numero(TextBox_Banco2_Flota_L1_27, 4, e)
    End Sub

    Private Sub TextBox160_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_28.KeyPress
        Numero(TextBox_Banco2_Flota_L1_28, 4, e)
    End Sub

    Private Sub TextBox158_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_29.KeyPress
        Numero(TextBox_Banco2_Flota_L1_29, 4, e)
    End Sub

    Private Sub TextBox156_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_30.KeyPress
        Numero(TextBox_Banco2_Flota_L1_30, 4, e)
    End Sub

    Private Sub TextBox173_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_21.KeyPress
        Numero(TextBox_Banco2_Flota_L12_21, 4, e)
    End Sub

    Private Sub TextBox171_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_22.KeyPress
        Numero(TextBox_Banco2_Flota_L12_22, 4, e)
    End Sub

    Private Sub TextBox169_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_23.KeyPress
        Numero(TextBox_Banco2_Flota_L12_23, 4, e)
    End Sub

    Private Sub TextBox167_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_24.KeyPress
        Numero(TextBox_Banco2_Flota_L12_24, 4, e)
    End Sub

    Private Sub TextBox165_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_25.KeyPress
        Numero(TextBox_Banco2_Flota_L12_25, 4, e)
    End Sub

    Private Sub TextBox163_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_26.KeyPress
        Numero(TextBox_Banco2_Flota_L12_26, 4, e)
    End Sub

    Private Sub TextBox161_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_27.KeyPress
        Numero(TextBox_Banco2_Flota_L12_27, 4, e)
    End Sub

    Private Sub TextBox159_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_28.KeyPress
        Numero(TextBox_Banco2_Flota_L12_28, 4, e)
    End Sub

    Private Sub TextBox157_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_29.KeyPress
        Numero(TextBox_Banco2_Flota_L12_29, 4, e)
    End Sub

    Private Sub TextBox155_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_30.KeyPress
        Numero(TextBox_Banco2_Flota_L12_30, 4, e)
    End Sub

    Private Sub TextBox154_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_31.KeyPress
        Numero(TextBox_Banco2_Flota_L1_31, 4, e)
    End Sub

    Private Sub TextBox152_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_32.KeyPress
        Numero(TextBox_Banco2_Flota_L1_32, 4, e)
    End Sub

    Private Sub TextBox150_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_33.KeyPress
        Numero(TextBox_Banco2_Flota_L1_33, 4, e)
    End Sub

    Private Sub TextBox148_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_34.KeyPress
        Numero(TextBox_Banco2_Flota_L1_34, 4, e)
    End Sub

    Private Sub TextBox146_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_35.KeyPress
        Numero(TextBox_Banco2_Flota_L1_35, 4, e)
    End Sub

    Private Sub TextBox144_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_36.KeyPress
        Numero(TextBox_Banco2_Flota_L1_36, 4, e)
    End Sub

    Private Sub TextBox142_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_37.KeyPress
        Numero(TextBox_Banco2_Flota_L1_37, 4, e)
    End Sub

    Private Sub TextBox140_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_38.KeyPress
        Numero(TextBox_Banco2_Flota_L1_38, 4, e)
    End Sub

    Private Sub TextBox138_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_39.KeyPress
        Numero(TextBox_Banco2_Flota_L1_39, 4, e)
    End Sub

    Private Sub TextBox136_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L1_40.KeyPress
        Numero(TextBox_Banco2_Flota_L1_40, 4, e)
    End Sub

    Private Sub TextBox153_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_31.KeyPress
        Numero(TextBox_Banco2_Flota_L12_31, 4, e)
    End Sub

    Private Sub TextBox151_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_32.KeyPress
        Numero(TextBox_Banco2_Flota_L12_32, 4, e)
    End Sub

    Private Sub TextBox149_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_33.KeyPress
        Numero(TextBox_Banco2_Flota_L12_33, 4, e)
    End Sub

    Private Sub TextBox147_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_34.KeyPress
        Numero(TextBox_Banco2_Flota_L12_34, 4, e)
    End Sub

    Private Sub TextBox145_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_35.KeyPress
        Numero(TextBox_Banco2_Flota_L12_35, 4, e)
    End Sub

    Private Sub TextBox143_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_36.KeyPress
        Numero(TextBox_Banco2_Flota_L12_36, 4, e)
    End Sub

    Private Sub TextBox141_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_37.KeyPress
        Numero(TextBox_Banco2_Flota_L12_37, 4, e)
    End Sub

    Private Sub TextBox139_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_38.KeyPress
        Numero(TextBox_Banco2_Flota_L12_38, 4, e)
    End Sub

    Private Sub TextBox137_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_39.KeyPress
        Numero(TextBox_Banco2_Flota_L12_39, 4, e)
    End Sub

    Private Sub TextBox135_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Flota_L12_40.KeyPress
        Numero(TextBox_Banco2_Flota_L12_40, 4, e)
    End Sub

    Private Sub TextBox218_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Banco2_Resistencia.KeyPress
        Numero(TextBox_Banco2_Resistencia, 4, e)
    End Sub

    'TRABAJO REALIZADO

    Private Sub RichTextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox_Trabajo_realizado.KeyPress
        LetrasCamText(RichTextBox_Trabajo_realizado, 200, e)
    End Sub


End Class