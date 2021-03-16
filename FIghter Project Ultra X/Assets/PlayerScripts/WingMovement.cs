using UnityEngine;

public class WingMovement : MonoBehaviour
{
    float inputX;
    float inputY;

    public GameObject wingL;
    public GameObject wingR;

    public Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        direction.x = inputX;
        direction.y = inputY;

        RotateWings(direction.x, direction.y);
    }

    void RotateWings(float inputX, float inputY)
    {
        
    }
}
