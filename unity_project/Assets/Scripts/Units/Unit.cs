using UnityEngine;

public class Unit : MonoBehaviour
{
    public StartingStats startingStats;
    public Stats stats;

    public EntityLevelingController levelingController;

    [HideInInspector]
    public EquipController equipments;
    [HideInInspector]
    public Inventory inventory;

    public virtual void Awake()
    {
        stats = new Stats(this, startingStats);
        levelingController = new EntityLevelingController();
        equipments = GetComponent<EquipController>();
        inventory = GetComponent<Inventory>();
    }

    public virtual void Start()
    {
    }

    public virtual void Init()
    {
    }

    public void Die()
    {
        IOController.io.LogSystem(this.name + " is dead");
    }
}
