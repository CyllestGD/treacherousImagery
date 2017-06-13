using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileMovement : MonoBehaviour
{
    public float timeKeeper = 0f;
    public float fracDist = .01f;
    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = PlayerMissileControl.objPosition;
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
    }

    void Update()
    {
        timeKeeper += Time.deltaTime;

        if (timeKeeper > .04)
        {
            fracDist += .0001f;
            timeKeeper = 0f;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, fracDist);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile"))
        {
            Destroy(other.gameObject);
        }
    }
}