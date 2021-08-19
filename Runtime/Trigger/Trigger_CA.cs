using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public struct CAData
    {
        public ICollection<CondCtorData> condColl;
        public ICollection<ActionCtorData> actColl;
    }

    /// <summary>
    /// Start conditions and trigger actions
    /// </summary>
    public abstract class Trigger_CA : ABaseTrigger
    {
        protected ABaseCondMgr condMgr;
        protected ABaseActionMgr actMgr;
        protected ETriggerState state = ETriggerState.None;

        public Trigger_CA(CAData data, ITSObjGenerator generator)
            : base(generator)
        {
            condMgr = new CondMgr_TotalSucc();
            condMgr.Init(this, data.condColl);

            actMgr = new ActMgr_TotalEnter();
            actMgr.Init(this, data.actColl);
        }

        public override void Start()
        {
            if (state != ETriggerState.None)
                return;

            state = ETriggerState.CheckStart;
            condMgr.Enter();
        }

        public override void Stop()
        {
            if (state == ETriggerState.None)
                return;

            switch (state)
            {
                case ETriggerState.CheckStart:
                    condMgr.Exit();
                    break;
                case ETriggerState.Acting:
                    actMgr.Exit();
                    break;
                case ETriggerState.End:
                    // the end is all cleared, but is diffrente with None
                    break;
                default:
                    break;
            }

            state = ETriggerState.None;
        }

        public override bool IsFinished()
        {
            return state == ETriggerState.End;
        }

        public override void Update(float delta)
        {
            if (state == ETriggerState.CheckStart)
            {
                if (condMgr.IsSuccess())
                {
                    // to do action
                    state = ETriggerState.Acting;
                    condMgr.Exit();
                    actMgr.Enter();

                    // to finished
                    state = ETriggerState.End;
                    actMgr.Exit();
                }
            }
        }
    }
}
