using System;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public bool isGuided = false; // 유도기능
    public Transform targetGuide;
    public float speed;
    private int _damage;
    public LayerMask touchLayer;
    public LayerMask targetLayer;
    public float explosionRange;

    Vector3 moveVec;
    Transform tr;

    private void Awake()
    {
        tr = transform;
    }


    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, 1f, touchLayer);
        if (cols.Length > 0)
            Explode();
    }

    private void FixedUpdate()
    {
        if (isGuided)
        {
            tr.LookAt(targetGuide);
            moveVec = (targetGuide.position - tr.position).normalized * speed;
        }
        tr.Translate(moveVec);
    }

    public void Setup(Vector3 dir, Transform target , int damage)
    {
        moveVec = dir * speed;
        targetGuide = target;
        _damage = damage;
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private void Explode()
    {
        Collider[] enemiesCols = Physics.OverlapSphere(tr.position, explosionRange, targetLayer);
        foreach (var enemiesCol in enemiesCols)
        {
            enemiesCol.GetComponent<Enemy>().hp -= _damage;
        }
        Destroy(gameObject);
    }

}
