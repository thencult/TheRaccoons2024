using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public float energy;
    public float reputation;

    public Slider energySlider;
    public Slider reputationSlider;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        energySlider.value = energy;
        reputationSlider.value = reputation;
    }

    public void ChangeEnergy(float amount)
    {
        energy += amount;
        energySlider.value = energy;
        Debug.Log($"Energy changed by {amount}. Current Energy: {energy}");
    }

    public void ChangeReputation(float amount)
    {
        reputation += amount;
        reputationSlider.value = reputation;
        Debug.Log($"Reputation changed by {amount}. Current Reputation: {reputation}");
    }
}

