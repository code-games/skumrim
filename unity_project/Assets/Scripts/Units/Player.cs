using UnityEngine;

public class Player : Unit
{
    public static Player player;

    public override void Awake()
    {
        base.Awake();
        player = this;

        this.name = "Nihal";
    }

    public override void Init()
    {
       
    }
}
