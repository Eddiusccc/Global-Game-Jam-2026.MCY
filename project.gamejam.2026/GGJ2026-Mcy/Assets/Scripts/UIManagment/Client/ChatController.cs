using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Collections;
using System;

public class ChatController : MonoBehaviour
{
    public static ChatController instance;
    #region  UI ELEMENTS
    public TMP_Text customerChatText;
    public RequestData[] maskRequest;
    public RequestData[] gemRequest;
    public RequestData[] gliphRequest;
    public string[] initialCustomerLines;
    public string[] finalCustomerLines;
    public string[] satisfiedCustomerLines;
    public string[] unhappyCustomerLines;
    public bool isTalking = false;
    [HideInInspector] public List<string> requestToShuffle = new List<string>();
    #endregion
    public CustomerRequest customerRequest;

    public float textDurationPerChar = 0.2f;
    void Awake()
    {
        instance = this;
    }
    public void ValidateMaskButton()
    {
        if (!isTalking)
        {
            isTalking = true;
            CustomerManager.instance.ValidateCustomer();
            return;
        }
    }

    #region REQUEST MANAGMENT

    public void MakeNewRequest()
    {
        customerRequest = new CustomerRequest();
        customerRequest = Data.ReturnRandomRequest(customerRequest);
        Debug.Log(customerRequest.maskType);
        Debug.Log(customerRequest.gemType);
        Debug.Log(customerRequest.gliphType);
        // MakeRequestChat(customerRequest);
        CustomerManager.instance.SetNewCustomer(customerRequest, MakeRequestChat);
    }
    void MakeRequestChat()
    {
        isTalking = true;
        string makeCustomerChat = string.Empty;
        //INICIAL
        makeCustomerChat += GetInitialLine();
        requestToShuffle.Clear();
        //MASCARA
        requestToShuffle.Add(GetMaskLine(customerRequest.maskType));
        //GEMA
        requestToShuffle.Add(GetGemLine(customerRequest.gemType));
        //GLIFO
        requestToShuffle.Add(GetGliphLine(customerRequest.gliphType));

        ShuffleList(requestToShuffle);

        foreach (var item in requestToShuffle)
        {
            makeCustomerChat += item;
        }
        //FINAL
        makeCustomerChat += GetFinalLine();
        CustomerTalk(makeCustomerChat);
    }
    void ShuffleList(List<string> lineToShuffle)
    {
        for (int i = 0; i < lineToShuffle.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, lineToShuffle.Count);
            var temp = lineToShuffle[i];
            lineToShuffle[i] = lineToShuffle[randomIndex];
            lineToShuffle[randomIndex] = temp;
        }
    }
    void CustomerTalk(string line, Action onAction = null)
    {
        StartCoroutine(CustomerTalkSounds(line.ToCharArray()));
        customerChatText.DOTypewrite(line, ReturnTextDuration(line)).OnComplete(() =>
        {
            requestToShuffle.Clear();
            isTalking = false;
            PointsManager.instance.StartTimer();
            if (onAction != null)
            {
                onAction?.Invoke();
            }
        });
    }
    public Tween CustomerTalkTween(string line, Action onAction = null)
    {
        isTalking = true;
        StartCoroutine(CustomerTalkSounds(line.ToCharArray()));

        Tween tw = customerChatText
            .DOTypewrite(line, ReturnTextDuration(line))
            .OnComplete(() =>
            {
                requestToShuffle.Clear();
                isTalking = false;
                PointsManager.instance.StartTimer();
                onAction?.Invoke();
            });

        return tw;
    }

    IEnumerator CustomerTalkSounds(char[] chars)
    {
        int charCount = chars.Length;
        for (int i = 0; i < charCount; i++)
        {
            if (chars[i] != ' ')
            {
                AudioManager.instance.PlaySFXRandomPitch("sfxTalk", 0.3f);
            }
            yield return new WaitForSeconds(textDurationPerChar);

        }
    }

    #endregion

    #region TEXT MANAGMENT
    public Tween FinalCustomerLine(bool isHappy, Action onAction = null)
    {
        if (isHappy)
        {
            return CustomerTalkTween(GetSatisfiedLine(), onAction);
        }
        else
        {
            return CustomerTalkTween(GetUnhappyLine(), onAction);
        }
    }
    string GetSatisfiedLine()
    {
        int rng = UnityEngine.Random.Range(0, satisfiedCustomerLines.Length);
        return satisfiedCustomerLines[rng];
    }
    string GetUnhappyLine()
    {
        int rng = UnityEngine.Random.Range(0, unhappyCustomerLines.Length);
        return unhappyCustomerLines[rng];
    }
    string GetInitialLine()
    {
        int rng = UnityEngine.Random.Range(0, initialCustomerLines.Length);
        return initialCustomerLines[rng];
    }
    string GetFinalLine()
    {
        int rng = UnityEngine.Random.Range(0, finalCustomerLines.Length);
        return finalCustomerLines[rng];
    }
    string GetMaskLine(MaskType mask)
    {
        foreach (var item in maskRequest)
        {
            if (item.maskType == mask)
            {
                int rng = UnityEngine.Random.Range(0, item.lines.Length);
                return item.lines[rng];
            }
        }
        return string.Empty;
    }
    string GetGemLine(GemType gem)
    {
        foreach (var item in gemRequest)
        {
            if (item.gemType == gem)
            {
                int rng = UnityEngine.Random.Range(0, item.lines.Length);
                return item.lines[rng];
            }
        }
        return string.Empty;
    }
    string GetGliphLine(GliphType gliph)
    {
        foreach (var item in gliphRequest)
        {
            if (item.gliphType == gliph)
            {
                int rng = UnityEngine.Random.Range(0, item.lines.Length);
                return item.lines[rng];
            }
        }
        return string.Empty;
    }
    float ReturnTextDuration(string text)
    {
        float charCount = text.ToCharArray().Length;
        return charCount * textDurationPerChar;
    }

    #endregion

}



