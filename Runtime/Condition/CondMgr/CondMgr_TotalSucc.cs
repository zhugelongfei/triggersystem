namespace Lonfee.TriggerSystem
{
    public class CondMgr_TotalSucc : ABaseCondMgr
    {
        protected override void OnEnter()
        {
            for (int i = 0; i < condList.Count; i++)
            {
                condList[i].Enter();
            }
        }

        protected override void OnExit()
        {
            for (int i = 0; i < condList.Count; i++)
            {
                condList[i].Exit();
            }
        }

        public override bool IsSuccess()
        {
            bool isTotalSucc = true;
            for (int i = 0; i < condList.Count; i++)
            {
                ABaseCondition item = condList[i];

                if (!item.IsSuccess)
                {
                    isTotalSucc = false;
                    break;
                }
            }

            return isTotalSucc;
        }
    }
}
