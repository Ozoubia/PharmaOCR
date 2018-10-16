using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace Pharmacy
{
    public partial class Form1 : Form
    {
        //frame , cam devices variables
        VideoCaptureDevice frame;
        FilterInfoCollection Devices;
        //red rectangle in the center
        Rectangle redRectangle = new Rectangle(130, 80, 120, 80);
        //main function
        public Form1()
        {
            InitializeComponent();
            Start_cam();
        }

        //start camera method
        void Start_cam()
        {
            try
            {
                //add all the video devices(cameras)
                Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                frame = new VideoCaptureDevice(Devices[0].MonikerString);
                // to show the video output of the camera in real time without saving it
                frame.NewFrame += new AForge.Video.NewFrameEventHandler(newFrame_event);
                frame.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("No camera detected plug in the camera and restart the app");
            }
        }

        //frames method
        void newFrame_event(object send, NewFrameEventArgs e)
        {
            try
            {
                //clone the img      
                Bitmap imgBeforeRotate = (Bitmap)e.Frame.Clone();
                imgBeforeRotate.RotateFlip(RotateFlipType.Rotate180FlipY);
                CamPictureBox.Image = imgBeforeRotate;

                //***this next line of code is for memory cleaning; will force a garbage collecting (cleaning) of the memory.***
                long usedMemory = GC.GetTotalMemory(true);
            }
            catch (Exception)
            {
                //catch code
            }
        }

        //cam picture box paint event 
        private void CamPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //drawing the red rectangle in the picture box
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), redRectangle);
        }

        //stopping the camera when the form is closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frame == null)
            {
                return;
            }
            //stopping the camera or frames
            frame.Stop();
            //stopping the timer
            timer.Stop();
        }

        //process button click event
        private void ProcessBtn_Click(object sender, EventArgs e)
        {
            //declaring image to be processed with the height and width of the picture box
            using (Bitmap savedImage = new Bitmap(CamPictureBox.ClientSize.Width,
                               CamPictureBox.ClientSize.Height))
            {                
                CamPictureBox.DrawToBitmap(savedImage, CamPictureBox.ClientRectangle);
                //sending image to be processed
                Preprocessing obj = new Preprocessing(savedImage);  
                
                //showing the result in the text box       
                ResultTextBox.Text = obj.applyAllEffects();
                //showing only first line of the text
                string resultFilteredText = ResultTextBox.Lines.FirstOrDefault();
                ResultTextBox.Text = resultFilteredText;
            }
        }

        //timer that ticks every 4 seconds 
        private void timer_Tick(object sender, EventArgs e)
        {
            //declaring image to be processed with the height and width of the picture box
            using (Bitmap savedImage = new Bitmap(CamPictureBox.ClientSize.Width,
                               CamPictureBox.ClientSize.Height))
            {
                CamPictureBox.DrawToBitmap(savedImage, CamPictureBox.ClientRectangle);
                Preprocessing obj = new Preprocessing(savedImage);
                //showing the result in the text box       
                ResultTextBox.Text = obj.applyAllEffects();
                //showing only first line of the text
                string resultFilteredText = ResultTextBox.Lines.FirstOrDefault();
                ResultTextBox.Text = resultFilteredText;
            }
        }

        //autoprocess check button checked or unckecked
        private void autoProcess_CheckedChanged(object sender, EventArgs e)
        {
            //start timer every 4 seconds when checked else stop
            if (autoProcess.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
