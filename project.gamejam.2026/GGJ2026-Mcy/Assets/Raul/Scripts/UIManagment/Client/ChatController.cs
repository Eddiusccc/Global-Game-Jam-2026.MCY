using TMPro;
using UnityEngine;
using DG.Tweening;

public class ChatController : MonoBehaviour
{
    #region  UI ELEMENTS
     public TMP_Text clientChatText;
     public PetitionsData[] maskPetitions;
     public PetitionsData[] gemPetitions;
     public PetitionsData[] gliphPetitions;

    #endregion

    void Start()
    {
        clientChatText.DOTypewrite("Hola como estas mi bro", 3f);
    }


}

public static class Tools
{
    #region HELPERS

     public static Tween DOTypewrite(this TMP_Text textComponent, string finalText, float duration)
    {
        textComponent.text = finalText;
        textComponent.maxVisibleCharacters = 0;
        int totalCharacters = textComponent.text.Length;

        return DOTween.To(
            () => (float)textComponent.maxVisibleCharacters,
            x => textComponent.maxVisibleCharacters = Mathf.Clamp(Mathf.RoundToInt(x), 0, totalCharacters),
            (float)totalCharacters,
            duration).SetEase(Ease.Linear);
    }

    #endregion
}

