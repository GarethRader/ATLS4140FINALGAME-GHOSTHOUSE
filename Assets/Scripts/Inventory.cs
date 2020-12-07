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
    public int Get(string itemName){
        Item item = null;
        if(itemName == "Battery"){
            item = new Item("Battery");
        }
        if(itemName  == "Note"){
            item = new Item("Note");
        }
        if(item == null) return -1;
        if(inventory.TryGetValue(item.type, out int current)){
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

    public void UseItem(string itemName) {
        //Debug.Log(item.type);
        if(itemName == "Battery"){
            
            Debug.Log("battery clicked");
        }
        if(itemName == "Note"){
            Debug.Log("Note clicked");
        }
    }
}
