using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float CoolDownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip fireballSound;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Time.timeScale == 0) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;

        if(Input.GetMouseButtonDown(0) && attackCooldown < CoolDownTimer && playerMovement.canAttack())
            Attack();

        CoolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(fireballSound);
        // Trigger attack animation
        anim.SetTrigger("attack");
        CoolDownTimer = 0; // Set cooldown duration
        SoundManager.instance.PlaySound(fireballSound);

        fireballs[findFireball()].transform.position = firePoint.position;
        fireballs[findFireball()].GetComponent<FireballProjector>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int findFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
