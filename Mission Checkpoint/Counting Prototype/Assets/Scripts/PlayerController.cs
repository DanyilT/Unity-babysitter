using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab; // Assign the turret prefab in the inspector
    [SerializeField] private LayerMask planeLayer; // Assign the layer of the plane in the inspector
    [SerializeField] private LayerMask obstacleLayer; // Assign the layer of obstacles in the inspector
    [SerializeField] private float placementRadius = 1.0f; // Radius to check for empty space
    [SerializeField] private int maxTurrets = 10; // Maximum number of turrets allowed

    private int currentTurretCount = 0; // Counter for the number of turrets placed

    void Start()
    {
        GameManager.Instance.SetTurretsLeft(maxTurrets - currentTurretCount);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch();
            PlaceTurret();
        }
    }

    void HandleTouch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Turret"))
            {
                RemoveTurret(hit.collider.gameObject);
            }
            else if (hit.collider.gameObject.layer == planeLayer)
            {
                PlaceTurret();
            }
        }
    }

    void PlaceTurret()
    {
        if (currentTurretCount >= maxTurrets)
        {
            Debug.Log("Maximum number of turrets reached.");
            return;
        }

        if (Camera.main == null)
        {
            Debug.LogError("Main Camera is not found. Please ensure the camera is tagged as 'MainCamera'.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
        {
            Debug.Log("Raycast hit: " + hit.point);
            Vector3 targetPosition = hit.point;

            if (IsPositionEmpty(targetPosition))
            {
                Debug.Log("Position is empty. Placing turret at: " + targetPosition);
                Instantiate(turretPrefab, targetPosition, Quaternion.identity);
                currentTurretCount++;
                GameManager.Instance.UpdateTurretsLeft(-1);
            }
            else
            {
                Vector3 nearestPosition = FindNearestEmptyPosition(targetPosition);
                if (nearestPosition != Vector3.zero)
                {
                    Debug.Log("Position is not empty. Placing turret at nearest position: " + nearestPosition);
                    Instantiate(turretPrefab, nearestPosition, Quaternion.identity);
                    currentTurretCount++;
                    GameManager.Instance.UpdateTurretsLeft(-1);
                }
                else
                {
                    Debug.Log("No empty position found near: " + targetPosition);
                }
            }
        }
        else
        {
            Debug.Log("Raycast did not hit the plane.");
        }
    }

    void RemoveTurret(GameObject turret)
    {
        Destroy(turret);
        currentTurretCount--;
        GameManager.Instance.UpdateTurretsLeft(1);
    }

    bool IsPositionEmpty(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, placementRadius, obstacleLayer);
        Debug.Log("Colliders found: " + colliders.Length);
        foreach (var collider in colliders)
        {
            Debug.Log("Collider detected: " + collider.name);
        }
        return colliders.Length == 0;
    }

    Vector3 FindNearestEmptyPosition(Vector3 targetPosition)
    {
        for (float radius = placementRadius; radius <= placementRadius * 2; radius += 0.1f)
        {
            for (float angle = 0; angle < 360; angle += 10)
            {
                Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;
                Vector3 newPosition = targetPosition + offset;

                if (IsPositionEmpty(newPosition))
                {
                    return newPosition;
                }
            }
        }
        return Vector3.zero; // No empty position found
    }
}
