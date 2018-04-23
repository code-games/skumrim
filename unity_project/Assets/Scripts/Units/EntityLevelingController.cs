
public class EntityLevelingController : LevelingController
{
    public const int ENTITY_LEVEL_CAP = 175;

    public override int getLevelCap()
    {
        return ENTITY_LEVEL_CAP;
    }

    public EntityLevelingController() : base() { }
}
