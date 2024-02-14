using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Material _material;
    
    private void Awake()
    {
        var renderer = GetComponent<Renderer>();
        var materials = renderer.materials;
        _material = materials[0];
    }

    public Color GetCurrentColor()
    {
        return _material.color;
    }
    
    public void SetColor(Color materialColor)
    {
        _material.color = materialColor;
    }
}
