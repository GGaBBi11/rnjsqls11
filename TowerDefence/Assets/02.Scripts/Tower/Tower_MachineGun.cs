using System;
using System.Collections.Generic;
using UnityEngine;



public class Tower_MachineGun : Tower
{
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
        target.GetComponent<Enemy>().hp -= damage;
    }
}

