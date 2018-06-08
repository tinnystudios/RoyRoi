using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementItem : StateBase, IPointerClickHandler
{

    public void Awake()
    {
        Exit();
    }

    public GameObject m_Body;

    public override IEnumerator OnTransitionIn()
    {
        m_Body.SetActive(true);
        yield break;
    }

    public override IEnumerator OnTransitionOut()
    {
        m_Body.SetActive(false);
        yield break;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_Body.activeInHierarchy)
            Exit();
        else
            Enter();
    }

    public void UpdateParentLayouts()
    {
        //Update my layout
        var layouts = GetComponentsInParent<LayoutGroup>().Select(x => x.GetComponent<RectTransform>());

        foreach (var layout in layouts)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
        }
    }
}
