namespace Lonfee.TriggerSystem
{
    public abstract class ABaseTrigger
    {
        public abstract bool IsFinished { get; }

        public abstract void Start();

        public abstract void Stop();

        public abstract void Update(float delta);

    }
}
