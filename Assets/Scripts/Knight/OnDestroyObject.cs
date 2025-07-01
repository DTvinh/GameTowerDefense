using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float time;
    private void OnEnable()
    {
        Invoke("DesActive", time);

    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }


    private void DesActive()
    {
        // Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
