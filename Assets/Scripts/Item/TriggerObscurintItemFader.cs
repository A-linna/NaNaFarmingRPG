

using UnityEngine;

public class TriggerObscurintItemFader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var obscuringItemFaders = other.gameObject.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders is { Length: > 0 })
        {
            foreach (var obscuringItemFader in obscuringItemFaders)
            {
                obscuringItemFader.FadeIn();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var obscuringItemFaders = other.gameObject.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders is { Length: > 0 })
        {
            foreach (var obscuringItemFader in obscuringItemFaders)
            {
                obscuringItemFader.FadeOut();
            }
        }
    }
}
