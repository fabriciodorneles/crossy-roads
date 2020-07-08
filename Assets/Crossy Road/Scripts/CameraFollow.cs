using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float speed = 0.25f;
    public bool autoMove = true;
    public GameObject player = null;
    public Vector3 offset = new Vector3(3, 6, -3);
    Vector3 depth = Vector3.zero;
    Vector3 pos = Vector3.zero;

    void Update()
    {

        if (!Manager.instance.CanPlay()) return; //controlador do Manager , se o jogo não tá rolando não passa daqui

        if (autoMove)  //Estado Normal de Jogo com a camera andando pra frente automatico
        {
            // adiciona na variavel depth a coord Z
            depth = this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            // atualiz quando anda pros lados (tem que entender essa função LERP)
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            // aqui move a camera com as coords definidas nas outras linhas (o Y(altura) nunca muda)
            gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);
        }
        else  // Se setar no unity pra camera não andar automaticamente (bom para outros jogos)
        {
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, pos.z);
        }

    } 	
}
