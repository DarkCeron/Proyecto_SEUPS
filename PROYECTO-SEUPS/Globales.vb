Module Globales
    Public Usuario As String
    Public Contrasena As String
    Public ServerName = "CERON\SQLEXPRESS"
    Public FolderOutput As String 'Almacenara la carpeta donde se almacenaran los pdfs

    Public Sub Letra(texto As TextBox, limite As Integer, e As KeyPressEventArgs)
        If (e.KeyChar = vbBack) Then
            e.Handled = False
        ElseIf Not (Char.IsLetter(e.KeyChar) And e.KeyChar <> vbBack) Then
            e.Handled = True
        ElseIf (Len(texto.Text) > limite - 1 And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If

    End Sub

    Public Sub Letras(texto As TextBox, limite As Integer, e As KeyPressEventArgs)
        If (e.KeyChar = vbBack Or e.KeyChar.Equals("."c) Or e.KeyChar = " ") Then
            e.Handled = False
        ElseIf Not (Char.IsLetter(e.KeyChar) And e.KeyChar <> vbBack) Then
            e.Handled = True
        ElseIf (Len(texto.Text) > limite - 1 And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Sub LetraYNumero(texto As TextBox, limite As Integer, e As KeyPressEventArgs)
        If (e.KeyChar = vbBack) Then
            e.Handled = False
        ElseIf Not (Char.IsLetterOrDigit(e.KeyChar) And e.KeyChar <> vbBack) Then
            e.Handled = True
        ElseIf (Len(texto.Text) > limite - 1 And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Sub Numero(texto As TextBox, limite As Integer, e As KeyPressEventArgs)
        If (e.KeyChar = vbBack) Then
            e.Handled = False
        ElseIf Not (Char.IsNumber(e.KeyChar) And e.KeyChar <> vbBack) Then
            e.Handled = True
        ElseIf (Len(texto.Text) > limite - 1 And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Sub NumeroE(texto As TextBox, limite As Integer, e As KeyPressEventArgs)
        If (e.KeyChar = vbBack Or e.KeyChar.Equals("-"c)) Then
            e.Handled = False
        ElseIf Not (Char.IsNumber(e.KeyChar) And e.KeyChar <> vbBack) Then
            e.Handled = True
        ElseIf (Len(texto.Text) > limite - 1 And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

    Public Sub LetrasCamText(texto As RichTextBox, limite As Integer, e As KeyPressEventArgs)
        If (e.KeyChar = vbBack Or e.KeyChar.Equals("."c)) Then
            e.Handled = False
        ElseIf Not (Char.IsLetter(e.KeyChar) And e.KeyChar <> vbBack) Then
            e.Handled = True
        ElseIf (Len(texto.Text) > limite - 1 And e.KeyChar <> vbBack) Then
            e.Handled = True
        End If
    End Sub

End Module