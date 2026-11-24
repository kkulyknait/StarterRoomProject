using UnityEngine;
using System;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputReader", menuName = "Modular Assets/PlayerInputReader")]
public class PlayerInputReader : ScriptableObject
{
    public event Action InteractEvent;
    public event Action FireEvent;
    public event Action<int> WeaponSelectEvent;
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput => _controls.Player.Look.ReadValue<Vector2>();

    private InputSystem_Actions _controls;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new InputSystem_Actions();
        }
        _controls.Player.Move.performed += HandleMove;
        _controls.Player.Move.canceled += HandleMove;
        _controls.Player.Interact.performed += HandleInteract;
        _controls.Player.Attack.performed += HandleFire;
        _controls.Player.Weapon1.performed += HandleWeapon1;
        _controls.Player.Weapon2.performed += HandleWeapon2;
        _controls.Player.Weapon3.performed += HandleWeapon3;
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Move.performed -= HandleMove;
        _controls.Player.Move.canceled -= HandleMove;
        _controls.Player.Interact.performed -= HandleInteract;
        _controls.Player.Attack.performed -= HandleFire;
        _controls.Player.Weapon1.performed -= HandleWeapon1;
        _controls.Player.Weapon2.performed -= HandleWeapon2;
        _controls.Player.Weapon3.performed -= HandleWeapon3;
        _controls.Player.Disable();
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }


    private void HandleInteract(InputAction.CallbackContext context)
    {
        InteractEvent?.Invoke();
    }

    private void HandleFire(InputAction.CallbackContext context)
    {
        FireEvent?.Invoke();
    }

    private void HandleWeapon1(InputAction.CallbackContext context) => WeaponSelectEvent?.Invoke(0);
    private void HandleWeapon2(InputAction.CallbackContext context) => WeaponSelectEvent?.Invoke(1);
    private void HandleWeapon3(InputAction.CallbackContext context) => WeaponSelectEvent?.Invoke(2);
}