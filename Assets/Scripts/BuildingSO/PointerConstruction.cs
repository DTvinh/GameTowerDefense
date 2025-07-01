using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerConstruction : MonoBehaviour
{

    SpriteRenderer image;
    BoxCollider2D Collider2D;
    public bool canBuilding;


    void Start()
    {
        image = this.transform.Find("image").GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }
    private void ChangeColor()
    {
        Collider2D isAreaClear = Physics2D.OverlapBox(this.transform.position, Collider2D.bounds.size, 0, BuildingManager.Instance.layerMask);
        if (isAreaClear != null)
        {
            image.color = new Color(255f / 255f, 151f / 255f, 148f / 255f, 76f / 255f);
            // image.color = Color.red;
            Debug.Log("không xây được ");
            canBuilding = false;
        }
        else
        {
            image.color = new Color(148f / 255f, 198 / 255f, 255 / 255f, 76 / 255f);

            Debug.Log("xây được");
            canBuilding = true;
        }
    }






}


