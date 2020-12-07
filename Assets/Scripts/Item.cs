using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public ItemTypes type;
    public Sprite sprite;
    public Inventory inventory;
    private void Awake(){
        var player = GameObject.FindGameObjectWithTag("player");
        inventory = player.GetComponent<Inventory>();
    }
    public Item(string name){
        if(name == "Battery"){
            type = ItemTypes.Battery;
        }
        if(name == "Note"){
            type = ItemTypes.Note;
        }
        itemName = name;
    }
    public Item(string name, ItemTypes type){
        itemName = name;
        type = type;
    }
    public Sprite GetSprite(){
        return sprite;
    }
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "player"){
            inventory.AddItem(type);

            //BUG: MOVING THROUGH ITEM OBJECTS TOO FAST WILL NOT BE DESTROYED FAST ENOUGH AND COUNT IT TWICE OR MORE
            // NEEDS TIME TO PICK UP ITEMS ONCE THEN DESTROY THEM
            // HAVE TRIED TO USE ONTRIGGER ENTER AND EXIT FUNCTION

            Destroy(this.GetComponent<MeshFilter>());
            Destroy(this);
            //Destroy(this.GetComponent<MeshFilter>());
        }
        else{

        }
        
    }
}