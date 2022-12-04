using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booking.System.Application.ShiftsRequests;
using Booking.System.Application.ShiftsRequests.DTO;
using Booking.System.Application.ShiftRequests.DTO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/shiftrequest")]
    public class ShiftRequestController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IShiftRequestRepository _repository;

        public ShiftRequestController(IMediator mediator, IShiftRequestRepository repository, IWebHostEnvironment hostingEnvironment)
            : base(mediator)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Создать заявку в лагерь
        /// </summary>
        /// <param name="createRequestDto"></param>
        /// <returns></returns>
        [HttpPost("createrequest")]
        public async Task<ActionResult<GetShiftRequestDto>> CreateRequest(CreateRequestDto createRequestDto)
        {
            var cardsResult = await _repository.CreateRequest(createRequestDto);

            return Ok(cardsResult);
        }

        /// <summary>
        /// Получить данные о всех сменах и их заполненности
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<AllShiftRequestsDto>> GetAllShiftRequests()
        {
            var result = await _repository.GetAllShiftRequests();
            return Ok(result);
        }

        /// <summary>
        /// Получить данные о действующих сменах и их заполненности
        /// </summary>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<ActionResult<AllShiftRequestsDto>> GetCurrentShiftRequests()
        {
            var result = await _repository.GetShiftsTodayDate();
            return Ok(result);
        }

        [HttpGet("datacharts")]
        public async Task<ActionResult<VisualDataVm>> GetMonthData()
        {
            var result = await _repository.GetMonthsShifts();
            return Ok(result);
        }

        [HttpGet("all/excel")]
        public async Task<ActionResult> ExportExcel()
        {
            string sWebRootFolder = _hostingEnvironment.ContentRootPath;

            var date = DateTime.Now.ToString("YYYYMMddhhmmss");
            string sFileName = @$"documentsExport\shifts_statistics{date}.xlsx";

            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);

            var path = sWebRootFolder + sFileName;

            Directory.CreateDirectory(sWebRootFolder + "documentsExport");

            FileInfo file = new FileInfo(path);

            var memory = new MemoryStream();

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();

                ISheet excelSheet = workbook.CreateSheet("Статистика");

                var result = await _repository.GetAllShiftRequests();

                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("Номер");
                row.CreateCell(1).SetCellValue("Наименование лагеря");
                row.CreateCell(2).SetCellValue("Название смены");
                row.CreateCell(3).SetCellValue("Тип смены");
                row.CreateCell(4).SetCellValue("Дата начала");
                row.CreateCell(5).SetCellValue("Дата окончания");
                row.CreateCell(6).SetCellValue("Количество мест");
                row.CreateCell(7).SetCellValue("Количество занятых мест");
                row.CreateCell(8).SetCellValue("Количество свободных мест");

                for (int i = 0; i < result.ShortShiftRequests.Count; i++)
                {
                    row = excelSheet.CreateRow(i + 1);

                    row.CreateCell(0).SetCellValue(i + 1);
                    row.CreateCell(1).SetCellValue(result.ShortShiftRequests[i].CampName);
                    row.CreateCell(2).SetCellValue(result.ShortShiftRequests[i].ShiftName);
                    row.CreateCell(3).SetCellValue(result.ShortShiftRequests[i].ShiftType);
                    row.CreateCell(4).SetCellValue(result.ShortShiftRequests[i].DateStart);
                    row.CreateCell(5).SetCellValue(result.ShortShiftRequests[i].DateEnd);
                    row.CreateCell(6).SetCellValue(result.ShortShiftRequests[i].PlacesCount);
                    row.CreateCell(7).SetCellValue(result.ShortShiftRequests[i].BusyPlacesCount);
                    row.CreateCell(8)
                        .SetCellValue(result.ShortShiftRequests[i].PlacesCount - result.ShortShiftRequests[i].BusyPlacesCount);
                }
                excelSheet.AutoSizeColumn(0);
                excelSheet.AutoSizeColumn(1);
                excelSheet.AutoSizeColumn(2);
                excelSheet.AutoSizeColumn(3);
                excelSheet.AutoSizeColumn(4);
                excelSheet.AutoSizeColumn(5);
                excelSheet.AutoSizeColumn(6);
                excelSheet.AutoSizeColumn(7);
                excelSheet.AutoSizeColumn(8);
                workbook.Write(fs, false);
            }

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }

        /// <summary>
        /// Экспорт в excel данных о действующих сменах и их заполненности
        /// </summary>
        /// <returns></returns>
        [HttpGet("excel/today")]
        public async Task<IActionResult> ExportToday()
        {
            string sWebRootFolder = _hostingEnvironment.ContentRootPath;

            var date = DateTime.Now.ToString("YYYYMMddhhmmss");
            string sFileName = @$"documentsExport\shifts_statistics{date}.xlsx";

            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);

            var path = sWebRootFolder + sFileName;

            Directory.CreateDirectory(sWebRootFolder + "documentsExport");

            FileInfo file = new FileInfo(path);

            var memory = new MemoryStream();

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();

                ISheet excelSheet = workbook.CreateSheet("Статистика");

                var result = await _repository.GetShiftsTodayDate();

                IRow row = excelSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("Номер");
                row.CreateCell(1).SetCellValue("Наименование лагеря");
                row.CreateCell(2).SetCellValue("Название смены");
                row.CreateCell(3).SetCellValue("Тип смены");
                row.CreateCell(4).SetCellValue("Дата начала");
                row.CreateCell(5).SetCellValue("Дата окончания");
                row.CreateCell(6).SetCellValue("Количество мест");
                row.CreateCell(7).SetCellValue("Количество занятых мест");
                row.CreateCell(8).SetCellValue("Количество свободных мест");

                for (int i = 0; i < result.ShortShiftRequests.Count; i++)
                {
                    row = excelSheet.CreateRow(i + 1);

                    row.CreateCell(0).SetCellValue(i + 1);
                    row.CreateCell(1).SetCellValue(result.ShortShiftRequests[i].CampName);
                    row.CreateCell(2).SetCellValue(result.ShortShiftRequests[i].ShiftName);
                    row.CreateCell(3).SetCellValue(result.ShortShiftRequests[i].ShiftType);
                    row.CreateCell(4).SetCellValue(result.ShortShiftRequests[i].DateStart);
                    row.CreateCell(5).SetCellValue(result.ShortShiftRequests[i].DateEnd);
                    row.CreateCell(6).SetCellValue(result.ShortShiftRequests[i].PlacesCount);
                    row.CreateCell(7).SetCellValue(result.ShortShiftRequests[i].BusyPlacesCount);
                    row.CreateCell(8)
                        .SetCellValue(result.ShortShiftRequests[i].PlacesCount - result.ShortShiftRequests[i].BusyPlacesCount);
                }
                excelSheet.AutoSizeColumn(0);
                excelSheet.AutoSizeColumn(1);
                excelSheet.AutoSizeColumn(2);
                excelSheet.AutoSizeColumn(3);
                excelSheet.AutoSizeColumn(4);
                excelSheet.AutoSizeColumn(5);
                excelSheet.AutoSizeColumn(6);
                excelSheet.AutoSizeColumn(7);
                excelSheet.AutoSizeColumn(8);

                workbook.Write(fs, false);
            }

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
}