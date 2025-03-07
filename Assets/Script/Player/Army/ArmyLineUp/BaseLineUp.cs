using System.Collections.Generic;

namespace Script.Player.Army.ArmyLineUp
{
    public class BaseLineUp
    {
        protected ArmyPlayer controller;
        protected List<SoldierController> soldiers;
        protected BaseLineUp(ArmyPlayer controller)
        {
            this.controller = controller;
            soldiers = this.controller.Players;
        }

        public virtual void OnEnterLineUp()
        {
            
        }

        public virtual void OnExecuteLineUp()
        {
            
        }

        public virtual void OnExitLineUp()
        {
            
        }
    }
}