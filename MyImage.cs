using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Image
{
    class Image
    {
        private byte[] myfile;
        private Pixel[,] matImage;

        public Image(byte[] myfile)
        {
            this.myfile = myfile;

            this.matImage = new Pixel[myfile[22] + myfile[23] * 256, myfile[18] + myfile[19] * 256];
            int longueur = 0;

            for (int i = 54; i < myfile.Length; i = i + (myfile[18] + myfile[19] * 256) * 3)
            {
                int largeur = 0;
                for (int j = i; j < i + (myfile[18] + myfile[19] * 256) * 3; j = j + 3)
                {

                    matImage[longueur, largeur] = new Pixel(myfile[j + 2], myfile[j + 1], myfile[j]);
                    largeur++;
                }
                longueur++;
            }
        }
        public int Convertir_Endian_To_Int(byte[] tab)
        {
        int s = 0;
        for (int i = 0; i < tab.Length; i++)
            {
                s += tab[i] * Convert.ToInt64(Math.Pow(256 , i));
            }
        return s;
        }
    public void gris()
        {
            for (int i = 0; i < matImage.GetLength(0); i++)
            {
                for (int j = 0; j < matImage.GetLength(1); j++)
                {
                    int gris = (matImage[i, j].r + matImage[i, j].g + matImage[i, j].b) / 3;
                    byte newgris = Convert.ToByte(gris);
                    matImage[i, j] = new Pixel(newgris, newgris, newgris);
                }
            }
        }

        public void nuancedenoir()
        {
            for (int i = 0; i < matImage.GetLength(0); i++)
            {
                for (int j = 0; j < matImage.GetLength(1); j++)
                {
                    int gris = (matImage[i, j].r + matImage[i, j].g + matImage[i, j].b) / 3;
                    if (gris < 127)
                    {
                        matImage[i, j] = new Pixel(0, 0, 0);
                    }
                    else
                    {
                        matImage[i, j] = new Pixel(255, 255, 255);
                    }


                }
            }
        }

        public void inversercouleur()
        {
            for (int i = 0; i < matImage.GetLength(0); i++)
            {
                for (int j = 0; j < matImage.GetLength(1); j++)
                {

                    matImage[i, j] = new Pixel(matImage[i, j].b, matImage[i, j].g, matImage[i, j].r);



                }
            }
        }
        public void newFile()
        {
            int longueur = 0;
            for (int i = 54; i < myfile.Length; i = i + (myfile[18] + myfile[19] * 256) * 3)
            {
                int largeur = 0;
                for (int j = i; j < i + (myfile[18] + myfile[19] * 256) * 3; j = j + 3)
                {

                    myfile[j] = matImage[longueur, largeur].b;
                    myfile[j + 1] = matImage[longueur, largeur].g;
                    myfile[j + 2] = matImage[longueur, largeur].r;
                    largeur++;
                }
                longueur++;
            }
        }
        public Pixel [,] Agrandissement(int coefficient)
        {
            Pixel [,] matImage2 = new Pixel[matImage.GetLength(0) * coefficient, matImage.GetLength(1) * coefficient];
            for (int i = 0, a = 0; i < this.matImage.GetLength(0); i++, a = i*coefficient)
            {
                for (int j = 0, b = 0; j < this.matImage.GetLength(1); j++, b = j*coefficient)
                {
                    for (int k = 0;k < coefficient; k++)
                    {
                        matImage2[a,b+k]= matImage[i,j];
                        matImage2[a + k, b] = matImage[i, j];
                    }
                }
            }
            return matImage2;
            //matImage = matImage2;
        }
    }
}
