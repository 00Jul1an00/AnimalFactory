using UnityEngine;
using System;

public class AnimalLogic
{
    private AnimalSO _baseAnimal;
    private float _cost;
    private float _speed;

    public AnimalSO BaseAnimal => _baseAnimal;
    public Sprite Sprite => _baseAnimal.Sprite;
    public float Cost => _cost;
    public float Speed => _speed;

    public event Action<float> SpeedChanged;


    public AnimalLogic(AnimalSO baseAnimal)
    {
        _baseAnimal = baseAnimal;
        _cost = _baseAnimal.BaseQuality.CalcCost();
        _speed = _baseAnimal.BaseQuality.CalcSpeed();
    }

    public void MergeAnimals(AnimalQualitySO otherAnimal)
    {
        IncreaseAnimalSpeed(otherAnimal);
        IncreaseAnimalCost(otherAnimal);
    }

    private void IncreaseAnimalSpeed(AnimalQualitySO animal)
    {
        float prevSpeed = _speed;

        if (_speed + animal.MergePower <= _baseAnimal.BaseQuality.MaxSpeed)
            _speed += animal.MergePower;
        else
            _speed = _baseAnimal.BaseQuality.MaxSpeed;

        SpeedChanged?.Invoke(prevSpeed);
    }

    private void IncreaseAnimalCost(AnimalQualitySO animal)
    {
        if (_cost + animal.MergePower <= _baseAnimal.BaseQuality.MaxCost)
            _cost += animal.MergePower;
        else
            _cost = _baseAnimal.BaseQuality.MaxCost;
    }
}
