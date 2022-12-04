using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booking.System.Application.ShiftsRequests;
using Booking.System.Application.ShiftsRequests.DTO;
using Booking.System.Application.ShiftRequests.DTO;
using OfficeOpenXml;

namespace Booking.System.WebApi.Controllers
{
    [ApiController]
    [Route("api/shiftrequest")]
    public class ShiftRequestController : ApiController
    {
        private readonly IShiftRequestRepository _repository;

        public ShiftRequestController(IMediator mediator, IShiftRequestRepository repository)
            : base(mediator)
        {
            _repository = repository;
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

        [HttpGet("all")]
        public async Task<ActionResult<AllShiftRequestsDto>> GetAllShiftRequests()
        {
            var result = await _repository.GetAllShiftRequests();
            return Ok(result);
        }

        [HttpGet("current")]
        public async Task<ActionResult<AllShiftRequestsDto>> GetCurrentShiftRequests()
        {
            var result = await _repository.GetShiftsTodayDate();
            return Ok(result);
        }

        [HttpGet("all/excel")]
        public async Task<ActionResult> ExportExcel()
        {
            var result = await _repository.GetAllShiftRequests();

            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"~\documents\test.xlsx"))) 
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("test");// Создать лист

                worksheet.Cells[1, 1].Value = "Наименование лагеря";
                worksheet.Cells[1, 2].Value = "Название смены";
                worksheet.Cells[1, 3].Value = "Тип смены";
                worksheet.Cells[1, 4].Value = "Количество мест";
                worksheet.Cells[1, 5].Value = "Количество занятых мест";
                worksheet.Cells[1, 6].Value = "Количество свободных мест";

                for (int i = 0; i < result.ShortShiftRequests.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = result.ShortShiftRequests[i].CampName;
                    worksheet.Cells[i + 2, 2].Value = result.ShortShiftRequests[i].ShiftName;
                    worksheet.Cells[i + 2, 3].Value = result.ShortShiftRequests[i].ShiftType;
                    worksheet.Cells[i + 2, 4].Value = result.ShortShiftRequests[i].PlacesCount;
                    worksheet.Cells[i + 2, 5].Value = result.ShortShiftRequests[i].BusyPlacesCount;
                    worksheet.Cells[i + 2, 6].Value = 
                        result.ShortShiftRequests[i].PlacesCount - result.ShortShiftRequests[i].BusyPlacesCount;
                }

                package.Save();/// Создать лист
            }

            return Ok();
        }
        //[HttpGet]
        //public async Task<ActionResult> GetFreeShifts()
        //{

        //}

    }
}