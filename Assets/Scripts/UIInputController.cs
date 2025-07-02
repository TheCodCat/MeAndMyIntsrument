using UnityEngine;

public class UIInputController : MonoBehaviour
{
	public void ChangeSceneName(string name)
	{
		ServiceLocator.Instance.Get<HideService>().Hide(() => ServiceLocator.Instance
		.Get<SceneService>().ChangeSceneName(name));
	}

	public void QuitGame()
	{
		ServiceLocator.Instance.Get<HideService>().Hide(() => ServiceLocator.Instance.Get<SceneService>().QuitGame());
	}
}
