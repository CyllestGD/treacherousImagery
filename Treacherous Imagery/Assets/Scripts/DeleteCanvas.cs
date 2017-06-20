using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCanvas : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}