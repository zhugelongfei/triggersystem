namespace Lonfee.TriggerSystem
{
    public class ActMgr_TotalEnter : ABaseActionMgr
    {
        protected override void OnEnter()
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                actionList[i].Enter();
            }
        }

        protected override void OnExit()
        {
            for (int i = 0; i < actionList.Count; i++)
            {
                actionList[i].Exit();
            }
        }
    }
}
