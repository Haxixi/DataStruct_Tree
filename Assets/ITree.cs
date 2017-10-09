using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TraverseType
{
    PreOrder,//先序遍历
    PostOrder,//后序遍历
    BroadOrder//层序遍历
}

public interface ITree<T>
{

    T Root();

    T Parent(T t);

    T Child(T t, int i);

    T RightSibling(T t);

    bool Insert(T s, T t, int i);

    T Delete(T t, int i);

    void Tranverse(TraverseType type);

    void Clear();

    bool isEmpty();

    int GetDepth(T t);

}
