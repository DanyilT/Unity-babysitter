using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    [SerializeField] private GameObject strengthPowerupIndicator;
    [SerializeField] private GameObject firePowerupIndicator;
    [SerializeField] private GameObject smashPowerupIndicator;
    [SerializeField] private GameObject powerupFireRockets;
    [SerializeField] private float speed = 5000.0f;
    [SerializeField] private float powerupStrength = 2000.0f;
    [SerializeField] private float rocketForce = 500;
    [SerializeField] private float hopHeight = 40.0f;
    [SerializeField] private float smashRadius = 100.0f;
    [SerializeField] private float smashForce = 200.0f;
    private Coroutine fireRocketsCoroutine;
    private List<GameObject> spawnedRockets = new List<GameObject>();
    internal bool hasStrengthPowerup = false;
    internal bool hasFirePowerup = false;
    internal bool hasSmashPowerup = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player based on arrow(or WASD) key input
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime * verticalInput);

        // Move the powerup indicators to the player's position
        strengthPowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        firePowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        smashPowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        strengthPowerupIndicator.SetActive(hasStrengthPowerup);
        firePowerupIndicator.SetActive(hasFirePowerup);
        smashPowerupIndicator.SetActive(hasSmashPowerup);

        // Call ShootFireRockets if fire powerup is active
        if (hasFirePowerup && fireRocketsCoroutine == null)
        {
            fireRocketsCoroutine = StartCoroutine(ShootFireRockets());
        }

        // Call SmashPowerup if smash powerup is active and space key is pressed
        if (hasSmashPowerup && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(HopAndSmash());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasStrengthPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine("Strength"));
        }

        if (other.CompareTag("FirePowerup"))
        {
            hasFirePowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine("Fire"));
        }

        if (other.CompareTag("SmashPowerup"))
        {
            hasSmashPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine("Smash"));
        }
    }

    private IEnumerator PowerupCountdownRoutine(string powerup)
    {
        yield return new WaitForSeconds(powerup == "Strength" ? 7 : powerup == "Fire" ? 5 : 10);
        hasStrengthPowerup = powerup == "Strength" ? false : hasStrengthPowerup;
        hasFirePowerup = powerup == "Fire" ? false : hasFirePowerup;
        hasSmashPowerup = powerup == "Smash" ? false : hasSmashPowerup;

        if (powerup == "Fire" && fireRocketsCoroutine != null)
        {
            StopCoroutine(fireRocketsCoroutine);
            fireRocketsCoroutine = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasStrengthPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private IEnumerator ShootFireRockets()
    {
        while (hasFirePowerup)
        {
            // Destroy all previously spawned rockets
            foreach (GameObject rocket in spawnedRockets)
            {
                Destroy(rocket);
            }
            spawnedRockets.Clear();

            // Spawn a new volley of rockets
            for (int i = 0; i < 25; i++)
            {
                SpawnRocketInRandomDirection();
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void SpawnRocketInRandomDirection()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        Vector3 spawnPosition = transform.position + randomDirection * 2f;
        GameObject rocket = Instantiate(powerupFireRockets, spawnPosition, powerupFireRockets.transform.rotation);
        Rigidbody rocketRb = rocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(randomDirection * rocketForce, ForceMode.Impulse);
        spawnedRockets.Add(rocket);
    }

    private IEnumerator HopAndSmash()
    {
        // Hop up into the air
        playerRb.AddForce(Vector3.up * hopHeight, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);

        // Smash down onto the ground
        playerRb.AddForce(Vector3.down * hopHeight * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);

        // Detect nearby enemies and apply force
        Collider[] enemies = Physics.OverlapSphere(transform.position, smashRadius);
        foreach (Collider enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = enemy.transform.position - transform.position;
                float distance = awayFromPlayer.magnitude;
                float impactForce = smashForce / distance;
                enemyRb.AddForce(awayFromPlayer.normalized * impactForce, ForceMode.Impulse);
            }
        }
    }
}
