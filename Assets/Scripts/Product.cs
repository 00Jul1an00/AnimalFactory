using UnityEngine;
using System;

public class Product : MonoBehaviour
{
    [SerializeField] private float _maxDistance;    
    [HideInInspector] public Product PreviusProductOnBelt;
    [HideInInspector] public Product NextProductOnBelt;

    public float SpeedOnBelt { get; private set; }

    private bool _isStoped = false;
    private Rigidbody2D _rb;

    private void Start()
    {
        SpeedOnBelt = 1;
        _rb = GetComponent<Rigidbody2D>();
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
        if (PreviusProductOnBelt == null)
            return false;

        float Distance = Vector2.Distance(transform.position, PreviusProductOnBelt.transform.position);
        return Distance <= _maxDistance;
    }

    public void StopProductOnBelt()
    {
        SpeedOnBelt = 0;
        _isStoped = true;
    }
    public void MoveProductOnBelt() 
    { 
        SpeedOnBelt = 1;
        _isStoped = false;
        _rb.WakeUp();
    }
}
