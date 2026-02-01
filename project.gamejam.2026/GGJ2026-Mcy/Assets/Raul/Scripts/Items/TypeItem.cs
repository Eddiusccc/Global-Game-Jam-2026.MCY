using UnityEngine;
using UnityEngine.UI; // Required for UI components like Image
using System;

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
    public bool IsBeingUsed;
    public bool JewelChecked;
    public bool IsBeingUsedOnCincel;
    public string ItemName;
    public MaskWithFace[] maskWithFace;
    public JewelType[] jewelTypes;
    int currentMaskIndex = 0;
    int currentJewelIndex = 0;
    public void SetMaskSprite()
    {
        if (currentMaskIndex < maskWithFace.Length)
        {
            image.sprite = maskWithFace[currentMaskIndex].spriteMask;
            gliphType = maskWithFace[currentMaskIndex].gliphType;
            currentMaskIndex++;
        }
        else
        {
            currentMaskIndex = 0;
            image.sprite = maskWithFace[currentMaskIndex].spriteMask;
            gliphType = maskWithFace[currentMaskIndex].gliphType;
            currentMaskIndex++;
        }
    }
    public void SetJewelSprite()
    {
        if (currentJewelIndex < jewelTypes.Length)
        {
            image.sprite = jewelTypes[currentJewelIndex].spriteJewel;
            gemType = jewelTypes[currentJewelIndex].gemType;
            elementType = Data.ReturnElementByGem(gemType);
            currentJewelIndex++;
        }
        else
        {
            currentJewelIndex = 0;
            image.sprite = jewelTypes[currentJewelIndex].spriteJewel;
            gemType = jewelTypes[currentJewelIndex].gemType;
            elementType = Data.ReturnElementByGem(gemType);
            currentJewelIndex++;
        }
    }
}

[System.Serializable]
public class MaskWithFace
{
    public Sprite spriteMask;
    public GliphType gliphType;
}

[System.Serializable]
public class JewelType
{
    public Sprite spriteJewel;
    public GemType gemType;
}
