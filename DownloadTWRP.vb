
Imports System.IO
Imports System.IO.Compression
Imports System.Net

Public Class DownloadTWRP

    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "OrangeFox-R10.0_2-Stable-lavender.zip"
    Private LastCount As Integer = 0

    Private Sub DownloadTWRP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        If Not Directory.Exists("C:\adb\.settings\TWRP") Then
            Directory.CreateDirectory("C:\adb\.settings\TWRP")
        End If


        Dim paths() As String = IO.Directory.GetFiles("C:\adb\MI", "*.zip")
        If paths.Length > 0 Then 'if at least one file is found do something
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip")

            If infoReader.Length > 40900000 Then

                Dim zipPath As String = "C:\adb\.settings\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip"
                Dim extractPath As String = "C:\adb\.settings\TWRP"

                ZipFile.ExtractToDirectory(zipPath, extractPath)

                Dim visual = New Visual()
                visual.Show()
                MyBase.Dispose(Disposing)

            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
                        TextBox1.Text = "Starting download... Please wait"
                        WClient.DownloadFileAsync(New Uri("https://files.orangefox.tech/OrangeFox-Stable/lavender/OrangeFox-R10.0_2-Stable-lavender.zip"), "C:\adb\.settings\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip")
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download TWRP!", MessageBoxIcon.Warning)
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        Else

            TextBox1.Text = "Starting download... Please wait"
            WClient.DownloadFileAsync(New Uri("https://files.orangefox.tech/OrangeFox-Stable/lavender/OrangeFox-R10.0_2-Stable-lavender.zip"), "C:\adb\.settings\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip")

        End If

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
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip")

        If infoReader.Length < 40900000 Then

            MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
            Dim twrpdownload = New DownloadTWRP()
            twrpdownload.Show()
            MyBase.Dispose(Disposing)

        Else

            Dim zipPath As String = "C:\adb\.settings\TWRP\OrangeFox-R10.0_2-Stable-lavender.zip"
            Dim extractPath As String = "C:\adb\.settings\TWRP"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            visual.Show()
            MyBase.Dispose(Disposing)

        End If
    End Sub

    Private Sub DownloadTWRP_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        System.Windows.Forms.Application.Restart()

    End Sub

End Class