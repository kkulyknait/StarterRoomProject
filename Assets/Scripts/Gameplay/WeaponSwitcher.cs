using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private IntVariable currentWeapon;
    [SerializeField] private GameEvent weaponChanged;

    private void OnEnable()
    {
        inputReader.WeaponSelectEvent += Select;
    }

    private void OnDisable()
    {
        inputReader.WeaponSelectEvent -= Select;
    }

    private void Start()
    {
        Select(0);
    }

    private void Select(int index)
    {
        if (index < 0 || index >= weapons.Length) return;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == index);
        }
        currentWeapon.Value = index;
        weaponChanged.Raise();
    }
}
