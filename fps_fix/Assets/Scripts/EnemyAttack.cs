using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealthScript Target;
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    [SerializeField] AudioClip meowAudio;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<PlayerHealthScript>();
    }

    public void AttackHitEvent () {
        if (target == null) {
            print("wtf is going on");
            return;
        }
        print("player has been hit.");
        AudioSource meow = GetComponent<AudioSource>();
        meow.PlayOneShot(meowAudio, 0.5f);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
        target.GetComponent<PlayerHealthScript>().TakeDamage(damage);
    }

    // Update is called once per frame
}
