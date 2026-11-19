using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVFXEvent", menuName = "Modular Assets/VFXEvent")]
public class VFXEvent : ScriptableObject
{
    public event Action<GameObject, Vector3, Quaternion> Raised;
    public void Raise(GameObject effect, Vector3 position, Quaternion rotation)
    {
        Raised?.Invoke(effect, position, rotation);
    
}
