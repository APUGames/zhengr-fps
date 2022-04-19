using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] float damage = 30f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= damage)
        {
            Destroy(gameObject);
        }
    }
}
