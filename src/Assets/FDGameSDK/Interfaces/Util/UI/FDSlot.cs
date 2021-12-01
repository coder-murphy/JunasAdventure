using Assets.FDGameSDK.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.FDGameSDK.Util.UI
{
    public abstract class FDSlot : MonoBehaviour, IFDObjectBase, IDropHandler
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public void OnDrop(PointerEventData eventData)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


