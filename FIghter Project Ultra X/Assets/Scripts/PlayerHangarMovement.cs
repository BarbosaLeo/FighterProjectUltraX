using UnityEngine;

public class PlayerHangarMovement : MonoBehaviour
{
    [SerializeField]float speed = 5;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.position += transform.forward * moveY * speed * Time.fixedDeltaTime;
        transform.position += transform.right * moveX * speed * Time.fixedDeltaTime;
    }
}
