using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gambler : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int health, defend;
    [SerializeField] private GameObject cardsHandler;
    [SerializeField] private Text healthText, defendText;
    [SerializeField] private Image iconImage;

    private List<Card> cards = new List<Card>();

    private void Start()
    {
        healthText.text = health.ToString();
        defendText.text = defend.ToString();
    }

    public void AddCard(Card newCard)
    {
        cards.Add(newCard);
        newCard.transform.SetParent(cardsHandler.transform);
    }    

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        card.transform.SetParent(transform);
    }

    public void NextTurn()
    {
        if (isPlayer)
        {
            foreach (var card in cards)
            {
                card.SetIsActive = true;
            }
        }
        else
        {
            Card rndCard = cards[Random.Range(0, cards.Count)];
            rndCard.DropCard();
        }
    }

    public void EndTurn()
    {
        if (isPlayer)
        {
            foreach (var card in cards)
            {
                card.SetIsActive = false;
            }
        }
    }

    public void AddHealth(int value)
    {
        health += value;
        healthText.text = health.ToString();
        healthText.transform.DOScale(1.3f, 0.3f).OnComplete(() =>
        {
            healthText.transform.DOScale(1f, 0.2f);
        });
    }

    public void DownHealth(int damage)
    {
        if(defend >= damage)
        {
            DownDefend(damage);
        }
        else
        {
            damage -= defend;
            health -= damage;
            healthText.text = health.ToString();
            healthText.transform.DOScale(1.3f, 0.3f).OnComplete(() =>
            {
                healthText.transform.DOScale(1f, 0.2f);
            });

            if (health < 0)
            {
                Debug.Log("Death " + gameObject.name);
            }
        }       
    }

    public void UpDefend(int value)
    {
        defend += value;
        defendText.text = defend.ToString();
        defendText.transform.DOScale(1.3f, 0.3f).OnComplete(() =>
        {
            defendText.transform.DOScale(1f, 0.2f);
        });
    }

    public void DownDefend(int value)
    {
        defend -= value;
        defendText.text = defend.ToString();
        defendText.transform.DOScale(1.3f, 0.3f).OnComplete(() =>
        {
            defendText.transform.DOScale(1f, 0.2f);
        });
    }
}
