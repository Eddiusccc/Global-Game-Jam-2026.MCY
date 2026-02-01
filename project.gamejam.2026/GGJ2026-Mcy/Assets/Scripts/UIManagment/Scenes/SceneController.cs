using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public SceneType _sceneType;

    [Header("Scene References")]
    [Space(10)]
    public Canvas mainCanvas;
    CanvasScaler canvasScaler;
    public RectTransform clienteTransform;
    public RectTransform tallerTransform;
    public RectTransform loseTransform;
    public RectTransform winTransform;
    public RectTransform mainMenuTransform;
    public Button mainMenuButton, quitButton;
    public bool isPlaying = false;
    [Header("UI")]
    [Space(10)]
    public GameObject manualWindow;
    public Button manualButton;
    public Button resetLoseButton;
    public Button resetWinButton;
    public float transitionDuration = 1f;
    public Button cambiarEscenaButton;
    float width;
    float height;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        resetLoseButton.onClick.AddListener(OnResetButton);
        resetWinButton.onClick.AddListener(OnResetButton);
        cambiarEscenaButton.onClick.AddListener(OnCambiarEscenaButton);
        manualButton.onClick.AddListener(OnManualButton);
        mainMenuButton.onClick.AddListener(OnMainMenuButton);
        quitButton.onClick.AddListener(OnQuitButton);
        canvasScaler = mainCanvas.gameObject.GetComponent<CanvasScaler>();
        width = canvasScaler.referenceResolution.x;
        height = canvasScaler.referenceResolution.y;
        SwitchScene(SceneType.Cliente);
        AudioManager.instance.Play("bg");
    }
    public void SwitchScene(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.Cliente:
                clienteTransform.DOAnchorPosX(0, transitionDuration);
                tallerTransform.DOAnchorPosX(width, transitionDuration);
                _sceneType = SceneType.Cliente;
                break;
            case SceneType.Taller:
                tallerTransform.DOAnchorPosX(0, transitionDuration);
                clienteTransform.DOAnchorPosX(-width, transitionDuration);
                _sceneType = SceneType.Taller;
                break;
            case SceneType.Perdiste:
                loseTransform.DOAnchorPosY(0, transitionDuration);
                winTransform.DOAnchorPosY(-height, transitionDuration);
                _sceneType = SceneType.Perdiste;
                isPlaying = false;
                break;
            case SceneType.Ganaste:
                winTransform.DOAnchorPosY(0, transitionDuration);
                loseTransform.DOAnchorPosY(height, transitionDuration);
                _sceneType = SceneType.Ganaste;
                break;
            case SceneType.Jugando:
                winTransform.DOAnchorPosY(-height, transitionDuration);
                loseTransform.DOAnchorPosY(height, transitionDuration);
                SwitchScene(SceneType.Cliente);
                break;
        }
    }

    #region BUTTONS
    public void OnCambiarEscenaButton()
    {
        if (_sceneType == SceneType.Cliente)
        {
            SwitchScene(SceneType.Taller);
        }
        else if(_sceneType == SceneType.Taller)
        {
            SwitchScene(SceneType.Cliente);
        }
    }
    public void OnResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnMainMenuButton()
    {
        AudioManager.instance.Play("choir");
        if (!isPlaying)
        {
            mainMenuTransform.DOAnchorPosY(height, transitionDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
         {
             isPlaying = true;
             ChatController.instance.MakeNewRequest();
         });
        }
        else
        {
            mainMenuTransform.DOAnchorPosY(height, transitionDuration).SetEase(Ease.InOutQuad).OnComplete(() =>
         {
             Time.timeScale = 1f;
         });
        }
    }
    public void OnManualButton()
    {
        if (_sceneType != SceneType.Perdiste)
        {
            manualWindow.SetActive(!manualWindow.activeSelf);
        }
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
    #endregion
    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            SwitchScene(SceneType.Jugando);
            return;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SwitchScene(SceneType.Taller);
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SwitchScene(SceneType.Cliente);
            return;
        }
        if (Input.GetKey(KeyCode.L))
        {
            SwitchScene(SceneType.Perdiste);
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            SwitchScene(SceneType.Ganaste);
            return;
        }
    }

    public enum SceneType
    {
        Cliente,
        Taller,
        Perdiste,
        Ganaste,
        Jugando
    }
}
