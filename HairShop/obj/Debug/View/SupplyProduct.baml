   M S B A M L   `   `   `  ????C  ?HairShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HairShop.ViewHairShop.View  5   	   !    HairShop.View.SupplyProduct   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HairShop.View     5   	     ? Title$#  Поставка товара??5   	   $	??480??6!   $	??720??6.    ? WindowStartupLocation$ CenterScreen=?6:   .??5	      ? .+?5
   
   ?? $??0,0,0,0q?6   ??5      ?? 5       ?? ImageSource$ 	back1.jpg??6   5      ?? 5   
   $??Закрыть??6   $??Right=?6A   $??0,15,14.6,0q?6]   $	??Top=?6r   $??90??6?   ???#eceff1???#546e7a$??28??6?   ??6#   ?? *	Close_Win+6?   ?? 5   
   $$??Номер накладной:??6   $
??Left=?6+   $??	15,15,0,0q?6F   $	??Top=?6Y   ???#546e7a$
??Bold"?6?   ?? 5   
   $
??Left=?61   $??
138,15,0,0q?6L    ?? TextWrapping$
 Wrap=?6`   $	??Top=?6t   $	??221??6?   ???#eceff1$??28??5   #   ??5      ?? *NumberInvoice+5   #   ?? 5   
   $??	Дата:??6   $
??Left=?6    $??	18,48,0,0q?6;   $	??Top=?6N   ???#546e7a$
??Bold"?6{   ?? 5   
   $
??Left=?6   $??
138,48,0,0q?6/   $	??Top=?6C   $	??221??6[   ???#eceff1$??28??6v   (  "System.Windows.Controls.DatePicker  5   
   $
??Left=?62   $??
138,48,0,0q?6M   $	??Top=?6a   $	??221??6y   ???#eceff1$??28??5      ???#546e7a   Text 5      ?? *DateInvoice+5   !   ?? 5   
   $??Поставщик:??6   $
??Left=?6%   $??	18,81,0,0q?6@   $	??Top=?6S   ???#546e7a$
??Bold"?6?   ?? 5   
   $??Добавить??6   $
??Left=?6D   $??
372,81,0,0q?6_   $	??Top=?6s   $	??103??6?   ???#eceff1???#546e7a$??28??5   ;   ??5   $   ?? *Add_Product+5   ;   ?? 5   
   $??Удалить??6   $
??Left=?6F   $??
480,81,0,0q?6a   $	??Top=?6u   $??87??6?   ???#eceff1???#546e7a$??28??5   7   ??5   #   ?? *Delete_Product+5   7   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ GridProducts??5         AutoGenerateColumns .  $??Stretch=?5      $??15,126,15,15q?6+   $??Stretch=?5         
IsReadOnly . $??14(?6;   ???#546e7a??5   )   ?? *SupplyProducts+ ?? SelectedItem 6P   ?? *SelectedSupplyProduct+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn
   Header$
 Название??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   ?? *Product_Name+  5!      $
 Количество??6%    6:   ?? *Product_Quantity+  5"      $
 Стоимость??6%    69   ?? *Product_Price+5$      ?? 5%   
   $??Провести??6   $??Right=?6G   $??	0,81,15,0q?6c   $	??top=?6v   $	??120??6?   ???#eceff1???#546e7a$??28??5&   ;   ??5%   $   ?? *Applay_Product+5&   ;   ?? 5'   
    ?? DisplayMemberPath$ Supplier_Name??6   $
??Left=?5(      $??
138,81,0,0q?6(   $	??Top=?6<   $	??221??6T   ???#eceff1$??28??6u   $??14(?5)      ???#546e7a??5'   5   ?? *	Suppliers+ 6X   ?? *SelectedSupplier+5)      5*      5+      