using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;
    public float followDist;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distance = (transform.position - target.transform.position).magnitude;
        Debug.Log(distance);

        if(distance <= followDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position,followDist) * Time.deltaTime;
            targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
            targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
        }
    }
}