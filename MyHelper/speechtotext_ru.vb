Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Public Class speechtotext_ru
    <DllImport("winmm.dll")>
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As StringBuilder, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim i As Integer
            i = mciSendString("open new type waveaudio alias capture", Nothing, 0, 0)
            Console.WriteLine(i)
            'i = mciSendString("set capture samplespersec " & lSamples & " channels " & lChannels & " bitspersample " & lBits & " alignment " & iBlockAlign & " bytespersec " & lBytesPerSec, Nothing, 0, 0)
            'Console.WriteLine(i)
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
            TextBox1.Text = zzz
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













End Class