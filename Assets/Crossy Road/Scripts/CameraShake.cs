using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float jumpIter = 4.5f;

   // Se quiser testar
    // void Update()
   // {
   //     if (Input.GetKeyDown("c"))
   //     {
   //         Shake();
   //     }
   // }

    public void Shake ()
    {
        float height = Mathf.PerlinNoise(jumpIter, 0f) * 5;
        height = height * height * 0.2f;

        float shakeAmt = height; // * 0.01f; //graus que a camera vai chacoalhar
        float shakePeriodTime = 0.25f; // periodo de cada chacoalhada
        float dropOffTime = 1.25f; // quanto tempo até a chacoalhada setar para ZERO

        LTDescr shakeTween = LeanTween.rotateAroundLocal(gameObject, Vector3.right, shakeAmt, shakePeriodTime).setEase(LeanTweenType.easeShake).setLoopClamp().setRepeat(-1);
        LeanTween.value(gameObject, shakeAmt, 0, dropOffTime).setOnUpdate((float val) => { shakeTween.setTo(Vector3.right * val); }).setEase(LeanTweenType.easeOutQuad);

    }

}
