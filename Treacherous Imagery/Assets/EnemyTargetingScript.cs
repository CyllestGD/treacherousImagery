using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetingScript : MonoBehaviour
{

    public enum Base { Left, Middle, Right };
    int Role = 5;
    public Base baseSelected;
    int xAxis;
    int yAxis;

    void ChoosingBase()
    {
        int role = Random.Range(0, 2);
        baseSelected = (Base)role;
    }

    void BaseCoordinates()
    {
        //if (baseSelected == Base.Left)
        //{
        //    xAxis = A;
        //    yAxis = B;
        //}
        //if (baseSelected == Base.Middle)
        //{
        //    xAxis = C;
        //    yAxis = D;
        //}
        //if (baseSelected == Base.Right)
        //{
        //    xAxis = E;
        //    yAxis = F;
        //}
        //else
        //{
        //    Debug.Log("Error: BaseCoordinates");
        //}
    }
}
