using System;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;
using VRage.Utils;
using BlendTypeEnum = VRageRender.MyBillboard.BlendTypeEnum;

namespace Invalid.profileloading
{
    [MySessionComponentDescriptor(MyUpdateOrder.BeforeSimulation | MyUpdateOrder.AfterSimulation)]
    public class Example_Session : MySessionComponentBase
    {
        public static Example_Session Instance;
        private TimeSpan loadTime;
        private DateTime beforeStartTime;

        public Example_Session()
        {
            Instance = this;
            beforeStartTime = DateTime.UtcNow;
        }

        public override void LoadData()
        {
        }

        public override void BeforeStart()
        {
            var totalTime = DateTime.UtcNow - beforeStartTime;
            loadTime = totalTime;
            Instance = null;

            if (MyAPIGateway.Session?.Player != null)
            {
                var playerName = MyAPIGateway.Session.Player.DisplayName;
                var message = $"Player {playerName} loaded in {totalTime.TotalSeconds:F2} seconds.";

                // Send the message to chat
                MyAPIGateway.Utilities.ShowMessage("Player Loaded", message);
            }
        }

        // Other overridden methods...
    }
}
