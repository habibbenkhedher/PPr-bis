using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tester_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHashcode_ohne_Screen()
        {
            string Ordnerpfad = @"C:\Users\Copperbottom\Desktop\Testszenarien\TXT_Text\";
            string Original = "Original";
            string Datei_Gleich = "Datei_Gleich";
            string neu = "Abweichung2";
            string neu2 = "Abweichung1";
            string Dateityp = ".txt";

            


            //Weist der Variable "vergleich" die Originale Vergleichs Datei zu
            Hashcode_Vergleich vergleich = new Hashcode_Vergleich(Ordnerpfad + Original + Dateityp);


            if (vergleich.Vergleich_Hash(Ordnerpfad + Datei_Gleich + Dateityp) == true)
            {
                Console.WriteLine(Datei_Gleich + "  gleich");
            }
            else
            {
                Console.WriteLine(Datei_Gleich + "  ungleich");
            }
            //Vergleicht den Text vom Original und der Datei "neu"
            if (vergleich.Vergleich_Hash(Ordnerpfad + neu + Dateityp) == true)
            {
                Console.WriteLine(neu + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu + "  ungleich");
            }
            //Vergleicht den Text vom Original und der Datei "neu2"
            if (vergleich.Vergleich_Hash(Ordnerpfad + neu2 + Dateityp) == true)
            {
                Console.WriteLine(neu2 + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu2 + "  ungleich");
            }
        }
        [TestMethod]
        public void TestHashcode_mit_Screen()
        {
            string Ordnerpfad = @"C:\Users\Copperbottom\Desktop\Testszenarien\TXT_Text\";
            string Original = "Original";
            string Datei_Gleich = "Datei_Gleich";
            string neu = "Abweichung2";
            string neu2 = "Abweichung1";
            string Dateityp = ".txt";
            string Dateityp2 = ".png";




            //Weist der Variable "vergleich" die Originale Vergleichs Datei zu
            Hashcode_Vergleich vergleich = new Hashcode_Vergleich(Ordnerpfad + Original + Dateityp, Ordnerpfad + Original + Dateityp2);


            if (vergleich.Vergleich_Hash(Ordnerpfad + Datei_Gleich + Dateityp, Ordnerpfad + Datei_Gleich + Dateityp2) == true)
            {
                Console.WriteLine(Datei_Gleich + "  gleich");
            }
            else
            {
                Console.WriteLine(Datei_Gleich + "  ungleich");
            }
            Console.WriteLine("");
            Console.WriteLine("Sollte: Screenshot richtig, Datei falsch");
            //Vergleicht den Text vom Original und der Datei "neu", beim Screenshot wird die richtigeDatei geöffnet
            if (vergleich.Vergleich_Hash(Ordnerpfad + neu + Dateityp, Ordnerpfad + Datei_Gleich + Dateityp2) == true)
            {
                
                Console.WriteLine(neu + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu + "  ungleich");
            }
            Console.WriteLine("");
            //Vergleicht den Text vom Original und der Datei "neu"
            if (vergleich.Vergleich_Hash(Ordnerpfad + neu + Dateityp, Ordnerpfad + neu + Dateityp2) == true)
            {
                Console.WriteLine(neu + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu + "  ungleich");
            }
            Console.WriteLine("");
            //Vergleicht den Text vom Original und der Datei "neu2"
            if (vergleich.Vergleich_Hash(Ordnerpfad + neu2 + Dateityp, Ordnerpfad + neu2 + Dateityp2) == true)
            {
                Console.WriteLine(neu2 + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu2 + "  ungleich");
            }
            Console.WriteLine("");
        }
        [TestMethod]
        public void TestBodyText()
        {
            string Ordnerpfad = @"C:\Users\Copperbottom\Desktop\Testszenarien\Body_Word_Vollbild\";
            string Original = "Original";
            string Datei_Gleich = "Datei_Gleich";
            string neu = "Abweichung2";
            string neu2 = "Abweichung1";
            string Dateityp = ".docx";

            //Weist der Variable "vergleich" die Originale Vergleichs Datei zu
            XML_Auslesen vergleich = new XML_Auslesen(Ordnerpfad + Original + Dateityp);


            if (vergleich.Vergleich_Body(Ordnerpfad + Datei_Gleich + Dateityp) == true)
            {
                Console.WriteLine(Datei_Gleich + "  gleich");
            }
            else
            {
                Console.WriteLine(Datei_Gleich + "  ungleich");
            }
            //Vergleicht den Text vom Original und der Datei "neu"
            if (vergleich.Vergleich_Body(Ordnerpfad + neu + Dateityp) == true)
            {
                Console.WriteLine(neu + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu + "  ungleich");
            }
            //Vergleicht den Text vom Original und der Datei "neu2"
            if (vergleich.Vergleich_Body(Ordnerpfad + neu2 + Dateityp) == true)
            {
                Console.WriteLine(neu2 + "  gleich");
            }
            else
            {
                //***Aufrufen von Screenshot hinzufügen
                Console.WriteLine(neu2 + "  ungleich");
            }

        }
        [TestMethod]
        public void TestScreenshot()
        {
            string Ordnerpfad = @"C:\Users\Copperbottom\Desktop\Testszenarien\Kreis_Paint\";
            string Original = "Original";
            string Datei_Gleich = "Bild_Gleich";
            string neu = "Abweichung2";
            string neu2 = "Abweichung1";
            string Dateityp = ".png";

            //Weist der Variable "vergleich" die Originale Vergleichs Datei zu
            Vergleich_Screenshot vergleich = new Vergleich_Screenshot(Ordnerpfad + Original + Dateityp);
            
            if (vergleich.Vergleich_Screen(Ordnerpfad + Datei_Gleich + Dateityp  ) == 0)
            {
                Console.WriteLine(Datei_Gleich + "  gleich");
            }
            else
            {
                Console.WriteLine(Datei_Gleich + "  ungleich");
            }

            if (vergleich.Vergleich_Screen(Ordnerpfad + neu + Dateityp) == 0)
            {
                Console.WriteLine(neu + "  gleich");
            }
            else
            {
                Console.WriteLine(neu + "  ungleich");
            }

            if (vergleich.Vergleich_Screen(Ordnerpfad + neu2 + Dateityp) == 0)
            {
                Console.WriteLine(neu2 + "  gleich");
            }
            else
            {
                Console.WriteLine(neu2 + "  ungleich");
            }

        }



    }

}
