Public Class BrowserCheck

    Shared Sub StartBrowser(Proc As String, Args As String)

        If System.IO.File.Exists("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") = True Then
            Process.Start(Proc, Args)

        ElseIf System.IO.File.Exists("C:\Program Files\Google\Chrome\Application\chrome.exe") = True Then
            Process.Start(Proc, Args)

        ElseIf System.IO.File.Exists("C:\Program Files\Google\Chrome\Application\MicrosoftEdge.exe") = False Then
            Process.Start(Proc, Args)

        ElseIf System.IO.File.Exists("C:\Program Files (x86)\Google\Chrome\Application\MicrosoftEdge.exe") = False Then
            Process.Start(Proc, Args)

        End If

    End Sub

End Class
