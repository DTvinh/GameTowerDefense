using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPawn : MonoBehaviour
{
    [SerializeField] int amountPawn;
    List<GameObject> listPawn = new List<GameObject>();
    public List<GameObject> ListPawn => listPawn;
    public static SpawnPawn Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetPawn()
    {
        if (listPawn.Count < amountPawn)
        {
            GameObject newPawn = Instantiate(GameAssets.Instance.pawn, transform);
            listPawn.Add(newPawn);
            newPawn.SetActive(false);
            return newPawn;
        }
        else
        {
            foreach (GameObject pawn in listPawn)
            {
                if (pawn.activeSelf)
                {
                    continue;
                }
                return pawn;
            }
        }
        return null;
    }


    public int GetAmount()
    {
        int count = 0;
        foreach (GameObject pawn in listPawn)
        {
            if (pawn.activeSelf)
            {
                count++;
            }
        }
        return count;
    }


}
