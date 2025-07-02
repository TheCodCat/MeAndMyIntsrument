using UnityEngine;

public class ViewButonsActionsController : MonoBehaviour
{
    public void ChangeViewButtons(string[] strings)
    {
        if (strings == null)
        {
            Debug.Log(strings);
            return;
        }
        foreach (var item in strings)
        {
            Debug.Log(item);
        }
    }
}
