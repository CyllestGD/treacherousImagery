using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 mousePosition;
    public static Vector2 objPosition;
    public static Vector2 targetPosition;

    public KeyCode fireMissile;

    public Transform missileObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKeyDown(fireMissile))
        {
            Instantiate(missileObj, new Vector3(0, 0), missileObj.rotation);
        }
    }
}
