using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "PetitionData", menuName = "Data")]
public class RequestData : ScriptableObject
{
    public MaskType maskType;
    public GemType gemType;
    public GliphType gliphType;

    public string[] lines;


    public string ReturnRandomLine()
    {
        int index = UnityEngine.Random.Range(0, lines.Length);
        return lines[index];
    }
}
