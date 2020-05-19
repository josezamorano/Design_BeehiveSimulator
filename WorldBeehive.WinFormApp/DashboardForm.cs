using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WorldBeehive.WinFormApp
{
    public partial class DashboardForm : Form
    {
        private int _initialLocationX = 10;
        private int _initialLocationY = 90;
        private int dashboardFormWidth;
        private int dashboardFormLocationY;
        private int moveDownForm = 230;
        private int moveUpForm = -1;
        WorldForm WorldForm = new WorldForm();
        BeehiveForm BeehiveForm = new BeehiveForm();
        Timer _flowerTimer;
        Timer _beeIndoorsTimer;
        Timer _beeOuterWorldTimer;
        Timer _dashBoardTimer;
        private DateTime _start = DateTime.Now;
        private DateTime _end;
        private IList<int> pollenNumberDatasource = new List<int>() { 0, 100, 200, 300, 400, 500 };

        public DashboardForm()
        {
            InitializeComponent();
            this.Load += DashboardForm_Load;
            btnSimulation.Text = Settings.ButtonState.StartSimulation;

            dashboardFormWidth = this.Location.X + Width +45;
            dashboardFormLocationY = Location.Y;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(_initialLocationX, _initialLocationY);
            this.pollenNumberComboBox.DataSource = pollenNumberDatasource;
            DashBoardFormSettings();
            LoadAllChildForms();
        }
       
        private void btnSimulation_Click(object sender, EventArgs e)
        {
            if (!ValidateDashboard()) return;
            if (btnSimulation.Text == Settings.ButtonState.StartSimulation)
            {
                var totalFlowers = (int)FlowersNumericUpDown.Value;
                WorldForm.SetMaxFlowersNumber(totalFlowers);
                var totalBees = (int)BeesNumericUpDown.Value;
                BeehiveForm.SetMaxBeesNumber(totalBees);
                BeehiveForm.CreateFirstBee();

                _beeIndoorsTimer.Interval = 50;
                _flowerTimer.Interval = 1000;
                _beeOuterWorldTimer.Interval = 10;
                _dashBoardTimer.Interval = 10;

                SetAllTimers(true);

                StartAllTimers();
            }

            if (btnSimulation.Text == Settings.ButtonState.PauseSimulation)
            {
                StopAllTimers();
            }

            if (btnSimulation.Text == Settings.ButtonState.ResumeSimulation)
            {
                StartAllTimers();
            }

            ToggleButtonState(btnSimulation.Text);
        }

        public void SetAllTimers(bool timerIsEnabled)
        { 
            _flowerTimer.Enabled = timerIsEnabled;
            _beeIndoorsTimer.Enabled = timerIsEnabled;
            _beeOuterWorldTimer.Enabled = timerIsEnabled;
            _dashBoardTimer.Enabled = timerIsEnabled;
        }
        
        public void StartAllTimers()
        {
            _flowerTimer.Start();
            _beeIndoorsTimer.Start();
            _beeOuterWorldTimer.Start();
            _dashBoardTimer.Start();
        }

        public void StopAllTimers()
        {
            _flowerTimer.Stop();
            _beeIndoorsTimer.Stop();
            _beeOuterWorldTimer.Stop();
            _dashBoardTimer.Stop();
        }

        private void ToggleButtonState(string status)
        {
            if (status == Settings.ButtonState.StartSimulation) btnSimulation.Text = Settings.ButtonState.PauseSimulation;
            if (status == Settings.ButtonState.PauseSimulation) btnSimulation.Text = Settings.ButtonState.ResumeSimulation;
            if (status == Settings.ButtonState.ResumeSimulation) btnSimulation.Text = Settings.ButtonState.PauseSimulation;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Everything goes back to zero
            StatusBeeListBox.Items.Clear();
            StatusFlowerListBox.Items.Clear();
            BeesLabelNumber.Text = Convert.ToString(0);
            FlowerLabelNumber.Text = Convert.ToString(0);
            HiveHoneyLabelNumber.Text = Convert.ToString(0);
            FramesRunLabelNumber.Text = Convert.ToString(0);
            FramesRateLabelNumber.Text = Convert.ToString(0);
            FieldNectarLabelNumber.Text = Convert.ToString(0);

            FlowersNumericUpDown.Value = 0;
            BeesNumericUpDown.Value = 0;
            this.pollenNumberComboBox.SelectedItem = null;
            this.pollenNumberComboBox.SelectedText = pollenNumberDatasource[0].ToString();

            StopAllTimers();
            SetAllTimers(false);
            BeehiveForm.GetAllBees().Clear();
            BeehiveForm.Refresh();

            //We remove all the flowers from the field
            WorldForm.GetAllFlowers().Clear();
            WorldForm.GetAllBeesInOuterWorld().Clear();
            WorldForm.Refresh();
            btnSimulation.Text = Settings.ButtonState.StartSimulation;
        }

        private bool ValidateDashboard()
        {
            if(BeesNumericUpDown.Value <= 0)
            {
                MessageBox.Show("You must set the Number of bees greater than zero");
                return false; 
            }
            if (FlowersNumericUpDown.Value <= 0)
            {
                MessageBox.Show("You must set the Number of Flowers greater than zero");
                return false;
            }
            if((int)pollenNumberComboBox.SelectedValue == 0)
            {
                MessageBox.Show("You must set the pollen Number greater than zero");
                return false;
            }
            return true;
        }

        private void LoadAllChildForms()
        {
            LoadWorldFormSettings();
            LoadBeehiveFormSettings();
        }

        private void DashBoardFormSettings()
        {
            _dashBoardTimer = new Timer();
            _dashBoardTimer.Tick += new EventHandler(ProcessDashboardInformation);
        }

        private void LoadWorldFormSettings()
        {
            WorldForm.Show();
            _flowerTimer = new Timer();
            _flowerTimer.Enabled = true;

            _beeOuterWorldTimer = new Timer();
            _beeOuterWorldTimer.Enabled = true;

            WorldForm.CreateFlowerTimer(_flowerTimer);
            WorldForm.CreateBeeTimer(_beeOuterWorldTimer);
            SetWorldFormLocation();
        }

       
        private void LoadBeehiveFormSettings()
        {
            BeehiveForm.Show();
            _beeIndoorsTimer = new Timer();
            _beeIndoorsTimer.Enabled = true;
            BeehiveForm.CreateBeeAnimationTimer(_beeIndoorsTimer);
            SetBeehiveFormLocation();
        }

        private void SetWorldFormLocation()
        {
            WorldForm.StartPosition = FormStartPosition.Manual;
            WorldForm.Location = new Point(dashboardFormWidth-50, Location.Y + moveDownForm);
        }

        private void SetBeehiveFormLocation()
        {
            BeehiveForm.StartPosition = FormStartPosition.Manual;
            BeehiveForm.Location = new Point(dashboardFormWidth-50, dashboardFormLocationY + moveUpForm);
        }

        int framesRun = 0;
        private void ProcessDashboardInformation(object sender, EventArgs e)
        {
            StatusBeeListBox.Items.Clear();
            StatusFlowerListBox.Items.Clear();

            var allBees = BeehiveForm.GetAllBees();
            var allFlowers = WorldForm.GetAllFlowers();
            
            var totalPollenCollectedMaternity = BeehiveForm.GetAllCollectedPollenBeeMaternity();
            var totalNectarInField = GetTotalNectarInField();

            BeesLabelNumber.Text = allBees.Count.ToString();
            FlowerLabelNumber.Text = allFlowers.Count.ToString();
            HiveHoneyLabelNumber.Text = totalPollenCollectedMaternity.ToString();
            FieldNectarLabelNumber.Text = totalNectarInField.ToString();
            FramesRunLabelNumber.Text = (framesRun++).ToString();
            FramesRateLabelNumber.Text = GetFrameDuration();
            foreach (var x in allBees)
            {
                StatusBeeListBox.Items.Add(string.Format("Bee Id: {0} Move: {1}. Pollen Collected: {2}", x.BeeId, x.BeeEnvironmentBehavior.ToString(), x.BeePollenCollected.ToString()));
            }

            foreach (var f in allFlowers)
            {
                StatusFlowerListBox.Items.Add(string.Format("Flower Id: {0} Stage: {1}. Pollen In flower: {2}",
                    f.FlowerID,
                    f.FlowerStage,
                    ((f.FlowerPollenArea.X != 0 && f.FlowerPollenArea.Y != 0) ? f.FlowerPollenContainer : 0)));
            }
        }

        private int GetTotalNectarInField()
        {
            var allFlowers = WorldForm.GetAllFlowers();
            var totalNectar=0;
            foreach (var flower in allFlowers)
            {
                totalNectar += flower.FlowerPollenContainer;
            }
            return totalNectar;
        }

        private string GetFrameDuration()
        {
            _end = DateTime.Now;
            TimeSpan frameDuration = _end - _start;
            _start = _end;
            string notification = "";
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                notification = string.Format("{0:f0} ({1:f1}ms)", 1000 / milliSeconds, milliSeconds);
            else
                notification = "N/A";

            return notification;
        }
    }
}
