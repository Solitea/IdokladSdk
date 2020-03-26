using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using IdokladSdk.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;

namespace IdokladSdk.Validation
{
    /// <summary>
    /// API result validator.
    /// </summary>
    public static class ApiResultValidator
    {
        private const string ApiResultSchemaFile = "apiresult-schema.json";
        private const string ApiBatchResultSchemaFile = "apibatchresult-schema.json";

        private static JSchema _basicSchema = null;
        private static JSchema _batchSchema = null;

        /// <summary>
        /// Gets JSON schema for common operation response.
        /// </summary>
        public static JSchema BasicSchema => _basicSchema ?? (_basicSchema = LoadBasicSchema());

        /// <summary>
        /// Gets JSON schema for batch operation response.
        /// </summary>
        public static JSchema BatchSchema => _batchSchema ?? (_batchSchema = LoadBatchSchema());

        /// <summary>
        /// Validate API response.
        /// </summary>
        /// <typeparam name="T">Result type.</typeparam>
        /// <param name="response">Response from RestSharp.</param>
        /// <param name="schemaType">Schema type.</param>
        /// <param name="handler">Custom API result handler.</param>
        public static void ValidateResponse<T>(IRestResponse<T> response, ApiResultSchema schemaType, Action<T> handler)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response), "Response cannot be null.");
            }

            if (response.ErrorException != null)
            {
                throw new ValidationException($"Response is not valid.", response.ErrorException);
            }

            var schema = GetSchema(schemaType);
            var apiResult = JObject.Parse(response.Content);

            if (!apiResult.IsValid(schema, out IList<string> messages))
            {
                throw new ValidationException(
                    $"Response is not valid based on JSON schema.{Environment.NewLine}{response.Content}{Environment.NewLine}{string.Join(Environment.NewLine, messages)}");
            }

            handler?.Invoke(response.Data);
        }

        private static JSchema GetSchema(ApiResultSchema schemaType)
        {
            switch (schemaType)
            {
                case ApiResultSchema.Basic:
                    return BasicSchema;
                case ApiResultSchema.Batch:
                    return BatchSchema;
                default:
                    throw new ArgumentOutOfRangeException(nameof(schemaType), "Unsupported API result schema.");
            }
        }

        private static JSchema LoadBasicSchema()
        {
            var basicSchema = LoadSchemaFromResource(ApiResultSchemaFile);
            return JSchema.Parse(basicSchema);
        }

        private static JSchema LoadBatchSchema()
        {
            var basicSchema = LoadSchemaFromResource(ApiResultSchemaFile);
            var batchSchema = LoadSchemaFromResource(ApiBatchResultSchemaFile);
            var resolver = new JSchemaPreloadedResolver();
            resolver.Add(new Uri(ApiResultSchemaFile, UriKind.Relative), basicSchema);

            return JSchema.Parse(batchSchema, resolver);
        }

        private static string LoadSchemaFromResource(string fileName)
        {
            var assembly = typeof(ApiResultValidator).Assembly;
            var resourceName = $"IdokladSdk.{fileName}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
