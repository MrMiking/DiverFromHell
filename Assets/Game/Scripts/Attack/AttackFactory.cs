public static class AttackFactory
{
    public static IAttack CreateAttack(AttackType type, EntityAttackData data)
    {
        switch (type)
        {
            case AttackType.Melee:
                return new MeleeAttack(data);
            case AttackType.Range:
                return null;
            default:
                throw new System.ArgumentException($"Unknown AttackType: {type}");
        }
    }
}