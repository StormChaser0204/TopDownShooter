using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool isActive = true;

    private Animator anim;

    public void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage()
    {
        isActive = false;
        StartCoroutine(Dead());
        MainController.instance.uiController.IncriminateKill();
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().TakeDamage();
        }
    }

    IEnumerator Dead()
    {
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
