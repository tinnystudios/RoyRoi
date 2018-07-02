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
            var stack = m_EventStacks[m_EventStacks.Count - 1];

            stack.OnEnterStack();

            if (m_EventStacks.Contains(stack))
            {
                m_EventStacks.Remove(stack);
            }
        }
    }

    public static int Count
    {
        get
        {
            return m_EventStacks.Count;
        }
    }

    public static void Clear()
    {
        m_EventStacks.Clear();
    }

    public static List<IEventStack> Stacks
    {
        get
        {
            return m_EventStacks;
        }
    }

}

public interface IEventStack {
    void OnEnterStack(); //When Back button is pressed.
}
