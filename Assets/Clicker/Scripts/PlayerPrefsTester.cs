using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTester : MonoBehaviour
{

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }


}
