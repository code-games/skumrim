using UnityEngine;

public class Stats
{
    #region Properties

    private Unit owner;
    public float xp;

    public int hitpoints;
    public int maxHitPoints;
    public int magicka;
    public int maxMagicka;
    public int stamina;
    public int maxStamina;

    public int carryingCapacity { get { return maxStamina / 2; } }

    //Combat
    public Skill archery;
    public Skill oneHanded;
    public Skill twoHanded;
    public Skill block;
    public Skill heavyArmor;
    public Skill lightArmor;

    //Magic
    public Skill alteration;
    public Skill conjuration;
    public Skill destruction;
    public Skill illusion;
    public Skill restoration;

    //Thief
    public Skill lockpicking;
    public Skill pickpocket;
    public Skill sneak;

    //Crafting
    public Skill smithing;
    public Skill enchanting;
    public Skill alchemy;
    public Skill cooking;

    //Other
    public Skill search;
    public Skill speech;
    public Skill hunting;

    #endregion

    public Stats(Unit owner, StartingStats sstats)
    {
        this.owner = owner;

        this.maxHitPoints = sstats.maxHitPoints;
        this.maxMagicka = sstats.maxMagicka;
        this.maxStamina = sstats.maxStamina;

        archery =       new Skill("archery", sstats.archery);
        oneHanded =     new Skill("one-handed", sstats.oneHanded);
        twoHanded =     new Skill("two-handed", sstats.twoHanded);
        block =         new Skill("block", sstats.block);
        heavyArmor =    new Skill("heavy armor", sstats.heavyArmor);
        lightArmor =    new Skill("light armor", sstats.lightArmor);

        alteration =    new Skill("alteration", sstats.alteration);
        conjuration =   new Skill("conjuration", sstats.conjuration);
        destruction =   new Skill("destruction", sstats.destruction);
        illusion =      new Skill("illusion", sstats.illusion);
        restoration =   new Skill("restoration", sstats.restoration);

        lockpicking =   new Skill("lock-picking", sstats.lockpicking);
        pickpocket =    new Skill("pickpocket", sstats.pickpocket);
        sneak =         new Skill("sneak", sstats.sneak);

        smithing =      new Skill("smithing", sstats.smithing);
        enchanting =    new Skill("enchanting", sstats.enchanting);
        alchemy =       new Skill("alchemy", sstats.alchemy);
        cooking =       new Skill("cooking", sstats.cooking);

        search =        new Skill("search", sstats.search);
        speech =        new Skill("speech", sstats.speech);
        hunting =       new Skill("hunting", sstats.hunting);

        addLevelUpListeners();
    }

    #region Methods

    private void addLevelUpListeners()
    {
        archery.    levelUpCallback.AddListener(SkillLevelUp);
        oneHanded.  levelUpCallback.AddListener(SkillLevelUp);
        twoHanded.  levelUpCallback.AddListener(SkillLevelUp);
        block.      levelUpCallback.AddListener(SkillLevelUp);
        heavyArmor. levelUpCallback.AddListener(SkillLevelUp);
        lightArmor. levelUpCallback.AddListener(SkillLevelUp);
                    
        alteration. levelUpCallback.AddListener(SkillLevelUp);
        conjuration.levelUpCallback.AddListener(SkillLevelUp);
        destruction.levelUpCallback.AddListener(SkillLevelUp);
        illusion.   levelUpCallback.AddListener(SkillLevelUp);
        restoration.levelUpCallback.AddListener(SkillLevelUp);
                    
        lockpicking.levelUpCallback.AddListener(SkillLevelUp);
        pickpocket. levelUpCallback.AddListener(SkillLevelUp);
        sneak.      levelUpCallback.AddListener(SkillLevelUp);
                    
        smithing.   levelUpCallback.AddListener(SkillLevelUp);
        enchanting. levelUpCallback.AddListener(SkillLevelUp);
        alchemy.    levelUpCallback.AddListener(SkillLevelUp);
        cooking.    levelUpCallback.AddListener(SkillLevelUp);
                    
        search.     levelUpCallback.AddListener(SkillLevelUp);
        speech.     levelUpCallback.AddListener(SkillLevelUp);
        hunting.    levelUpCallback.AddListener(SkillLevelUp);
    }

    #region HP, MP and Stamina

    public void Damage(int ammount)
    {
        hitpoints -= ammount;

        if (hitpoints <= 0)
            owner.Die();
    }
    public void Heal(int ammount)
    {
        hitpoints += ammount;

        if (hitpoints > maxHitPoints)
            hitpoints = maxHitPoints;
    }
    public void DepleteHitpoints()
    {
        hitpoints = 0;
    }
    public void HealAll()
    {
        hitpoints = maxHitPoints;
    }


    public bool UseMagicka(int ammount)
    {
        if (ammount > this.magicka)
        {
            return false;
        }
        this.magicka -= ammount;
        return true;
        
    }
    public void RegenMagicka(int ammount)
    {
        magicka += ammount;

        if (magicka > maxMagicka)
            magicka = maxMagicka;
    }
    public void DepleteMagicka()
    {
        magicka = 0;
    }
    public void RegenAllMagicka()
    {
        magicka = maxMagicka;
    }

    
    public bool UseStamina(int ammount)
    {
        if (ammount > this.stamina)
        {
            return false;
        }
        this.stamina -= ammount;
        return true;
    }
    public void RegenStamina(int ammount)
    {
        stamina += ammount;

        if (stamina > maxStamina)
            stamina = maxStamina;
    }
    public void DepleteStamina()
    {
        stamina = 0;
    }
    public void RegenAllStamina()
    {
        stamina = maxStamina;
    }

    #endregion

    public void SkillLevelUp(Skill skill)
    {
        Debug.Log(skill.name + " leveling up to " + skill.level);
        owner.levelingController.GiveXP(1);
    }

    #endregion
}
