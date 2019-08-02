using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public enum WeaponType
    {
        Mg,
        Laser,
        Br
    }
    
    [SerializeField] private GameObject bulletPrefab = null;
    private float bulletVelocity = 300;
    private WeaponType currentWeapon;

    private int mgBullets = 200;
    private int laserBullets = 20;
    private int brBullets = 80;
    
    public void Fire(Transform parentPosition)
    {
        switch (currentWeapon)
        {
            case WeaponType.Mg:
                MachineGun(parentPosition);
                break;
            
            case WeaponType.Laser:
                LaserGun(parentPosition);
                break;
            
            case WeaponType.Br:
                BattleRifle(parentPosition);
                break;
        }
    }

    private void MachineGun(Transform parentPosition)
    {
        Instantiate(bulletPrefab, parentPosition.position + parentPosition.forward * 4, Quaternion.identity)
            .GetComponent<Rigidbody>()
            .AddForce(parentPosition.forward * bulletVelocity, ForceMode.Impulse);
    }

    private void LaserGun(Transform parentPosition)
    {
        Instantiate(bulletPrefab, parentPosition.position + parentPosition.forward * 4, Quaternion.identity)
            .GetComponent<Rigidbody>()
            .AddForce(parentPosition.forward * bulletVelocity, ForceMode.Impulse);
    }

    private void BattleRifle(Transform parentPosition)
    {
        Instantiate(bulletPrefab, parentPosition.position + parentPosition.forward * 4, Quaternion.identity)
            .GetComponent<Rigidbody>()
            .AddForce(parentPosition.forward * bulletVelocity, ForceMode.Impulse);
    }

    public void SetWeapon(WeaponType type)
    {
        currentWeapon = type;
    }

    public WeaponType GetCurrentWeapon()
    {
        return currentWeapon;
    }
}
