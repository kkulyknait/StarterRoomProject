using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioEvent sfxEvent;
    [SerializeField] private AudioMixerGroup sfxGroup;

    private void OnEnable()
    {
        sfxEvent.Raised += PlayAt;
    }
    private void OnDisable()
    {
        sfxEvent.Raised -= PlayAt;
    }

    private void PlayAt(AudioClip clip, Vector3 position)
    {
        if (clip == null) return;
        GameObject go = new GameObject("SFX_" + clip.name);
        go.transform.SetParent(transform);
        go.transform.position = position;

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.outputAudioMixerGroup = sfxGroup;
        source.spatialBlend = 1f;  //  3D Sound
        source.Play();

        Destroy(go, clip.length);
    }
}
