using System;

namespace MPewsey.UnityEventManager
{
    /// <summary>
    /// A struct for containing an event key string and its hash code for faster lookup.
    /// </summary>
    public readonly struct EventKey : IEquatable<EventKey>
    {
        /// <summary>
        /// The event key string.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The event key hash code.
        /// </summary>
        private int HashCode { get; }

        /// <summary>
        /// Performs an implicit cast from a string to an event key.
        /// </summary>
        /// <param name="key">The key string.</param>
        public static implicit operator EventKey(string key) => new EventKey(key);

        /// <summary>
        /// Initializes a new event key.
        /// </summary>
        /// <param name="key">The key string.</param>
        public EventKey(string key)
        {
            Key = key;
            HashCode = key.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"EventKey({Key})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is EventKey eventKey && Equals(eventKey);
        }

        /// <inheritdoc/>
        public bool Equals(EventKey other)
        {
            return HashCode == other.HashCode && Key == other.Key;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode;
        }
    }
}