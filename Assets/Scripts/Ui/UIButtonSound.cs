using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip clickSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlaySound(clickSound);
    }
}

