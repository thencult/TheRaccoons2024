using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Tasks/Task Data", order = 0)]
public class TaskData : ScriptableObject
{
    public string title;        // Task title
    public string description;  // Task description
    public float duration;      // Time required to complete
    public float energyChange;  // Energy change when completed
    public float reputationChange; // Reputation impact
    public TaskType taskType;   // Optional: categorize tasks
}

public enum TaskType
{
    Work,
    Rest,
    Social,
    Miscellaneous
}
