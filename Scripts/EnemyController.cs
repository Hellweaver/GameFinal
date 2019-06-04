using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	public Transform player;
    public NavMeshAgent agent;
    public Text scoreText;
    static int score;
   
    void Start()
    {
        score = 0;
    }

    
    void FixedUpdate()
    {
        agent.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.CompareTag("Bullet"))
    	{
                Destroy(collision.gameObject);
                Destroy(gameObject);

            scoreText.text = "Score: 0";
        	score = score + 5;
        	scoreText.text = "Score: " + score;

            if(score >= 10)
            {
                SceneManager.LoadScene(0);
            }
		}
	}
}
