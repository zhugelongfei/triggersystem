using UnityEngine;
using Lonfee.EventSystem;

namespace Lonfee.TriggerSystem.Samples
{
    public class EvtCls_PlayerEnterTrap
    {
        public int playerId;
    }

    public class Cond_PlayerEnterTrap : ABaseCondition
    {
        private int playerId;

        public override void InitData(object data)
        {
            playerId = (int)data;
        }

        protected override void OnEnter()
        {
            EventMgr.RegisterEvent<EvtCls_PlayerEnterTrap>(OnEvt_PlayerEnterTrap);
        }

        private void OnEvt_PlayerEnterTrap(EvtCls_PlayerEnterTrap obj)
        {
            if (obj.playerId == playerId)
            {
                IsSuccess = true;
            }
        }

        protected override void OnExit()
        {
            EventMgr.RemoveEvent<EvtCls_PlayerEnterTrap>(OnEvt_PlayerEnterTrap);
        }
    }
}