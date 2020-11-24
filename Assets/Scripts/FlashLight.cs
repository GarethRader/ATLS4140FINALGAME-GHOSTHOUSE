using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private HealthSystem batterySystem;
    private bool isTurnedOn = false;
    private MeshCollider collider;

    private void Awake(){
        // REUSING HEALTH SYSTEM FOR BATTERY SYSTEM
        batterySystem = new HealthSystem(1000);
        Transform batteryBarTransform = GameObject.FindGameObjectWithTag("FlashLightBattery").transform;
        HealthBar batteryBar = batteryBarTransform.GetComponent<HealthBar>();
        batteryBar.Setup(batterySystem);

        collider = transform.Find("FlashLight").GetComponent<MeshCollider>();
        collider.enabled = false;

    }
    public void UseFlashLight(){
        //turn on flashlight and drain while on
        isTurnedOn ^= true; // will change to opposite state
        collider.enabled ^= true;
    }
    private void ForceTurnOffFlashLight(){
        isTurnedOn = false;
        collider.enabled = false;
    }
    private void Update(){
        if(isTurnedOn){
            if(batterySystem.GetHealthPercentage() > 0) batterySystem.Damage(1);
            else ForceTurnOffFlashLight();
            //drain battery and activate collider
            
        }
    }

    public bool FlashLightOn(){
        return isTurnedOn;
    }
    public void UseBattery(){
        batterySystem.Heal(100);
    }
}
