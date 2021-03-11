using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public RaycastWeapon weaponFab;
    private void OnTriggerEnter(Collider other)
    {
        // If collider has ActiveWeapon1 script
        ActiveWeapon1 activeWeapon = other.gameObject.GetComponent<ActiveWeapon1>();
        if (activeWeapon) 
        {
            RaycastWeapon newWeapon = Instantiate(weaponFab);
            activeWeapon.Equip(newWeapon);
        }
    }
}
