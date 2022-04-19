using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRaycast();
        PlayMuzzleFlash();
    }

    private void CreateHitImpact(RaycastHit hit){
        GameObject impact = Instantiate(hitEffect.gameObject, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    private void ProcessRaycast(){
        RaycastHit hit;

        if (Physics.Raycast(fPCamera.transform.position,fPCamera.transform.forward, out hit, range)){
            print("I hit this: " + hit.transform.name);
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
