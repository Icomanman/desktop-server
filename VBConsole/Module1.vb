Imports OpenSTAADUI
Module Module1

    Sub Main()
        Dim OSt As Object
        Dim path As String
        Dim id As String

        path = "C:\Users\GiulianoDiEnrico\Documents\010 Swan House\Outgoing\B Calcs\STAAD Models\SH-011.std"
        'OSt = CreateObject("StaadPro.OpenSTAAD")
        OSt = GetObject(, "StaadPro.OpenSTAAD")

        id = OSt.GetBaseUnit()

        Console.WriteLine("tawid: " + CStr(id))
        Console.ReadKey()

        OSt = Nothing
    End Sub

End Module
