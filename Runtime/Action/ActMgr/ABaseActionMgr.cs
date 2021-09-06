using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public abstract class ABaseActionMgr
    {
        protected ABaseTrigger trigger;
        protected List<ABaseAction> actionList;

        internal void Init(ABaseTrigger trigger, ICollection<ActionCtorData> actDataColl)
        {
            this.trigger = trigger;
            actionList = new List<ABaseAction>(actDataColl.Count);

            ITSObjFactory generator = trigger.TSObjGenerator;

            // init act
            IEnumerator<ActionCtorData> enumerator = actDataColl.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ActionCtorData ctorData = enumerator.Current;
                ABaseAction act = generator.GetActionByType(ctorData.type);
                if (act == null)
                {
                    Tools.LogError("Action obj is null. Type is : " + ctorData.type);
                    continue;
                }

                act.Ctor(this, ctorData);
                act.InitData(ctorData.data);
                actionList.Add(act);
            }
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

    }
}
