using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_collector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "BG" || target.tag == "Platform" ||
            target.tag == "NormalItme" || target.tag == "ExtraItme" ||
            target.tag == "Yanlis_Kutu")
        {

            target.gameObject.SetActive(false);
        }

    } // on trigger
}
