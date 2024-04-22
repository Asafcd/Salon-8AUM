using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExitTransform
{
    public static void DestroyChildren(this Transform t, bool destroyInmediately = false)
    {
        foreach (Transform child in t)
        {
            if (destroyInmediately)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
            else
            {
                MonoBehaviour.Destroy(child.gameObject);
            }
        }
    }
}
