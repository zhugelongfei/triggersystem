namespace Lonfee.TriggerSystem
{
    public abstract class ABaseTrigger
    {
        private ITSObjGenerator generator;

        public ITSObjGenerator TSObjGenerator
        {
            get { return generator; }
        }

        public ABaseTrigger(ITSObjGenerator generator)
        {
            if (generator == null)
                throw new System.Exception("TS object generator can not be null.");

            this.generator = generator;
        }

        public abstract void Start();

        public abstract void Stop();

        public abstract void Update(float delta);

        public abstract bool IsFinished();
    }
}
