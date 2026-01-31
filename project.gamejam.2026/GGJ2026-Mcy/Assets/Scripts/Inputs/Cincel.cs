using UnityEngine;

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

        if (typeSlot.HasMask && typeItem.isMask)
        {
            typeItem.SetMaskSprite();
        }

    }
}
