using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


//Babushkas are a seperate game object, I may add their flying models in the background in the future
public class BabushkaManager : MonoBehaviour
{
    public GameObject babushka;
    public TextMeshProUGUI txtPrice;
    public TextMeshProUGUI txtCount;
    public Button btn;

    public int price;
    int babushkaCount = 0;


    private void Start()
    {
        txtPrice.text = $"Price: {price}";

        babushkaCount = PlayerPrefs.GetInt(nameof(babushkaCount));

        AddBabushkas();
    }

    private void AddBabushkas()
    {
        for (int i = 0; i < babushkaCount; i++)
        {
            price = (int)(price * 1.5f);

            txtPrice.text = $"Price: {price}";

            var b = Instantiate(babushka);
            b.transform.parent = transform;
        }
        txtCount.text = babushkaCount.ToString();
    }

    public void AddBabushka()
    {
        if (Clicker.inst.TakeCookies(price))
        {
            txtCount.text = (++babushkaCount).ToString();

            price = (int)(price * 1.5f);

            txtPrice.text = $"Price: {price}";

            var b = Instantiate(babushka);
            b.transform.parent = transform;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            PlayerPrefs.SetInt(nameof(babushkaCount), babushkaCount);
    }


    private void Update()
    {
        btn.interactable = Clicker.inst.cookies > price;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(nameof(babushkaCount), babushkaCount);
    }
}
