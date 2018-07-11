Imports System.Runtime.CompilerServices
Imports Microsoft.Win32

Public Module RegistryUtilities
    ' Based on the code by drdandle: https://www.codeproject.com/Articles/16343/Copy-and-Rename-Registry-Keys

    <Extension()>
    Public Sub RenameSubKey(parentKey As RegistryKey, subKeyName As String, newSubKeyName As String)
        If subKeyName <> newSubKeyName Then
            CopySubKey(parentKey, subKeyName, newSubKeyName)
            parentKey.DeleteSubKeyTree(subKeyName)
        End If
    End Sub

    Private Sub CopySubKey(parentKey As RegistryKey, keyNameToCopy As String, newKeyName As String)
        Dim destinationKey As RegistryKey = parentKey.CreateSubKey(newKeyName)
        Dim sourceKey As RegistryKey = parentKey.OpenSubKey(keyNameToCopy)

        RecurseCopySubKey(sourceKey, destinationKey)
    End Sub

    Private Sub RecurseCopySubKey(sourceKey As RegistryKey, destinationKey As RegistryKey)
        For Each valueName As String In sourceKey.GetValueNames()
            Dim objValue As Object = sourceKey.GetValue(valueName)
            Dim valKind As RegistryValueKind = sourceKey.GetValueKind(valueName)
            destinationKey.SetValue(valueName, objValue, valKind)
        Next

        For Each sourceSubKeyName As String In sourceKey.GetSubKeyNames()
            Dim sourceSubKey As RegistryKey = sourceKey.OpenSubKey(sourceSubKeyName)
            Dim destSubKey As RegistryKey = destinationKey.CreateSubKey(sourceSubKeyName)
            RecurseCopySubKey(sourceSubKey, destSubKey)
        Next
    End Sub
End Module
