using UnityEngine;

public class EvtCls_HitEnemy
{

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
            Lonfee.EventSystem.EventMgr.Dispatch(new EvtCls_HitEnemy());
        }
    }
}