using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IdokladSdk.Requests.Core.Modifiers.Select.Common
{
    /// <summary>
    /// ModelVisitor.
    /// </summary>
    public class ModelVisitor : ExpressionVisitor
    {
        private Assembly _idokladSdkAssembly;

        /// <summary>
        /// Gets IdokladSdk models member names.
        /// </summary>
        public HashSet<string> MemberNames { get; } = new HashSet<string>();

        /// <summary>
        /// Gets IdokladSdk assembly.
        /// </summary>
        protected Assembly IdokladSdkAssembly => _idokladSdkAssembly ?? (_idokladSdkAssembly = typeof(DokladApi).Assembly);

        /// <summary>
        /// Visit MemberExpression node - usage of property or field. If it's property of API model, it adds fully qualified
        /// property name to the list <see cref="MemberNames"/>.
        /// </summary>
        /// <param name="member">Node.</param>
        /// <returns>Expression.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Called internally with not null parameter.")]
        protected override Expression VisitMember(MemberExpression member)
        {
            if (member.Member.DeclaringType?.Assembly == IdokladSdkAssembly)
            {
                MemberNames.Add(GetFullyQualifiedMemberName(member));
            }

            return base.VisitMember(member);
        }

        private string GetFullyQualifiedMemberName(MemberExpression member)
        {
            var nameParts = new List<string>();

            while (member != null)
            {
                nameParts.Add(member.Member.Name);
                member = member.Expression as MemberExpression;
            }

            return string.Join(".", nameParts.AsEnumerable().Reverse());
        }
    }
}
