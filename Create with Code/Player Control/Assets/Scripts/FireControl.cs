using UnityEngine;

public class FireControl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float fireRate = 0.5f;
    private float nextFireTime = 0;
    private float bulletSpeed = 1000000;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bulletRb = bulletPrefab.GetComponent<Rigidbody>();
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Fire()
    {
        Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z + 1);
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition, bulletPrefab.transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.AddForce(transform.forward * bulletSpeed);
        }
    }
}
