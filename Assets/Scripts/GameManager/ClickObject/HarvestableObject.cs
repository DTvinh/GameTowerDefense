using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableObject : MonoBehaviour
{



    public float timeHarvesting;
    public bool canHarvest = true;
    public Sprite sprite;

    public virtual void Harvest()
    {
        // Destroy(gameObject);
        if (canHarvest)
        {
            StartCoroutine(Harvesting());

        }
    }
    IEnumerator Harvesting()
    {
        GameObject pawnObj = SpawnPawn.Instance.GetPawn();
        if (pawnObj != null)
        {
            canHarvest = false;
            pawnObj.transform.position = transform.position - new Vector3(0.8f, 0, 0);
            // pawnObj.transform.SetParent(transform);
            pawnObj.SetActive(true);
            yield return new WaitForSeconds(timeHarvesting);
            canHarvest = true;
            DropResource();
            pawnObj.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {


        }

    }

    protected virtual void DropResource()
    {

    }

    // protected void OnMouseEnter()
    // {
    //     ClickHarvest.Show_static(this);
    // }

    public void OnMouseEnter()
    {
        if (canHarvest)
        {
            ClickHarvest.Show_static(this, sprite);

        }
        // Debug.Log("thương nnnn");
    }

    // protected void OnMouseExit()
    // {
    //     ClickHarvest.Instance.Hide();
    // }
}
