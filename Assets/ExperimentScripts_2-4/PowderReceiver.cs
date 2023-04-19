using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderReceiver : MonoBehaviour
{
    public float requiredPowder;
    public float currentPowder;
    public float percentage;
    public float normalizedPercentage;

    public void PowderFill(float amount)
    {
        if (currentPowder + amount < requiredPowder)
            currentPowder += amount;
        else
            currentPowder = requiredPowder;
        CalculatePercentage();
    }

    void CalculatePercentage()
    {
        normalizedPercentage = currentPowder / requiredPowder;
        percentage = normalizedPercentage * 100;
    }
}
