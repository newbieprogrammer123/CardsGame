using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EffectCard : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite healthSprite, defendSprite, damageSprite;

    public void Show(TypeSkill typeSkill)
    {
        Sprite currentSprite = healthSprite;

        if(typeSkill == TypeSkill.Defend)
        {
            currentSprite = defendSprite;
        }
        else if (typeSkill == TypeSkill.Attack)
        {
            currentSprite = damageSprite;
        }


        Vector2 rndPos;
        foreach (var image in images)
        {
            image.sprite = currentSprite;
            image.gameObject.SetActive(true);

            rndPos = new Vector2(Random.Range(-100, 100), Random.Range(-70, 70));

            image.DOFade(1, 0.15f);
            image.transform.DOLocalMove(rndPos, 0.5f).OnComplete(() =>
            {
                image.DOFade(0, 0.3f).OnComplete(() =>
                {
                    image.transform.localPosition = new Vector3(0, 0, 0);
                    image.gameObject.SetActive(false);
                });
            });
        }
    }
}
