using System;
using System.Security.Cryptography; //Erstellung von Hashcodes z.B. MB5
using System.IO; //Filestream und File erstellung
//using System.Text; //Wird benötigt für UTF8Encoding //Wird nur für die Erstellung von Datein benötigt
using System.Linq; //Wird benötigt für Sequence

/// <summary>
/// Klassen zum schnellen Vergleichen von Dateien mittels Hash.
/// </summary>
public class Hashcode_Vergleich
{
    public static string Speicherpfad_Kontroll = @"";
    public static string Speicherpfad_Screen_Kontrol = @"";
    public static byte[] Byte_Kontroll;

    private bool Existiert_Kontroll_Speicherpfad;


    /// <summary>
    /// Weist den Variablen des Objektes, den Speicherpfad der Kontroll Datei zu und überprüft ob der Pfad existiert.
    /// </summary>
    /// <param name="speicherpfad_kontroll">Speicherpfad von der Kontroll Datei</param>
    public Hashcode_Vergleich(string speicherpfad_kontroll, string speicherpfad_screen_kontroll = null)
    {
        if (Existiert_Datei(speicherpfad_kontroll) == false)
        {
            Existiert_Kontroll_Speicherpfad = false;
        }
        else
        {
            Existiert_Kontroll_Speicherpfad = true;
            //Kontrolliert ob die Screesshot Kontroll Datei existiert
            if (Existiert_Datei(speicherpfad_kontroll))
                Speicherpfad_Screen_Kontrol = speicherpfad_screen_kontroll;
            else
                Speicherpfad_Screen_Kontrol = null;

            Speicherpfad_Kontroll = speicherpfad_kontroll;
            var md5 = MD5.Create();
            Byte_Kontroll = md5.ComputeHash(File.OpenRead(Speicherpfad_Kontroll));
        }
        //Console.WriteLine(Byte_Kontroll);
    }

    /// <summary>
    /// Vergleicht den angegebenen Hash mit der Kontroll Datei (Konstruktor)
    /// </summary>
    /// <param name="speicherpfad_neu">Speicherpfad von der neu erstellten Datei, die mit der Kontroll Datei vergleicht werden soll</param>
    /// <returns></returns>
    public bool Vergleich_Hash(string speicherpfad_neu, string speicherpfad_Screen_Neu = null)
    {
        //Überprüft ob Kontroll Speicherpfad und der neue Speicherpfad existieren
        if (Existiert_Datei(speicherpfad_neu) == false || Existiert_Kontroll_Speicherpfad == false) return false;
        else
        {
            var md5 = MD5.Create();
            byte[] Byte_neu = md5.ComputeHash(File.OpenRead(speicherpfad_neu));
            if (Byte_Kontroll.SequenceEqual(Byte_neu))
            {
                Console.WriteLine("Hash vergleich war erfolgreich");
                return true;
            }
            //überprüft Screeshot, wenn dies gewünscht wurde nach fehlerhaften Hash vergleich
            else if (Speicherpfad_Screen_Kontrol != null && speicherpfad_Screen_Neu != null)
            {
                if (Existiert_Datei(speicherpfad_Screen_Neu))
                {
                    Console.WriteLine("Hashcode Vergleich war Fehlerhaft, überprüfe nun Screenshot");
                    Vergleich_Screenshot vergleich_Screenshot = new Vergleich_Screenshot(Speicherpfad_Screen_Kontrol);
                    if (vergleich_Screenshot.Vergleich_Screen(speicherpfad_Screen_Neu) == 0)
                    {
                        Console.WriteLine("Screenshot war gleich");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Screenshot war ungleich");
                        return false;
                    }
                }
                Console.WriteLine("Speicherpfad_Screen_Neu war Fehlerhaft");
                return false;
            }
            else
            {
                Console.WriteLine("Hashvergleich war Fehlerhaft und es wurde kein Screenshot vergleich gewünscht");
                return false;
            }
        }
    }

    /// <summary>
    /// Überprüft ob die Datei am angegebenen Speicherpfad existiert
    /// </summary>
    /// <param name="speicherort">Speicherpfad einer beliebigen Datei</param>
    /// <returns></returns>
    private static bool Existiert_Datei(string speicherort)
    {
        if (File.Exists(speicherort))
            return true;
        else
        {
            Console.WriteLine("Speicherpfad nicht gefunden: " + speicherort);
            return false;
        }
    }
}


