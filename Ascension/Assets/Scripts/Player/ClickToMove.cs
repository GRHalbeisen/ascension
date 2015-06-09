using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start ClickToMove");
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Input.GetMouseButtonUp(0))
		{
			if(Physics.Raycast(ray, out hit, 100))
			{
				Debug.Log(hit.point);
				navAgent.SetDestination(hit.point);
			}
			else 
			{

			}
		}
	}


}
