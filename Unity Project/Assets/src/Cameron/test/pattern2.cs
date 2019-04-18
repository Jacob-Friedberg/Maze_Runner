using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract class Iterator
{
    // list of values to iterate over
    public int[] numbers = new int[5] {1,2,3,4,5};

    public abstract object first();
    public abstract object next();
}

class requirement : Iterator
{
    private int current = 0;

    public override object first()
    {
        return numbers[0];
    }

    public override object next()
    {
        object ret = null;
        if(current < 5)
        {
            ret = numbers[++current];
        }
        return ret;
    }
}
