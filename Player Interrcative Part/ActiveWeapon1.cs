using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEditor.Animations;

public class ActiveWeapon1 : MonoBehaviour
{
    public Rig handIk;
    public Transform weaponParent;
    public Transform weaponLeftSocket;
    public Transform weaponRightSocket;
    public Animator rigController;

    [SerializeField]
    Transform crossHairTarget;
    RaycastWeapon weapon;

   

    void Start()
    {
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        if (existingWeapon)
            Equip(existingWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time >= weapon.nextTimeToFire)
            Shoot();
    }

    void Shoot()
    {
        if (weapon)
        {
            if (Input.GetButton("Fire1"))
            {
                if (Time.time >= weapon.nextTimeToFire)
                    weapon.StartFiring();
            }
            else
            {
                weapon.StopFiring();
            }
        }
    }

    // if there is a weapon in hands - put hanIk layer at weight 1
    public void Equip(RaycastWeapon newWeapon)
    {
        if (weapon)
            Destroy(weapon.gameObject);

        weapon = newWeapon;
        weapon.raycastDestination = crossHairTarget;
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = weapon.GetSpawnPoint;
        weapon.transform.localRotation = Quaternion.Euler(0f, -6.39f, 0f);
        handIk.weight = 1;
        rigController.Play("Equip_" + weapon.GetWeaponName);  
    }
}
