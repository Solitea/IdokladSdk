using System;
using IdokladSdk.Clients;
using IdokladSdk.Clients.Readonly;

namespace IdokladSdk
{
    /// <summary>
    /// Definition of all endpoints in iDoklad API.
    /// </summary>
    public class DokladApi
    {
        private AccountClient _accountClient;
        private AttachmentClient _attachmentClient;
        private BankAccountClient _bankAccountClient;
        private BankClient _bankClient;
        private BankStatementClient _bankStatementClient;
        private BatchClient _batchClient;
        private CashRegisterClient _cashRegisterClient;
        private CashVoucherClient _cashVoucherClient;
        private ConstantSymbolClient _constantSymbolClient;
        private ContactClient _contactClient;
        private CountryClient _countryClient;
        private CreditNoteClient _creditNoteClient;
        private CurrencyClient _currencyClient;
        private ExchangeRateClient _exchangeRateClient;
        private IssuedDocumentPaymentClient _issuedDocumentPaymentClient;
        private IssuedInvoiceClient _issuedInvoiceClient;
        private IssuedDocumentTemplateClient _issuedDocumentTemplateClient;
        private IssuedTaxDocumentClient _issuedTaxDocumentClient;
        private LogClient _logClient;
        private MailClient _mailClient;
        private NotificationClient _notificationClient;
        private NumericSequenceClient _numericSequenceClient;
        private PaymentOptionClient _paymentOptionClient;
        private PriceListItemClient _priceListItemClient;
        private ProformaInvoiceClient _proformaInvoiceClient;
        private ReceivedInvoiceClient _receivedInvoiceClient;
        private ReceivedDocumentPaymentsClient _receivedDocumentPaymentsClient;
        private RecurringInvoiceClient _recurringInvoiceClient;
        private RegisteredSaleClient _registeredSaleClient;
        private ReportClient _reportClient;
        private SalesOfficeClient _salesOfficeClient;
        private SalesOrderClient _salesOrderClient;
        private SalesPosEquipmentClient _salesPosEquipmentClient;
        private SalesReceiptClient _salesReceiptClient;
        private StatisticsClient _statisticsClient;
        private StockMovementClient _stockMovementClient;
        private SystemClient _systemClient;
        private TagClient _tagClient;
        private VatCodeClient _vatCodeClient;
        private VatRateClient _vatRateClient;
        private VatReverseChargeCodeClient _vatReverseChargeCodeClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DokladApi" /> class.
        /// </summary>
        /// <param name="context">API context.</param>
        public DokladApi(ApiContext context)
        {
            ApiContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets API context.
        /// </summary>
        public ApiContext ApiContext { get; }

        /// <summary>
        /// Gets account.
        /// </summary>
        public AccountClient AccountClient =>
            _accountClient ?? (_accountClient = new AccountClient(ApiContext));

        /// <summary>
        /// Gets Attachments.
        /// </summary>
        public AttachmentClient AttachmentClient =>
            _attachmentClient ?? (_attachmentClient = new AttachmentClient(ApiContext));

        /// <summary>
        /// Gets bank accounts.
        /// </summary>
        public BankAccountClient BankAccountClient => _bankAccountClient ?? (_bankAccountClient = new BankAccountClient(ApiContext));

        /// <summary>
        /// Gets banks.
        /// </summary>
        public BankClient BankClient => _bankClient ?? (_bankClient = new BankClient(ApiContext));

        /// <summary>
        /// Gets bank statements.
        /// </summary>
        public BankStatementClient BankStatementClient => _bankStatementClient ?? (_bankStatementClient = new BankStatementClient(ApiContext));

        /// <summary>
        /// Gets batch operations.
        /// </summary>
        public BatchClient BatchClient => _batchClient ?? (_batchClient = new BatchClient(ApiContext));

        /// <summary>
        /// Gets cash registers.
        /// </summary>
        public CashRegisterClient CashRegisterClient =>
            _cashRegisterClient ?? (_cashRegisterClient = new CashRegisterClient(ApiContext));

        /// <summary>
        /// Gets cash vouchers.
        /// </summary>
        public CashVoucherClient CashVoucherClient =>
            _cashVoucherClient ?? (_cashVoucherClient = new CashVoucherClient(ApiContext));

        /// <summary>
        /// Gets constant symbols.
        /// </summary>
        public ConstantSymbolClient ConstantSymbolClient =>
            _constantSymbolClient ?? (_constantSymbolClient = new ConstantSymbolClient(ApiContext));

        /// <summary>
        /// Gets Contacts.
        /// </summary>
        public ContactClient ContactClient => _contactClient ?? (_contactClient = new ContactClient(ApiContext));

        /// <summary>
        /// Gets Countries.
        /// </summary>
        public CountryClient CountryClient => _countryClient ?? (_countryClient = new CountryClient(ApiContext));

        /// <summary>
        /// Gets Credit notes.
        /// </summary>
        public CreditNoteClient CreditNoteClient => _creditNoteClient ?? (_creditNoteClient = new CreditNoteClient(ApiContext));

        /// <summary>
        /// Gets Currencies.
        /// </summary>
        public CurrencyClient CurrencyClient => _currencyClient ?? (_currencyClient = new CurrencyClient(ApiContext));

        /// <summary>
        /// Gets exchange rates.
        /// </summary>
        public ExchangeRateClient ExchangeRateClient =>
            _exchangeRateClient ?? (_exchangeRateClient = new ExchangeRateClient(ApiContext));

        /// <summary>
        /// Gets issued invoices.
        /// </summary>
        public IssuedDocumentPaymentClient IssuedDocumentPaymentClient =>
            _issuedDocumentPaymentClient ?? (_issuedDocumentPaymentClient = new IssuedDocumentPaymentClient(ApiContext));

        /// <summary>
        /// Gets issued invoices.
        /// </summary>
        public IssuedDocumentTemplateClient IssuedDocumentTemplateClient =>
            _issuedDocumentTemplateClient ?? (_issuedDocumentTemplateClient = new IssuedDocumentTemplateClient(ApiContext));

        /// <summary>
        /// Gets issued invoices.
        /// </summary>
        public IssuedInvoiceClient IssuedInvoiceClient =>
            _issuedInvoiceClient ?? (_issuedInvoiceClient = new IssuedInvoiceClient(ApiContext));

        /// <summary>
        /// Gets issued tax documents.
        /// </summary>
        public IssuedTaxDocumentClient IssuedTaxDocumentClient =>
            _issuedTaxDocumentClient ?? (_issuedTaxDocumentClient = new IssuedTaxDocumentClient(ApiContext));

        /// <summary>
        /// Gets logs.
        /// </summary>
        public LogClient LogClient =>
            _logClient ?? (_logClient = new LogClient(ApiContext));

        /// <summary>
        /// Gets mail.
        /// </summary>
        public MailClient MailClient => _mailClient ?? (_mailClient = new MailClient(ApiContext));

        /// <summary>
        /// Gets Notifications.
        /// </summary>
        public NotificationClient NotificationClient => _notificationClient ?? (_notificationClient = new NotificationClient(ApiContext));

        /// <summary>
        /// Gets numeric sequence.
        /// </summary>
        public NumericSequenceClient NumericSequenceClient => _numericSequenceClient ?? (_numericSequenceClient = new NumericSequenceClient(ApiContext));

        /// <summary>
        /// Gets payment options.
        /// </summary>
        public PaymentOptionClient PaymentOptionClient =>
            _paymentOptionClient ?? (_paymentOptionClient = new PaymentOptionClient(ApiContext));

        /// <summary>
        /// Gets price list items.
        /// </summary>
        public PriceListItemClient PriceListItemClient =>
            _priceListItemClient ?? (_priceListItemClient = new PriceListItemClient(ApiContext));

        /// <summary>
        /// Gets proforma invoices.
        /// </summary>
        public ProformaInvoiceClient ProformaInvoiceClient =>
            _proformaInvoiceClient ?? (_proformaInvoiceClient = new ProformaInvoiceClient(ApiContext));

        /// <summary>
        /// Gets received invoices.
        /// </summary>
        public ReceivedInvoiceClient ReceivedInvoiceClient =>
            _receivedInvoiceClient ?? (_receivedInvoiceClient = new ReceivedInvoiceClient(ApiContext));

        /// <summary>
        /// Gets received document payments.
        /// </summary>
        public ReceivedDocumentPaymentsClient ReceivedDocumentPaymentsClient =>
            _receivedDocumentPaymentsClient ?? (_receivedDocumentPaymentsClient = new ReceivedDocumentPaymentsClient(ApiContext));

        /// <summary>
        /// Gets recurring invoices.
        /// </summary>
        public RecurringInvoiceClient RecurringInvoiceClient =>
            _recurringInvoiceClient ?? (_recurringInvoiceClient = new RecurringInvoiceClient(ApiContext));

        /// <summary>
        /// Gets registered sale.
        /// </summary>
        public RegisteredSaleClient RegisteredSaleClient =>
            _registeredSaleClient ?? (_registeredSaleClient = new RegisteredSaleClient(ApiContext));

        /// <summary>
        /// Gets reports.
        /// </summary>
        public ReportClient ReportClient => _reportClient ?? (_reportClient = new ReportClient(ApiContext));

        /// <summary>
        /// Gets sales offices.
        /// </summary>
        public SalesOfficeClient SalesOfficeClient =>
            _salesOfficeClient ?? (_salesOfficeClient = new SalesOfficeClient(ApiContext));

        /// <summary>
        /// Gets sales orders.
        /// </summary>
        public SalesOrderClient SalesOrderClient =>
            _salesOrderClient ?? (_salesOrderClient = new SalesOrderClient(ApiContext));

        /// <summary>
        /// Gets sales pos equipments.
        /// </summary>
        public SalesPosEquipmentClient SalesPosEquipmentClient =>
            _salesPosEquipmentClient ?? (_salesPosEquipmentClient = new SalesPosEquipmentClient(ApiContext));

        /// <summary>
        /// Gets sales receipts.
        /// </summary>
        public SalesReceiptClient SalesReceiptClient =>
            _salesReceiptClient ?? (_salesReceiptClient = new SalesReceiptClient(ApiContext));

        /// <summary>
        /// Gets stock movements.
        /// </summary>
        public StatisticsClient StatisticsClient => _statisticsClient ?? (_statisticsClient = new StatisticsClient(ApiContext));

        /// <summary>
        /// Gets stock movements.
        /// </summary>
        public StockMovementClient StockMovementClient =>
            _stockMovementClient ?? (_stockMovementClient = new StockMovementClient(ApiContext));

        /// <summary>
        /// Gets system data.
        /// </summary>
        public SystemClient SystemClient => _systemClient ?? (_systemClient = new SystemClient(ApiContext));

        /// <summary>
        /// Gets tags.
        /// </summary>
        public TagClient TagClient => _tagClient ?? (_tagClient = new TagClient(ApiContext));

        /// <summary>
        /// Gets VAT codes.
        /// </summary>
        public VatCodeClient VatCodeClient => _vatCodeClient ?? (_vatCodeClient = new VatCodeClient(ApiContext));

        /// <summary>
        /// Gets VAT rates.
        /// </summary>
        public VatRateClient VatRateClient => _vatRateClient ?? (_vatRateClient = new VatRateClient(ApiContext));

        /// <summary>
        /// Gets VAT reverse charge codes.
        /// </summary>
        public VatReverseChargeCodeClient VatReverseChargeCodeClient =>
            _vatReverseChargeCodeClient ?? (_vatReverseChargeCodeClient = new VatReverseChargeCodeClient(ApiContext));
    }
}
