using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Linq;

public class Clicker : MonoBehaviour
{
    public static Clicker inst;

    public TextMeshProUGUI txt;
    public TextMeshProUGUI cps;

    [HideInInspector]
    public int cookies;

    Queue<int> speed = new Queue<int>();
    int lastCount;

    private void Awake()
    {
        if (inst == null)
            inst = this;

        lastCount = cookies = PlayerPrefs.GetInt(nameof(cookies), cookies);

        UpdateCookies();
    }

    private void Start()
    {
        InvokeRepeating(nameof(CountAverageSpeed), 0, 1);
    }

    //average last 10 secs
    void CountAverageSpeed()
    {
        if (speed.Count == 4)
        {
            //delete first added element 
            speed.Dequeue();
        }

        var diffrence = (cookies - lastCount) < 0 ? 0 : cookies - lastCount;


        //add new element at the end
        speed.Enqueue(diffrence);

        var average = speed.Sum() / speed.Count;

        lastCount = cookies;

        cps.text = $"{average} cps";
    }

    void UpdateCookies()
    {
        txt.text = $"{cookies} cookies";
    }

    public void AddCookies(int value)
    {
        cookies += value;

        UpdateCookies();
        //txt.transform.DOScale(Vector3.one, 0.1f).ChangeStartValue(Vector3.one * 1.3f);
    }

    public bool TakeCookies(int value)
    {
        if (cookies < value) return false;

        cookies -= value;

        UpdateCookies();

        return true;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(nameof(cookies), cookies);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetInt(nameof(cookies), cookies);
        }
    }
}
