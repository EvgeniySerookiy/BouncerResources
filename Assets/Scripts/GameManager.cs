using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ColorsProvider _colorsProvider = new();
    [SerializeField] private GiftsManager _giftsManager;
    [SerializeField] private ColorfulCandy _colorfulCandyPrefab;
    [SerializeField] private MapSettings _mapSettings;
    [SerializeField] private PlayerManager _playerManager;
    private PositionGenerator _positionGenerator;
    private ColorfulCandy _colorfulCandy;
    

    private void Awake()
    {
        var mapSize = _mapSettings.MapCollider.bounds.size;
        _positionGenerator = new PositionGenerator(mapSize, _mapSettings.MapOffset, _mapSettings.MapScale.localScale.x);
        
        _playerManager.Initialize(_positionGenerator);
        _giftsManager.Initialize(_colorsProvider, _positionGenerator);
        
        _colorfulCandy = Instantiate(_colorfulCandyPrefab);
        _colorfulCandy.Initialize(_colorsProvider, _positionGenerator);
        
    }
}
