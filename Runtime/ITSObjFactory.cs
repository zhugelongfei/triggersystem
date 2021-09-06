namespace Lonfee.TriggerSystem
{
    public interface ITSObjFactory
    {
        ABaseAction GetActionByType(int type);

        ABaseCondition GetCondByType(int type);
    }
}
