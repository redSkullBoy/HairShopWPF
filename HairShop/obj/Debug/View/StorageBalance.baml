   M S B A M L   `   `   `  ����C  ?HairShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HairShop.ViewHairShop.View  5   	   "    HairShop.View.StorageBalance   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:HairShop.View     5   	     � Title$:  4Просмотр складских остатков��5   	   $	��508��6-   $	��720��6:    � WindowStartupLocation$ CenterScreen=�6F   .��5	      � .+�5
   
   �� $��0,0,0,0q�6   ��5      �� 5       �� ImageSource$ 	back1.jpg��6   5      �� 5   
    �� DisplayMemberPath$ Product_Type_Name��6   $
��Left=�5      $��	15,25,0,0q�6.   $	��Top=�6A   $	��180��6Y   ���#eceff1$��28��6z   $��14(�5      ���#546e7a��5   9   �� *ProductTypes+ �� SelectedItem 6_   �� *SelectedProductType+5   !   �� 5   
   $ Hair_Type_Name��6   $
��Left=�5      $��
200,25,0,0q�6.   $	��Top=�6B   $	��180��6Z   ���#eceff1$��28��6{   $��14(�5      ���#546e7a��5   6   �� *	HairTypes+ 6X   �� *SelectedHairType+5   !   �� 5   
   $ 
Brand_Name��6   $
��Left=�5      $��
385,25,0,0q�6.   $	��Top=�6B   $	��180��6Z   ���#eceff1$��28��6{   $��14(�5      ���#546e7a��5   2   �� *Brands+ 6Q   �� *SelectedBrand+5   !   �� 5   
   $
��Left=�67   $��	15,68,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $	��Top=�5      $	��340��6*   ���#eceff1$��28��6K   $��14(�6W   ���#546e7a��5      �� *ProductNameTemplate+5   e   �� 5   
   $��
Поиск��6   $
��Left=�6D   $��
360,68,0,0q�6_   $	��Top=�6s   $	��100��6�   $��28��6�   ���#eceff1���#546e7a��6!   �� *Select_Product+5   &   �� 5   
   $��Очистить��6   $
��Left=�6E   $��
465,68,0,0q�6`   $	��Top=�6t   $	��100��6�   $��28��6�   ���#eceff1���#546e7a��6$   �� *Clear_Filter+5   &   �� 5   
   $��Закрыть��6   $��Right=�6A   $��	0,15,15,0q�6]   $	��Top=�6p   $	��100��6�   ���#eceff1���#546e7a$��28��6�   ��6#   �� *	Close_Win+6�   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ GridProducts��5          AutoGenerateColumns .  $��Stretch=�5!      $��15,110,15,15q�6+   $��Stretch=�5"         
IsReadOnly . $��14(�6;   ���#546e7a��5    )   �� *FilteredProducts+ 6R   �� *SelectedProduct+	   Columns	 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Название��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Product_Name+  5%      $
 
Объём��6%    66   �� *volume+  5&      $
 Стоимость��6%    69   �� *
unit_price+  5'      $
 Количество��6%    6:   �� *count_stock+5)      �� 5*   
   $��Тип товара:��6   $
��Left=�6&   $��15,4,0,0q�6A   $	��Top=�6S   $��11(�6k   ���#546e7a6y   �� 5+   
   $��Тип волос:��6   $
��Left=�6%   $��	200,4,0,0q�6@   $	��Top=�6S   $��11(�6k   ���#546e7a6y   �� 5,   
   $��Бренд:��6   $
��Left=�6!   $��	385,4,0,0q�6<   $	��Top=�6O   $��11(�6g   ���#546e7a6u   �� 5-   
   $��Название:��6   $
��Left=�6$   $��	15,48,0,0q�6?   $	��Top=�6R   $��11(�6j   ���#546e7a$��20��6�   5.      5/      