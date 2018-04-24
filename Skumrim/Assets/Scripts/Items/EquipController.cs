#pragma warning disable 0414

using UnityEngine;

[RequireComponent(typeof(Unit))]
public class EquipController : MonoBehaviour
{
    private Unit owner;
    private Inventory inventory;

    public Equipment head { get; protected set; }
    public Equipment torso { get; protected set; }
    public Equipment legs { get; protected set; }
    public Equipment arms { get; protected set; }

    public Equipment neck { get; protected set; }
    public Equipment ring { get; protected set; }
    public Equipment shield { get; protected set; }
    public Equipment quiver { get; protected set; }

    public Weapon weapon;

    private void Awake()
    {
        owner = GetComponent<Unit>();
    }

    private void Start()
    {
        inventory = owner.inventory;
    }

    private void showSlot(string slotName, Equipment slot)
    {
        if (slot)
            IOController.io.Log(slotName + ": " + slot.name);
        else
            IOController.io.Log(slotName + ": Empty");
    }

    public void ShowSlotWithName(string slot)
    {
        switch (slot)
        {
            case "helm":
            case "head":
                this.showSlot("Head", head);
                break;
            case "armor":
            case "torso":
                this.showSlot("Torso", torso);
                break;
            case "leg":
            case "legs":
                this.showSlot("Legs", legs);
                break;
            case "arm":
            case "arms":
                this.showSlot("Arms", arms);
                break;
            case "necklace":
            case "neck":
                this.showSlot("Neck", neck);
                break;
            case "rings":
            case "ring":
                this.showSlot("Ring", ring);
                break;
            case "shield":
                this.showSlot("Shield", shield);
                break;
            case "quiver":
                this.showSlot("Quiver", quiver);
                break;
            case "weapon":
                this.showSlot("Weapon", weapon);
                break;
            default:
                IOController.io.LogError("No such slot name: '" + slot + "'");
                break;

        }
    }

    public void Show()
    {
        this.showSlot("Head", head);
        this.showSlot("Torso", torso);
        this.showSlot("Legs", legs);
        this.showSlot("Arms", arms);
        this.showSlot("Neck", neck);
        this.showSlot("Ring", ring);
        this.showSlot("Shield", shield);
        this.showSlot("Quiver", quiver);
        this.showSlot("Weapon", weapon);
    }

    public Item Equip(Equipment equip)
    {
        Item ret = null;

        switch (equip.getEquipmentType())
        {
            case EquipmentType.Head:
                if (head)
                {
                    if (head != equip)
                    {
                        ret = head;
                    }
                    else
                        return null;
                }
                head = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Torso:
                if (torso)
                {
                    if (torso != equip)
                    {
                        ret = torso;
                    }
                    else
                        return null;
                }
                torso = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Legs:
                if (legs)
                {
                    if (legs != equip)
                    {
                        ret = legs;
                    }
                    else
                        return null;
                }
                legs = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Arms:
                if (arms)
                {
                    if (arms != equip)
                    {
                        ret = arms;
                    }
                    else
                        return null;
                }
                arms = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Necklace:
                if (neck)
                {
                    if (neck != equip)
                    {
                        ret = neck;
                    }
                    else
                        return null;
                }
                neck = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Ring:
                if (ring)
                {
                    if (ring != equip)
                    {
                        ret = ring;
                    }
                    else
                        return null;
                }
                ring = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Shield:
                if (shield)
                {
                    if (shield != equip)
                    {
                        ret = shield;
                    }
                    else
                        return null;
                }
                shield = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Quiver:
                if (quiver)
                {
                    if (quiver != equip)
                    {
                        ret = quiver;
                    }
                    else
                        return null;
                }
                quiver = equip;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            case EquipmentType.Weapon:
                if (weapon)
                {
                    if (weapon != equip)
                    {
                        ret = weapon;
                    }
                    else
                        return null;
                }
                weapon = equip as Weapon;
                inventory.getItemWithName(equip.name).TakeOne();
                break;
            default:
                IOController.io.LogError("'" + equip.name + "' is not supposed to be equipped");
                break;
        }

        return ret;
    }

    public void Unequip(string slot)
    {
        switch (slot)
        {
            case "helm":
            case "head":
                if (head)
                {
                    inventory.AddItem(head);
                    head = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "armor":
            case "torso":
                if (torso)
                {
                    inventory.AddItem(torso);
                    torso = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "leg":
            case "legs":
                if (legs)
                {
                    inventory.AddItem(legs);
                    legs = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "arm":
            case "arms":
                if (arms)
                {
                    inventory.AddItem(arms);
                    arms = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "necklace":
            case "neck":
                if (neck)
                {
                    inventory.AddItem(neck);
                    neck = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "rings":
            case "ring":
                if (ring)
                {
                    inventory.AddItem(ring);
                    ring = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "shield":
                if (shield)
                {
                    inventory.AddItem(shield);
                    shield = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "quiver":
                if (quiver)
                {
                    inventory.AddItem(quiver);
                    quiver = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            case "weapon":
                if (weapon)
                {
                    inventory.AddItem(weapon);
                    weapon = null;
                }
                else
                {
                    IOController.io.Log("You have no item equipped on this slot");
                }
                break;
            default:
                IOController.io.LogError("No such slot name: '" + slot + "'");
                break;

        }
    }
}
