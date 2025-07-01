using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class SkillsManager : MonoBehaviour
{
    private SuppostSkillsSO supportSkills;
    public SuppostSkillsSO SupportSkills => supportSkills;

    public static SkillsManager Instance;

    public LayerMask AttackLayer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (supportSkills != null)
            {

                Vector2 Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                supportSkills.supportSkills.SpawnPrefabs(Point);

                supportSkills = null;
                Observer.Notify(CONSTANT.UPDATE_SELECTED_SKILL);
                Observer.Notify(CONSTANT.START_COOLDOWN);


            }
        }
    }

    public void SetSelect(SuppostSkillsSO typeSO)
    {
        supportSkills = typeSO;

    }
    public void SetEmptySelected()
    {
        supportSkills = null;
        Observer.Notify(CONSTANT.UPDATE_SELECTED_SKILL);
    }


}
