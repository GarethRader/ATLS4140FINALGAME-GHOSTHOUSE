using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ItemTypes,int> inventory;
    private UI_InventoryScript UI_inventory;

    private void Awake(){
        inventory = new Dictionary<ItemTypes, int>();
        UI_inventory = GameObject.FindGameObjectWithTag("UI_Inventory").GetComponent<UI_InventoryScript>();
    }

    public void AddItem(ItemTypes types, int count =1 ){
        if(!inventory.TryGetValue(types, out int current)){
            inventory.Add(types, count);
            DisplayInventory();
            //Debug.Log(inventory[types]);
        }
        else{
            inventory[types] += count;
            DisplayInventory();
            //Debug.Log(inventory[types]);
        }
    }
    public Dictionary<ItemTypes,int> GetInventory(){
        return inventory;
    }
    public int Get(ItemTypes item){
        if(inventory.TryGetValue(item, out int current)){
            return current;
        }
        else{
            throw new KeyNotFoundException();
        }
    }

    // FOR DEBUGGING
    public void DisplayInventory(){
        foreach(var entry in inventory){
            Debug.Log(entry);
        }
    }

    public void UseItem(Item item) {
        //Debug.Log(item.type);
        if(item.itemName == "Battery"){
            Debug.Log("battery clicked");
        }
        if(item.itemName == "Note"){
            Debug.Log("Note clicked");
        }
    }
}
