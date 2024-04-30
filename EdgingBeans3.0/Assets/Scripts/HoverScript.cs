using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject PlayButton;
    public GameObject OptionsButton;
    public GameObject QuitButton;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(0, 25, 0);
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

}
