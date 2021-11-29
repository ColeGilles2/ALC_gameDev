using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour {

    [Header("Stats")]
    public int curHP;
    public int maxHp;
    public int ScoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;

    public float yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        curHP = maxHp;

        //gather components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    void UpdatePath() {
        //calculate a pathto the target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        //save calculated oath to list
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget() {
        if(path.Count == 0)
            return;

        //move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0),
         moveSpeed * Time.deltaTime);

         if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    void Die() {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.back * 2, ForceMode.Impulse); 
        rb.AddForce(Vector3.up * 1, ForceMode.Impulse); 
        Destroy(gameObject, 1);
    } 


    public void TakeDamage(int damage) {
        curHP -= damage;

        if(curHP <= 0) {
            Die();
        }
    }


    // Update is called once per frame
    void Update() {
        //look at target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.up * angle;

        //get distance from enemy
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if(dist <= attackRange) {
            if (weapon.CanShoot() && curHP > 0)
                weapon.Shoot();
        } else {
            ChaseTarget();
        }
    }
}
