using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool isActive = true;
    public float speed = 3;

    public GroundChecker groundChecker;

    private float time = 0f;
    private float lifeTime = 5f;

    private Animator anim;
    private Rigidbody rb;
    private Transform playerTransform = null;
    private Vector3 velocity;

    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (playerTransform == null)
        {
            velocity = transform.forward * speed;
        }
        else
        {
            velocity = transform.forward * speed;
            transform.LookAt(playerTransform);
        }
    }

    public void Update()
    {
        rb.velocity = velocity;
        if (!groundChecker.onFloor)
        {
            if (time < lifeTime)
            {
                time += Time.deltaTime;
            }
            else
            {
                MainController.instance.botController.RespawnEnemy(this.gameObject);
            }
        }
    }

    public void Spawn()
    {
        transform.LookAt(PlayerController.instance.player.transform);
        speed = 3;
    }

    public void TakeDamage()
    {
        isActive = false;
        playerTransform = null;
        speed = 0;
        StartCoroutine(Dead());
        MainController.instance.uiController.IncriminateKill();
    }

    public void Respawn()
    {
        MainController.instance.botController.RespawnEnemy(this.gameObject);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerTransform = col.gameObject.transform;
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().TakeDamage();
            StartCoroutine(WaitForMoving());
        }
        if (col.gameObject.tag == "Enemy" && playerTransform == null)
        {
            Quaternion rotation = transform.rotation;
            transform.Rotate(Vector3.up, 135f);
        }
    }

    IEnumerator WaitForMoving()
    {
        speed = 0;
        yield return new WaitForSeconds(3f);
        speed = 3;
    }

    IEnumerator Dead()
    {
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        MainController.instance.botController.RespawnEnemy(this.gameObject);
    }
}
