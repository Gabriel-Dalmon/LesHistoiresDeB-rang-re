using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickySalad : PlantScript
{
    public int newStickyStrength = 15;
    int previousStickyStrength = 1;

    public override void AddPlantEffect(SnailController snail) 
    {
        if(_isEaten == false) {
            _isEaten = true;
            previousStickyStrength = snail.stickyStrength;
            snail.stickyStrength = newStickyStrength;
            //Could switch to an eaten plant sprite
            this.gameObject.SetActive(false);
        }
    }

    public override void RemovePlantEffect(SnailController snail)
    {
        snail.stickyStrength = previousStickyStrength;
    }
}
