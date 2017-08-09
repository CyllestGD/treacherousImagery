using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileMovement : MonoBehaviour
{
    public float timeKeeper = 0f;
    public float fracDist = .01f;
    public Vector3 targetPosition;
    public bool isHead = false;

    // Use this for initialization
    void Start()
    {
        targetPosition = EnemyMissileControl.Instance.targetPosition;
        if (isHead)
        {
            GetComponent<Transform>().eulerAngles = new Vector3(-90, 0, 0);
        }
        else
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timeKeeper += Time.deltaTime;

        //if (timeKeeper > .04)
        //{
        //    fracDist += .000001f;
        //    timeKeeper = 0f;
        //}
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, fracDist);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftBase"))
        {
            PlayerMissileControl.LeftHP -= 1;
            PlayerMissileControl.SetHealthText();
            Debug.Log("Left is hurt");
            if (PlayerMissileControl.LeftHP == 0)
            {
                EnemyMissileControl.leftActive = 0;
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("MiddleBase"))
        {
            PlayerMissileControl.MiddleHP -= 1;
            PlayerMissileControl.SetHealthText();
            Debug.Log("Middle my dude");
            if (PlayerMissileControl.MiddleHP == 0)
            {
                EnemyMissileControl.middleActive = 0;
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("RightBase"))
        {
            PlayerMissileControl.RightHP -= 1;
            PlayerMissileControl.SetHealthText();
            Debug.Log("Right's hit!");
            if (PlayerMissileControl.RightHP == 0)
            {
                EnemyMissileControl.rightActive = 0;
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}