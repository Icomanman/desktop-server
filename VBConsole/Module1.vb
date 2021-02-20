Imports OpenSTAADUI
Module Module1

    Sub Main()
        Dim OSt As Object
        Dim path As String

        path = "C:\Users\GiulianoDiEnrico\Documents\010 Swan House\Outgoing\B Calcs\STAAD Models\SH-011.std"
        'OSt = CreateObject("StaadPro.OpenSTAAD")
        OSt = GetObject(path, "StaadPro.OpenSTAAD")
        Console.ReadKey()

        OSt.Quit()

        Console.WriteLine("tawid")

        OSt = Nothing
    End Sub

End Module
