using System;
using System.IO;
using System.Drawing;

/// <summary>
/// Klasse zum Vergleichen von Screenshots
/// </summary>
public class Vergleich_Screenshot
{
    public static string Speicherpfad_Kontroll = @"";
    public Bitmap Bitmap_Kontroll;
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
    public int Vergleich_Screen(string speicherpfad_neu)
    {
        //Überprüft ob Kontroll Speicherpfad und der neue Speicherpfad existieren
        if (Existiert_Datei(speicherpfad_neu) == false || Existiert_Kontroll_Speicherpfad == false) return 9999;
        else
        {
            bool Datei_Gleich = true;
            int AnzahlPixel_Fehler = 0;
            int AnzahlPixel_Insgesamt = 0;
            string img1_ref, img2_ref;

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
            return AnzahlPixel_Fehler;
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
}