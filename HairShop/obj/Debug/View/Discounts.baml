   M S B A M L   `   `   `  ????C  ?HairShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HairShop.ViewHairShop.View  5   	       HairShop.View.Discounts   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HairShop.View     5   	     ? Title$  
Акции??5   	   $	??480??6   $	??720??6$    ? WindowStartupLocation$ CenterScreen=?60   .??5	      ? .+?5
   
   ?? $??2??6   ??5      ?? 5       ?? ImageSource$ 	back1.jpg??6   5      ?? 5   
   $??Закрыть??6   $??Right=?6A   $??0,15,14.6,0q?6]   $	??Top=?6r   $??89??6?   ???#eceff1???#546e7a$??28??5   :   ??5   #   ?? *	Close_Win+5   :   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridDiscounts??5         AutoGenerateColumns .  $??Stretch=?5      $??Stretch=?61   $??15,62,15,15q?6M      
IsReadOnly . $??14(?6t   ???#546e7a??5   *   ?? *TableDiscounts+ ?? SelectedItem 6Q   ?? *SelectedDiscount+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название??6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 68   ?? *Discount_Name+  5      $ Процент??6%   	 68   ?? *Discount_amount+  5      $ Дата начала??6%   	 6;   ?? *	D_Start+  5      $! Дата окончания??6%   	 6>   ?? *D_End+5      ?? 5   
   $??Создать акцию??6   $
??Left=?6M   $??	15,15,0,0q?6h   $	??Top=?6{   $	??133??6?   ???#eceff1???#546e7a$??28??5   ;   ??5   )   ?? *Create_Discount+5   ;   ?? 5   
   $ ??Редактировать??6   $
??Left=?6K   $??
153,15,0,0q?6f   $	??Top=?6z   $	??139??6?   ???#eceff1???#546e7a$??28??5   ;   ??5   )   ?? *Edit_Discount+5   ;   ?? 5   
   $??Удалить??6   $
??Left=?6G   $??
297,15,0,0q?6b   $	??Top=?6v   $??99??6?   ???#eceff1???#546e7a$??28??5   ;   
 J? RenderTransformOrigin$
 1.517,0.788&?6G   ??5   #   ?? *Delete_Discount+5   G   5!      5"      