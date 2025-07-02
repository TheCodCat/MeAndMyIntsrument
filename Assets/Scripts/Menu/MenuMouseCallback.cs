using UnityEngine;
using UnityEngine.InputSystem;

public class MenuMouseCallback : MonoBehaviour
{
	private Vector2 screenParams;
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 startPosition;
	[SerializeField] private float maxAngle;
	[SerializeField] private Vector2 floatAngle;

	private void Start()
	{
		screenParams.x = Screen.width;
		screenParams.y = Screen.height;
		startPosition = target.position;
	}

	/// <summary>
	/// поворот камеры за мышью в зависимости от положения курсора
	/// </summary>
	/// <param name="callbackContext"></param>
	public void MouseCallback(InputAction.CallbackContext callbackContext)
	{
		Debug.Log($"{(callbackContext.ReadValue<Vector2>().x / screenParams.x).ToString("F2")}/{(callbackContext.ReadValue<Vector2>().y / screenParams.y).ToString("F2")}");
		
		floatAngle.x = ((callbackContext.ReadValue<Vector2>().x - screenParams.x / 2) / screenParams.x) * maxAngle;
		floatAngle.y = ((callbackContext.ReadValue<Vector2>().y - screenParams.y / 2) / screenParams.y) * maxAngle;
		
		if(target != null)
			target.SetPositionAndRotation(new Vector3( startPosition.x + floatAngle.x,startPosition.y + floatAngle.y, startPosition.z), Quaternion.identity);
		//target.rotation = Quaternion.Euler( 0, yAngle, xAngle);
	}
}
