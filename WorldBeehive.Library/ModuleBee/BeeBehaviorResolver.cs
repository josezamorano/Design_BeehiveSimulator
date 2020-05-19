using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WorldBeehive.Common.Interfaces;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.ModuleBee
{
    public class BeeBehaviorResolver : IBeeBehaviorResolver
    {
        private int _minNextMovementIteration = 15;
        private int _maxNextMovementIteration = 45;
        private Random rand = new Random();
        private Rectangle _beehiveExitDoorDimmensions;


        IBeeCommon _beeCommon;
        IFlowerManager _flowerManager;
        ILandscapeManager _landscapeManager;
        IInteractionManager _interactionManager;
        IMovementBehaviorCommandInvoker _movementBehaviorCommandInvoker;
        IMovementSelector _movementSelector;
        public BeeBehaviorResolver(IBeeCommon beeCommon ,IFlowerManager flowerManager, ILandscapeManager landscapeManager, IInteractionManager interactionManager, IMovementBehaviorCommandInvoker movementBehaviorCommandInvoker, IMovementSelector movementSelector)
        {
            _beeCommon = beeCommon;
            _flowerManager = flowerManager;
            _landscapeManager = landscapeManager;
            _interactionManager = interactionManager;
            _movementBehaviorCommandInvoker = movementBehaviorCommandInvoker;
            _movementSelector = movementSelector;
        }

        public void SetBeehiveExitDoorDimmensions(Rectangle beehiveExitDoorDimmensions)
        {
            _beehiveExitDoorDimmensions= beehiveExitDoorDimmensions;
        }
        
        public IBee UpdateBeeInfo_OnRandomMovement(IBee bee, Rectangle environmentDimmensions)
        {
            //Indoors
            SetRandomChangeOfMovementDirectionIndoors(bee);
            SetRandomChangeOfBehaviorIndoors(bee);
            SetOppositeMovementDirectionOnReachingIndoorsLimits(bee, environmentDimmensions);
            //OuterWorld
            SetRandomChangeOfMovementDirectionOuterWorld(bee);
            SetRandomChangeOfBehaviorOuterWorld(bee);
            SetOppositeMovementDirectionOnReachingOuterWorldLimits(bee, environmentDimmensions);
            return bee;
        }

        public IBee UpdateBeeInfo_OnTargetedMovement(IBee bee)
        {   //Indoors
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                SetBeeTargetedMovementDirection_Indoors(bee, _beehiveExitDoorDimmensions);
                SetBeeNewBehaviorOnHittingTarget_Indoors(bee, _beehiveExitDoorDimmensions);
            }
            
            //OuterWorld
            if (BeeIsGoingTowardsBeehiveEntrance(bee))
            {
                Rectangle beehiveEntranceDoor = _landscapeManager.GetBeehiveEntranceDoorDimmensions();
                SetBeeTargetedMovementDirection_OuterWorld(bee, beehiveEntranceDoor);
                SetBeeNewTargetedBehaviorOnHittingTarget_OuterWorld(bee, beehiveEntranceDoor);
            }

            if (BeeIsGoingTowardsFlower(bee))
            {
                SetTargetBehaviorBee_PollenFlower(bee);
                if (!HasAFlowerIDBeenAssignedToBee(bee)){ SetRandomBehaviorBee_OuterWorld(bee); }
                else
                {
                    IFlower selectedFlower = GetSelectedFlowerByID(bee.BeeTargetFlowerID);
                    if (selectedFlower != null)
                    {
                        SetBeeTargetedMovementDirection_OuterWorld(bee, selectedFlower.FlowerPollenArea);
                        SetBeeNewTargetedBehaviorOnHittingTarget_OuterWorld(bee, selectedFlower.FlowerPollenArea);
                    }
                }
            }
            return bee;
        }
        

        #region Private Methods
        private IFlower GetSelectedFlowerByID(int id)
        {
            IFlower selectedFlower = _flowerManager.GetAllFlowers().Where(a => a.FlowerID == id).FirstOrDefault();
            return selectedFlower;
        }

        private void SetBeeTargetBlossomingFlowerID(IBee bee)
        {
            if (bee.BeeTargetFlowerID == -1 && BeeIsGoingTowardsFlower(bee))
            {
                var selectedFlower = GetTargetFlowerCloserToBee(bee, _flowerManager.GetBlossomingFlowers());
                bee.BeeTargetFlowerID = (selectedFlower != null) ? selectedFlower.FlowerID : -1;
            }
        }

        private bool IsTargetFlowerStillBlossoming(IBee bee)
        {
            if (!HasAFlowerIDBeenAssignedToBee(bee)) { return false; }
            if (bee.BeeTargetFlowerID != -1 && BeeIsGoingTowardsFlower(bee))
            {   //we get the flower by ID
                var selectedFlower = GetSelectedFlowerByID(bee.BeeTargetFlowerID);
                if (selectedFlower != null && selectedFlower.FlowerPollenArea.Width != 0 && selectedFlower.FlowerPollenArea.Height != 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveFlowerIDFromBee(IBee bee)
        {
            bee.BeeTargetFlowerID = -1;
        }

        private bool HasAFlowerIDBeenAssignedToBee(IBee bee)
        {
            var result = (bee.BeeTargetFlowerID != -1) ? true : false;
            return result;
        }

        private IFlower GetTargetFlowerCloserToBee(IBee bee, List<IFlower> blossomingFlowers)
        {
            int minimumDistance = -1;
            int flowerIndex = -1;
            for (var i = 0; i < blossomingFlowers.Count; i++)
            {
                if (blossomingFlowers[i].FlowerPollenArea.Width != 0 && blossomingFlowers[i].FlowerPollenArea.Height != 0)
                {
                    var distance = _interactionManager.GetDistanceBetweenObjectAandObjectB(bee.BeeInOuterWorldSize, blossomingFlowers[i].FlowerPollenArea);
                    if (i == 0)
                    {
                        minimumDistance = distance;
                        flowerIndex = i;
                    }
                    else if (distance < minimumDistance)
                    {
                        minimumDistance = distance;
                        flowerIndex = i;
                    }
                }
            }
            var selectedFlower =(flowerIndex != -1) ? blossomingFlowers[flowerIndex] : null;
            return selectedFlower;
        } 
        
        private bool BeeIsGoingTowardsBeehiveEntrance(IBee bee)
        {
            var beeTowardsEntrance = (bee.BeeEnvironmentBehavior == BeeEnvironmentBehaviorEnum.OuterWorldTargetBeehiveEntrance);
            return beeTowardsEntrance;
        }

        private bool BeeIsGoingTowardsFlower(IBee bee)
        {
            var beeTowardsFlower = (bee.BeeEnvironmentBehavior == BeeEnvironmentBehaviorEnum.OuterWorldTargetFlower);
            return beeTowardsFlower;
        }
        
        private void SetBeeTargetedMovementDirection_Indoors(IBee bee, Rectangle environmentTargetDimmensions)
        {
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                var beeLocationPoint = new Point(bee.BeeIndoorsSize.X, bee.BeeIndoorsSize.Y);
                var targetLocationPoint = new Point(environmentTargetDimmensions.X, environmentTargetDimmensions.Y);
                bee.BeeIndoorsMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior, beeLocationPoint, targetLocationPoint);
            }
        }

        private void SetBeeTargetedMovementDirection_OuterWorld(IBee bee, Rectangle environmentTargetDimmensions)
        {
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            {
                var beeLocationPoint = new Point(bee.BeeInOuterWorldSize.X, bee.BeeInOuterWorldSize.Y);
                var targetLocationPoint = new Point(environmentTargetDimmensions.X, environmentTargetDimmensions.Y);
                bee.BeeOuterWorldMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior, beeLocationPoint, targetLocationPoint);
            }
        }

        private void SetBeeNewBehaviorOnHittingTarget_Indoors(IBee bee, Rectangle environmentTargetDimmensions)
        {
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                var beeReachesObject = _interactionManager.ObjectAIntersectsObjectB(bee.BeeIndoorsSize, environmentTargetDimmensions);
                if (beeReachesObject)
                {
                    SetRandomBehaviorBee_OuterWorld(bee);
                }
            }
        }

        private void SetBeeNewTargetedBehaviorOnHittingTarget_OuterWorld(IBee bee, Rectangle environmentTargetDimmensions)
        {
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            {
                var beeReachesTarget = _interactionManager.ObjectAIntersectsObjectB(bee.BeeInOuterWorldSize, environmentTargetDimmensions);
                if (BeeIsGoingTowardsBeehiveEntrance(bee) && beeReachesTarget)
                {
                    SetRandomBehaviorBee_Indoors(bee);
                }

                if (BeeIsGoingTowardsFlower(bee) && beeReachesTarget)
                {
                    BeeExtractPollenFromFlower(bee);
                    SetTargetBehaviorBee_BeehiveExitDoor(bee);
                }
            }
        }

        
        private IBee BeeExtractPollenFromFlower(IBee bee)
        {
            var selectedFlower = GetSelectedFlowerByID(bee.BeeTargetFlowerID);
            if(selectedFlower != null)
            {
                var flowerRemainingPollen = selectedFlower.FlowerPollenContainer - bee.BeePollenCarryingCapacity;

                bee.BeePollenCollected = bee.BeePollenCarryingCapacity;
                selectedFlower.FlowerPollenContainer = flowerRemainingPollen;
                if(flowerRemainingPollen <= 0)
                {
                    selectedFlower.FlowerPollenContainer = 0;
                    bee.BeePollenCollected = 0;
                }
            }
            return bee;
        }

        private void SetRandomBehaviorBee_Indoors(IBee bee)
        {
            bee.BeeIsOnDisplayIndoors = true;
            bee.BeeIsOnDisplayOuterWorld = false;
            bee.BeeOuterWorldMovementDirection = MovementDirectionEnum.Static;
            bee.BeeEnvironmentBehavior = BeeEnvironmentBehaviorEnum.IndoorsRandom;
            bee.BeeIndoorsMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior);
        }

        private void SetRandomBehaviorBee_OuterWorld(IBee bee)
        {
            bee.BeeIsOnDisplayIndoors = false;
            bee.BeeIsOnDisplayOuterWorld = true;
            bee.BeeIndoorsMovementDirection = MovementDirectionEnum.Static;
            bee.BeeEnvironmentBehavior = BeeEnvironmentBehaviorEnum.OuterWorldRandom;
            bee.BeeOuterWorldMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior);
        }

        private void SetTargetBehaviorBee_PollenFlower(IBee bee)
        {
            SetBeeTargetBlossomingFlowerID(bee);
            if (!IsTargetFlowerStillBlossoming(bee))
            {
                if (HasAFlowerIDBeenAssignedToBee(bee)) { RemoveFlowerIDFromBee(bee); }
                SetBeeTargetBlossomingFlowerID(bee);
            }
        }

        private void SetTargetBehaviorBee_BeehiveExitDoor(IBee bee)
        {
            bee.BeeIsOnDisplayIndoors = false;
            bee.BeeIsOnDisplayOuterWorld = true;
            bee.BeeIndoorsMovementDirection = MovementDirectionEnum.Static;
            bee.BeeEnvironmentBehavior = BeeEnvironmentBehaviorEnum.OuterWorldTargetBeehiveEntrance;
            bee.BeeOuterWorldMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior);
        }

        private void SetRandomChangeOfMovementDirectionIndoors(IBee bee)
        {
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            { 
                if (bee.NextBeeMovementCycle == bee.BeeIterationMovementCycleCounter)
                {
                    bee.BeeIndoorsMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior);
                    bee.NextBeeMovementCycle = rand.Next(_minNextMovementIteration, _maxNextMovementIteration);
                    bee.BeeIterationMovementCycleCounter = 0;
                    return;
                }
                bee.BeeIterationMovementCycleCounter++;
            }
        }

        private void SetRandomChangeOfMovementDirectionOuterWorld(IBee bee)
        {
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            { 
                if (bee.NextBeeMovementCycle == bee.BeeIterationMovementCycleCounter)
                {
                    bee.BeeOuterWorldMovementDirection = _beeCommon.GetSelectedMovement(bee.BeeEnvironmentBehavior);
                    bee.NextBeeMovementCycle = rand.Next(_minNextMovementIteration, _maxNextMovementIteration);
                    bee.BeeIterationMovementCycleCounter = 0;
                    return;
                }
                bee.BeeIterationMovementCycleCounter++;
            }
        }

        private void SetRandomChangeOfBehaviorIndoors(IBee bee)
        {
            if(_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                if (bee.NextBeeBehaviorType == bee.BeeIterationBehaviorTypeCounter)
                {
                    bee.BeeEnvironmentBehavior = _movementBehaviorCommandInvoker.SelectBehaviorRandomly(BeeEnvironmentEnum.Indoors);
                    bee.BeeIterationBehaviorTypeCounter = 0;
                    return;
                }
                bee.BeeIterationBehaviorTypeCounter++;
            }
        }

        private void SetRandomChangeOfBehaviorOuterWorld(IBee bee)
        {
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            { 
                if (bee.NextBeeBehaviorType == bee.BeeIterationBehaviorTypeCounter)
                {
                    bee.BeeEnvironmentBehavior = _movementBehaviorCommandInvoker.SelectBehaviorRandomly(BeeEnvironmentEnum.OuterWorld);
                    //If the selected random behavior is OuterWorldTargetBeehiveEntrance we execute the selector again
                    //until the bee goes to random or to target flower
                    if (bee.BeeEnvironmentBehavior == BeeEnvironmentBehaviorEnum.OuterWorldTargetBeehiveEntrance)
                    {
                        SetRandomChangeOfBehaviorOuterWorld(bee);
                    }
                    bee.BeeIterationBehaviorTypeCounter = 0;
                    return;
                }
                bee.BeeIterationBehaviorTypeCounter++;
            }
        }

        private void SetOppositeMovementDirectionOnReachingIndoorsLimits(IBee bee, Rectangle environmentDimmensions)
        {
            if (_beeCommon.BeeIsIndoors(bee.BeeEnvironmentBehavior))
            {
                var beeHitsLimits = _interactionManager.ObjectAIsBeyondObjectB(bee.BeeIndoorsSize, environmentDimmensions);
                if (beeHitsLimits)
                {
                    bee.BeeIndoorsMovementDirection = _movementSelector.GetOppositeMovement(bee.BeeIndoorsMovementDirection);
                }
            }
        }

        private void SetOppositeMovementDirectionOnReachingOuterWorldLimits(IBee bee, Rectangle environmentDimmensions)
        {
            if (_beeCommon.BeeIsInOuterWorld(bee.BeeEnvironmentBehavior))
            {
                var beeHitsLimits = _interactionManager.ObjectAIsBeyondObjectB(bee.BeeInOuterWorldSize, environmentDimmensions);
                if (beeHitsLimits)
                {
                    bee.BeeOuterWorldMovementDirection = _movementSelector.GetOppositeMovement(bee.BeeOuterWorldMovementDirection);
                }
            }
        }
        #endregion
    }
}
