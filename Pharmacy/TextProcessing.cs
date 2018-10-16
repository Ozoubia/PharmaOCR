using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Pharmacy
{
    //image processing class (OCR)
    class TextProcessing
    {
        Bitmap toProcessImg;

        //ocr constructor that takes an image to process
        public TextProcessing(Bitmap image)
        {
            this.toProcessImg = image;
        }

        // the ocr function that does the image processing and returns the resulted text
        public string process()
        {
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            ocr.SetVariable("test", "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ:/");
            var page = ocr.Process(toProcessImg);
            return page.GetText();
        }
    }
}
