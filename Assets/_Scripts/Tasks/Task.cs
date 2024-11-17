using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData taskData;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    [SerializeField] private GameStateHolder gameStateHolder;
    /*
        public GameObject titleObject;
        public GameObject descriptionObject;*/

    private void Awake()
    {
        title = GetComponentsInChildren<TextMeshProUGUI>()[0];
        description = GetComponentsInChildren<TextMeshProUGUI>()[1];
        gameStateHolder = Resources.Load<GameStateHolder>("GameState");

    }
    private void Update()
    {
        AssignText();
    }
    public void AssignText()
    {
        title.text = taskData.title;
        description.text = taskData.description;
    }
    
    public void ExecuteTask()
    {
        // Handle task completion logic
        // Debug.Log($"Task '{taskData.title}' completed!");
        ApplyEffects();
    }

    private void ApplyEffects()
    {
        // Example of applying task effects to the player
        if (gameStateHolder.energy >= taskData.energyChange)
        {
            PlayerStats.Instance.ChangeEnergy(taskData.energyChange);
            PlayerStats.Instance.ChangeReputation(taskData.reputationChange);
            PlayerStats.Instance.ChangeTime(taskData.duration);
        }

    }
}

