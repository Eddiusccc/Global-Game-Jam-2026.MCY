using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public bool isJewelSlot = false;
    public bool isGlyhpSlot = false;
    public bool isMaskSlot = false;
    public bool isTableSlot = false;

    private void Start()
    {
        string objectName = gameObject.name;
        switch (objectName)
        {
            case "Jewel":
                isJewelSlot = true;
                break;
            case "Glyph":
                isGlyhpSlot = true;
                break;
            case "Mask":
                isMaskSlot = true;
                break;
            case "TableSlot":
                isTableSlot = true;
                break;
            default:
                Debug.Log("No matching slot type found.");
                break;
        }
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