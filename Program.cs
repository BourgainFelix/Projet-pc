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
    class Program
    {

        static void Main(string[] args)
        {
            byte[] myfile = File.ReadAllBytes("./Images/coco.bmp");

            Image image = new Image(myfile);

            //image.nuancedenoir();
            //image.gris();
            //image.inversercouleur();
            //image.Agrandissement(2);
            image.newFile();


            File.WriteAllBytes("./Images/cocotest.bmp", myfile);
        }
    }
}