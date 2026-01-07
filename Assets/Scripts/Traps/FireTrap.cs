using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{
    [Header("FireTrap TImers")]

    [SerializeField] private float activeTime;
    [SerializeField] private float activationDelay;
    [SerializeField] private float damage;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered; // to check if the trap has been triggered
    private bool active; // to check if the trap is currently active
    private Health playerHealth;

    [Header("FireTrap Sound")]
    [SerializeField] private AudioClip fireTrapSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if(!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            
            if(active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = null;
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(fireTrapSound);
        spriteRend.color = Color.white;
        // activate the trap
        active = true;
        anim.SetBool("activated", true);
        

        yield return new WaitForSeconds(activeTime);
        // deactivate the trap
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
