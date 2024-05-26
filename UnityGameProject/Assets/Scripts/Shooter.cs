using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;

    private float timeAfterFire;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterFire += Time.deltaTime;

        if (timeAfterFire >= fireRate)
        {
            timeAfterFire = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
