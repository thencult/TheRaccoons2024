using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private RectTransform dragRectTransform;
    private Canvas canvas;
    private bool isOpen = true;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        canvas = GameObject.Find("UI").GetComponent<Canvas>();
        dragRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }

    public void CloseButtonSwitch()
    {

    if (isOpen)
        {
            CloseWindow();
        }
    else
        {
            OpenWindow();
        }
    }

    public void OpenWindow()
    {
        dragRectTransform.gameObject.SetActive(true);
        isOpen = true;
    }

    public void CloseWindow()
    {
        dragRectTransform.gameObject.SetActive(false);
        isOpen = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }


}
