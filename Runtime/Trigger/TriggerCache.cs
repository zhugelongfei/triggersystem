using System.Collections.Generic;

namespace Lonfee.TriggerSystem
{
    public class TriggerCache
    {
        private Dictionary<string, object> dataDic = null;

        public object this[string key]
        {
            get
            {
                if (dataDic == null || !dataDic.ContainsKey(key))
                    return null;
                return dataDic[key];
            }
            set
            {
                if (dataDic == null)
                    dataDic = new Dictionary<string, object>();

                dataDic[key] = value;
            }
        }

        public bool Contains(string key)
        {
            return dataDic != null && dataDic.ContainsKey(key);
        }

        public void Clear()
        {
            // if dic is created, next start trigger the dic will be created, so there only clear dic.
            if (dataDic != null)
                dataDic.Clear();
        }
    }
}