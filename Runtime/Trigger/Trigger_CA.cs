using System;
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
    public class Trigger_CA : ABaseTrigger
    {
        protected ABaseCondMgr condMgr;
        protected ABaseActionMgr actMgr;
        private ETriggerState mState = ETriggerState.None;
        private Action<ETriggerState> onStatusChange;

        protected ETriggerState State
        {
            get { return mState; }
            set
            {
                mState = value;
                onStatusChange?.Invoke(mState);
            }
        }

        public override bool IsFinished
        {
            get { return mState == ETriggerState.End; }
        }

        public Trigger_CA(ITSObjFactory generator, CAData data, Action<ETriggerState> onStatusChange = null)
        {
            condMgr = new CondMgr_TotalSucc();
            condMgr.Ctor(generator, data.condColl);

            actMgr = new ActMgr_TotalEnter();
            actMgr.Ctor(generator, data.actColl);

            this.onStatusChange = onStatusChange;
        }

        public override void Start()
        {
            if (mState != ETriggerState.None)
                return;

            State = ETriggerState.CheckStart;
            condMgr.Enter();
        }

        public override void Stop()
        {
            if (mState == ETriggerState.None)
                return;

            switch (mState)
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

            State = ETriggerState.None;
        }

        public override void Update(float delta)
        {
            if (mState == ETriggerState.CheckStart)
            {
                if (condMgr.IsSuccess())
                {
                    // to do action
                    State = ETriggerState.Acting;
                    condMgr.Exit();
                    actMgr.Enter();

                    // to finished
                    State = ETriggerState.End;
                    actMgr.Exit();
                }
            }
        }
    }
}
