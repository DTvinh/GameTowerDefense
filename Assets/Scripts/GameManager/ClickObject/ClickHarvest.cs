using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickHarvest : ClickObject
{

    public static ClickHarvest Instance;
    // public GameObject 
    private HarvestableObject harvestableObject;
    public SpriteRenderer spriteRenderer;

    public GameObject slider;

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
    void OnEnable()
    {
        // Invoke("Hide", 5f);
    }
    protected override void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Start();
        Hide();


    }

    // Update is called once per frame
    protected override void Update()
    {
        // DetectClick();
        base.Update();
    }

    public static void Show_static(HarvestableObject harvestableObject, Sprite sprite)
    {
        Instance.Show(harvestableObject, sprite);

    }

    private void Show(HarvestableObject harvestableObject, Sprite sprite)
    {
        this.harvestableObject = harvestableObject;
        gameObject.SetActive(true);
        transform.position = new Vector2(harvestableObject.transform.position.x, harvestableObject.transform.position.y + 1.5f);
        spriteRenderer.sprite = sprite;

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }



    protected override void EventClick()
    {
        if (harvestableObject)
        {
            harvestableObject.Harvest();
            if (!harvestableObject.canHarvest)
            {
                GameObject bar = ObjectPooling.Instance.GetObject(slider);
                bar.transform.position = transform.position;
                bar.GetComponentInChildren<HarvestBar>().SetTimer(harvestableObject.timeHarvesting);
                bar.SetActive(true);

            }

        }
        gameObject.SetActive(false);


    }



}
