using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectUi : MonoBehaviour
{
    [SerializeField] Transform BtnTemplate;
    [SerializeField] List<SuppostSkillsSO> listSkillSO;
    SuppostSkillsSO skillSelected;
    Dictionary<SuppostSkillsSO, Transform> dictionarySkill;

    public Transform btnCloseSelected;

    private void Awake()
    {
        dictionarySkill = new Dictionary<SuppostSkillsSO, Transform>();
        foreach (SuppostSkillsSO typeSO in listSkillSO)
        {
            Transform Btn = Instantiate(BtnTemplate, this.transform);
            Btn.Find("Image").GetComponent<Image>().sprite = typeSO.spriteUI;
            dictionarySkill.Add(typeSO, Btn);

            Btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                HendleSelectBuilding(typeSO);
            });
        }
    }
    void Start()
    {

        Observer.AddListener(CONSTANT.START_COOLDOWN, StartCooldown);
        Observer.AddListener(CONSTANT.UPDATE_SELECTED_SKILL, UpdateSelectedSkillvisual);

    }
    private void HendleSelectBuilding(SuppostSkillsSO skillTypeSO)
    {
        if (CanUseSkillItem(skillTypeSO))
        {
            SkillsManager.Instance.SetSelect(skillTypeSO);
            skillSelected = skillTypeSO;
            Observer.Notify(CONSTANT.UPDATE_SELECTED_SKILL);
            btnCloseSelected.position = new Vector2(dictionarySkill[skillTypeSO].transform.position.x, btnCloseSelected.position.y);
            btnCloseSelected.gameObject.SetActive(true);

        }

    }

    private bool CanUseSkillItem(SuppostSkillsSO skillTypeSO)
    {
        bool isCooldown = dictionarySkill[skillTypeSO].GetComponent<Cooldown>().IsCooldown;

        return !isCooldown;
    }
    public void StartCooldown(object[] datas)
    {
        if (skillSelected != null)
        {
            dictionarySkill[skillSelected].GetComponent<Cooldown>().SetCooldown(skillSelected.CooldownTime);

        }
    }

    private void UpdateSelectedSkillvisual(object[] datas)
    {
        foreach (SuppostSkillsSO type in dictionarySkill.Keys)
        {
            dictionarySkill[type].Find("Selected").gameObject.SetActive(false);
            btnCloseSelected.gameObject.SetActive(false);

        }

        SuppostSkillsSO buildingSO = SkillsManager.Instance.SupportSkills;
        if (buildingSO != null)
        {
            dictionarySkill[buildingSO].Find("Selected").gameObject.SetActive(true);
        }

    }
}
