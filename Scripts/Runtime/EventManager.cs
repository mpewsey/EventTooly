using System.Collections.Generic;
using UnityEngine.Events;

namespace MPewsey.EventTooly
{
    /// <summary>
    /// A class for managing multiple events.
    /// </summary>
    public static class EventManager
    {
        /// <summary>
        /// A dictionary of events by key.
        /// </summary>
        private static Dictionary<EventKey, object> Events { get; } = new Dictionary<EventKey, object>();

        /// <summary>
        /// Clears all events from the manager.
        /// </summary>
        public static void Clear()
        {
            Events.Clear();
        }

        /// <summary>
        /// Removes all listeners for the specified event.
        /// </summary>
        /// <param name="key">The event key.</param>
        public static void RemoveAllListeners(EventKey key)
        {
            AcquireEvent(key).RemoveAllListeners();
        }

        /// <summary>
        /// Removes all listeners for the specified event.
        /// </summary>
        /// <param name="key">The event key.</param>
        public static void RemoveAllListeners<T1>(EventKey key)
        {
            AcquireEvent<T1>(key).RemoveAllListeners();
        }

        /// <summary>
        /// Removes all listeners for the specified event.
        /// </summary>
        /// <param name="key">The event key.</param>
        public static void RemoveAllListeners<T1, T2>(EventKey key)
        {
            AcquireEvent<T1, T2>(key).RemoveAllListeners();
        }

        /// <summary>
        /// Removes all listeners for the specified event.
        /// </summary>
        /// <param name="key">The event key.</param>
        public static void RemoveAllListeners<T1, T2, T3>(EventKey key)
        {
            AcquireEvent<T1, T2, T3>(key).RemoveAllListeners();
        }

        /// <summary>
        /// Returns the event for the specified key. If the key does not already exist, a new event is created.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <exception cref="System.InvalidCastException">Raised if an existing event cannot be cast to the return event type.</exception>
        private static UnityEvent AcquireEvent(EventKey key)
        {
            if (!Events.TryGetValue(key, out object obj))
            {
                var newEvent = new UnityEvent();
                Events.Add(key, newEvent);
                return newEvent;
            }

            if (obj is UnityEvent unityEvent)
                return unityEvent;

            throw new System.InvalidCastException($"Invalid cast for {key}. Attempted to cast {obj.GetType()} to {typeof(UnityEvent)}");
        }

        /// <summary>
        /// Returns the event for the specified key. If the key does not already exist, a new event is created.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <exception cref="System.InvalidCastException">Raised if an existing event cannot be cast to the return event type.</exception>
        private static UnityEvent<T1> AcquireEvent<T1>(EventKey key)
        {
            if (!Events.TryGetValue(key, out object obj))
            {
                var newEvent = new UnityEvent<T1>();
                Events.Add(key, newEvent);
                return newEvent;
            }

            if (obj is UnityEvent<T1> unityEvent)
                return unityEvent;

            throw new System.InvalidCastException($"Invalid cast for {key}. Attempted to cast {obj.GetType()} to {typeof(UnityEvent<T1>)}");
        }

        /// <summary>
        /// Returns the event for the specified key. If the key does not already exist, a new event is created.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <exception cref="System.InvalidCastException">Raised if an existing event cannot be cast to the return event type.</exception>
        private static UnityEvent<T1, T2> AcquireEvent<T1, T2>(EventKey key)
        {
            if (!Events.TryGetValue(key, out object obj))
            {
                var newEvent = new UnityEvent<T1, T2>();
                Events.Add(key, newEvent);
                return newEvent;
            }

            if (obj is UnityEvent<T1, T2> unityEvent)
                return unityEvent;

            throw new System.InvalidCastException($"Invalid cast for {key}. Attempted to cast {obj.GetType()} to {typeof(UnityEvent<T1, T2>)}");
        }

        /// <summary>
        /// Returns the event for the specified key. If the key does not already exist, a new event is created.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <exception cref="System.InvalidCastException">Raised if an existing event cannot be cast to the return event type.</exception>
        private static UnityEvent<T1, T2, T3> AcquireEvent<T1, T2, T3>(EventKey key)
        {
            if (!Events.TryGetValue(key, out object obj))
            {
                var newEvent = new UnityEvent<T1, T2, T3>();
                Events.Add(key, newEvent);
                return newEvent;
            }

            if (obj is UnityEvent<T1, T2, T3> unityEvent)
                return unityEvent;

            throw new System.InvalidCastException($"Invalid cast for {key}. Attempted to cast {obj.GetType()} to {typeof(UnityEvent<T1, T2, T3>)}");
        }

        /// <summary>
        /// Adds a listener to an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void AddListener(EventKey key, UnityAction action)
        {
            AcquireEvent(key).AddListener(action);
        }

        /// <summary>
        /// Adds a listener to an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void AddListener<T1>(EventKey key, UnityAction<T1> action)
        {
            AcquireEvent<T1>(key).AddListener(action);
        }

        /// <summary>
        /// Adds a listener to an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void AddListener<T1, T2>(EventKey key, UnityAction<T1, T2> action)
        {
            AcquireEvent<T1, T2>(key).AddListener(action);
        }

        /// <summary>
        /// Adds a listener to an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void AddListener<T1, T2, T3>(EventKey key, UnityAction<T1, T2, T3> action)
        {
            AcquireEvent<T1, T2, T3>(key).AddListener(action);
        }

        /// <summary>
        /// Removes a listener from an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void RemoveListener(EventKey key, UnityAction action)
        {
            AcquireEvent(key).RemoveListener(action);
        }

        /// <summary>
        /// Removes a listener from an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void RemoveListener<T1>(EventKey key, UnityAction<T1> action)
        {
            AcquireEvent<T1>(key).RemoveListener(action);
        }

        /// <summary>
        /// Removes a listener from an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void RemoveListener<T1, T2>(EventKey key, UnityAction<T1, T2> action)
        {
            AcquireEvent<T1, T2>(key).RemoveListener(action);
        }

        /// <summary>
        /// Removes a listener from an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="action">The action.</param>
        public static void RemoveListener<T1, T2, T3>(EventKey key, UnityAction<T1, T2, T3> action)
        {
            AcquireEvent<T1, T2, T3>(key).RemoveListener(action);
        }

        /// <summary>
        /// Invokes an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        public static void Invoke(EventKey key)
        {
            AcquireEvent(key).Invoke();
        }

        /// <summary>
        /// Invokes an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="arg1">The first argument.</param>
        public static void Invoke<T1>(EventKey key, T1 arg1)
        {
            AcquireEvent<T1>(key).Invoke(arg1);
        }

        /// <summary>
        /// Invokes an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        public static void Invoke<T1, T2>(EventKey key, T1 arg1, T2 arg2)
        {
            AcquireEvent<T1, T2>(key).Invoke(arg1, arg2);
        }

        /// <summary>
        /// Invokes an event.
        /// </summary>
        /// <param name="key">The event key.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        public static void Invoke<T1, T2, T3>(EventKey key, T1 arg1, T2 arg2, T3 arg3)
        {
            AcquireEvent<T1, T2, T3>(key).Invoke(arg1, arg2, arg3);
        }
    }
}