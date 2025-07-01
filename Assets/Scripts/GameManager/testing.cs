using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam;
    [SerializeField] GameObject aaaa;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // dragOrigin=this.transform.position;
            // dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(dragOrigin);
            GameObject obj = ObjectPooling.Instance.GetObject(aaaa);
            obj.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
            // obj.GetComponent<DamagePupop>().setUp(100);
            obj.SetActive(true);

        }


    }


}
