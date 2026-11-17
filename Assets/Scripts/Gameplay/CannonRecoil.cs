using System.Collections;
using UnityEngine;

public class CannonRecoil : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private float recoilDistance = 0.3f;
    [SerializeField] private float returnTime = 0.35f;

    private Vector3 restPosition;
    private Vector3 recoilOffset;
    private Coroutine kick;

    private void Awake()
    {
        restPosition = transform.localPosition;

        Vector3 backward = -muzzle.forward * recoilDistance;
        recoilOffset = transform.parent.InverseTransformVector(backward);
    }

    public void Kick()
    {
        if (kick != null) StopCoroutine(kick);
        kick = StartCoroutine(KickRoutine());
    }

    private IEnumerator KickRoutine()
    {
        Vector3 pushed = restPosition + recoilOffset;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / returnTime;
            transform.localPosition = Vector3.Lerp(pushed, restPosition, t);
            yield return null;
        }

        transform.localPosition = restPosition;
    }
}
