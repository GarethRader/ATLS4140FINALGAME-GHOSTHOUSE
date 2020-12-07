using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class itemSlotScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private Sprite sprite;
    private Player player;
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Transform itemSlotContainer;
    [SerializeField]
    private Transform itemSlotTemplate;
    private TextMesh text;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        inventory =  player.GetComponent<Inventory>();
        text = GetComponentInChildren<TextMesh>();
        text.color = Color.white;
        text.text = inventory.Get(itemName).ToString();
    }
    public void OnPointerClick(PointerEventData click){
        // use item from inventory (just call function from inventory)
        //Debug.Log("item clicked");
        if(this.itemName == "Battery"){
            inventory.UseItem("Battery");
            player.FillFlashLight();
        }
        if(this.itemName == "Note"){
            //show note 
            inventory.UseItem("Note");
        }                     
    }
}
