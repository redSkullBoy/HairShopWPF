   M S B A M L   `   `   `  ????C  ?HairShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HairShop.ViewHairShop.View  5   	   $    HairShop.View.AddProductSupply   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HairShop.View     5   	     ? Title$;  5Добавление товара в поставку??5   	   $	??273??6.   $	??536??6;    ? WindowStartupLocation$ CenterScreen=?6G    ? 
ResizeMode$ NoResize=?6l   .??5	      ? .+?5
   
   ?? $??0,0,0,0q?6   $??2??6%   ??5      ?? 5       ?? ImageSource$ 	back1.jpg??6   5      ?? 5   
   $$??Название товара:??6   $
??Left=?6+   $??	10,10,0,0q?6F   $	??Top=?6Y   ???#546e7a$
??Bold"?6?   ?? 5   
   $
??Left=?60   $??30??6K   $??	15,34,0,0q?6W    ?? TextWrapping$
 Wrap=?6j   $	??Top=?6~   $	??508??6?    ?? 
IsReadOnly . ???#eceff1???#546e7a$??14(?5   J   ??5      ?? *Product_Name+5   J   ?? 5   
   $(??"Количество товара:??6   $
??Left=?6-   $??	10,69,0,0q?6H   $	??Top=?6[   ???#546e7a$
??Bold"?6?   ?? 5   
   $
??Left=?64   $??30??6O   $??	15,98,0,0q?6[   $
 Wrap=?6n   $	??Top=?6?   $	??261??6?   ???#eceff1???#546e7a$??14(?5   8   ??5      ?? *Product_Quantity+5   8   ?? 5   
   $&?? Стоимость товара:??6   $
??Left=?6,   $??
10,128,0,0q?6G   $	??Top=?6[   ???#546e7a$
??Bold"?6?   ?? 5   
   $
??Left=?61   $??30??6L   $??
15,159,0,0q?6X   $
 Wrap=?6l   $	??Top=?6?   $	??261??6?   ???#eceff1???#546e7a$??14(?5   8   ??5      ?? *Product_Price+5   8   ?? 5   
   $??Добавить??6   $
??Left=?6K   $??109,199,0,0q?6f   $	??Top=?6{   $	??118??6?   ???#eceff1???#546e7a$??28??5   ;   ??5   $   ?? *Add_Product_Supply+5   ;   ?? 5   
   $??Отменить??6   $
??Left=?6B   $??301,199,0,0q?6]   $	??Top=?6r   $	??118??6?   ???#eceff1???#546e7a$??28??5   ;   ??5   $   ?? *	Close_Win+5   ;   5      5      