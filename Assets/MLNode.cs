using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLNode<T>
{

    private T data;

    private MLNode<T>[] childs;

    public MLNode(int max)
    {
        childs = new MLNode<T>[max];

        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = null;
        }
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public MLNode<T>[] Childs
    {
        get { return childs; }
        set { childs = value; }
    }
}
