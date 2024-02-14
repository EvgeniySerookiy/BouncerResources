using System;
using UnityEngine;

[Serializable]
public class MapSettings
{
    [field: SerializeField] public MeshCollider MapCollider { get; private set; }
    [field: SerializeField] public int MapOffset { get; private set; }
    [field: SerializeField] public Transform MapScale { get; private set; }
}