using UnityEngine;

public class PositionGenerator
{
    private readonly Vector3 _sizeMap;
    private readonly int _offset;
    private readonly float _scale;

    public PositionGenerator(Vector3 sizeMap, int offset, float scale)
    {
        _sizeMap = sizeMap;
        _offset = offset;
        _scale = scale;
    }
    
    public Vector3 GetRandomPosition()
    {
        var randomX = Random.Range((-1) * _sizeMap.x / _scale + _offset, _sizeMap.x / _scale - _offset);
        var randomZ = Random.Range((-1) * _sizeMap.x / _scale + _offset, _sizeMap.z / _scale - _offset);
        var randomPosition = new Vector3(randomX, 0, randomZ);
        return randomPosition;
    }
}
