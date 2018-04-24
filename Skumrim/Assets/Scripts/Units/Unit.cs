using UnityEngine;

public class Unit : MonoBehaviour
{
    public StartingStats startingStats;
    public Stats stats;

    public UnitLevelingController levelingController;

    [HideInInspector]
    public EquipController equipments;

    public Inventory inventory;

    public virtual void Awake()
    {
        stats = new Stats(this, startingStats);
        levelingController = new UnitLevelingController();
        equipments = GetComponent<EquipController>();
    }

    public virtual void Start()
    {
    }

    public virtual void Init()
    {
        Debug.Log(name + ".Init()");

        inventory.Init(this, equipments);
    }

    public void Die()
    {
        IOController.io.LogSystem(this.name + " is dead");
    }
}
