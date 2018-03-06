Imports System
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.String
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class read_hy
    Private connectionString As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim user_text As String, text_user As String
        user_text = TextBox1.Text
        Dim textforchecklang As String
        If user_text.Length > 200 Then
            textforchecklang = user_text.Substring(20)
        Else : textforchecklang = user_text
        End If
        textforchecklang = start_test.get_translate_key() & textforchecklang
        If start_test.getxmlattrvalue(textforchecklang, "code") <> 200 Then
            MsgBox("Error : No internet connection , server disabled. If you think it is wrong, contact to MyHelper's support")
        Else
            Dim language As String
            language = start_test.getxmlattrvalue(textforchecklang, "lang")
            If language <> "en" And language <> "ru" And language <> "uk" Then
                MsgBox("Извените, , система работает только русский, английский, украинский языки")
            Else
                If language = "en" Then
                    language = "en-US"
                End If
                If language = "ru" Then
                    language = "ru-RU"
                End If
                If language = "uk" Then
                    language = "uk-UK"
                End If
                Dim hgfrhfru As String = start_test.getserver() & "api/system/url-encode.php?a="

                user_text = start_test.Makequery(hgfrhfru & user_text)
                text_user = start_test.get_speechkit_key() & user_text & "&lang=" & language
                AxWindowsMediaPlayer1.URL = text_user
            End If
        End If
        Dim a As String = TextBox1.Text & " " & " "
        For i = 0 To a.Length - 1
            Dim c As String = a.Substring(i, 1)
            Dim myFilePath As String = ("rus\" & c & ".gif")
            If c = " " Then
                PictureBox1.ImageLocation = ("rus\s.png")
                Threading.Thread.Sleep(500)
            End If
            If File.Exists(myFilePath) Then
                PictureBox1.ImageLocation = ("rus\" & c & ".gif")
                Threading.Thread.Sleep(500)
            Else
                Dim g As Graphics = PictureBox1.CreateGraphics()
                PictureBox1.Image = Nothing
                g.DrawString(c, New Font("Arial", 100), Brushes.Black, 30, 30)
                Threading.Thread.Sleep(500)
            End If
            Application.DoEvents()
        Next
    End Sub   '' Կատարվում է հարցումը և պատասխանի ստացումը
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
        start_test.calltomoderator()
    End Sub '' Զանգել օգնողին
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        menu_hy.Show()
        Me.Close()
    End Sub '' Վերադարձ դեպի մենյու
    Private Sub read_hy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start_test.readload()
    End Sub  '' Գույների, անհրաժեշտ գործիքների ընտրում
End Class