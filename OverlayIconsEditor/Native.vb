Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Native
    ' Code implemented from https://stackoverflow.com/questions/565405/how-to-programatically-restart-windows-explorer-process

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    Const WM_USER = &H400 ' http://msdn.microsoft.com/en-us/library/windows/desktop/ms644931(v=vs.85).aspx

    Public Shared Sub RestartExplorer()
        Try
            Dim ptr = FindWindow("Shell_TrayWnd", Nothing)
            PostMessage(ptr, WM_USER + 436, IntPtr.Zero, IntPtr.Zero)

            Do
                ptr = FindWindow("Shell_TrayWnd", Nothing)
                If ptr.ToInt32() = 0 Then Exit Do
                Thread.Sleep(250)
            Loop
        Catch ex As Exception
            Debug.WriteLine($"{ex.Message} {ex.StackTrace}")
        End Try

        Dim explorerProcessPath As String = IO.Path.Combine($"{Environment.GetEnvironmentVariable("WINDIR")}", "explorer.exe").ToLower()
        Using p As New Process()
            p.StartInfo.FileName = explorerProcessPath
            p.StartInfo.UseShellExecute = True
            p.Start()
        End Using
    End Sub
End Class
