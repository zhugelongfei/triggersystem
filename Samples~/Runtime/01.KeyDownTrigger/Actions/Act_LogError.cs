using UnityEngine;

namespace Lonfee.TriggerSystem.Samples
{
    public class Act_LogError : ABaseEvent
    {
        public override void InitData(object data)
        {

        }

        protected override void DoAction()
        {
            Debug.LogError("Do Action");
        }
    }
}