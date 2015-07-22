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
		if (Vector3.Distance (other.GetComponent<Player> ().destination, transform.position) > 10) {
			other.GetComponent<NavMeshAgent> ().SetDestination (other.GetComponent<Player> ().destination);
		}
//		Camera.main.transform = dest;

		cm.UpdateModeCameraPos (destination.position);
	}
}
