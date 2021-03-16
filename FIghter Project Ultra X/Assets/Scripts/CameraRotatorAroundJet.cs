using UnityEngine;

public class CameraRotatorAroundJet : MonoBehaviour
{
    public float speed = 8;
    public Transform aircraftLocation;

    void Update()
    {
        transform.RotateAround(aircraftLocation.position, Vector3.up, speed * Time.deltaTime);       
    }
}
