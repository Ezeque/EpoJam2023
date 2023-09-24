using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    Transform enemyTransform;
    Transform playerTransform;
    GameObject playerObject;
    Player player;
    public float speed = 5f;
    // Start is called before the first frame update

    public Enemy(){
    }

    void Start()
    {
        //playerObject = GameObject.Find("Player");
        //player = playerObject.GetComponent<Player>();
        //enemyTransform = GameObject.Find("Enemy").transform; 
        //playerTransform = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
      double dist = EuclidianDist();

      Vector3 newPosition = transform.position;
      
      if(dist >= 0.5){
            if(GameObject.Find("Player").transform.position.x > transform.position.x){
                newPosition.x += + 0.5f * speed * Time.deltaTime;
            }
            else if(GameObject.Find("Player").transform.position.x < transform.position.x) {
                newPosition.x -= 0.5f * speed * Time.deltaTime;
            }
                    

            if(GameObject.Find("Player").transform.position.y > transform.position.y){
                newPosition.y += 0.5f * speed * Time.deltaTime;
            }
            else if(GameObject.Find("Player").transform.position.y < transform.position.y) {
                newPosition.y -= 0.5f * speed * Time.deltaTime;
            }
        }  

        transform.position = newPosition;
    }

    public double EuclidianDist(){
        //calcula a distancia 
        double diffx = Math.Pow(GameObject.Find("Player").transform.position.x - transform.position.x, 2);
        double diffy = Math.Pow(GameObject.Find("Player").transform.position.y - transform.position.y, 2); 
        return Math.Sqrt(diffx+diffy);
    }
}
