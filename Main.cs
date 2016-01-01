using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using CharacterRecognition.Distance;

namespace CharacterRecognition {
    public partial class Main : Form {

        private const int _downSampleWidth = 5;
        private const int _downSampleHeight = 7;

        private readonly EuclideanDistance _distCalc = new EuclideanDistance();
        private readonly Graphics _entryGraphics;
        private readonly Bitmap _entryImage;
        private readonly Pen _blackPen;
        private readonly Dictionary<char, double[]> _letterDictionary = new Dictionary<char, double[]>();

        private double[] _downSampled;
        private int _lastEntryX, _lastEntryY;

        public Main() {
            InitializeComponent();
            _blackPen = new Pen(Color.Black);
            _entryImage = new Bitmap(pnlEntry.Width, pnlEntry.Height);
            _entryGraphics = Graphics.FromImage(_entryImage);
            _downSampled = new double[_downSampleHeight * _downSampleWidth];
            ClearEntry();
        }

        private void pnlSample_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            int x, y;
            int yCell = pnlSample.Height / _downSampleHeight;
            int xCell = pnlSample.Width / _downSampleWidth;

            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            var blackPen = new Pen(Color.Black);

            g.FillRectangle(whiteBrush, 0, 0, pnlSample.Width, pnlSample.Height);

            for(y = 0; y < _downSampleHeight; y++) {
                g.DrawLine(blackPen, 0, y * yCell, pnlSample.Width, y * yCell);
            }

            for(x = 0; x < _downSampleWidth; x++) {
                g.DrawLine(blackPen, x * xCell, 0, x * xCell, pnlSample.Height);
            }

            int index = 0;
            for(y = 0; y < _downSampleHeight; y++) {
                for(x = 0; x < _downSampleWidth; x++) {
                    if(_downSampled[index++] > 0.1) {
                        g.FillRectangle(blackBrush, x*xCell, y*yCell, xCell, yCell);
                    }
                }
            }

            g.DrawRectangle(blackPen, 0, 0, pnlSample.Width - 1, pnlSample.Height - 1);
        }

        private void pnlEntry_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawImage(_entryImage, 0, 0);
            var blackPen = new Pen(Color.Black);
            g.DrawRectangle(blackPen, 0, 0, pnlEntry.Width - 1, pnlEntry.Height - 1);
        }

        private void pnlEntry_MouseDown(object sender, MouseEventArgs e) {
            pnlEntry.Capture = true;
            _lastEntryX = e.X;
            _lastEntryY = e.Y;
        }

        private void pnlEntry_MouseMove(object sender, MouseEventArgs e) {
            if(pnlEntry.Capture) {
                _entryGraphics.DrawLine(_blackPen, _lastEntryX, _lastEntryY, e.X, e.Y);
                pnlEntry.Invalidate();
                _lastEntryX = e.X;
                _lastEntryY = e.Y;
            }
        }

        private void pnlEntry_MouseUp(object sender, MouseEventArgs e) {
            _entryGraphics.DrawLine(_blackPen, _lastEntryX, _lastEntryY, e.X, e.Y);
            pnlEntry.Invalidate();
            pnlEntry.Capture = false;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var ds = new DownSample(_entryImage);
            _downSampled = ds.DoDownSampling(_downSampleWidth, _downSampleHeight);
            pnlSample.Invalidate();
            const string prompt = "The letter you drew was:";
            const string title = "Input Letter";
            const string defaultMessage = "";

            Int32 xPos = (SystemInformation.WorkingArea.Width/2) - 200;
            Int32 yPos = (SystemInformation.WorkingArea.Height/2) - 100;

            bool valid = false;
            foreach(double t in _downSampled) {
                if(t > 0.1) {
                    valid = true;
                }
            }

            if(!valid) {
                MessageBox.Show(@"Please draw a letter before adding it.");
                return;
            }

            string result = Interaction.InputBox(prompt, title, defaultMessage, xPos, yPos);
            if(result != null) {
                result = result.ToUpper();
                if(result.Length == 0) {
                    MessageBox.Show(@"Please enter a letter.");
                } else if(result.Length > 1) {
                    MessageBox.Show(@"Please only enter one letter.");
                } else if(_letterDictionary.ContainsKey(result[0])) {
                    MessageBox.Show(@"That letter is already defined. Please delete it first.");
                } else {
                    lstLetters.Items.Add(result);
                    _letterDictionary.Add(result[0], _downSampled);
                    ClearEntry();
                }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e) {
            ClearEntry();
        }

        private void btnClearList_Click(object sender, EventArgs e) {
            _letterDictionary.Clear();
            lstLetters.Items.Clear();
            ClearEntry();
        }

        private void btnRecognize_Click(object sender, EventArgs e) {
            var ds = new DownSample(_entryImage);
            _downSampled = ds.DoDownSampling(_downSampleWidth, _downSampleHeight);
            pnlSample.Invalidate();

            char bestChar = '?';
            double bestDistance = double.MaxValue;

            foreach(char c in _letterDictionary.Keys) {
                double[] data = _letterDictionary[c];
                double dist = _distCalc.Calculate(data, _downSampled);

                if(dist < bestDistance) {
                    bestDistance = dist;
                    bestChar = c;
                }
            }

            MessageBox.Show(@"The letter closely matches: " + bestChar, @"Recognize");
            ClearEntry();
        }

        private void ClearEntry() {
            Brush whiteBrush = new SolidBrush(Color.White);
            _entryGraphics.FillRectangle(whiteBrush, 0, 0, pnlEntry.Width, pnlEntry.Height);
            pnlEntry.Invalidate();
            var ds = new DownSample(_entryImage);
            _downSampled = ds.DoDownSampling(_downSampleWidth, _downSampleHeight);
            pnlSample.Invalidate();
        }
    }
}
