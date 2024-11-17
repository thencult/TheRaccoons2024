using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTask : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameStateHolder gameStateHolder;

    void Awake()
    {
        canvas = GameObject.Find("UI").GetComponent<Canvas>();
        dragRectTransform = transform.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        gameStateHolder = Resources.Load<GameStateHolder>("GameState");
       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameStateHolder.energy >= eventData.pointerDrag.GetComponent<Task>().taskData.energyChange)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
            dragRectTransform.parent = canvas.transform;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (gameStateHolder.energy >= eventData.pointerDrag.GetComponent<Task>().taskData.energyChange)
        {
            dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameStateHolder.energy >= eventData.pointerDrag.GetComponent<Task>().taskData.energyChange)
        {
            canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }

}
