using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetle : MonoBehaviour
{
    public float speed = 1f;
    bool isWait = false;
    bool isHidden = false;
    public float waitTime = 2f;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        point.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);  
    }

    // Update is called once per frame
    void Update()
    {
        if (isWait == false)
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        if (transform.position == point.position)
        {
            if (isHidden)
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
                isHidden = false;
            }
            else
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
                isHidden = true;
            }
            isWait = true;
            StartCoroutine(Waiting());
        }
    
    }   
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        isWait = false;
    }
}

