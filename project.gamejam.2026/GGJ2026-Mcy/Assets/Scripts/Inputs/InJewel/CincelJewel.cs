using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CincelJewel : MonoBehaviour
{
    public DraggableItem draggableItem;
    public ClickableJewel clickableJewel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clickableJewel.clickAction = FunctionToCallOnClick;
    }
    void FunctionToCallOnClick()
    {
        Debug.Log("Cincel clicked!");
        TypeItem typeItem = draggableItem.GetComponent<TypeItem>();
        FindAllDraggablesItem();

        if (typeItem.isJewel && typeItem.JewelChecked)
        {
            Debug.Log("Cincel used on jewel!");
            typeItem.SetJewelSprite();
        }
    }
    void FindAllDraggablesItem()
    {
        DraggableItem[] allJewels = Object.FindObjectsByType<DraggableItem>(FindObjectsSortMode.None);
        Debug.Log("Found " + allJewels.Length + " active jewels.");

        foreach (DraggableItem draggableitem in allJewels)
        {
            TypeItem item = draggableitem.GetComponent<TypeItem>();
            if (item.isJewel && item.JewelChecked)
            {
                Debug.Log(item.ItemName + " is being used.");
                this.draggableItem = draggableitem;
            }
        }
    }
}
