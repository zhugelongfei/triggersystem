namespace Lonfee.TriggerSystem
{
    public abstract class ABaseAction
    {
        private int type;

        protected ABaseActionMgr actMgr;

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

        internal void Ctor(ABaseActionMgr actMgr, ActionCtorData ctorData)
        {
            this.actMgr = actMgr;
            this.type = ctorData.type;
        }

        public abstract void InitData(object data);
    }
}
