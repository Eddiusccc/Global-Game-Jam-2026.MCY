using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTableSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
        TypeItem typeItem = droppedObject.GetComponent<TypeItem>();

        if (draggableItem != null && typeItem.isMask)
        {
            typeItem.IsBeingUsed = true;
            typeItem.IsBeingUsedOnCincel = false;
            gameObject.GetComponent<TypeSlot>().HasMask = true;
            draggableItem.parentAfterDrag = transform;
        } 
    }
}