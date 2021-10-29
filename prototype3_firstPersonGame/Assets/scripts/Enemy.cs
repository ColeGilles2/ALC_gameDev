using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Stats")]
    public int curHP, maxHp, ScoreToGive;

    [Header("Movement")]
    public float moveSpeed, attackRange, yPathOffset;

    private List<Vector3> path;

    private Weapon weapon;
    private GameObject target;


    // Start is called before the first frame update
    void Start() {
        //gather components
        weapon = GetComponent<weapon>();
        target = FindOjectOfType<PlayerController>().GameObject;
    }

    void UpdatePath() {
        //calculate a pathto the target
        NavMeshPath navMeshPath = new NavMeshPath();

        navMeshPath.CalculatePath(this.transform.position, target.transform.position, navMeshPath);

        //save calculated oath to list
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget() {
        if(path.Count == 0)
            return;

        //move towards closest path
        transform.position = Vector3.MoveTowards(transform.poistion, path[0] + new Vector3(0, yPathOffset, 0),
         moveSpeed * Time.deltaTime);

         if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
