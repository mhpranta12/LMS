using LMS.Application.Dtos.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Interfaces
{
    public interface IPdfReportService
    {
        byte[] GenerateBooksReport(IEnumerable<BookResponseDto> books);
    }
}
