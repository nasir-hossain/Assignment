using Assignment.DbContexts;
using Assignment.DTO;
using Assignment.Helper;
using Assignment.IRepository;
using Assignment.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#pragma warning disable
namespace Assignment.Repository
{
    public class AssignmentRepository : IAssignment
    {
        private readonly WriteDbContext _contextW;
        private readonly ReadDbContext _contextR;
        public AssignmentRepository(WriteDbContext contextW, ReadDbContext contextR)
        {
            _contextW = contextW;
            _contextR = contextR;
        }
        public async Task<MessageHelper> CreateItem(ItemDTO create)
        {
            try
            {
                var check = _contextW.TblItem.FirstOrDefault(x => x.StrItemName == create.StrItemName);
                if (check == null)
                {
                    var InsertData = new Models.Write.TblItem()
                    {
                        StrItemName = create.StrItemName,
                        NumStockQuantity = 0,
                        IsActive = true
                    };

                    await _contextW.TblItem.AddAsync(InsertData);
                    await _contextW.SaveChangesAsync();

                    return new MessageHelper()
                    {
                        Message = "Data has been inserted successfully!",
                        statuscode = 200
                    };
                }

                else
                {
                    return new MessageHelper()
                    {
                        Message = "Data already exists!",
                        statuscode = 200
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public async Task<MessageHelper> EditItem(ItemDTO edit)
        {
            try
            {
                var IsExist = _contextW.TblItem.Where(x => x.IntItemId == edit.IntItemId && x.IsActive == true).FirstOrDefault();
                var check = _contextW.TblItem.FirstOrDefault(x => x.StrItemName == edit.StrItemName);
                if (check == null)
                {
                    IsExist.StrItemName = edit.StrItemName;
                    //IsExist.NumStockQuantity = edit.NumStockQuantity;

                    _contextW.TblItem.Update(IsExist);
                    await _contextW.SaveChangesAsync();

                    return new MessageHelper()
                    {
                        Message = "Data has been updated successfully!",
                        statuscode = 200
                    };
                }
                else
                {
                    return new MessageHelper()
                    {
                        Message = "Data already exists!",
                        statuscode = 200
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MessageHelper> CreatePartnerType(PartnerTypeDTO create)
        {
            try
            {
                var check = _contextW.TblPartnerType.FirstOrDefault(x => x.StrPartnerTypeName == create.StrPartnerTypeName);
                if (check == null)
                {
                    var InsertData = new Models.Write.TblPartnerType()
                    {
                        StrPartnerTypeName = create.StrPartnerTypeName,
                        IsActive = true
                    };
                    await _contextW.TblPartnerType.AddAsync(InsertData);
                    await _contextW.SaveChangesAsync();

                    return new MessageHelper()
                    {
                        Message = "Partner type has been created successfully!",
                        statuscode = 200
                    };
                }
                else
                {
                    return new MessageHelper()
                    {
                        Message = "Partner type already exists!",
                        statuscode = 200
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MessageHelper> CreatePartner(PartnerDTO create)
        {
            try
            {
                var InsertData = new Models.Write.TblPartner()
                {
                    StrPartnerName = create.StrPartnerName,
                    IntPartnerTypeId = create.IntPartnerTypeId,
                    IsActive = true
                };

                await _contextW.TblPartner.AddAsync(InsertData);
                await _contextW.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Partner has been Created successfully!",
                    statuscode = 200
                };
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<MessageHelper> CreatePurchase(PurchaseCommonDTO create)
        {
            try
            {
                var Purchase = new Models.Write.TblPurchase()
                {
                    IntSupplierId = create.header.IntSupplierId,
                    DtePurchaseDate = DateTime.Now,

                    IsActive = true
                };

                await _contextW.TblPurchase.AddAsync(Purchase);
                await _contextW.SaveChangesAsync();

                //var PurchaseDetails = new List<TblPurchaseDetails>();

                //foreach (var item in create.row)
                //{
                //    var rowdata = new Models.Write.TblPurchaseDetails()
                //    {
                //        IntPurchaseId = Purchase.IntPurchaseId,
                //        IntItemId = item.IntItemId,
                //        NumItemQuantity = item.NumItemQuantity,
                //        NumUnitPrice = item.NumUnitPrice,
                //        IsActive = true
                //    };
                //    PurchaseDetails.Add(rowdata);
                //}

                //await _contextW.TblPurchaseDetails.AddRangeAsync(PurchaseDetails);

                var rowdata = new Models.Write.TblPurchaseDetails()
                {
                    IntPurchaseId = Purchase.IntPurchaseId,
                    IntItemId = create.row.IntItemId,
                    NumItemQuantity = create.row.NumItemQuantity,
                    NumUnitPrice = create.row.NumUnitPrice,
                    IsActive = true
                };

                await _contextW.TblPurchaseDetails.AddAsync(rowdata);
                await _contextW.SaveChangesAsync();


                var check = _contextW.TblItem.Where(x => x.IntItemId == create.row.IntItemId && x.IsActive == true).FirstOrDefault();

                check.NumStockQuantity  += create.row.NumItemQuantity;

                _contextW.TblItem.Update(check);
                await _contextW.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Item has been Purchased successfully!",
                    statuscode = 200
                };

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MessageHelper> CreateSales(SalesCommonDTO create)
        {
            try
            {
                var check = _contextW.TblItem.Where(x => x.IntItemId == create.row.IntItemId && x.IsActive == true).FirstOrDefault();
                if (create.row.NumItemQuantity > check.NumStockQuantity)
                {
                    return new MessageHelper()
                    {
                        Message = "Stock Limited!",
                        statuscode = 200
                    };
                }
                else
                {
                    var sales = new Models.Write.TblSales()
                    {
                        IntCustomerId = create.header.IntCustomerId,
                        DteSalesDate = DateTime.Now,
                        IsActive = true
                    };
                    await _contextW.TblSales.AddAsync(sales);
                    await _contextW.SaveChangesAsync();

                    //var SalesDetails = new List<TblSalesDetails>();
                    //foreach (var item in create.row)
                    //{
                    //    var rowdata = new Models.Write.TblSalesDetails()
                    //    {
                    //        IntSalesId = sales.IntSalesId,
                    //        IntItemId = item.IntItemId,
                    //        NumItemQuantity = item.NumItemQuantity,
                    //        NumUnitPrice = item.NumUnitPrice,
                    //        IsActive = true
                    //    };

                    //    SalesDetails.Add(rowdata);
                    //}


                    var SalesDetails = new Models.Write.TblSalesDetails()
                    {
                        IntSalesId = sales.IntSalesId,
                        IntItemId = create.row.IntItemId,
                        NumItemQuantity = create.row.NumItemQuantity,
                        NumUnitPrice = create.row.NumUnitPrice,
                        IsActive = true
                    };

                    //await _contextW.TblSalesDetails.AddRangeAsync(SalesDetails);
                    await _contextW.TblSalesDetails.AddAsync(SalesDetails);
                    await _contextW.SaveChangesAsync();


                    var find = _contextW.TblItem.Where(x => x.IntItemId == create.row.IntItemId && x.IsActive == true).FirstOrDefault();
                    find.NumStockQuantity -= create.row.NumItemQuantity;

                    _contextW.TblItem.Update(find);
                    await _contextW.SaveChangesAsync();
                    return new MessageHelper()
                    {
                        Message = "Item has been sold successfully!",
                        statuscode = 200
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ItemWisePurchaseReportDTO>> ItemWiseDailyPurchaseReport(long ItemId)
        {
            try
            {
                var GetDailyReport = await Task.FromResult((from a in _contextR.TblPurchase
                                                            join b in _contextR.TblPurchaseDetails on a.IntPurchaseId equals b.IntPurchaseId
                                                            join c in _contextR.TblItem on b.IntItemId equals c.IntItemId
                                                            join d in _contextR.TblPartner on a.IntSupplierId equals d.IntPartnerId
                                                            where c.IntItemId == ItemId && c.IsActive == true
                                                            && a.IsActive == true && b.IsActive == true
                                                            && a.DtePurchaseDate.Date == DateTime.Now.Date
                                                            group new { a,c,b } by new {a.DtePurchaseDate.Date,c.StrItemName, d.StrPartnerName} into g

                                                            select new ItemWisePurchaseReportDTO()
                                                            {
                                                                PurchaseDate = DateTime.Now.Date,
                                                                itemName = g.Key.StrItemName,
                                                                SupplierName = g.Key.StrPartnerName,
                                                                ItemQuantity = g.Sum(x=>x.b.NumItemQuantity)
                                                            }).ToList());
                return GetDailyReport;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ItemWisePurchaseReportDTO>> ItemWiseMonthlyPurchaseReport(long ItemId)
        {
            try
            {
                var toDate = DateTime.Now;
                var month = new DateTime(toDate.Year, toDate.Month, 1);
                var fromDate = month.Date;

                var GetMonthlyReport = await Task.FromResult((from a in _contextR.TblPurchase
                                                            join b in _contextR.TblPurchaseDetails on a.IntPurchaseId equals b.IntPurchaseId
                                                            join c in _contextR.TblItem on b.IntItemId equals c.IntItemId
                                                            join d in _contextR.TblPartner on a.IntSupplierId equals d.IntPartnerId
                                                            where c.IntItemId == ItemId && c.IsActive == true
                                                            && a.IsActive == true && b.IsActive == true
                                                            && (a.DtePurchaseDate.Date >= fromDate.Date && a.DtePurchaseDate.Date <= toDate.Date)
                                                            group new { a, c, b } by new { a.DtePurchaseDate, c.StrItemName, d.StrPartnerName } into g

                                                            select new ItemWisePurchaseReportDTO()
                                                            {
                                                                PurchaseDate =g.Key.DtePurchaseDate,
                                                                itemName = g.Key.StrItemName,
                                                                SupplierName = g.Key.StrPartnerName,
                                                                ItemQuantity = g.Sum(x => x.b.NumItemQuantity)

                                                            }).ToList());
                return GetMonthlyReport;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async  Task<List<ItemWiseMonthlySalesReportDTO>> ItemWiseMonthlySalesReport(long ItemId)
        {
            try
            {
                var toDate = DateTime.Now;
                var month = new DateTime(toDate.Year, toDate.Month, 1);
                var fromDate = month.Date;

                var getMonthlyReport = await Task.FromResult((from a in _contextR.TblSales
                                                              join b in _contextR.TblSalesDetails on a.IntSalesId equals b.IntSalesId
                                                              join c in _contextR.TblItem on b.IntItemId equals c.IntItemId
                                                              join d in _contextR.TblPartner on a.IntCustomerId equals d.IntPartnerId
                                                              where c.IntItemId == ItemId && c.IsActive == true
                                                              && a.IsActive == true && b.IsActive == true
                                                              && (a.DteSalesDate.Date >= fromDate.Date && a.DteSalesDate.Date <= toDate.Date)
                                                              group new { a, b, c } by new { a.DteSalesDate, c.StrItemName, d.StrPartnerName } into g
                                                              select new ItemWiseMonthlySalesReportDTO()
                                                              {
                                                                  SalesDate =g.Key.DteSalesDate,
                                                                  itemName = g.Key.StrItemName,
                                                                  CustomerName = g.Key.StrPartnerName,
                                                                  ItemQuantity = g.Sum(x=>x.b.NumItemQuantity)

                                                              }).ToList());

                return getMonthlyReport;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<SupplierWiseDailyPurchaseReportDTO>> SupplierWiseDailyPurchaseReport(long supplierId)
        {
            try
            {
                var GetDailyReport = await Task.FromResult((from a in _contextR.TblPurchase
                                                            join b in _contextR.TblPurchaseDetails on a.IntPurchaseId equals b.IntPurchaseId
                                                            join c in _contextR.TblItem on b.IntItemId equals c.IntItemId
                                                            join d in _contextR.TblPartner on a.IntSupplierId equals d.IntPartnerId
                                                            where d.IntPartnerId == supplierId && c.IsActive == true
                                                            && a.IsActive == true && b.IsActive == true
                                                            && a.DtePurchaseDate.Date == DateTime.Now.Date
                                                            group new { a, c, b } by new { a.DtePurchaseDate.Date, c.StrItemName, d.StrPartnerName } into g

                                                            select new SupplierWiseDailyPurchaseReportDTO()
                                                            {
                                                                PurchaseDate = DateTime.Now.Date,
                                                                itemName = g.Key.StrItemName,
                                                                SupplierName = g.Key.StrPartnerName,
                                                                ItemQuantity = g.Sum(x => x.b.NumItemQuantity)
                                                            }).ToList());
                return GetDailyReport;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CustomerWiseMonthlySalesReportDTO>> CustomerWiseMonthlySalesReport(long customerId)
        {
            try
            {
                var toDate = DateTime.Now;
                var month = new DateTime(toDate.Year, toDate.Month, 1);
                var fromDate = month.Date;

                var getMonthlyReport = await Task.FromResult((from a in _contextR.TblSales
                                                              join b in _contextR.TblSalesDetails on a.IntSalesId equals b.IntSalesId
                                                              join c in _contextR.TblItem on b.IntItemId equals c.IntItemId
                                                              join d in _contextR.TblPartner on a.IntCustomerId equals d.IntPartnerId
                                                              where d.IntPartnerId == customerId && c.IsActive == true
                                                              && a.IsActive == true && b.IsActive == true
                                                              && (a.DteSalesDate.Date >= fromDate.Date && a.DteSalesDate.Date <= toDate.Date)
                                                              group new { a, b, c } by new { a.DteSalesDate, c.StrItemName, d.StrPartnerName } into g
                                                              select new CustomerWiseMonthlySalesReportDTO()
                                                              {
                                                                  SalesDate = g.Key.DteSalesDate,
                                                                  itemName = g.Key.StrItemName,
                                                                  CustomerName = g.Key.StrPartnerName,
                                                                  ItemQuantity = g.Sum(x => x.b.NumItemQuantity)

                                                              }).ToList());

                return getMonthlyReport;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
