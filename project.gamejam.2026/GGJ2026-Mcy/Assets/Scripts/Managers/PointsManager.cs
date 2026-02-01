using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    #region UI ELEMENTS
    public TMP_Text currentTimeText;
    public TMP_Text currentMoneyText;
    public float segundosParaRealizarLaMascara;
    public float minMaxVariacionSegundos;
    public int dineroGanadoPorMascara;
    public int minMaxVariacionDinero;
    public int dineroWinCondition;
    public int dineroPenalizacion;
    float timeLeft = 10f;

    #endregion
    void Awake()
    {
        instance = this;
        currentMoneyText.text = currentMoney.ToString();
    }
    void Update()
    {
        UpdateTime();
        UpdateMoneyCheck();
    }
    #region MONEY MANAGMENT
    int currentMoney = 0;
    void UpdateMoneyCheck()
    {
        if (currentMoney >= dineroWinCondition)
        {
            //GANASTE
            isTimeRunning = false;
            SceneController.instance.SwitchScene(SceneController.SceneType.Ganaste);
        }
    }
    int ReturnMaskIncome()
    {
        int variacion = Random.Range(-minMaxVariacionDinero, minMaxVariacionDinero);
        return dineroGanadoPorMascara + variacion;
    }

    public void GainMoney(int penalizaciones = 0)
    {
        int baseMoney = ReturnMaskIncome();
        int finalMoney = baseMoney - (dineroPenalizacion * penalizaciones);
        finalMoney = Mathf.Clamp(finalMoney, 0, 9999);
        currentMoney += finalMoney;
        Debug.Log("Dinero ganado: " + finalMoney);
        currentMoneyText.text = currentMoney.ToString();
    }

    #endregion

    #region  TIME MANAGMENT
    void UpdateTime()
    {
        if (!isTimeRunning) { return; }
        TimeTick();
    }
    bool isTimeRunning = false;
    public void SetNewTime()
    {
        float variation = Random.Range(-minMaxVariacionSegundos, minMaxVariacionSegundos);
        float newTime = segundosParaRealizarLaMascara + variation;
        timeLeft = newTime;
        isTimeRunning = true;
    }

    void TimeTick()
    {
        timeLeft -= Time.deltaTime;
        UpdateTimeUI();
    }
    void UpdateTimeUI()
    {
        if(isTimeRunning == false){return;}
        int minutos = Mathf.FloorToInt(timeLeft / 60f);
        int segundos = Mathf.FloorToInt(timeLeft % 60f);

        currentTimeText.text = $"{minutos:00}:{segundos:00}";
        if (segundos <= 0 && isTimeRunning == true && timeLeft == 0)
        {
            isTimeRunning = false;
            Debug.Log("Tiempo terminado");
            SceneController.instance.SwitchScene(SceneController.SceneType.Perdiste);
        }
    }
    public void StartTimer()
    {
        SetNewTime();
    }

    #endregion
}
