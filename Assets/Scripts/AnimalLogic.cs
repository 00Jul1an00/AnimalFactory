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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        RedrawSpite();
        ChangeProductivityStats();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeAnimal(AnimalsData.Instance.GetAnimalByID(1));
        if (Input.GetKeyDown(KeyCode.E))
            ChangeAnimal(_prevAnimal);
    }

    private void OnEnable() => _iterationTrigger.ProductOnIteration += OnProductOnIteration;
    private void OnDisable() => _iterationTrigger.ProductOnIteration -= OnProductOnIteration;

    public void ChangeAnimal(AnimalSO newAnimal)
    {
        _prevAnimal = _currentAnimal;
        _currentAnimal = newAnimal;
        RedrawSpite();
        ChangeProductivityStats();
    }

    public void MergeAnimals(AnimalSO animal)
    {

    }

    private void IncreaseAnimalSpeed()
    {

    }

    private void IncreaseAnimalCost()
    {

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

    private void OnProductOnIteration() => _iterationTrigger.CurrentProductOnIteration.Cost += Mathf.CeilToInt(_currentAnimal.Cost);
}
