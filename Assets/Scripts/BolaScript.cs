using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaScript : MonoBehaviour
{

    private GerenteJogo gerente;
    private Rigidbody2D bola_rb;

    [SerializeField]
    private float ForcaDoTiro = -6;

    public ParticleSystem particulaExplosao;

    [HeaderAttribute("Velocidade Do RigidBody2D")]
    public float rb_velocidade;


    void Start()
    {
        bola_rb = GetComponent<Rigidbody2D>();
        bola_rb.AddForce(GameObject.Find("lancadorfrente").GetComponent<MovimentoPlayer>().direcaotiro * ForcaDoTiro, ForceMode2D.Impulse);
        gerente = FindObjectOfType<GerenteJogo>();
        
    }


    void Update()
    {
        rb_velocidade = bola_rb.velocity.magnitude;

        if (rb_velocidade < 0.01)
        {
            StartCoroutine(DeletarSeFicarParado());
        }
        
    }

    private IEnumerator DeletarSeFicarParado()
    {
        print("Comecou a Rotina");
        yield return new WaitForSeconds(3);

            DeletarABola();

        print("Fim da Rotina");

    }

    void OnBecameInvisible()
    {
        DeletarABola();
    }



    void DeletarABola()
    {
        Instantiate(particulaExplosao, transform.position, transform.rotation);
        gerente.ProximaFase();
        gerente.RemoverBolas(1);
        Destroy(gameObject);
    }
}
