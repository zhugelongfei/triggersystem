namespace Lonfee.TriggerSystem.Samples
{
    public class TsObjGenerator : ITSObjGenerator
    {
        public ABaseAction GetActionByType(int type)
        {
            EActionType actType = (EActionType)type;
            switch (actType)
            {
                case EActionType.LogError:
                    return new Act_LogError();
                default:
                    break;
            }
            return null;
        }

        public ABaseCondition GetCondByType(int type)
        {
            EConditionType condType = (EConditionType)type;
            switch (condType)
            {
                case EConditionType.KeyDown:
                    return new Cond_KeyDown();
                default:
                    break;
            }
            return null;
        }

    }
}