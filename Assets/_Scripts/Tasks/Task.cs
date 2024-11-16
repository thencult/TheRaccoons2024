using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskData taskData;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private void Awake()
    {
        title = GetComponent<TextMeshProUGUI>();
        description = GetComponent<TextMeshProUGUI>();
    }

    public void AssignText()
    {

    }
    
    public void ExecuteTask()
    {
        // Handle task completion logic
        Debug.Log($"Task '{taskData.title}' completed!");
        ApplyEffects();
    }

    private void ApplyEffects()
    {
        // Example of applying task effects to the player
        PlayerStats.Instance.ChangeEnergy(taskData.energyChange);
        PlayerStats.Instance.ChangeReputation(taskData.reputationChange);
    }
}

