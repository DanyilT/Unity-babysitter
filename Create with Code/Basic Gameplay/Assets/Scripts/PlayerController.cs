using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InterfaceManager interfaceScript;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]  private float speed = 20.0f;
    [SerializeField]  private float xRange = 15;
    [SerializeField] private float zRangeTop = 5;
    [SerializeField] private float zRangeBottom = -2;
    //public GameObject projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find and assign the InterfaceManager script
        interfaceScript = FindObjectOfType<InterfaceManager>();
        if (interfaceScript == null)
        {
            Debug.LogError("InterfaceManager not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left and right bounds & Move the player left and right
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Check for forward and backward bounds & Move the player forward and backward
        if (transform.position.z < zRangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeBottom);
        }
        else if (transform.position.z > zRangeTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
        }

        // Player movement left to right
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            //Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }
}
