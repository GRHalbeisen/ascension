using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {

	public string name;
	public int health;
	public int damage;
	public float meleeRange;
	// Attack speed is one attack per second
	public float attackSpeed = 2f;
	public bool hasAttacked;
	public bool isAttacking;
	public Transform target;
	public float visibleDistance = 5f;
	public NavMeshAgent navAgent;

	public void GetHit(int playerDamage)
	{
		health -= playerDamage;
	}

	public bool IsWithinRange(float range)
	{
		if (Vector3.Distance (target.transform.position, transform.position) <= range) {
			return true;
		}
		return false;
	}

	public void GetWithinMeleeRange()
	{
		if (IsWithinRange (visibleDistance)) {
			navAgent.Resume ();
			navAgent.SetDestination (target.position);
		}
	}

	public void ResetAttack()
	{
		this.hasAttacked = false;
	}

	protected abstract void Attack();


}
