using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform GetNextNode(Transform currentNode)
    {
        if (currentNode == null)
            return transform.GetChild(0);
        else if (currentNode.GetSiblingIndex() < transform.childCount - 1)
            return transform.GetChild(currentNode.GetSiblingIndex() + 1);
        else
            return transform.GetChild(0);
    }
}