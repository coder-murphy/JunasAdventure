using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.FDGameSDK.Interfaces.Util.UI
{
    public abstract class FDDragObject : MonoBehaviour, IDragHandler,IBeginDragHandler
    {
        [SerializeField]
        private RectTransform rectTransform;

        public void OnBeginDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.SetAsLastSibling();
        }
    }
}
