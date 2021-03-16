using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aircraft Part/New Part")]
public class Part : AircraftItems
{
    public AircraftPart partSlot;
    public bool isDefault;

    [Space]
    public float speedModifier;
    public float maxSpeedModifier;
    public float minSpeedModifier;
    [Space]
    public float pitchModifier;
    public float rollModifier;
    public float yawModifier;
    [Space]
    public GameObject partMesh;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }
}

public enum AircraftPart { Nose, Fuselage, Wing, Elevator, Rudder, Thruster }
