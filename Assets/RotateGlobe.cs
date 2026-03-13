using UnityEngine;

public class RotateGlobe : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}