Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.SqlClient

Public Class ReporteCliente

    Private Sub ReporteServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MenuPrincipal.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Generar_reporte.Click

        Dim ruta As Integer
        Save.Filter = "Archivos Adobe PDF (*.pdf)|*.pdf"
        Save.FileName = FolderOutput & "\" & Folio.Text & "-C.pdf"
        ruta = 1 ' Save.ShowDialog

        'incertar en mantenimientos un reporte
        Dim iincert As New SqlCommand
        Dim CI As New SqlConnection
        Try
            CI.ConnectionString = "Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";"
            CI.Open()
            iincert.Connection = CI
            iincert.CommandText = "insert into MANTENIMIENTO values('" & Folio.Text & "-C','" & DateTimePicker.Value.Day.ToString() & "','" & DateTimePicker.Value.Month.ToString() & "','" & DateTimePicker.Value.Year.ToString() & "','" & DateTimePicker.Value.Hour.ToString() & ":" & DateTimePicker.Value.Minute.ToString() & "','" & TextBox4.Text & "','" & CBUps.Text & "','" & Save.FileName & "')"
            iincert.ExecuteNonQuery()
            MsgBox("Registro guardado exitosamente..")
            CI.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo salir
        End Try
        'fin incertar en mantenimientos...

        If File.Exists(Save.FileName) Then GoTo salir
        Try
            Kill(Save.FileName)
        Catch ex As Exception
        End Try

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



            'cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TEXTO de prueba (centro)", 315, 730, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "TEXTO de prueba (izquierda)", 611, 786, 0)
            'cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "X", 180, 788 - 120, 0)
            Try
                Dim png As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("C:\Users\ACER\Pictures\IMG_FINAL_HD1.JPG")
                png.ScaleAbsolute(611, 787)
                png.SetAbsolutePosition(0, 0)
                cb.AddImage(png)
            Catch ex As Exception
            End Try


            fuente = FontFactory.GetFont(FontFactory.HELVETICA, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL).BaseFont

            cb.SetFontAndSize(fuente, 16)
            cb.SetColorFill(BaseColor.RED)

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Folio.Text, 493, 788 - 61, 0) 'folio

            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(BaseColor.BLACK)

            If (RadioButton_Inspeccion.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 180, 788 - 125, 0) 'inspeccion
            If (RadioButton_Preventivo.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 280, 788 - 125, 0) 'preventivo
            If (RadioButton_Correctivo.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 390, 788 - 125, 0) 'correctivo
            If (RadioButton_Garantia.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 480, 788 - 125, 0) 'garantia

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cliente.Text, 90, 788 - 140, 0) 'cliente
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, (Me.DateTimePicker.Value.ToString).Split(New Char() {" "c})(0).ToString.Replace("/", "      "), 380, 788 - 140, 0) 'fecha
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CBSuc.Text, 90, 788 - 152, 0) 'domicilio
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Atencion.Text, 90, 788 - 172, 0) 'atencion

            If (RadioButton_Excelente.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 384, 788 - 170, 0) 'exelente                
            If (RadioButtonBuena.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 430, 788 - 170, 0) 'bueno                
            If (RadioButton_Regular.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 477, 788 - 170, 0) 'regular                
            If (RadioButton_Malo.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 521, 788 - 170, 0) 'malo                

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_UPS_Marca.Text, 80, 788 - 207, 0) 'marca
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, CBUps.Text, 88, 788 - 218, 0) 'modelo
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_UPS_MLFB.Text, 75, 788 - 228, 0) 'mlfb
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_UPS_Serie.Text, 75, 788 - 238, 0) 'serie
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_UPS_Capacidad.Text, 100, 788 - 248, 0) 'capacidad
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, TextBox_UPS_v_Entrada.Text, 185, 788 - 258, 0) 'v entrada
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, TextBox12_UPS_v_Salida.Text, 300, 788 - 258, 0) 'v salida

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_BAT_Marca.Text, 350, 788 - 207, 0) 'marca
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_BAT_Modelo.Text, 355, 788 - 217, 0) 'modelo
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_BAT_Capacidad.Text, 366, 788 - 227, 0) 'capasidad
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_BAT_Cantidad.Text, 366, 788 - 238, 0) 'cantidad
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_BAT_Bancos.Text, 350, 788 - 248, 0) 'bancos
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_BAT_Voltaje.Text, 400, 788 - 258, 0) 'voltaje bateria

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F1_F2.Text, 150, 788 - 297, 0) 'MAX f1-f2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F2_F3.Text, 150, 788 - 308, 0) 'MAX f2-f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F3_F1.Text, 150, 788 - 319, 0) 'MAX f3-f1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F1_N.Text, 150, 788 - 330, 0) 'MAX f1-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F2_N.Text, 150, 788 - 340, 0) 'MAX f2-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F3_N.Text, 150, 788 - 351, 0) 'MAX f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F1_F2.Text, 235, 788 - 297, 0) 'MIN f1-f2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F2_F3.Text, 235, 788 - 308, 0) 'MIN f2-f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F3_F1.Text, 235, 788 - 319, 0) 'MIN f3-f1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F1_N.Text, 235, 788 - 330, 0) 'MIN f1-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F2_N.Text, 235, 788 - 340, 0) 'MIN f2-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F3_N.Text, 235, 788 - 351, 0) 'MIN f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, TextBox31.Text, 216, 788 - 379, 0) 'frecuencia

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F1.Text, 150, 788 - 400, 0) 'f1 max
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F2.Text, 150, 788 - 410, 0) 'f2 max
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Max_F3.Text, 150, 788 - 420, 0) 'f3 max

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F1.Text, 235, 788 - 400, 0) 'f1 min
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F2.Text, 235, 788 - 410, 0) 'f2 min
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDE_Min_F3.Text, 235, 788 - 420, 0) 'f3 min

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F1_F2.Text, 424, 788 - 297, 0) 'MAX f1-f2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F2_F3.Text, 424, 788 - 307, 0) 'MAX f2-f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F3_F1.Text, 424, 788 - 318, 0) 'MAX f3-f1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F1_N.Text, 424, 788 - 328, 0) 'MAX f1-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F2_N.Text, 424, 788 - 339, 0) 'MAX f2-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F3_N.Text, 424, 788 - 349, 0) 'MAX f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F1_F2.Text, 502, 788 - 297, 0) 'MIN f1-f2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F1_F2.Text, 502, 788 - 307, 0) 'MIN f2-f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F3_F1.Text, 502, 788 - 318, 0) 'MIN f3-f1
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F1_N.Text, 502, 788 - 328, 0) 'MIN f1-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F2_N.Text, 502, 788 - 339, 0) 'MIN f2-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F3_N.Text, 502, 788 - 349, 0) 'MIN f3-n

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_N_TF.Text, 424, 788 - 360, 0) 'MAX n-tf
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_N_TF.Text, 502, 788 - 360, 0) 'MIN n-tf

            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, TextBox_MDS_Frecuencia.Text, 484, 788 - 380, 0) 'frecuencia

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F1.Text, 424, 788 - 400, 0) 'f1 max
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F2.Text, 424, 788 - 410, 0) 'f2 max
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Max_F3.Text, 424, 788 - 421, 0) 'f3 max

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F1.Text, 502, 788 - 400, 0) 'f1 min
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F2.Text, 502, 788 - 410, 0) 'f2 min
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Min_F3.Text, 502, 788 - 421, 0) 'f3 min

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_MDS_Carga_nominal.Text, 410, 788 - 431, 0) 'carga nominal

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, RichTextBox_MDS_Problema_reportado.Text, 45, 788 - 460, 0) 'Problema reportado..

            If (CheckBox_Alarma_panel.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 205, 788 - 512, 0) 'alarma en panel             
            If (CheckBox_UPS_linea.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 290, 788 - 512, 0) 'ups en linea      
            If (CheckBox_UPS_bypass.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 380, 788 - 512, 0) 'ups en by-pass           
            If (CheckBox_No_alarma.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 475, 788 - 512, 0) 'no alarma
            If (CheckBox_Panel_apagado.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 555, 788 - 512, 0) 'panel apagado      

            If (CheckBox_Func_ventilador.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 196, 788 - 530, 0) 'Funcionamiento de ventiladores           
            If (CheckBox_Ind_lectura_panel.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 480, 788 - 530, 0) 'indicacion o lectura en panel

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Func_ventilador.Text, 220, 788 - 530, 0) 'Funcionamiento de ventiladores texto           
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Ind_lectura_panel.Text, 50, 788 - 540, 0) 'indicacion o lectura en panel texto

            'falta ajustar los text

            If (CheckBox_LG_UPS.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 295, 788 - 560, 0) 'ups
            If (CheckBox_LG_Baterias.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 425, 788 - 560, 0) 'baterias

            If (CheckBox_RC_UPS.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 295, 788 - 578, 0) 'ups
            If (CheckBox_RC_Baterias.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 425, 788 - 578, 0) 'baterias

            If (CheckBox1_Ajustes_Rectificador.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 295, 788 - 596, 0) 'rectificador
            If (CheckBox1_Ajustes_Inverzor.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 425, 788 - 596, 0) 'inversor
            If (CheckBox1_Ajustes_Bypass.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 525, 788 - 596, 0) 'by-pass

            If (CheckBox2_Ajustes_Rectificador.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 295, 788 - 616, 0) 'rectificador
            If (CheckBox2_Ajustes_Inverzor.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 425, 788 - 616, 0) 'inversor
            If (CheckBox2_Ajustes_Bypass.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 525, 788 - 616, 0) 'by-pass

            If (CheckBox_Trans_bypass.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 140, 788 - 635, 0) 'transferencia a by-pass
            If (CheckBox_Trans_Normal.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 290, 788 - 635, 0) 'transferencia a normal
            If (CheckBoxPrueba_resp_requer.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 525, 788 - 635, 0) 'prueba de respaldo requerido

            If (CheckBox_Prueba_Emergencia.Checked) Then cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "X", 160, 788 - 655, 0) 'prueba a planta de emergencia

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox64.Text, 245, 788 - 655, 0) 'f1-f2
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox63.Text, 372, 788 - 655, 0) 'f2-f3
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox62.Text, 507, 788 - 655, 0) 'f3-f1

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Prueba_Frecuencia.Text, 90, 788 - 672, 0) 'frecuencia

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox68.Text, 245, 788 - 673, 0) 'f1-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox67.Text, 372, 788 - 673, 0) 'f2-n
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox66.Text, 507, 788 - 673, 0) 'f3-n

            Dim nn As Integer
            '1'----------------------------------------------------------------------------
            nn = 735
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cantidad_1.Text, 46, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Unidad_1.Text, 110, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Descripcion_1.Text, 168, 788 - nn, 0)
            '2'----------------------------------------------------------------------------
            nn = 744
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cantidad_2.Text, 46, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Unidad_2.Text, 110, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Descripcion_2.Text, 168, 788 - nn, 0)
            '3'----------------------------------------------------------------------------
            nn = 752
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cantidad_3.Text, 46, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Unidad_3.Text, 110, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Descripcion_3.Text, 168, 788 - nn, 0)
            '4'----------------------------------------------------------------------------
            nn = 762
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cantidad_4.Text, 46, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Unidad_4.Text, 110, 788 - nn, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Descripcion_4.Text, 168, 788 - nn, 0)


            cb.EndText() 'Fin del flujo de bytes.

            oDoc.NewPage() 'Agregamos una pagina.
            cb.BeginText() 'Iniciamos el flujo de bytes.
            'Instanciamos el objeto para la tipo de letra.
            Try
                Dim png As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("C:\Users\ACER\Pictures\IMG_FINAL_HD2.JPG")
                png.ScaleAbsolute(611, 787)
                png.SetAbsolutePosition(0, 0)
                cb.AddImage(png)
            Catch ex As Exception
            End Try

            cb.SetFontAndSize(fuente, 16)
            cb.SetColorFill(BaseColor.RED)

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Folio.Text, 493, 788 - 61, 0) 'folio

            cb.SetFontAndSize(fuente, 8)
            cb.SetColorFill(BaseColor.BLACK)

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cliente.Text, 84, 788 - 124, 0) 'cliente
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v.Text, 150, 788 - 157, 0) 'voltaje de flotacion
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBoxTextBox_Vol_Bat_v.Text, 382, 788 - 157, 0) 'I de bateriasde bus

            Dim n As Integer
            '1'----------------------------------------------------------------------------
            n = 215
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_1.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_1.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_24.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_24.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_1.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_1.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_24.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_24.Text, 520, 788 - n, 0)
            '2'----------------------------------------------------------------------------
            n = 228
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_2.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_2.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_25.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_25.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_2.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_2.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_25.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_25.Text, 520, 788 - n, 0)
            '3'----------------------------------------------------------------------------
            n = 240
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_3.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_3.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_26.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_26.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_3.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_3.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_26.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_26.Text, 520, 788 - n, 0)
            '4'----------------------------------------------------------------------------
            n = 253
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_4.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_4.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_27.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_27.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_4.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_4.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_27.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_27.Text, 520, 788 - n, 0)
            '5'----------------------------------------------------------------------------
            n = 265
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_5.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_5.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_28.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_28.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_5.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_5.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_28.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_28.Text, 520, 788 - n, 0)
            '6'----------------------------------------------------------------------------
            n = 278
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_6.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_6.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_29.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_29.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_6.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_6.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_29.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_29.Text, 520, 788 - n, 0)
            '7'----------------------------------------------------------------------------
            n = 290
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_7.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_7.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_30.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_30.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_7.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_7.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_30.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_30.Text, 520, 788 - n, 0)
            '8'----------------------------------------------------------------------------
            n = 302
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_8.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_8.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_31.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_31.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_8.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_8.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_31.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_31.Text, 520, 788 - n, 0)
            '9'----------------------------------------------------------------------------
            n = 314
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_9.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_9.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_32.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_32.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_9.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_9.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_32.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_32.Text, 520, 788 - n, 0)
            '10'----------------------------------------------------------------------------
            n = 326
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_10.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_10.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_33.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_33.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_10.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_10.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_33.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_33.Text, 520, 788 - n, 0)
            '11'----------------------------------------------------------------------------
            n = 338
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_11.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_11.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_34.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_34.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_11.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_11.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_34.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_34.Text, 520, 788 - n, 0)
            '12'----------------------------------------------------------------------------
            n = 350
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_12.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_12.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_35.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_35.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_12.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_12.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_35.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_35.Text, 520, 788 - n, 0)
            '13'----------------------------------------------------------------------------
            n = 362
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_13.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_13.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_36.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_36.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_13.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_13.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_36.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_36.Text, 520, 788 - n, 0)
            '14'----------------------------------------------------------------------------
            n = 374
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_14.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_14.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_37.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_37.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_14.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_14.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_37.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_37.Text, 520, 788 - n, 0)
            '15'----------------------------------------------------------------------------
            n = 387
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_15.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_15.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_38.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_38.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_15.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_15.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_38.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_38.Text, 520, 788 - n, 0)
            '16'----------------------------------------------------------------------------
            n = 399
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_16.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_16.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_39.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_39.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_16.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_16.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_39.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_39.Text, 520, 788 - n, 0)
            '17'----------------------------------------------------------------------------
            n = 411
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_17.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_17.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_40.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_40.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_17.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_17.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_40.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_40.Text, 520, 788 - n, 0)
            '18'----------------------------------------------------------------------------
            n = 424
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_18.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_18.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_41.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_41.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_18.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_18.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_41.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_41.Text, 520, 788 - n, 0)
            '19'----------------------------------------------------------------------------
            n = 436
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_19.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_19.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_42.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_42.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_19.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_19.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_42.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_42.Text, 520, 788 - n, 0)
            '20'----------------------------------------------------------------------------
            n = 448
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_20.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_20.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_43.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_43.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_20.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_20.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_43.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_43.Text, 520, 788 - n, 0)
            '21'----------------------------------------------------------------------------
            n = 460
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_21.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_21.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_44.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_44.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_21.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_21.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_44.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_44.Text, 520, 788 - n, 0)
            '22'----------------------------------------------------------------------------
            n = 472
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_22.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_22.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_45.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_45.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_22.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_22.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_45.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_45.Text, 520, 788 - n, 0)
            '23'----------------------------------------------------------------------------
            n = 485
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_23.Text, 98, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_23.Text, 149, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Flot_v_46.Text, 227, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Vol_Desc_v_46.Text, 279, 788 - n, 0)
            '--------------------------------------------------------
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_23.Text, 355, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_23.Text, 400, 788 - n, 0)
            '
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Flot_v_46.Text, 475, 788 - n, 0)
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox2_Vol_Desc_v_46.Text, 520, 788 - n, 0)

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Resistencia.Text, 145, 788 - 498, 0) 'resistencia
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Tiempo.Text, 385, 788 - 498, 0) 'tiempo
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Observaciones_comentarios.Text, 60, 788 - 539, 0) 'commmentarios
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Responsable_empresa.Text, 95, 788 - 735, 0) 'responsable
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, TextBox_Cliente2.Text, 360, 788 - 735, 0) 'cliente



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


    Dim ultimo = 0
    Private Sub ReporteServicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rutas = Dir(Replace(FolderOutput, vbCrLf, "") & "\*.pdf")
        Do While rutas <> ""
            Dim t As Integer
            Try
                If rutas.Contains("-C") Then
                    t = CInt(Int(rutas.Replace("-C.pdf", "")))
                    If t > ultimo Then
                        ultimo = t
                    End If
                End If
            Catch ex As Exception
            End Try
            rutas = Dir()
        Loop
        Folio.Text = ultimo + 1

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
                    CBSuc.Items.Add(dt.Rows(i).Item("NOM_SUC"))
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
                MsgBox("No existen UPS. Agrega Algunas Primero..", MsgBoxStyle.Critical)
            Else
                For i = 0 To dt.Rows.Count - 1
                    CBUps.Items.Add(dt.Rows(i).Item("ID_UPS"))
                Next
            End If
            cnn.Close()
        End Using

    End Sub

    Private Sub CBSuc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBSuc.SelectedIndexChanged
        If ((CBSuc.Text = "")) Then
        Else
            If ((CBUps.Text = "")) Then
            Else
                Button_Generar_reporte.Enabled = True
                'MsgBox("Habilitando boton....")
            End If
        End If
        Using cnn As New SqlConnection("Data Source=" & ServerName & "; Initial Catalog=SEUPS; User id=" & Usuario & "; password=" & Contrasena & ";")
            cnn.Open()
            Dim consulta As String = "Select ID_SUC from SUCURSALES WHERE NOM_SUC = '" + CBSuc.Text + "'"
            Dim cmd As New SqlCommand(consulta, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            TextBox4.Text = dt.Rows(0).Item("ID_SUC")
            cnn.Close()
        End Using
    End Sub

    Private Sub CBUps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBUps.SelectedIndexChanged
        If ((CBSuc.Text = "")) Then
        Else
            If ((CBUps.Text = "")) Then
            Else
                Button_Generar_reporte.Enabled = True
                'MsgBox("Habilitando boton....")
            End If
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Func_ventilador.CheckedChanged
        If (CheckBox_Func_ventilador.Checked) Then
            TextBox_Func_ventilador.Enabled = True
        Else
            TextBox_Func_ventilador.Enabled = False
        End If
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Ind_lectura_panel.CheckedChanged
        If (CheckBox_Ind_lectura_panel.Checked) Then
            TextBox_Ind_lectura_panel.Enabled = True
        Else
            TextBox_Ind_lectura_panel.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cliente.KeyPress
        Letras(TextBox_Cliente, 12, e)
    End Sub

    Private Sub TextBox275_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Folio.KeyPress
        Numero(Folio, 5, e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Atencion.KeyPress
        LetraYNumero(TextBox_Atencion, 12, e)
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_UPS_Marca.KeyPress
        LetraYNumero(TextBox_UPS_Marca, 10, e)
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_UPS_MLFB.KeyPress
        LetraYNumero(TextBox_UPS_MLFB, 10, e)
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_UPS_Serie.KeyPress
        LetraYNumero(TextBox_UPS_Serie, 10, e)
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_UPS_Capacidad.KeyPress
        Numero(TextBox_UPS_Capacidad, 6, e)
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_UPS_v_Entrada.KeyPress
        Numero(TextBox_UPS_v_Entrada, 6, e)
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12_UPS_v_Salida.KeyPress
        Numero(TextBox12_UPS_v_Salida, 6, e)
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_BAT_Marca.KeyPress
        LetraYNumero(TextBox_BAT_Marca, 15, e)
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_BAT_Modelo.KeyPress
        LetraYNumero(TextBox_BAT_Modelo, 10, e)
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_BAT_Capacidad.KeyPress
        Numero(TextBox_BAT_Capacidad, 6, e)
    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_BAT_Cantidad.KeyPress
        Numero(TextBox_BAT_Cantidad, 6, e)
    End Sub

    Private Sub TextBox17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_BAT_Bancos.KeyPress
        Numero(TextBox_BAT_Bancos, 6, e)
    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_BAT_Voltaje.KeyPress
        Numero(TextBox_BAT_Voltaje, 6, e)
    End Sub

    Private Sub TextBox20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F1_F2.KeyPress
        Numero(TextBox_MDE_Max_F1_F2, 6, e)
    End Sub

    Private Sub TextBox22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F2_F3.KeyPress
        Numero(TextBox_MDE_Max_F2_F3, 6, e)
    End Sub

    Private Sub TextBox24_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F3_F1.KeyPress
        Numero(TextBox_MDE_Max_F3_F1, 6, e)
    End Sub

    Private Sub TextBox26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F1_N.KeyPress
        Numero(TextBox_MDE_Max_F1_N, 6, e)
    End Sub

    Private Sub TextBox28_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F2_N.KeyPress
        Numero(TextBox_MDE_Max_F2_N, 6, e)
    End Sub

    Private Sub TextBox30_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F3_N.KeyPress
        Numero(TextBox_MDE_Max_F3_N, 6, e)
    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F1_F2.KeyPress
        Numero(TextBox_MDE_Min_F1_F2, 6, e)
    End Sub

    Private Sub TextBox21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F2_F3.KeyPress
        Numero(TextBox_MDE_Min_F2_F3, 6, e)
    End Sub

    Private Sub TextBox23_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F3_F1.KeyPress
        Numero(TextBox_MDE_Min_F3_F1, 6, e)
    End Sub

    Private Sub TextBox25_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F1_N.KeyPress
        Numero(TextBox_MDE_Min_F1_N, 6, e)
    End Sub

    Private Sub TextBox27_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F2_N.KeyPress
        Numero(TextBox_MDE_Min_F2_N, 6, e)
    End Sub

    Private Sub TextBox29_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F3_N.KeyPress
        Numero(TextBox_MDE_Min_F3_N, 6, e)
    End Sub

    Private Sub TextBox31_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox31.KeyPress
        Numero(TextBox31, 8, e)
    End Sub

    Private Sub TextBox32_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F1.KeyPress
        Numero(TextBox_MDE_Max_F1, 6, e)
    End Sub

    Private Sub TextBox34_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F2.KeyPress
        Numero(TextBox_MDE_Max_F2, 6, e)
    End Sub

    Private Sub TextBox36_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Max_F3.KeyPress
        Numero(TextBox_MDE_Max_F3, 6, e)
    End Sub

    Private Sub TextBox33_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F1.KeyPress
        Numero(TextBox_MDE_Min_F1, 6, e)
    End Sub

    Private Sub TextBox35_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F2.KeyPress
        Numero(TextBox_MDE_Min_F2, 6, e)
    End Sub

    Private Sub TextBox37_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDE_Min_F3.KeyPress
        Numero(TextBox_MDE_Min_F3, 6, e)
    End Sub

    Private Sub TextBox56_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F1_F2.KeyPress
        Numero(TextBox_MDS_Max_F1_F2, 6, e)
    End Sub

    Private Sub TextBox52_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F2_F3.KeyPress
        Numero(TextBox_MDS_Max_F2_F3, 6, e)
    End Sub

    Private Sub TextBox48_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F3_F1.KeyPress
        Numero(TextBox_MDS_Max_F3_F1, 6, e)
    End Sub

    Private Sub TextBox44_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F1_N.KeyPress
        Numero(TextBox_MDS_Max_F1_N, 6, e)
    End Sub

    Private Sub TextBox42_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F2_N.KeyPress
        Numero(TextBox_MDS_Max_F2_N, 6, e)
    End Sub

    Private Sub TextBox40_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F3_N.KeyPress
        Numero(TextBox_MDS_Max_F3_N, 6, e)
    End Sub

    Private Sub TextBox54_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F1_F2.KeyPress
        Numero(TextBox_MDS_Min_F1_F2, 6, e)
    End Sub

    Private Sub TextBox50_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F2_F3.KeyPress
        Numero(TextBox_MDS_Min_F2_F3, 6, e)
    End Sub

    Private Sub TextBox46_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F3_F1.KeyPress
        Numero(TextBox_MDS_Min_F3_F1, 6, e)
    End Sub

    Private Sub TextBox43_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F1_N.KeyPress
        Numero(TextBox_MDS_Min_F1_N, 6, e)
    End Sub

    Private Sub TextBox41_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F2_N.KeyPress
        Numero(TextBox_MDS_Min_F2_N, 6, e)
    End Sub

    Private Sub TextBox39_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F3_N.KeyPress
        Numero(TextBox_MDS_Min_F3_N, 6, e)
    End Sub

    Private Sub TextBox58_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_N_TF.KeyPress
        Numero(TextBox_MDS_Max_N_TF, 6, e)
    End Sub

    Private Sub TextBox57_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_N_TF.KeyPress
        Numero(TextBox_MDS_Min_N_TF, 6, e)
    End Sub

    Private Sub TextBox38_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Frecuencia.KeyPress
        Numero(TextBox_MDS_Frecuencia, 8, e)
    End Sub

    Private Sub TextBox55_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F1.KeyPress
        Numero(TextBox_MDS_Max_F1, 6, e)
    End Sub

    Private Sub TextBox51_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F2.KeyPress
        Numero(TextBox_MDS_Max_F2, 6, e)
    End Sub

    Private Sub TextBox47_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Max_F3.KeyPress
        Numero(TextBox_MDS_Max_F3, 6, e)
    End Sub

    Private Sub TextBox53_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F1.KeyPress
        Numero(TextBox_MDS_Min_F1, 6, e)
    End Sub

    Private Sub TextBox49_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F2.KeyPress
        Numero(TextBox_MDS_Min_F2, 6, e)
    End Sub

    Private Sub TextBox45_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Min_F3.KeyPress
        Numero(TextBox_MDS_Min_F3, 6, e)
    End Sub

    Private Sub TextBox59_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_MDS_Carga_nominal.KeyPress
        Numero(TextBox_MDS_Carga_nominal, 8, e)
    End Sub

    Private Sub RichTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichTextBox_MDS_Problema_reportado.KeyPress
        LetrasCamText(RichTextBox_MDS_Problema_reportado, 150, e)
    End Sub

    Private Sub TextBox60_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Func_ventilador.KeyPress
        Letra(TextBox_Func_ventilador, 30, e)
    End Sub

    Private Sub TextBox61_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Ind_lectura_panel.KeyPress
        LetraYNumero(TextBox_Ind_lectura_panel, 30, e)
    End Sub

    Private Sub TextBox65_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Prueba_Frecuencia.KeyPress
        Numero(TextBox_Prueba_Frecuencia, 6, e)
    End Sub

    Private Sub TextBox64_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox64.KeyPress
        Numero(TextBox64, 6, e)
    End Sub

    Private Sub TextBox68_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox68.KeyPress
        Numero(TextBox68, 6, e)
    End Sub

    Private Sub TextBox63_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox63.KeyPress
        Numero(TextBox63, 6, e)
    End Sub

    Private Sub TextBox67_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox67.KeyPress
        Numero(TextBox67, 6, e)
    End Sub

    Private Sub TextBox62_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox62.KeyPress
        Numero(TextBox62, 6, e)
    End Sub

    Private Sub TextBox66_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox66.KeyPress
        Numero(TextBox66, 6, e)
    End Sub

    Private Sub TextBox161_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v.KeyPress
        Numero(TextBox_Vol_Flot_v, 6, e)
    End Sub

    Private Sub TextBox162_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxTextBox_Vol_Bat_v.KeyPress
        Numero(TextBoxTextBox_Vol_Bat_v, 6, e)
    End Sub

    Private Sub TextBox69_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_1.KeyPress
        Numero(TextBox_MDS_Carga_nominal, 6, e)
    End Sub

    Private Sub TextBox71_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_2.KeyPress
        Numero(TextBox_Vol_Flot_v_2, 6, e)
    End Sub

    Private Sub TextBox73_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_3.KeyPress
        Numero(TextBox_Vol_Flot_v_3, 6, e)
    End Sub

    Private Sub TextBox75_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_4.KeyPress
        Numero(TextBox_Vol_Flot_v_4, 6, e)
    End Sub

    Private Sub TextBox77_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_5.KeyPress
        Numero(TextBox_Vol_Flot_v_5, 6, e)
    End Sub

    Private Sub TextBox79_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_6.KeyPress
        Numero(TextBox_Vol_Flot_v_6, 6, e)
    End Sub

    Private Sub TextBox81_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_7.KeyPress
        Numero(TextBox_Vol_Flot_v_7, 6, e)
    End Sub

    Private Sub TextBox83_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_8.KeyPress
        Numero(TextBox_Vol_Flot_v_8, 6, e)
    End Sub

    Private Sub TextBox85_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_9.KeyPress
        Numero(TextBox_Vol_Flot_v_9, 6, e)
    End Sub

    Private Sub TextBox87_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_10.KeyPress
        Numero(TextBox_Vol_Flot_v_10, 6, e)
    End Sub

    Private Sub TextBox89_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_11.KeyPress
        Numero(TextBox_Vol_Flot_v_11, 6, e)
    End Sub

    Private Sub TextBox91_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_12.KeyPress
        Numero(TextBox_Vol_Flot_v_12, 6, e)
    End Sub

    Private Sub TextBox93_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_13.KeyPress
        Numero(TextBox_Vol_Flot_v_13, 6, e)
    End Sub

    Private Sub TextBox95_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_14.KeyPress
        Numero(TextBox_Vol_Flot_v_14, 6, e)
    End Sub

    Private Sub TextBox97_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_15.KeyPress
        Numero(TextBox_Vol_Flot_v_15, 6, e)
    End Sub

    Private Sub TextBox99_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_16.KeyPress
        Numero(TextBox_Vol_Flot_v_16, 6, e)
    End Sub

    Private Sub TextBox101_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_17.KeyPress
        Numero(TextBox_Vol_Flot_v_17, 6, e)
    End Sub

    Private Sub TextBox103_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_18.KeyPress
        Numero(TextBox_Vol_Flot_v_18, 6, e)
    End Sub

    Private Sub TextBox105_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_19.KeyPress
        Numero(TextBox_Vol_Flot_v_19, 6, e)
    End Sub

    Private Sub TextBox107_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_20.KeyPress
        Numero(TextBox_Vol_Flot_v_20, 6, e)
    End Sub

    Private Sub TextBox109_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_21.KeyPress
        Numero(TextBox_Vol_Flot_v_21, 6, e)
    End Sub

    Private Sub TextBox111_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_22.KeyPress
        Numero(TextBox_Vol_Flot_v_22, 6, e)
    End Sub

    Private Sub TextBox113_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_23.KeyPress
        Numero(TextBox_Vol_Flot_v_23, 6, e)
    End Sub

    Private Sub TextBox70_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_1.KeyPress
        Numero(TextBox_Vol_Desc_v_1, 6, e)
    End Sub

    Private Sub TextBox72_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_2.KeyPress
        Numero(TextBox_Vol_Desc_v_2, 6, e)
    End Sub

    Private Sub TextBox74_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_3.KeyPress
        Numero(TextBox_Vol_Desc_v_3, 6, e)
    End Sub

    Private Sub TextBox76_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_4.KeyPress
        Numero(TextBox_Vol_Desc_v_4, 6, e)
    End Sub

    Private Sub TextBox78_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_5.KeyPress
        Numero(TextBox_Vol_Desc_v_5, 6, e)
    End Sub

    Private Sub TextBox80_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_6.KeyPress
        Numero(TextBox_Vol_Desc_v_6, 6, e)
    End Sub

    Private Sub TextBox82_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_7.KeyPress
        Numero(TextBox_Vol_Desc_v_7, 6, e)
    End Sub

    Private Sub TextBox84_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_8.KeyPress
        Numero(TextBox_Vol_Desc_v_8, 6, e)
    End Sub

    Private Sub TextBox86_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_9.KeyPress
        Numero(TextBox_Vol_Desc_v_9, 6, e)
    End Sub

    Private Sub TextBox88_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_10.KeyPress
        Numero(TextBox_Vol_Desc_v_10, 6, e)
    End Sub

    Private Sub TextBox90_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_11.KeyPress
        Numero(TextBox_Vol_Desc_v_11, 6, e)
    End Sub

    Private Sub TextBox92_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_12.KeyPress
        Numero(TextBox_Vol_Desc_v_12, 6, e)
    End Sub

    Private Sub TextBox94_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_13.KeyPress
        Numero(TextBox_Vol_Desc_v_13, 6, e)
    End Sub

    Private Sub TextBox96_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_14.KeyPress
        Numero(TextBox_Vol_Desc_v_14, 6, e)
    End Sub

    Private Sub TextBox98_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_15.KeyPress
        Numero(TextBox_Vol_Desc_v_15, 6, e)
    End Sub

    Private Sub TextBox100_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_16.KeyPress
        Numero(TextBox_Vol_Desc_v_16, 6, e)
    End Sub

    Private Sub TextBox102_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_17.KeyPress
        Numero(TextBox_Vol_Desc_v_17, 6, e)
    End Sub

    Private Sub TextBox104_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_18.KeyPress
        Numero(TextBox_Vol_Desc_v_18, 6, e)
    End Sub

    Private Sub TextBox106_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_19.KeyPress
        Numero(TextBox_Vol_Desc_v_19, 6, e)
    End Sub

    Private Sub TextBox108_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_20.KeyPress
        Numero(TextBox_Vol_Desc_v_20, 6, e)
    End Sub

    Private Sub TextBox110_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_21.KeyPress
        Numero(TextBox_Vol_Desc_v_21, 6, e)
    End Sub

    Private Sub TextBox112_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_22.KeyPress
        Numero(TextBox_Vol_Desc_v_22, 6, e)
    End Sub

    Private Sub TextBox114_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_23.KeyPress
        Numero(TextBox_Vol_Desc_v_23, 6, e)
    End Sub

    Private Sub TextBox115_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_24.KeyPress
        Numero(TextBox_Vol_Flot_v_24, 6, e)
    End Sub

    Private Sub TextBox117_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_25.KeyPress
        Numero(TextBox_Vol_Flot_v_25, 6, e)
    End Sub

    Private Sub TextBox119_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_26.KeyPress
        Numero(TextBox_Vol_Flot_v_26, 6, e)
    End Sub

    Private Sub TextBox121_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_27.KeyPress
        Numero(TextBox_Vol_Flot_v_27, 6, e)
    End Sub

    Private Sub TextBox123_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_28.KeyPress
        Numero(TextBox_Vol_Flot_v_28, 6, e)
    End Sub

    Private Sub TextBox125_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_29.KeyPress
        Numero(TextBox_Vol_Flot_v_29, 6, e)
    End Sub

    Private Sub TextBox127_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_30.KeyPress
        Numero(TextBox_Vol_Flot_v_30, 6, e)
    End Sub

    Private Sub TextBox129_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_31.KeyPress
        Numero(TextBox_Vol_Flot_v_31, 6, e)
    End Sub

    Private Sub TextBox131_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_32.KeyPress
        Numero(TextBox_Vol_Flot_v_32, 6, e)
    End Sub

    Private Sub TextBox133_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_33.KeyPress
        Numero(TextBox_Vol_Flot_v_33, 6, e)
    End Sub

    Private Sub TextBox135_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_34.KeyPress
        Numero(TextBox_Vol_Flot_v_34, 6, e)
    End Sub

    Private Sub TextBox137_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_35.KeyPress
        Numero(TextBox_Vol_Flot_v_35, 6, e)
    End Sub

    Private Sub TextBox139_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_36.KeyPress
        Numero(TextBox_Vol_Flot_v_36, 6, e)
    End Sub

    Private Sub TextBox141_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_37.KeyPress
        Numero(TextBox_Vol_Flot_v_37, 6, e)
    End Sub

    Private Sub TextBox143_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_38.KeyPress
        Numero(TextBox_Vol_Flot_v_38, 6, e)
    End Sub

    Private Sub TextBox145_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_39.KeyPress
        Numero(TextBox_Vol_Flot_v_39, 6, e)
    End Sub

    Private Sub TextBox147_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_40.KeyPress
        Numero(TextBox_Vol_Flot_v_40, 6, e)
    End Sub

    Private Sub TextBox149_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_41.KeyPress
        Numero(TextBox_Vol_Flot_v_41, 6, e)
    End Sub

    Private Sub TextBox151_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_42.KeyPress
        Numero(TextBox_Vol_Flot_v_42, 6, e)
    End Sub

    Private Sub TextBox153_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_43.KeyPress
        Numero(TextBox_Vol_Flot_v_43, 6, e)
    End Sub

    Private Sub TextBox155_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_44.KeyPress
        Numero(TextBox_Vol_Flot_v_44, 6, e)
    End Sub

    Private Sub TextBox157_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_45.KeyPress
        Numero(TextBox_Vol_Flot_v_45, 6, e)
    End Sub

    Private Sub TextBox159_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Flot_v_46.KeyPress
        Numero(TextBox_Vol_Flot_v_46, 6, e)
    End Sub

    Private Sub TextBox116_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_24.KeyPress
        Numero(TextBox_Vol_Desc_v_24, 6, e)
    End Sub

    Private Sub TextBox118_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_25.KeyPress
        Numero(TextBox_Vol_Desc_v_25, 6, e)
    End Sub

    Private Sub TextBox120_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_26.KeyPress
        Numero(TextBox_Vol_Desc_v_26, 6, e)
    End Sub

    Private Sub TextBox122_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_27.KeyPress
        Numero(TextBox_Vol_Desc_v_27, 6, e)
    End Sub

    Private Sub TextBox124_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_28.KeyPress
        Numero(TextBox_Vol_Desc_v_28, 6, e)
    End Sub

    Private Sub TextBox126_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_29.KeyPress
        Numero(TextBox_Vol_Desc_v_29, 6, e)
    End Sub

    Private Sub TextBox128_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_30.KeyPress
        Numero(TextBox_Vol_Desc_v_30, 6, e)
    End Sub

    Private Sub TextBox130_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_31.KeyPress
        Numero(TextBox_Vol_Desc_v_31, 6, e)
    End Sub

    Private Sub TextBox132_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_32.KeyPress
        Numero(TextBox_Vol_Desc_v_32, 6, e)
    End Sub

    Private Sub TextBox134_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_33.KeyPress
        Numero(TextBox_Vol_Desc_v_33, 6, e)
    End Sub

    Private Sub TextBox136_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_34.KeyPress
        Numero(TextBox_Vol_Desc_v_34, 6, e)
    End Sub

    Private Sub TextBox138_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_35.KeyPress
        Numero(TextBox_Vol_Desc_v_35, 6, e)
    End Sub

    Private Sub TextBox140_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_36.KeyPress
        Numero(TextBox_Vol_Desc_v_36, 6, e)
    End Sub

    Private Sub TextBox142_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_37.KeyPress
        Numero(TextBox_Vol_Desc_v_37, 6, e)
    End Sub

    Private Sub TextBox144_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_38.KeyPress
        Numero(TextBox_Vol_Desc_v_38, 6, e)
    End Sub

    Private Sub TextBox146_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_39.KeyPress
        Numero(TextBox_Vol_Desc_v_39, 6, e)
    End Sub

    Private Sub TextBox148_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_40.KeyPress
        Numero(TextBox_Vol_Desc_v_40, 6, e)
    End Sub

    Private Sub TextBox150_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_41.KeyPress
        Numero(TextBox_Vol_Desc_v_41, 6, e)
    End Sub

    Private Sub TextBox152_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_42.KeyPress
        Numero(TextBox_Vol_Desc_v_42, 6, e)
    End Sub

    Private Sub TextBox154_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_43.KeyPress
        Numero(TextBox_Vol_Desc_v_43, 6, e)
    End Sub

    Private Sub TextBox156_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_44.KeyPress
        Numero(TextBox_Vol_Desc_v_44, 6, e)
    End Sub

    Private Sub TextBox158_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_45.KeyPress
        Numero(TextBox_Vol_Desc_v_45, 6, e)
    End Sub

    Private Sub TextBox160_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Vol_Desc_v_46.KeyPress
        Numero(TextBox_Vol_Desc_v_46, 6, e)
    End Sub

    Private Sub TextBox165_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_1.KeyPress
        Numero(TextBox2_Vol_Flot_v_1, 6, e)
    End Sub

    Private Sub TextBox167_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_2.KeyPress
        Numero(TextBox2_Vol_Flot_v_2, 6, e)
    End Sub

    Private Sub TextBox169_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_3.KeyPress
        Numero(TextBox2_Vol_Flot_v_3, 6, e)
    End Sub

    Private Sub TextBox171_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_4.KeyPress
        Numero(TextBox2_Vol_Flot_v_4, 6, e)
    End Sub

    Private Sub TextBox173_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_5.KeyPress
        Numero(TextBox2_Vol_Flot_v_5, 6, e)
    End Sub

    Private Sub TextBox175_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_6.KeyPress
        Numero(TextBox2_Vol_Flot_v_6, 6, e)
    End Sub

    Private Sub TextBox177_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_7.KeyPress
        Numero(TextBox2_Vol_Flot_v_7, 6, e)
    End Sub

    Private Sub TextBox179_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_8.KeyPress
        Numero(TextBox2_Vol_Flot_v_8, 6, e)
    End Sub

    Private Sub TextBox181_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_9.KeyPress
        Numero(TextBox2_Vol_Flot_v_9, 6, e)
    End Sub

    Private Sub TextBox183_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_10.KeyPress
        Numero(TextBox2_Vol_Flot_v_10, 6, e)
    End Sub

    Private Sub TextBox185_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_11.KeyPress
        Numero(TextBox2_Vol_Flot_v_11, 6, e)
    End Sub

    Private Sub TextBox187_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_12.KeyPress
        Numero(TextBox2_Vol_Flot_v_12, 6, e)
    End Sub

    Private Sub TextBox189_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_13.KeyPress
        Numero(TextBox2_Vol_Flot_v_13, 6, e)
    End Sub

    Private Sub TextBox191_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_14.KeyPress
        Numero(TextBox2_Vol_Flot_v_14, 6, e)
    End Sub

    Private Sub TextBox193_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_15.KeyPress
        Numero(TextBox2_Vol_Flot_v_15, 6, e)
    End Sub

    Private Sub TextBox195_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_16.KeyPress
        Numero(TextBox2_Vol_Flot_v_16, 6, e)
    End Sub

    Private Sub TextBox197_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_17.KeyPress
        Numero(TextBox2_Vol_Flot_v_17, 6, e)
    End Sub

    Private Sub TextBox199_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_18.KeyPress
        Numero(TextBox2_Vol_Flot_v_18, 6, e)
    End Sub

    Private Sub TextBox201_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_19.KeyPress
        Numero(TextBox2_Vol_Flot_v_19, 6, e)
    End Sub

    Private Sub TextBox203_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_20.KeyPress
        Numero(TextBox2_Vol_Flot_v_20, 6, e)
    End Sub

    Private Sub TextBox205_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_21.KeyPress
        Numero(TextBox2_Vol_Flot_v_21, 6, e)
    End Sub

    Private Sub TextBox207_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_22.KeyPress
        Numero(TextBox2_Vol_Flot_v_22, 6, e)
    End Sub

    Private Sub TextBox209_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_23.KeyPress
        Numero(TextBox2_Vol_Flot_v_23, 6, e)
    End Sub

    Private Sub TextBox166_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_1.KeyPress
        Numero(TextBox2_Vol_Desc_v_1, 6, e)
    End Sub

    Private Sub TextBox168_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_2.KeyPress
        Numero(TextBox2_Vol_Desc_v_2, 6, e)
    End Sub

    Private Sub TextBox170_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_3.KeyPress
        Numero(TextBox2_Vol_Desc_v_3, 6, e)
    End Sub

    Private Sub TextBox172_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_4.KeyPress
        Numero(TextBox2_Vol_Desc_v_4, 6, e)
    End Sub

    Private Sub TextBox174_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_5.KeyPress
        Numero(TextBox2_Vol_Desc_v_5, 6, e)
    End Sub

    Private Sub TextBox176_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_6.KeyPress
        Numero(TextBox2_Vol_Desc_v_6, 6, e)
    End Sub

    Private Sub TextBox178_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_7.KeyPress
        Numero(TextBox2_Vol_Desc_v_7, 6, e)
    End Sub

    Private Sub TextBox180_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_8.KeyPress
        Numero(TextBox2_Vol_Desc_v_8, 6, e)
    End Sub

    Private Sub TextBox182_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_9.KeyPress
        Numero(TextBox2_Vol_Desc_v_9, 6, e)
    End Sub

    Private Sub TextBox184_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_10.KeyPress
        Numero(TextBox2_Vol_Desc_v_10, 6, e)
    End Sub

    Private Sub TextBox186_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_11.KeyPress
        Numero(TextBox2_Vol_Desc_v_11, 6, e)
    End Sub

    Private Sub TextBox188_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_12.KeyPress
        Numero(TextBox2_Vol_Desc_v_12, 6, e)
    End Sub

    Private Sub TextBox190_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_13.KeyPress
        Numero(TextBox2_Vol_Desc_v_13, 6, e)
    End Sub

    Private Sub TextBox192_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_14.KeyPress
        Numero(TextBox2_Vol_Desc_v_14, 6, e)
    End Sub

    Private Sub TextBox194_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_15.KeyPress
        Numero(TextBox2_Vol_Desc_v_15, 6, e)
    End Sub

    Private Sub TextBox196_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_16.KeyPress
        Numero(TextBox2_Vol_Desc_v_16, 6, e)
    End Sub

    Private Sub TextBox198_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_17.KeyPress
        Numero(TextBox2_Vol_Desc_v_17, 6, e)
    End Sub

    Private Sub TextBox200_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_18.KeyPress
        Numero(TextBox2_Vol_Desc_v_18, 6, e)
    End Sub

    Private Sub TextBox202_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_19.KeyPress
        Numero(TextBox2_Vol_Desc_v_19, 6, e)
    End Sub

    Private Sub TextBox204_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_20.KeyPress
        Numero(TextBox2_Vol_Desc_v_20, 6, e)
    End Sub

    Private Sub TextBox206_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_21.KeyPress
        Numero(TextBox2_Vol_Desc_v_21, 6, e)
    End Sub

    Private Sub TextBox208_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_22.KeyPress
        Numero(TextBox2_Vol_Desc_v_22, 6, e)
    End Sub

    Private Sub TextBox210_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_23.KeyPress
        Numero(TextBox2_Vol_Desc_v_23, 6, e)
    End Sub

    Private Sub TextBox211_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_24.KeyPress
        Numero(TextBox2_Vol_Flot_v_24, 6, e)
    End Sub

    Private Sub TextBox213_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_25.KeyPress
        Numero(TextBox2_Vol_Flot_v_25, 6, e)
    End Sub

    Private Sub TextBox215_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_26.KeyPress
        Numero(TextBox2_Vol_Flot_v_26, 6, e)
    End Sub

    Private Sub TextBox217_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_27.KeyPress
        Numero(TextBox2_Vol_Flot_v_27, 6, e)
    End Sub

    Private Sub TextBox219_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_28.KeyPress
        Numero(TextBox2_Vol_Flot_v_28, 6, e)
    End Sub

    Private Sub TextBox221_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_29.KeyPress
        Numero(TextBox2_Vol_Flot_v_29, 6, e)
    End Sub

    Private Sub TextBox223_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_30.KeyPress
        Numero(TextBox2_Vol_Flot_v_30, 6, e)
    End Sub

    Private Sub TextBox225_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_31.KeyPress
        Numero(TextBox2_Vol_Flot_v_31, 6, e)
    End Sub

    Private Sub TextBox227_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_32.KeyPress
        Numero(TextBox2_Vol_Flot_v_32, 6, e)
    End Sub

    Private Sub TextBox229_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_33.KeyPress
        Numero(TextBox2_Vol_Flot_v_33, 6, e)
    End Sub

    Private Sub TextBox231_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_34.KeyPress
        Numero(TextBox2_Vol_Flot_v_34, 6, e)
    End Sub

    Private Sub TextBox233_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_35.KeyPress
        Numero(TextBox2_Vol_Flot_v_35, 6, e)
    End Sub

    Private Sub TextBox235_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_36.KeyPress
        Numero(TextBox2_Vol_Flot_v_36, 6, e)
    End Sub

    Private Sub TextBox237_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_37.KeyPress
        Numero(TextBox2_Vol_Flot_v_37, 6, e)
    End Sub

    Private Sub TextBox239_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_38.KeyPress
        Numero(TextBox2_Vol_Flot_v_38, 6, e)
    End Sub

    Private Sub TextBox241_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_39.KeyPress
        Numero(TextBox2_Vol_Flot_v_39, 6, e)
    End Sub

    Private Sub TextBox243_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_40.KeyPress
        Numero(TextBox2_Vol_Flot_v_40, 6, e)
    End Sub

    Private Sub TextBox245_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_41.KeyPress
        Numero(TextBox2_Vol_Flot_v_41, 6, e)
    End Sub

    Private Sub TextBox247_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_42.KeyPress
        Numero(TextBox2_Vol_Flot_v_42, 6, e)
    End Sub

    Private Sub TextBox249_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_43.KeyPress
        Numero(TextBox2_Vol_Flot_v_43, 6, e)
    End Sub

    Private Sub TextBox251_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_44.KeyPress
        Numero(TextBox2_Vol_Flot_v_44, 6, e)
    End Sub

    Private Sub TextBox253_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_45.KeyPress
        Numero(TextBox2_Vol_Flot_v_45, 6, e)
    End Sub

    Private Sub TextBox255_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Flot_v_46.KeyPress
        Numero(TextBox2_Vol_Flot_v_46, 6, e)
    End Sub

    Private Sub TextBox212_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_24.KeyPress
        Numero(TextBox2_Vol_Desc_v_24, 6, e)
    End Sub

    Private Sub TextBox214_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_25.KeyPress
        Numero(TextBox2_Vol_Desc_v_25, 6, e)
    End Sub

    Private Sub TextBox216_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_26.KeyPress
        Numero(TextBox2_Vol_Desc_v_26, 6, e)
    End Sub

    Private Sub TextBox218_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_27.KeyPress
        Numero(TextBox2_Vol_Desc_v_27, 6, e)
    End Sub

    Private Sub TextBox220_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_28.KeyPress
        Numero(TextBox2_Vol_Desc_v_28, 6, e)
    End Sub

    Private Sub TextBox222_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_29.KeyPress
        Numero(TextBox2_Vol_Desc_v_29, 6, e)
    End Sub

    Private Sub TextBox224_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_30.KeyPress
        Numero(TextBox2_Vol_Desc_v_30, 6, e)
    End Sub

    Private Sub TextBox226_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_31.KeyPress
        Numero(TextBox2_Vol_Desc_v_31, 6, e)
    End Sub

    Private Sub TextBox228_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_32.KeyPress
        Numero(TextBox2_Vol_Desc_v_32, 6, e)
    End Sub

    Private Sub TextBox230_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_33.KeyPress
        Numero(TextBox2_Vol_Desc_v_33, 6, e)
    End Sub

    Private Sub TextBox232_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_34.KeyPress
        Numero(TextBox2_Vol_Desc_v_34, 6, e)
    End Sub

    Private Sub TextBox234_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_35.KeyPress
        Numero(TextBox2_Vol_Desc_v_35, 6, e)
    End Sub

    Private Sub TextBox236_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_36.KeyPress
        Numero(TextBox2_Vol_Desc_v_36, 6, e)
    End Sub

    Private Sub TextBox238_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_37.KeyPress
        Numero(TextBox2_Vol_Desc_v_37, 6, e)
    End Sub

    Private Sub TextBox240_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_38.KeyPress
        Numero(TextBox2_Vol_Desc_v_38, 6, e)
    End Sub

    Private Sub TextBox242_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_39.KeyPress
        Numero(TextBox2_Vol_Desc_v_39, 6, e)
    End Sub

    Private Sub TextBox244_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_40.KeyPress
        Numero(TextBox2_Vol_Desc_v_40, 6, e)
    End Sub

    Private Sub TextBox246_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_41.KeyPress
        Numero(TextBox2_Vol_Desc_v_41, 6, e)
    End Sub

    Private Sub TextBox248_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_42.KeyPress
        Numero(TextBox2_Vol_Desc_v_42, 6, e)
    End Sub

    Private Sub TextBox250_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_43.KeyPress
        Numero(TextBox2_Vol_Desc_v_43, 6, e)
    End Sub

    Private Sub TextBox252_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_44.KeyPress
        Numero(TextBox2_Vol_Desc_v_44, 6, e)
    End Sub

    Private Sub TextBox254_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_45.KeyPress
        Numero(TextBox2_Vol_Desc_v_45, 6, e)
    End Sub

    Private Sub TextBox256_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_Vol_Desc_v_46.KeyPress
        Numero(TextBox2_Vol_Desc_v_46, 6, e)
    End Sub

    Private Sub TextBox164_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Resistencia.KeyPress
        Numero(TextBox_Resistencia, 6, e)
    End Sub

    Private Sub TextBox163_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Tiempo.KeyPress
        Numero(TextBox_Tiempo, 6, e)
    End Sub

    Private Sub TextBox257_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cantidad_1.KeyPress
        Numero(TextBox_Cantidad_1, 2, e)
    End Sub

    Private Sub TextBox260_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cantidad_2.KeyPress
        Numero(TextBox_Cantidad_2, 2, e)
    End Sub

    Private Sub TextBox263_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cantidad_3.KeyPress
        Numero(TextBox_Cantidad_3, 2, e)
    End Sub

    Private Sub TextBox266_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cantidad_4.KeyPress
        Numero(TextBox_Cantidad_4, 2, e)
    End Sub

    Private Sub TextBox258_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Unidad_1.KeyPress
        Letras(TextBox_Unidad_1, 15, e)
    End Sub

    Private Sub TextBox261_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Unidad_2.KeyPress
        Letras(TextBox_Unidad_2, 15, e)
    End Sub

    Private Sub TextBox264_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Unidad_3.KeyPress
        Letras(TextBox_Unidad_3, 15, e)
    End Sub

    Private Sub TextBox267_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Unidad_4.KeyPress
        Letras(TextBox_Unidad_4, 15, e)
    End Sub

    Private Sub TextBox259_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Descripcion_1.KeyPress
        Letras(TextBox_Descripcion_1, 100, e)
    End Sub

    Private Sub TextBox262_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Descripcion_2.KeyPress
        Letras(TextBox_Descripcion_2, 100, e)
    End Sub

    Private Sub TextBox265_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Descripcion_3.KeyPress
        Letras(TextBox_Descripcion_3, 100, e)
    End Sub

    Private Sub TextBox268_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Descripcion_4.KeyPress
        Letras(TextBox_Descripcion_4, 100, e)
    End Sub

    Private Sub TextBox272_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Observaciones_comentarios.KeyPress
        Letras(TextBox_Descripcion_1, 200, e)
    End Sub

    Private Sub TextBox273_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Responsable_empresa.KeyPress
        Letras(TextBox_Descripcion_1, 50, e)
    End Sub

    Private Sub TextBox274_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cliente2.KeyPress
        Letras(TextBox_Descripcion_1, 50, e)
    End Sub

End Class