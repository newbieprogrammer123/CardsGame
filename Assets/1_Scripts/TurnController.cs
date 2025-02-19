using UnityEngine;
using DG.Tweening;

public class TurnController : Singletone<TurnController>
{
    [SerializeField] private GameObject selectCardPosition;

    private Gambler player, enemy;
    private Gambler attackGambler, defendGambler;

    private bool isPlayerTurn;

    public void Init(Gambler player, Gambler enemy)
    {
        this.player = player;
        this.enemy = enemy;

        NextTurn();
    }

    private void NextTurn()
    {
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {
            attackGambler = player;
            defendGambler = enemy;

            player.NextTurn();
        }
        else
        {
            attackGambler = enemy;
            defendGambler = player;

            enemy.NextTurn();
        }
    }

    public void SelectCard(Card card)
    {
        if (isPlayerTurn)
        {
            player.EndTurn();
            player.RemoveCard(card);
        }
        else
        {
            enemy.EndTurn();
            enemy.RemoveCard(card);
        }

        Vector3 movePos = selectCardPosition.transform.position;
        movePos.z = 0;

        card.transform.DOMove(movePos, 0.3f).OnComplete(() =>
        {
            card.ShowEffect();

            if (card.GetTypeSkill == TypeSkill.Health)
            {
                attackGambler.AddHealth(card.GetValue);
            }
            else if (card.GetTypeSkill == TypeSkill.Defend)
            {
                attackGambler.UpDefend(card.GetValue);
            }
            else if (card.GetTypeSkill == TypeSkill.Attack)
            {
                defendGambler.DownHealth(card.GetValue);
            }

            DOTween.Sequence().AppendInterval(1.2f).OnComplete(() =>
            {
                card.GetComponent<CanvasGroup>().DOFade(0, 0.3f).OnComplete(() =>
                {
                    Destroy(card.gameObject);
                });

                NextTurn();
            });
        });        
    }
}
