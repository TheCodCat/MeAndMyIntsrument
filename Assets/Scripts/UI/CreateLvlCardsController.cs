using UnityEngine;

public class CreateLvlCardsController : MonoBehaviour
{
    [SerializeField] private LvlCardPrefab prefab;
    [SerializeField] private RectTransform content;
    [SerializeField] private LvlContentCard card;

    private void Start()
    {
        foreach (var item in card.Cards)
        {
            var card = Instantiate(prefab, content).GetComponent<LvlCardPrefab>();
            card.Init(item);
        }
    }
}
