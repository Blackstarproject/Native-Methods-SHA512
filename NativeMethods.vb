Imports System.Runtime.InteropServices

Public Class NativeMethods

    <DllImport("shell32.dll")>
    Public Shared Function SHGetKnownFolderPath(<MarshalAs(UnmanagedType.LPStruct)> rfid As Guid,
                                                dwFlags As UInteger, hToken As IntPtr, ByRef pszPath As IntPtr) As Int32

    End Function

    Public Enum ShellSpecialFolders
        Downloads
        Music
        Documents
        Pictures
        Videos
    End Enum

    Private Shared ReadOnly ShellFolderGuids As Guid() = {
        Guid.Parse("{374DE290-123F-4565-9164-39C4925E467B}"),
        Guid.Parse("{4BD8D571-6D19-48D3-BE97-422220080E43}"),
        Guid.Parse("{33E28130-4E1E-4676-835A-98395C3BC3BB}"),
        Guid.Parse("{18989B1D-99B5-455B-841C-AB7C74E4DDFC}"),
        Guid.Parse("{FDD39AD0-238F-46AF-ADB4-6C85480369C7}")}




    'ROUND 2...
    Friend Shared Function GetSpecialFolder(folder As ShellSpecialFolders) As String
        Dim fPath As IntPtr
        Dim SHFlag As UInteger = &H4000
        Dim ret As Integer = SHGetKnownFolderPath(ShellFolderGuids(folder), SHFlag, New IntPtr(0), fPath)
        If ret = 0 Then
            Return Marshal.PtrToStringUni(fPath)
        Else
            Return ""
        End If
    End Function

    Friend Shared Function GetSpecialVideoFolder() As String
        Return GetSpecialFolder(ShellSpecialFolders.Documents)
        Return GetSpecialFolder(ShellSpecialFolders.Downloads)
        Return GetSpecialFolder(ShellSpecialFolders.Music)
        Return GetSpecialFolder(ShellSpecialFolders.Pictures)
        Return GetSpecialFolder(ShellSpecialFolders.Videos)

    End Function

End Class
