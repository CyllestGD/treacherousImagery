using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileControl : MonoBehaviour
{
    public enum Base { Left, Middle, Right };
    public Base baseSelected;
    public int xAxis;
    public int yAxis;

    public float timeKeeper = 0f;
    public float fracDist = .01f;
    public Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
        targetPosition = GameManager.objPosition;
        GetComponent<Transform>().eulerAngles = new Vector3 (0, 0, -15);
    }

    // Update is called once per frame
    void Update()
    {
        timeKeeper += Time.deltaTime;

        if ( timeKeeper > .04)
        {
            fracDist += .01f;
            timeKeeper = 0f;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3 (xAxis, yAxis, 0), fracDist);
    }

    void ChoosingBase()
    {
        int role = Random.Range(0, 3);
        baseSelected = (Base)role;
    }

    void BaseCoordinates()
    {
        if (baseSelected == Base.Left)
        {
            xAxis = -6;
            yAxis = -4;
        }
        if (baseSelected == Base.Middle)
        {
            xAxis = 0;
            yAxis = -4;
        }
        if (baseSelected == Base.Right)
        {
            xAxis = 6;
            yAxis = -4;
        }
        else
        {
            Debug.Log("Error: BaseCoordinates");
        }
    }


}
