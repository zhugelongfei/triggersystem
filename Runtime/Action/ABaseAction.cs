namespace Lonfee.TriggerSystem
{
    public abstract class ABaseAction
    {
        private int type;

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

        internal void Ctor(ActionCtorData ctorData)
        {
            this.type = ctorData.type;
        }

        public abstract void InitData(object data);
    }
}
