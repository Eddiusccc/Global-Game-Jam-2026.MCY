using UnityEngine;
using UnityEngine.UI; // Required for UI components like Image

public class SourceImageItem : MonoBehaviour
{
public Sprite[] sourceMaskImages;
public Sprite[] sourceJewelImages;
public Sprite[] sourceGlyphImages;
// Variable to hold the loaded sprite
Sprite LoadedSprite;
//TypeItem typeItem;
    // void Update()
    // {
    //     typeItem = gameObject.GetComponent<TypeItem>();
    //     if (typeItem.isMask)
    //     {
    //         UpdateSprite(caseName: "Mask", 1);
    //     }
    //     else if (typeItem.isJewel)
    //     {
    //         UpdateSprite("Jewel", 1);
    //     }
    //     else if (typeItem.isGlyph)
    //     {
    //         UpdateSprite("Glyph", 1);
    //     }
    // }
    void UpdateSprite(string caseName, int index)
    {
        switch (caseName)
        {
            case "Mask":
                LoadedSprite = gameObject.GetComponent<SourceImageItem>().sourceMaskImages[index];
                break;
            case "Jewel":
                LoadedSprite = gameObject.GetComponent<SourceImageItem>().sourceJewelImages[index];
                break;
            case "Glyph":
                LoadedSprite = gameObject.GetComponent<SourceImageItem>().sourceGlyphImages[index];
                break;
            default:
                Debug.Log("No matching item type found.");
                break;
        }
        if (LoadedSprite != null)
        {
            gameObject.GetComponent<Image>().sprite = LoadedSprite;
        }
    }

}
