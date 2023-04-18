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

    public AnimalQualitySO BaseQuality => _quality;
    public AnimalQuality Quility => _animalQuality;
    public Sprite Sprite => _sprite;
    public int ID => _id;
    public string Name => _name;

    private void OnValidate()
    {
        string path = _animalQuality.ToString();
        _quality = Resources.Load<AnimalQualitySO>("AnimalQuality/" + path);
    }
}
