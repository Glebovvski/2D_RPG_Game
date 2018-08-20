using System;
using System.Collections.Generic;

public class MessagingManager : Singleton<MessagingManager>
{
    protected MessagingManager() { } // guarantee this will be always a singleton only - can't use the constructor!

    // public property for manager
    private List<Action> subscribers = new List<Action>();
    private List<Action<bool>> uiEventSubscribers = new List<Action<bool>>();
    private List<Action<InventoryItem>> inventorySubscribers = new List<Action<InventoryItem>>();

    // Subscribe method for manager
    public void Subscribe(Action subscriber)
    {
        if (subscribers != null)
        {
            subscribers.Add(subscriber);
        }
    }
    
    // Subscribe method for manager
    public void SubscribeUIEvent(Action<bool> subscriber)
    {
        if (uiEventSubscribers != null)
        {
            uiEventSubscribers.Add(subscriber);
        }
    }

    public void SubscribeInventoryEvent(Action<InventoryItem> subscriber)
    {
        if (inventorySubscribers != null)
        {
            inventorySubscribers.Add(subscriber);
        }
    }
    
    public void Broadcast()
    {
        if (subscribers != null)
        {
            foreach (var subscriber in subscribers.ToArray())
            {
                subscriber();
            }
        }
    }
    
    public void BroadcastUIEvent(bool uIVisible)
    {
        if (uiEventSubscribers != null)
        {
            foreach (var subscriber in uiEventSubscribers.ToArray())
            {
                subscriber(uIVisible);
            }
        }
    }

    public void BroadcastInventoryEvent(InventoryItem itemInuse)
    {
        foreach (var subscriber in inventorySubscribers)
        {
            subscriber(itemInuse);
        }
    }


    // Unsubscribe method for manager
    public void UnSubscribe(Action subscriber)
    {
        if (subscribers != null)
        {
            subscribers.Remove(subscriber);
        }
    }

    // Unsubscribe method for UI manager
    public void UnSubscribeUIEvent(Action<bool> subscriber)
    {
        if (uiEventSubscribers != null)
        {
            uiEventSubscribers.Remove(subscriber);
        }
    }

    public void UnsubscribeInventoryEvent(Action<InventoryItem> subscriber)
    {
        if (inventorySubscribers != null)
        {
            inventorySubscribers.Remove(subscriber);
        }
    }


    // Clear subscribers method for manager
    public void ClearAllSubscribers()
    {
        if (subscribers != null)
        {
            subscribers.Clear();
        }
    }

    // Clear subscribers method for manager
    public void ClearAllUIEventSubscribers()
    {
        if (uiEventSubscribers != null)
        {
            uiEventSubscribers.Clear();
        }
    }

    public void ClearAllInventoryEventSubscribers()
    {
        if (inventorySubscribers != null)
        {
            inventorySubscribers.Clear();
        }
    }
}


