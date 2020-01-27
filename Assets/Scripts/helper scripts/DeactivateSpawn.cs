using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSpawn : MonoBehaviour
{
    void Start()
    {
        Invoke("Deactivate", Random.Range(4f, 10f));
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
