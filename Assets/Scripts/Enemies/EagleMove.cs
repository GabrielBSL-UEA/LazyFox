using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMove : MonoBehaviour
{
    public float speed;
    public float moveTime;
    private bool dirRight = true;
    private float timer;
    
    void Update()
    {
        if(dirRight){
            //se verdadeiro, vai para a direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            gameObject.transform.localScale = new Vector3(-2, 2, 2);

        }else{
            //se falso, vai pra esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            gameObject.transform.localScale = new Vector3(2, 2, 2);

        }
        //o timer vai ser somado com o tempo que se passa dentro do jogo
        timer += Time.deltaTime;
        //e ao se passar certo tempo, ela vai trocar o valor booleano
        if(timer >= moveTime){
            dirRight = !dirRight;
            timer = 0f;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<GameController>().ActivateDefeatPanel();
        }
    }
}
