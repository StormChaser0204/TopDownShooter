using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5;
    private float lifeTime = 5f;
    private float currentLifeTime;

    private Transform tr;


    public void Awake()
    {
        tr = GetComponent<Transform>();
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyBehaviour>().TakeDamage();
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        tr.position += tr.forward * speed * Time.deltaTime;
        if (currentLifeTime < lifeTime)
        {
            currentLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
