﻿using System;
using System.Collections.Generic;
using System.Globalization;
using IdokladSdk.Clients.Interfaces;
using IdokladSdk.Enums;
using IdokladSdk.Models.NumericSequence;
using IdokladSdk.Requests.NumericSequence;
using IdokladSdk.Response;

namespace IdokladSdk.Clients
{
    /// <summary>
    /// Client for communication with numeric sequence endpoints.
    /// </summary>
    public partial class NumericSequenceClient :
        BaseClient,
        IEntityList<NumericSequenceList>,
        IPatchRequest<NumericSequencePatchModel, NumericSequenceGetModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericSequenceClient"/> class.
        /// </summary>
        /// <param name="apiContext">Context.</param>
        public NumericSequenceClient(ApiContext apiContext)
            : base(apiContext)
        {
        }

        /// <inheritdoc/>
        public override string ResourceUrl { get; } = "/NumericSequences";

        /// <inheritdoc cref="IEntityDetail{TDetail}.Detail"/>
        /// <param name="id">Entity Id.</param>
        /// <param name="year">Year.</param>
        public NumericSequenceDetail Detail(int id, int? year = null)
        {
            return new NumericSequenceDetail(id, this, year);
        }

        /// <inheritdoc/>
        public NumericSequenceList List()
        {
            return new NumericSequenceList(this);
        }

        /// <summary>
        /// Returns document number and variable symbol by parameters.
        /// </summary>
        /// <param name="documentType">Document type.</param>
        /// <param name="date">Date.</param>
        /// <param name="documentSerialNumber">Serial number.</param>
        /// <param name="numericSequenceId">Numeric sequence id.</param>
        /// <returns><see cref="ApiResult{TData}"/> instance containing <see cref="DocumentNumbersGetModel"/>.</returns>
        public ApiResult<DocumentNumbersGetModel> GetDocumentNumber(NumericSequenceDocumentType documentType,  DateTime? date = null, int? documentSerialNumber = null, int? numericSequenceId = null)
        {
            var resource = $"{ResourceUrl}/DocumentNumbers/{documentType}";
            var queryParams = QueryParams(date, documentSerialNumber, numericSequenceId);
            return Get<DocumentNumbersGetModel>(resource, queryParams);
        }

        /// <inheritdoc />
        public ApiResult<NumericSequenceGetModel> Update(NumericSequencePatchModel model)
        {
            return Patch<NumericSequencePatchModel, NumericSequenceGetModel>(model);
        }

        private Dictionary<string, string> QueryParams(DateTime? date, int? documentSerialNumber, int? numericSequenceId)
        {
            var queryParams = new Dictionary<string, string>();
            if (date != null)
            {
                queryParams.Add("date", date.GetValueOrDefault().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            }

            if (documentSerialNumber != null)
            {
                queryParams.Add("documentSerialNumber", documentSerialNumber.ToString());
            }

            if (numericSequenceId != null)
            {
                queryParams.Add("numericSequenceId", numericSequenceId.ToString());
            }

            return queryParams;
        }
    }
}
