using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMissileControl : MonoBehaviour
{
    // Information for base health
    public static int LeftHP = 5;
    public static int MiddleHP = 5;
    public static int RightHP = 5;
    public static Text leftHP;
    public static Text middleHP;
    public static Text rightHP;
    public Text leftHPNS;
    public Text middleHPNS;
    public Text rightHPNS;


    // Information for directions
    public Vector3 mousePosition;
    public static Vector3 objPosition;
    public int xAxis;
    public int yAxis = -4;

    // Information for shooting missiles
    public KeyCode fireMissile;
    public Transform missileObj;
    public float timeKeeper = 0f;
    public float fracDist = .01f;
    public Vector3 targetPosition;

    // Used to decide what base to shoot from
    public enum Base { Left, Middle, Right };
    public Base baseSelected;
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
        }
        else if (baseSelected == Base.Middle)
        {
            xAxis = 0;
        }
        else if (baseSelected == Base.Right)
        {
            xAxis = 6;
        }
        else
        {
            //Debug.Log("Error: BaseCoordinates");
        }
    }

    public static void SetHealthText()
    {
        leftHP.text = "Health: " + LeftHP.ToString();
        middleHP.text = "Health: " + MiddleHP.ToString();
        rightHP.text = "Health: " + RightHP.ToString();
    }

    void Start()
    {
        leftHP = leftHPNS;
        middleHP = middleHPNS;
        rightHP = rightHPNS;
        targetPosition = objPosition;
        SetHealthText();
        GetComponent<Transform>().eulerAngles = new Vector3 (xAxis, yAxis, -15);
    }

    void Update()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3f);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Decides what base to fire from, gets spawn location for player missiles
        // Spawns missile, moves it to the target location
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
