using System;
using System.IO;
using System.IO.Packaging;
//using System.Xml;
//using System.Text;
//using System.Xml.Linq;
//using System.Linq;
using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;

public class XML_Auslesen
{
    private static string Speicherort1 = @"";
    private static string Speicherort2 = @"";
    public XML_Auslesen()
    {
        OpenAndAddTextToWordDocument(Speicherort1, "test");
        OpenAndAddTextToWordDocument(Speicherort2, "test");
    }
    
    public static void OpenAndAddTextToWordDocument(string filepath, string text)
    {
        // Variable wordprocessingDocument beinhaltet die Datei, die ausgelesen wird
        WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(filepath, true);

        // über body lässt sich der Text im normalen Word Bereich schreiben
        Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

        // Erstellt die Variable run, welche es ermöglicht Den Body zu beschreiben
        Paragraph para = body.AppendChild(new Paragraph());
        Run run = para.AppendChild(new Run());

        //Fügt der Datei einen Text hinzu
        //run.AppendChild(new Text(text));

        // Schreibt den Inhalt des Bodys aus
        Console.WriteLine(body.InnerText);
        // Schließt die Datei
        wordprocessingDocument.Close();
    }
    


}
