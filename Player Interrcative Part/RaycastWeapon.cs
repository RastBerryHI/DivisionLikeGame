using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{

    public ParticleSystem hitEffect;
    public float fireRate = 20f;
    public float nextTimeToFire = 0f;
    public TrailRenderer tracerEffect;
    public bool isFiring = false;
    public Transform raycastDestination;
   
    public string GetWeaponName 
    {
        get
        {
            return weaponName;    
        }
    }

    public Vector3 GetSpawnPoint 
    {
        get 
        {
            return spawnPosition;
        }
    }

    [SerializeField]
    Vector3 spawnPosition;
    [SerializeField]
    ParticleSystem[] muzzleFlash;
    [SerializeField]
    Transform raycastOrigin;
    [SerializeField]
    string weaponName;

   

    Ray ray;
    RaycastHit hitInfo;
    public void StartFiring()
    {
        isFiring = true;
        nextTimeToFire = Time.time + 1f / fireRate;
        FireBullet();
    }

    private void FireBullet()
    {
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;

        var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        muzzleFlash[0].Emit(1);
        muzzleFlash[1].Emit(5);


        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green, 1f);

            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hitInfo.point;
        }
        //ray.origin = raycastOrigin.position;
        //ray.direction = raycastOrigin.forward;

        //if(Physics.Raycast(ray, out hitInfo)) 
        //{
        //    Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
        //    hitEffect.transform.position = hitInfo.point;
        //    hitEffect.transform.forward = hitInfo.normal;
        //    hitEffect.Emit(1);

        //    tracer.transform.position = hitInfo.point;
        //}
    }

    public void StopFiring() 
    {
        isFiring = false;
    }
}
