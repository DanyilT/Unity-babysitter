using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform turretTop; // The top part of the turret that rotates
    [SerializeField] private GameObject projectilePrefab; // The projectile prefab to fire
    [SerializeField] private Transform firePoint; // The point from where the projectile is fired
    [SerializeField] private float detectionRadius = 10.0f; // Radius to detect enemies
    [SerializeField] private float fireRate = 1.0f; // Rate of fire in seconds
    [SerializeField] private string enemyTag = "Enemy"; // Tag to detect enemies

    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        Transform nearestEnemy = GetNearestEnemy(colliders);
        if (nearestEnemy != null)
        {
            RotateTurret(nearestEnemy);
            if (fireCooldown <= 0f)
            {
                FireProjectile(nearestEnemy);
                fireCooldown = fireRate;
            }
        }
    }

    Transform GetNearestEnemy(Collider[] colliders)
    {
        Transform nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(enemyTag))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = collider.transform;
                }
            }
        }

        return nearestEnemy;
    }

    void RotateTurret(Transform target)
    {
        Vector3 direction = (target.position - turretTop.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        turretTop.rotation = Quaternion.Slerp(turretTop.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void FireProjectile(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        if (projectileController != null)
        {
            projectileController.SetTarget(target);
        }
    }
}
