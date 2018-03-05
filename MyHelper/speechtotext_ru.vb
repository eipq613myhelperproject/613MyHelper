Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.Web
Imports System.IO

Public Class speechtotext_ru
    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As StringBuilder, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim i As Integer
            i = mciSendString("open new type waveaudio alias capture", Nothing, 0, 0)
            Console.WriteLine(i)
          i = mciSendString("record capture", Nothing, 0, 0)
            Console.WriteLine(i)
            Threading.Thread.Sleep(2000)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub






    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            Dim i As Integer
            i = mciSendString("save capture " & "sox/aaa.wav", Nothing, 0, 0)
            i = mciSendString("close capture", Nothing, 0, 0)
            Dim snotes As New System.Diagnostics.Process()
            snotes = Process.Start("aaa.vbs", "")
            Threading.Thread.Sleep(300)
            Dim zzz = ConvertFileToBase64("aaa.flac")
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("test.txt", True)
            file.WriteLine(zzz)
            file.Close()

            Dim logincookie As CookieContainer
            Dim postData As String = "audio=" & zzz
            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)
            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("http://iwebing.96.lt/speechtotext.php?lang=en-US"), HttpWebRequest)
            postReq.Method = "POST"
            postReq.KeepAlive = True
            postReq.CookieContainer = tempCookies
            postReq.ContentType = "application/x-www-form-urlencoded"
            postReq.Referer = "http://iwebing.96.lt/speechtotext.php?lang=en-US"
            postReq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
            postReq.ContentLength = byteData.Length
            Dim postreqstream As Stream = postReq.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
            postreqstream.Close()
            Dim postresponse As HttpWebResponse
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
            tempCookies.Add(postresponse.Cookies)
            logincookie = tempCookies
            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
            Dim thepage As String = postreqreader.ReadToEnd
            TextBox1.Text = thepage


        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Public Function ConvertFileToBase64(ByVal fileName As String) As String
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
    End Function

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        menu_ru.Show()
        Me.Hide()
    End Sub




    Private Function UnicodeBytesToString(
    ByVal bytes() As Byte) As String

        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function


    Public Function postData(ByRef URL As String, ByRef POST As String, ByRef Cookies As CookieContainer)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        request = CType(WebRequest.Create(URL), HttpWebRequest)
        request.ContentType = "application/x-www-form-urlencoded"
        MsgBox(POST)
        request.ContentLength = POST.Length
        request.Method = "POST"
        request.AllowAutoRedirect = False
        Dim requeststream As Stream = request.GetRequestStream()
        Dim postBytes As Byte() = Encoding.ASCII.GetBytes(POST)
        requeststream.Write(postBytes, 0, postBytes.Length)
        requeststream.Close()
        response = CType(request.GetResponse(), HttpWebResponse)
        Return New StreamReader(response.GetResponseStream()).ReadToEnd()
    End Function


End Class