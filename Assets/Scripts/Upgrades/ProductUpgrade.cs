using System.Collections.Generic;
using UnityEngine;

public class ProductUpgrade : BaseUpgrade
{
    [Min(1)]
    [SerializeField] private float _productCostMultiply;

    private List<Product> _products;

    private void Start()
    {
        Init();
        //_productCostMultiply = _upgradeStats.SpecificMyltiply;
    }

    public void FillProductList(List<Product> products)
    {
        if(products != null)
            _products = products;
    }

    protected override void UpgradeLogic()
    {
        foreach (Product product in _products)
            product.ChangeProductCost(Mathf.CeilToInt(product.Cost * _productCostMultiply));

        _upgradeStats.SpecificMyltiply = _productCostMultiply; 
    }
}
