using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantScriptLinker : MonoBehaviour
{
    public PlantScript _linkedPlantScript;

    public PlantScript Get()
    {
        return _linkedPlantScript;
    }
    /*public virtual void AddPlantEffect(SnailController snailController) 
    { 
        _linkedPlantScript.AddPlantEffect(snailController);
    }

    public virtual void RemovePlantEffect(SnailController snailController)
    {
        _linkedPlantScript.RemovePlantEffect(snailController);
    }*/
}
