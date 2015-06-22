using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private static Transform player;
	private static Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (tag:"Player").transform;
		relCameraPos = transform.position - player.position;
	}

	public void UpdateModeCameraPos(Vector3 destination)
	{
		//transform.position = player.position + relCameraPos;
		Camera.main.transform.position = destination + relCameraPos;
	}
}
