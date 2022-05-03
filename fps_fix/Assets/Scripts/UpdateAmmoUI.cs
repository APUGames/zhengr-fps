using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateAmmoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI ammoText2;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AmmoType ammoType2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayAmmo(){
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
        int currentAmmo2 = ammoSlot.GetCurrentAmmo(ammoType2);
        ammoText2.text = currentAmmo2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
    }
}
