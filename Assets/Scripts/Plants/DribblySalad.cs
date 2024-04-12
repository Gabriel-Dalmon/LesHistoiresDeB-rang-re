using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DribblySalad : PlantScript
{
    public int SpitCountAdded = 15;

    public override void AddPlantEffect(SnailController snail) 
    {
        if(_isEaten == false) {
            _isEaten = true;
            snail.remainingSpitCount += SpitCountAdded;
            //Could switch to an eaten plant sprite
            this.gameObject.SetActive(false);
        }
    }

    public override void RemovePlantEffect(SnailController snail)
    {
    }
}
