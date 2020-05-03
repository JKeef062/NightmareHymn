using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public GameManager theGM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theGM.EndGame();
        }
    }
}
