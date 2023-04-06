using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductUpgrade : BaseUpgrade
{
    [Min(1)]
    [SerializeField] private float _costMultiply;

    private List<Product> _products;

    public void FillUpListWithProducts(List<Product> products)
    {
        if(products != null)
            _products = products;
    }

    protected override void UpgradeLogic()
    {
        foreach(Product product in _products)
            product.Cost *= _costMultiply;
    }
}
