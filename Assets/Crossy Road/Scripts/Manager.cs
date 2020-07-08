
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //pra usar a parte de USER INTERFACE do Unity
using UnityEngine.SceneManagement; //Gerenciar Cenas
using System.Collections;




public class Manager : MonoBehaviour
{
    public int levelCount = 50;
    public Text coin = null; // parte do Unity.UI
    public Text distance = null; // UI também
    public Camera camera = null; //pra acessar o controle da camera (referencia lá no unity)
    public GameObject guiGameOver = null;
    public LevelGenerator levelGenerator = null;
    
    private int currentCoins = 0;
    private int currentDistance = 0;
    private bool canPlay = false;
    

    //Metodo Padrão sempre que for fazer um Manager(?) pra ter acesso a todos os metodos do projeto aqui(?)
    private static Manager s_Instance;                     
    public static Manager instance
    {
        get
        {
            if ( s_Instance == null)
            {
                s_Instance = FindObjectOfType ( typeof ( Manager ) ) as Manager;

             }

            return s_Instance;
        }
    }
    // Metodo manager ^ até aqui

    void Start ()
    {
        for (int i=0; i < levelCount; i++)
        {
            levelGenerator.RandomGenerator();
        }
    }

    public void UpdateCoinCount ( int value ) // value pq as moedas podem ter valores diferentes
    {
        Debug.Log(" Player pegou mais uma moeda de " + value);

        currentCoins += value; //equivale à currentCoins = currentCoins + value

        coin.text = currentCoins.ToString(); //metodo da UI pra exibir na tela algo ( o TOString é pq o current coins é integer e esse metodo tem que ser String(TXT))

    }

    public void UpdateDistanceCount ()
    {
        //Debug.Log("Player se moveu para frente um ponto");

        currentDistance += 1;

        distance.text = currentDistance.ToString();

        levelGenerator.RandomGenerator();
        
    }

    public bool CanPlay () //esse função aqui é pra retornar pra alguma chama esterna o estado do canPlay
    {
        return canPlay;
    }

    public void StartPlay () // pra começar a jogar
    {
        canPlay = true;
    }

    public void GameOver ()
    {
        camera.GetComponent<CameraShake>().Shake(); //chama o CameraShake no Unit e ordena um Shake()
        camera.GetComponent<CameraFollow>().enabled = false; // chama o CameraFollow do e seta com false

        GuiGameOver();
    }

    void GuiGameOver ()
    {
        //Debug.Log("Game Over!");
        guiGameOver.SetActive(true);

    }

    public void PlayAgain ()
    {
        Scene scene = SceneManager.GetActiveScene(); // carrega na variavel a mesma scena que já tá
        SceneManager.LoadScene(scene.name); //carrega a mesma cena de novo (não tem outros level e é randomizado(dentro do codigo da cena mesmo) por isso carrega a mesma
    }

    public void Quit ()
    {
        Application.Quit();
    } 
}
