//using System;
//using System.IO;
//using System.IO.Packaging;
//using System.Xml;
//using System.Text;
//using System.Xml.Linq;
//using System.Linq;
using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;

public class XML_Auslesen
{
    //Befehl zum abrufen des aktuellen Pfades und in diesem zurück zu gehen.
    //string Kontroll_Datei = System.IO.Path.GetFullPath(@"..\..\..\");
    private static string Speicherpfad_Kontroll = @"";
    public XML_Auslesen(string speicherpfad_kontroll)
    {
        Speicherpfad_Kontroll = speicherpfad_kontroll;
    }
 
    public bool Vergleich_Body( string speicherpfad_neu)
    {
        //WordprocessingDocument ermöglicht bearbeiten und auslesen der Datei
        WordprocessingDocument wordprocessingDocument_Kontroll = WordprocessingDocument.Open(Speicherpfad_Kontroll, false);
        WordprocessingDocument wordprocessingDocument_neu= WordprocessingDocument.Open(speicherpfad_neu, false);

        // über Body lässt sich der Text im normalen Word Bereich schreiben
        Body body_Kontroll = wordprocessingDocument_Kontroll.MainDocumentPart.Document.Body;
        Body body_neu = wordprocessingDocument_neu.MainDocumentPart.Document.Body;

        //
        //Console.WriteLine(body_Kontroll.InnerText);
        //Console.WriteLine(body_neu.InnerText);

        if(body_Kontroll.InnerText == body_neu.InnerText)
        {
            return true;
        }
        else
        {
            return false;
        }
        // Schließt die Datei
        //wordprocessingDocument_neu.Close();

    }




}
