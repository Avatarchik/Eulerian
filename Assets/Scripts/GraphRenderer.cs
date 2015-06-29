using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class GraphRenderer : MonoBehaviour
{
    [SerializeField]
    private float width = 0.1f;

    [SerializeField]
    private Color color = Color.white;

    void Awake()
    {
        SetPositions(new List<Vector2>(){
            new Vector2(0.0f, 1.0f),
            new Vector2(-1.0f, -0.7f),
            new Vector2(1.0f, -0.7f)
        });
    }

    public void SetPositions(List<Vector2> positions)
    {
        LineRenderer renderer = GetComponent<LineRenderer>();

        int nodes = positions.Count;
        int segments = nodes + 1;

        renderer.SetVertexCount(segments);
        renderer.SetWidth(width, width);
        renderer.SetColors(color, color);

        renderer.useWorldSpace = true;

        for (int i = 0; i < segments; i++)
        {
            Vector2 p = positions[i % nodes];
            renderer.SetPosition(i, p);
        }
    }
}
