public class ItemLibraryArmorSet : ItemLibrary
{
    public ArmorSet armorSet;

    public EQUIP_Helmet helmet;
    public EQUIP_Torso torso;
    public EQUIP_Arms arms;
    public EQUIP_Legs legs;

    public EQUIP_Helmet makeHelmet()
    {
        return Instantiate(helmet);
    }

    public EQUIP_Torso makeTorso()
    {
        return Instantiate(torso);
    }

    public EQUIP_Arms makeArms()
    {
        return Instantiate(arms);
    }

    public EQUIP_Legs makeLegs()
    {
        return Instantiate(legs);
    }
}
