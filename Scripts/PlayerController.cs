using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	   Rigidbody rb;
	   public GameObject bullet;
    Rigidbody rbClone;
    GameObject BulletClone;
    public Text hpText;
    int hp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
       rb.AddForce(transform.forward * moveVertical * 25f);

       float moveHorizontal = Input.GetAxis("Horizontal");
       transform.Rotate(0f, moveHorizontal * 5f, 0f);

        if(Input.GetKeyDown("space"))
       {
        BulletClone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        rbClone = BulletClone.GetComponent<Rigidbody>();
        rbClone.AddForce(transform.forward * 1000f);
       }
    }

    void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.tag == "Enemy")
      {
        hpText.text = "HP: 0";
        hp = hp - 50;
        hpText.text = "HP: " + hp;
      
      if(hp <= 0)
        {
          SceneManager.LoadScene(1);
        }
      }
    }
}
