using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorsProvider
{
    private List<Color> _colors = new ()
    {
        Color.red,
        Color.blue,
        Color.green
    };
    private int _currentColorIndex;
    
    public Color GetRandom()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, _colors.Count);
        } 
        while (_currentColorIndex == randomIndex);
        
        _currentColorIndex = randomIndex;
        
        return _colors[randomIndex];
    }
}
