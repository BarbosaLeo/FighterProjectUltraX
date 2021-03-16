
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    public GameObject aircraftMesh;

    public float baseSpeed = 10;
    public float currentSpeed = 10;
    float maxSpeed = 80;
    float minSpeed = 5;

    private float yawSpeed = 4;
    private float turnSpeed = 50;
    private float pitchSpeed = 40;

    float rotate;
    float pitch;
    float yaw;

    public float accelerationRate;
    public float decelRate;
    public float yawRate;

    public float throttle;
    public float offsetRot;

    public float tSpeed;

    void Start()
    {
        aircraftMesh = GameObject.FindGameObjectWithTag("AircraftMesh");
    }


    //
    //Update aircraft position and transform throught FixedUpdate to prevent advantage in higher FPS.
    //
    void FixedUpdate()
    {
        Vector3 aircraftDirection = transform.forward;

        //float incrementedTurnSpeed = Mathf.RoundToInt(turnSpeed + accel * 15f);

        transform.Rotate(Vector3.back * rotate * turnSpeed * Time.fixedDeltaTime);

        transform.Rotate(Vector3.right * pitch * pitchSpeed * Time.fixedDeltaTime);

        transform.Rotate(Vector3.up * yaw * yawSpeed * Time.fixedDeltaTime);

        if (throttle > 0)
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, maxSpeed, ref currentSpeed, .025f, .03f);
            if (currentSpeed >= maxSpeed) throttle = 0;
        }
        if (throttle < 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, minSpeed, .02f);
        }
        if (throttle == 0)
        {
            if (currentSpeed > baseSpeed)
                currentSpeed -= .05f;
            if (currentSpeed < baseSpeed)
                currentSpeed = Mathf.SmoothDamp(currentSpeed, baseSpeed, ref currentSpeed, .02f, .03f);
        }


        //Move aircraft
        transform.position += aircraftDirection * currentSpeed * Time.fixedDeltaTime;

        tSpeed = currentSpeed;
    }

    //
    // receive inputs through update
    //
    void Update()
    {
        // Aircraft pitch n roll movement
        rotate = Input.GetAxis("Horizontal");
        offsetRot = Input.GetAxisRaw("Horizontal");
        pitch = Input.GetAxis("Vertical");
        if (pitch > .4f) pitch = .4f;

        //Aircraft Yaw movement
        yaw = Input.GetAxis("Yaw");
        yawRate = yaw * 1.5f;

        throttle = Input.GetAxis("Throttle");
    }

    private void GetPlayerInput()
    {
        
    }
}
