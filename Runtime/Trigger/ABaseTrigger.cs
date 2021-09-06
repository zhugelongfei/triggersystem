namespace Lonfee.TriggerSystem
{
    public abstract class ABaseTrigger
    {
        private ITSObjFactory generator;

        internal ITSObjFactory TSObjGenerator
        {
            get { return generator; }
        }

        public abstract bool IsFinished { get; }

        public ABaseTrigger(ITSObjFactory generator)
        {
            if (generator == null)
                throw new System.Exception("TS object generator can not be null.");

            this.generator = generator;
        }

        public abstract void Start();

        public abstract void Stop();

        public abstract void Update(float delta);

    }
}
