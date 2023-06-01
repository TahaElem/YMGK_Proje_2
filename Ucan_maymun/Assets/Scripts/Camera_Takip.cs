using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Takip : MonoBehaviour
{
    private Transform hedef;

    private bool TakipPlayer;

    public float min_Y_Esik = -2.6f;

    void Awake()
    {
        hedef = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {

        if (hedef.position.y < (transform.position.y - min_Y_Esik))
        {
            TakipPlayer = false;
        }

        if (hedef.position.y > transform.position.y)
        {
            TakipPlayer = true;
        }

        if (TakipPlayer)
        {
            Vector3 temp = transform.position;
            temp.y = hedef.position.y;
            transform.position = temp;
        }

    }
}
