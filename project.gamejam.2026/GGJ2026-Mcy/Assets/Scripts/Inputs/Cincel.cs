using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Cincel : MonoBehaviour
{
    public InventoryTableSlot inventoryTableSlot;
    public DraggableItem draggableItem;
    public ClickableItem clickableItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickableItem.clickAction = FunctionToCallOnClick;
    }
    void FunctionToCallOnClick()
    {
        Debug.Log("Cincel clicked!");
        TypeItem typeItem = draggableItem.GetComponent<TypeItem>();
        TypeSlot typeSlot = inventoryTableSlot.GetComponent<TypeSlot>();
        FindAllDraggablesItem();

        if (typeSlot.HasMask && typeItem.isMask)
        {
            Debug.Log("Cincel used on mask!");
            typeItem.SetMaskSprite();
        }
    }
    void FindAllDraggablesItem()
    {
        DraggableItem[] allMasks = Object.FindObjectsByType<DraggableItem>(FindObjectsSortMode.None);
        Debug.Log("Found " + allMasks.Length + " active masks.");

        foreach (DraggableItem draggableitem in allMasks)
        {
            TypeItem item = draggableitem.GetComponent<TypeItem>();
            if (item.IsBeingUsed && item.isMask)
            {
                // Example action: log the name of the GameObject
                Debug.Log(item.ItemName + " is being used.");
                this.draggableItem = draggableitem;
                break; // Exit the loop after finding the first match 
            }
        }
    }
}
