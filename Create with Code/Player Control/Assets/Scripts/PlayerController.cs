using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 1000;
    [SerializeField] private float turnSpeed = 100;
    private float speed;
    private float rpm;
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;

    [SerializeField] private List<WheelCollider> allWheels;
    private int wheelsOnGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input from player
        horizontalInput = Input.GetAxis(horizontalInputName);
        verticalInput = Input.GetAxis(verticalInputName);

        // Check if the vehicle is on the ground
        if (IsOnGround())
        {
            // Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            // Turning the vehicle
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

            // Print the speed
            speed = Mathf.Round(playerRb.linearVelocity.magnitude * 2.237f); // 3.6f for km/h
            speedometerText.SetText("Speed: " + speed + " mph");

            // Print the RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
