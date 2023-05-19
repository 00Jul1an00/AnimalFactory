using UnityEngine;
using System;

public static class NumsFormatHelper
{
    private static string[] postfixs = new[]
    {
        "",
        "K",
        "M",
        "B",
        "T"
    };

    public static string FormatNum(double num)
    {
        if (num == 0) 
            return "0";

        num = Mathf.Round((float)num);

        int i = 0;

        while (i + 1 < postfixs.Length && num >= 1000)
        {
            num /= 1000;
            i++;
        }

        return num.ToString(format: "#,##") + postfixs[i];
    }

    public static string FormatNum(float num)
    {
        if (num == 0)
            return "0";

        num = Mathf.Round(num);

        int i = 0;

        while (i + 1 < postfixs.Length && num >= 1000)
        {
            num /= 1000;
            i++;
        }

        return num.ToString(format: "#,##") + postfixs[i];
    }

    public static string FormatNum(decimal num)
    {
        if (num == 0)
            return "0";

        num = Decimal.Round(num);

        int i = 0;

        while (i + 1 < postfixs.Length && num >= 1000)
        {
            num /= 1000;
            i++;
        }

        return num.ToString(format: "#,##") + postfixs[i];
    }
    
    public static string FormatNum(int num)
    {
        if (num == 0)
            return "0";

        int i = 0;

        while (i + 1 < postfixs.Length && num >= 1000)
        {
            num /= 1000;
            i++;
        }

        return num.ToString(format: "#,##") + postfixs[i];
    }
}
