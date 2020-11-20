using System;
using System.Security.Cryptography; //Erstellung von Hashcodes z.B. MB5
using System.IO; //Filestream und File erstellung
using System.Text; //Wird benötigt für UTF8Encoding //Wird nur für die Erstellung von Datein benötigt
using System.Linq; //Wird benötigt für Sequence
public class Hashcode_Vergleich
{
    public static string speicherort = @"";
    public Hashcode_Vergleich()
    {
        byte[] Nummer1;
        byte[] Nummer2;

        //Create File
        using (FileStream datei = File.Create(speicherort))
        {
            byte[] info = new UTF8Encoding(true).GetBytes("32");
            // Add some information to the file.
            datei.Write(info, 0, info.Length);
        }

        //Nummer1 wird beschrieben
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(speicherort))
            {
                Nummer1 = md5.ComputeHash(stream);
            }
        }
        //Create File
        using (FileStream datei = File.Create(speicherort))
        {
            byte[] info = new UTF8Encoding(true).GetBytes("32");
            // Add some information to the file.
            datei.Write(info, 0, info.Length);
        }

        //Nummer2 wird beschrieben
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(speicherort))
            {
                Nummer2 = md5.ComputeHash(stream);
            }
        }
        //SequenceEqual vergleich 2 Byte Arrays
        if (Nummer1.SequenceEqual(Nummer2))
            Console.WriteLine("Gleich");
        else
            Console.WriteLine("Nicht Gleich");
    }
    public static bool Existiert_Datei(string speicherort)
    {
        if (File.Exists(speicherort))
            return true;
        else
            return false;
    }

}
