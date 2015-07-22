using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	NavMeshAgent navAgent;
	public Vector3 target;
	//Player player;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start ClickToMove");
		navAgent = GetComponent<NavMeshAgent> ();
		//player = Player.player;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Input.GetMouseButtonUp(0))
		{
			//Transform npcSelected = GameObject.FindWithTag("NPC").transform;
			if(Physics.Raycast(ray, out hit, 50))
			{
				//Debug.Log("Hit " + hit.transform.gameObject.name);
				//if(hit.transform.gameObject.tag == "NPC"){
					//Player.target = hit.transform;
					//player.Attack();
				//} else {
				//	Debug.Log("NOT WORKING");
				//}
				Debug.Log(hit.point);
				navAgent.SetDestination(hit.point);
				target = hit.point;
			}
			else 
			{
				Debug.Log("No hit");
			}
		}
	}


}
