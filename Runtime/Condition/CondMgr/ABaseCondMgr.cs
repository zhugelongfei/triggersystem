using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public abstract class ABaseCondMgr
    {
        protected ABaseTrigger trigger;
        protected List<ABaseCondition> condList;

        /// <summary>
        /// use it like ctor.(to avoid write white block ctor in sub class)
        /// </summary>
        public void Init(ABaseTrigger trigger, ICollection<CondCtorData> condDataColl)
        {
            this.trigger = trigger;
            condList = new List<ABaseCondition>(condDataColl.Count);

            ITSObjGenerator generator = trigger.TSObjGenerator;

            // init cond
            IEnumerator<CondCtorData> enumerator = condDataColl.GetEnumerator();
            while (enumerator.MoveNext())
            {
                CondCtorData ctorData = enumerator.Current;
                ABaseCondition cond = generator.GetCondByType(ctorData.type);
                if (cond == null)
                    continue;

                cond.Ctor(this, ctorData);
                cond.InitData(ctorData.data);
                condList.Add(cond);
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

        public abstract bool IsSuccess();
    }
}
