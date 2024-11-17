using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public GameStateHolder gameStateHolder;

    public FadeInOut fadeInOut;
    public float time;
    public int scene_index;
    public Slider energySlider;
    public Slider reputationSlider;
    public Slider timeSlider;
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        energySlider.value = gameStateHolder.energy;
        reputationSlider.value = gameStateHolder.reputation;
    }


    float elapsed = 0f;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            ChangeTime(1);
        }
    }

    public void ChangeEnergy(float amount)
    {
        gameStateHolder.energy += amount;
        energySlider.value = gameStateHolder.energy;
        Debug.Log($"Energy changed by {amount}. Current Energy: {gameStateHolder.energy}");
    }

    public void ChangeReputation(float amount)
    {
        gameStateHolder.reputation += amount;
        reputationSlider.value = gameStateHolder.reputation;
        Debug.Log($"Reputation changed by {amount}. Current Reputation: {gameStateHolder.reputation}");
    }

    public void ChangeTime(float amount)
    {
        time -= amount;
        timeSlider.value = time;
        Debug.Log($"Time changed by {amount}. Current Time: {time}");
        if (time <= 0)
        {
            StartCoroutine(EndDay());
        }
    }

    public IEnumerator EndDay ()
    {
        fadeInOut.StartFadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(scene_index);
    }
}

