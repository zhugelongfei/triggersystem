namespace Lonfee.TriggerSystem
{
    public abstract class ABaseCondition
    {
        private int type;
        private bool isSucc = false;
        private bool isResetOnEnter;

        public int Type
        {
            get { return type; }
        }

        public bool IsSuccess
        {
            get { return isSucc; }
            protected set { isSucc = value; }
        }

        internal void Enter()
        {
            // when restart, reset the flag
            isSucc = isResetOnEnter ? false : isSucc;
            OnEnter();
        }

        protected abstract void OnEnter();

        internal void Exit()
        {
            OnExit();
        }

        protected abstract void OnExit();

        internal void Ctor(CondCtorData ctorData)
        {
            this.type = ctorData.type;
            this.isResetOnEnter = ctorData.isResetOnEnter;
        }

        public abstract void InitData(object data);
    }
}
