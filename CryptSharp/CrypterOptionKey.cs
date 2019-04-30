using CryptSharp.Internal;
using System;

namespace CryptSharp
{
    /// <summary>
    /// The key type for options.
    /// </summary>
    public class CrypterOptionKey
    {
        /// <summary>
        /// Creates a new option key.
        /// </summary>
        /// <param name="description">A description of the option.</param>
        /// <param name="valueType">The type of the option's value.</param>
        public CrypterOptionKey(string description, Type valueType)
        {
            Check.Null("description", description);
            Check.Null("valueType", valueType);

            Description = description;
            ValueType = valueType;
        }

        /// <summary>
        /// Throws an exception if the value is incompatible with this option.
        /// </summary>
        /// <param name="value">The value to check.</param>
        public void CheckValue(object value)
        {
            if (value == null)
            {
                throw Exceptions.ArgumentNull(null);
            }

            if (!ValueType.IsAssignableFrom(value.GetType()))
            {
                throw Exceptions.Argument(null, "Value is incompatible with type {0}.", ValueType);
            }

            OnCheckValue(value);
        }

        /// <summary>
        /// Override this to provide additional validation for an option.
        /// </summary>
        /// <param name="value">The value to check.</param>
        protected virtual void OnCheckValue(object value)
        {

        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Description;
        }

        /// <summary>
        /// A description of the option.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// The type of the option's value.
        /// </summary>
        public Type ValueType
        {
            get;
            private set;
        }
    }
}
