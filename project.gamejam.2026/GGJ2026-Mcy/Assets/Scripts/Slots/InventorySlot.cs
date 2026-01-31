using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool isJewelSlot = false;
    public bool isGlyhpSlot = false;
    public bool isMaskSlot = false;

    private void Start()
    {
        string objectName = gameObject.name;
        Debug.Log("The name of this object is: " + objectName);
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            draggableItem.parentAfterDrag = transform;
        } 
    }
}