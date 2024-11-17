using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float time_for_event;
    float time_to_trigger;
    /*  [SerializeField] float minWindowWidth = 340f;
        [SerializeField] float minWindowHeight = 250f;*/
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time_to_trigger += Time.deltaTime;

        if (time_to_trigger >= time_for_event)
        {
            time_to_trigger = 0;
            Debug.Log("Event triggered");
            // Trigger event
        }


    }
}
