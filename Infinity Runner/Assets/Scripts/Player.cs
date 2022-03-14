using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public Animator anim;

    public float speed;
    public float jumpforce;

    private bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() //É chamado pela física da unity
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping) // !isJumping é o mesmo que isJumping == false
        {
            rig.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            anim.SetBool("jumping", false);
            isJumping = false;
        }
    }
}
