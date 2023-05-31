using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalQuality
{
    Default,
    Common,
    Rare,
    Mythical,
    Legendary
}

[CreateAssetMenu(fileName = "Animal Quality", menuName = "Scriptable Objects/Animal Quality")]
public class AnimalQualitySO : ScriptableObject
{
    [SerializeField] private int _rarity;
    [SerializeField] private float _mergePower;
    [Space(20)]
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [Space(20)]
    [SerializeField] private float _minCost;
    [SerializeField] private float _maxCost;

    public float MergePower => _mergePower;
    public int Rarity => _rarity;
    public float MaxSpeed => _maxSpeed;
    public float MaxCost => _maxCost;

    public float CalcSpeed() => Round(Random.Range(_minSpeed, _maxSpeed));
    public float CalcCost() => Round(Random.Range(_minCost, _maxCost));
    private float Round(float f) => Mathf.Round(f * 100f) * 0.01f;
}
