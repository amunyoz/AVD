using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask Masks;//layers to damage or be reactive
    public float speed =20f;
    private Rigidbody2D RB;// or public if we want to reference it in the editor
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();//we take the component from the gameobject where the script is attached
        // we can access to STATIC variables without instanciate the class
        // check if we need to fire left or right and rescale the sprite to face the direction
        Vector3 theScale = transform.localScale;
        if (CharacterController2D.m_FacingRight)
        {
            speed *= -1;       
        }
        else {
            theScale.x *= -1; 
        }
        transform.localScale = theScale;
        RB.velocity = transform.right * -speed;
        

    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        Debug.Log(info.gameObject.name);
        if (RB.IsTouchingLayers(Masks))
        {
            //the bullet touch some enemy or objet- no the player 
            Destroy(gameObject);
        }
        
    }
}
