Imports OpenSTAADUI
Public Module Module1

    Public Sub Main()
        Dim OSt As Object
        Dim path As String
        'Dim id As String
        'Dim procID As String

        path = "C:\Users\GiulianoDiEnrico\Documents\010 Swan House\Outgoing\B Calcs\STAAD Models\SH-011.std"
        OSt = CreateObject("StaadPro.OpenSTAAD")
        'OSt = GetObject(, "StaadPro.OpenSTAAD")

        'id = OSt.GetBaseUnit()
        'procID = OSt.GetProcessId()

        OSt.OpenSTAADFile(path)
        'Console.WriteLine("tawid: " + id + " " + procID)
        Console.ReadLine()
        Console.ReadKey()

        OSt.Quit()

        OSt = Nothing
    End Sub

    Public Function GetStaad(ByVal fileName As String, ByVal open As Boolean)
        Dim OSt As Object
        Dim OpStd As Object

        OSt = CreateObject("StaadPro.OpenSTAAD")
        OSt.OpenSTAADFile(fileName)

        If open = False Then
            OpStd = GetObject(, "StaadPro.OpenSTAAD")
            OpStd.Quit()
        End If


        'Console.ReadKey()
        'OSt.Quit()
        'OSt = Nothing

        Return OSt

    End Function

End Module
