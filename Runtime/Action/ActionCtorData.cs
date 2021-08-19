namespace Lonfee.TriggerSystem
{
    public struct ActionCtorData
    {
        public int type;
        public object data;

        public ActionCtorData(int type, object data = null)
        {
            this.type = type;
            this.data = data;
        }
    }
}