using UnityEngine.Events;

public class SkillLevelUpEvent : UnityEvent<Skill> { }

public class Skill : LevelingController
{
    #region Static

    public const int SKILL_LEVEL_CAP = 100;

    #endregion

    #region Properties

    public string name { get; protected set; }
    //in the future this will take in account the buffs and debuffs
    public int value { get { return level; } } 

    public override int getLevelCap()
    {
        return SKILL_LEVEL_CAP;
    }

    public new SkillLevelUpEvent levelUpCallback;

    #endregion

    #region Constructors

    public Skill(string name, int level, int xp) : base(level, xp)
    {
        this.name = name;
        this.levelUpCallback = new SkillLevelUpEvent();
    }

    public Skill(string name, int level) : this(name, level, 0) { }

    public Skill(string name) : this(name, 15, 0) { }

    #endregion

    #region Methods

    protected override void levelUp()
    {
        base.levelUp();

        levelUpCallback.Invoke(this);
    }

    #endregion
}
