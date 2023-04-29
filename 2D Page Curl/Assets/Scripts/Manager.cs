using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Slider alphaSlider;

    [SerializeField] private SpriteRenderer[] touchAreas;

    public void Sliding()
    {
        for (int i = 0; i < touchAreas.Length; i++)
        {
            Color temp = touchAreas[i].color;
            temp.a = alphaSlider.value;
            touchAreas[i].color = temp;
        }
    }
}
