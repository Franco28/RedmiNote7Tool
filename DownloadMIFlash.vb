Imports System.IO.Compression
Imports System.Net

Public Class DownloadMIFlash

    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "MiFlash20181115.zip"
    Private LastCount As Integer = 0

    Private Sub DownloadMIFlash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        Dim paths() As String = IO.Directory.GetFiles("C:\adb\MI", "*.zip")
        If paths.Length > 0 Then 'if at least one file is found do something
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\MI\MiFlash20181115.zip")

            If infoReader.Length > 75900000 Then

                Dim zipPath As String = "C:\adb\MI\MiFlash20181115.zip"
                Dim extractPath As String = "C:\adb\MI\"

                ZipFile.ExtractToDirectory(zipPath, extractPath)

                Dim FileToDelete As String

                FileToDelete = "C:\adb\MI\MiFlash20181115.zip"

                If System.IO.File.Exists(FileToDelete) = True Then

                    System.IO.File.Delete(FileToDelete)

                End If

                MsgBox("Mi Flash installed in C:\adb\MI\", MessageBoxIcon.Information)

                Dim visual = New Visual()
                visual.Show()
                MyBase.Dispose(Disposing)

            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
                        TextBox1.Text = "Starting download... Please wait"
                        WClient.DownloadFileAsync(New Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/MiFlash20181115.zip"), "C:\adb\MI\MiFlash20181115.zip")
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download Mi Flash!", MessageBoxIcon.Warning)
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        Else

            Try
                If My.Computer.Network.Ping("www.google.com") Then
                    TextBox1.Text = "Starting download... Please wait"
                    WClient.DownloadFileAsync(New Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/MiFlash20181115.zip"), "C:\adb\MI\MiFlash20181115.zip")
                End If
            Catch ex As Exception
                MsgBox("ERROR: Can´t connect to the server to download Mi Flash!", MessageBoxIcon.Warning)
                System.Windows.Forms.Application.Restart()
            End Try

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

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\MI\MiFlash20181115.zip")

        If infoReader.Length < 75900000 Then

            MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
            Dim miflash = New DownloadMIFlash()
            miflash.Show()
            MyBase.Dispose(Disposing)

        Else

            ChDir("C:\adb\MI\MiFlash20181115.zip")

            Dim zipPath As String = "C:\adb\MI\MiFlash20181115.zip"
            Dim extractPath As String = "C:\adb\MI\"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            Dim FileToDelete As String

            FileToDelete = "C:\adb\MI\MiFlash20181115.zip"

            If System.IO.File.Exists(FileToDelete) = True Then

                System.IO.File.Delete(FileToDelete)

            End If

            MsgBox("Mi Flash installed in C:\adb\MI\", MessageBoxIcon.Information)

            Dim visual = New Visual()
            visual.Show()
            MyBase.Dispose(Disposing)

        End If

    End Sub

    Private Sub DownloadMIFlash_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        System.Windows.Forms.Application.Restart()

    End Sub


End Class