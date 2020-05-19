using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorldBeehive.Library.DependencyInjection;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.WinFormApp
{
    public partial class WorldForm : Form
    {
        IWorldMediator _worldMediator = ContainerConfig.GetInstance<IWorldMediator>();
        private int totalFlowersCount;
        public WorldForm()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(PaintLandscape);
            this.Paint += new PaintEventHandler(PaintFlowers);
            this.Paint += new PaintEventHandler(PaintBeesInOuterWorld);
            _worldMediator.SetWorldDimmensions(Width, Height);
            EnableDoubleBuffering();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void SetMaxFlowersNumber(int flowersCount)
        {
            totalFlowersCount = flowersCount;
            _worldMediator.SetMaxFlowersNumber(flowersCount);
        }

        public List<IFlower> GetAllFlowers()
        {
            var allFlowers = _worldMediator.GetAllFlowers();
            return allFlowers;
        }

        public List<IBee> GetAllBeesInOuterWorld()
        {
           var allBees = _worldMediator.GetAllBeesInOuterWorld();
            return allBees;
        }

        public void CreateFlowerTimer(Timer flowerTimer)
        {
            FlowerTimer_Setup(flowerTimer);
        }

        public void CreateBeeTimer(Timer beeOuterWorldTimer)
        {
            BeeTimer_Setup(beeOuterWorldTimer);
        }

        private void EnableDoubleBuffering()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void FlowerTimer_Setup(Timer flowerTimer)
        {
           if(flowerTimer != null)
            {
                flowerTimer.Tick += new System.EventHandler(this.FlowerTimer_Tick);
            }
        }

        private void FlowerTimer_Tick(object sender, EventArgs e)
        {
            _worldMediator.UpdateAllFlowersLifeCycle();
            _worldMediator.CreateNewFlowers();
            this.Refresh();
        }

        private void BeeTimer_Setup(Timer beeTimer)
        {
            if(beeTimer != null)
            {
                beeTimer.Tick += new EventHandler(this.BeeTimer_Tick);
            }
        }

        private void BeeTimer_Tick(object sender,EventArgs e)
        {
            _worldMediator.MoveBeeInTheWorld();
            _worldMediator.RemoveBeeFromOuterWorld();
            this.Refresh();
        }

        private void PaintLandscape(object sender, PaintEventArgs paintOuterWorldEventArgs)
        {
            _worldMediator.PaintLandscape(paintOuterWorldEventArgs);
        }

        private void PaintFlowers(object sender, PaintEventArgs paintOuterWorldEventArgs)
        {
            _worldMediator.PaintFlowers(paintOuterWorldEventArgs);
        }

        private void PaintBeesInOuterWorld(object sender, PaintEventArgs paintOuterWorldEventArgs)
        {
            _worldMediator.PaintBees(paintOuterWorldEventArgs);
        }
    }
}
