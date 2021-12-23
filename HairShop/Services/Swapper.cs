using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Services
{
    public static class Swapper
    {
        private static int currentUserID;
        public static int CurrentUserID
        {
            get { return currentUserID; }
            set { currentUserID = value; }
        }

        private static int checkID;
        public static int CheckID
        {
            get { return checkID; }
            set { checkID = value; }
        }

        private static int supplyID;
        public static int SupplyID
        {
            get { return supplyID; }
            set { supplyID = value; }
        }

        private static int productID;
        public static int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private static string productName;
        public static string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private static decimal productUnitPrice;
        public static decimal ProductUnitPrice
        {
            get { return productUnitPrice; }
            set { productUnitPrice = value; }
        }

        private static string productQuantity;
        public static string ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }

        private static string modeAddOrEdit;
        public static string ModeAddOrEdit
        {
            get { return modeAddOrEdit; }
            set { modeAddOrEdit = value; }
        }

        private static int discountid;
        public static int DiscountID
        {
            get { return discountid; }
            set { discountid = value; }
        }

        private static DateTime report_datebeg;
        public static DateTime Report_DateBeg
        {
            get { return report_datebeg; }
            set { report_datebeg = value; }
        }

        private static DateTime report_dateend;
        public static DateTime Report_DateEnd
        {
            get { return report_dateend; }
            set { report_dateend = value; }
        }

        private static string messageShowText;
        public static string MessageShowText
        {
            get { return messageShowText; }
            set { messageShowText = value; }
        }

    }
}
