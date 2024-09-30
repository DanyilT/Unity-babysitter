using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    public float turnSpeed = 300f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
