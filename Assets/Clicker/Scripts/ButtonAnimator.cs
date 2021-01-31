using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonAnimator : MonoBehaviour
{
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void ButtonClicked()
    {
        audio.Play();
        transform.DOScale(Vector3.one, 1).ChangeStartValue(Vector3.one * 1.3f);
    }
}
