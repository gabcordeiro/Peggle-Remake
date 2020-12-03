using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject bola;

    [SerializeField]
    private Transform pontodetiro;

    public Vector2 direcaotiro;

    private GerenteJogo gerente;
    private BolaScript bolascript;

   

    [SerializeField]
    private ParticleSystem efeitoexplosao;


    void Start()
    {
        gerente = FindObjectOfType<GerenteJogo>();
        bolascript = FindObjectOfType<BolaScript>();
    }


    void Update()
    {

        Vector3 posicaomouse = Input.mousePosition;
        posicaomouse = Camera.main.ScreenToWorldPoint(posicaomouse);


        Vector2 direcao = new Vector2(posicaomouse.x - transform.position.x, posicaomouse.y - transform.position.y);

        transform.up = -direcao;

        direcaotiro = -direcao.normalized;



        AtirarBola();



        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gerente.AdicionarBolas(10);
        }
    */
    }

    private void AtirarBola()
    {
     
        if (Input.GetMouseButtonDown(0) && gerente.bolas > 0 && GameObject.FindGameObjectWithTag("bolas") == null)
        {

            

            Instantiate(bola, pontodetiro.transform.position, pontodetiro.transform.rotation);
            Instantiate(efeitoexplosao, pontodetiro.transform.position, pontodetiro.transform.rotation);
            



        }
    }

}
