using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum WindowType 
{
    Complete,
    Postpone
}

public class DropField : MonoBehaviour, IDropHandler
{
    public WindowType windowType;
    public TaskManager taskManager;

    void Awake()
    {
        taskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("Dropped");
        if (eventData.pointerDrag != null)
        {

            taskManager.CompleteTask(eventData.pointerDrag.gameObject.GetComponent<Task>());
            Destroy(eventData.pointerDrag.gameObject);
        }
    }
}
