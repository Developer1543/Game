using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        
// called whenever the player hits the ground
    


        [SerializeField] private float speed;
        private Rigidbody2D body;
        private Animator anime; 


        public Transform groundChecker;
        public float groundRadius;
        private bool ground;



        private void Awake(){

            body = GetComponent<Rigidbody2D>();
            anime = GetComponent<Animator>();

        }

        private void Update()
                {

            float horizontalInput = Input.GetAxis("Horizontal");

            // how fast our player is moving and direction

            body.velocity = new Vector2(horizontalInput * speed,  body.velocity.y);       

                // player moves right
                if (horizontalInput > 0.01f){
                    transform.localScale = new Vector3(0.30f, 0.30f, 1);
                }
                // when player looks left (transformed from int to float using f)
                if (horizontalInput < -0.01f){
                    transform.localScale = new Vector3(-0.30f, 0.30f, 1);
    
                }
                
               
       

// get key is a boolean vairable that returns true when key is pressed. 
                Jump();


          anime.SetBool("run", horizontalInput != 0);
    }

    private void Jump(){
        if (Input.GetKey(KeyCode.Space) && ground) {
                     body.velocity = new Vector2(body.velocity.x, speed);
                     ground = false;

    }

}
  private void OnCollisionEnter2D(Collision2D collision){
            if (collision.gameObject.tag == "Ground")
                ground = true;
        }
   
public bool canAttack(){
    return horizontalInput == 0 && ground;

}
}


