using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAircraftInventory : MonoBehaviour
{
    public static PlayerAircraftInventory instance;

    public List<AircraftItems> parts = new List<AircraftItems>();
    public List<AircraftItems> weapons = new List<AircraftItems>();

    public void Add(AircraftItems item)
    {
        parts.Add(item);
        weapons.Add(item);
    }
    
    public void Remove(AircraftItems item)
    {
        parts.Remove(item);
        weapons.Remove(item);
    }
}
