
Imports System.IO.Compression
Imports System.Net

Public Class DownloadAdbFastboot

    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "adb.zip"
    Private LastCount As Integer = 0

    Private Sub DownloadAdbFastboot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        TextBox1.Text = "Files missing! Starting download... Please wait"

        WClient.DownloadFileAsync(New Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/adb.zip"), "C:\adb\adb.zip")
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

        ChDir("C:\adb")

        Dim zipPath As String = "adb.zip"
        Dim extractPath As String = "C:\adb"

        ZipFile.ExtractToDirectory(zipPath, extractPath)

        Dim FileToDelete As String

        FileToDelete = "C:\adb\adb.zip"

        If System.IO.File.Exists(FileToDelete) = True Then

            System.IO.File.Delete(FileToDelete)

        End If

        MsgBox("adb & fastboot installed in C:\adb", MessageBoxIcon.Information)

        Dim visual = New Visual()
        visual.Show()
        MyBase.Dispose(Disposing)

    End Sub

End Class