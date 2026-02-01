using DG.Tweening;
using UnityEngine;
using TMPro;

public static class Data
{
    public static Elements ReturnElementByGem(GemType gemType)
    {
        switch (gemType)
        {
            case GemType.Rubi:
            return Elements.Fuego;
            case GemType.Zafiro:
            return Elements.Agua;
            case GemType.Ambar:
            return Elements.Tierra;
            case GemType.Amatista:
            return Elements.Aire;
            default:
            return Elements.Vacio;
        }

        
    }
    public static CustomerRequest ReturnRandomRequest(CustomerRequest customerRequest) 
    {
        int rng1 = UnityEngine.Random.Range(0, 5);
        int rng2 = UnityEngine.Random.Range(0, 5);
        int rng3 = UnityEngine.Random.Range(0, 5);
        customerRequest.SetNewCustomerRequest(rng1, rng2, rng3);
        return customerRequest;
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

    public enum Elements
    {
    Fuego, Agua, Tierra, Aire, Vacio
    }
    public enum MaskType
    {
        Naturaleza, Fortuna, Guerra, Muerte, Nada
    }
    public enum GemType
    {
        Rubi, Zafiro, Ambar, Amatista, Opalo
    }
    public enum GliphType
    {
        Feliz, Triste, Molesto, Asustado, Neutral
    }
