using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ROYROI.Buttons
{
    public abstract class Toggle<T,TGet> : MonoBehaviour, IPointerClickHandler
    {
        public bool m_On;

        public T m_onAvatar;
        public T m_offAvatar;

        public TGet m_Avatar;

        public virtual void Awake()
        {
            Apply();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_On = !m_On;
            Apply();
        }

        public virtual void Apply()
        {
            if (m_On)
            {
                On();
                //m_Image.sprite = m_OnSprite;
            }
            else
            {
                Off();
                //m_Image.sprite = m_OffSprite;
            }
        }

        public abstract void On();
        public abstract void Off();

    }
}
