using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beePatrol : MonoBehaviour
{   public Transform point1;
    public Transform point2;
    public float speed = 2f;
    public float stopTime = 3f;
    bool CanGo = true;
    // Start is called before the first frame update
    void Start(){        
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, point1.position.z); 
    }

    // Update is called once per frame
    void Update(){
        if (CanGo)
        transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        if (transform.position == point1.position){
            Transform t = point1;
            point1 = point2;
            point2 = t;
            CanGo = false;
            StartCoroutine(Waiting());
        }
    }
    IEnumerator Waiting(){
        yield return new WaitForSeconds(stopTime);
        CanGo = true;
    }
}
