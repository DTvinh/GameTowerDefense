using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPooling : MonoBehaviour
{

    public static Dictionary<GameObject, List<GameObject>> listObject;

    public static ObjectPooling Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        listObject = new Dictionary<GameObject, List<GameObject>>();
    }

    private void OnEnable()
    {

    }

    public GameObject GetObject(GameObject prefab)
    {
        if (listObject.ContainsKey(prefab))
        {
            foreach (GameObject obj in listObject[prefab])
            {
                if (obj.activeSelf)
                {
                    continue;
                }
                // Debug.Log(obj.name);
                return obj;
            }
            GameObject GameObj = Instantiate(prefab, transform);
            GameObj.SetActive(false);
            listObject[prefab].Add(GameObj);
            return GameObj;
        }

        List<GameObject> newList = new List<GameObject>();
        GameObject newGameObj = Instantiate(prefab, transform);
        newGameObj.SetActive(false);
        newList.Add(newGameObj);
        listObject.Add(prefab, newList);

        return newGameObj;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        listObject.Clear();
    }




    // public GameObject getObject(GameObject prefab)
    // {
    //     foreach (GameObject obj in listGame)
    //     {
    //         if (obj.activeSelf)
    //         {
    //             continue;
    //         }
    //         Debug.Log("return");
    //         return obj;
    //     }
    //     GameObject newGameObj = Instantiate(prefab, transform);
    //     listGame.Add(newGameObj);
    //     newGameObj.SetActive(false);
    //     return newGameObj;
    // }
}
