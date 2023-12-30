using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public Vector2 Aim;
    public bool openFire;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float TimeTillShot;
    private float TimeLeftTillShot;


    public void Fire()
    {
        if(TimeLeftTillShot <= 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(BulletSpawnPoint.right * BulletSpeed, ForceMode2D.Impulse);
            TimeLeftTillShot = TimeTillShot;
        }
    }

    private void Update()
    {
        float angle = Mathf.Atan2(Aim.y, Aim.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        TimeLeftTillShot -= Time.deltaTime;
        if (openFire)
        {
            Fire();
        }
    }
}
