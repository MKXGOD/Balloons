using UnityEngine;
using System;

public class Shreder : MonoBehaviour
{
    public static Action OnBalloonMissed;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Balloons")
        { 
            Destroy(collision.gameObject);
            OnBalloonMissed?.Invoke();
        }
    }
}
