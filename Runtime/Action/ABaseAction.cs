namespace Lonfee.TriggerSystem
{
    public abstract class ABaseAction
    {
        private int type;
        protected TriggerCache cache;

        public int Type
        {
            get { return type; }
        }

        internal void Enter()
        {
            OnEnter();
        }

        protected abstract void OnEnter();

        internal void Exit()
        {
            OnExit();
        }

        protected abstract void OnExit();

        internal void Ctor(ActionCtorData ctorData, TriggerCache cache)
        {
            this.type = ctorData.type;
            this.cache = cache;
        }

        public abstract void InitData(object data);
    }
}
