using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryScript : MonoBehaviour
{
    private Inventory inventory;
    private Player player;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    
    private void Awake() {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        inventory = player.GetComponent<Inventory>();
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetAmountText(int amount){

    }
    private void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 75f;
        foreach (var Item in inventory.GetInventory()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            //image.sprite = item.GetSprite();

            x++;
            if (x >= 4) {
                x = 0;
                y++;
            }
        }
    }
}
