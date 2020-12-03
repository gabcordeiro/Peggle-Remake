using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [HeaderAttribute("Animacao da Interface")]
    public AnimationCurve animacaoGUI;

    public Vector3 posicaofinal;
    public Vector3 posicaoinicial;

    [HeaderAttribute("Tempo da Animacao")]
    public float tempo = 0.5f;



    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))
        StartCoroutine(MoverGUI());

    }

    public IEnumerator MoverGUI()
    {
        float i = 0;
        float rate = 1 / tempo;
        while (i < 1)
        {
            i += rate * Time.deltaTime;
            transform.localPosition = Vector3.Lerp(posicaoinicial, posicaofinal, animacaoGUI.Evaluate(i));
            yield return 0;
        }
    }




    public void RestartJogo()
    {
        Scene fase = SceneManager.GetActiveScene();
        SceneManager.LoadScene(fase.name);
        print("Restart Nivel");
    }
    public void ProximaFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("MENU");
    }
}
