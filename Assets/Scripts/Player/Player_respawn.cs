using UnityEngine;

public class Player_respawn : MonoBehaviour
{
    private Transform currentcheckPoint;
    [SerializeField] private AudioClip respawnSound;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void respawn()
    {
        transform.position = currentcheckPoint.position;
        playerHealth.Respawn();

        //Move camera to checkpoint room
        Camera.main.GetComponent<CameraMovement>().moveToNewRoom(currentcheckPoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentcheckPoint = collision.transform;
            SoundManager.instance.PlaySound(respawnSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
