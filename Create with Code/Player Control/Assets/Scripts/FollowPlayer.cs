using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Camera SecondCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 MainCameraOffset = new Vector3(0, 10, -15);
    [SerializeField] private Vector3 SecondCameraOffset = new Vector3(0, 2, 1);
    private bool fPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCamera.enabled = true;
        SecondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (fPressed)
            {
                MainCamera.enabled = true;
                SecondCamera.enabled = false;
                MainCamera.transform.position = player.transform.position + MainCameraOffset;
            }
            else
            {
                MainCamera.enabled = false;
                SecondCamera.enabled = true;
                SecondCamera.transform.position = player.transform.position + SecondCameraOffset;
            }

            fPressed = !fPressed;
        }
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        // Move the cameras to follow the player
        MainCamera.transform.position = player.transform.position + MainCameraOffset;
        SecondCamera.transform.position = player.transform.position + SecondCameraOffset;
    }
}
