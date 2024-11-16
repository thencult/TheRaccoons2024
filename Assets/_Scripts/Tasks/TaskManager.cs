using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<TaskData> taskPool; // List of all tasks
    public List<Task> activeTasks; // Tasks in the current queue

    [SerializeField] private int maxTasks = 1;
    public GameObject taskVisibleObject;
    public GameObject taskWindow;

    void Start()
    {
        GenerateTasks(maxTasks);
    }

    public void GenerateTasks(int tasksAmount)
    {
        activeTasks.Clear();

        float yOffset = -120f; // Start at the top of the container

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
                rectTransform.anchoredPosition = new Vector2(0, -yOffset);
            }

            // Update the vertical offset for the next task
            yOffset += 120f; // Adjust this value to change the spacing

            // Add to active tasks
            activeTasks.Add(task);
        }
    }


    public void CompleteTask(Task task)
    {
        task.ExecuteTask();
        activeTasks.Remove(task);
        Destroy(task.gameObject);

        // Optionally generate a new task
        GenerateTasks(maxTasks);
    }
}
