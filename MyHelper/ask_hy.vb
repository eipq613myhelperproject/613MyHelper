Imports System
Imports System.Net
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class ask_hy
    Private connectionString As String
    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function

    Function Makequery(ByVal query As String)
        Try
            Dim Request As HttpWebRequest = HttpWebRequest.Create(query)
            Request.Proxy = Nothing
            Request.UserAgent = "Test"
            Dim Response As HttpWebResponse = Request.GetResponse
            Dim ResponseStream As System.IO.Stream = Response.GetResponseStream
            Dim StreamReader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = StreamReader.ReadToEnd
            StreamReader.Close()
            Makequery = Data
        Catch ex As Exception
            'MsgBox("error")
            Debug.Print("makequery")
        End Try
    End Function
    Function Makequerya(ByVal query As String, ByVal user_text As String)
        Try
            Dim Request As HttpWebRequest = HttpWebRequest.Create(query)
            Request.Proxy = Nothing
            Request.UserAgent = "Test"
            Dim Response As HttpWebResponse = Request.GetResponse
            Dim ResponseStream As System.IO.Stream = Response.GetResponseStream
            Dim StreamReader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = StreamReader.ReadToEnd
            StreamReader.Close()
            Makequerya = Data
        Catch ex As Exception
            '   MsgBox(user_text)
            user_text = Makequery("http://iwebing.96.lt/api/world-it-planet-url-encode.php?a=" & user_text)
            Dim webAddress As String = "https://yandex.ru/search/?text=" & user_text
            'TextBox1.Text = webAddress
            WebBrowser1.Visible = True
            WebBrowser1.Navigate(webAddress)
            'Process.Start(webAddress)
        End Try
    End Function
    Function getxmltagvalue(ByVal query, ByVal valuetext)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            Dim xmlvalue As String
            xmlvalue = Makequery(query)
            doc.LoadXml(xmlvalue)

            Dim valuetexta As String = "//" & valuetext ' Translation/text
            Dim gettedtext As String = doc.SelectSingleNode(valuetexta).InnerText
            getxmltagvalue = gettedtext
        Catch ex As Exception
        End Try
    End Function
    Function getxmlattrvalue(ByVal query, ByVal attribute)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            Dim xmlvalue As String
            xmlvalue = Makequery(query)
            doc.LoadXml(xmlvalue)
            Dim root As XmlElement = doc.DocumentElement
            Dim lang As String
            If (root.HasAttribute(attribute)) Then
                lang = root.GetAttribute(attribute)
            Else : lang = "There is not found attribute"
            End If
            getxmlattrvalue = lang
        Catch ex As Exception
        End Try
    End Function

    Function replaceaaa(ByVal textaaa As String)
        Dim aaaaaa As String = textaaa
        For i = 0 To textaaa.Length - 1
            aaaaaa = textaaa.Replace(" ", "+")
        Next
        replaceaaa = aaaaaa
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TextBox2.Visible = False
        WebBrowser1.Visible = False
        PictureBox1.Visible = False









        ' //////////// Get English text
        Dim user_text As String
        user_text = TextBox1.Text
        Dim textforchecklang As String
        textforchecklang = "https://translate.yandex.net/api/v1.5/tr/translate?key=trnsl.1.1.20171215T141314Z.7e2b64cbfaa80409.452ed95d1799a5cc4054fb5ecf82a422669c1a09&lang=en&text=" & user_text
        Dim translatedtext As String = getxmltagvalue(textforchecklang, "Translation/text")
        Dim translatedtextazaz As String = "http://api.wolframalpha.com/v1/result?appid=H66T43-J89H6RJHLH&i=" & replaceaaa(translatedtext)
        Dim zzzzzz = Makequerya(translatedtextazaz, user_text)

        '//////////////////   Get Armenian text  



        Dim textforchecklangz As String
        textforchecklangz = user_text

        If textforchecklangz.Length > 200 Then
            textforchecklangz = textforchecklangz.Substring(20)
        End If


        textforchecklangz = "https://translate.yandex.net/api/v1.5/tr/detect?key=trnsl.1.1.20171215T141314Z.7e2b64cbfaa80409.452ed95d1799a5cc4054fb5ecf82a422669c1a09&text=" & textforchecklangz

        Dim detectedlang As String = getxmlattrvalue(textforchecklang, "lang")
        detectedlang = detectedlang.Substring(0, 2)

        '   MsgBox(detectedlang)

        '//////////////////   top is ok


        Dim retranslate As String = "https://translate.yandex.net/api/v1.5/tr/translate?key=trnsl.1.1.20171215T141314Z.7e2b64cbfaa80409.452ed95d1799a5cc4054fb5ecf82a422669c1a09&lang=" & detectedlang & "&text=" & zzzzzz
        '   TextBox1.Text = retranslate
        Dim translatedtexts As String = getxmltagvalue(retranslate, "text")


        '        MsgBox()
        TextBox2.Visible = True
        TextBox2.Text = translatedtexts 'zzzzzz



        user_text = translatedtexts

        If Len(user_text) > 200 Then
            textforchecklang = user_text.Substring(20)
        Else : textforchecklang = user_text
        End If
        textforchecklang = "https://translate.yandex.net/api/v1.5/tr/detect?key=trnsl.1.1.20171215T141314Z.7e2b64cbfaa80409.452ed95d1799a5cc4054fb5ecf82a422669c1a09&text=" & textforchecklang
        If getxmlattrvalue(textforchecklang, "code") <> 200 Then
            ' MsgBox("Error . API key was wrong or disactivated by yandex")
        Else
            Dim language As String
            language = getxmlattrvalue(textforchecklang, "lang")
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
                user_text = Makequery("http://iwebing.96.lt/api/world-it-planet-url-encode.php?a=" & user_text)
                Dim text_user As String = "https://tts.voicetech.yandex.net/generate?key=c6a0ef6d-8f9e-4379-9001-408fee63f93c&emotion=good&text=" & user_text & "&lang=" & language 'user_text
                'TextBox1.Text = text_user
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
















































    End Sub





    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String

        str = "SELECT * FROM moderator_data WHERE (name = '" & "tel" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim ezo As String
        While dr.Read()
            ezo = dr("value").ToString
        End While
        callto(ezo)
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String

        str = "SELECT * FROM moderator_data WHERE (name = '" & "tel" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim ezo As String
        While dr.Read()
            ezo = dr("value").ToString
        End While
        callto(ezo)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        menu_hy.Show()
        Me.Close()
    End Sub

    Private Sub ask_hy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim o As String = ""
        Dim provider As String
        Dim dataFile As String
        Dim connString As String

        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        Dim wherename As String
        wherename = "background"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            o = dr("value").ToString
        End While
        If o = "1" Then
            Me.BackColor = Color.White

            Button1.ForeColor = Color.Teal


        ElseIf o = "2" Then
            Me.BackColor = Color.White

            Button1.ForeColor = Color.Black

        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue

            Button1.ForeColor = Color.Blue

        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond

            Button1.ForeColor = Color.Sienna

        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed

            Button1.ForeColor = Color.Lime

        End If
    End Sub
End Class