namespace Lonfee.TriggerSystem.Samples
{
    public class TsObjGenerator : ITSObjGenerator
    {
        public ABaseAction GetActionByType(int type)
        {
            EActionType actType = (EActionType)type;
            switch (actType)
            {
                case EActionType.HitEnemy:
                    return new Act_HitEnemy();
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
                case EConditionType.PlayerEnterTrap:
                    return new Cond_PlayerEnterTrap();
                default:
                    break;
            }
            return null;
        }

    }
}