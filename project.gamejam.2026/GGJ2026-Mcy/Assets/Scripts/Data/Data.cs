using UnityEngine;

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
}
    public enum Elements
    {
    Fuego, Agua, Tierra, Aire, Vacio
    }
    public enum MaskTypes
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
