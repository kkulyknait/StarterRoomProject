using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float damage = 1f;
    [SerializeField] private float lifetime = 5f;
    [Header("Feedback")]
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private AudioEvent sfxEvent;
    [SerializeField] private AudioClip impactClip;
    [SerializeField] private VFXEvent vfxEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        if(collision.collider.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(damage, contact.point);
        }
        vfxEvent.Raise(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
        sfxEvent.Raise(impactClip, contact.point);
        Destroy(gameObject);
    }

}
