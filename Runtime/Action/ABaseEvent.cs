namespace Lonfee.TriggerSystem
{
    public abstract class ABaseEvent : ABaseAction
    {
        protected override void OnEnter()
        {
            DoAction();
        }

        protected override void OnExit()
        {

        }

        protected abstract void DoAction();

    }
}
