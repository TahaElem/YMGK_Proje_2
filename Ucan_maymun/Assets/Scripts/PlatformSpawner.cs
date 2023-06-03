using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject left_Platform, right_Platform;

    private float sag_X_Min = -4.26f, sag_X_Max = -2.89f, sol_X_Min = 4.26f, sol_X_Max = 2.78f;//platformun  x spawn koordinatlarý
    private float y_Treshold = 2.6f;//platformun  y spawn koordinatlarý
    private float last_Y;

    public int spawn_Count = 16;
    private int platform_Spawned;

    [SerializeField]
    private Transform platform_Parent;

    // more variables to spawn bird enemy
    [SerializeField]
    private GameObject bird;
    public float bird_Y = 5f;
    private float bird_X_Min = -2.3f, bird_X_Max = 2.3f;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        last_Y = transform.position.y;

        SpawnPlatforms();

    }

    public void SpawnPlatforms()
    {

        Vector2 temp = Vector2.zero;
        GameObject newPlatform = null;

        for (int i = 0; i <spawn_Count; i++)
        {

            temp.y = last_Y;

            // we have even number
            if ((platform_Spawned % 2) == 0)
            {

                temp.x = Random.Range(sag_X_Min, sag_X_Max);//sað spawn aralýklarý rastgele

                newPlatform = Instantiate(right_Platform, temp, Quaternion.identity);

            }
            else
            {
                // if we have odd number

                temp.x = Random.Range(sol_X_Min, sol_X_Max);// sol spawn aralýklarý rastgele 

                newPlatform = Instantiate(left_Platform, temp, Quaternion.identity);

            }

            newPlatform.transform.parent = platform_Parent;

            last_Y += y_Treshold;
            platform_Spawned++;

        }

        if (Random.Range(0, 2) > 0)
        {
            SpawnBird();
        }

    } // spawn platforms

    void SpawnBird()
    {

        Vector2 temp = transform.position;
        temp.x = Random.Range(bird_X_Min, bird_X_Max);
        temp.y += bird_Y;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platform_Parent;

    }
}
