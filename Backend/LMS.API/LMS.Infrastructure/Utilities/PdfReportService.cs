using LMS.Application.Dtos.BookDtos;
using LMS.Application.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Utilities
{
    public class PdfReportService : IPdfReportService
    {
        public byte[] GenerateBooksReport(IEnumerable<BookResponseDto> books)
        {
            var bookList = books.ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(c => ComposeTable(c, bookList));
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
                });
            });

            return document.GeneratePdf();
        }

        private void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Text("Library Management System").FontSize(18).Bold();
                column.Item().Text("Book Inventory Report").FontSize(12).FontColor(Colors.Grey.Darken1);
                column.Item().Text($"Generated on {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC")
                    .FontSize(9).FontColor(Colors.Grey.Medium);
                column.Item().PaddingTop(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
            });
        }

        private void ComposeTable(IContainer container, List<BookResponseDto> books)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3); // Title
                    columns.RelativeColumn(2); // Publisher
                    columns.RelativeColumn(2); // Category
                    columns.RelativeColumn(2); // Branch
                    columns.RelativeColumn(1); // Status
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCellStyle).Text("Title");
                    header.Cell().Element(HeaderCellStyle).Text("Publisher");
                    header.Cell().Element(HeaderCellStyle).Text("Category");
                    header.Cell().Element(HeaderCellStyle).Text("Branch");
                    header.Cell().Element(HeaderCellStyle).Text("Status");

                    static IContainer HeaderCellStyle(IContainer c) =>
                        c.DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White))
                         .Background(Colors.Blue.Darken2)
                         .Padding(5);
                });

                foreach (var book in books)
                {
                    table.Cell().Element(BodyCellStyle).Text(book.Title);
                    table.Cell().Element(BodyCellStyle).Text(book.Publisher);
                    table.Cell().Element(BodyCellStyle).Text(book.Category ?? "-");
                    table.Cell().Element(BodyCellStyle).Text(book.Branch ?? "-");
                    table.Cell().Element(BodyCellStyle)
                        .Text(book.IsBorrowed ? "Borrowed" : "Available")
                        .FontColor(book.IsBorrowed ? Colors.Red.Medium : Colors.Green.Medium);

                    static IContainer BodyCellStyle(IContainer c) =>
                        c.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5).PaddingHorizontal(5);
                }
            });

            if (!books.Any())
            {
                container.PaddingTop(20).AlignCenter().Text("No books found.").FontColor(Colors.Grey.Medium);
            }
        }
    }
}
