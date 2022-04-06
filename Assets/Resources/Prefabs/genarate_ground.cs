using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genarate_ground : MonoBehaviour
{
    private GameObject heavy;

    // Start is called before the first frame update
    void Start()
    {
        heavy = GameObject.Find("HeavyTest");
    }

    void Update()
    {
        if (heavy != null)
            transform.position = new Vector3 { x = heavy.transform.position.x, y = transform.position.y };
    }
}
