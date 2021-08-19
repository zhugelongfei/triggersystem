namespace Lonfee.TriggerSystem
{
    public abstract class ABaseCondition
    {
        private int type;
        private bool isSucc = false;
        private bool isResetOnEnter;
        protected ABaseCondMgr condMgr;

        public int Type
        {
            get { return type; }
        }

        public bool IsSuccess
        {
            get { return isSucc; }
            protected set { isSucc = value; }
        }

        public void Enter()
        {
            // when restart, reset the flag
            isSucc = isResetOnEnter ? false : isSucc;
            OnEnter();
        }

        protected abstract void OnEnter();

        public void Exit()
        {
            OnExit();
        }

        protected abstract void OnExit();

        public void Ctor(ABaseCondMgr condMgr, CondCtorData ctorData)
        {
            this.condMgr = condMgr;
            this.type = ctorData.type;
            this.isResetOnEnter = ctorData.isResetOnEnter;
        }

        public abstract void InitData(object data);
    }
}
