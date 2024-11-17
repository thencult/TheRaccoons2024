using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<TaskData> taskPool; // List of all tasks
    public List<Task> activeTasks; // Tasks in the current queue

    [SerializeField] private int maxTasks = 3; // Fixed task count
    public GameObject taskVisibleObject;
    public GameObject taskWindow;

    void Start()
    {
        GenerateTasks(maxTasks - activeTasks.Count);
    }

    public void GenerateTasks(int tasksAmount)
    {
        float yOffset = activeTasks.Count * 120f; // Calculate offset based on current tasks

        for (int i = 0; i < tasksAmount; i++)
        {
            // Select a random task
            var randomTask = taskPool[Random.Range(0, taskPool.Count)];

            // Instantiate the task object
            var taskObject = Instantiate(taskVisibleObject, taskWindow.transform);
            var task = taskObject.AddComponent<Task>();
            task.taskData = randomTask;

            // Position the task object
            RectTransform rectTransform = taskObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(0, -yOffset); // Negative offset for stacking downwards
            }

            // Update the vertical offset for the next task
            yOffset += 120f;

            // Add to active tasks
            activeTasks.Add(task);
        }
    }

    public void CompleteTask(Task task)
    {
        task.ExecuteTask();
        activeTasks.Remove(task);
        Destroy(task.gameObject);

        // Replenish tasks to maintain fixed count
        if (activeTasks.Count < 1)
        {
            GenerateTasks(maxTasks - activeTasks.Count);
        }
    }
}
