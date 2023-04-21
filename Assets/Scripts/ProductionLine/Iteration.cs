using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Iteration : MonoBehaviour
{
    [SerializeField] private float _productionDelay;
    [SerializeField] private Timer _timer;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private AnimalLogic _currentAnimal;
    private Product _currentProductOnIteration;
    public AnimalLogic CurrentAnimal => _currentAnimal;

    public float ProductionDelay
    {
        get { return _productionDelay; }
        set
        {
            if (value > 0 && _productionDelay >= 0.1f)
            {
                _productionDelay = value;
                _timer.AnimationDuration = _productionDelay;
            }
        }
    }

    private void OnDisable() => _currentAnimal.SpeedChanged -= OnSpeedChanged;

    public void ChangeAnimal(AnimalLogic animal)
    {
        _currentAnimal.SpeedChanged -= OnSpeedChanged;
        _productionDelay += _currentAnimal.Speed;
        _currentAnimal = animal;
        _productionDelay -= _currentAnimal.Speed;
        _currentAnimal.SpeedChanged += OnSpeedChanged;
        RedrawSprite();
    }

    private void SetStartAnimal(AnimalLogic animal)
    {
        _currentAnimal = animal; 
        _currentAnimal.SpeedChanged += OnSpeedChanged;
        _productionDelay -= _currentAnimal.Speed;
        _timer.AnimationDuration = _productionDelay;
        RedrawSprite();
    }

    private void Start()
    {
        SetStartAnimal(new AnimalLogic(AnimalsData.Instance.GetAnimalByID(1)));
    }

    private IEnumerator WaitforProductionDelay()
    {
        _currentProductOnIteration.StopProductOnBelt();

        for (int i = 0; i < Timer.DURATION_SPLITING; i++)
        {
            yield return new WaitForSeconds(_productionDelay / Timer.DURATION_SPLITING);
        }

        _currentProductOnIteration.MoveProductOnBelt();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Product product))
        {
            _currentProductOnIteration = product;
            product.Cost += Mathf.RoundToInt(_currentAnimal.Cost);
            StartCoroutine(WaitforProductionDelay());
            StartCoroutine(_timer.TimerAnimation());
        }
    }

    private void RedrawSprite() => _spriteRenderer.sprite = _currentAnimal.Sprite;

    private void OnSpeedChanged(float prevSpeed)
    {
        _productionDelay += prevSpeed;
        _productionDelay -= _currentAnimal.Speed;
    }
}
