using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public Transform destination;
	public CameraMovement cm;

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Player entered trigger.");
		Vector3 dest = new Vector3 (destination.position.x, destination.position.y, destination.position.z);
		//other.gameObject.transform.position = dest;
		other.GetComponent<NavMeshAgent> ().Warp (dest);
//		Camera.main.transform = dest;

		cm.UpdateModeCameraPos (destination.position);
	}
}
