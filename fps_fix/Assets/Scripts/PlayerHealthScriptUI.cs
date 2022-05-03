using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthScriptUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void displayPlayerHealth(){
        float currentHealth = GetComponent<PlayerHealthScript>().hitPoints;
        playerHealth.text = currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        displayPlayerHealth();
    }
}
