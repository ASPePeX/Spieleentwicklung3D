using UnityEngine;

// ReSharper disable once CheckNamespace
public class PlayerWeapon : MonoBehaviour
{
    private float _gunTimer;
    private int _selectedWeapon;

    private float _gunTimerMachinegun;
    private float _gunTimerLaser;

    public Transform PlayerShot;
    private Vector3 _shotSpawnOffset;
    private Transform _shotParent;
    public Transform Laser;

    // ReSharper disable once UnusedMember.Local
    private void Start()
    {
        _selectedWeapon = (int) Weapon.Machinegun;
        UI.CurWeapon = "Machinegun";
        _gunTimerMachinegun = float.Parse(Config.GetConfig("guntimer-machinegun"));
        _gunTimerLaser = float.Parse(Config.GetConfig("guntimer-laser"));
        _shotSpawnOffset = new Vector3(2, 0, 0);
        _shotParent = GameObject.Find("Projectiles").transform;
    }

    // ReSharper disable once UnusedMember.Local
    private void Update()
    {
        //Weapon selector
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gunTimer = 0;
            _selectedWeapon = (int) Weapon.Machinegun;
            UI.CurWeapon = "Machinegun";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _gunTimer = 0;
            _selectedWeapon = (int) Weapon.Laser;
            UI.CurWeapon = "Laser";
        }

        if (Input.GetAxis("Fire1") > 0 && _gunTimer <= 0)
        {
            switch (_selectedWeapon)
            {
                case (int) Weapon.Machinegun:
                    _gunTimer = _gunTimerMachinegun;
                    var clone =
                        Instantiate(PlayerShot, transform.position + _shotSpawnOffset, Quaternion.identity) as Transform;
                    if (clone != null) clone.parent = _shotParent;
                    break;

                case (int) Weapon.Laser:
                    _gunTimer = _gunTimerLaser;
                    RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.right, 50);
                    foreach (RaycastHit hit in hits)
                    {
                        Destroy(hit.transform.parent.gameObject);
                        SendMessageUpwards("AddScore", 5);
                    }
                    Laser.gameObject.SetActive(true);
                    audio.Play();
                    break;
            }
        }

        if (_gunTimer > 0)
            _gunTimer -= Time.deltaTime;
    }

    private enum Weapon
    {
        Machinegun,
        Laser
    }
}