using DG.Tweening;
using System.ComponentModel;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [Header("Scene References")]
    public Canvas canvasCliente;
    public Canvas canvasTaller;
    Camera mainCamera;
    public float transitionDuration = 1f;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void SwitchScene(SceneType sceneType)
    {
        Vector3 targetPos = ScenePosition(sceneType);
        switch (sceneType)
        {
            case SceneType.Cliente:
                mainCamera.transform.DOMove(targetPos, transitionDuration)
                    .SetEase(Ease.InOutQuad);
                break;
            case SceneType.Taller:
                mainCamera.transform.DOMove(targetPos, transitionDuration)
                    .SetEase(Ease.InOutQuad);
                break;
        }
    }

    Vector3 ScenePosition(SceneType sceneType)
    {
        Vector3 position = Vector3.zero;
        switch (sceneType)
        {
            case SceneType.Cliente:
                position = canvasCliente.transform.position;
                break;
            case SceneType.Taller:
                position = canvasTaller.transform.position;
                break;
        }
        position = new Vector3(position.x, position.y, mainCamera.transform.position.z);
        return position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SwitchScene(SceneType.Taller);
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SwitchScene(SceneType.Cliente);
            return;
        }
    }

    public enum SceneType
    {
        Cliente,
        Taller
    }
}
