using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductUpgrade : BaseUpgrade
{
    private List<Product> _products;

    public void FillUpListWithProducts(List<Product> products)
    {
        if(products != null)
            _products = products;
    }

    protected override void UpgradeLogic()
    {
        print("from PU");
    }
}
