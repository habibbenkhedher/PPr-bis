using System;
using System.IO;
//using System.IO.Packaging;
//using System.Xml;
//using System.Text;
//using System.Xml.Linq;
//using System.Linq;
using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;


/// <summary>
/// Klasse zum Vergleichen von XML Datein (Word,Excel...)
/// </summary>
public class XML_Auslesen
{
    //Befehl zum abrufen des aktuellen Pfades und in diesem zurück zu gehen.
    //string Kontroll_Datei = System.IO.Path.GetFullPath(@"..\..\..\");
    private static string Speicherpfad_Kontroll = @"";
    private static string Speicherpfad_Screen_Kontrol = @"";

    private static bool Existiert_Kontroll_Speicherpfad;


    /// <summary>
    /// Weist den Variablen des Objektes, den Speicherpfad der Kontroll Datei zu.
    /// </summary>
    /// <param name="speicherpfad_kontroll">Speicherpfad von der Kontroll Datei</param>
    public XML_Auslesen(string speicherpfad_kontroll, string speicherpfad_screen_kontroll = null)
    {
        if (Existiert_Datei(speicherpfad_kontroll) == false)
            Existiert_Kontroll_Speicherpfad = false;
        else
        {
            Existiert_Kontroll_Speicherpfad = true;
            //Kontrolliert ob die Screesshot Kontroll Datei existiert
            if (Existiert_Datei(speicherpfad_kontroll))
                Speicherpfad_Screen_Kontrol = speicherpfad_screen_kontroll;
            else
                Speicherpfad_Screen_Kontrol = null;
            Speicherpfad_Kontroll = speicherpfad_kontroll;
        }
    }


    /// <summary>
    /// Vergleicht den Text der im Body geschrieben wurde mit der Kontroll Datei
    /// </summary>
    /// <param name="speicherpfad_neu">Speicherpfad von der neu erstellten Datei, die mit der Kontroll Datei vergleicht werden soll</param>
    /// <returns></returns>
    public bool Vergleich_Body( string speicherpfad_neu, string speicherpfad_Screen_Neu = null)
    {
        //Überprüft ob Kontroll Speicherpfad und der neue Speicherpfad existieren
        if (Existiert_Datei(speicherpfad_neu) == false || Existiert_Kontroll_Speicherpfad == false) return false;
        else
        {
            //WordprocessingDocument ermöglicht bearbeiten und auslesen der Datei
            WordprocessingDocument wordprocessingDocument_Kontroll = WordprocessingDocument.Open(Speicherpfad_Kontroll, false);
            WordprocessingDocument wordprocessingDocument_neu = WordprocessingDocument.Open(speicherpfad_neu, false);

            // über Body lässt sich der Text im normalen Word Bereich schreiben
            Body body_Kontroll = wordprocessingDocument_Kontroll.MainDocumentPart.Document.Body;
            Body body_neu = wordprocessingDocument_neu.MainDocumentPart.Document.Body;

            //
            //Console.WriteLine(body_Kontroll.InnerText);
            //Console.WriteLine(body_neu.InnerText);

            if (body_Kontroll.InnerText == body_neu.InnerText)
            {
                return true;
            }
            //überprüft Screeshot, wenn dies gewünscht wurde nach fehlerhaften Hash vergleich
            else if (Speicherpfad_Screen_Kontrol != null && speicherpfad_Screen_Neu != null)
            {
                return Vergleich_Screenshot.Screenvergleich(speicherpfad_Screen_Neu, Speicherpfad_Screen_Kontrol);
            }
            else
            {
                Console.WriteLine("XML vergleich war Fehlerhaft und es wurde kein Screenshot vergleich gewünscht");
                return false;
            }
                // Schließt die Datei
                //wordprocessingDocument_neu.Close();
            }

    }

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
