using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileCreation : MonoBehaviour {
    public Rigidbody PlayerMissile;

	void Update () {
        Instantiate(PlayerMissile, transform.position, transform.rotation);
	}
}
