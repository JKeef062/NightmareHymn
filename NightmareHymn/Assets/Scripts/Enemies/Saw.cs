using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Saw : MonoBehaviour
{
    float count;

    public float speed;
    public float width;
    public float height;

    float startx, starty, startz;
    // Start is called before the first frame update
    void Start()
    {
        startx = transform.position.x;
        starty = transform.position.y;
        startz = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count += Time.deltaTime * speed;

        float x = startx + Mathf.Cos(count) * width;
        float y = starty + Mathf.Sin(count) * height;
        

        transform.position = new Vector3(x, y, startz);
    }

}
