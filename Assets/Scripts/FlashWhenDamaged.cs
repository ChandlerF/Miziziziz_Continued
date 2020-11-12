using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWhenDamaged : MonoBehaviour
{
    private Material WhiteMaterial;
    private Material DefaultMaterial;
    public SpriteRenderer BodyRenderer, HeadRenderer;

    private void Start()
    {
        WhiteMaterial = Resources.Load("White Flash", typeof(Material)) as Material;
        DefaultMaterial = BodyRenderer.material;
        DefaultMaterial = HeadRenderer.material;
    }
    public IEnumerator FlashWhite(float Duration)
    {
        double Elapsed = 0.0f;

        while (Elapsed < Duration)
        {
            BodyRenderer.material = WhiteMaterial;
            HeadRenderer.material = WhiteMaterial;

            Elapsed += .01;

            yield return null;
        }
        BodyRenderer.material = DefaultMaterial;
        HeadRenderer.material = DefaultMaterial;

    }

    public void Flash()
    {
        StartCoroutine(FlashWhite(.5f));
    }
}
