using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatedorMovimento : MonoBehaviour
{
    [Range(1,10)]
    public float offset;

    [Range(1, 10)]
    public float velocidade = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time * velocidade) * offset , transform.position.y);
        //print(transform.position.x);
    }
}
