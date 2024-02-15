using UnityEngine;

public class ColorfulCandy : MonoBehaviour
{
    private ColorsProvider _colorsProvider;
    private PositionGenerator _positionGenerator;
    private Material _material;

    public void Initialize(ColorsProvider colorsProvider, PositionGenerator positionGenerator)
    {
        var renderer = transform.GetComponentInChildren<Renderer>();
        var materials = renderer.materials;
        _material = materials[0];
        _positionGenerator = positionGenerator;
        _colorsProvider = colorsProvider;
        ChangeСolor();
        ChangePosition();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerView player))
        {
            player.SetColor(_material.color);
            ChangeСolor();
            ChangePosition();
        }
    }

    private void ChangeСolor()
    {
        _material.color = _colorsProvider.GetRandom();
    }
    
    
    private void ChangePosition()
    {
        gameObject.transform.position = _positionGenerator.GetRandomPosition();
    }
}
