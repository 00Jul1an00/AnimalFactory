using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalQuality
{
    Common,
    Rare,
    Mythical,
    Legendary
}


[CreateAssetMenu(fileName = "AnimalSO", menuName = "Scriptable Objects/Animal")]
public class AnimalSO : ScriptableObject
{
    [SerializeField] private AnimalQuality _animalQuality;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private int _id;
    [SerializeField] private float _speed;
    [SerializeField] private float _cost;

    public AnimalQuality AnimalQuality => _animalQuality;
    public Sprite Sprite => _sprite;
    public float Speed => _speed;
    public float Cost => _cost;
    public int Id => _id;
}
