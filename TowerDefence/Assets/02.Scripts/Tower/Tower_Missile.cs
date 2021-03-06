using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Missile : Tower
{
    public GameObject missilePrefab;
    public Transform[] firePoints;
    public int damage;
    public float reloadTime;
    private float reloadTimer;
    public override void Update()
    {
        base.Update();

        if (reloadTimer < 0)
        {
            if (target != null)
            {
                Attack();
                reloadTimer = reloadTime;
            }
        }
        else
        {
            reloadTimer -= Time.deltaTime;
        }

    }

    private void Attack()
    {
        foreach (var firePoint in firePoints)
        {
            GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);
            Vector3 dir = (target.transform.position - missile.transform.position).normalized;
            missile.GetComponent<Missile>().Setup(dir, target, damage);

        }
        
    }

}
