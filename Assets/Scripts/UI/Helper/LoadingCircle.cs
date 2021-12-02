using UnityEngine;
using DG.Tweening;

namespace FreddyNewton.Ui.Helper
{
    /// <summary>
    /// Helper function that uses 
    /// </summary>
    public class LoadingCircle : MonoBehaviour
    {
        private void Awake()
        {
            var sequence = DOTween.Sequence()
                .Append(gameObject.transform.DOLocalRotate(new Vector3(0,0,360), 3, RotateMode.Fast)).SetRelative();
            sequence.SetLoops(-1, LoopType.Restart);
            sequence.Play();
        }

        private void OnDestroy()
        {
            gameObject.transform.DOKill();
        }
    }

}
