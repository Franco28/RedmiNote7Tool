Public Class Help

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Audio = CreateObject("SAPI.SpVoice")
        Dim SAPI As Object
        Dim h = New Help()

        Audio.volume = 100

        Audio.rate = -1

        SAPI = CreateObject("SAPI.spvoice")

        SAPI.Speak("Hey! " & Environment.UserName & " Thanks for using this simple Tool! If you need to contact to developer, press the following button.")

        If My.Dialogs.QuestionDialog("Packed by Franco28: A simple IT student (c) 2019 - Redmi Note 7 Lavender", "Hey! " & Environment.UserName, "Contact", "Close") Then


            If ("Chrome.exe" Is Nothing) Then
                BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://t.me/francom28")
            Else
                BrowserCheck.StartBrowser("Chrome.exe", "https://t.me/francom28")
            End If

        Else

            h.Close()

        End If

        h.Close()

    End Sub
End Class