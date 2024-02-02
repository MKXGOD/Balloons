using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public static float xMin
    {
        get => Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x + 0.5f;
    }
    public static float xMax
    {
        get => Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x - 0.5f;
    }
    public static float yMin
    {
        get => Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 2;
    }
}
