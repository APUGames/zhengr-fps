using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();

        hitPoints -= damage;

        if (hitPoints <= damage)
        {
            Destroy(gameObject);
        }
    }

}
