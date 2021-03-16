using UnityEngine;

public class HangarCameraController : MonoBehaviour
{
    [SerializeField] float mouseX = 0f;
    [SerializeField] float mouseY = 0f;
    [SerializeField] float mouseSens = 5f;
    public Transform playerBody;
    public Transform playerCameraLocation;

    [Space]
    [SerializeField] float rotationSpeed = 8;
    public Transform aircraftLocation;
    public Transform aircraftCameraLocation;

    [SerializeField]bool hangarCameraEnabled = false;

    [Space]
    [SerializeField] public GameObject aircraftMenu;


    private void Awake()
    {
        transform.parent = playerBody;
    }
    private void Update()
    {
        Vector3 targetPosition;

        if (hangarCameraEnabled == false && Input.GetKeyDown(KeyCode.E))
        {
            hangarCameraEnabled = true;

            transform.forward = aircraftCameraLocation.forward;
            targetPosition = aircraftCameraLocation.position;
            transform.position = targetPosition;
        }

        else if(hangarCameraEnabled == true && Input.GetKeyDown(KeyCode.E))
        {
            hangarCameraEnabled = false;

            transform.parent = playerBody;
            targetPosition = playerCameraLocation.position;
            transform.position = targetPosition;
            transform.rotation = playerBody.rotation;
        }


        if (hangarCameraEnabled == true)
        {
            transform.parent = aircraftCameraLocation;
            transform.RotateAround(aircraftLocation.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        
        else if(hangarCameraEnabled == false)
        {

            mouseX += Input.GetAxis("Mouse X") * mouseSens;
            mouseY += Input.GetAxis("Mouse Y") * mouseSens;

            mouseY = Mathf.Clamp(mouseY, -90f, 90f);

            playerBody.transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
            transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0f);
        }

        EnableAircraftHUD();
        
    }

    void EnableAircraftHUD()
    {
        if (hangarCameraEnabled == true)
        {
            aircraftMenu.SetActive(true);
        }
        else aircraftMenu.SetActive(false);
    }
}
