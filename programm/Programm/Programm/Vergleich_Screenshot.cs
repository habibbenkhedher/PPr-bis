using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Vergleich_Screenshot
{
    public string fname2 = @"";
    public string fname1 = @"";

    public Vergleich_Screenshot()
    {
        // Picturebox_Bild2_Anzeigen();
        //Picturebox_Bild1_Anzeigen();
    }
    /*
    private void progressBar1_Click(object sender, EventArgs e)
    {

    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        openFileDialog1.FileName = ""; //entfernt den Namen openfileDialong aus der Suche
        openFileDialog1.Title = "Images";
        openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";
        openFileDialog1.ShowDialog();
        if (openFileDialog1.FileName.ToString() != "")
        {
            fname1 = openFileDialog1.FileName.ToString();
            Picturebox_Bild1_Anzeigen();
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        progressBar1.Visible = false;
        //pictureBox1.Visible = false;
    }

    private void Bild2_Wahl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {

        openFileDialog1.FileName = ""; //entfernt den Namen openfileDialong aus der Suche
        openFileDialog1.Title = "Images";
        openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";
        openFileDialog1.ShowDialog();

        if (openFileDialog1.FileName.ToString() != "")
        {
            fname2 = openFileDialog1.FileName.ToString();
            Picturebox_Bild2_Anzeigen();
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        bool flag = true;
        int count1 = 0;
        int count2 = 0;
        progressBar1.Visible = true;
        progressBar1.Value = 0;
        string img1_ref, img2_ref;
        Bitmap img1 = new Bitmap(fname1);
        Bitmap img2 = new Bitmap(fname2);
        progressBar1.Maximum = img1.Width;
        if (img1.Width == img2.Width && img1.Height == img2.Height)
        {
            for (int Vergleich_Horizontal = 0; Vergleich_Horizontal < img1.Width; Vergleich_Horizontal++)
            {
                for (int Vergleich_Vertikal = 0; Vergleich_Vertikal < img1.Height; Vergleich_Vertikal++)
                {
                    img1_ref = img1.GetPixel(Vergleich_Horizontal, Vergleich_Vertikal).ToString();
                    img2_ref = img2.GetPixel(Vergleich_Horizontal, Vergleich_Vertikal).ToString();
                    if (img1_ref != img2_ref)
                    {
                        count2++;
                        flag = false;
                        break;
                    }
                    count1++;
                }
                progressBar1.Value++;
            }
            if (flag == false)
                MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
            else
                MessageBox.Show(" Images are same , " + count1 + " same pixels found and " + count2 + " wrong pixels found");
        }
        else
            MessageBox.Show("can not compare this images");

        // this.Dispose(); //Beendet direkt das Programm

    }

    private void Picturebox_Bild1_Anzeigen()
    {
        Bitmap img1 = new Bitmap(fname1);
        Bild1.Image = img1;
    }

    private void Picturebox_Bild2_Anzeigen()
    {
        Bitmap img2 = new Bitmap(fname2);
        Bild2.Image = img2;
    }


}
    */
}
