using Assignment.DTO;
using Assignment.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.IRepository
{
    public interface IAssignment
    {
        public Task<MessageHelper> CreateItem(ItemDTO create);
        public Task<MessageHelper> EditItem(ItemDTO edit);
        public Task<MessageHelper> CreatePartnerType(PartnerTypeDTO create);
        public Task<MessageHelper> CreatePartner(PartnerDTO create);
        public Task<MessageHelper> CreatePurchase(PurchaseCommonDTO create);
        public Task<MessageHelper> CreateSales(SalesCommonDTO create);
        public Task<List<ItemWisePurchaseReportDTO>> ItemWiseDailyPurchaseReport(long ItemId);
        public Task<List<ItemWisePurchaseReportDTO>> ItemWiseMonthlyPurchaseReport(long ItemId);
        public Task<List<ItemWiseMonthlySalesReportDTO>> ItemWiseMonthlySalesReport(long ItemId);
        public Task<List<SupplierWiseDailyPurchaseReportDTO>> SupplierWiseDailyPurchaseReport(long supplierId);
        public Task<List<CustomerWiseMonthlySalesReportDTO>> CustomerWiseMonthlySalesReport(long customerId);




    }
}
