//using System;
using System.Security.Cryptography; //Erstellung von Hashcodes z.B. MB5
using System.IO; //Filestream und File erstellung
//using System.Text; //Wird benötigt für UTF8Encoding //Wird nur für die Erstellung von Datein benötigt
using System.Linq; //Wird benötigt für Sequence
public class Hashcode_Vergleich
{
    public static string Speicherpfad_Kontroll = @"";
    public static byte[] Byte_Kontroll;

    public Hashcode_Vergleich(string speicherpfad_kontroll)
    {
        Speicherpfad_Kontroll = speicherpfad_kontroll;
        var md5 = MD5.Create();
        Byte_Kontroll = md5.ComputeHash(File.OpenRead(Speicherpfad_Kontroll));
        //Console.WriteLine(Byte_Kontroll);
    }

    public bool Vergleich_Hash(string speicherpfad_neu)
    {

        var md5 = MD5.Create();
        byte[] Byte_neu = md5.ComputeHash(File.OpenRead(speicherpfad_neu));
        //Console.WriteLine(Byte_Kontroll);
        //SequenceEqual vergleich 2 Byte Arrays
        if (Byte_Kontroll.SequenceEqual(Byte_neu))
            return true;
        else
            return false;
    }
    public static bool Existiert_Datei(string speicherort)
    {
        if (File.Exists(speicherort))
            return true;
        else
            return false;
    }
}


