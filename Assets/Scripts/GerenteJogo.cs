using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class GerenteJogo : MonoBehaviour
{
    //public event Action PinoPonto;
    [HeaderAttribute("Pontuação e Bolas")]
    [SerializeField]
    private int pontuacao;


    public int bolas = 10;

    [SerializeField]
    private Text pontuacaotexto;

    [SerializeField]
    private Text bolastexto;

    [HeaderAttribute("Referencias")]
    [SerializeField]
    private GameObject GameOverMenu;

    [SerializeField]
    private GameObject ProximaFaseMenu;

    [HeaderAttribute("Pinos Laranjas Carregados por Script")] 
    public ColisorPinoLaranja[] pinosLaranjas;

    private GameObject[] gamepinoLaranja;

    private GameOverMenu GUImenu;


    [HeaderAttribute("Anuncios")]
    [SerializeField]
    private string gameId;

    private bool testMode = true;

    void Start()
    {
        AdicionarPonto(0);

        bolastexto.text = bolas.ToString();

        GUImenu = FindObjectOfType<GameOverMenu>();

        Advertisement.Initialize(gameId, testMode);

    }


    void Update()
    {
        if (bolas <= 0)
        {
            //StartCoroutine(MostrarAnuncio());
                GameOverMenu.SetActive(true);
        }

    }

    public void ProximaFase()
    {
        if (ChecarSeTerminouPinosLaranjas())
        {
            //StartCoroutine(MostrarAnuncio());
            ProximaFaseMenu.SetActive(true);

            //GUImenu.MoverGUI();
           
        }
    }


    public IEnumerator MostrarAnuncio()
    {
        if (Advertisement.IsReady("video") )
        {
            Advertisement.Show("video");
            yield return 0;
        }

    }

    public bool ChecarSeTerminouPinosLaranjas()
    {
        gamepinoLaranja = GameObject.FindGameObjectsWithTag("pinoLaranja");
        pinosLaranjas = new ColisorPinoLaranja[gamepinoLaranja.Length];

        for (int i = 0; i < gamepinoLaranja.Length; i++)
        {
            pinosLaranjas[i] = gamepinoLaranja[i].GetComponent<ColisorPinoLaranja>();
            if (!pinosLaranjas[i].aceso)
            {
                //print("cu");
                return false;
            }
        }
        return true;
    }


    public void RemoverBolas(int bol)
    {
        bolas -= bol;
        bolastexto.text = bolas.ToString();
    }

    public void AdicionarBolas(int bol)
    {
        bolas += bol;
        bolastexto.text = bolas.ToString();
    }

    public void AdicionarPonto(int ponto)
    {
        
        pontuacao += ponto;
        pontuacaotexto.text = pontuacao.ToString();
    }


}
