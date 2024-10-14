using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera mainCamera;
    private Vector3 mousePos;
    private TrailRenderer trailRenderer;
    private BoxCollider boxCollider;
    private bool swiping = false;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mainCamera = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        trailRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }

            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    private void UpdateMousePosition()
    {
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = mousePos;
    }

    private void UpdateComponents()
    {
        trailRenderer.enabled = swiping;
        boxCollider.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
