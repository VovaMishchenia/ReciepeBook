   M S B A M L   `   `   `  ����F  BReciepeBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ReciepeBook.View.UserClientReciepeBook.View.UserClient  5   	   ,    &ReciepeBook.View.UserClient.UserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ReciepeBook.View.UserClient     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  
UserWindow��5
   	   $��566.4��6   $��957.2��6+   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��115* �6   �� 5      $
��677* �6    � RowDefinitions 5   
   �� 5      $
��114* �6   �� 5      $
��116* �6   �� 5      $
��112* �6   �� 5      $
��193* �6   .+�5   
   �� $��../../img/main.png��6   $��10 10q�6,    J� Opacity$ .8Q�6;   �� 5   
   -   5        $��tbName��5      $��60(�5      $��1��5      $
��Bold"�5      $��Calibri)�5      
���z���$��Center=�5      $
��0,20q�63   $��74��6A   �� 5   
   -   5         ��Name$
 list��5   0   $��1��6   $��1��6    $��6,0,5,0q�5    <   $��3��6M   ��5   >   �� *
Messages+ �� View 5!      �� 5"      .P�5#      �� $��Від��6%    �� Width$	 250��5$   )    �� CellTemplate 5%      �� 5&      .R�5'   "   �� $
��Bold"�5(   0   ��5'   ,   �� *FromUser.Email+5(   0   5)      5+      �� 5,      $��Рецепт��5.      $	 250��5/       �� DisplayMemberBinding 5-      �� *Reciepe.ReciepeName+5/      �� 50      $��Повідомлення��52      $	 250��53       51      �� *Text+53      54      	 � ContextMenu	 56      �� 57      .@�58      m� -   5        $��Зберегти��58      
���z���$��14(�6J   59      m� 5:      -   5        $��Видалити��5:      
���z���$��14(�6c   m� 5;      -   5        $��Переглянути��5;      
���z���$��14(�6h   5<      5>      �� 5@   
   -   5        $��btnNewMessage��5B      $��1��5@       +  'MaterialDesignFloatingActionLightButton#��[  5C      
���z���
���z���
 � ToolTip$-
 'MaterialDesignFloatingActionLightButton��5F      $��41,29q�65   $
��Auto��6D   $
��Auto��6R   .��5G      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�5H      $��24��5I      $��24��5J      5K      �� 5M   
   -   5        $��2��5M      #��[  5O      
���z���
���z���$-
 'MaterialDesignFloatingActionLightButton��5R      $��41,29q�65   $
��Auto��6D   $
��Auto��6R   .��5S        $ Accounts=�5T      $��24��5U      $��24��5V      5W      �� 5Y   
   -   5        $��
btnRefresh��5]      $��3��5Y      #��[  5Z      
���z���
���z���$-
 'MaterialDesignFloatingActionLightButton��5_      $��41,29,41,109q�65   $
��Auto��6K   $
��Auto��6Y   .��5`        $ Refresh=�5a      $��24��5b      $��24��5c      5d      5f      5g      