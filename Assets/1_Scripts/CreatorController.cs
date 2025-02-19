using System.Collections.Generic;
using UnityEngine;

public class CreatorController : MonoBehaviour
{
    [SerializeField] private Gambler player, enemy;

    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Card cardPrefab;
    [SerializeField] private DataCard[] dataCards;

    private List<Card> allCards = new List<Card>();

    private void Start()
    {
        for (int i = 0; i < dataCards.Length; i++)
        {
            Card newCard = Instantiate(cardPrefab, spawnObject.transform);
            newCard.Init(dataCards[i]);
            allCards.Add(newCard);
        }

        for (int i = 0; i < dataCards.Length; i++)
        {
            Card newCard = Instantiate(cardPrefab, spawnObject.transform);
            newCard.Init(dataCards[i]);
            allCards.Add(newCard);
        }

        int countCards = allCards.Count / 2;

        for (int i = 0; i < countCards; i++)
        {
            player.AddCard(GetRandomCard());
        }

        countCards = allCards.Count;

        for (int i = 0; i < countCards; i++)
        {
            enemy.AddCard(GetRandomCard());
        }

        TurnController.Instance.Init(player, enemy);
    }

    private Card GetRandomCard()
    {
        Card rndCard = allCards[Random.Range(0, allCards.Count)];
        allCards.Remove(rndCard);
        return rndCard;
    }
}
