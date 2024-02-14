using System;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public event Action<Gift, Action> GiftCollisedWithPlayer;
    
    public Color Color { get; private set; }
    
    public void Initialize(Color color)
    {
        var renderer = transform.GetComponentsInChildren<Renderer>();
        var materials = renderer[1].materials;
        materials[1].color = color;
        Color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerView playerView) && playerView.GetCurrentColor() == Color)
        {
            GiftCollisedWithPlayer?.Invoke(this, DestroyGift);
        }
    }

    private void DestroyGift()
    {
        Destroy(gameObject);
    }
}
