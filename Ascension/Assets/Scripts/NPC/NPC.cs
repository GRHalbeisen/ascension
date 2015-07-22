using UnityEngine;
using System.Collections;

public class NPC : Creature {

	// Use this for initialization
	void Start () {
		this.target = Player.player.transform;
		navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
	}

//	void OnMouseOver()
//	{
//		Player.target = transform;
//	}

	protected override void Attack()
	{
		if (this.IsWithinRange(meleeRange))
		{
			transform.LookAt(target.position);
			this.navAgent.Stop();
			if (!this.hasAttacked) {
				Debug.Log (gameObject.name + " is ATTACKING " + this.target.name);
				this.target.gameObject.GetComponent<Player> ().GetHit (damage);
				this.hasAttacked = true;
				Invoke ("ResetAttack", this.attackSpeed);
			}
		} else {
			this.GetWithinMeleeRange();
		}
	}






}
