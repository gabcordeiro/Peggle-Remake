using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptParticula : MonoBehaviour
{

    ParticleSystem particula;

    void Start()
    {
        particula = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!particula.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
