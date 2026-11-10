using UnityEngine;

public class HitTarget : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;
    [Header("Optional display")]
    [SerializeField] private FloatVariable healthDisplay;
    [SerializeField] private GameEvent damagedEvent;
    private float health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        health -= amount;
        if (healthDisplay != null) healthDisplay.Value = Mathf.Clamp01(health / maxHealth);
        if (damagedEvent != null) damagedEvent.Raise();
        if (health <= 0f) gameObject.SetActive(false);
    }

}
