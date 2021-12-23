using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DAL.Entity;
using HairShop.View;
using HairShop.Models;
using System.Collections.ObjectModel;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using HairShop.Services;

namespace HairShop.ViewModels
{
    class MakeCheckViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private MakeCheck makecheck;
        public MakeCheckViewModel(MakeCheck makecheck)
        {
            this.makecheck = makecheck;

            db = new DBOperations();

            checkID = db.GetNextCheckID();

            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            HairTypes = new ObservableCollection<HairTypeModel>(db.GetHairTypes());
            ProductTypes = new ObservableCollection<ProductTypeModel>(db.GetProductTypes());
            FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());
            CheckProducts = new ObservableCollection<CheckProductModel>(db.GetCheckProducts(checkID));
            Summa_Itogo = ReCountItog();
        }

        private int checkID;
        public int CheckID
        {
            get { return checkID; }
            set { checkID = value; }
        }


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      makecheck.Close();
                  }));
            }
        }

        private ReCommand select;
        public ReCommand Select_Product
        {
            get
            {
                return select ??
                  (select = new ReCommand(obj =>
                  {
                      FilterProductModel filter = new FilterProductModel(productNameTemplate, selectedBrand, selectedProductType, selectedHairType);
                      FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct(filter));
                      OnPropertyChanged("FilteredProducts");
                  }));
            }
        }

        private ReCommand clear;
        public ReCommand Clear_Filter
        {
            get
            {
                return clear ??
                  (clear = new ReCommand(obj =>
                  {
                      productNameTemplate = null;
                      OnPropertyChanged("productNameTemplate");
                      selectedProductType = null;
                      OnPropertyChanged("selectedProductType");
                      selectedHairType = null;
                      OnPropertyChanged("selectedHairType");
                      selectedBrand = null;
                      OnPropertyChanged("selectedBrand");
                      FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());
                      OnPropertyChanged("FilteredProducts");
                  }));
            }
        }


        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<HairTypeModel> HairTypes { get; set; }
        public ObservableCollection<ProductTypeModel> ProductTypes { get; set; }
        public ObservableCollection<ProductModel> FilteredProducts { get; set; }
        public ObservableCollection<CheckProductModel> CheckProducts { get; set; }


        private string selectedProductName;
        public string SelectedProductName
        {
            get { return selectedProductName; }
            set
            {
                selectedProductName = value;
            }
        }

        
        private CheckProductModel selectedCheckProduct;
        public CheckProductModel SelectedCheckProduct
        {
            get { return selectedCheckProduct; }
            set
            {
                selectedCheckProduct = value;
            }
        }

        private ProductModel selectedProduct;
        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
            }
        }

        public void RefreshCheckProducts()
        {
            CheckProducts = new ObservableCollection<CheckProductModel>(db.GetCheckProducts(checkID));
            OnPropertyChanged("CheckProducts");
            Summa_Itogo = ReCountItog();
            OnPropertyChanged("Summa_Itogo");
            Summa_OddMoney = Summa_Received - Summa_Itogo;
            if (Summa_OddMoney < 0.0M)
                Summa_OddMoney = 0.0M;
            OnPropertyChanged("Summa_OddMoney");
        }

        private BrandModel selectedBrand;
        public BrandModel SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;
            }
        }

        private HairTypeModel selectedHairType;
        public HairTypeModel SelectedHairType
        {
            get { return selectedHairType; }
            set
            {
                selectedHairType = value;
            }
        }

        private ProductTypeModel selectedProductType;
        public ProductTypeModel SelectedProductType
        {
            get { return selectedProductType; }
            set
            {
                selectedProductType = value;
            }
        }

        private string productNameTemplate;
        public string ProductNameTemplate
        {
            get { return productNameTemplate; }
            set { productNameTemplate = value; }
        }

        private decimal summa_itogo;
        public decimal Summa_Itogo
        {
            get { return summa_itogo; }
            set
            {
                summa_itogo = value;
                Summa_OddMoney = Summa_Received - value;
                if (Summa_OddMoney < 0.0M)
                    Summa_OddMoney = 0.0M;
                OnPropertyChanged("Summa_OddMoney");
            }
        }

        private decimal summa_received;
        public decimal Summa_Received
        {
            get { return summa_received; }
            set
            {
                summa_received = value;
                Summa_OddMoney = value - Summa_Itogo;
                if (Summa_OddMoney < 0.0M)
                    Summa_OddMoney = 0.0M;
                OnPropertyChanged("Summa_OddMoney");
            }
        }

        private decimal summa_oddMoney;
        public decimal Summa_OddMoney
        {
            get { return summa_oddMoney; }
            set { summa_oddMoney = value; }
        }

        private ReCommand clear_check;
        public ReCommand Clear_Check
        {
            get
            {
                return clear_check ??
                  (clear_check = new ReCommand(obj =>
                  {
                      for (int ii = 0; ii < CheckProducts.Count; ii++)
                      {
                          Line_of_check loch = db.GetLineOfCheck(checkID, CheckProducts[ii].Product_ID);
                          db.RemoveLineOfChecks(loch);
                      }
                      CheckProducts = new ObservableCollection<CheckProductModel>(db.GetCheckProducts(checkID));
                      OnPropertyChanged("CheckProducts");
                      Summa_Itogo = ReCountItog();
                      OnPropertyChanged("Summa_Itogo");
                      Summa_Received = 0;
                      OnPropertyChanged("Summa_Received");

                      productNameTemplate = null;
                      OnPropertyChanged("productNameTemplate");
                      selectedProductType = null;
                      OnPropertyChanged("selectedProductType");
                      selectedHairType = null;
                      OnPropertyChanged("selectedHairType");
                      selectedBrand = null;
                      OnPropertyChanged("selectedBrand");
                      FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());
                      OnPropertyChanged("FilteredProducts");
                  }));
            }
        }

        private ReCommand edit_checkproduct;
        public ReCommand Edit_CheckProduct
        {
            get
            {
                return edit_checkproduct ??
                  (edit_checkproduct = new ReCommand(obj =>
                  {
                      if (SelectedCheckProduct == null)
                          return;

                      Swapper.CheckID = CheckID;
                      Swapper.ProductID = SelectedCheckProduct.Product_ID;
                      Swapper.ProductName = SelectedCheckProduct.Product_Name;
                      Swapper.ProductUnitPrice = 0;
                      Swapper.ProductQuantity = SelectedCheckProduct.Product_Quantity.ToString();
                      Swapper.ModeAddOrEdit = "edit";
                      AddToCheck frm = new AddToCheck();
                      frm.ShowDialog();

                      CheckProducts = new ObservableCollection<CheckProductModel>(db.GetCheckProducts(checkID));
                      OnPropertyChanged("CheckProducts");
                      Summa_Itogo = ReCountItog();
                      OnPropertyChanged("Summa_Itogo");
                  }));
            }
        }

        private ReCommand delete_checkproduct;
        public ReCommand Delete_CheckProduct
        {
            get
            {
                return delete_checkproduct ??
                  (delete_checkproduct = new ReCommand(obj =>
                  {
                      if (SelectedCheckProduct == null)
                          return;

                      Line_of_check loch = db.GetLineOfCheck(checkID, SelectedCheckProduct.Product_ID);
                      db.RemoveLineOfChecks(loch);
                      CheckProducts = new ObservableCollection<CheckProductModel>(db.GetCheckProducts(checkID));
                      OnPropertyChanged("CheckProducts");
                      Summa_Itogo = ReCountItog();
                      OnPropertyChanged("Summa_Itogo");
                  }));
            }
        }

        private decimal ReCountItog()
        {
            decimal res = 0.0M;
            for (int ii = 0; ii < CheckProducts.Count; ii++)
            {
                List<DiscountModel> discounts = db.GetDiscountsByDateAndProdType(DateTime.Now, CheckProducts[ii].Product_ID);
                decimal sumDiscount = 0.0M;
                if (discounts.Count > 0)
                {
                    for (int jj = 0; jj < discounts.Count; jj++)
                    {
                        CheckProducts[ii].Product_Discount = CheckProducts[ii].Product_Summa * discounts[jj].Discount_amount * 0.01M;
                        sumDiscount += CheckProducts[ii].Product_Discount;
                    }
                }
                CheckProducts[ii].Product_SumItog = CheckProducts[ii].Product_Summa - sumDiscount;
                res += CheckProducts[ii].Product_SumItog;
            }
            return res;
        }


        private ReCommand check_pdf;
        public ReCommand Check_Pdf
        {
            get
            {
                return check_pdf ??
                  (check_pdf = new ReCommand(obj =>
                  {
                      //проверка количество товара на складе
                      for (int ii = 0; ii < CheckProducts.Count; ii++)
                      {
                          Product prod = db.GetProduct(CheckProducts[ii].Product_ID);
                          if (CheckProducts[ii].Product_Quantity > prod.count_stock)
                          {
                              string strMsg = "Количество товара '" + prod.Product_Name + "' (" + CheckProducts[ii].Product_Quantity.ToString()
                                  + " ед.) превышает количество товара на складе. Доступно: " + prod.count_stock.ToString() + " ед.";
                              Swapper.MessageShowText = strMsg;
                              MessageShow frm = new MessageShow();
                              frm.ShowDialog();
                              return;
                          }
                      }
                      //печать чека
                      string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                      var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                      var font = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                      font.Size = 10;
                      var document = new iTextSharp.text.Document();
                      string pdfName = "Чек #" + CheckID.ToString() + ".pdf";
                      using (var writer = PdfWriter.GetInstance(document, new FileStream(pdfName, FileMode.Create)))
                      {
                          document.Open();
                          writer.DirectContent.BeginText();
                          document.Add(new Paragraph("Заказ № " + CheckID.ToString(), font));
                          document.Add(new Paragraph(" ", font));

                          PdfPTable table = new PdfPTable(7);
                          table.WidthPercentage = 100;
                          PdfPCell cell = new PdfPCell(new Paragraph("Название", font));
                          cell.Colspan = 2;
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);
                          cell = new PdfPCell(new Paragraph("Количество", font));
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);
                          cell = new PdfPCell(new Paragraph("Стоимость", font));
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);
                          cell = new PdfPCell(new Paragraph("Сумма без скидки", font));
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);
                          cell = new PdfPCell(new Paragraph("Размер скидки", font));
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);
                          cell = new PdfPCell(new Paragraph("Сумма со скидкой", font));
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);

                          for (int ii = 0; ii < CheckProducts.Count; ii++)
                          {
                              cell = new PdfPCell(new Paragraph(CheckProducts[ii].Product_Name, font));
                              cell.Colspan = 2;
                              cell.Padding = 5;
                              table.AddCell(cell);
                              cell = new PdfPCell(new Paragraph(CheckProducts[ii].Product_Quantity.ToString("N0"), font));
                              cell.HorizontalAlignment = 1;
                              cell.Padding = 5;
                              table.AddCell(cell);
                              cell = new PdfPCell(new Paragraph(CheckProducts[ii].Product_Price.ToString("N2"), font));
                              cell.HorizontalAlignment = 2;
                              cell.Padding = 5;
                              table.AddCell(cell);
                              cell = new PdfPCell(new Paragraph(CheckProducts[ii].Product_Summa.ToString("N2"), font));
                              cell.HorizontalAlignment = 2;
                              cell.Padding = 5;
                              table.AddCell(cell);
                              cell = new PdfPCell(new Paragraph(CheckProducts[ii].Product_Discount.ToString("N2"), font));
                              cell.HorizontalAlignment = 2;
                              cell.Padding = 5;
                              table.AddCell(cell);
                              cell = new PdfPCell(new Paragraph(CheckProducts[ii].Product_SumItog.ToString("N2"), font));
                              cell.HorizontalAlignment = 2;
                              cell.Padding = 5;
                              table.AddCell(cell);

                              db.DecreaseProduct(CheckProducts[ii].Product_ID, CheckProducts[ii].Product_Quantity);
                          }
                          document.Add(table);

                          document.Add(new Paragraph(" ", font));
                          document.Add(new Paragraph("Итог: " + Summa_Itogo.ToString("N2"), font));
                          document.Add(new Paragraph("Получено: " + Summa_Received.ToString("N2"), font));
                          document.Add(new Paragraph("Сдача: " + Summa_OddMoney.ToString("N2"), font));

                          writer.DirectContent.EndText();

                          document.Close();
                          writer.Close();

                          Swapper.MessageShowText = "Покупка произведена. Чек '" + pdfName + "' сохранен.";
                          MessageShow frm = new MessageShow();
                          frm.ShowDialog();
                          System.Diagnostics.Process.Start(pdfName);
                          
                          checkID = db.GetNextCheckID();
                                                   
                          CheckProducts = new ObservableCollection<CheckProductModel>(db.GetCheckProducts(checkID));
                          OnPropertyChanged("CheckProducts");
                          Summa_Itogo = ReCountItog();
                          OnPropertyChanged("Summa_Itogo");
                          Summa_Received = 0;
                          OnPropertyChanged("Summa_Received");

                          productNameTemplate = null;
                          OnPropertyChanged("productNameTemplate");
                          selectedProductType = null;
                          OnPropertyChanged("selectedProductType");
                          selectedHairType = null;
                          OnPropertyChanged("selectedHairType");
                          selectedBrand = null;
                          OnPropertyChanged("selectedBrand");
                          FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());
                          OnPropertyChanged("FilteredProducts");

                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
