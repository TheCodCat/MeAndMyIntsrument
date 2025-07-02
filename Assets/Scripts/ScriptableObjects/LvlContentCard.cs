using Assets.Scripts.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class LvlContentCard : ScriptableObject
{
    [Header("Карты")]
    public Card[] Cards;
}
