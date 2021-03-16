using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    PlayerAircraftInventory inventory;
    EquipmentManager equipmentManager;

    void Start()
    {
        inventory = PlayerAircraftInventory.instance;
        equipmentManager = EquipmentManager.instance;
    }

    public void UpdateMesh(Part part)
    {
        equipmentManager.Equip(part);
    }

    public void SaveLoadout(Part part)
    {
        equipmentManager.SaveCurrentToLoadout();
    }
}
