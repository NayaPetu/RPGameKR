using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //private int _strenght;
    //private int _health;

    public Slider healthSliderP;
    public Transform target;
    public GameObject player;
    private NavMeshAgent agent;
    //public GameObject batt;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if ((player.transform.position - agent.transform.position).sqrMagnitude < 10)
        {
            healthSliderP.value = healthSliderP.value - 1;
        }
    }

    //public GameObject bottle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spear")
        {
            Destroy(this.gameObject);
            //Instantiate(hit.collider.gameObject);// наверное сдесь прописать появление предметов из скелетов
        }
    }
}
