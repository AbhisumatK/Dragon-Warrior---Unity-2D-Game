using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private Vector3[] initialPositions;
    private Collider2D roomCollider;
    private Transform player;

    private bool isActive;

    private void Awake()
    {
        roomCollider = GetComponent<Collider2D>();
        roomCollider.isTrigger = true; // safety

        initialPositions = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                initialPositions[i] = enemies[i].transform.position;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ActivateRoom(false); // start inactive
    }

    private void Update()
    {
        if (player == null)
            return;

        // THIS is the entire fix
        bool playerInside =
            roomCollider.bounds.Contains(player.position);

        if (playerInside && !isActive)
            ActivateRoom(true);
        else if (!playerInside && isActive)
            ActivateRoom(false);
    }

    public void ActivateRoom(bool status)
    {
        isActive = status;

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) continue;

            enemies[i].SetActive(status);

            if (status)
                enemies[i].transform.position = initialPositions[i];
        }
    }
}
