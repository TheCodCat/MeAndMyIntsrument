using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour, IService
{
	/// <summary>
	/// запуск асинхронной загрузки сцены
	/// </summary>
	/// <param name="name"></param>
	public void ChangeSceneName(string name)
	{
		StartCoroutine(Loader(name));
	}

	/// <summary>
	/// асинхронная заргузка сцены
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	private IEnumerator Loader(string name)
	{
		var load = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

		yield return new WaitUntil(() => load.isDone);
	}

	public void QuitGame() => Application.Quit();
}
