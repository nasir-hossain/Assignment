using Assignment.DTO;
using Assignment.Helper;
using Assignment.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignment _IRepository;
        public AssignmentController(IAssignment IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpPost]
        [Route("CreateItem")]
        public async  Task<MessageHelper> CreateItem(ItemDTO create)
        {
            return await _IRepository.CreateItem(create);
        }

        [HttpPut]
        [Route("EditItem")]
        public async Task<MessageHelper> EditItem(ItemDTO edit)
        {
            return await _IRepository.EditItem(edit);
        }

        [HttpPost]
        [Route("CreatePartnerType")]
        public async Task<MessageHelper> CreatePartnerType(PartnerTypeDTO create)
        {
            return await _IRepository.CreatePartnerType(create);
        }

        [HttpPost]
        [Route("CreatePartner")]
        public async Task<MessageHelper> CreatePartner(PartnerDTO create)
        {
            return await _IRepository.CreatePartner(create);
        }

        [HttpPost]
        [Route("CreatePurchase")]
        public async Task<MessageHelper> CreatePurchase(PurchaseCommonDTO create)
        {
            return await _IRepository.CreatePurchase(create);
        }

        [HttpPost]
        [Route("CreateSales")]
        public async Task<MessageHelper> CreateSales(SalesCommonDTO create)
        {
            return await _IRepository.CreateSales(create);
        }

        [HttpGet]
        [Route("ItemWiseDailyPurchaseReport")]
        public async Task<List<ItemWisePurchaseReportDTO>> ItemWiseDailyPurchaseReport(long ItemId)
        {
            return await _IRepository.ItemWiseDailyPurchaseReport(ItemId);
        }

        [HttpGet]
        [Route("ItemWiseMonthlyPurchaseReport")]
        public async Task<List<ItemWisePurchaseReportDTO>> ItemWiseMonthlyPurchaseReport(long ItemId)
        {
            return await _IRepository.ItemWiseMonthlyPurchaseReport(ItemId);
        }

        [HttpGet]
        [Route("ItemWiseMonthlySalesReport")]
        public async Task<List<ItemWiseMonthlySalesReportDTO>> ItemWiseMonthlySalesReport(long ItemId)
        {
            return await _IRepository.ItemWiseMonthlySalesReport(ItemId);
        }

        [HttpGet]
        [Route("SupplierWiseDailyPurchaseReport")]
        public async Task<List<SupplierWiseDailyPurchaseReportDTO>> SupplierWiseDailyPurchaseReport(long supplierId)
        {
            return await _IRepository.SupplierWiseDailyPurchaseReport(supplierId);
        }

        [HttpGet]
        [Route("CustomerWiseMonthlySalesReport")]
        public async Task<List<CustomerWiseMonthlySalesReportDTO>> CustomerWiseMonthlySalesReport(long customerId)
        {
            return await _IRepository.CustomerWiseMonthlySalesReport(customerId);
        }

    }
}
