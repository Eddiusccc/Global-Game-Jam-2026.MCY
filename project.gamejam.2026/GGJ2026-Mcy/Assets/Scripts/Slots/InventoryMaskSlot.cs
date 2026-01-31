using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryMaskSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;
        DraggableItem draggableItem = droppedObject.GetComponent<DraggableItem>();
        TypeItem typeItem = droppedObject.GetComponent<TypeItem>();
       

        if (draggableItem != null && typeItem.isJewel)
        {
            draggableItem.parentAfterDrag = transform;
            gameObject.GetComponent<TypeItem>().HasJewel = true;
        }
    }
}