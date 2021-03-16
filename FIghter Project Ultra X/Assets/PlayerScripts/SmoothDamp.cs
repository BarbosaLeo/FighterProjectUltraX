using UnityEngine;

static class SmoothDamp
{
    static public Quaternion Rotate(Quaternion a, Quaternion b, float speed, float dt)
    {
        return Quaternion.Slerp(a, b, 1 - Mathf.Exp(-speed * dt));
    }
    
    static public float Move(float a, float b, float speed, float dt)
    {
        return Mathf.Lerp(a, b, 1 - Mathf.Exp(-speed * dt));
    }
}
