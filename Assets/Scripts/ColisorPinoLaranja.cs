using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorPinoLaranja : MonoBehaviour
{

    SpriteRenderer pino_sr;


    GerenteJogo gerente;

    [SerializeField]
    private Sprite pino_aceso;

    public bool aceso = false;



    void Start()
    {
        pino_sr = GetComponent<SpriteRenderer>();

        gerente = FindObjectOfType<GerenteJogo>();

    }

    void Update()
    {
        if (aceso == true)
        {
            pino_sr.sprite = pino_aceso;
        }
    }





    void OnCollisionEnter2D(Collision2D col)
    {

        if (aceso == false)
        {
            gerente.AdicionarPonto(50);

            aceso = true;
        }
    }

}
