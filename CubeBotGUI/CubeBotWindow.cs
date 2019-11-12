using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;

namespace CubeBotGUI
{
    public partial class CubeBotWindow : Form
    {
        public CubeBotWindow()
        {
            if (File.Exists("bmp"))
            {
                File.Delete("bmp");
            }
            Control.CheckForIllegalCrossThreadCalls = false; //100% need this
            InitializeComponent();
        }

        VideoCapture capture = new VideoCapture(); //create a camera capture
        VideoCapture cap = new VideoCapture(); //create a camera capture
        Bitmap image;
        public Bitmap img;


        public static string text;
        public static int frame = 0;
        private bool viewed;
        public bool live = true;

        public static string color;

        public static int redvalue;
        public static int greenvalue;
        public static int bluevalue;

        public static int red_confidence;
        public static int green_confidence;
        public static int blue_confidence;
        public static int overall_confidence;
        public bool solvemycubepressed = false;
        public string newtext;



        public static int px = 0;


        //define location of corners in terms of pixels
        public static int[,] pixel = new int[4, 2]{ 

                                {220, 220}, //first int is how far right, second int is how far down
                                {300, 250}, 
                                {300, 340},
                                {220, 320}

                            };

        public static void WriteResourceToFile(string resourceName, string fileName)
        {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }

        public void ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the stream ***
            string output = process.StandardOutput.ReadToEnd();

            output.Replace("  ","");
            log(output);

            process.Close();
        }

        public void log(string text)
        {
            //log_box.AppendText(Environment.NewLine);
            log_box.AppendText(text);
        }

        bool InRange(int colorvalue, int max, int min)
        {
            return (colorvalue <= max && colorvalue >= min);
        }

        public string colorname()
        {
            if (InRange(redvalue, 255, 150) && InRange(greenvalue, 60, 0) && InRange(bluevalue, 60, 0))
            {
                //red_confidence = Math.Abs(((255 - redvalue + (redvalue - 150)) / 2) - 202) / 202 ;   // fix this to show percent error of red value



                return "red";
            }



            else
            {
                //log("error determining color name");
                return "error";
            }
        }

        private void read_f1_Click(object sender, EventArgs e)
        {
            solvemycubepressed = true;
            live = false;
            Thread.Sleep(1000); //give time for LiveCamera() to finish running, or else we will get nullreferenceexception
            cap.Dispose();
            liveimage.Dispose();
            GC.Collect();
            string workdir = Environment.CurrentDirectory;

            if (File.Exists(workdir + "/CubeBotRewritten.exe"))
            {
                File.Delete(workdir + "/CubeBotRewritten.exe");
            }
            if (!File.Exists(workdir + "/CubeBotRewritten.exe"))
            {
                WriteResourceToFile("CubeBotGUI.Resources.CubeBotRewritten.exe", workdir + "/CubeBotRewritten.exe");
            }

            if (cubestring_box.Text == "Manually enter cubestring" || cubestring_box.Text == null)
            {
                //log("Capturing webcam");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                VideoCapture capture = new VideoCapture(); //create a camera capture
                Bitmap image = capture.QueryFrame().Bitmap; //take a picture
                cubeview.Image = image;
                cubeview.Refresh();



                for (int i = 0; i < 4; i++)
                {
                    Bitmap bmp = (Bitmap)cubeview.Image;
                    Color clr = bmp.GetPixel(pixel[i, 0], pixel[i, 1]);
                    redvalue = clr.R;
                    greenvalue = clr.G;
                    bluevalue = clr.B;
                    log("Corner " + i + " color is:  RGB(" + redvalue + ", " + greenvalue + ", " + bluevalue + ")");

                    for (int q = 0; q < 50; q++)
                    {
                        px++;
                        image.SetPixel(pixel[i, 0] + px, pixel[i, 1] + px, Color.Yellow);
                    }
                    px = 0;

                    cubeview.Image = bmp;

                    log(Environment.NewLine + "Color name is: " + colorname() + Environment.NewLine);
                }
                stopwatch.Stop();
                log("Time elapsed for reading face 1: " + stopwatch.Elapsed);
            }
            else
            {
                log("Cubestring is: " + cubestring_box.Text);
                ExecuteCommand("CubeBotRewritten.exe " + cubestring_box.Text);
                log(Environment.NewLine);
                log("CubeBotRewritten is finished.");
            }
        }



        public void ViewCamera()
        {
            live = false;
            double viewtime = Convert.ToDouble(timetextbox.Text);

            Stopwatch s = new Stopwatch();
            s.Start();

            VideoCapture capture = new VideoCapture();
            while (s.Elapsed < TimeSpan.FromSeconds(viewtime))
            {
                image = capture.QueryFrame().Bitmap; //take a picture
                cubeview.Image = image;
                cubeview.Refresh();
            } s.Stop();
              

            cubeview.Image = image;
            cubeview.Refresh();
            for (int i = 0; i < 4; i++)
            {
                Bitmap bmp = (Bitmap)cubeview.Image;
                Color clr = bmp.GetPixel(pixel[i, 0], pixel[i, 1]);
                redvalue = clr.R;
                greenvalue = clr.G;
                bluevalue = clr.B;
                //log("Corner " + i + " color is:  RGB(" + redvalue + ", " + greenvalue + ", " + bluevalue + ")");

                for (int q = 0; q < 50; q++)
                {
                    px++;
                    image.SetPixel(pixel[i, 0] + px, pixel[i, 1] + px, Color.Yellow);
                }
                px = 0;

                cubeview.Image = bmp;

                //log(Environment.NewLine + "Color name is: " + colorname() + Environment.NewLine);
            }
            GC.Collect();
            }

        public void LiveView()
        {
            int t = 0;
            Task.Run(() =>
            {
                while (live)
                {
                    if (t == 1)
                    {
                        Enabled = true;
                    }
                    t = 1;
                    VideoCapture cap = new VideoCapture();
                    Bitmap img;
                    img = cap.QueryFrame().Bitmap; //take a picture
                    liveimage.Image = img;
                    liveimage.Refresh();
                    GC.Collect();
                }
            });
        }
        private void viewwhereweread_Click(object sender, EventArgs e)
        {
            if (viewed)
            {
                viewwhereweread.Text = "Must reset images before running again!";
                viewwhereweread.Enabled = false;
            }
            else
            {
                viewed = true;
                live = false;
                Thread.Sleep(300);
                ViewCamera();
            }
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            live = false;
        }

        private void restart_Click(object sender, EventArgs e)
        {
            if (solvemycubepressed)
            {
                resetbutton_Click(sender, e);
            }
            else
            {
                live = true;
                Thread.Sleep(300);
                LiveView();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Refresh();
            LiveView();
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            live = false;
            Thread.Sleep(300);
            this.Hide();
            CubeBotWindow frm1 = new CubeBotWindow();
            GC.Collect();
            frm1.Show();
        }

        private void cubestring_box_Click(object sender, EventArgs e)
        {
            cubestring_box.Text = null;
        }
    }
}
