using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [HideInInspector] public SceneType sceneType;

    [Header("Scene References")]
    public Canvas mainCanvas;
    CanvasScaler canvasScaler;
    public RectTransform clienteTransform;
    public RectTransform tallerTransform;
    Camera mainCamera;
    public float transitionDuration = 1f;
    float width;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        mainCamera = Camera.main;
        canvasScaler = mainCanvas.gameObject.GetComponent<CanvasScaler>();
        width = canvasScaler.referenceResolution.x;
        SwitchScene(SceneType.Cliente);
    }
    public void SwitchScene(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Cliente:
                clienteTransform.DOAnchorPosX(0, transitionDuration);
                tallerTransform.DOAnchorPosX(width, transitionDuration);
                sceneType = SceneType.Cliente;
                break;
            case SceneType.Taller:
                tallerTransform.DOAnchorPosX(0, transitionDuration);
                clienteTransform.DOAnchorPosX(-width, transitionDuration);
                sceneType = SceneType.Taller;
                break;
        }
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
