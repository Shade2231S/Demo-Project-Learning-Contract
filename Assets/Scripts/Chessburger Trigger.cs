using UnityEngine;
using UnityEngine.Playables;
public class ChessburgerTrigger : MonoBehaviour
{
    private PlayerControllerV2 player;
    public PlayableDirector timeline;
    public float stopspeed = 0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();
            //player.;
        }
    }
}