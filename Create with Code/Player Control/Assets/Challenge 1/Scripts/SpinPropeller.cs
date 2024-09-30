using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public GameObject propeller;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        propeller.transform.Rotate(0, 0, 10);
    }
}
