using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float reloadTime = 0.5f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip gunShot;

    bool canShoot = true;

    // Update is called once per frame
    void Update()

    {
        //DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot){
            StartCoroutine(Shoot());
        }
    }

    //public void DisplayAmmo(){
        //int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        //ammoText.text = currentAmmo.ToString();
   // }
    private void OnEnable()
    {
        canShoot = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0 )
        {
            AudioSource shot = GetComponent<AudioSource>();
            shot.PlayOneShot(gunShot, 1);
            //
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

    private void CreateHitImpact(RaycastHit hit){
        GameObject impact = Instantiate(hitEffect.gameObject, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    private void ProcessRaycast(){
        RaycastHit hit;
        

        if (Physics.Raycast(fPCamera.transform.position,fPCamera.transform.forward, out hit, range)){
            print("I hit this: " + hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null){
                return;
            }
            target.TakeDamage(damage);
        }
        else {
            return;
        }
    }

    private void PlayMuzzleFlash(){
        muzzleFlash.Play();
    }
}
