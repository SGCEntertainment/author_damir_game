using UnityEngine;

public static class RectTransformExtens
{
    public static float GetHeight(this Transform transform)
    {
        float height = 0;
        foreach(Transform t in transform)
        {
            height += t.GetComponent<RectTransform>().rect.height;
        }

        return height;
    }
}
