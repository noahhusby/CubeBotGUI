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
using System.Collections.ObjectModel;

namespace CubeBotGUI
{
    public partial class Form1 : Form
    {
        public Form1()
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

        public Color paint;


        //
        //
        //
        //    variables for solving algorithm
        //
        //
        //

        //   create array for holding the colors of each corner, plus one extra for storing the next target. [0] is the top-back-right piece. 
        Stopwatch stopwatch1 = new Stopwatch();
        public static string[] CornerColor = new string[10];
        public static string[] current = new string[10];
        public static int PossibleNumberOfPiecesToSolve = 7;
        public static ObservableCollection<string> SolvedPieces = new ObservableCollection<string>();
        public static ObservableCollection<string> UnsolvedPieces = new ObservableCollection<string>();
        public static ObservableCollection<string> twisted = new ObservableCollection<string>();
        public static ObservableCollection<string> solutions = new ObservableCollection<string>();
        public static string YPerm = "R U' R' U' R U R' F' R U R' U' R' F R";

        public static string posa;
        public static string posb;
        public static string posc;
        public static string posd;
        public static string pose;
        public static string posf;
        public static string posg;
        public static string posh;
        public static string posi;
        public static string posj;
        public static string posk;
        public static string posl;
        public static string posm;
        public static string posn;
        public static string poso;
        public static string posp;
        public static string posq;
        public static string posr;
        public static string poss;
        public static string post;
        public static string posu;
        public static string posv;
        public static string posw;
        public static string posx;
        private static string loc;
        private static string CornerBelongsInPosition;
        private static string colors_on_twist;
        private static string setup;
        private static string und;
        private static string targetcolor;
        private static string cubestring;
        private static bool specialtwistedloccase;
        private static bool locistwisted;
        private static string twist_buff;

        public static Stopwatch stopwatch = new Stopwatch();
        private static bool handlingtwist;
        public static string oldloc;
        private static string newcube;
        private static string oldpiece;
        private static string newpiece;
        private static string old;
        private string oldcolor;
        private string newcolor;
        private int oldcornercolor;
        private int newcornercolor;
        private static string temp;
        private static string finalaposition;
        private static string finalpieceweshotto;
        private static object temp_for_buff;
        private static int timesbuilt;
        private static string pcs;
        private static string allpcs;
        public static bool firsttime = true;




        public static int px = 0;


        //define location of corners in terms of pixels
        public static int[,] pixel = new int[4, 2]{

                                {220, 220}, //first int is how far right, second int is how far down
                                {300, 250},
                                {300, 340},
                                {220, 320}

                            };
        private DateTime _start;
        private DateTime StartTime;

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

            output.Replace("  ", "");
            log(output);

            process.Close();
        }

        public void log(string text)
        {
            log_box.AppendText(Environment.NewLine);
            log_box.AppendText(text);
        }

        bool InRange(int colorvalue, int max, int min)
        {
            return (colorvalue <= max && colorvalue >= min);
        }

        public string colorname()
        {
            if (InRange(redvalue, 255, 120) && InRange(greenvalue, 80, 0) && InRange(bluevalue, 80, 0))
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
            //string workdir = Environment.CurrentDirectory;

            //if (File.Exists(workdir + "/CubeBotRewritten.exe"))
            //{
            // File.Delete(workdir + "/CubeBotRewritten.exe");
            //}
            //if (!File.Exists(workdir + "/CubeBotRewritten.exe"))
            //{
            //WriteResourceToFile("CubeBotGUI.Resources.CubeBotRewritten.exe", workdir + "/CubeBotRewritten.exe");
            //}

            if (cubestring_box.Text == "Manually enter cubestring" || cubestring_box.Text == null)
            {
                solvemycubepressed = true;
                live = false;
                Thread.Sleep(1000); //give time for LiveCamera() to finish running, or else we will get nullreferenceexception
                cap.Dispose();
                liveimage.Dispose();
                GC.Collect();
                //log("Capturing webcam");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                //VideoCapture capture = new VideoCapture(); //create a camera capture
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
                cubestring = cubestring_box.Text;
                timer1.Enabled = true;
                timer1.Interval = 100;
                StartTime = DateTime.Now;
                Thread thr = new Thread(alg);
                thr.Start();
            }
        }



        public void ViewCamera()
        {
            //solvemycubepressed = true;
            live = false;
            Thread.Sleep(1000); //give time for LiveCamera() to finish running, or else we will get nullreferenceexception
            cap.Dispose();
            liveimage.Dispose();
            GC.Collect();

            Bitmap image = capture.QueryFrame().Bitmap; //take a picture
            cubeview.Image = image;
            cubeview.Refresh();



            for (int i = 0; i < 4; i++)
            {
                Bitmap bmp = (Bitmap)cubeview.Image;

                for (int q = 0; q < 50; q++)
                {
                    px++;
                    image.SetPixel(pixel[i, 0] + px, pixel[i, 1] + px, Color.Yellow);
                }
                px = 0;

                cubeview.Image = bmp;
            }
            log("We will read colors at top-left-most pixel of each line drawn on image");

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
                    //VideoCapture cap = new VideoCapture();
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
            Form1 frm1 = new Form1();
            GC.Collect();
            frm1.Show();
        }

        private void cubestring_box_Click(object sender, EventArgs e)
        {
            cubestring_box.Text = null;
        }









