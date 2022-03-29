using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    
    NavMeshAgent meshA;

    //how far ai looks for
    float distanceToTarget = Mathf.Infinity;
    bool smellsYou = false;
    bool isProvoked = false;
    void Start()
    {
        meshA = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    /*void Update()
    {
        //measure distance between enemy n player
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (smellsYou | isProvoked) {
            EngageTarget();
        }
        else {
            if (distanceToTarget <= chaseRange) {
            meshA.SetDestination(target.position);
            smellsYou = true;
        }
        }
    }*/

    void Update()
    {
        //measure distance between enemy n player
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (smellsYou) {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange) {
            meshA.SetDestination(target.position);
            smellsYou = true;
        }
    }

    private void EngageTarget(){
        if(distanceToTarget >= meshA.stoppingDistance){
            ChaseTarget();
        }
        if(distanceToTarget <= meshA.stoppingDistance){
            AttackTarget();
        }
    }

    private void ChaseTarget(){
        //GetComponent<Animator>().SetTrigger("run");
        meshA.SetDestination(target.position);
    }

    private void AttackTarget(){
        //temp
        print(name + " has slain " + target.name);
    }
    
    private void OnDrawGizmosSelected() {
        //Display chase range when selected
        Gizmos.color = new Color(1,0.7f,0.6f,1.0f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
