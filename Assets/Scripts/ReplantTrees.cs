using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplantTrees : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("GetTrees", 15f);
    }


    private void GetTrees()
    {
        GameObject newTree = ObjectPooling.Instance.GetObject(GameAssets.Instance.tree);
        newTree.transform.position = transform.position;
        newTree.SetActive(true);
        gameObject.SetActive(false);
    }
}
