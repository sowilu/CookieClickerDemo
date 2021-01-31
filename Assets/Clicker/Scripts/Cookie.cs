using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cookie : MonoBehaviour
{
    //public ParticleSystem crumbs;
    public float animTime;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        transform.DOScale(Vector3.one, animTime).ChangeStartValue(Vector3.one * 1.3f);
        Clicker.inst.AddCookies(1);

        /*var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crumbs.transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        crumbs.Play();*/

        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.Play();
    }
}
