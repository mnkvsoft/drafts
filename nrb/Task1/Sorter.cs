using System;
using System.Collections.Generic;

namespace Task1;

static class Sorter
{
    // т.к. не было указано ограничений по памяти, то считаю, что они есть
    // и использую самую простую (и ту, которую помню), не эффективную по времени, но эффективную по памяти
    // сортировку пузырьком
    public static void Sort<T>(IList<T> values) where T: IComparable<T>
    {
        if(values.Count < 2)
            return;
        
        for (int i = 0; i + 1 < values.Count; ++i) 
        {
            for (int j = 0; j + 1 < values.Count - i; ++j) 
            {
                if (values[j + 1].CompareTo(values[j]) < 0)
                {
                    (values[j], values[j + 1]) = (values[j + 1], values[j]);
                }
            }
        }
    }
}