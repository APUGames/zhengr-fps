using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    Rigidbody cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false){
            GetComponent<AudioSource>().volume = Random.Range(0.8f , 1);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f , 2);
            GetComponent<AudioSource>().Play();
        }
        
    }
}
