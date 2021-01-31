using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babushka : MonoBehaviour
{
    public ParticleSystem cookies;
    public float interval = 5;
    public int amount = 10;

    void Start()
    {
        InvokeRepeating(nameof(MakeCookies), interval, interval);
    }

    void MakeCookies()
    {
        Clicker.inst.AddCookies(amount);
        cookies.Play();
    }
}
