using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private HealthSystem batterySystem;
    private bool isTurnedOn = false;
    [SerializeField]
    private MeshCollider collider;
    private int frames = 0;
    [SerializeField]
    private MeshRenderer flashLightMesh;
    [SerializeField]
    AudioSource flashLightSound;

    private void Awake(){
        // REUSING HEALTH SYSTEM FOR BATTERY SYSTEM
        batterySystem = new HealthSystem(500);
        Transform batteryBarTransform = GameObject.FindGameObjectWithTag("FlashLightBattery").transform;
        HealthBar batteryBar = batteryBarTransform.GetComponent<HealthBar>();
        batteryBar.Setup(batterySystem);

        collider = transform.Find("flashlight 1").GetComponent<MeshCollider>();
        collider.enabled = false;
        flashLightMesh = transform.Find("flashlight 1").GetComponent<MeshRenderer>();
        flashLightMesh.enabled = false;
        flashLightSound = GetComponent<AudioSource>();
    }
    public void UseFlashLight(){
        // INSERT FLASHLIGHT SOUND
        //turn on flashlight and drain while on
        isTurnedOn ^= true; // will change to opposite state
        flashLightSound.Play();
        collider.enabled ^= true;
        flashLightMesh.enabled ^= true;
    }
    private void ForceTurnOffFlashLight(){
        isTurnedOn = false;
        collider.enabled = false;
        flashLightMesh.enabled = false;
    }
    private void Update(){
        if(isTurnedOn){
            if(batterySystem.GetHealthPercentage() > 0) batterySystem.Damage(1);
            else ForceTurnOffFlashLight();
            //drain battery and activate collider
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            var enemyObject = other.gameObject.GetComponent<EnemyScript>();
            //enemyObject.TakeDamage(10);
            StartCoroutine(enemyObject.TakeDamage(10));
            //Debug.Log("enemy taking damage");
            frames = 0;
        }
    }
    private void OnTriggerStay(Collider other){
        if(other.tag == "Enemy"){
            if(frames <= 60 ){
                frames++;
            }
            else{
                var enemyObject = other.gameObject.GetComponent<EnemyScript>();
                enemyObject.normalTakeDamage(5);
                //Debug.Log("enemy taking damage" + frames);
            }
            
        }
    }

    public bool FlashLightOn(){
        return isTurnedOn;
    }
    public void UseBattery(){
        batterySystem.Heal(100);
    }
}
