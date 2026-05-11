using UnityEngine;
[ExecuteInEditMode]

[RequireComponent(typeof(Renderer))]
public class TextureTilingFromScale : MonoBehaviour
{
    public Vector2 tileSize = new(1.0f, 1.0f);
    private Material materialInstance;
    private Vector3 lastScale;

    void Start()
    {
        materialInstance = GetComponent<Renderer>().material;
        UpdateTiling();
    }

    void Update()
    {
        if (transform.localScale != lastScale)
        {
            UpdateTiling();
            lastScale = transform.localScale;
        }
    }

    void UpdateTiling()
    {
        if (materialInstance == null) return;

        Vector3 scale = transform.localScale;
        materialInstance.mainTextureScale = new Vector2(scale.x / tileSize.x, scale.z / tileSize.y);
    }
}
