using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitFlash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat; 
    private float restoreDefaulMatTime = 0.2f;
    private Material defaulMat; 
    private SpriteRenderer spriteRenderer; 
    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>(); 
        defaulMat = spriteRenderer.material; 
    }

    public float GetRestoreMatTime() 
    {
        return restoreDefaulMatTime; 
    }

    public IEnumerator FlashRoutine() 
    {
        spriteRenderer.material = whiteFlashMat; 
        yield return new WaitForSeconds(restoreDefaulMatTime); 
        spriteRenderer.material = defaulMat;   
    }
}
