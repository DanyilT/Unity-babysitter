using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float patrolInterval = 5.0f; // Time interval between patrol points
    [SerializeField] private float obstacleDetectionDistance = 2.0f; // Distance to detect obstacles
    [SerializeField] private float health = 50.0f; // Health of the enemy

    private NavMeshAgent navMeshAgent;
    private float timeSinceLastPatrol;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        timeSinceLastPatrol = 0f;
        SetRandomDirection();
    }

    void Update()
    {
        timeSinceLastPatrol += Time.deltaTime;

        if (timeSinceLastPatrol >= patrolInterval || IsObstacleAhead())
        {
            SetRandomDirection();
            timeSinceLastPatrol = 0f;
        }

        navMeshAgent.Move(transform.forward * navMeshAgent.speed * Time.deltaTime);
    }

    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, randomAngle, 0);
    }

    bool IsObstacleAhead()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        return Physics.Raycast(ray, obstacleDetectionDistance);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.AddScore(10); // Add score when enemy dies
        Destroy(gameObject);
    }
}
