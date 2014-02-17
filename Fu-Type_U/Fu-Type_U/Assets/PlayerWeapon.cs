using UnityEngine;

// ReSharper disable once CheckNamespace
public class PlayerWeapon : MonoBehaviour
{
    private float _gunTimer;
    private int _selectedWeapon;

    // ReSharper disable once UnusedMember.Local
    private void Start()
    {
        _selectedWeapon = (int) Weapon.Gun;
    }

    // ReSharper disable once UnusedMember.Local
    private void Update()
    {
        //Weapon selector
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gunTimer = 0;
            _selectedWeapon = (int) Weapon.Gun;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _gunTimer = 0;
            _selectedWeapon = (int) Weapon.Machinegun;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _gunTimer = 0;
            _selectedWeapon = (int) Weapon.Laser;
        }

        if (Input.GetAxis("Fire1") > 0 && _gunTimer <= 0)
        {
            switch (_selectedWeapon)
            {
                case (int) Weapon.Gun:
                    Debug.Log("Peng Gun" + _gunTimer);
                    _gunTimer = 0.7f;
                    break;

                case (int) Weapon.Machinegun:
                    Debug.Log("Peng MachineGun" + _gunTimer);
                    _gunTimer = 0.2f;
                    break;

                case (int) Weapon.Laser:
                    Debug.Log("Peng Laser" + _gunTimer);
                    _gunTimer = 2;
                    break;
            }
        }

        if (_gunTimer > 0)
            _gunTimer -= Time.deltaTime;
    }

    private enum Weapon
    {
        Gun,
        Machinegun,
        Laser
    }
}