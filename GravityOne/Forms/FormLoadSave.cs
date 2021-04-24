using GravityOne.Gravity;
using GravityOne.SpaceObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace GravityOne.Forms
{
    public partial class FormLoadSave : Form
    {
        private FormMain myParent = null;
        private List<Recording> Recordings = new List<Recording>();
        NumberFormatInfo providerDecimalPoint = new NumberFormatInfo();
        const string VERSION_NUMBER_RECORDINGS = "1.5";

        public FormLoadSave()
        {
            InitializeComponent();
            providerDecimalPoint.NumberDecimalSeparator = ".";
        }

        public FormMain MyParent
        {
            get
            {
                return myParent;
            }

            set
            {
                myParent = value;
            }
        }

        private void gradientButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gradientButtonLoadSave_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("Save"))
            {
                if (textBoxName.Text.Length == 0)
                {
                    MessageBox.Show("You must use a name!");
                    return;
                }
                else
                {
                    SaveRecording();
                }
            }
            if (this.Text.Equals("Load"))
            {
                if (textBoxName.Text.Length == 0)
                {
                    MessageBox.Show("You must select a file!");
                    return;
                }
                else
                {
                    LoadRecording();
                }
            }
            Close();
        }

        private Int32 GetStreamPosition(StreamReader s)
        {
            Int32 charpos = (Int32)s.GetType().InvokeMember("charPos", BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField, null, s, null);

            return charpos;
        }

        private void LoadCompressedData(string FileName, int numObjects, int calcs_per_unit_index, int calculationsPerStepPrecalculated, int totalCalculationsInRecording)
        {
            using (ZipArchive archive = ZipFile.OpenRead(FileName + "_data"))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Equals("objectdata"))
                    {
                        using (var stream = new StreamReader(entry.Open()))
                        {
                            for (int k = 0; k < numObjects; k++)
                            {
                                string name = stream.ReadLine();
                                string textureName = stream.ReadLine();
                                Microsoft.Xna.Framework.Color color = StringToColor(stream.ReadLine());
                                double mass = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                bool trace = Convert.ToBoolean(stream.ReadLine());
                                bool vector = Convert.ToBoolean(stream.ReadLine());
                                double x = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                double y = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                double xSpeed = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                double ySpeed = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                bool scaleObject = Convert.ToBoolean(stream.ReadLine());
                                myParent.DisplayXNA.GravitySystem.AddObject(name, mass, x, y, xSpeed, ySpeed, myParent.DisplayXNA.GetTextureByName(textureName), color, trace, vector, scaleObject);
                            }

                            myParent.DisplayXNA.GravitySystem.InitCalculation();
                            if (!stream.EndOfStream)    // if there is a calculation, load and start it
                            {
                                for (int k = 0; k < numObjects; k++)
                                {
                                    myParent.DisplayXNA.GravitySystem.CalculationInitialSpeeds[k].X = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                    myParent.DisplayXNA.GravitySystem.CalculationInitialSpeeds[k].Y = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                }
                                for (int k = 0; k < numObjects; k++)
                                {
                                    myParent.DisplayXNA.GravitySystem.CalculationCurrentSpeeds[k].X = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                    myParent.DisplayXNA.GravitySystem.CalculationCurrentSpeeds[k].Y = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                }
                                for (int i = 0; i <= totalCalculationsInRecording; i++)
                                {
                                    progressBarLoadSave.Value = (int)(100 * i / (double)totalCalculationsInRecording);
                                    progressBarLoadSave.Invalidate();

                                    for (int k = 0; k < numObjects; k++)
                                    {
                                        myParent.DisplayXNA.GravitySystem.Calculation[i][k].X = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                        myParent.DisplayXNA.GravitySystem.Calculation[i][k].Y = Convert.ToDouble(stream.ReadLine(), providerDecimalPoint);
                                    }
                                }
                                myParent.DisplayXNA.GravitySystem.StartCalculation();
                            }
                        }
                    }
                }
            }
        }

        private Microsoft.Xna.Framework.Color StringToColor(string color)
        {
            if(color.Equals("Red"))
            {
                return Microsoft.Xna.Framework.Color.Red;
            }
            if (color.Equals("Green"))
            {
                return Microsoft.Xna.Framework.Color.Green;
            }
            if (color.Equals("Blue"))
            {
                return Microsoft.Xna.Framework.Color.Blue;
            }
            if (color.Equals("Yellow"))
            {
                return Microsoft.Xna.Framework.Color.Yellow;
            }

            return Microsoft.Xna.Framework.Color.White;
        }

        private string ColorToString(Microsoft.Xna.Framework.Color color)
        {
            if(color.Equals(Microsoft.Xna.Framework.Color.Red))
            {
                return "Red";
            }
            if (color.Equals(Microsoft.Xna.Framework.Color.Green))
            {
                return "Green";
            }
            if (color.Equals(Microsoft.Xna.Framework.Color.Blue))
            {
                return "Blue";
            }
            if (color.Equals(Microsoft.Xna.Framework.Color.Yellow))
            {
                return "Yellow";
            }
            return "White";
        }

        private void LoadRecording()
        {
            Recording rec = (Recording)listBoxRecordings.SelectedItem;
            var lines = File.ReadLines(rec.FileName).Take(4).ToArray();

            using (StreamReader srFile = new StreamReader(rec.FileName))
            {
                string version = srFile.ReadLine();      // version
                string versionNumber = version.Substring(1);
                if(!versionNumber.Equals(VERSION_NUMBER_RECORDINGS))
                {
                    MessageBox.Show("The recording you are trying to load is of version " + versionNumber + ". Only recordings of version " + VERSION_NUMBER_RECORDINGS + " can be loaded by this program.", "Older version recording");
                    return;
                }

                panelBusy.Visible = true;
                Refresh();
                myParent.DisplayXNA.GravitySystem.StopCalculation();

                srFile.ReadLine();      // name
                srFile.ReadLine();      // savedate

                int numObjects = Convert.ToInt32(srFile.ReadLine());
                int calculationsPerStepPrecalculated = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.TargetFrameRate = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.PreCalculationTime = Convert.ToInt32(srFile.ReadLine());
                int frameNumberCalc = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.FrameNumberPlay = 0;
                int calcs_per_unit_index = Convert.ToInt32(srFile.ReadLine());      // triggers the pre-calculation, so postpone until previous calcs are loaded
                myParent.macTrackBarSpeed.Value = Convert.ToInt32(srFile.ReadLine());
                myParent.macTrackBarScale.Value = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.ObjectIndex = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.CenterIndex = Convert.ToInt32(srFile.ReadLine());
                string date = srFile.ReadLine();
                myParent.DisplayXNA.SimulationTime = long.Parse(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.OffsetX = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.OffsetY = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.Scale = Convert.ToInt64(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.CalculationsPerStepSetting = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.SecondsPerStepSolarSystem = Convert.ToInt64(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.UseBarnesHut = Convert.ToBoolean(srFile.ReadLine());
                myParent.DisplayXNA.GravitySystem.QuadTree.Treshold = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                myParent.DisplayXNA.BlendState = myParent.ConvertToBlendState(srFile.ReadLine());
                myParent.DisplayXNA.CustomShape.PixelSize = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.CustomShape.Type = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.CustomShape.Alpha = Convert.ToInt32(srFile.ReadLine());
                myParent.DisplayXNA.CustomShape.RandomSize = Convert.ToBoolean(srFile.ReadLine());
                myParent.DisplayXNA.CustomShape.RandomColor = Convert.ToBoolean(srFile.ReadLine());
                bool compressed = Convert.ToBoolean(srFile.ReadLine());

                int totalCalculationsInRecording = frameNumberCalc;
                if(calculationsPerStepPrecalculated>1)
                {
                    totalCalculationsInRecording = myParent.DisplayXNA.GravitySystem.NumPrecalculatedFrames();
                }

                myParent.DisplayXNA.GravitySystem.GravityObjects.Clear();      // clear old objects just before loading new ones.


                if (compressed)
                {
                    LoadCompressedData(rec.FileName, numObjects, calcs_per_unit_index, calculationsPerStepPrecalculated, totalCalculationsInRecording);
                }
                else
                {
                    for (int k = 0; k < numObjects; k++)
                    {
                        string name = srFile.ReadLine();
                        string textureName = srFile.ReadLine();
                        Microsoft.Xna.Framework.Color color = StringToColor(srFile.ReadLine());
                        double mass = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        bool trace = Convert.ToBoolean(srFile.ReadLine());
                        bool vector = Convert.ToBoolean(srFile.ReadLine());
                        double x = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        double y = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        double xSpeed = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        double ySpeed = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        bool scaleObject = Convert.ToBoolean(srFile.ReadLine());
                        myParent.DisplayXNA.GravitySystem.AddObject(name, mass, x, y, xSpeed, ySpeed, myParent.DisplayXNA.GetTextureByName(textureName), color, trace, vector, scaleObject);
                    }

                    myParent.DisplayXNA.GravitySystem.InitCalculation();
                    if (!srFile.EndOfStream)    // if there is a calculation, load and start it if neccesary
                    {
                        for (int k = 0; k < numObjects; k++)
                        {
                            myParent.DisplayXNA.GravitySystem.CalculationInitialSpeeds[k].X = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                            myParent.DisplayXNA.GravitySystem.CalculationInitialSpeeds[k].Y = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        }
                        for (int k = 0; k < numObjects; k++)
                        {
                            myParent.DisplayXNA.GravitySystem.CalculationCurrentSpeeds[k].X = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                            myParent.DisplayXNA.GravitySystem.CalculationCurrentSpeeds[k].Y = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                        }
                        for (int i = 0; i <= totalCalculationsInRecording; i++)
                        {
                            progressBarLoadSave.Value = (int)(100 * i / (double)totalCalculationsInRecording);
                            progressBarLoadSave.Invalidate();
                            
                            for (int k = 0; k < numObjects; k++)
                            {
                                myParent.DisplayXNA.GravitySystem.Calculation[i][k].X = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                                myParent.DisplayXNA.GravitySystem.Calculation[i][k].Y = Convert.ToDouble(srFile.ReadLine(), providerDecimalPoint);
                            }
                        }
                        myParent.DisplayXNA.GravitySystem.StartCalculation();
                    }
                }
                myParent.DisplayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy = calculationsPerStepPrecalculated;      // lost with InitCalculation()
                myParent.DisplayXNA.GravitySystem.FrameNumberCalc = frameNumberCalc;      // lost with InitCalculation()
                myParent.DisplayXNA.GravitySystem.DetermineCalculationsPerStepActual();
                myParent.DisplayXNA.GravitySystem.ScaleObjects();
                // perform calculation to show right vectors
                myParent.DisplayXNA.GravitySystem.CalculateStep(0, false);
                myParent.UpdateObjectProperties();
                myParent.DisplayXNA.GravitySystem.ObtainMinMaxValues();
                myParent.DisplayXNA.updateCustomShapes();
                myParent.DisplayXNA.Rewind();
                myParent.DisplayXNA.GravitySystem.DisplayFrame();
            }
        }

        private bool SaveRecording()
        {
            string FileName = CurrentRecordingFilename();

            if (FileName != null)        // file exists
            {
                DialogResult result = MessageBox.Show("That name already exists. Do you want to overwrite it?", "Existing recording", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    File.Delete(CurrentRecordingFilename() + "_data");      // delete compressed data if it exists
                }
            }
            else
            {
                FileName = FindUniqueFileName(myParent.SaveDir, "recording.grv1");
            }
            panelBusy.Visible = true;
            Refresh();
            myParent.DisplayXNA.GravitySystem.StopCalculation();
            myParent.DisplayXNA.Rewind();

            using (StreamWriter srFile = new StreamWriter(FileName))
            {
                srFile.WriteLine("v"+VERSION_NUMBER_RECORDINGS);
                srFile.WriteLine(textBoxName.Text);
                srFile.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.GravityObjects.Count);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.CalculationsPerStepPrecalculatedGalaxy);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.TargetFrameRate);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.PreCalculationTime);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.FrameNumberCalc);
                srFile.WriteLine(myParent.macTrackBarSpeed.Value.ToString());
                srFile.WriteLine(myParent.macTrackBarScale.Value.ToString());
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.ObjectIndex);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.CenterIndex);
                srFile.WriteLine(myParent.DisplayXNA.SimulationTime);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.OffsetX);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.OffsetY);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.Scale);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.CalculationsPerStepSetting);
                srFile.WriteLine(myParent.DisplayXNA.SecondsPerStepSolarSystem);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.UseBarnesHut);
                srFile.WriteLine(myParent.DisplayXNA.GravitySystem.QuadTree.Treshold.ToString(providerDecimalPoint));
                srFile.WriteLine(myParent.DisplayXNA.BlendState);
                srFile.WriteLine(myParent.DisplayXNA.CustomShape.PixelSize);
                srFile.WriteLine(myParent.DisplayXNA.CustomShape.Type);
                srFile.WriteLine(myParent.DisplayXNA.CustomShape.Alpha);
                srFile.WriteLine(myParent.DisplayXNA.CustomShape.RandomSize);
                srFile.WriteLine(myParent.DisplayXNA.CustomShape.RandomColor);
                srFile.WriteLine(myParent.CompressRecordings);
                srFile.Flush();
                if (myParent.CompressRecordings)
                {
                    //                    byte[] compressedBytes = CreateCompressedData();
                    //                    srFile.BaseStream.Write(compressedBytes, 0, compressedBytes.Length);
                    SaveCompressedData(FileName);
                }
                else
                {
                    foreach (GravityObject o in myParent.DisplayXNA.GravitySystem.GravityObjects)
                    {
                        srFile.WriteLine(o.Name);
                        srFile.WriteLine(o.Texture.Name);
                        srFile.WriteLine(ColorToString(o.Color));
                        srFile.WriteLine(o.Mass.ToString(providerDecimalPoint));
                        srFile.WriteLine(o.Trace);
                        srFile.WriteLine(o.Vector);
                        srFile.WriteLine(o.X.ToString(providerDecimalPoint));
                        srFile.WriteLine(o.Y.ToString(providerDecimalPoint));
                        srFile.WriteLine(o.XSpeed.ToString(providerDecimalPoint));
                        srFile.WriteLine(o.YSpeed.ToString(providerDecimalPoint));
                        srFile.WriteLine(o.ScaleTexture);
                    }

                    if (myParent.DisplayXNA.GravitySystem.Calculation != null)
                    {
                        foreach (Vector speed in myParent.DisplayXNA.GravitySystem.CalculationInitialSpeeds)
                        {
                            srFile.WriteLine(speed.X.ToString(providerDecimalPoint));
                            srFile.WriteLine(speed.Y.ToString(providerDecimalPoint));
                        }
                        foreach (Vector speed in myParent.DisplayXNA.GravitySystem.CalculationCurrentSpeeds)
                        {
                            srFile.WriteLine(speed.X.ToString(providerDecimalPoint));
                            srFile.WriteLine(speed.Y.ToString(providerDecimalPoint));
                        }
                        for (int i = 0; i <= myParent.DisplayXNA.GravitySystem.NumPrecalculatedFrames(); i++)
                        {
                            progressBarLoadSave.Value = (int)(100 * i / (double)myParent.DisplayXNA.GravitySystem.NumPrecalculatedFrames());
                            progressBarLoadSave.Invalidate();
                            for (int k = 0; k < myParent.DisplayXNA.GravitySystem.GravityObjects.Count; k++)
                            {
                                Object2D myCalc = myParent.DisplayXNA.GravitySystem.Calculation[i][k];
                                srFile.WriteLine(myCalc.X.ToString(providerDecimalPoint));
                                srFile.WriteLine(myCalc.Y.ToString(providerDecimalPoint));
                            }
                        }
                    }
                }
            }
            myParent.DisplayXNA.GravitySystem.StartCalculation();

            return true;
        }

        public void SaveCompressedData(string FileName)
        {
            using (FileStream zipToOpen = new FileStream(FileName + "_data", FileMode.CreateNew))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry("objectdata");
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        foreach (GravityObject o in myParent.DisplayXNA.GravitySystem.GravityObjects)
                        {
                            writer.WriteLine(o.Name);
                            writer.WriteLine(o.Texture.Name);
                            writer.WriteLine(ColorToString(o.Color));
                            writer.WriteLine(o.Mass.ToString(providerDecimalPoint));
                            writer.WriteLine(o.Trace);
                            writer.WriteLine(o.Vector);
                            writer.WriteLine(o.X.ToString(providerDecimalPoint));
                            writer.WriteLine(o.Y.ToString(providerDecimalPoint));
                            writer.WriteLine(o.XSpeed.ToString(providerDecimalPoint));
                            writer.WriteLine(o.YSpeed.ToString(providerDecimalPoint));
                            writer.WriteLine(o.ScaleTexture);
                        }

                        if (myParent.DisplayXNA.GravitySystem.Calculation != null)
                        {
                            foreach (Vector speed in myParent.DisplayXNA.GravitySystem.CalculationInitialSpeeds)
                            {
                                writer.WriteLine(speed.X.ToString(providerDecimalPoint));
                                writer.WriteLine(speed.Y.ToString(providerDecimalPoint));
                            }
                            foreach (Vector speed in myParent.DisplayXNA.GravitySystem.CalculationCurrentSpeeds)
                            {
                                writer.WriteLine(speed.X.ToString(providerDecimalPoint));
                                writer.WriteLine(speed.Y.ToString(providerDecimalPoint));
                            }
                            for (int i = 0; i <= myParent.DisplayXNA.GravitySystem.NumPrecalculatedFrames(); i++)
                            {
                                progressBarLoadSave.Value = (int)(100 * i / (double)myParent.DisplayXNA.GravitySystem.NumPrecalculatedFrames());
                                progressBarLoadSave.Invalidate();
                                for (int k = 0; k < myParent.DisplayXNA.GravitySystem.GravityObjects.Count; k++)
                                {
                                    Object2D myCalc = myParent.DisplayXNA.GravitySystem.Calculation[i][k];
                                    writer.WriteLine(myCalc.X.ToString(providerDecimalPoint));
                                    writer.WriteLine(myCalc.Y.ToString(providerDecimalPoint));
                                }
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Compress(Stream input)
        {
            using (var compressStream = new MemoryStream())
            using (var compressor = new DeflateStream(compressStream, CompressionMode.Compress))
            {
                input.CopyTo(compressor);
                compressor.Close();
                return compressStream.ToArray();
            }
        }

        private static MemoryStream Decompress(Stream compressedStream)
        {
            var output = new MemoryStream();

            using (var decompressor = new DeflateStream(compressedStream, CompressionMode.Decompress))
                decompressor.CopyTo(output);

            output.Position = 0;
            return output;
        }



        static FileStream CreateFile(string fullPath)
        {
            try
            {
                return new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write);
            }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (IOException)
            {
                // Will occur if another thread created a file with this 
                // name since we created the HashSet. Ignore this and just
                // try with the next filename.
            }

            return null;
        }

        static string FindUniqueFileName(string folder, string fileName, int maxAttempts = 10000)
        {
            // get filename base and extension
            var fileBase = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            // build hash set of filenames for performance
            var files = new HashSet<string>(Directory.GetFiles(folder));

            for (var index = 0; index < maxAttempts; index++)
            {
                // first try with the original filename, else try incrementally adding an index
                var name = (index == 0)
                    ? fileName
                    : String.Format("{0}{1}{2}", fileBase, index, ext);

                // check if exists
                var fullPath = Path.Combine(folder, name);
                if (files.Contains(fullPath))
                    continue;

                return fullPath;
            }

            throw new Exception("Could not create unique filename in " + maxAttempts + " attempts");
        }

        public void EnumerateRecordings()
        {
            try
            {
                var files = Directory.EnumerateFiles(myParent.SaveDir, "*.grv1", SearchOption.AllDirectories);
                Recordings.Clear();
                listBoxRecordings.Items.Clear();
                foreach (var f in files)
                {
                    Recording recording = new Recording();
                    var lines = File.ReadLines(f).Take(8).ToArray();
                    if (lines.Length == 8)
                    {
                        recording.FileName = f;
                        recording.Name = lines[1];
                        recording.Date = DateTime.ParseExact(lines[2], "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        recording.NumberOfObjects = Convert.ToInt32(lines[3]);
                        recording.CalcsDone = lines[7] + "/" + Convert.ToInt32(lines[6]) * Convert.ToInt32(lines[5]) + " (" + lines[4] + ")";
                        recording.DisplayText = recording.Name.PadRight(32, ' ') + " " + recording.Date.ToString("dd/MM/yyyy H:mm").PadRight(16, ' ') + " objects: " + recording.NumberOfObjects.ToString().PadRight(8, ' ') + " calculations: " + recording.CalcsDone.ToString().PadRight(10, ' ');
                        Recordings.Add(recording);
                        listBoxRecordings.Items.Add(recording);
                    }
                }
                Console.WriteLine("{0} files found.", files.Count().ToString());
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }

        }

        private void listBoxRecordings_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recording rec = (Recording)listBoxRecordings.SelectedItem;
            if (rec!=null)
            {
                textBoxName.Text = rec.Name;
                textBoxDate.Text = rec.Date.ToString("dd/MM/yyyy H:mm");
                textBoxNumberOfObjects.Text = rec.NumberOfObjects.ToString();
                textBoxCalcsDone.Text = rec.CalcsDone.ToString();
            }
        }

        private void listBoxRecordings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Text.Equals("Load"))
            {
                LoadRecording();
            }
            else
            {
                SaveRecording();
            }
            Close();
        }

        private string CurrentRecordingFilename()
        {
            foreach(Recording item in listBoxRecordings.Items)
            {
                if (item.Name.Equals(textBoxName.Text))
                {
                    return item.FileName;
                }
            }
            return null;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (CurrentRecordingFilename() !=null)
            {
                gradientButtonDelete.Visible = true;
            }
            else
            {
                gradientButtonDelete.Visible = false;
            }

        }

        private void gradientButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this recording?", "Delete recording", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.Delete(CurrentRecordingFilename());
                File.Delete(CurrentRecordingFilename()+"_data");
                EnumerateRecordings();
            }
        }

        private void panelBusy_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new LinearGradientBrush(this.ClientRectangle,
                       Color.White, Color.Black, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
