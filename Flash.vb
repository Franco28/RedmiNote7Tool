Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Flash

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim var As String

        var = ComboBox1.Text

        If (var = "flash_all" = True) Then

            ProgressBar1.Value = 0
            Counter = 0
            myToken = New CancellationTokenSource
            Await startProgressBar(myToken)

            MsgBox(var, MessageBoxIcon.Information)
            Dim psi As New ProcessStartInfo("flash_all.bat")
            psi.RedirectStandardError = True
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = False
            psi.WindowStyle = ProcessWindowStyle.Hidden
            psi.UseShellExecute = False
            Dim process As Process = Process.Start(psi)
        ElseIf (var = "flash_all_except_storage" = True) Then
            MsgBox(var, MessageBoxIcon.Information)
            Dim psi As New ProcessStartInfo("C:\adb\.settings\xiaomiglobalfastboot\MI\flash_all_except_storage.bat")
            psi.RedirectStandardError = True
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = False
            psi.WindowStyle = ProcessWindowStyle.Hidden
            psi.UseShellExecute = False
            Dim process As Process = Process.Start(psi)
        ElseIf (var = "flash_all_lock" = True) Then
            MsgBox(var, MessageBoxIcon.Information)
            Dim psi As New ProcessStartInfo("C:\adb\.settings\xiaomiglobalfastboot\MI\flash_all_lock.bat")
            psi.RedirectStandardError = True
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = False
            psi.WindowStyle = ProcessWindowStyle.Hidden
            psi.UseShellExecute = False
            Dim process As Process = Process.Start(psi)

        Else

            MsgBox("Didn´t select any option", MessageBoxIcon.Warning)

            If Not myToken Is Nothing Then
                myToken.Cancel() ' We tell our token to cancel
            End If

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Using frm = New OpenFolderDialog()

            If frm.ShowDialog(Me) = DialogResult.OK Then

                TextBox1.Text = frm.Folder

                ChDir(frm.Folder)

                Dim flash_all As String
                flash_all = "flash_all.bat"

                If Not File.Exists(flash_all) Then
                    MsgBox("Can´t find flash_all.bat", MessageBoxIcon.Warning)
                Else
                    ComboBox1.Items.Add("flash_all")
                    RadioButton1.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(0)
                End If

                Dim flash_all_except_storage As String
                flash_all_except_storage = "flash_all_except_storage.bat"

                If Not File.Exists(flash_all_except_storage) Then
                    MsgBox("Can´t find flash_all_except_storage.bat", MessageBoxIcon.Warning)
                Else
                    ComboBox1.Items.Add("flash_all_except_storage")
                    RadioButton2.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(1)
                End If

                Dim flash_all_lock As String
                flash_all_lock = "flash_all_lock.bat"

                If Not File.Exists(flash_all_lock) Then
                    MsgBox("Can´t find flash_all_lock.bat", MessageBoxIcon.Warning)
                Else
                    ComboBox1.Items.Add("flash_all_lock")
                    RadioButton3.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                End If

                If Not File.Exists(flash_all_except_storage) Then
                    MsgBox("Can´t find flash_all_except_storage.bat", MessageBoxIcon.Warning)
                    RadioButton2.Checked = False
                Else
                    RadioButton2.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                End If

                If Not File.Exists(flash_all_lock) Then
                    MsgBox("Can´t find flash_all_lock.bat", MessageBoxIcon.Warning)
                    RadioButton3.Checked = False
                Else
                    RadioButton3.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                End If

            End If

        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
    End Sub



    ' This is specific to the type of async function we're doing. Yours may be different.
    Dim MyWebClient As WebClient = New WebClient
    ' This is used to notify the async function that we want to cancel it.
    Dim myToken As CancellationTokenSource
    ' We use this as the vehicle for reporting progress back to our GUI thread
    Dim myProgress As Progress(Of Integer)
    ' This is a variable that we use to track our progress (specific to this example)
    Dim Counter As Integer = 0

    Public Async Function startProgressBar(sender As CancellationTokenSource) As Task

        ' We have to create an event handler for the function we use to report progress
        Dim progressTarget As Action(Of Integer)

        ' We assign the handler to our specific function (see below)
        progressTarget = AddressOf ReportProgress

        ' When we initialize our progress reporter, we pass our handler to it
        myProgress = New Progress(Of Integer)(progressTarget)

        For I = 0 To 9
            ' We are really not doing anything with the results of this function, just returning it)
            TextBox1.Text = Now.ToLongTimeString
            If sender.IsCancellationRequested = True Then
                Exit For
            End If

            ' We don't do anything with this string, just so we can run our async function
            Dim myString As String = Await RetrieveString(myProgress)
        Next
    End Function
    Public Async Function RetrieveString(ByVal myProgress As IProgress(Of Integer)) As Task(Of String)
        Dim myString As String = ""

        'If we have a valid progress object, report our progress using it
        If Not myProgress Is Nothing Then
            Counter = Counter + 10
            myProgress.Report(Counter)
        End If

        ' This is a throwaway function - just something that uses async
        myString = Await MyWebClient.DownloadStringTaskAsync("https://google.com")

        ' We are really not doing anything with the results of this function, just returning it
        Return myString

    End Function

    Private Sub ReportProgress(ByVal sender As Integer)
        TextBox1.Text = "Step Number: " & sender.ToString
        ProgressBar1.Value = sender
    End Sub

    Private Sub Flash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using frm = New OpenFolderDialog()

            If frm.ShowDialog(Me) = DialogResult.OK Then

                TextBox1.Text = frm.Folder

                ChDir(frm.Folder)

                Dim flash_all As String
                flash_all = "flash_all.bat"

                If Not File.Exists(flash_all) Then
                    MsgBox("Can´t find flash_all.bat", MessageBoxIcon.Warning)
                Else
                    ComboBox1.Items.Add("flash_all")
                    RadioButton1.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(0)
                End If

                Dim flash_all_except_storage As String
                flash_all_except_storage = "flash_all_except_storage.bat"

                If Not File.Exists(flash_all_except_storage) Then
                    MsgBox("Can´t find flash_all_except_storage.bat", MessageBoxIcon.Warning)
                Else
                    ComboBox1.Items.Add("flash_all_except_storage")
                    RadioButton2.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(1)
                End If

                Dim flash_all_lock As String
                flash_all_lock = "flash_all_lock.bat"

                If Not File.Exists(flash_all_lock) Then
                    MsgBox("Can´t find flash_all_lock.bat", MessageBoxIcon.Warning)
                Else
                    ComboBox1.Items.Add("flash_all_lock")
                    RadioButton3.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                End If

                If Not File.Exists(flash_all_except_storage) Then
                    MsgBox("Can´t find flash_all_except_storage.bat", MessageBoxIcon.Warning)
                    RadioButton2.Checked = False
                Else
                    RadioButton2.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                End If

                If Not File.Exists(flash_all_lock) Then
                    MsgBox("Can´t find flash_all_lock.bat", MessageBoxIcon.Warning)
                    RadioButton3.Checked = False
                Else
                    RadioButton3.Checked = True
                    ComboBox1.SelectedItem = ComboBox1.Items(2)
                End If

            End If

        End Using
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.SelectedItem = ComboBox1.Items(0)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.SelectedItem = ComboBox1.Items(1)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        ComboBox1.SelectedItem = ComboBox1.Items(2)
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub
End Class