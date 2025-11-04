using Invoice.Model;
using Invoice.Service;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.PortableExecutable;

namespace Invoice.Handler
{
    public class InvoiceGenerator
    {
        private IInvoiceService _invoiceService;
        private IVoucherService _voucherService;

        public InvoiceGenerator(IInvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
        }

        public void Generate(int invoiceId)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            

            Model.Invoice invoice = this._invoiceService.GetInvoiceForPrint(invoiceId).Result;

            string companyName = invoice.FinancialYear.Company.Name;
            string filePath = Path.Combine($@"\Invoices\{companyName}\{invoiceId}.pdf");

            InvoiceDocument invoiceDocument = new InvoiceDocument(invoice);
            invoiceDocument.GeneratePdf(filePath);

            foreach(VoucherMaster voucher in invoice.Vouchers)
            {
                this._voucherService.UpdateStatus(voucher.Id, VoucherStatus.Invoice_Printed);
            }

            this._invoiceService.UpdateStatus(invoice.Id, VoucherStatus.Invoice_Printed);
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
                page.MarginTop(50);
                page.MarginBottom(50);
                page.MarginLeft(25);
                page.MarginRight(25);
                page.Content().Column(col =>
                {
                    composeHeader(col);
                    composeCustomerInfo(col);
                    composeItemTable(col);
                    composeTotals(col);
                    composeFooter(col);
                    //ComposeCustomerDetails(col);
                    //ComposeItemTable(col);
                    //ComposeTotals(col);
                    //ComposeFooter(col);
                });
            });
        }

        private void composeHeader(ColumnDescriptor col)
        {
            DateTime fromDate = this._invoice.Vouchers.Min(x => x.FromDate);
            DateTime toDate = this._invoice.Vouchers.Max(x => x.ToDate);

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
                    addTwoColumnText(c, "From Date", fromDate.ToString("dd-MM-yy"));
                    addTwoColumnText(c, "To Date", toDate.ToString("dd-MM-yy"));
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
                    c.Item().Text(_invoice.Customer.Name).Bold();
                });
                row.ConstantItem(250).Column(c =>
                {
                    addTwoColumnText(c, "GST No.", _invoice.Customer.GSTNo);
                    addTwoColumnText(c, "Pan No.", _invoice.Customer.PANNo);
                    addTwoColumnText(c, "LUT No.", _invoice.Customer.CessNo);
                });
            });

            col.Item().PaddingTop(10).LineHorizontal(1);
        }

        void composeItemTable(ColumnDescriptor col)
        {
            col.Item().PaddingTop(10);

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
                    cell.Cell().Padding(1).Background(Colors.Grey.Lighten3).Text($"Sr.#{Environment.NewLine}").FontSize(10);
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
                foreach (var item in _invoice.InvoiceDetail)
                {
                    table.Cell().Padding(1).Text(++srno).FontSize(10);
                    table.Cell().Padding(1).Text(item.Item.ItemName).FontSize(10);
                    table.Cell().Padding(1).Text(item.Description).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.VoucherDetail.Voucher.VoucherDate.ToString("dd-MM-yy")).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.Item.Quantity.ToString()).FontSize(10);
                    table.Cell().Padding(1).Text(item.Item.Unit).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.Rate.Value.ToString("F2")).FontSize(10);
                    table.Cell().Padding(1).AlignRight().Text(item.Amount.Value.ToString("F2")).FontSize(10);
                    table.Cell().Padding(1).Text(item.VoucherDetail.Voucher.Vehicle.VehicleType).FontSize(10);
                }

                for (int i = srno; i < 16; i++)
                {
                    for (int j = 0; j < 9; j++)
                        table.Cell().Padding(6).Text("");
                }

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
            col.Item().PaddingTop(10).Row(r =>
            {
                r.RelativeItem().Text("");
                r.ConstantItem(200).Column(c =>
                {
                    addTwoColumnText(c, "Total Invoice Amount before tax", this._invoice.Total.Value.ToString("F2"));
                    addTwoColumnText(c, "Add: CGST @2.50", this._invoice.CGST.Value.ToString("F2"));
                    addTwoColumnText(c, "Add: SGST @2.50", this._invoice.SGST.Value.ToString("F2"));
                    addTwoColumnText(c, "Add: IGST @5.00", this._invoice.IGST.Value.ToString("F2"));
                    addTwoColumnText(c, "Total Payable amount", this._invoice.Amount.ToString("F2"), true);
                });
            });
        }



        private void addTwoColumnText(ColumnDescriptor c, string label, string value, bool bold = false)
        {
            c.Item().Row(r =>
            {
                r.RelativeItem().AlignRight().Text(label).FontSize(10).Bold();
                r.RelativeItem().AlignRight().Text(value).FontSize(10);
            });
        }

        private void composeFooter(ColumnDescriptor col)
        {
            col.Item().PaddingTop(15).Text($"Bank Name : {_invoice.BankDetail.Bank.BankName}  AccountNo: {_invoice.BankDetail.AccountNumber}  IFSC Code : {_invoice.BankDetail.IFSCCode}").FontSize(10);
            col.Item().Text("NOTIFICATION NO 22/2019 CGST RATE").FontSize(9);
            col.Item().Text("LIABILITY OF GST WILL BE ON THE SERVICE CHARGE MECHANISM").FontSize(9);
            col.Item().Text($"Invoice (Computer Generated) Place of Providing Service: {_invoice.FinancialYear.Company.City}").FontSize(9);
            col.Item().AlignRight().Text("Proprietor").Bold().FontSize(11);
        }
    }
}
