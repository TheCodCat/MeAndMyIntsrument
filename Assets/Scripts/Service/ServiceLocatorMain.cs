using UnityEngine;

public class ServiceLocatorMain : MonoBehaviour
{
	[SerializeField] private SceneService sceneService;
	[SerializeField] private HideService hideService;

	private void Awake()
	{
		ServiceLocator.Init();

		ServiceLocator.Instance.Register<SceneService>(sceneService);
		ServiceLocator.Instance.Register<HideService>(hideService);
	}

	private void OnDisable()
	{
		ServiceLocator.Instance.UnRegister<SceneService>();
		ServiceLocator.Instance.UnRegister<HideService>();
	}
}
