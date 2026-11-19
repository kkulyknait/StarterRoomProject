using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private Rigidbody ballPrefab;
    [SerializeField] Transform muzzle;
    [SerializeField] private float launchSpeed = 20f;
    [SerializeField] private float cooldown = 0.8f;

    [Header("Feedback")]
    [SerializeField] private GameEvent firedEvent;
    [SerializeField] private GameObject muzzleEffect;
    [SerializeField] private AudioEvent sfxEvent;
    [SerializeField] private VFXEvent vfxEvent;
    [SerializeField] private AudioClip fireClip;

    private float nextFireTime;

    private void OnEnable()
    {
        inputReader.InteractEvent += Fire;
    }

    private void OnDisable()
    {
        inputReader.InteractEvent -= Fire;
    }

    public void Fire()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + cooldown;

        Rigidbody ball = Instantiate(ballPrefab, muzzle.position, muzzle.rotation);
        ball.linearVelocity = muzzle.forward * launchSpeed;
        vfxEvent.Raise(muzzleEffect, muzzle.position, muzzle.rotation);
        sfxEvent.Raise(fireClip, muzzle.position);
        firedEvent.Raise();
    }
}
