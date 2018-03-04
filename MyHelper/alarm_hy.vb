Public Class alarm_hy
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim songs() As String = {"alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3", "alarm.mp3"}
        For x As Integer = 0 To songs.GetUpperBound(0)
            Dim song As WMPLib.IWMPMedia = AxWindowsMediaPlayer1.newMedia(songs(x))
            AxWindowsMediaPlayer1.currentPlaylist.appendItem(song)
        Next
        AxWindowsMediaPlayer1.settings.setMode("shuffle", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub '' Alarm backend
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub ''Գնալ ետ
End Class