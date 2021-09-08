using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public abstract class ABaseCondMgr
    {
        protected List<ABaseCondition> condList;

        public void Ctor(ITSObjFactory generator, ICollection<CondCtorData> condDataColl)
        {
            if (generator == null)
                throw new System.Exception("TS object generator can not be null.");

            condList = new List<ABaseCondition>(condDataColl.Count);

            // init cond
            IEnumerator<CondCtorData> enumerator = condDataColl.GetEnumerator();
            while (enumerator.MoveNext())
            {
                CondCtorData ctorData = enumerator.Current;
                ABaseCondition cond = generator.GetCondByType(ctorData.type);
                if (cond == null)
                {
                    Tools.LogError("Condition obj is null. Type is : " + ctorData.type);
                    continue;
                }

                cond.Ctor(ctorData);
                cond.InitData(ctorData.data);
                condList.Add(cond);
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

        public abstract bool IsSuccess();
    }
}
