using Invoice.Model;
using Invoice.Service;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Invoice.Handler
{
    public class InvoiceGenerator
    {
        private IInvoiceService _invoiceService;
        private IVoucherService _voucherService;

        public InvoiceGenerator(IInvoiceService invoiceService, IVoucherService voucherService)
        {
            this._invoiceService = invoiceService;
            this._voucherService = voucherService;
        }

        public byte[] Generate(int invoiceId)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Model.Invoice invoice = this._invoiceService.GetInvoiceForPrint(invoiceId).Result;

            invoice.Vouchers = invoice.Vouchers.OrderBy(x => x.VoucherNo).ToList();

            InvoiceDocument invoiceDocument = new InvoiceDocument(invoice);
            
            byte[] generatedInvoice = invoiceDocument.GeneratePdf();

            foreach (VoucherMaster voucher in invoice.Vouchers)
            {
                this._voucherService.UpdateStatus(voucher.Id, VoucherStatus.Invoice_Printed);
            }

            this._invoiceService.UpdateStatus(invoice.Id, VoucherStatus.Invoice_Printed);

            return generatedInvoice;
        }

    }

    public class InvoiceDocument : IDocument
    {
        private readonly Model.Invoice _invoice;

        public InvoiceDocument(Model.Invoice invoice)
        {
            _invoice = invoice;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.MarginTop(25);
                page.MarginBottom(25);
                page.MarginLeft(25);
                page.MarginRight(25);
                page.Content().Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Tax Invoice").Bold().FontSize(16).AlignLeft();
                        row.RelativeItem().Text("Original For Receipt").Bold().FontSize(16).AlignRight();
                    });
                    col.Item().PaddingBottom(10);

                    composeHeader(col);
                    composeCustomerInfo(col);
                    composeItemTable(col);
                });
                page.Footer().Element(composeFooter);
            });
        }

        private void composeHeader(ColumnDescriptor col)
        {
            col.Item().LineHorizontal(1);
            col.Item().Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    Company company = this._invoice.FinancialYear.Company;
                    c.Item().Text(company.Name).Bold().FontSize(16);
                    c.Item().Text($"{company.Address1}, {company.Address2}, {company.Address3}, {company.City} - {company.Zip},  {company.State}, {company.Country}").FontSize(10);
                    c.Item().Text($"(M) {company.PhoneNumber}").FontSize(10);
                });

                row.ConstantItem(250).Column(c =>
                {
                    addTwoColumnText(c, "Invoice No", this._invoice.InvoiceNo);
                    addTwoColumnText(c, "Dated", this._invoice.InvoiceDate.ToString("dd-MM-yy"));
                    addTwoColumnText(c, "GST No", this._invoice.FinancialYear.Company.GSTNo);
                });
            });

            col.Item().PaddingTop(5).LineHorizontal(1);
        }

        void composeCustomerInfo(ColumnDescriptor col)
        {
            col.Item().Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text("TO").Bold();
                    if (!string.IsNullOrWhiteSpace(_invoice.Customer.Name)) c.Item().Text(_invoice.Customer.Name).Bold();
                    if (!string.IsNullOrWhiteSpace(_invoice.Customer.Address1)) c.Item().Text(_invoice.Customer.Address1).Bold();
                    if (!string.IsNullOrWhiteSpace(_invoice.Customer.Address2)) c.Item().Text(_invoice.Customer.Address2).Bold();
                    if (!string.IsNullOrWhiteSpace(_invoice.Customer.Address3)) c.Item().Text(_invoice.Customer.Address3).Bold();
                    if (!string.IsNullOrWhiteSpace(_invoice.Customer.City)) c.Item().Text(_invoice.Customer.City).Bold();
                    c.Item().Text(_invoice.Customer.State +"-"+ _invoice.Customer.Zip).Bold();


                    //if(this._invoice.Vouchers.Count == 1)
                    //{
                    //    VoucherMaster firstVoucher = this._invoice.Vouchers[0];

                    //    if (!string.IsNullOrWhiteSpace(firstVoucher.VisitorName))
                    //    {
                    //        addTwoColumnText(c, "Visitor Name:", firstVoucher.VisitorName);
                    //    }

                    //    if (firstVoucher.BillingWorkType != BillingWorkType.NONE)
                    //    {
                    //        string unit = (firstVoucher.BillingWorkType == BillingWorkType.KM ? "KM" : "Time");
                    //        addTwoColumnText(c, $"From {unit}", firstVoucher.StartFrom);
                    //        addTwoColumnText(c, $"To {unit}", firstVoucher.EndFrom);
                    //    }
                    //    //c.Item().Text(firstVoucher.VisitorName);
                    //}

                });
                row.ConstantItem(250).Column(c =>
                {
                    addTwoColumnText(c, "GST No.", _invoice.Customer.GSTNo);
                    addTwoColumnText(c, "Pan No.", _invoice.Customer.PANNo);
                    addTwoColumnText(c, "LUT No.", _invoice.Customer.CessNo);
                });

            });

            col.Item().PaddingTop(3).Row(row =>
            {
                VoucherMaster firstVoucher = this._invoice.Vouchers[0];
                if (!string.IsNullOrWhiteSpace(firstVoucher.VisitorName))
                {
                    addTwoColumnText(row, "Visitor Name: ", firstVoucher.VisitorName);
                }

                if (firstVoucher.BillingWorkType != BillingWorkType.NONE)
                {
                    string unit = (firstVoucher.BillingWorkType == BillingWorkType.KM ? "KM" : "Time");
                    addTwoColumnText(row, $"{unit} From:", firstVoucher.StartFrom, true);
                    addTwoColumnText(row, $"To:", firstVoucher.EndFrom);
                }

                DateTime fromDate = this._invoice.Vouchers.Min(x => x.FromDate);
                DateTime toDate = this._invoice.Vouchers.Max(x => x.ToDate);
                addTwoColumnText(row, "From Date", fromDate.ToString("dd-MM-yy"));
                addTwoColumnText(row, "To Date", toDate.ToString("dd-MM-yy"));

                //row.RelativeItem().Column(c =>
                //{
                //    //if (!string.IsNullOrWhiteSpace(firstVoucher.VisitorName))
                //    //{

                //    //}
                //});

                //row.RelativeItem().Column(c =>
                //{
                //    c.Item().Text("From KM");
                //    c.Item().Text(firstVoucher.StartFrom);
                //});
            });

            col.Item().PaddingTop(5);
        }

        void composeItemTable(ColumnDescriptor col)
        {
            col.Item().PaddingTop(5);

            col.Item().Table(table =>
            {
                table.ColumnsDefinition(def =>
                {
                    def.ConstantColumn(25); //SrNo
                    def.RelativeColumn(1); //Item Name;
                    def.RelativeColumn(1);
                    def.ConstantColumn(60);
                    def.ConstantColumn(25);
                    def.ConstantColumn(60);
                    def.ConstantColumn(60);
                    def.ConstantColumn(60);
                    def.ConstantColumn(70);
                    //cell.Cell().Text("Description");
                    //cell.Cell().Text("From Date - To Date");
                    //cell.Cell().Text("Unit");
                    //cell.Cell().Text("Rate");
                    //cell.Cell().Text("Amount");
                    //cell.Cell().Text("Car");
                });
                table.Header(cell =>
                {
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Sr.#").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Item").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Description").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Date").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Qty").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Unit").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Rate").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Amount").FontSize(10);
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text("Car").FontSize(10);
                });

                //    table.
                //    .Border(1)
                //    .BorderColor(Colors.Grey.Medium)
                //    .ColumnsDefinition(columns =>
                //    {
                //        columns.ConstantColumn(25);   // Sr
                //        columns.RelativeColumn(2);    // Description
                //        columns.RelativeColumn(1);    // Date
                //        columns.RelativeColumn(1);    // KM/Hr
                //        columns.RelativeColumn(1);    // Rate
                //        columns.RelativeColumn(1);    // DA
                //        columns.RelativeColumn(1);    // Amount
                //    });

                //// Header Row
                //string[] headers = { "Sr.", "Description", "Date", "K.M/Hr", "Rate", "DA", "Amount" };
                //foreach (var h in headers)
                //    table.Cell().BorderBottom(1).Background(Colors.Grey.Lighten3).Padding(4).Text(h).Bold().FontSize(10);

                //// Items
                int srno = 0;

                List<string> vouchers = new List<string>();

                foreach (var item in _invoice.InvoiceDetail)
                {
                    string voucherNo = item.VoucherDetail==null? "" : item.VoucherDetail.Voucher.VoucherNo;
                    string date = string.Empty;
                    string carName = string.Empty;
                    string itemDesc= string.Empty;

                    bool isVoucherRepeate = voucherNo==""? true : vouchers.Contains(voucherNo);
                    if (!isVoucherRepeate)
                    {
                        vouchers.Add(voucherNo);
                        date = item.VoucherDetail.Voucher.VoucherDate.ToString("dd-MM-yy");
                        carName = item.VoucherDetail.Voucher.Vehicle.VehicleType;
                        itemDesc = item.Description;
                        
                    }
                    else
                    {
                        date = string.Empty;
                        carName = string.Empty;
                        itemDesc = item.Description;
                    }

                    table.Cell().Padding(1).Text(++srno).FontSize(10);
                    table.Cell().Padding(1).Text(item.Item.ItemName).FontSize(10);
                    table.Cell().Padding(1).Text(itemDesc).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(date).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.Item.Quantity.ToString()).FontSize(10);
                    table.Cell().Padding(1).Text(item.Item.Unit).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.Rate.Value.ToString("F2")).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.Amount.Value.ToString("F2")).FontSize(10);
                    table.Cell().Padding(1).Text(carName).FontSize(10);
                }

                //for (int i = srno; i < 17; i++)
                //{
                //    for (int j = 0; j < 9; j++)
                //        table.Cell().Padding(6).Text("");
                //}

                //// Fill remaining empty rows to match template look
                //for (int i = _invoice.Items.Count; i < 8; i++)
                //{
                //    for (int j = 0; j < headers.Length; j++)
                //        table.Cell().Padding(6).Text("");
                //}

                //col.Item().Element(table);
            });
        }

        void composeTotals(ColumnDescriptor col)
        {
            col.Item().PaddingTop(5).Row(r =>
            {
                r.RelativeItem().Text("");
                r.ConstantItem(200).Column(c =>
                {
                    string total = string.Empty;
                    string SGST = string.Empty;
                    string CGST = string.Empty;
                    string IGST = string.Empty;

                    if (this._invoice.Customer.TaxCategory == TaxCategory.GST && this._invoice.Customer.InvoiceFormat == InvoiceFormat.WITH_GST)
                    {
                        total = this._invoice.Total.Value.ToString("F2");
                        SGST = this._invoice.CGST.Value.ToString("F2");
                        CGST = this._invoice.SGST.Value.ToString("F2");
                        IGST = this._invoice.IGST.Value.ToString("F2");
                    }
                    else
                    {
                        total = this._invoice.Amount.ToString("F2");
                        SGST = "0.00";
                        CGST = "0.00";
                        IGST = "0.00";
                    }

                    addTwoColumnText(c, "Total Invoice Amount before tax", total);
                    addTwoColumnText(c, "Add: CGST @2.50", CGST);
                    addTwoColumnText(c, "Add: SGST @2.50", SGST);
                    addTwoColumnText(c, "Add: IGST @5.00", IGST);
                    addTwoColumnText(c, "Total Payable amount", this._invoice.Amount.ToString("F2"), true);
                });
            });
        }


        private void addTwoColumnText(RowDescriptor r, string label, string value, bool isValueFitToScal = false)
        {
            r.AutoItem().PaddingRight(1).AlignLeft().Text(label).FontSize(10).Bold();
            if (isValueFitToScal)
                r.AutoItem().PaddingLeft(1).PaddingRight(1).AlignLeft().Text(value).FontSize(10);
            else
                r.RelativeItem().PaddingLeft(1).AlignLeft().Text(value).FontSize(10);
        }


        private void addTwoColumnText(ColumnDescriptor c, string label, string value, bool bold = false)
        {
            c.Item().Row(r =>
            {
                r.RelativeItem().AlignRight().Text(label).FontSize(10).Bold();
                r.RelativeItem().AlignRight().Text(value).FontSize(10);
            });
        }

        private void composeFooter(IContainer container)
        {
            container.Column(col =>
            {
                composeTotals(col);
                col.Item().PaddingBottom(10);
                col.Item().LineHorizontal(1);
                col.Item().PaddingTop(5).Text($"Bank Name : {_invoice.BankDetail.Bank.BankName}  AccountNo: {_invoice.BankDetail.AccountNumber}  IFSC Code : {_invoice.BankDetail.IFSCCode}").FontSize(10);
                col.Item().Text("NOTIFICATION NO 22/2019 CGST RATE").FontSize(9);
                col.Item().Text("LIABILITY OF GST WILL BE ON THE SERVICE CHARGE MECHANISM").FontSize(9);
                col.Item().Text($"Invoice (Computer Generated) Place of Providing Service: {_invoice.FinancialYear.Company.City}").FontSize(9);
                col.Item().AlignRight().Text("Proprietor").Bold().FontSize(11);
            });
        }
    }
}
