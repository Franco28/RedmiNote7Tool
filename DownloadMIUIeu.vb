
Imports System.Net

Public Class DownloadMIUIeu

    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "xiaomi.eu_multi_HMNote7_9.11.14_v11-9.zip"
    Private LastCount As Integer = 0

    Private Sub DownloadMIUIeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        If (Not System.IO.Directory.Exists("C:\adb\.settings\xiaomieu")) Then
            System.IO.Directory.CreateDirectory("C:\adb\.settings\xiaomieu")
        End If

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                TextBox1.Text = "Starting download... Please wait"
                WClient.DownloadFileAsync(New Uri("https://va2.androidfilehost.com/dl/xTDek6CNKuxMCQl8CBUIog/1574151887/4349826312261629207/xiaomi.eu_multi_HMNote7_9.11.14_v11-9.zip"), "C:\adb\.settings\xiaomieu\xiaomi.eu_multi_HMNote7_9.11.14_v11-9.zip")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Can´t connect to the server to download MIUI By Xiaomi.eu!", MessageBoxIcon.Warning)
            System.Windows.Forms.Application.Restart()
        End Try

    End Sub

    Private Sub wClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WClient.DownloadProgressChanged

        ProgressBar1.Value = e.ProgressPercentage

        If e.ProgressPercentage > LastCount Then
            TextBox1.Text = FileName & "... " & LastCount.ToString & " % Completed"
            LastCount += 1
        End If

    End Sub

    Private Sub wClient_DownloadComplete(ByVal sender As Object, ByVal e As EventArgs) Handles WClient.DownloadFileCompleted

        TextBox1.Text = FileName & "... " & "100 % Complete"

        LastCount = 0

        Dim visual = New Visual()

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomieu\xiaomi.eu_multi_HMNote7_9.11.14_v11-9.zip")

        If infoReader.Length < 1717986918.4 Then
            MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
            Dim miuieu = New DownloadMIUIeu()
            miuieu.Show()
            MyBase.Dispose(Disposing)
        Else
            Dim Proc As String = "Explorer.exe"
            Dim Args As String =
            ControlChars.Quote &
            IO.Path.Combine("C:\", "adb\.settings\xiaomieu") &
            ControlChars.Quote
            Process.Start(Proc, Args)

            visual.Show()
            MyBase.Dispose(Disposing)
        End If

    End Sub
End Class