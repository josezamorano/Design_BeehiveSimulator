using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorldBeehive.Library.DependencyInjection;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.WinFormApp
{
    public partial class BeehiveForm : Form
    {
        IBeehiveMediator _beehiveMediator = ContainerConfig.GetInstance<IBeehiveMediator>();
        public BeehiveForm()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(PaintBeehiveIndoors);
            this.Paint += new PaintEventHandler(PaintBeesIndoors);
            
            FormBorderStyle = FormBorderStyle.FixedSingle;
            EnableDoubleBuffering();
            SetBeehiveFormDimmensions();
        }

        private void EnableDoubleBuffering()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void SetMaxBeesNumber(int beesCount)
        {
            _beehiveMediator.SetMaxNumberOfBees(beesCount);
        }

        public void SetBeehiveFormDimmensions()
        {
            int initialPointX = 0;
            int initialPointY = 0;
            _beehiveMediator.SetBeehiveIndoorsSkyDimmensions(new System.Drawing.Rectangle(initialPointX, initialPointY, this.Width, this.Height));
        }

        public void CreateFirstBee()
        {
            _beehiveMediator.CreateFirstBee();
        }

        public List<IBee> GetAllBees()
        {
            var allBees = _beehiveMediator.GetAllBees();
            return allBees;
        }

        public int GetAllCollectedPollenBeeMaternity()
        {
            var allPollen = _beehiveMediator.GetAllPollenCollected();
            return allPollen;
        }

        public void CreateBeeAnimationTimer(Timer beeTimer)
        {
            BeeAnimationTimer_setup(beeTimer);
        }

        public void BeeAnimationTimer_setup(Timer beeAnimationTimer)
        {
            if(beeAnimationTimer != null)
            {
                beeAnimationTimer.Tick += new EventHandler(BeeAnimationTimer_Tick);
            }
        }

        public void BeeAnimationTimer_Tick(object sender, EventArgs e)
        {
            _beehiveMediator.UpdateBeesWingMotionCycle();
            _beehiveMediator.UpdateAllBeesLifeCycle();
            _beehiveMediator.MoveAllBeesIndoors();
            _beehiveMediator.ActivateBeeMaternity();
            _beehiveMediator.AddPollenToMaternityPollenCollector();
            this.Refresh();
        }

        public void PaintBeehiveIndoors(object sender, PaintEventArgs paintIndoorsEvent)
        {
            _beehiveMediator.PaintBeehiveIndoors( paintIndoorsEvent);
        }

        public void PaintBeesIndoors(object sender, PaintEventArgs paintIndoorsEvent)
        {
            _beehiveMediator.PaintAllBeesIndoors(this, paintIndoorsEvent);
        }
    }
}
