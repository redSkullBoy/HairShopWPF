   M S B A M L   `   `   `  ????C  ?HairShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:HairShopHairShop  5   	       HairShop.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:HairShop     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  Authorization??5	   	   $??376.8??6   $	??534??6.   $	??480??6:   $	??720??6J   $	??480??6Y   $	??720??6i    ? WindowStyle$
 None=?5
   	    ? WindowStartupLocation$ CenterScreen=?6    ? 	Resources 5         ButtonClose ?? 
TargetType  MaterialDesignRaisedButton ?? BasedOn ?? Property ?? Value'  !MaterialDesignThemes.Wpf.PackIcon   Kind	 ?? Triggers
 P? Property P? Value??%?  &	        7  ?? 5   
   " ??5   	   8   .?5      ??  ? ?? 5        5      $ CloseBox=?6.   ???#546e7a$??40??6T   $??40??6_   $	??-10q?6k   5      	 5      P? 5      
 ?@J?IsMouseOver . . ?5      ??  ? ?? 5        5      $ Close=?66   ???#eceff1$??45??6X   $??45??6c   $	??-10q?6o   5      5      5      5       .??5"      ? .+?5#   
   ?? $??0,0,-0.4,-0.4q?6   ??5$      ?? 5%       ?? ImageSource$ 	back1.jpg??6   5'      ?? 5(   
   $	??275??6   $??Bottom=?6!   $??146,0,134,103q?6<    ?? RadiusY$ 10??6S    ?? RadiusX$ 10??6`   ???#546e7a J? RenderTransformOrigin$ 1.034,0.152&?6|    J? Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$ 15Q?6#      	Direction$ 0Q?63      RenderingBias$ Quality=?6A      ShadowDepth$ 1Q?6Y      Color$ 	#FFBBBBBB??6i   5,      ?? 5-   
   $??АВТОРИЗАЦИЯ??6   $??Center=?6&   $	??Top=?6C   $??255,116,248.6,0q?6[   ???#eceff1$??25(?6?   $
??Bold"?6?   $??42??6?   $	??210??6?   $ 0.5,0.5&?6?   ?? 5.   
   -   5         ??Name$ NameTextBox??5.      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Login??6'      HintOpacity$ 22Q?5/      ???#eceff1$??176,185,159.6,243.6q?50   "   $
??Bold"?6?   $??22(?6Q    ?? 
CaretBrush ?#546e7a???#546e7a??51      ?? *Login+ ?? UpdateSourceTrigger$ PropertyChanged=?G? 52   
   -   5         G?Name$ PasswordBox??52      $ Password??6+   $ 22Q?53      ???#eceff1 G? 
CaretBrush ?#546e7a$??176,250,159.6,178.6q?54   7   $	??378??55      $??22(?6   ???#546e7a$
??Bold"?6;   ?? 56   
   $
??Left=?6/   $??
623,26,0,0q?6J   $	??Top=?6^   $??52??6v   $??33??6?   $ 0.567,0.607&?6?   #??[  6?   $??22(?6?   ??6   ?? *	Close_Win+??6?   Z? ??6?   Z? ?? 58   
   $??ВХОД??59      ???#546e7a$??275,395,274.6,31.6q?5:      ???#eceff1$ 0.518,-0.331&?6?   $??20(?6d   $
??Auto??6r   ??58      ?? *
Entrance+??6/   ??  ?? ElementName$ PasswordBox??5:   r   5<      5=      