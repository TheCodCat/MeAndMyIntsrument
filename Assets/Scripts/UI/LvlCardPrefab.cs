using Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LvlCardPrefab : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text title;
    [SerializeField] private string sceneAsset;

    public void Init(Card card)
    {
        icon.sprite = card.Icon;
        description.text = card.Description;
        title.text = card.NameCard;
        sceneAsset = card.NameScene;
    }

    public void LoadSceneCard()
    {
        ServiceLocator.Instance.Get<HideService>().Hide(() => 
        ServiceLocator.Instance.Get<SceneService>().ChangeSceneName(sceneAsset));
    }
}
