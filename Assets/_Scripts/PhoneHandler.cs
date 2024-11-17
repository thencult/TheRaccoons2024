using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PhoneHandler : MonoBehaviour, IPointerDownHandler
{
    Vector3 finalPosition;
    // Start is called before the first frame update
    void Start()
    {
        finalPosition = new Vector3(this.transform.position.x, this.transform.position.y + 450, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == finalPosition)
        {
           PlayerStats.Instance.ChangeTime(90);
        }
    }

    public void startEvent()
    {
        this.transform.position = Vector3.MoveTowards(
            this.transform.position,
            new Vector3(
                this.transform.position.x,
                250,
                this.transform.position.z
            ),
            25
            );  
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 10, this.transform.position.z);
    }

}
