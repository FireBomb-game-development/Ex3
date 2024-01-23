using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float width = 0.05f;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = width;
        lineRenderer.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RenderLine (Vector3 finalPosition, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!lineRenderer.enabled) lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;

        }
        else
        {
            if (lineRenderer.enabled) lineRenderer.enabled = false;

        }

        if (lineRenderer.enabled)
        {
            Vector3 pos = startPosition.position;
            pos.z = -10f;
            startPosition.position = pos;
            pos = finalPosition;
            pos.z = 0f;
            finalPosition = pos;
            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, finalPosition);

        }
    }
}
