using System;
using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public struct CACData
    {
        public ICollection<CondCtorData> startCondColl;
        public ICollection<ActionCtorData> actColl;
        public ICollection<CondCtorData> endCondColl;
    }

    public enum ETriggerState
    {
        None = 0,
        CheckStart = 1,
        Acting = 2,
        End = 4,
    }

    /// <summary>
    /// Start condition, trigger action, end condition
    /// </summary>
    public class Trigger_CAC : ABaseTrigger
    {
        protected ABaseCondMgr startCondMgr;
        protected ABaseActionMgr actMgr;
        protected ABaseCondMgr endCondMgr;
        protected ETriggerState state = ETriggerState.None;
        protected Action<ETriggerState> onStatusChange;

        public Trigger_CAC(ITSObjGenerator generator, CACData data, Action<ETriggerState> onStatusChange = null)
            : base(generator)
        {
            startCondMgr = new CondMgr_TotalSucc();
            startCondMgr.Init(this, data.startCondColl);

            actMgr = new ActMgr_TotalEnter();
            actMgr.Init(this, data.actColl);

            endCondMgr = new CondMgr_TotalSucc();
            endCondMgr.Init(this, data.endCondColl);

            this.onStatusChange = onStatusChange;
        }

        public void SwitchToState(ETriggerState state)
        {
            this.state = state;
            onStatusChange?.Invoke(state);
        }

        public override void Start()
        {
            if (state != ETriggerState.None)
                return;

            SwitchToState(ETriggerState.CheckStart);
            startCondMgr.Enter();

            // sync trigger
            Update(0);
        }

        public override void Stop()
        {
            if (state == ETriggerState.None)
                return;

            switch (state)
            {
                case ETriggerState.CheckStart:
                    startCondMgr.Exit();
                    break;
                case ETriggerState.Acting:
                    endCondMgr.Exit();
                    actMgr.Exit();
                    break;
                case ETriggerState.End:
                    // the end is all cleared, but is diff with none
                    break;
                default:
                    break;
            }

            SwitchToState(ETriggerState.None);
        }

        public override bool IsFinished()
        {
            return state == ETriggerState.End;
        }

        public override void Update(float delta)
        {
            switch (state)
            {
                case ETriggerState.None:
                    break;
                case ETriggerState.CheckStart:
                    if (startCondMgr.IsSuccess())
                    {
                        // switch to acting
                        SwitchToState(ETriggerState.Acting);
                        startCondMgr.Exit();
                        endCondMgr.Enter();
                        actMgr.Enter();

                        // sync trigger
                        Update(0);
                    }
                    break;
                case ETriggerState.Acting:
                    if (endCondMgr.IsSuccess())
                    {
                        SwitchToState(ETriggerState.End);
                        endCondMgr.Exit();
                        actMgr.Exit();

                        // sync trigger
                        Update(0);
                    }
                    break;
                case ETriggerState.End:
                    break;
                default:
                    break;
            }
        }
    }
}
