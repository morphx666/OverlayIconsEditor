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

    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Shared Function ExtractIconEx(szFileName As String, nIconIndex As Integer, phiconLarge() As IntPtr, phiconSmall() As IntPtr, nIcons As UInteger) As UInteger
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Private Structure SHFILEINFO
        Public hIcon As IntPtr ' : icon
        Public iIcon As Integer ' : icondex
        Public dwAttributes As Integer ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
    End Structure

    Private Declare Ansi Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As IntPtr
    Private Const SHGFI_ICON As Integer = &H100
    Private Const SHGFI_SMALLICON As Integer = &H1
    Private Const SHGFI_LARGEICON As Integer = &H0 ' Large icon

    Private ReadOnly CLSID_ShellLink As Guid = New Guid("00021401-0000-0000-C000-000000000046")
    Private Const INFOTIPSIZE As Integer = 1024

    Private Const WM_USER = &H400

    Public Shared Sub RestartExplorer()
        Try
            Do
                Dim ptr As IntPtr = FindWindow("Shell_TrayWnd", Nothing)
                PostMessage(ptr, WM_USER + 436, IntPtr.Zero, IntPtr.Zero)
                Thread.Sleep(500)

                ptr = FindWindow("Shell_TrayWnd", Nothing)
                If ptr.ToInt32() = 0 Then Exit Do
                Thread.Sleep(1000)
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

    Public Shared Function GetIconsFromFile(fileName As String, Optional extractSmallIcon As Boolean = True, Optional extractDefault As Boolean = False) As List(Of Icon)
        Dim hImgSmall() As IntPtr = {IntPtr.Zero}
        Dim hImgLarge() As IntPtr = {IntPtr.Zero}
        Dim extractedIcons As New List(Of Icon)

        If IO.File.Exists(fileName) OrElse IO.Directory.Exists(fileName) Then
            Dim r As UInteger = ExtractIconEx(fileName, -1, Nothing, Nothing, 0)
            If r <> 0 AndAlso Not extractDefault Then
                ReDim hImgLarge(r - 1)
                ReDim hImgSmall(r - 1)
                Dim k As UInteger = ExtractIconEx(fileName, 0, hImgLarge, hImgSmall, r)
                For i As Integer = 0 To r - 1
                    If extractSmallIcon Then
                        extractedIcons.Add(Icon.FromHandle(hImgSmall(i)).Clone())

                    Else
                        extractedIcons.Add(Icon.FromHandle(hImgLarge(i)).Clone())
                    End If
                    DestroyIcon(hImgLarge(i))
                    DestroyIcon(hImgSmall(i))
                Next
            Else
                Dim shinfo As SHFILEINFO = New SHFILEINFO With {
                    .szDisplayName = New String(Chr(0), 260),
                    .szTypeName = New String(Chr(0), 80),
                    .iIcon = 0
                }

                If extractSmallIcon Then
                    hImgSmall(0) = SHGetFileInfo(fileName, 0, shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON Or SHGFI_SMALLICON)
                Else
                    hImgLarge(0) = SHGetFileInfo(fileName, 0, shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON Or SHGFI_LARGEICON)
                End If
                If shinfo.hIcon.ToInt32() <> 0 Then
                    extractedIcons.Add(Icon.FromHandle(shinfo.hIcon).Clone())
                    DestroyIcon(shinfo.hIcon)
                End If
            End If
        End If

        Return extractedIcons
    End Function
End Class
