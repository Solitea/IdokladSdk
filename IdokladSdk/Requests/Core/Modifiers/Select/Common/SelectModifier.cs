using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using IdokladSdk.Requests.Core.Interfaces;
using IdokladSdk.Requests.Core.Path;

namespace IdokladSdk.Requests.Core.Modifiers.Select.Common
{
    /// <summary>
    /// Select modifier of a request.
    /// </summary>
    /// <typeparam name="TSelect">Request model.</typeparam>
    public class SelectModifier<TSelect> : IQueryStringModifier
     where TSelect : new()
    {
        private readonly PathCollection _selects = new PathCollection();

        private readonly string _prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectModifier{TSelect}"/> class.
        /// </summary>
        /// <param name="prefix">Select prefix.</param>
        public SelectModifier(string prefix = "")
        {
            _prefix = prefix;
        }

        /// <summary>
        /// Select.
        /// </summary>
        /// <param name="selector">A transform function to apply to each source element.</param>
        /// <typeparam name="TGetModel">Get model.</typeparam>
        /// <typeparam name="TResult">Return type.</typeparam>
        public void Select<TGetModel, TResult>(Expression<Func<TGetModel, TResult>> selector)
        {
            var visitor = new ModelVisitor();
            visitor.Visit(selector);

            foreach (var memberName in visitor.MemberNames)
            {
                AddSelect(memberName);
            }
        }

        /// <summary>
        /// Select.
        /// </summary>
        /// <typeparam name="TCustomResult">CustomResult type.</typeparam>
        public void Select<TCustomResult>()
        {
            var type = (TypeInfo)typeof(TCustomResult);
            foreach (var propertyInfo in type.GetProperties())
            {
                var name = _prefix + propertyInfo.Name;
                var propertyType = propertyInfo.PropertyType;
                var isEnumerable = typeof(IEnumerable).IsAssignableFrom(propertyType) && propertyType != typeof(string);
                if ((propertyType.IsClass && propertyType != typeof(string)) || isEnumerable)
                {
                    var innerPaths = GetInnerPaths(propertyInfo);
                    foreach (var innerPath in innerPaths)
                    {
                        AddSelect(innerPath);
                    }
                }
                else
                {
                    AddSelect(name);
                }
            }
        }

        /// <inheritdoc/>
        public Dictionary<string, string> GetQueryParameters()
        {
            if (!_selects.Any())
            {
                return null;
            }

            return new Dictionary<string, string>
            {
                { "select", _selects.ToString() }
            };
        }

        private static bool IsValid(string value)
        {
            var filterableObject = new TSelect();
            var propertyName = value.Split(new[] { '.' }, 2)[0];
            var isSelectProperty = filterableObject.GetType().GetProperties().Any(info => info.Name == propertyName);
            return isSelectProperty;
        }

        private void AddSelect(string name)
        {
            if (IsValid(name))
            {
                _selects.Add(name);
            }
        }

        private string RemoveModelName(string value)
        {
            return value.Remove(0, value.IndexOf(".", StringComparison.Ordinal) + 1);
        }

        private List<string> GetInnerPaths(PropertyInfo info)
        {
            List<string> paths = new List<string>();
            var name = info.Name;
            var infoPropertyType = info.PropertyType;
            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(infoPropertyType) && infoPropertyType != typeof(string);
            if (isEnumerable)
            {
                infoPropertyType = infoPropertyType.GetGenericArguments()[0];
            }

            if (infoPropertyType.IsClass && infoPropertyType != typeof(string))
            {
                var propertyType = (TypeInfo)infoPropertyType;
                foreach (var prop in propertyType.GetProperties())
                {
                    var innerPaths = GetInnerPaths(prop);
                    foreach (var innerPath in innerPaths)
                    {
                        paths.Add($"{name}.{innerPath}");
                    }
                }
            }

            paths.Add(name);
            return paths;
        }
    }
}
