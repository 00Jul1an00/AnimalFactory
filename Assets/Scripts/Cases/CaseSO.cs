using UnityEngine;

[CreateAssetMenu(fileName = "Case", menuName = "Scriptable Objects/Case")]
public class CaseSO : ScriptableObject
{
    [SerializeField] private int _commonDropChance;
    [SerializeField] private int _rareDropChance;
    [SerializeField] private int _mythicalDropChance;
    [SerializeField] private int _id;

    public int ID => _id;
    public int CommonDropChance => _commonDropChance;
    public int RareDropChance => _rareDropChance;
    public int MythicalDropChance => _mythicalDropChance;
}