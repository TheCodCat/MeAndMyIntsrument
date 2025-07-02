using DG.Tweening;
using TMPro;
using UnityEngine;

public class ViewButonsActionsController : MonoBehaviour
{
    [SerializeField] private TMP_Text viewText;
    [SerializeField] private string[] viewData;
    [SerializeField] private CanvasGroup rectGroup;
    [SerializeField] private bool isView;
    private bool temp;
    public void ChangeViewButtons(string[] strings)
    {
        viewData = strings;
        temp = viewData == null ? false: true;

        if (isView == temp) return;

        viewText.text = $"{(viewData == null ? string.Empty: viewData[1])}";
        isView = temp;
        rectGroup.DOFade(isView ? 1 : 0, 0.2f).SetEase(Ease.Linear);
    }
}
