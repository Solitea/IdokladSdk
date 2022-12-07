using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdokladSdk.Clients;
using IdokladSdk.Response;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Clients;

/// <summary>
/// ClientTests.
/// </summary>
public class ClientTests
{
    [Test]
    public void AllMethodsAreAsyncToo()
    {
        // Arrange
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .FirstOrDefault(a => a.GetName().Name == "IdokladSdk")
            .GetTypes()
            .Where(p =>
                typeof(BaseClient).IsAssignableFrom(p) &&
                !p.IsAbstract);

        // Act
        var message = new StringBuilder();
        foreach (var type in types)
        {
            var methodInfos = type.GetMethods();
            var methods = methodInfos.Where(t => t.ReturnType.IsGenericType &&
            (t.ReturnType.GetGenericTypeDefinition() == typeof(ApiResult<>) || t.ReturnType.GetGenericTypeDefinition() == typeof(ApiBatchResult<>)));

            foreach (var methodInfo in methods)
            {
                var parameterTypes = GetParameterTypes(methodInfo, true);
                var asyncMethod = type.GetMethods()
                    .FirstOrDefault(m => m.Name == methodInfo.Name + "Async" && GetParameterTypes(m, false) == parameterTypes);
                if (asyncMethod == null || !asyncMethod.ReturnType.IsGenericType ||
                    asyncMethod.ReturnType.GetGenericTypeDefinition() != typeof(Task<>))
                {
                    message.AppendLine($"{type.Name} not implement: {methodInfo.Name + "Async"}");
                }
            }
        }

        // Assert
        if (message.Length > 0)
        {
            throw new Exception(message.ToString());
        }
    }

    private string GetParameterTypes(MethodInfo methodInfo, bool addCancellationToken)
    {
        var parameters = methodInfo.GetParameters().Select(p => p.ParameterType.FullName).ToList();
        if (addCancellationToken)
        {
            parameters.Add(typeof(CancellationToken).FullName);
        }

        return string.Join(", ", parameters);
    }
}
