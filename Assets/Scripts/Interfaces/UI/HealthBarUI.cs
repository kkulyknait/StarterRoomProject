using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private FloatVariable health;
    [SerializeField] private Slider slider;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        slider.value = health.Value;
    }
}
