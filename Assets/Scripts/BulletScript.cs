using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float Damage;


    IEnumerator DeleteBulletAfterTime()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    IEnumerator Start()
    {
        yield return StartCoroutine(nameof(DeleteBulletAfterTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemyscript Enemy = collision.collider.gameObject.GetComponent<Enemyscript>();
        if(Enemy != null)
        {
            Enemy.Damage(Damage);
            Destroy(gameObject);
            return;
        }
    }
}
