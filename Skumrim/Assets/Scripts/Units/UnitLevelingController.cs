
public class UnitLevelingController : LevelingController
{
    public const int UNIT_LEVEL_CAP = 175;

    public override int getLevelCap()
    {
        return UNIT_LEVEL_CAP;
    }

    public UnitLevelingController() : base() { }
}
