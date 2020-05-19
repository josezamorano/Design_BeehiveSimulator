using Autofac;
using WorldBeehive.Library.Factory;
using WorldBeehive.Library.Interfaces;
using WorldBeehive.Library.ViewModels;
using WorldBeehive.Library.ModuleBeehive;
using WorldBeehive.Library.ModuleBeehive.Mediators;
using WorldBeehive.Library.ModuleFlower;
using WorldBeehive.Library.ModuleWorld;
using WorldBeehive.Library.ModuleWorld.Mediators;
using WorldBeehive.Library.ModuleBee;
using WorldBeehive.Library.MovementStrategy;
using WorldBeehive.Library.MovementStrategy.MovementTypes;
using WorldBeehive.Library.MovementStrategy.BehaviorTypes;
using WorldBeehive.Common.ObjectInteraction;
using WorldBeehive.Common.Interfaces;
using WorldBeehive.Common.Graphics;
using WorldBeehive.Common.Util;

namespace WorldBeehive.Library.DependencyInjection
{
    public class ContainerConfig
    {
        private static IContainer container = null;
        public static void Configure()
        {//***** Class -- Interface Pairs *****
            var builder = new ContainerBuilder();
            builder.RegisterType<Bee>().As<IBee>();
            builder.RegisterType<BeeBehaviorResolver>().As<IBeeBehaviorResolver>();
            builder.RegisterType<BeeCommon>().As<IBeeCommon>();
            builder.RegisterType<BeeManager>().As<IBeeManager>().SingleInstance();
            builder.RegisterType<BeehiveManager>().As<IBeehiveManager>().SingleInstance();
            builder.RegisterType<BeehiveMediator>().As<IBeehiveMediator>().SingleInstance();
            builder.RegisterType<BeeWingsMovementCycle>().As<IBeeWingsMovementCycle>();
            builder.RegisterType<BeeWingsMovementInvoker>().As<IBeeWingsMovementInvoker>();
            builder.RegisterType<Flower>().As<IFlower>();
            builder.RegisterType<FlowerLifeCycle>().As<IFlowerLifeCycle>().SingleInstance();
            builder.RegisterType<FlowerManager>().As<IFlowerManager>().SingleInstance();
            builder.RegisterType<ImageDrawing>().As<IImageDrawing>();
            builder.RegisterType<InteractionManager>().As<IInteractionManager>();
            builder.RegisterType<MovementBehaviorCommandInvoker>().As<IMovementBehaviorCommandInvoker>();
            builder.RegisterType<LandscapeManager>().As<ILandscapeManager>().SingleInstance();
            builder.RegisterType<LinearMovementStrategy>().As<ILinearMovementStrategy>();
            builder.RegisterType<LifeFactory>().As<ILifeFactory>();
            builder.RegisterType<MovementSelector>().As<IMovementSelector>();
            builder.RegisterType<RandomMovementBehavior>().As<IRandomMovenentBehavior>();
            builder.RegisterType<ShapeDrawing>().As<IShapeDrawing>();
            builder.RegisterType<TargetedMovementBehavior>().As<ITargetedMovementBehavior>();
            builder.RegisterType<CommonUtilities>().As<ICommonUtilities>();
            builder.RegisterType<WorldMediator>().As<IWorldMediator>().SingleInstance();
            
            container = builder.Build();
        }

        public static T GetInstance<T>()
        {
            if(container == null)
            {
                Configure();
            }
            return container.Resolve<T>();
        }
    }
}
