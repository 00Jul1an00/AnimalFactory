using UnityEngine;
using System;

public class AnimalLogic : MonoBehaviour
{
    [SerializeField] private AnimalSO _baseAnimal;

    private float _cost;
    private float _speed;

    public AnimalSO BaseAnimal => _baseAnimal;
    public Sprite Sprite => _baseAnimal.Sprite;
    public float Cost => _cost;
    public float Speed => _speed;

    public event Action<float> SpeedChanged;

    #region temp
    private void Start()
    {
        _baseAnimal.Quality.CalcStats();
        _cost = _baseAnimal.Quality.Cost;
        _speed = _baseAnimal.Quality.Speed;
    }
    #endregion

    public void AddToPlayerInventory()
    {
        _baseAnimal.Quality.CalcStats();
        _cost = _baseAnimal.Quality.Cost;
        _speed = _baseAnimal.Quality.Speed;
    }

    public void MergeAnimals(AnimalQualitySO animal)
    {
        IncreaseAnimalSpeed(animal);
        IncreaseAnimalCost(animal);
    }

    private void IncreaseAnimalSpeed(AnimalQualitySO animal)
    {
        float prevSpeed = _speed;

        if (_speed + animal.MergePower < _baseAnimal.Quality.MaxSpeed)
            _speed += animal.MergePower;
        else
            _speed = _baseAnimal.Quality.MaxSpeed;

        SpeedChanged?.Invoke(prevSpeed);
    }

    private void IncreaseAnimalCost(AnimalQualitySO animal)
    {
        if (_cost + animal.MergePower < _baseAnimal.Quality.MaxCost)
            _cost += animal.MergePower;
        else
            _cost = _baseAnimal.Quality.MergePower;

    }
}
