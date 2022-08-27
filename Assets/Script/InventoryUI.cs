using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Button inventoryBtn;

    private void Start(){
        inventoryPanel.SetActive(activeInventory);
        inventoryBtn.onClick.AddListener(Inventory);
    }

    

    void Inventory(){
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }
}
