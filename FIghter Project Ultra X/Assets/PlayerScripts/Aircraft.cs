using UnityEngine;

public class FlightInput
{
    public float Roll = 0f;
    public float Pitch = 0f;
    public float Yaw = 0f;
    public float Throttle = 1f;
}

public class Aircraft : MonoBehaviour
{
    [Header("Unity Properties")]
    public bool usedFixedUpdate = false;
    public float startSpeed = 200f;
    public FlightInput FlightInput = new FlightInput();
    public bool IsPlayer = false;
    [Space]
    
    [Header("Plane Properties")]
    public float pitchRate = 30f;
    public float pitchMax = 5f;
    [Space]
    public float rollRate = 120f;
    public float rollMax = 5f;
    [Space]
    public float yawRate = 6f;
    public float yawMax = 2f;
    [Space]
    public bool isInHangar = false;

    public Vector3 velocity { get; private set; } = Vector3.zero;

    private float pitch = 0f;
    private float roll = 0f;
    private float yaw = 0f;

    private void Awake()
    {
        if (isInHangar == true)
        {
            return;
        }
        velocity = transform.forward * startSpeed;

        //if (IsPlayer) ;
    }

    private void FixedUpdate()
    {
        if (usedFixedUpdate)
            RunFlightModel(Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (!usedFixedUpdate)
            RunFlightModel(Time.deltaTime);

        ReadPlayerInput();
    }

    private void ReadPlayerInput()
    {
        FlightInput.Pitch = Input.GetAxis("Vertical"); 
        FlightInput.Roll = Input.GetAxis("Horizontal");
        FlightInput.Yaw = Input.GetAxis("Yaw");
    }

    private void RunFlightModel(float deltaTime)
    {
        velocity = transform.forward * velocity.magnitude;
        transform.position += velocity * deltaTime;

        var targetPitch = FlightInput.Pitch * pitchRate;
        pitch = SmoothDamp.Move(pitch, targetPitch, pitchMax, deltaTime);
        var pitchRot = Quaternion.AngleAxis(pitch * deltaTime, Vector3.right);

        var targetRoll = FlightInput.Roll * rollRate;
        roll = SmoothDamp.Move(roll, targetRoll, rollMax, deltaTime);
        var rollRot = Quaternion.AngleAxis(roll * deltaTime, Vector3.back);

        var targetYaw = FlightInput.Yaw * yawRate;
        yaw = SmoothDamp.Move(yaw, targetYaw, yawMax, deltaTime);
        var yawRot = Quaternion.AngleAxis(yaw * yawRate * deltaTime, Vector3.up);

        transform.localRotation *= pitchRot * rollRot * yawRot;
    }
}
