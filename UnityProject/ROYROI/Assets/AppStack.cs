using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppStack {

    private static List<IEventStack> m_EventStacks = new List<IEventStack>();

    //Add an event stack to the stack
    public static void Add(IEventStack eventStack)
    {
        m_EventStacks.Add(eventStack);
    }

    public static void Invoke() {
        if (m_EventStacks.Count > 0)
        {
            m_EventStacks[m_EventStacks.Count-1].OnEnterStack();
            m_EventStacks.RemoveAt(m_EventStacks.Count-1);
        }
    }

}

public interface IEventStack {
    void OnEnterStack(); //When Back button is pressed.
}
