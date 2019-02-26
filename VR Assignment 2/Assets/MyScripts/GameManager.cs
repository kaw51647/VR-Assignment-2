using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float missileSpeed;
    public float missileSpawnPeriod_sec;
    public float missileSpawnRadius;
    public Transform missileSpawnOrigin;
    public Missile missilePrefab;
    public Transform target;
    public bool missileSpawnerActive;
    public int level;
    public int missileCount;
    private int x = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(missileSpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator missileSpawner()
    {

        while (true)
        {
            if (x == missileCount)
            {
                level++;
                missileSpeed++;
            }

            if (missileSpawnerActive)
            {
                //spawn new missile
                Missile m = Instantiate<Missile>(missilePrefab);

                //move it to a new location
                m.transform.position = missileSpawnOrigin.position
                + Random.Range(-1.0f, 1.0f) * missileSpawnRadius * missileSpawnOrigin.right
                + Random.Range(-1.0f, 1.0f) * missileSpawnRadius * missileSpawnOrigin.forward;

                Rigidbody rb = m.GetComponent<Rigidbody>();

                //if target is destroyed
                if(target == null)
                {
                    missileSpawnerActive = false;
                }

                //if target is not destroyed
                if (target != null)
                {
                    rb.velocity = (target.position - m.transform.position).normalized * missileSpeed;
                }

                x++;

                yield return new WaitForSeconds(missileSpawnPeriod_sec);
            }
            yield return null;  //wait for next frame
            
        }
    }


}
