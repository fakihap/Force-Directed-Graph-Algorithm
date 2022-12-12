using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> adjacent;
    public List<Node> unadjacent;
    public float attractForce = 3f;
    public float repelForce = 2f;

    public Rigidbody rb;

    public Vector3 sigmaF;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        sigmaF = Vector3.zero;

        foreach(var i in adjacent){
            Vector3 res = transform.position - i.transform.position;
            sigmaF -= res.normalized * attractForce * res.magnitude;
        }

        foreach(var i in unadjacent){
            Vector3 res = transform.position - i.transform.position;
            // if (res.magnitude == 0) { print(transform.name + i.name);}
            sigmaF += res.normalized * repelForce / res.sqrMagnitude;
        }

        sigmaF /= (adjacent.Count + unadjacent.Count);

        rb.velocity = sigmaF;

    }

    
}
