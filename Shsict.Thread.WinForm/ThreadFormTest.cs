using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shsict.Thread.WinForm
{
    public partial class ThreadFormTest : Form
    {
        public ThreadFormTest()
        {
            InitializeComponent();
        }

        private void bwThreadTest_DoWork(object sender, DoWorkEventArgs e)
        {
            // This event handler is where the actual work is done.
            // This method runs on the background thread.

            // Get the BackgroundWorker object that raised this event.
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;

            // Get the Words object and call the main method.
            Words WC = (Words)e.Argument;
            WC.CountWords(worker, e);
        }

        private void StartThread()
        {
            // This method runs on the main thread.
            this.tbWordCounts.Text = "0";

            // Initialize the object that the background worker calls.
            Words WC = new Words();
            WC.CompareString = this.tbCompareString.Text;
            WC.SourceFile = this.tbSourceFile.Text;

            // Start the asynchronous operation.
            bwThreadTest.RunWorkerAsync(WC);
        }

        private void bwThreadTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This event handler is called when the background thread finishes.
            // This method runs on the main thread.
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else if (e.Cancelled)
                MessageBox.Show("Word counting canceled.");
            else
                MessageBox.Show("Finished counting words.");
        }

        private void bwThreadTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This method runs on the main thread.
            Words.CurrentState state =
                (Words.CurrentState)e.UserState;
            this.tbLineCounts.Text = state.LinesCounted.ToString();
            this.tbWordCounts.Text = state.WordsMatched.ToString();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartThread();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.bwThreadTest.CancelAsync();
        }
    }
}
