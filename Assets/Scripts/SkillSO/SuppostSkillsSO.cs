using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SuppostSkillsSO", menuName = "SuppostSkillsSO")]
public class SuppostSkillsSO : ScriptableObject
{
    public SupportSkills supportSkills;
    public Sprite spriteUI;

    public float CooldownTime;

}
