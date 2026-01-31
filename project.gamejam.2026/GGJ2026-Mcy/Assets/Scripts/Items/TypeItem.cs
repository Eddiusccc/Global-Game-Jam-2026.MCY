using UnityEngine;
using UnityEngine.UI; // Required for UI components like Image

public class TypeItem : MonoBehaviour
{
    // Enums to define item types
    public MaskTypes maskType;
    public GemType gemType;
    public GliphType gliphType;
    public Elements elementType;
    public Image image;
    //Variable to hold the item type as string
    public bool isMask;
    public bool isJewel;
    public bool isGlyph;
    public bool HasJewel;
    public bool HasGlyph;
    public bool IsComplete;
    public MaskWithFace[] maskWithFace;

    int currentMaskIndex = 0;
    public void SetMaskSprite()
    {
        if (currentMaskIndex < maskWithFace.Length)
        {
            image.sprite = maskWithFace[currentMaskIndex].spriteMask;
            currentMaskIndex++;
        }
        else
        {
            currentMaskIndex = 0;
            image.sprite = maskWithFace[currentMaskIndex].spriteMask;
            currentMaskIndex++;
        }
    }
}

[System.Serializable]
public class MaskWithFace
{
    public Sprite spriteMask;
    public GliphType gliphType;
}