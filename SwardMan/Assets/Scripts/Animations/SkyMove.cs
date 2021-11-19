using UnityEngine;
using DG.Tweening;
public class SkyMove : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Animate();
    }

    void Animate()
    {
        transform.DORotate(new Vector3(0,1,0),speed).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental);
    }
}
