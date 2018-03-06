Imports System
Imports System.Net
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class ask_hy
    Private connectionString As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Visible = False
        WebBrowser1.Visible = False
        PictureBox1.Visible = False
        ' //////////// Get English text
        Dim user_text As String
        user_text = TextBox1.Text
        Dim textforchecklang As String
        textforchecklang = "https://translate.yandex.net/api/v1.5/tr/translate?key=" & start_test.trans_key() & "&lang=en&text=" & user_text
        Dim translatedtext As String = start_test.getxmltagvalue(textforchecklang, "Translation/text")
        Dim translatedtextazaz As String = "http://api.wolframalpha.com/v1/result?appid=H66T43-J89H6RJHLH&i=" & start_test.replaceaaa(translatedtext)
        Dim zzzzzz = start_test.Makequerya(translatedtextazaz, user_text)
        '//////////////////   Get Armenian text  
        Dim textforchecklangz As String
        textforchecklangz = user_text
        If textforchecklangz.Length > 200 Then
            textforchecklangz = textforchecklangz.Substring(20)
        End If
        textforchecklangz = "https://translate.yandex.net/api/v1.5/tr/detect?key=" & start_test.trans_key() & "&text=" & textforchecklangz
        Dim detectedlang As String = start_test.getxmlattrvalue(textforchecklang, "lang")
        detectedlang = detectedlang.Substring(0, 2)
        Dim retranslate As String = "https://translate.yandex.net/api/v1.5/tr/translate?key=" & start_test.trans_key() & "&lang=" & detectedlang & "&text=" & zzzzzz
        Dim translatedtexts As String = start_test.getxmltagvalue(retranslate, "text")
        TextBox2.Visible = True
        TextBox2.Text = translatedtexts
        user_text = translatedtexts
        If Len(user_text) > 200 Then
            textforchecklang = user_text.Substring(20)
        Else : textforchecklang = user_text
        End If
        textforchecklang = "https://translate.yandex.net/api/v1.5/tr/detect?key=" & start_test.trans_key() & "&text=" & textforchecklang
        If start_test.getxmlattrvalue(textforchecklang, "code") <> 200 Then
            ' MsgBox("Error . There isnt error, some server are disabled . If you think as it is an error , contact to MyHELPER'S SUPPORT")
        Else
            Dim language As String
            language = start_test.getxmlattrvalue(textforchecklang, "lang")
            If language <> "en" And language <> "ru" And language <> "uk" Then
                'MsgBox("Извените, , система работает только русский, английский, украинский языки")
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
                Dim text_user As String = "https://tts.voicetech.yandex.net/generate?key=" & start_test.speech_key() & "&emotion=good&text=" & user_text & "&lang=" & language 'user_text
                AxWindowsMediaPlayer1.URL = text_user
                PictureBox1.Visible = True
                user_text = translatedtexts
                Dim a As String = translatedtexts & " " & " "
                For i = 0 To a.Length - 1
                    Dim c As String = a.Substring(i, 1)
                    Dim myFilePath As String = ("rus\" & c & ".gif")
                    If c = " " Then
                        PictureBox1.ImageLocation = ("rus\s.png")
                        Threading.Thread.Sleep(500)
                    ElseIf File.Exists(myFilePath) Then
                        PictureBox1.ImageLocation = ("rus\" & c & ".gif")
                        Threading.Thread.Sleep(500)
                    Else
                        Dim g As Graphics = PictureBox1.CreateGraphics()
                        PictureBox1.Image = Nothing
                        g.DrawString(c, New Font("Arial", 100), Brushes.Black, 30, 30)
                        Threading.Thread.Sleep(1000)
                    End If
                    Application.DoEvents()
                Next
            End If
        End If
    End Sub   ' Կատարել հարցում, ստանալ պատ.
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        start_test.calltomoderator()
    End Sub ' Զանգել օգնողին
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        menu_hy.Show()
        Me.Close()
    End Sub  ' վերադառնալ գնխավոր մենյու
    Private Sub ask_hy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start_test.askload()
    End Sub   '' Համապատասխան թեմայի ընտրում
End Class