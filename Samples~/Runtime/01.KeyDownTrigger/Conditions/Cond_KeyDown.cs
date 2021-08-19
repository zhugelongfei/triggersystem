using UnityEngine;
using Lonfee.EventSystem;

namespace Lonfee.TriggerSystem.Samples
{
    public class EvtCls_KeyDown
    {
        public KeyCode code;
    }

    public class Cond_KeyDown : ABaseCondition
    {
        private KeyCode code;

        public override void InitData(object data)
        {
            this.code = (KeyCode)data;
        }

        protected override void OnEnter()
        {
            EventMgr.RegisterEvent<EvtCls_KeyDown>(OnEvt_KeyDown);
        }

        private void OnEvt_KeyDown(EvtCls_KeyDown obj)
        {
            if (obj.code == code)
            {
                IsSuccess = true;
            }
        }

        protected override void OnExit()
        {
            EventMgr.RemoveEvent<EvtCls_KeyDown>(OnEvt_KeyDown);
        }
    }
}