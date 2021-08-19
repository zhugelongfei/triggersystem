namespace Lonfee.TriggerSystem
{
    public interface ITSObjGenerator
    {
        ABaseAction GetActionByType(int type);

        ABaseCondition GetCondByType(int type);
    }
}
