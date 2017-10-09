using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTree : MonoBehaviour
{
    private MLTree<string> tr = new MLTree<string>();
    // Use this for initialization
    void Start()
    {
        MLNode<string> a1 = new MLNode<string>(3);

        a1.Data = "A";

        MLNode<string> a2 = new MLNode<string>(3);

        a2.Data = "B";

        MLNode<string> a3 = new MLNode<string>(3);

        a3.Data = "D";

        MLNode<string> a4 = new MLNode<string>(3);

        a4.Data = "C";

        MLNode<string> a5 = new MLNode<string>(3);

        a5.Data = "E";

        MLNode<string> a6 = new MLNode<string>(3);

        a6.Data = "F";

        MLNode<string> a7 = new MLNode<string>(3);

        a7.Data = "G";

        tr.Insert(a2, a1, 0);

        tr.Insert(a3, a1, 1);

        tr.Insert(a4, a2, 0);

        tr.Insert(a5, a2, 1);

        tr.Insert(a6, a3, 0);

        tr.Insert(a7, a6, 0);

        tr.Tranverse(TraverseType.PostOrder);

        Debug.Log(tr.GetDepth(a1));
    }
}
