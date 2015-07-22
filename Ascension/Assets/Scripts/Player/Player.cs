using UnityEngine;
using System.Collections;

public class Player : Creature {

	public static Player player;
	public Vector3 destination;

	//public static Transform target;
	
	void Awake()
	{
		player = this;
	}

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			ClickToMove();
		}
		if (isAttacking) {
			Attack ();
		}
	}

	protected override void Attack ()
	{
		if (this.IsWithinRange(meleeRange))
		{
			transform.LookAt(target.position);
			//var newRot = Quaternion.LookRotation(target.position);
			//transform.rotation = Quaternion.Lerp(transform.rotation, newRot, 1f);
			this.navAgent.Stop();
			if (!this.hasAttacked) {
				Debug.Log (gameObject.name + " is ATTACKING " + target.name);
				target.GetComponent<NPC>().GetHit(damage);
				this.hasAttacked = true;
				Invoke ("ResetAttack", this.attackSpeed);
			}
		} else {
			this.GetWithinMeleeRange();
		}
//		if (Input.GetKeyUp (KeyCode.Space)) {
//			if (target != null && IsWithinRange(meleeRange))
//			{
//				Debug.Log ("Player attack " + target.gameObject.name);
//				target.GetComponent<NPC>().GetHit(damage);
//			}
//		}
	}

	private void ClickToMove()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Transform npcSelected = GameObject.FindWithTag("NPC").transform;
		if(Physics.Raycast(ray, out hit, 50))
		{
			Debug.Log("Hit " + hit.transform.gameObject.name);
			Debug.Log(hit.point);
			if(hit.transform.gameObject.tag == "NPC"){
				Debug.Log("Target: " + hit.transform.gameObject.name);
				isAttacking = true;
				target = hit.transform;
				destination = target.position;
				navAgent.SetDestination(hit.transform.position);
				navAgent.Resume();
			} else {
				Debug.Log("No Target");
				isAttacking = false;
				//target = hit.transform;
				destination = hit.point;
				navAgent.SetDestination(destination);
				navAgent.Resume();
			}


			//navAgent.SetDestination(hit.point);
			//navAgent.SetDestination(hit.transform.position);
			//navAgent.Resume();
			//target = hit.point;
			//target = hit.transform;


		}
		else 
		{
			Debug.Log("No hit");
		}
	}
}
