using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Imaging.Filters;

namespace Pharmacy
{
    class Preprocessing
    {
        //vars
        Bitmap preProcessImage;
        Bitmap tempImg;
        public string resultText;

        //preprocessing constructor
        public Preprocessing(Bitmap image)
        {
            this.preProcessImage = image;
        }

        //function that apply all the preprocessing effects to the image taken by the camera
        public string applyAllEffects()
        {
            blackAndWhite();
            SetContrast(30);            
            flipBack();
            return resultText;
        }

        //flip imageback to its normal form
        public void flipBack()
        {
            tempImg.RotateFlip(RotateFlipType.Rotate180FlipY);
            TextProcessing obj = new TextProcessing(tempImg);
            resultText = obj.process();
        }

        //method that crops the rectangle part of the image and returns it as a bitmap image
        public Bitmap CropImage()
        {
            //cropper that only crop the rectangle part
            Crop cropper = new Crop(new Rectangle(132, 82, 118, 78));
            // apply the filter
            Bitmap croppedImg = cropper.Apply(preProcessImage);

            return croppedImg;
        }

        //method that turns the image black and white 
        public void blackAndWhite()
        {
            var croppedImg = CropImage();
            Image<Bgr, Byte> imageToGrey = new Image<Bgr, Byte>(croppedImg);
            Image<Gray, byte> greyImg = imageToGrey.Convert<Gray, byte>();
            tempImg = greyImg.ToBitmap();
        }

        //method that adjusts the contrast of the image 
        public void SetContrast(double contrast)
        {

            Bitmap ToContrastImg = new Bitmap(tempImg);
            Bitmap ContrastImg = (Bitmap)ToContrastImg.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < ContrastImg.Width; i++)
            {
                for (int j = 0; j < ContrastImg.Height; j++)
                {
                    c = ContrastImg.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    ContrastImg.SetPixel(i, j,
        Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            tempImg = (Bitmap)ContrastImg.Clone();           
        }
    }
}
