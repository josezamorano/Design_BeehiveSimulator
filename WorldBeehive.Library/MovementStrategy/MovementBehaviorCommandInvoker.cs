using System;
using System.Collections.Generic;
using System.Linq;
using WorldBeehive.Library.DependencyInjection;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.Models;

namespace WorldBeehive.Library.MovementStrategy
{
    public class MovementBehaviorCommandInvoker : IMovementBehaviorCommandInvoker
    {
        private Random rand = new Random();
        private List<BehaviorType> allMovementAndBehaviorCombinations;
        private IRandomMovenentBehavior randomMoevenentBehavior = ContainerConfig.GetInstance<IRandomMovenentBehavior>();
        private ITargetedMovementBehavior targetedMovementBehavior = ContainerConfig.GetInstance<ITargetedMovementBehavior>();
        public MovementBehaviorCommandInvoker()
        {
            allMovementAndBehaviorCombinations = new List<BehaviorType>()
            {
                new BehaviorType()
                {
                    BehaviorTypeEnum = BeeEnvironmentBehaviorEnum.IndoorsRandom,
                    BehaviorTypeName = randomMoevenentBehavior,
                },
                new BehaviorType()
                {
                    BehaviorTypeEnum = BeeEnvironmentBehaviorEnum.IndoorsTargetExit,
                    BehaviorTypeName = targetedMovementBehavior,
                },
                new BehaviorType()
                {
                    BehaviorTypeEnum = BeeEnvironmentBehaviorEnum.OuterWorldRandom,
                    BehaviorTypeName = randomMoevenentBehavior,
                },
                new BehaviorType()
                {
                    BehaviorTypeEnum = BeeEnvironmentBehaviorEnum.OuterWorldTargetFlower,
                    BehaviorTypeName = targetedMovementBehavior,
                },
                new BehaviorType()
                {
                    BehaviorTypeEnum = BeeEnvironmentBehaviorEnum.OuterWorldTargetBeehiveEntrance,
                    BehaviorTypeName = targetedMovementBehavior,
                }
            };
        }

        public IBehaviorCommand GetSelectedBehavioralMovement(BeeEnvironmentBehaviorEnum beeBehavior)
        {
            var selectedBehavior = allMovementAndBehaviorCombinations.Where(a => a.BehaviorTypeEnum == beeBehavior).FirstOrDefault();
            return selectedBehavior.BehaviorTypeName;
        }

        public BeeEnvironmentBehaviorEnum SelectBehaviorRandomly(BeeEnvironmentEnum beeEnvironment)
        {
            var environment = beeEnvironment.ToString().ToLower();
            var allBehaviors = Enum.GetValues(typeof(BeeEnvironmentBehaviorEnum)).Cast<BeeEnvironmentBehaviorEnum>().ToList();
            var selectedBehaviors = allBehaviors.Where(a => a.ToString().ToLower().Contains(environment)).ToList();
            var index = rand.Next(0, selectedBehaviors.Count);
            BeeEnvironmentBehaviorEnum selectedBehavior = selectedBehaviors[index];
            return selectedBehavior;
        }
    }
}
