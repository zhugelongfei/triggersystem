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

        public void Enter()
        {
            OnEnter();
        }

        protected abstract void OnEnter();

        public void Exit()
        {
            OnExit();
        }

        protected abstract void OnExit();

        public void Ctor(ABaseActionMgr actMgr, ActionCtorData ctorData)
        {
            this.actMgr = actMgr;
            this.type = ctorData.type;
        }

        public abstract void InitData(object data);
    }
}
