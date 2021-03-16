using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    Part[] currentEquipedParts;
    GameObject[] currentMesh;

    public Part[] defaultParts;

    public delegate void OnEquipmentChanged(Part newPart, Part oldPart);
    public OnEquipmentChanged onEquipmentChanged;

    public void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(AircraftPart)).Length;
        currentEquipedParts = new Part[numSlots];
        currentMesh = new GameObject[numSlots];

        EquipDefaultItems();
    }

    public void Equip(Part newPart)
    {

        int partSlot = (int)newPart.partSlot;
        Part oldPart = Unequip(partSlot);

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newPart, oldPart);
        }

        currentEquipedParts[partSlot] = newPart;

        GameObject newMesh = Instantiate(newPart.partMesh, this.transform);

        currentMesh[partSlot] = newMesh;
    }

    public Part Unequip(int slotIndex)
    {
        if (currentEquipedParts[slotIndex] != null)
        {
            if (currentMesh[slotIndex] != null)
            {
                Destroy(currentMesh[slotIndex]);
            }

            Part oldPart = currentEquipedParts[slotIndex];
            currentEquipedParts[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldPart);
            }
            return oldPart;
        }
        return null;

    }

    void EquipDefaultItems()
    {
        foreach(Part part in defaultParts)
        {
            Equip(part);
        }
    }

    public void SaveCurrentToLoadout()
    {
        PlayerPrefs.Save();
    }

}
