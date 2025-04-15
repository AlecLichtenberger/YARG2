using UnityEngine;
using System.Collections.Generic;

public class PlatformDrawer : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab with LineRenderer + EdgeCollider2D
    public float pointSpacing = 0.1f;

    private List<Vector3> currentWorldPoints = new List<Vector3>();
    private List<Vector2> currentLocalPoints = new List<Vector2>();
    private GameObject currentPlatform;
    private LineRenderer lineRenderer;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartNewPlatform();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;

            if (currentWorldPoints.Count == 0 || Vector3.Distance(currentWorldPoints[^1], mouseWorld) >= pointSpacing)
            {
                currentWorldPoints.Add(mouseWorld);
                currentLocalPoints.Add(currentPlatform.transform.InverseTransformPoint(mouseWorld));

                lineRenderer.positionCount = currentWorldPoints.Count;
                lineRenderer.SetPositions(currentWorldPoints.ToArray());

                EdgeCollider2D edge = currentPlatform.GetComponent<EdgeCollider2D>();
                edge.points = currentLocalPoints.ToArray();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            FinalizePlatform();
        }
    }

    void StartNewPlatform()
    {
        currentPlatform = Instantiate(platformPrefab);
        lineRenderer = currentPlatform.GetComponent<LineRenderer>();

        currentWorldPoints.Clear();
        currentLocalPoints.Clear();

        lineRenderer.positionCount = 0;
        currentPlatform.GetComponent<EdgeCollider2D>().points = new Vector2[0];
    }

    void FinalizePlatform()
    {
        currentPlatform = null;
        lineRenderer = null;
    }
}
