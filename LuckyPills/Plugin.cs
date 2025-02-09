﻿namespace LuckyPills
{
    using System;
    using Exiled.API.Features;
    using PlayerEvent = Exiled.Events.Handlers.Player;
    
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "Lucky Pills";
        public override Version Version { get; } = new Version(3, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0, 0);

        private EventHandlers _eventHandler;

        public override void OnEnabled()
        {
            _eventHandler = new EventHandlers(this);

            PlayerEvent.UsingItem += _eventHandler.OnEatThePill;
            PlayerEvent.PickingUpItem += _eventHandler.OnPickupPill;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerEvent.UsingItem -= _eventHandler.OnEatThePill;
            PlayerEvent.PickingUpItem -= _eventHandler.OnPickupPill;
            
            _eventHandler = null;
            
            base.OnDisabled();
        }
    }
}
