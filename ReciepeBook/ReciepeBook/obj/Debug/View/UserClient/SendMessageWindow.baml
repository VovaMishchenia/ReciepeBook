   M S B A M L   `   `   `  ����F  BReciepeBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ReciepeBook.View.UserClientReciepeBook.View.UserClient  5   	   3    -ReciepeBook.View.UserClient.SendMessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ReciepeBook.View.UserClient     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   
�������  � Title$  New Message��5
   	   $	��450��6   $��408.8��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��61* �6   �� 5      $	��90* �6   �� 5      $
��180* �6   �� 5      $	��88* �6   .+�5   
   �� -   5        $
��tbTo��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Кому:��5       %  !MaterialDesignFloatingHintTextBox#��[  5      $��Center=�5      $	��380��5      $��45��5      $	��0,8q�6&   $��2��63   �� 5   
   -   5        $��	cbReciepe��5      $��1��5      $	��380��5      $ Рецепт��5         HintOpacity$	 .26Q�5       $��2��5!   4   ��6   �� *
Reciepes+��5"      �� 5#      .R�5$      �� $��16(�5%       ��5$       �� *ReciepeName+5%       5&      5(      �� 5)   
   -   5        $��tbText��52      $��2��5)      $��2��6    �� TextWrapping$
 Wrap=�5*      $��Stretch=�5+      $	��280��5,       �� AcceptsReturn . $��10,10q�5.      " �� VerticalScrollBarVisibility$
 Auto=�5/       �� 	IsEnabled . $ Повідомлення:��51      52      � 54   
   $��3��6   $
��11,0q�6   .+�55      �� -   5        $��btnSend��5;      
���z��� # MaterialDesignRaisedLightButton#��[ 57      $��40��58      +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 5��59      
 � ToolTip$8
 2MaterialDesignRaisedLightButton with Round Corners��5:      .��5=      ]� .+�5>      �� $��18(�6    $��Відправити��6.   '  !MaterialDesignThemes.Wpf.PackIcon  5?         Kind$ SendCircleOutline=�6.   $��Right=�6G   $��25��6^   $��30��6j   5@      5A      5B      � 5C   
   $��3��6   $��1��6   $
��11,0q�6,   .+�5D      �� -   5        $��	btnCancle��5J      
���z���#��[ 5F      $��40��5G      $	 5��5H      $8
 2MaterialDesignRaisedLightButton with Round Corners��5I      .��5K      �� $��18(�6   $��Відміна��5L      5M      5N      5O      5Q      