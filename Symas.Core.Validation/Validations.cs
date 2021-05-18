using System;
using System.Collections;

namespace Symas.Core.Validation
{
    public static class Validations
    {
        public static ArgumentValidation<T> NotNull<T>(this ArgumentValidation<T> item)
        {
            if (typeof(T).IsClass && item.Value == null)
            {
                throw new ArgumentNullException(item.ArgumentName);
            }

            var nullable = Nullable.GetUnderlyingType(typeof(T)) != null;
            if (nullable && item.Value == null)
            {
                throw new ArgumentNullException(item.ArgumentName);
            }

            return item;
        }

        public static ArgumentValidation<string> NotNullOrWhitespace(this ArgumentValidation<string> item)
        {
            if (string.IsNullOrWhiteSpace(item.Value))
            {
                throw new ArgumentNullException(item.ArgumentName);
            }

            return item;
        }

        public static ArgumentValidation<T[]> NotEmpty<T>(this ArgumentValidation<T[]> items)
        {
            if (items.Value.Length == 0)
                throw new ArgumentNullException(items.ArgumentName);

            return items;
        }

        public static ArgumentValidation<T> IsTrue<T>(
            this ArgumentValidation<T> item,
            Func<ArgumentValidation<T>, bool> predicate,
            string message = "IsTrue evaluated to false")
        {
            if (predicate.Invoke(item) == false)
                throw new ArgumentException(message, item.ArgumentName);

            return item;
        }

        public static ArgumentValidation<T> IsFalse<T>(
            this ArgumentValidation<T> item,
            Func<ArgumentValidation<T>, bool> predicate,
            string message = "IsFalse evaluated to true")
        {
            if (predicate.Invoke(item) == true)
                throw new ArgumentException(message, item.ArgumentName);

            return item;
        }

        public static ArgumentValidation<T> IsElementTypeAt<T>(
            this ArgumentValidation<T> item,
            int index,
            Type type,
            bool isNullValue = true)
            where T : IList
        {
            if (item == null || item.Value == null)
                throw new ArgumentException(
                    $"The array for evaluate can not be null",
                    item.ArgumentName);

            if (type == null)
                throw new ArgumentException(
                    $"The type can not be null",
                    item.ArgumentName);

            var element = item.Value[index];

            if (!isNullValue && element == null)
                throw new ArgumentException(
                    $"IsElementTypeAt({index}) element can not be null value",
                    item.ArgumentName);

            if (element.GetType() != type)
                throw new ArgumentException(
                    $"IsElementTypeAt({index}) is '{element.GetType().FullName}' and expected '{type.FullName}'",
                    item.ArgumentName);

            return item;
        }


    }
}
