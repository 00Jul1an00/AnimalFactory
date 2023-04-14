using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalLogic : MonoBehaviour
{
    [SerializeField] private AnimalSO _currentAnimal;
    [SerializeField] private IterationTrigger _iterationTrigger;
   
    private SpriteRenderer _spriteRenderer;
    private AnimalSO _prevAnimal;

    private void Start()
    {
        //
        _currentAnimal.Init();
        //
        _spriteRenderer = GetComponent<SpriteRenderer>();
        RedrawSpite();
        ChangeProductivityStats();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            ChangeAnimal(AnimalsData.Instance.GetAnimalByID(1));
        if (Input.GetKeyUp(KeyCode.E))
            ChangeAnimal(_prevAnimal);
        if (Input.GetKeyUp(KeyCode.S))
            MergeAnimals(AnimalsData.Instance.GetAnimalByID(1).Quality);
    }

    private void OnEnable() => _iterationTrigger.ProductOnIteration += OnProductOnIteration;
    private void OnDisable() => _iterationTrigger.ProductOnIteration -= OnProductOnIteration;

    public void ChangeAnimal(AnimalSO newAnimal)
    {
        _prevAnimal = _currentAnimal;
        _currentAnimal = newAnimal;
        //
        _currentAnimal.Init();
        //
        RedrawSpite();
        ChangeProductivityStats();
    }

    public void MergeAnimals(AnimalQualitySO animal)
    {
        IncreaseAnimalSpeed(animal);
        IncreaseAnimalCost(animal);
    }

    private void IncreaseAnimalSpeed(AnimalQualitySO animal)
    {
        _iterationTrigger.ProductionDelay += _currentAnimal.Speed;
        _currentAnimal.IncreaseSpeed(animal.MergePower);
        _iterationTrigger.ProductionDelay -= _currentAnimal.Speed;
    }

    private void IncreaseAnimalCost(AnimalQualitySO animal)
    {
        _currentAnimal.IncreaseCost(animal.MergePower);
    }

    private void ChangeProductivityStats()
    {
        if(_prevAnimal != null)
        {
            _iterationTrigger.ProductionDelay += _prevAnimal.Speed;
        }    

        _iterationTrigger.ProductionDelay -= _currentAnimal.Speed;
    }

    private void RedrawSpite() => _spriteRenderer.sprite = _currentAnimal.Sprite;

    private void OnProductOnIteration() => _iterationTrigger.CurrentProductOnIteration.Cost += Mathf.RoundToInt(_currentAnimal.Cost);
}
