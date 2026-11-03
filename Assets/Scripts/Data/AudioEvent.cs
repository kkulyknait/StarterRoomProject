using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioEvent", menuName = "Modular Assets/Audio Event")]
public class AudioEvent : ScriptableObject
{
    public event Action<AudioClip, Vector3> Raised;
    public void Raise(AudioClip clip, Vector3 position)
    {
        Raised?.Invoke(clip, position);
    }
}
