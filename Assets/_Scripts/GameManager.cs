using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public float time_for_event;
    float time_to_trigger;
    public PhoneHandler phone;
    [SerializeField] private GameStateHolder gameStateHolder;
    /*  [SerializeField] float minWindowWidth = 340f;
        [SerializeField] float minWindowHeight = 250f;*/
    // Start is called before the first frame update

    private void Awake()
    {
        gameStateHolder = Resources.Load<GameStateHolder>("GameState");
        gameStateHolder.energy = 100;
    }
    void Start()
    {
       phone = GameObject.Find("Phone").GetComponent<PhoneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        time_to_trigger += Time.deltaTime;

        if (time_to_trigger >= time_for_event)
        {
            time_to_trigger = 0;
            phone.startEvent();
            // Trigger event
        }


    }
}
