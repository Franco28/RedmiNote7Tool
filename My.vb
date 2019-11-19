Imports System.Runtime.InteropServices
Namespace My
    <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
    Partial Friend Class _Dialogs
        Public Function QuestionDialog(ByVal Text As String, ByVal Title As String) As Boolean
            MsgDialog.Patch(New String() {"A Yep", "A No"})
            Return Question(Text, Title)
        End Function
        Public Function QuestionDialog(ByVal Text As String, ByVal Title As String, ByVal YesText As String, ByVal NoText As String) As Boolean
            MsgDialog.Patch(New String() {YesText, NoText})
            Return Question(Text, Title)
        End Function
        Public Function Question(ByVal Text As String, ByVal Title As String) As Boolean
            Return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        ''' <summary>
        ''' Ask question
        ''' </summary>
        ''' <param name="Text">Question to ask</param>
        ''' <param name="Title">Text for dialog caption</param>
        ''' <param name="DefaultButton">Which button is the default</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Question(ByVal Text As String, ByVal Title As String, ByVal DefaultButton As MsgBoxResult) As Boolean
            Dim db As MessageBoxDefaultButton
            If DefaultButton = MsgBoxResult.No Then
                db = MessageBoxDefaultButton.Button2
            End If
            Return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, db) = MsgBoxResult.Yes)
        End Function
        Private Class MsgDialog
            Private Shared mLabels() As String    '' Desired new labels
            Private Shared mLabelIndex As Integer '' Next caption to update
            Public Shared Sub Patch(ByVal labels() As String)
                mLabels = labels
                Application.OpenForms(0).BeginInvoke(New FindWindowDelegate(AddressOf FindMsgBox), GetCurrentThreadId())
            End Sub
            Private Shared Sub FindMsgBox(ByVal tid As Integer)
                EnumThreadWindows(tid, AddressOf EnumWindow, IntPtr.Zero)
            End Sub
            Private Shared Function EnumWindow(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
                ''--- Is this the message box?
                Dim sb As New System.Text.StringBuilder(256)
                GetClassName(hWnd, sb, sb.Capacity)
                If sb.ToString() <> "#32770" Then
                    Return True
                End If
                ''--- Got it, now find the buttons
                mLabelIndex = 0
                EnumChildWindows(hWnd, AddressOf FindButtons, IntPtr.Zero)
                Return False
            End Function
            Private Shared Function FindButtons(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
                Dim sb As New System.Text.StringBuilder(256)
                GetClassName(hWnd, sb, sb.Capacity)
                If sb.ToString() = "Button" And mLabelIndex <= UBound(mLabels) Then
                    SetWindowText(hWnd, mLabels(mLabelIndex))
                    mLabelIndex += 1
                End If
                Return True
            End Function
            ''--- P/Invoke declarations
            Private Delegate Sub FindWindowDelegate(ByVal tid As Integer)
            Private Delegate Function EnumWindowDelegate(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
            Private Declare Auto Function EnumThreadWindows Lib "user32.dll" (ByVal tid As Integer, ByVal callback As EnumWindowDelegate, ByVal lp As IntPtr) As Boolean
            Private Declare Auto Function EnumChildWindows Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal callback As EnumWindowDelegate, ByVal lp As IntPtr) As Boolean
            Private Declare Auto Function GetClassName Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal name As System.Text.StringBuilder, ByVal maxlen As Integer) As Integer
            Private Declare Auto Function GetCurrentThreadId Lib "kernel32.dll" () As Integer
            Private Declare Auto Function SetWindowText Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal text As String) As Boolean
        End Class
    End Class
    <Global.Microsoft.VisualBasic.HideModuleName()>
    Friend Module KSG_Dialogs
        Private instance As New ThreadSafeObjectProvider(Of _Dialogs)
        ReadOnly Property Dialogs() As _Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace