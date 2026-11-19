using UnityEngine;
using Unity.Cinemachine;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] private VFXEvent vfxEvent;
    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void OnEnable() 
    {
        vfxEvent.Raised += Spawn;
    }

    private void OnDisable()
    {
        vfxEvent.Raised -= Spawn;
    }

    private void Spawn(GameObject effect, Vector3 position, Quaternion rotation)
    {
        if (effect == null) return;
        Instantiate(effect, position, rotation, transform);
    }

    public void Shake(float force)

    {
        impulseSource.GenerateImpulseWithForce(force);
    }
}
