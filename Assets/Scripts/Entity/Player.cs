using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CnControls;

public class Player : MonoBehaviour
{
    public event Action onTakeDamage;

    public int lifeCounter = 3;
    public float moveSpeed = 10;

    public GameObject bullet;
    public Transform stick;
    public Animator PlayerAnim;

    private float _moveSpeed;
    private bool canTakeDamage = true;
    private float rotation;

    private Rigidbody rb;
    private Transform tr;
    private Vector3 _stick;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    public void Start()
    {
        _moveSpeed = moveSpeed;
        _stick = new Vector3(stick.position.x, 0, stick.position.y);
        rotation = tr.rotation.y;
    }

    void Update()
    {
        moveInput = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    public void FixedUpdate()
    {
        rb.velocity = moveVelocity;
        if (CnInputManager.GetAxis("Horizontal") != 0 || CnInputManager.GetAxis("Vertical") != 0)
            tr.rotation = Quaternion.Euler(0, Mathf.Atan2(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical")) * Mathf.Rad2Deg, 0);
    }

    public void Shoot()
    {
        Instantiate(bullet, tr.position, tr.rotation);
    }

    public void TakeDamage()
    {
        if (lifeCounter > 1)
        {
            if (canTakeDamage)
            {
                lifeCounter--;
                StartCoroutine(WaitForRevive());
                onTakeDamage();
            }
        }
        else
        {
            onTakeDamage();
            Time.timeScale = 0;
            MainController.instance.uiController.Lose();
        }
    }

    IEnumerator WaitForRevive()
    {
        PlayerAnim.SetTrigger("TakeDamage");
        canTakeDamage = false;
        moveSpeed = 0;
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
        moveSpeed = _moveSpeed;
    }
}
