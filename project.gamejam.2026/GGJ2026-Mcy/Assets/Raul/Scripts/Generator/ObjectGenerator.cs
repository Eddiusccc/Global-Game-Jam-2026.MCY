using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] mascaras;
    public GameObject[] gemas;
    public Transform parentTransform;
    public Canvas canvas;
    public void MaskGeneration(int index)
    {
        GameObject go = Instantiate(mascaras[index], transform.position, Quaternion.identity);
        go.transform.SetParent(parentTransform);
        go.GetComponent<DraggableItem>().canvas = canvas;
    }

    public void CreateAllMasks()
    {
        for (int i = 0; i < mascaras.Length; i++)
        {
            GameObject go = Instantiate(mascaras[i], transform.position, Quaternion.identity);
            go.transform.SetParent(parentTransform);
            go.GetComponent<DraggableItem>().canvas = canvas;
        }
    }

    public void GenGeneration(int index)
    {
        GameObject go = Instantiate(gemas[index], transform.position, Quaternion.identity);
        go.transform.SetParent(parentTransform);
        go.GetComponent<DraggableItem>().canvas = canvas;
    }

    public void CreateAllGems()
    {
        for (int i = 0; i < gemas.Length; i++)
        {
            GameObject go =Instantiate(gemas[i], transform.position, Quaternion.identity);
            go.transform.SetParent(parentTransform);
            go.GetComponent<DraggableItem>().canvas = canvas;
        }
    }

    public void DeleteAllMask()
    {
        GameObject[] masks = GameObject.FindGameObjectsWithTag("Mascara");
        foreach (GameObject mask in masks)
        {
            Destroy(mask);
        }
    }
    public void DeleteAllGems()
    {
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gema");
        foreach (GameObject gem in gems)
        {
            Destroy(gem);
        }
    }
}
