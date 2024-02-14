using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GiftsManager : MonoBehaviour
{
    [SerializeField] private CounterUI counterUI;
    [SerializeField] private Gift _giftPrefab;
    private ColorsProvider _colorsProvider;
    [SerializeField] private int _giftsCount = 10;
    private Dictionary<Color, int> _dictionaryGifts = new();
    private Gift _gift;
    
    public void Initialize(ColorsProvider colorsProvider, PositionGenerator positionGenerator)
    {
        for (var i = 0; i < _giftsCount; i++)
        {
            _gift = Instantiate(_giftPrefab, transform);
            _gift.transform.position = positionGenerator.GetRandomPosition();
            var color = colorsProvider.GetRandom();
            _gift.Initialize(color);
            _gift.GiftCollisedWithPlayer += OnGiftCollisedWithPlayer;
            
            if (_dictionaryGifts.ContainsKey(color))
            {
                _dictionaryGifts[color]++;
            }
            else
            {
                _dictionaryGifts.Add(color, 1);
            }
        }

        foreach (var keyValuePair in _dictionaryGifts)
        {
            counterUI.ShowGiftCount(keyValuePair.Value, keyValuePair.Key);
        }
    }

    private void OnGiftCollisedWithPlayer(Gift gift, Action destroyGift)
    {
        if (_dictionaryGifts.ContainsKey(gift.Color))
        {
            _dictionaryGifts[gift.Color]--;
            counterUI.ShowGiftCount(_dictionaryGifts[gift.Color], gift.Color);
            gift.GiftCollisedWithPlayer -= OnGiftCollisedWithPlayer;
            destroyGift.Invoke();
        }
    }
    
    
}
