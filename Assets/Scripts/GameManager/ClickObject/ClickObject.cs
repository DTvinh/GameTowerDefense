using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    protected Camera currentCamera;
    [SerializeField] protected LayerMask clickableLayer;


    protected virtual void Start()
    {
        currentCamera = Camera.main;
    }

    protected virtual void Update()
    {
        DetectClick();
    }

    protected void DetectClick()
    {
        if (Input.GetMouseButtonDown(0) && currentCamera != null)
        {
            // Vector2 mousePos = currentCamera.ScreenToWorldPoint(Input.mousePosition);
            // RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, clickableLayer);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                EventClick();
            }
        }
    }

    protected virtual void EventClick()
    {
        Debug.Log("Clicked: " + gameObject.name);
    }


}
