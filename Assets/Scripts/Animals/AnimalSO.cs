using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "AnimalSO", menuName = "Scriptable Objects/Animal")]
public class AnimalSO : ScriptableObject
{
    [SerializeField] private AnimalQuality _animalQuality;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private int _id;

    private AnimalQualitySO _quality;
    private float _speed;
    private float _cost;

    public AnimalQualitySO Quality => _quality;
    public Sprite Sprite => _sprite;
    public float Speed { get { return _speed; } private set { _speed = value; } }
    public float Cost { get { return _cost; } private set { _cost = value; } }
    public int Id => _id;

    public void Init()
    {
        _speed = _quality.Speed;
        _cost = _quality.Cost;

        _quality.CalcStats();
        Debug.Log(Speed);
        Debug.Log(Cost);
    }

    public void IncreaseSpeed(float increaser)
    {
        if(increaser > 0 && Speed < _quality.MaxSpeed)
            Speed += increaser;
    }
    
    public void IncreaseCost(float increaser)
    {
        if(increaser > 0 && Cost < _quality.MaxCost)
            Cost += increaser;
    }

    private void OnValidate()
    {
        string path = _animalQuality.ToString();
        _quality = Resources.Load<AnimalQualitySO>("AnimalQuality/" + path);
    }
}
