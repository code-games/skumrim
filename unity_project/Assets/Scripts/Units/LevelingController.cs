using UnityEngine.Events;

public class LevelUpEvent : UnityEvent<LevelingController> { }

public class LevelingController
{
    #region Properties

    public int level { get; private set; }
    public float xp { get; private set; }

    public float xpToNextLevel
    {
        get
        {
            float v = this.getXPThresholdToGetToLevel(level + 1);

            if (v == -1)
                return v;

            return v - xp;
        }
    }

    public virtual int getLevelCap() { return 100; }

    public bool isAtLevelCap { get { return this.level == this.getLevelCap(); } }

    public LevelUpEvent levelUpCallback;

    #endregion

    #region Constructors

    public LevelingController(int startingLevel, float startingXP)
    {
        this.level = startingLevel;
        this.xp = startingXP;

        this.levelUpCallback = new LevelUpEvent();
    }

    public LevelingController() : this(1, 0) { }

    #endregion

    #region Methods

    public virtual bool GiveXP(float ammount)
    {
        if (!this.isAtLevelCap)
        {
            this.xp += ammount;
            return this.checkLevelUp();
        }

        return false;
    }

    public virtual void ResetLevel()
    {
        level = 1;
        xp = 0;
    }

    //Override this is you want to change the way leveling xp scales
    protected virtual float getXPThresholdToGetToLevel(int nextLevel)
    {
        return nextLevel;
    }

    //override this to change level up behaviour
    protected virtual void levelUp()
    {
        xp = this.xpToNextLevel * (-1);
        level++;

        //just to make sure we didn't level up more than once
        if (xp > 0)
            if (!this.checkLevelUp())
                levelUpCallback.Invoke(this);
    }

    protected virtual bool checkLevelUp()
    {
        if (this.xpToNextLevel <= 0)
        {
            this.levelUp();
            return true;
        }

        return false;
    }

    #endregion
}
