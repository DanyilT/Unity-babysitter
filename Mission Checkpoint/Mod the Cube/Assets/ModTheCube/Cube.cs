using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private Vector3 position = new Vector3(0, 0, 0);
    [SerializeField] private float scale = 1f;
    [SerializeField] private Color color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    [SerializeField] private float opacity = 1.0f;
    [SerializeField] private float rotationAngle = 0.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    void Start()
    {
        transform.position = position;
        transform.localScale = Vector3.one * scale;

        Material material = Renderer.material;

        material.color = color;

        transform.Rotate(0.0f, rotationAngle, 0.0f);
    }

    void Update()
    {
        Renderer.material.color = new Color(
            Mathf.Sin(Time.time) * 0.5f + 0.5f,
            Mathf.Cos(Time.time) * 0.5f + 0.5f,
            Mathf.Sin(Time.time) * 0.5f + 0.5f,
            opacity
        );

        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnMouseDown()
    {
        GameObject newCube = Instantiate(gameObject, position, Quaternion.identity);
        newCube.GetComponent<Cube>().position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }
}
