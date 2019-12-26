using AForge.Imaging;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TapScreen
{
    public partial class MainForm : Form
    {
        Thread thread;

        public float ScreenScale
        {
            get
            {
                return 1.0f;
                // return btnx05.Enabled ? 1.0f : 0.5f;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            btnStop.Enabled = false;
            numSensability.Value = 80;
            btnx05.Enabled = false;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = false;
            btnStop.Enabled = true;

            thread = new Thread(new ThreadStart(ThreadDisplay));
            thread.IsBackground = true;
            thread.Start();
        }

        private void ThreadDisplay()
        {
            var adb = new Process();
            adb.StartInfo.FileName = "adb.exe";
            adb.StartInfo.UseShellExecute = false;
            adb.StartInfo.CreateNoWindow = true;
            adb.StartInfo.RedirectStandardError = true;
            adb.StartInfo.RedirectStandardInput = true;
            adb.StartInfo.RedirectStandardOutput = true;

            try
            {
                while (true)
                {
                    adb.StartInfo.Arguments = "shell screencap sdcard/screen.png";
                    adb.Start();
                    adb.WaitForExit();

                    adb.StartInfo.Arguments = "pull sdcard/screen.png";
                    adb.Start();
                    adb.WaitForExit();

                    using (var fs = new System.IO.FileStream("screen.png", System.IO.FileMode.Open))
                    {
                        var bitmap = new Bitmap(fs);
                        screen.BeginInvoke(new Action(() => screen.Image = bitmap));

                        var files = System.IO.Directory.GetFiles(string.Format("{0}/", txtName.Text));
                        foreach (var file in files)
                        {
                            var saved = new Bitmap(file);
                            float sensability = (float)numSensability.Value * 0.01f;
                            if (CompareImages(bitmap, saved, sensability, 0.9f))
                            {
                                var pos = System.IO.Path.GetFileNameWithoutExtension(file);
                                Tap(pos);
                            }
                        }
                    }

                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                adb.Close();
                adb.Dispose();

                btnPlay.BeginInvoke(new Action(() => btnPlay.Enabled = true));
                btnStop.BeginInvoke(new Action(() => btnStop.Enabled = false));

                MessageBox.Show(e.ToString());

                if (!(e is ThreadAbortException))
                    Play_Click(null, null);
            }
        }

        public Boolean CompareImages(Bitmap bmp1, Bitmap bmp2, double compareLevel, float similarityThreshold)
        {
            var newBitmap1 = ChangePixelFormat(new Bitmap(bmp1), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var newBitmap2 = ChangePixelFormat(new Bitmap(bmp2), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            var tm = new ExhaustiveTemplateMatching(similarityThreshold);
            var results = tm.ProcessImage(newBitmap1, newBitmap2);
            if (results.Length <= 0)
            {
                return false;
            }
            var match = results[0].Similarity >= compareLevel;
            return match;
        }

        private Bitmap ChangePixelFormat(Bitmap inputImage, System.Drawing.Imaging.PixelFormat newFormat)
        {
            return (inputImage.Clone(new Rectangle(0, 0, inputImage.Width, inputImage.Height), newFormat));
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            btnPlay.Enabled = true;
            btnStop.Enabled = false;

            thread.Abort();
            thread = null;
        }

        private void Sensability_Changed(object sender, EventArgs e)
        {

        }

        private void SizeX05_Click(object sender, EventArgs e)
        {
            btnx05.Enabled = false;
            btnx1.Enabled = true;
        }

        private void Sizex1_Click(object sender, EventArgs e)
        {
            btnx05.Enabled = true;
            btnx1.Enabled = false;
        }

        private void Screen_Click(object sender, EventArgs e)
        {
            var me = e as MouseEventArgs;

            if (!System.IO.Directory.Exists(txtName.Text))
                System.IO.Directory.CreateDirectory(txtName.Text);

            var pos = $"{(int)(me.X / ScreenScale)} {(int)(me.Y / ScreenScale)}";
            var bmp = new Bitmap(screen.Image);
            bmp.Save(string.Format("{0}/{1}.png", txtName.Text, pos));
            Tap(pos);
        }

        private void Tap(string pos)
        {
            var adb = new Process();
            adb.StartInfo.FileName = "adb.exe";
            adb.StartInfo.UseShellExecute = false;
            adb.StartInfo.CreateNoWindow = true;
            adb.StartInfo.RedirectStandardError = true;
            adb.StartInfo.RedirectStandardInput = true;
            adb.StartInfo.RedirectStandardOutput = true;

            adb.StartInfo.Arguments = string.Format("shell input touchscreen tap {0}", pos);

            adb.Start();
            adb.WaitForExit();
            adb.Close();
            adb.Dispose();
        }
    }
}
