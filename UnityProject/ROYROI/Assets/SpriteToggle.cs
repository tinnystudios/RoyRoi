using ROYROI.Buttons;
using UnityEngine;
using UnityEngine.UI;

public class SpriteToggle : Toggle<Sprite, Image>
{
    public override void Off()
    {
        m_Avatar.sprite = m_offAvatar;
    }

    public override void On()
    {
        m_Avatar.sprite = m_onAvatar;
    }
}


