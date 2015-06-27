using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class NodeRenderer : MonoBehaviour
{
    [SerializeField]
    private float radius = 1;

    [SerializeField]
    private int segments = 64;

    [SerializeField]
    private float width = 0.1f;

    [SerializeField]
    private Color color = Color.white;

    void Awake()
    {
        UpdatePositions();
    }

    void UpdatePositions()
    {
        LineRenderer renderer = GetComponent<LineRenderer>();

        renderer.SetVertexCount(segments + 1);
        renderer.SetWidth(width, width);
        renderer.SetColors(color, color);

        renderer.useWorldSpace = true;
        
        for (int i = 0; i < segments + 1; i++)
        {
            float angle = 360.0f / segments * i;
            
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            
            renderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
