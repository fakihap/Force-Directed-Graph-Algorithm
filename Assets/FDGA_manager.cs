using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDGA_manager : MonoBehaviour
{
    public List<Node> nodes;

    public float space = 10f;

    void Start(){
        foreach(var i in nodes){
            i.transform.position = new Vector3(Random.Range(-space, space), Random.Range(-space, space), Random.Range(-space, space));
        }

        foreach (var i in nodes){
            foreach (var j in nodes){
                if(!i.adjacent.Contains(j) && i != j){
                    i.unadjacent.Add(j);    
                }
            }
        }
    }
}
