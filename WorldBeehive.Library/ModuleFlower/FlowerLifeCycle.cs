using System.Collections.Generic;
using System.Linq;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.ViewModels;
using WorldBeehive.Library.Properties;

namespace WorldBeehive.Library.ModuleFlower
{
    public class FlowerLifeCycle : IFlowerLifeCycle
    {
        List<FlowerCycle> flowerCycles;
        public FlowerLifeCycle()
        {
            flowerCycles = new List<FlowerCycle>()
            {
                new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Birth1,
                    FlowerCycleImage = Resource.plant01,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                 new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.EarlyStage1,
                    FlowerCycleImage =Resource.plant02,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                  new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.EarlyStage2,
                    FlowerCycleImage =Resource.plant03,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                   new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.EarlyStage3,
                    FlowerCycleImage =Resource.plant04,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                    new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.EarlyStage4,
                    FlowerCycleImage =Resource.plant05,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                     new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Growth1,
                    FlowerCycleImage =Resource.plant06,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                      new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Growth2,
                    FlowerCycleImage =Resource.plant07,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                       new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Growth3,
                    FlowerCycleImage =Resource.plant08,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                        new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Growth4,
                    FlowerCycleImage =Resource.plant09,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                         new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.MidStage1,
                    FlowerCycleImage =Resource.plant10,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                          new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.MidStage2,
                    FlowerCycleImage =Resource.plant11,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                           new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.MidStage3,
                    FlowerCycleImage =Resource.plant12,
                    FlowerPollenArea =new System.Drawing.Rectangle(47,20,5,5)
                },
                            new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Blossom1,
                    FlowerCycleImage =Resource.plant13,
                    FlowerPollenArea =new System.Drawing.Rectangle(48,14,5,5)
                },
                             new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Blossom2,
                    FlowerCycleImage =Resource.plant14,
                    FlowerPollenArea =new System.Drawing.Rectangle(45,11,5,5)
                },
                              new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Blossom3,
                    FlowerCycleImage =Resource.plant15,
                    FlowerPollenArea =new System.Drawing.Rectangle(45,14,5,5)
                },
                               new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Blossom4,
                    FlowerCycleImage =Resource.plant16,
                    FlowerPollenArea =new System.Drawing.Rectangle(45,14,5,5)
                },
                                new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Maturity1,
                    FlowerCycleImage =Resource.plant17,
                    FlowerPollenArea =new System.Drawing.Rectangle(43,26,5,5)
                },
                                 new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Maturity2,
                    FlowerCycleImage =Resource.plant18,
                    FlowerPollenArea =new System.Drawing.Rectangle(43,25,5,5)
                },
                                  new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.LateStage1,
                    FlowerCycleImage =Resource.plant19,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                                   new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Death1,
                    FlowerCycleImage =Resource.plant20,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                                    new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Death2,
                    FlowerCycleImage =Resource.plant21,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                },
                                    new FlowerCycle(){
                    FlowerCycleStage = Enums.FlowerLifeCycleEnum.Dissapeareance,
                    FlowerCycleImage =Resource.plant21,
                    FlowerPollenArea =new System.Drawing.Rectangle(0,0,0,0)
                }
            };
        }


        public FlowerCycle GetSelectedFlowerCycle(FlowerLifeCycleEnum flowerLifeCycle)
        {
            var flower = flowerCycles.Where(a=>a.FlowerCycleStage == flowerLifeCycle).FirstOrDefault();
            return flower;
        }


        public FlowerCycle GetNextFlowerCycle(FlowerLifeCycleEnum flowerLifeCycle)
        {
            var nextCycleNumber = (int)flowerLifeCycle+1;
            var nextFlower = flowerCycles.Where(a => (int)a.FlowerCycleStage == nextCycleNumber).FirstOrDefault();
            return nextFlower;
        }
    }
}
