using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public abstract class ABaseActionMgr
    {
        protected ABaseTrigger trigger;
        protected List<ABaseAction> actionList;

        public void Init(ABaseTrigger trigger, ICollection<ActionCtorData> actDataColl)
        {
            this.trigger = trigger;
            actionList = new List<ABaseAction>(actDataColl.Count);

            ITSObjGenerator generator = trigger.TSObjGenerator;

            // init act
            IEnumerator<ActionCtorData> enumerator = actDataColl.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ActionCtorData ctorData = enumerator.Current;
                ABaseAction act = generator.GetActionByType(ctorData.type);
                if (act == null)
                    continue;

                act.Ctor(this, ctorData);
                act.InitData(ctorData.data);
                actionList.Add(act);
            }
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

    }
}
