using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class DrawnPlatform : MonoBehaviour
{
    public float pointSpacing = 0.1f;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector3> worldLinePoints = new List<Vector3>();
    private List<Vector2> localColliderPoints = new List<Vector2>();
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        lineRenderer.positionCount = 0;
        edgeCollider.points = new Vector2[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            worldLinePoints.Clear();
            localColliderPoints.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            if (worldLinePoints.Count == 0 || Vector3.Distance(worldLinePoints[worldLinePoints.Count - 1], mouseWorldPos) >= pointSpacing)
            {
                worldLinePoints.Add(mouseWorldPos);
                localColliderPoints.Add(transform.InverseTransformPoint(mouseWorldPos)); // convert to local space

                lineRenderer.positionCount = worldLinePoints.Count;
                lineRenderer.SetPositions(worldLinePoints.ToArray());
                edgeCollider.points = localColliderPoints.ToArray();
            }
        }
    }
}