        /*
        * 
        * 
        *    Below is the solving algorithm for my program
        *    I just needed a dividing line between the GUI and the alg :)
        * 
        * 
        * 
        * */


        public int oldcorner(string oldpiece)
        {
            if (oldpiece == "A" || oldpiece == "E" || oldpiece == "R")
            {
                return 0;
            }
            if (oldpiece == "B" || oldpiece == "N" || oldpiece == "Q")
            {
                return 1;
            }
            if (oldpiece == "C" || oldpiece == "M" || oldpiece == "J")
            {
                return 2;
            }
            if (oldpiece == "D" || oldpiece == "F" || oldpiece == "I")
            {
                return 3;
            }
            if (oldpiece == "U" || oldpiece == "G" || oldpiece == "L")
            {
                return 4;
            }
            if (oldpiece == "V" || oldpiece == "P" || oldpiece == "K")
            {
                return 5;
            }
            if (oldpiece == "W" || oldpiece == "O" || oldpiece == "T")
            {
                return 6;
            }
            if (oldpiece == "X" || oldpiece == "H" || oldpiece == "S")
            {
                return 7;
            }
            else
            {
                log("something isn't right");
                return 0;
            }
        }

        public int newcorner(string newpiece)
        {
            if (newpiece == "A" || newpiece == "E" || newpiece == "R")
            {
                return 0;
            }
            if (newpiece == "B" || newpiece == "N" || newpiece == "Q")
            {
                return 1;
            }
            if (newpiece == "C" || newpiece == "M" || newpiece == "J")
            {
                return 2;
            }
            if (newpiece == "D" || newpiece == "F" || newpiece == "I")
            {
                return 3;
            }
            if (newpiece == "U" || newpiece == "G" || newpiece == "L")
            {
                return 4;
            }
            if (newpiece == "V" || newpiece == "P" || newpiece == "K")
            {
                return 5;
            }
            if (newpiece == "W" || newpiece == "O" || newpiece == "T")
            {
                return 6;
            }
            if (newpiece == "X" || newpiece == "H" || newpiece == "S")
            {
                return 7;
            }
            else
            {
                log("something isn't right");
                return 0;
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - StartTime;

            // Start with the days if greater than 0.
            string text = "";
            if (elapsed.Days > 0)
                text += elapsed.Days.ToString() + ".";

            // Compose the rest of the elapsed time.
            text +=
                elapsed.Seconds.ToString("00") + "." +
                elapsed.Milliseconds.ToString("0");

            TimerTextBox.Text = text;
        }

        public void alg()
        {



            log("Input cubestring is " + cubestring);
            CornerColor[0] = cubestring.Substring(0, 3); //split each corner's colors from whole string
            CornerColor[1] = cubestring.Substring(3, 3);
            CornerColor[2] = cubestring.Substring(6, 3);
            CornerColor[3] = cubestring.Substring(9, 3);
            CornerColor[4] = cubestring.Substring(12, 3);
            CornerColor[5] = cubestring.Substring(15, 3);
            CornerColor[6] = cubestring.Substring(18, 3);
            CornerColor[7] = cubestring.Substring(21, 3);


            posa = CornerColor[0].Substring(0, 1); //split each sticker's color from the whole piece's colors
            pose = CornerColor[0].Substring(1, 1);
            posr = CornerColor[0].Substring(2, 1);

            posb = CornerColor[1].Substring(0, 1);
            posn = CornerColor[1].Substring(1, 1);
            posq = CornerColor[1].Substring(2, 1);

            posc = CornerColor[2].Substring(0, 1);
            posm = CornerColor[2].Substring(1, 1);
            posj = CornerColor[2].Substring(2, 1);


            posd = CornerColor[3].Substring(0, 1);
            posf = CornerColor[3].Substring(1, 1);
            posi = CornerColor[3].Substring(2, 1);


            posu = CornerColor[4].Substring(0, 1);
            posg = CornerColor[4].Substring(1, 1);
            posl = CornerColor[4].Substring(2, 1);


            posv = CornerColor[5].Substring(0, 1);
            posp = CornerColor[5].Substring(1, 1);
            posk = CornerColor[5].Substring(2, 1);


            posw = CornerColor[6].Substring(0, 1);
            poso = CornerColor[6].Substring(1, 1);
            post = CornerColor[6].Substring(2, 1);


            posx = CornerColor[7].Substring(0, 1);
            posh = CornerColor[7].Substring(1, 1);
            poss = CornerColor[7].Substring(2, 1);



            //foreach (string str in CornerColor)
            //{
            //  log(str);
            //}
            PossibleNumberOfPiecesToSolve = 7;
            depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
            //Console.ResetColor();
            FindIfAnySolvedPieces();


            allpcs = null;
            for (int i = 0; i < 8; i++)
            {
                //log("Backing up CornerColor[" + i + "] in current[" + i + "]");
                current[i] = CornerColor[i];
                allpcs += current[i];
            }
            log(Environment.NewLine);

            if (allpcs == "WOBWRBWRGWOGYOGYRGYRBYOB")
            {
                log("Your cube is already solved, dummy.");
                solved();
            }




            oldpiece = "A";
            FindWherePieceBelongs(CornerColor[0]); //find where buffer belongs
            log("Corner " + current[0] + " belongs in [loc = " + loc + "]");
            PossibleNumberOfPiecesToSolve--;
            depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
            log(PossibleNumberOfPiecesToSolve.ToString() + " pieces left to solve");
            FindSetupMoves(loc); //find which setup moves/inverse we need to use
            newpiece = loc;

            updatecurrent();


            AddToSolvedPieces(loc);
            Console.ForegroundColor = ConsoleColor.Green;
            log("Corner Solution: " + setup + " " + YPerm + " " + und); //print solution for first corner
            solution_box.AppendText(setup + " " + YPerm + " " + und);
            solution_box.AppendText(Environment.NewLine);
            log(Environment.NewLine);
            Console.ResetColor();
            solutions.Add(setup + " " + YPerm + " " + und);
            //SolvedPieces.ForEach(i => Console.Write("{0}\t", i));

            pcs = null;
            for (int i = 0; i < 8; i++)
            {
                pcs += current[i];
            }
            if (pcs == "WOBWRBWRGWOGYOGYRGYRBYOB")
            {
                solved();
            }

            if (pcs != "WOBWRBWRGWOGYOGYRGYRBYOB")
            {
                while (PossibleNumberOfPiecesToSolve > 0)
                {
                    SolveNextCorner();
                } //keep solving corners until we have none left to solve :)
            }
        }

        public  void updatecurrent()
        {
            oldcornercolor = oldcorner(oldpiece);
            newcornercolor = newcorner(newpiece);

            //(current[0], current[newcornercolor]) = (current[newcornercolor], current[0]);
            //the above is sufficient to swap the permutations of the two pieces we just switched, but whole point is to know orientation as well.
            //for example, shooting the piece in the "A" position to any sticker on the front/back side of the cube will cause the piece in the "A" position (after shooting) to be misoriented in our program in contrast to real life.
            //we need to correct for this.


            //swapchar(true, current[0], current[newcornercolor], 1, , 2, , 3, , 1, , 2, , 3, );

            if (newpiece == "A")
            {
                //no change- it's already in "a"
            }
            if (newpiece == "B")
            {
                //this stuff here will swap the buffer and piece we shot to, and put each color in the correct orientation we will see in real life
                swapchar(true, current[0], current[newcornercolor], /* first we build buffer -> */ 1, 1, 2, 3, 3, 2, /* next we build piece we shot to ->*/ 1, 1, 2, 3, 3, 2);
            }
            if (newpiece == "C")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3);
            }
            if (newpiece == "D")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2);
            }
            if (newpiece == "E")
            {
                //this wouldn't make any sense. Can't swap buffer with buffer ;)
            }
            if (newpiece == "F")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
            }
            if (newpiece == "G") //IDK WHY THIS ONE WORKS??? SHOULDN'T ''SHOT TO'' BE DIFFERENT??? SHOULDNT IT MATCH BUFFER?
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3, 1);
            }
            if (newpiece == "H")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
            }
            if (newpiece == "I")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
            }
            if (newpiece == "J")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2);
            }
            if (newpiece == "K")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
            }
            if (newpiece == "L")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2);
            }
            if (newpiece == "M")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3, 1);
            }
            if (newpiece == "N")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
            }
            if (newpiece == "O")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3, 1);
            }
            if (newpiece == "P")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 2, 2, 1, 3, 3, 1, 2, 2, 1, 3, 3);
            }
            if (newpiece == "Q")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
            }
            if (newpiece == "R")
            {
                //r is on the buffer so wouldnt make sense
            }
            if (newpiece == "S")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 2, 3, 1, 1, 3, 2, 2, 3, 1);
            }
            if (newpiece == "T")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2);
            }
            if (newpiece == "U")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3);
            }
            if (newpiece == "V")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2);
            }
            if (newpiece == "W")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 2, 3, 3, 1, 1, 2, 2, 3, 3);
            }
            if (newpiece == "X")
            {
                swapchar(true, current[0], current[newcornercolor], 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2);
            }
        }

        public  void swapchar(bool swapbuffer, string buffer, string shotto, int buff_swap1_buffchar, int buff_swap1_shotchar, int buff_swap2_buffchar, int buff_swap2_shotchar, int buff_swap3_buffchar, int buff_swap3_shotchar, int shot_swap1_buffchar, int shot_swap1_shotchar, int shot_swap2_buffchar, int shot_swap2_shotchar, int shot_swap3_buffchar, int shot_swap3_shotchar)
        {

            //this is a pretty odd algorithm which swaps the buffer and shot piece, and vice versa, according to how we specify, in order to achieve the correct representation of the pieces' orientations and permutations in the program. Cornercolor[] array does not care about orientation, so current[] array is more accurate in reagrd to piece attributes (permutation and orientation).
            StringBuilder buff_builder = new StringBuilder(buffer);
            StringBuilder shot_builder = new StringBuilder(shotto);
            StringBuilder temp_for_buff = new StringBuilder(buffer);

            //log("buff builder is " + buff_builder.ToString() + " and shot is " + shot_builder.ToString() + " and temp is " + temp_for_buff.ToString());


            //first we build buffer
            temp_for_buff[buff_swap1_buffchar - 1] = shot_builder[buff_swap1_shotchar - 1]; //minus one because arrays start at zero, not 1
            temp_for_buff[buff_swap2_buffchar - 1] = shot_builder[buff_swap2_shotchar - 1];
            temp_for_buff[buff_swap3_buffchar - 1] = shot_builder[buff_swap3_shotchar - 1];

            //next we build piece we shot to
            shot_builder[shot_swap1_shotchar - 1] = buff_builder[shot_swap1_buffchar - 1];
            shot_builder[shot_swap2_shotchar - 1] = buff_builder[shot_swap2_buffchar - 1];
            shot_builder[shot_swap3_shotchar - 1] = buff_builder[shot_swap3_buffchar - 1];

            current[0] = temp_for_buff.ToString();
            current[newcornercolor] = shot_builder.ToString(); //pack changes back into current piece array
        }


        public  void FindIfAnySolvedPieces()
        {
            if (CornerColor[0].Contains("W") && CornerColor[0].Contains("O") && CornerColor[0].Contains("B"))
            {
                if (CornerColor[0].Substring(0, 1) == "W")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("TBL");
                }
            }
            if (CornerColor[1].Contains("W") && CornerColor[1].Contains("R") && CornerColor[1].Contains("B"))
            {
                if (CornerColor[1].Substring(0, 1) == "W")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("TBR");
                }
            }
            if (CornerColor[2].Contains("W") && CornerColor[2].Contains("R") && CornerColor[2].Contains("G"))
            {
                if (CornerColor[2].Substring(0, 1) == "W")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("TFR");
                }
            }
            if (CornerColor[3].Contains("W") && CornerColor[3].Contains("O") && CornerColor[3].Contains("G"))
            {
                if (CornerColor[3].Substring(0, 1) == "W")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("TFL");
                }
            }
            if (CornerColor[4].Contains("Y") && CornerColor[4].Contains("O") && CornerColor[4].Contains("G"))
            {
                //do the same for Y
                if (CornerColor[4].Substring(0, 1) == "Y")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("BFL");
                }
            }
            if (CornerColor[5].Contains("Y") && CornerColor[5].Contains("R") && CornerColor[5].Contains("G"))
            {
                if (CornerColor[5].Substring(0, 1) == "Y")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("BFR");
                }
            }
            if (CornerColor[6].Contains("Y") && CornerColor[6].Contains("R") && CornerColor[6].Contains("B"))
            {
                if (CornerColor[6].Substring(0, 1) == "Y")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("BBR");
                }
            }
            if (CornerColor[7].Contains("Y") && CornerColor[7].Contains("O") && CornerColor[7].Contains("B"))
            {
                if (CornerColor[7].Substring(0, 1) == "Y")
                {
                    PossibleNumberOfPiecesToSolve--;
                    SolvedPieces.Add("BBL");
                }
            }

            log("Number of pieces we need to solve: " + PossibleNumberOfPiecesToSolve);
            depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
            //log(Environment.NewLine);
            //log(Environment.NewLine);

            FindIfAnyTwistedPieces();
            log("Pieces that are permuted correctly but not oriented correctly (aka twisted): ");
            twisted.ToList().ForEach(i => log_box.AppendText("  " + i));
        }
        public  void FindIfAnyTwistedPieces()
        {
            if (CornerColor[0].Contains("W") && CornerColor[0].Contains("O") && CornerColor[0].Contains("B"))
            {
                if (CornerColor[0].Substring(0, 1) != "W")
                {
                    twisted.Add("TBL");
                }
            }
            if (CornerColor[1].Contains("W") && CornerColor[1].Contains("R") && CornerColor[1].Contains("B"))
            {
                if (CornerColor[1].Substring(0, 1) != "W")
                {
                    twisted.Add("TBR");
                }
            }
            if (CornerColor[2].Contains("W") && CornerColor[2].Contains("R") && CornerColor[2].Contains("G"))
            {
                if (CornerColor[2].Substring(0, 1) != "W")
                {
                    twisted.Add("TFR");
                }
            }
            if (CornerColor[3].Contains("W") && CornerColor[3].Contains("O") && CornerColor[3].Contains("G"))
            {
                if (CornerColor[3].Substring(0, 1) != "W")
                {
                    twisted.Add("TFL");
                }
            }
            if (CornerColor[4].Contains("Y") && CornerColor[4].Contains("O") && CornerColor[4].Contains("G"))
            {
                if (CornerColor[4].Substring(0, 1) != "Y")
                {
                    twisted.Add("BFL");
                }
            }
            if (CornerColor[5].Contains("Y") && CornerColor[5].Contains("R") && CornerColor[5].Contains("G"))
            {
                if (CornerColor[5].Substring(0, 1) != "Y")
                {
                    twisted.Add("BFR");
                }
            }
            if (CornerColor[6].Contains("Y") && CornerColor[6].Contains("R") && CornerColor[6].Contains("B"))
            {
                if (CornerColor[6].Substring(0, 1) != "Y")
                {
                    twisted.Add("BBR");
                }
            }
            if (CornerColor[7].Contains("Y") && CornerColor[7].Contains("O") && CornerColor[7].Contains("B"))
            {
                if (CornerColor[7].Substring(0, 1) != "Y")
                {
                    twisted.Add("BBL");
                }
            }
        }
        public  void FindWherePieceBelongs(string CornerColor)
        {
            if (CornerColor.Contains("R") && CornerColor.Contains("B") && CornerColor.Contains("Y"))
            {
                CornerBelongsInPosition = "Back_Bottom_Right";

                if (CornerColor.Substring(0, 1) == "R")
                {
                    loc = "O";
                }
                if (CornerColor.Substring(0, 1) == "B")
                {
                    loc = "T";
                }
                if (CornerColor.Substring(0, 1) == "Y")
                {
                    loc = "W";
                }
            }
            if (CornerColor.Contains("G") && CornerColor.Contains("Y") && CornerColor.Contains("R"))
            {
                CornerBelongsInPosition = "Front_Bottom_Right";

                if (CornerColor.Substring(0, 1) == "G")
                {
                    loc = "K";
                }
                if (CornerColor.Substring(0, 1) == "Y")
                {
                    loc = "V";
                }
                if (CornerColor.Substring(0, 1) == "R")
                {
                    loc = "P";
                }
            }
            if (CornerColor.Contains("Y") && CornerColor.Contains("B") && CornerColor.Contains("O"))
            {
                CornerBelongsInPosition = "Back_Bottom_Left";

                if (CornerColor.Substring(0, 1) == "Y")
                {
                    loc = "X";
                }
                if (CornerColor.Substring(0, 1) == "B")
                {
                    loc = "S";
                }
                if (CornerColor.Substring(0, 1) == "O")
                {
                    loc = "H";
                }
            }
            if (CornerColor.Contains("O") && CornerColor.Contains("G") && CornerColor.Contains("W"))
            {
                CornerBelongsInPosition = "Front_Top_Left";

                if (CornerColor.Substring(0, 1) == "O")
                {
                    loc = "F";
                }
                if (CornerColor.Substring(0, 1) == "G")
                {
                    loc = "I";
                }
                if (CornerColor.Substring(0, 1) == "W")
                {
                    loc = "D";
                }
            }
            if (CornerColor.Contains("G") && CornerColor.Contains("Y") && CornerColor.Contains("O"))
            {
                CornerBelongsInPosition = "Front_Bottom_Left";

                if (CornerColor.Substring(0, 1) == "G")
                {
                    loc = "L";
                }
                if (CornerColor.Substring(0, 1) == "Y")
                {
                    loc = "U";
                }
                if (CornerColor.Substring(0, 1) == "O")
                {
                    loc = "G";
                }
            }
            if (CornerColor.Contains("W") && CornerColor.Contains("B") && CornerColor.Contains("O"))
            {
                CornerBelongsInPosition = "Back_Top_Left";

                if (CornerColor.Substring(0, 1) == "W")
                {
                    loc = "A";
                    PossibleNumberOfPiecesToSolve++;
                    depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
                    colors_on_twist = "WBO";
                    HandleTwist();
                }
                if (CornerColor.Substring(0, 1) == "B")
                {
                    loc = "R";
                    PossibleNumberOfPiecesToSolve++;
                    depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
                    colors_on_twist = "BWO";
                    HandleTwist();
                }
                if (CornerColor.Substring(0, 1) == "O")
                {
                    loc = "E";
                    PossibleNumberOfPiecesToSolve++;
                    depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
                    colors_on_twist = "OBW";
                    HandleTwist();
                }
            }
            if (CornerColor.Contains("W") && CornerColor.Contains("R") && CornerColor.Contains("G"))
            {
                CornerBelongsInPosition = "Front_Top_Right";

                if (CornerColor.Substring(0, 1) == "W")
                {
                    loc = "C";
                }
                if (CornerColor.Substring(0, 1) == "R")
                {
                    loc = "M";
                }
                if (CornerColor.Substring(0, 1) == "G")
                {
                    loc = "J";
                }
            }
            if (CornerColor.Contains("W") && CornerColor.Contains("R") && CornerColor.Contains("B"))
            {
                CornerBelongsInPosition = "Back_Top_Right";

                if (CornerColor.Substring(0, 1) == "W")
                {
                    loc = "B";
                }
                if (CornerColor.Substring(0, 1) == "R")
                {
                    loc = "N";
                }
                if (CornerColor.Substring(0, 1) == "B")
                {
                    loc = "Q";
                }
            }
        }

        public  void HandleTwist()
        {
            handlingtwist = true;
            //PossibleNumberOfPiecesToSolve++;
            if (colors_on_twist == "WBO")
            {
                if (PossibleNumberOfPiecesToSolve > 0)
                {
                    log("The A position is solved, yet there are other pieces which aren't solved yet.");
                    PossibleNumberOfPiecesToSolve++;
                    depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;

                }
            }
            else
            {
                log("The piece in the 'A' position is permuted correctly but oriented incorrectly (aka twisted).");
                //Environment.Exit(1);
            }

            log("twisted corner... orig loc is " + loc);
            oldpiece = loc;
            FindPieceToSolve(); //returns us a loc of a piece we haven't solved
            newpiece = loc;
            updatecurrent();
            FindNextPiece(loc); //find the colors on that piece
            CornerColor[8] = targetcolor; //store the colors of the piece in the array
            FindSetupMoves(loc); //find setup moves to shoot to new buffer
            twist_buff = loc; //make sure we store what our new buffer position is so we can check if we're shooting to it later
            log("twist_buff = " + twist_buff);
            PossibleNumberOfPiecesToSolve--;
            depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
            log(PossibleNumberOfPiecesToSolve.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            log("Corner Solution: " + setup + " " + YPerm + " " + und); //print solution for that piece
            solution_box.AppendText(setup + " " + YPerm + " " + und);
            solution_box.AppendText(Environment.NewLine);
            Console.ResetColor();
            solutions.Add(setup + " " + YPerm + " " + und);
            log("We have solved: ");
            SolvedPieces.ToList().ForEach(i => log_box.AppendText("   " + i));

            while (PossibleNumberOfPiecesToSolve != 0)
            {
                SolveNextCorner();
            }
        }

        public  void FindPieceToSolve()
        {
            CornerColor[9] = colors_on_twist;
            log("current orientation of piece in A position is " + colors_on_twist);

            if (!SolvedPieces.Contains("TBR"))
            {
                loc = "B";
                twist_buff = "B"; //we use "loc" here because we need to know if we're shooting to ANY sticker on buffer piece
                log(loc + " is not solved. Shooting to " + loc);
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    log("We are trying to shoot to a piece that is twisted in place....");
                    Console.ResetColor();
                    specialtwistedloccase = true;
                }
                return;
            }
            if (!SolvedPieces.Contains("TFR"))
            {
                loc = "C";
                log(loc + " is not solved. Shooting to " + loc);
                twist_buff = loc;
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    log("We are trying to shoot to a piece that is twisted in place....");
                    specialtwistedloccase = true;
                }
                return;
            }
            if (!SolvedPieces.Contains("TFL"))
            {
                loc = "D";
                log(loc + " is not solved. Shooting to " + loc);
                twist_buff = loc;
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    log("We are trying to shoot to a piece that is twisted in place....");
                    specialtwistedloccase = true;
                }
                return;
            }
            if (!SolvedPieces.Contains("BFL"))
            {
                loc = "L";
                log(loc + " is not solved. Shooting to " + loc);
                twist_buff = loc;
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    log("We are trying to shoot to a piece that is twisted in place....");
                    specialtwistedloccase = true;
                }
                return;
            }
            if (!SolvedPieces.Contains("BFR"))
            {
                loc = "K";
                log(loc + " is not solved. Shooting to " + loc);
                twist_buff = loc;
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    log("We are trying to shoot to a piece that is twisted in place....");
                    specialtwistedloccase = true;
                }
                return;
            }
            if (!SolvedPieces.Contains("BBR"))
            {
                loc = "W";
                log(loc + " is not solved. Shooting to " + loc);
                twist_buff = loc;
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    log("We are trying to shoot to a piece that is twisted in place....");
                    specialtwistedloccase = true;
                }
                return;
            }
            if (!SolvedPieces.Contains("BBL"))
            {
                loc = "X";
                log(loc + " is not solved. Shooting to " + loc);
                twist_buff = loc;
                CheckIfLocIsTwisted(loc);
                if (locistwisted)
                {
                    log("We are trying to shoot to a piece that is twisted in place....");
                    specialtwistedloccase = true;
                }
                return;
            }
        }


        public  void CheckIfLocIsTwisted(string loc)
        {
            log(Environment.NewLine);
            log("checking if loc is twisted... loc is now " + loc);
            log(Environment.NewLine);
            if (loc == "B")
            {
                if (twisted.Contains("TBR"))
                {
                    locistwisted = true;
                }
            }
            if (loc == "C")
            {
                if (twisted.Contains("TFR"))
                {
                    locistwisted = true;
                }
            }
            if (loc == "D")
            {
                if (twisted.Contains("TFL"))
                {
                    locistwisted = true;
                }
            }
            if (loc == "L")
            {
                if (twisted.Contains("BFL"))
                {
                    locistwisted = true;
                }
            }
            if (loc == "K")
            {
                if (twisted.Contains("BFR"))
                {
                    locistwisted = true;
                }
            }
            if (loc == "W")
            {
                if (twisted.Contains("BBR"))
                {
                    locistwisted = true;
                }
            }
            if (loc == "X")
            {
                if (twisted.Contains("BBL"))
                {
                    locistwisted = true;
                }
            }
        }

        public  string FindSetupMoves(string loc)
        {
            if (loc == "A")
            {
                setup = "";
                und = "";
            }
            if (loc == "B")
            {
                setup = "R D'";
                und = "D R'";
            }
            if (loc == "C")
            {
                setup = "F";
                und = "F'";
            }
            if (loc == "D")
            {
                setup = "L D L'";
                und = "L D' L'";
            }
            if (loc == "E")
            {
                setup = "";
                und = "";
                log("ERR: Buffer belongs in a buffer position (twisted buffer or need new cycle)");
                Environment.Exit(1);
            }
            if (loc == "F")
            {
                setup = "F2";
                und = "F2";
            }
            if (loc == "G")
            {
                setup = "D2 R";
                und = "R' D2";
            }
            if (loc == "H")
            {
                setup = "D2";
                und = "D2";
            }
            if (loc == "I")
            {
                setup = "F' D";
                und = "D' F";
            }
            if (loc == "J")
            {
                setup = "F2 D";
                und = "D' F2";
            }
            if (loc == "K")
            {
                setup = "F D";
                und = "D' F'";
            }
            if (loc == "L")
            {
                setup = "D";
                und = "D'";
            }
            if (loc == "M")
            {
                setup = "R'";
                und = "R";
            }
            if (loc == "N")
            {
                setup = "R2";
                und = "R2";
            }
            if (loc == "O")
            {
                setup = "R";
                und = "R'";
            }
            if (loc == "P")
            {
                setup = "";
                und = "";
            }
            if (loc == "Q")
            {
                setup = "R' F";
                und = "F' R";
            }
            if (loc == "R")
            {
                setup = "";
                und = "";
                log("ERR: Buffer belongs in a buffer position (twisted buffer or need new cycle)");
                Environment.Exit(1);
            }
            if (loc == "S")
            {
                setup = "D' R";
                und = "R' D";
            }
            if (loc == "T")
            {
                setup = "D'";
                und = "D";
            }
            if (loc == "U")
            {
                setup = "F'";
                und = "F";
            }
            if (loc == "V")
            {
                setup = "D' F'";
                und = "F D";
            }
            if (loc == "W")
            {
                setup = "D2 F'";
                und = "F D2";
            }
            if (loc == "X")
            {
                setup = "D F'";
                und = "F D'";
            }

            return setup;
        }

        public  void AddToSolvedPieces(string loc)
        {
            if (loc == "B" || loc == "N" || loc == "Q")
            {
                SolvedPieces.Add("TBR");
            }
            if (loc == "C" || loc == "M" || loc == "J")
            {
                SolvedPieces.Add("TFR");
            }
            if (loc == "D" || loc == "F" || loc == "I")
            {
                SolvedPieces.Add("TFL");
            }
            if (loc == "U" || loc == "G" || loc == "L")
            {
                SolvedPieces.Add("BFL");
            }
            if (loc == "V" || loc == "P" || loc == "K")
            {
                SolvedPieces.Add("BFR");
            }
            if (loc == "W" || loc == "O" || loc == "T")
            {
                SolvedPieces.Add("BBR");
            }
            if (loc == "X" || loc == "H" || loc == "S")
            {
                SolvedPieces.Add("BBL");
            }
        }

        public  void RemoveFromSolvedPieces(string oldloc)
        {
            if (loc == "B" || loc == "N" || loc == "Q")
            {
                SolvedPieces.Remove("TBR");
            }
            if (loc == "C" || loc == "M" || loc == "J")
            {
                SolvedPieces.Remove("TFR");
            }
            if (loc == "D" || loc == "F" || loc == "I")
            {
                SolvedPieces.Remove("TFL");
            }
            if (loc == "U" || loc == "G" || loc == "L")
            {
                SolvedPieces.Remove("BFL");
            }
            if (loc == "V" || loc == "P" || loc == "K")
            {
                SolvedPieces.Remove("BFR");
            }
            if (loc == "W" || loc == "O" || loc == "T")
            {
                SolvedPieces.Remove("BBR");
            }
            if (loc == "X" || loc == "H" || loc == "S")
            {
                SolvedPieces.Remove("BBL");
            }
        }

        public  void SolveNextCorner()
        {
            pcs = null;
            for (int i = 0; i < 8; i++)
            {
                pcs += current[i];
            } //log(pcs);
            if (pcs == "WOBWRBWRGWOGYOGYRGYRBYOB")
            {
                solved();
            }

            oldpiece = loc;
            FindNextPiece(loc); //find the colors of the piece in the position we just shot to, and store it in `targetcolor`
            CornerColor[8] = targetcolor; //Store `targetcolor` as CornerColor[8]
            FindWherePieceBelongs(CornerColor[8]); //find where CornerColor[8] belongs, or where the piece we just shot to belongs
            newpiece = loc;

            updatecurrent();


            log("piece we just shot to belongs in [loc = " + loc + "]");
            FindSetupMoves(loc); //find setup moves for that piece
            PossibleNumberOfPiecesToSolve--;
            depth_label.Text = "Depth: " + PossibleNumberOfPiecesToSolve;
            log(PossibleNumberOfPiecesToSolve.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            log("Corner Solution: " + setup + " " + YPerm + " " + und); //print solution for that piece
            solution_box.AppendText(setup + " " + YPerm + " " + und);
            solution_box.AppendText(Environment.NewLine);
            Console.ResetColor();
            AddToSolvedPieces(loc);
            solutions.Add(setup + " " + YPerm + " " + und);
            log("We have solved: ");
            SolvedPieces.ToList().ForEach(i => log_box.AppendText("   " + i));
            log(Environment.NewLine);

            if (ShootingToBuffer(loc))
            {
                log("We just shot to the buffer. Cube is either solved or needs new cycle.");

                Console.WriteLine("  We have to solve " + PossibleNumberOfPiecesToSolve + " pieces");
                if (PossibleNumberOfPiecesToSolve > 0)
                {
                    Console.Beep();
                    log("the buffer is solved, yet we still have other pieces that aren't solved yet.");
                    pcs = null;
                    for (int i = 0; i < 8; i++)
                    {
                        pcs += current[i];
                    }
                    log("current cubestring is: " + pcs);
                    log("rerunning cubebot based on current (tracked) cubestring to solve remaining corners");
                    cubestring = pcs;


                    //prepwork
                    //SolvedPieces.Re(0, SolvedPieces.Count);
                    //twisted.RemoveRange(0, twisted.Count);

                    alg(); //start program over again with updated cubestring!!!
                }
            }

            if (PossibleNumberOfPiecesToSolve == 0)
            {
                solved();
            }
        }

        public  void FindNextPiece(string loc)
        {
            if (loc == "A" || loc == "E" || loc == "R")
            {
                if (posa != "W")
                {
                    //either solved or we need to start a new cycle (or twisted buffer)
                }
            }
            //if (solved)
            //{
            //   log("cube is solved");
            //  Environment.Exit(0);
            //}

            log("finding next piece... loc is " + loc);

            //log(posf + posd + posi);


            //if (loc == twist_buff) //if we are shooting to where we shot in case of a twisted buffer
            //{
            //  times_shot++;
            //if (times_shot == 1) //TRY CHANGING TO 1 seems doesn't trigger when actaully shooting to it fi this


            //do if shooting to new buffer and pieces remaining != 0 then buffer is solved but other pieces aren't so shoot to new position like a cornertwist
            //{
            //log("We are shooting to where we shot the buffer because of a twisted corner");
            //  loc = twist_buff;
            // targetcolor = colors_on_twist;
            //times_shot = 0;
            //}
            //}


            if (loc == "B")
            {
                targetcolor = posb + posn + posq;
            }
            if (loc == "C")
            {
                targetcolor = posc + posm + posj;
            }
            if (loc == "D")
            {
                targetcolor = posd + posf + posi;
            }
            if (loc == "F")
            {
                targetcolor = posf + posd + posi;
                //log(f + d + i);
            }
            if (loc == "G")
            {
                targetcolor = posg + posu + posl;
            }
            if (loc == "H")
            {
                targetcolor = posh + posx + poss;
            }
            if (loc == "I")
            {
                targetcolor = posi + posd + posf;
            }
            if (loc == "J")
            {
                targetcolor = posj + posc + posm;
            }
            if (loc == "K")
            {
                targetcolor = posk + posp + posv;
            }
            if (loc == "L")
            {
                targetcolor = posl + posg + posu;
            }
            if (loc == "M")
            {
                targetcolor = posm + posc + posj;
            }
            if (loc == "N")
            {
                targetcolor = posn + posb + posq;
            }
            if (loc == "O")
            {
                targetcolor = poso + post + posw;
            }
            if (loc == "P")
            {
                targetcolor = posp + posk + posv;
            }
            if (loc == "Q")
            {
                targetcolor = posq + posb + posn;
            }
            if (loc == "S")
            {
                targetcolor = poss + posh + posx;
            }
            if (loc == "T")
            {
                targetcolor = post + poso + posw;
            }
            if (loc == "U")
            {
                targetcolor = posu + posl + posg;
            }
            if (loc == "V")
            {
                targetcolor = posv + posk + posp;
            }
            if (loc == "W")
            {
                targetcolor = posw + poso + post;
            }
            if (loc == "X")
            {
                targetcolor = posx + posh + poss;
            }

            log("next piece to solve is " + targetcolor);
            oldloc = loc;
            log("loc of previous piece is " + oldloc);
        }

        public  bool ShootingToBuffer(string loc)
        {
            if (twist_buff == "B") //if our new buffer that we shot to is on the piece where sticker B resides
            {
                if (loc == "B" || loc == "N" || loc == "Q") //and if we are shooting to any piece on that buffer
                {
                    return true; //then yes, we are shooting to the buffer and the buffer is now solved (meaning either the cube is solved or we have a solved buffer but pieceslefttosolve > 0 so we still have some pieces left to solve (nned new cycle)
                }
            }
            if (twist_buff == "C")
            {
                if (loc == "C" || loc == "M" || loc == "J")
                {
                    return true;
                }
            }
            if (twist_buff == "D")
            {
                if (loc == "D" || loc == "F" || loc == "I")
                {
                    return true;
                }
            }
            if (twist_buff == "L")
            {
                if (loc == "L" || loc == "G" || loc == "U")
                {
                    return true;
                }
            }
            if (twist_buff == "K")
            {
                if (loc == "K" || loc == "P" || loc == "V")
                {
                    return true;
                }
            }
            if (twist_buff == "W")
            {
                if (loc == "W" || loc == "O" || loc == "T")
                {
                    return true;
                }
            }
            if (twist_buff == "X")
            {
                if (loc == "X" || loc == "H" || loc == "S")
                {
                    return true;
                }
            }
            return false; //if none of the above, return false
        }

        public  void FindUnsolvedPieces()
        {
            if (!SolvedPieces.Contains("TBL"))
            {
                UnsolvedPieces.Add("TBL");
            }
            if (!SolvedPieces.Contains("TBR"))
            {
                UnsolvedPieces.Add("TBR");
            }
            if (!SolvedPieces.Contains("TFR"))
            {
                UnsolvedPieces.Add("TFR");
            }
            if (!SolvedPieces.Contains("TFL"))
            {
                UnsolvedPieces.Add("TFL");
            }
            if (!SolvedPieces.Contains("BFL"))
            {
                UnsolvedPieces.Add("BFR");
            }
            if (!SolvedPieces.ToString().Contains("BBR"))
            {
                UnsolvedPieces.Add("BBR");
            }
            if (!SolvedPieces.ToString().Contains("BBL"))
            {
                UnsolvedPieces.Add("BBL");
            }
        }

        private void solved()
        {
            pcs = null;
            for (int i = 0; i < 8; i++)
            {
                //log(current[i]);
                pcs += current[i];
            }
            //log(pcs);
            if (pcs == "WOBWRBWRGWOGYOGYRGYRBYOB")
            {
                stopwatch.Stop();
                stopwatch1.Stop();
                log(Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("  Your cube is solved in exactly  {0}  seconds", stopwatch.Elapsed);
                Console.Beep();
                log("YOUR CUBE IS SOLVED!");
                log(Environment.NewLine);
                //solutions.ToList().ForEach(i => log_box.AppendText("  " + i + Environment.NewLine));
                Console.ResetColor();
                timer1.Stop();
                Thread.CurrentThread.Abort();
            }
            else
            {
                log(pcs);
                err("something has gone horribly wrong... cube seems to be solved, yet our piece tracker says otherwise... please file a bug as this is a major bug.");
            }
        }
        private void err(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            log(text);
            Console.ResetColor();
        }
    }
}
