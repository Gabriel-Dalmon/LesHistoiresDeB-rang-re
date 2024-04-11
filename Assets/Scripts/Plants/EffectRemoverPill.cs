using UnityEngine;

public class EffectRemoverPill : PlantScript
{
    public EffectRemoverPill(bool isEaten)
    {
        _isEaten = isEaten;
    }
    public override void AddPlantEffect(SnailController snail)
    {
    }

    public override void RemovePlantEffect(SnailController snail)
    {
    }
}
