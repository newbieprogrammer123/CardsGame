using UnityEngine;

[CreateAssetMenu(fileName = "DataCard", menuName = "Data/DataCard")]
public class DataCard : ScriptableObject
{
    public TypeSkill TypeSkill;
    public int Value;
    public string Description;
    public Sprite Sprite;
}

public enum TypeSkill
{
    Health,
    Attack,
    Defend
}
