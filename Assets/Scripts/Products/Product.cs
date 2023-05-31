using UnityEngine;
using System;

public class Product : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    public Product NextProductOnBelt;

    public float SpeedOnBelt { get; private set; }
    public int Cost { get; private set; }
    public int CostFromIteration { get; private set; }

    private bool _isStoped = false;
    private Rigidbody2D _rb;
    

    private void Start()
    {
        SpeedOnBelt = 1;
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable()
    {
        if (Cost < 1)
            Cost = 1;
    }

    private void OnDisable()
    {
        Cost -= CostFromIteration;
        CostFromIteration = 0;
    }

    private void Update()
    {
        if (_isStoped)
            return;

        if (CheckDistance())
            SpeedOnBelt = 0;
        else
            MoveProductOnBelt();
    }

    private bool CheckDistance()
    {
        if (NextProductOnBelt == null)
            return false;

        float Distance = Vector2.Distance(transform.position, NextProductOnBelt.transform.position);
        return Distance <= _maxDistance;
    }

    public void ChangeProductCost(int value)
    {
        if (value < 0)
            return;

        Cost = value - CostFromIteration;
    }
    
    public void IncreseProductCost(int value)
    {
        if (value < 0)
            return;

        Cost += value;
        CostFromIteration += value;
    }

    public void StopProductOnBelt()
    {
        SpeedOnBelt = 0;
        _isStoped = true;
        _rb.Sleep();
    }
    public void MoveProductOnBelt() 
    { 
        SpeedOnBelt = 1;
        _isStoped = false;
        _rb.WakeUp();
    }
}
