using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Aircraft aircraft;

    float compensation;
    float rollOffset;
    private Vector3 vel = Vector3.zero;

    private void Start()
    {
        aircraft = GameObject.FindObjectOfType<Aircraft>();
    }

    void FixedUpdate()
    {
        transform.position = target.TransformPoint(Vector3.back * aircraft.velocity.magnitude/10);

        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, .45f);

    }

    void Update()
    {
        compensation = aircraft.velocity.magnitude / 1000;
        rollOffset = Input.GetAxis("Horizontal");
        rollOffset *= .1f;
        print(rollOffset);
    }

}
