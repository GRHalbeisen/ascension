using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private static Transform player;
	private static Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;
	private float panningSpeed = 3.0f;
	private int screenWidth = Screen.width - 1;
	private int screenHeight = Screen.height - 1;

	/// <summary>
	/// Records the offset of the camera relative to the player.
	/// This value will be used for camera centering.
	/// </summary>
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (tag:"Player").transform;
		relCameraPos = transform.position - player.position;
	}

	/// <summary>
	/// Updates the camera position to the destination offset by the relative camera position.
	/// </summary>
	/// <param name="destination">Destination.</param>
	public void UpdateModeCameraPos(Vector3 destination)
	{
		Camera.main.transform.position = destination + relCameraPos;
	}

	/// <summary>
	/// Pan camera when moving mouse to edges of screen.
	/// values are offset by one pixel due to bug fix.
	/// (Would not pan right on full screen without offset)
	/// </summary>
	void FixedUpdate()
	{
		if(Input.mousePosition.x <= 1)
		{
			transform.Translate(new Vector3(-panningSpeed * Time.deltaTime, 0,0));
		}
		if(Input.mousePosition.x >= screenWidth)
		{
			transform.Translate(new Vector3(panningSpeed * Time.deltaTime, 0,0));
		}
		if(Input.mousePosition.y <= 1)
		{
			transform.Translate(new Vector3(0, 0, -panningSpeed * Time.deltaTime));
		}
		if(Input.mousePosition.y >= screenHeight)
		{
			transform.Translate(new Vector3(0, 0, panningSpeed * Time.deltaTime));
		}
	}
}
