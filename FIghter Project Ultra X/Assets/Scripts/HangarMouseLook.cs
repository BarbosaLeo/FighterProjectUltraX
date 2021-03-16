using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarMouseLook : MonoBehaviour
{

    float mouseSens = 3f;
    public Transform playerBody;

    float mouseX = 0;
    float mouseY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mouseX += Input.GetAxis("Mouse X") * mouseSens;
        mouseY += Input.GetAxis("Mouse Y") * mouseSens;

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        playerBody.transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
        transform.rotation = Quaternion.Euler(-mouseY,mouseX,0f);
    }
}
