using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5.0f;
    [SerializeField] float turnSpeed = 5.0f;
    
    
    NavMeshAgent meshA;

    //how far ai looks for
    float distanceToTarget = Mathf.Infinity;
    bool smellsYou = false;
    void Start()
    {
        meshA = GetComponent<NavMeshAgent>();
        
    }

    private void FaceTarget(){
        Vector3 direction = (target.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void OnDamageTaken(){
        smellsYou = true;
        EngageTarget();
    }

    

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
        FaceTarget();
        if(distanceToTarget >= meshA.stoppingDistance){
            ChaseTarget();
        }
        if(distanceToTarget <= meshA.stoppingDistance){
            AttackTarget();
        }
    }

    private void ChaseTarget(){
        GetComponent<Animator>().SetTrigger("run");
        GetComponent<Animator>().SetBool("attack", false);
        print("running");
        meshA.SetDestination(target.position);
    }

    private /*async*/ void AttackTarget(){
        //temp
        bool catMeow = false;
        if (catMeow == false){
            
        }
        GetComponent<Animator>().SetBool("attack", true);
        //print(name + " has slain " + target.name);
    }
    
    private void OnDrawGizmosSelected() {
        //Display chase range when selected
        Gizmos.color = new Color(1,0.7f,0.6f,1.0f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
