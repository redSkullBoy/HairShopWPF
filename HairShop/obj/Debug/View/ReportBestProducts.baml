   M S B A M L   `   `   `  ????C  ?HairShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HairShop.ViewHairShop.View  5   	   &     HairShop.View.ReportBestProducts   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HairShop.View     5   	     ? Title$P  JОтчёт о наиболее востребованных товарах??5   	   $	??206??69   $	??414??6F    ? WindowStartupLocation$ CenterScreen=?6R    ? 
ResizeMode$ NoResize=?6w   .??5	      ? .+?5
   
   ?? $??0,0,0,0q?6   $??2??6%   ??5      ?? 5       ?? ImageSource$ 	back1.jpg??6   5      ?? 5   
   $
??Left=?6   $??
170,63,0,0q?6/   $	??Top=?6C   $	??222??6[   $??28??6g   ???#eceff16s   (  "System.Windows.Controls.DatePicker  5   
   $
??Left=?6=   $??
170,63,0,0q?6X   $	??Top=?6l   $	??222??6?   ???#eceff1???#546e7a$??28??5   9      SelectedDate 5      ?? *Report_DateEnd+5   9   ?? 5   
   $
??Left=?6   $??
170,25,0,0q?6/   $	??Top=?6C   $	??222??6[   $??28??6g   ???#eceff16s     5   
   $
??Left=?6=   $??
170,25,0,0q?6X   $	??Top=?6l   $	??222??6?   ???#eceff1???#546e7a$??28??5   9    5      ?? *Report_DateBeg+5   9   ?? 5   
   $"??Начало периода:??6   $
??Left=?6*   $??	15,25,0,0q?6E   $	??Top=?6X   $??14(?6p   ???#546e7a$
??Bold"?6?   ?? 5   
   $(??"Окончание периода:??6   $
??Left=?6-   $??	15,63,0,0q?6H   $	??Top=?6[   $??14(?6s   ???#546e7a$
??Bold"?6?   ?? 5   
   $)??#Сформировать отчет??6   $??Right=?6Q   $??0,118,107,0q?6m   $	??Top=?6?   $	??193??6?   ???#eceff1???#546e7a$??28??5   7   ??5   .   ?? *Report_Forming+5   7   5      5      