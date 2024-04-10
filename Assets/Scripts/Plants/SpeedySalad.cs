using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedySalad : PlantScript
{
    public int newSpeedMultiplier = 3;
    public int newMaxSpeedMultiplier = 3;
    int previousSpeedMultiplier = 1;
    int previousMaxSpeedMultiplier = 1;

    public override void AddPlantEffect(SnailController snail) 
    {
        if(_isEaten == false) {
            _isEaten = true;
            previousSpeedMultiplier = snail.SpeedMultiplier;
            previousMaxSpeedMultiplier = snail.MaxSpeedMultiplier;
            snail.SpeedMultiplier = newSpeedMultiplier;
            snail.MaxSpeedMultiplier = newMaxSpeedMultiplier;
            //Could switch to an eaten plant sprite
            this.gameObject.SetActive(false);
        }
    }

    public override void RemovePlantEffect(SnailController snail)
    {
        snail.SpeedMultiplier = previousSpeedMultiplier;
        snail.MaxSpeedMultiplier = previousMaxSpeedMultiplier;
    }
}
