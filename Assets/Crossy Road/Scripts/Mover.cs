using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1.0f;
    public float moveDirection = 0;
    public bool parentOnTrigger = true;
    public bool hitBoxOnTrigger = false;
    public GameObject moverObject = null;

    private Renderer renderer = null;
    private bool isVisible = false;

    void Start ()
    {
        renderer = moverObject.GetComponent<Renderer>();
    }

    void Update ()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);

        IsVisible();
    }
    	
    void IsVisible ()
    {
        if (renderer.isVisible)
        {
            isVisible = true;
        }
        if (!renderer.isVisible && isVisible)
        {
            //Debug.Log("Removendo Objeto. Não visto mais pela câmera.");
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (parentOnTrigger)
            {
                Debug.Log("Enter. Parent on Me");
                other.transform.parent = this.transform;
                other.GetComponent<PlayerController>().parentedToObject = true; //seta um bool pra agua/pra saber se ta parentado com o tronco
            }
            
            if (hitBoxOnTrigger)
            {
                Debug.Log("Enter. Got Hit. Game Over");
                other.GetComponent<PlayerController>().GotHit();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (parentOnTrigger)
            {
                Debug.Log("Exit");
                other.transform.parent = null;
                other.GetComponent<PlayerController>().parentedToObject = false; //seta um bool pra agua quando sai do tronco fica falso

            }
        } 
    }
}
