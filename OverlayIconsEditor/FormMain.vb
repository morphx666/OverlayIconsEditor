Imports System.Text
Imports Microsoft.Win32

Public Class FormMain
    Private Const overlaysKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers"
    Private maxSupportedOverlays As Integer = If(Environment.Is64BitOperatingSystem, 11, 15) - 1 ' Really Microsoft? Really? Why???!!!

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverlayIcons()

        AddHandler ListViewOverlayIcons.SelectedIndexChanged, Sub() UpdateUI()
        AddHandler ButtonUp.Click, Sub() MoveSelectedItems(-1)
        AddHandler ButtonDown.Click, Sub() MoveSelectedItems(1)
        AddHandler ButtonApply.Click, Sub() ApplyNewOverlayIconsOrder()
    End Sub

    Private Sub LoadOverlayIcons()
        ImageListIcons.Images.Clear()

        With ListViewOverlayIcons
            .BeginUpdate()

            .Items.Clear()

            Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(overlaysKey)
                For Each sk As String In rk.GetSubKeyNames()
                    If sk <> "EnhancedStorageShell" Then
                        'GetIcon(sk)
                        .Items.Add(sk.Trim()).SubItems.Add(GetDescription(sk)).Tag = sk
                    End If
                Next
            End Using

            .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            .EndUpdate()
        End With

        UpdateUI()
    End Sub

    Private Function GetDescription(subKey As String) As String
        Dim description As String = ""

        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey($"{overlaysKey}\{subKey}")
            Dim classCLSID As String = rk.GetValue("")
            If classCLSID.StartsWith("{") Then
                Using srk As RegistryKey = Registry.ClassesRoot.OpenSubKey($"CLSID\{classCLSID}")
                    If srk.GetValue("") Is Nothing Then
                        Using srk2 As RegistryKey = Registry.LocalMachine.OpenSubKey($"SOFTWARE\Classes\CLSID\{classCLSID}\InProcServer32")
                            description = If(srk2.GetValue(""), "")
                        End Using
                    Else
                        description = If(srk.GetValue(""), "")
                    End If
                End Using
            End If
        End Using

        Return description
    End Function

    Private Function GetIcon(subKey As String) As Bitmap
        Dim bmp As Bitmap = Nothing

        ' TODO: Can we call IShellIconOverlayIdentifier::GetOverlayInfo over the InProcServer32 to get the icon information? 
        ' https://blogs.msdn.microsoft.com/jonathanswift/2006/10/03/dynamically-calling-an-unmanaged-dll-from-net-c/

        Return bmp
    End Function

    Private Sub UpdateUI()
        ButtonUp.Enabled = ListViewOverlayIcons.SelectedItems.Count > 0
        ButtonDown.Enabled = ButtonUp.Enabled

        With ListViewOverlayIcons
            .BeginUpdate()

            For i As Integer = 0 To .Items.Count - 1
                If i < maxSupportedOverlays Then
                    .Items(i).Font = New Font(.Font, FontStyle.Bold)
                Else
                    .Items(i).Font = New Font(.Font, FontStyle.Regular)
                End If
            Next

            .EndUpdate()
        End With
    End Sub

    Private Sub MoveSelectedItems(offset As Integer)
        With ListViewOverlayIcons
            Dim index As Integer = .SelectedItems(0).Index

            For i As Integer = 0 To .SelectedItems.Count - 1
                If .SelectedItems(i).Index + offset < 0 OrElse .SelectedItems(i).Index + offset >= .Items.Count Then Exit Sub
            Next

            .BeginUpdate()

            Dim moveItems As New List(Of ListViewItem)
            For i As Integer = 0 To .SelectedItems.Count - 1
                moveItems.Add(CType(.SelectedItems(0).Clone, ListViewItem))
                .Items.RemoveAt(index)
            Next

            For i As Integer = 0 To moveItems.Count - 1
                With .Items.Insert(index + offset, moveItems(i))
                    .Selected = True
                    If i = 0 Then .EnsureVisible()
                End With
            Next

            .EndUpdate()
        End With

        UpdateUI()
    End Sub

    Private Sub ApplyNewOverlayIconsOrder()
        If SaveRegistryBackup() Then
            Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(overlaysKey, True)
                With ListViewOverlayIcons
                    Dim c As Integer = Math.Min(maxSupportedOverlays, .Items.Count)
                    For i As Integer = 0 To .Items.Count - 1
                        For Each sk As String In rk.GetSubKeyNames()
                            If sk.Trim() = .Items(i).Text Then
                                Try
                                    If i < c Then
                                        rk.RenameSubKey(sk, $"{New String(" "c, c - i)}{ .Items(i).Text}")
                                        Debug.WriteLine($"{ .Items(i).Tag} -> {New String(" "c, c - i)}{ .Items(i).Text}")
                                    Else
                                        rk.RenameSubKey(sk, $"{ .Items(i).Text}")
                                        Debug.WriteLine($"{ .Items(i).Tag} -> { .Items(i).Text}")
                                    End If
                                Catch ex As Exception
                                    MsgBox($"An error has occurred while trying to rename the key '{sk}': {ex.Message}")
                                End Try
                            End If
                        Next
                    Next
                End With
            End Using

            If MsgBox("Do you want to restart explorer to apply these changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Native.RestartExplorer()
            End If
        End If

        LoadOverlayIcons()
    End Sub

    Private Function SaveRegistryBackup() As Boolean
        Dim sb As New StringBuilder()
        Dim buildKeyLine = Function(subKey As String) $"[HKEY_LOCAL_MACHINE\{overlaysKey}{If(subKey = "", "", $"\{subKey}")}]"

        sb.AppendLine("Windows Registry Editor Version 5.00")
        sb.AppendLine()

        sb.AppendLine(buildKeyLine(""))

        Using rk As RegistryKey = Registry.LocalMachine.OpenSubKey(overlaysKey)
            For Each sk As String In rk.GetSubKeyNames()
                sb.AppendLine()
                sb.AppendLine(buildKeyLine(sk))

                Using srk As RegistryKey = Registry.LocalMachine.OpenSubKey($"{overlaysKey}\{sk}")
                    sb.AppendLine($"@=""{srk.GetValue("")}""")
                End Using
            Next
        End Using

        Using dlg As New SaveFileDialog()
            dlg.OverwritePrompt = True
            dlg.FileName = $"{Now.Year:0000}{Now.Month:00}{Now.Day:00}{Now.Hour:00}{Now.Minute:00}{Now.Second:00}-ShellIconOverlayIdentifiers"
            dlg.DefaultExt = "reg"
            dlg.Filter = "Registration Files (*.reg)|*.reg"

            Do
                Select Case dlg.ShowDialog(Me)
                    Case DialogResult.OK
                        Try
                            IO.File.WriteAllText(dlg.FileName, sb.ToString())
                            Return True
                        Catch ex As Exception
                            MsgBox($"Unable to create backup file: {ex.Message}")
                        End Try
                    Case Else
                        Return False
                End Select
            Loop
        End Using
    End Function
End Class
