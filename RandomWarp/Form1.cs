using Randomizer.Randomizers;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Randomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int _RandomSeed => (int)numericUpDown2.Value;
        private int _GateRandomness => (int)numericUpDown1.Value;


        public void StartRandomize()
        {
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int TasksToComplete = 0;
            int TasksCompleted = 0;

            void reportProgress()
            {
                backgroundWorker1.ReportProgress((TasksCompleted * 100) / TasksToComplete);
            }
            void reportTaskComplete()
            {
                TasksCompleted++;
                reportProgress();
            }
            // Count tasks
            if (chkRandomizeGates.Checked) TasksToComplete++;
            if (chkRandomizeShipTypeData.Checked) TasksToComplete++;

            reportProgress();

            try
            {
                if (chkRandomizeGates.Checked)
                {
                    GateRandomizer.RandomizeGateConnections(_RandomSeed, _GateRandomness);
                    reportTaskComplete();
                }
                if (chkRandomizeShipTypeData.Checked)
                {
                    ShipRandomizer.RandomizeAllShipWeapons(_RandomSeed);
                    reportTaskComplete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception. Please see exception.txt");
                File.WriteAllText("./exception.txt", ex.ToString());
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartRandomize();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            numericUpDown2.Value = rand.Next((int)numericUpDown2.Minimum, (int)numericUpDown2.Maximum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            numericUpDown1.Value = rand.Next((int)numericUpDown1.Minimum, (int)numericUpDown1.Maximum);
        }
    }
}
