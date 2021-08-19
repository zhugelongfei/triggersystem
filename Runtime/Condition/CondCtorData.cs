namespace Lonfee.TriggerSystem
{
    public struct CondCtorData
    {
        public int type;
        public object data;
        public bool isResetOnEnter;

        public CondCtorData(int type, object data = null, bool isResetOnEnter = true)
        {
            this.type = type;
            this.data = data;
            this.isResetOnEnter = isResetOnEnter;
        }
    }
}