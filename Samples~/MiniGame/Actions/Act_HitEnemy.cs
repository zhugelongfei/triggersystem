using UnityEngine;

public class EvtCls_HitEnemy
{
    public int playerId;
}

namespace Lonfee.TriggerSystem.Samples
{
    public class Act_HitEnemy : ABaseEvent
    {
        public override void InitData(object data)
        {

        }

        protected override void DoAction()
        {
            object objPlayerId = cache["PlayerId"];

            EvtCls_HitEnemy evtData = new EvtCls_HitEnemy();

            if (objPlayerId != null)
            {
                // unboxing...
                evtData.playerId = (int)objPlayerId;
            }

            Lonfee.EventSystem.EventMgr.Dispatch(evtData);
        }
    }
}