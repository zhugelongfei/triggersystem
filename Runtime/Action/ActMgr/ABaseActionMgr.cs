using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public abstract class ABaseActionMgr
    {
        protected List<ABaseAction> actionList;

        public void Ctor(ITSObjFactory generator, ICollection<ActionCtorData> actDataColl, TriggerCache cache = null)
        {
            if (generator == null)
                throw new System.Exception("TS object generator can not be null.");

            actionList = new List<ABaseAction>(actDataColl.Count);

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

                act.Ctor(ctorData, cache);
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
