using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Scripts.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
   public PostProcessVolume postProcessVolume;
   public Vignette vignette;
    public float duration=0.3f;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }

    IEnumerator FlashColorVignette()
    {
        Vignette tmp;
        if (postProcessVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            vignette = tmp;
        }

        ColorParameter c = new ColorParameter();

        float time=0;
        while (time <duration)
        {
            c.value = Color.Lerp(Color.blue,Color.red,time/duration);
            time += Time.deltaTime;
            vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }
        time = 0;

        while (time < duration)
        {
            c.value = Color.Lerp(Color.red, Color.blue, time / duration);
            time += Time.deltaTime;
            vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }


    }

}
