using System;
using System.Drawing;
using System.Linq;
using WorldBeehive.Library.Enums;
using WorldBeehive.Library.Interfaces;

namespace WorldBeehive.Library.MovementStrategy.BehaviorTypes
{
    public class RandomMovementBehavior: IRandomMovenentBehavior
    {
        Random rand = new Random();
        public MovementDirectionEnum Execute(Point? hLocationPoint = null, Point? tLocationPoint = null)
        {
            var allMovements = Enum.GetValues(typeof(MovementDirectionEnum)).Cast<MovementDirectionEnum>().ToList();
            var totalMovements = allMovements.Count;
            var randomIndex = rand.Next(0, totalMovements);
            var selectedMovement = allMovements[randomIndex];
            return selectedMovement;
        }
    }
}
