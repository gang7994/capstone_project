using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Slot[] slots;
    public Transform slotHolder;
    public bool activeInventory = false;

    public Button inventoryBtn;

    private void Start(){
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventoryPanel.SetActive(activeInventory);
        inventoryBtn.onClick.AddListener(Inventory);
    }

    

    void Inventory(){
        activeInventory = !activeInventory;
        inventoryPanel.SetActive(activeInventory);
    }
}
