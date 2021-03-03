using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// He añadido una funcion de cambiar escala segun el feedBack correspondiente.
/// </summary>
public class MyBtn : Button
{
    public Vector3 enterScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 pressScale = new Vector3(1.1f, 1.1f, 1.1f);
    public Vector3 exitScale = new Vector3(1, 1, 1);

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        transform.localScale = enterScale;
        SoundsManager.soundsManager.PlayAudio(Audios.ButtonDown);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        transform.localScale = enterScale;
        SoundsManager.soundsManager.PlayAudio(Audios.ButtonFeedBack);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        transform.localScale = exitScale;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        transform.localScale = pressScale;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }
}
