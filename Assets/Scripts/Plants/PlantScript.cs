using UnityEngine;

public abstract class PlantScript : MonoBehaviour
{
    protected bool _isEaten = false;
    public abstract void AddPlantEffect(SnailController snailController);
    public abstract void RemovePlantEffect(SnailController snailController);
}