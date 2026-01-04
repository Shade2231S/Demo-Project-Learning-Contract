using UnityEngine;
using UnityEngine.Playables;
public class ChessburgerTrigger : MonoBehaviour
{
    private PlayerControllerV2 player;
    public PlayableDirector timeline;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();
            
        }
    }
}