using System;
using System.IO;
using System.Drawing;

/// <summary>
/// Klasse zum Vergleichen von Screenshots
/// </summary>
public class Vergleich_Screenshot
{
    private static string Speicherpfad_Kontroll = @"";
    private Bitmap Bitmap_Kontroll;
    private static bool Existiert_Kontroll_Speicherpfad;
    //**** Screenshot Pixelbereich einbauen



    /// <summary>
    /// Weist den Variablen des Objektes, den Speicherpfad der Kontroll Datei zu.
    /// </summary>
    /// <param name="speicherpfad_kontroll">Speicherpfad von der Kontroll Datei</param>
    public Vergleich_Screenshot(string speicherpfad_kontroll)
    {
        if (Existiert_Datei(speicherpfad_kontroll) == false)
            Existiert_Kontroll_Speicherpfad = false;
        else
        {
            Existiert_Kontroll_Speicherpfad = true;
            Speicherpfad_Kontroll = speicherpfad_kontroll;
            Bitmap_Kontroll = new Bitmap(Speicherpfad_Kontroll);
        }
    }
    /// <summary>
    /// Vergleicht 2 Screenshots mittels jeden Pixels der 2 Bitmaps (Farbe)
    /// </summary>
    /// <param name="speicherpfad_neu">Speicherpfad von der neu erstellten Datei, die mit der Kontroll Datei vergleicht werden soll</param>
    /// <returns></returns>
    public Tuple<Bitmap,int>Vergleich_Screen(string speicherpfad_neu)
    {
        //Überprüft ob Kontroll Speicherpfad und der neue Speicherpfad existieren
        if (Existiert_Datei(speicherpfad_neu) == false || Existiert_Kontroll_Speicherpfad == false) return Tuple.Create(new Bitmap(1,1), 9999); 
        else
        {
            bool Datei_Gleich = true;
            int AnzahlPixel_Fehler = 0;
            int AnzahlPixel_Insgesamt = 0;
            string img1_ref, img2_ref;
            Bitmap Bitmap_Rückgabe_Fehlerhafter_Bereich = new Bitmap(speicherpfad_neu);


            Bitmap Bitmap_neu = new Bitmap(speicherpfad_neu);
            if (Bitmap_neu.Width == Bitmap_Kontroll.Width && Bitmap_neu.Height == Bitmap_Kontroll.Height)
            {
                for (int Vergleich_Horizontal = 0; Vergleich_Horizontal < Bitmap_neu.Width; Vergleich_Horizontal++)
                {
                    for (int Vergleich_Vertikal = 0; Vergleich_Vertikal < Bitmap_neu.Height; Vergleich_Vertikal++)
                    {
                        img1_ref = Bitmap_neu.GetPixel(Vergleich_Horizontal, Vergleich_Vertikal).ToString();
                        img2_ref = Bitmap_Kontroll.GetPixel(Vergleich_Horizontal, Vergleich_Vertikal).ToString();
                        if (img1_ref != img2_ref)
                        {
                            Bitmap_Rückgabe_Fehlerhafter_Bereich.SetPixel(Vergleich_Horizontal, Vergleich_Vertikal, Color.Red);
                            AnzahlPixel_Fehler++;
                            Datei_Gleich = false;
                            break; //***break muss ausgebaut werden um später die genaue Anzahl der Pixelfehler zurückzugeben
                        }
                        AnzahlPixel_Insgesamt++;
                    }
                }
                /*
                if (Datei_Gleich == false)
                    Console.WriteLine("Sorry, Images are not same , " + AnzahlPixel_Fehler + " wrong pixels found");
                else
                    Console.WriteLine(" Images are same , " + AnzahlPixel_Insgesamt + " same pixels found and " + AnzahlPixel_Fehler + " wrong pixels found");
            }
            else
                Console.WriteLine("Es ist nicht möglich die beiden Bilder zu vergleichen");
                */
            }
            return Tuple.Create(Bitmap_Rückgabe_Fehlerhafter_Bereich, AnzahlPixel_Insgesamt);
            // this.Dispose(); //Beendet direkt das Programm

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
    /// <summary>
    /// Screenshot Vergleich, wenn Hash oder XML Fehlerhaft sind
    /// </summary>
    /// <param name="speicherpfad_Screen_Neu">Der Pfad des neuen Screenshot</param>
    /// <param name="Speicherpfad_Screen_Kontrol">Der Pfad des kontrol Screenshot</param>
    /// <returns></returns>
    public static bool Screenvergleich(string speicherpfad_Screen_Neu, string Speicherpfad_Screen_Kontrol)
    {
        if (Existiert_Datei(speicherpfad_Screen_Neu))
        {
            Console.WriteLine("Hashcode Vergleich war Fehlerhaft, überprüfe nun Screenshot");
            Vergleich_Screenshot vergleich_Screenshot = new Vergleich_Screenshot(Speicherpfad_Screen_Kontrol);
            Tuple<Bitmap,int> Screen_Rueckgabe = vergleich_Screenshot.Vergleich_Screen(speicherpfad_Screen_Neu);

            if (Screen_Rueckgabe.Item2 == 0)
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
}