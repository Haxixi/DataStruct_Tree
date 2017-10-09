using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MLTree<T> : ITree<MLNode<T>>
{

    private int depth = 1;
    private int maxDepth;

    private MLNode<T> head;

    public MLNode<T> Head
    {
        get { return head; }
        set { head = value; }
    }

    public MLTree()
    {
        head = null;
    }

    public MLTree(MLNode<T> node)
    {
        head = node;
    }

    public MLNode<T> Child(MLNode<T> t, int i)
    {
        if (t != null && i < t.Childs.Length)
        {
            return t.Childs[i];
        }
        else
        {
            return null;
        }
    }

    public void Clear()
    {
        head = null;
    }

    public MLNode<T> Delete(MLNode<T> t, int i)
    {
        t = FindNode(t);
        MLNode<T> node = null;
        if (t != null && t.Childs.Length > i)
        {
            node = t.Childs[i];
            t.Childs[i] = null;
        }

        return node;
    }

    public int GetDepth(MLNode<T> root)
    {

        if (root == null)
            return 0;

        for (int i = 0; i < root.Childs.Length; i++)
        {

            if (root.Childs[i] != null)
            {
                depth++;
                GetDepth(root.Childs[i]);
            }
            else
            {
                if (maxDepth < depth)
                    maxDepth = depth;

                depth = 1;
            }
        }

        return maxDepth;
    }

    public bool Insert(MLNode<T> s, MLNode<T> t, int i)
    {
        if (isEmpty())
            head = t;
        t = FindNode(t);

        if (t != null && t.Childs.Length > i)
        {
            t.Childs[i] = s;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isEmpty()
    {
        return head == null;
    }

    public MLNode<T> Parent(MLNode<T> t)
    {
        MLNode<T> tmp = head;
        if (isEmpty() || t == null)
            return null;
        if (tmp.Data.Equals(t.Data))
            return null;

        Queue que = new Queue();
        que.Enqueue(tmp);
        while (que.Count > 0)
        {
            tmp = (MLNode<T>)que.Dequeue();
            for (int i = 0; i < tmp.Childs.Length; i++)
            {
                if (tmp.Childs[i] != null)
                {
                    if (tmp.Childs[i].Data.Equals(t.Data))
                    {
                        return tmp;
                    }
                    else
                    {
                        que.Enqueue(tmp.Childs[i]);
                    }
                }

            }
        }

        return null;
    }

    public MLNode<T> RightSibling(MLNode<T> t)
    {
        MLNode<T> pn = Parent(t);

        if (pn != null)
        {
            int i = FindRank(t);
            return Child(pn, i + 1);
        }
        else
        {
            return null;
        }
    }

    public MLNode<T> Root()
    {
        return head;
    }

    public void Tranverse(TraverseType type)
    {
        switch (type)
        {
            case TraverseType.BroadOrder:
                BroadOrder(head);
                break;
            case TraverseType.PreOrder:
                PreOrder(head);
                break;
            case TraverseType.PostOrder:
                PostOrder(head);
                break;
        }
    }

    private void PreOrder(MLNode<T> root)
    {
        if (root == null)
            return;

        Debug.Log(root.Data + "前序");
        for (int i = 0; i < root.Childs.Length; i++)
        {
            PreOrder(root.Childs[i]);
        }
    }

    private void PostOrder(MLNode<T> root)
    {
        if (root == null)
            return;

        for (int i = 0; i < root.Childs.Length; i++)
        {
            PostOrder(root.Childs[i]);
        }
        Debug.Log(root.Data + "后序");

    }

    private void BroadOrder(MLNode<T> root)
    {
        if (root == null)
            return;

        MLNode<T> tmp = root;

        Queue que = new Queue();
        que.Enqueue(tmp);
        while (que.Count > 0)
        {
            tmp = (MLNode<T>)que.Dequeue();

            Debug.Log(tmp.Data + "层序");

            for (int i = 0; i < tmp.Childs.Length; i++)
            {
                if (tmp.Childs[i] != null)
                {
                    que.Enqueue(tmp.Childs[i]);
                }
            }
        }
    }

    private int FindRank(MLNode<T> t)
    {
        MLNode<T> pn = Parent(t);

        for (int i = 0; i < pn.Childs.Length; i++)
        {
            MLNode<T> tmp = pn.Childs[i];

            if (tmp != null && tmp.Data.Equals(t.Data))
            {
                return i;
            }
        }

        return -1;
    }

    private MLNode<T> FindNode(MLNode<T> t)
    {
        if (head.Data.Equals(t.Data))
            return head;

        MLNode<T> pn = Parent(t);
        foreach (var tmp in pn.Childs)
        {
            if (tmp != null && tmp.Data.Equals(t.Data))
            {
                return tmp;
            }
        }

        return null;
    }

}
