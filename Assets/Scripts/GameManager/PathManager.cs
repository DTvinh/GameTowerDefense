using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathManager : MonoBehaviour
{

    public Transform startpath;
    public List<Transform> listPoint;
    public List<Transform> listPointTest;

    public List<List<Transform>> allPaths;
    public static PathManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }

        listPoint = GetComponentsInChildren<Transform>().ToList();
        listPoint.RemoveAt(0);
    }


    void Start()
    {
        LoadPaths();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LoadPaths()
    {
        allPaths = new List<List<Transform>>();
        foreach (Transform path in transform)
        {
            List<Transform> waypoints = new List<Transform>();

            foreach (Transform waypoint in path)
            {
                waypoints.Add(waypoint);
            }
            allPaths.Add(waypoints);
        }




    }

}
