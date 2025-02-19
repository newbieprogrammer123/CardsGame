using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Text descriptionText, valueCardText;
    [SerializeField] private Image skillImage;
    [SerializeField] private EffectCard effect;

    private TypeSkill skillType;
    private int valueCard;
    private bool isActive;

    public TypeSkill GetTypeSkill
    {
        get { return skillType; }
    }

    public int GetValue
    {
        get { return valueCard; }
    }

    public bool SetIsActive
    {
        set
        {
            isActive = value;
        }
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (isActive)
            {
                DropCard();
            }
        });
    }

    public void DropCard()
    {
        TurnController.Instance.SelectCard(this);
    }

    public void ShowEffect()
    {
        effect.Show(skillType);
    }

    public void Init(DataCard data)
    {
        skillType = data.TypeSkill;
        valueCard = data.Value;
        descriptionText.text = data.Description;
        valueCardText.text = data.Value.ToString();
        skillImage.sprite = data.Sprite;
    }
}
