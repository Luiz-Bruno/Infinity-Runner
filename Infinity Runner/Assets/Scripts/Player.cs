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

    public GameObject bulletPrefab;
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() //� chamado pela f�sica da unity
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping) // !isJumping � o mesmo que isJumping == false
        {
            rig.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            isJumping = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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
