using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static string NumberFormat(long num)
    {
        int count = 0;
        // 上万
        if (num / 10000 > 0)
        {
            count = 1;
        }

        // 上亿
        if (num / 100000000 > 0)
        {
            count = 2;
        }

        long new_number = 0;
        string unit = "";
        if (count == 1)
        {
            new_number = num / 10000;
            unit = "万";
        }
        else if (count == 2)
        {
            new_number = num / 100000000;
            unit = "亿";
        }

        return string.Format("{0}{1}", new_number, unit);
    }
}
