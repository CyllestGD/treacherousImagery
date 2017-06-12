using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    public enum Base { Left, Middle, Right };
    public Base baseSelected;
    public int xAxis;
    public int yAxis;

    public Vector3 mousePosition;
    public static Vector3 objPosition;

    public KeyCode fireMissile;

    public Transform missileObj;

    public float timeKeeper = 0f;
    public float fracDist = .01f;
    public Vector3 targetPosition;

    public GameObject[] bases;

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
    // Use this for initialization
    void Start()
    {
        targetPosition = objPosition;
        GetComponent<Transform>().eulerAngles = new Vector3 (xAxis, yAxis, -15);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKeyDown(fireMissile))
        {
            ChoosingBase();
            BaseCoordinates();
            Instantiate(missileObj, new Vector3(xAxis, yAxis, 0), missileObj.rotation);
            transform.position = Vector3.Lerp(transform.position, targetPosition, fracDist);
        }

        timeKeeper += Time.deltaTime;

        if ( timeKeeper > .04)
        {
            fracDist += .01f;
            timeKeeper = 0f;
        }
    }

    GameObject GetClosestBase()
    {
        GameObject bestBase = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (GameObject potentialTarget in bases)
        {
            // needs to be against mouse pos
            Vector3 directionToTarget = potentialTarget.transform.position - mousePosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestBase = potentialTarget;
            }
        }

        return bestBase;
    }
}
