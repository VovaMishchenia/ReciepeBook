   M S B A M L   `   `   `  ����F  BReciepeBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ReciepeBook.View.UserClientReciepeBook.View.UserClient  5   	   /    )ReciepeBook.View.UserClient.FriendsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ReciepeBook.View.UserClient     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  FriendsWindow��5   	   
�������$��566.4��5   	   $��1081.7��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��17* �6   �� 5      $	��56* �6    � RowDefinitions 5   
   �� 5      $
��120* �6   �� 5      $	��80* �6   �� 5      $	��90* �6   �� 5      $	��87* �6   �� 5      $
��158* �6   .+�5   
   �� -   5        $��tbName��5      $��72(�5      $
��Bold"�5      $��Calibri)�5      
���z���$��Мої друзі��5      $��Center=�5      $��205,23,0,10q�63   $��87��6H   $��2��6T   �� 5   
   $��../../img/main.png��6   $��10 10q�6,    J� Opacity$ .8Q�6;   �� 5    
   -   5         ��Name$
 list��5    0   $��1��6   $��1��6    $��6,0,5,0q�5!      $��4��6%   ��5    >   �� *	Friends+ �� View 5"      �� 5#      .P�5$      �� $��Ім'я��6%    �� Width$	 200��5%   )    �� CellTemplate 5&      �� 5'      .R�5(   "   �� $
��Bold"�5)   0   ��5(   ,   �� *
User1.Name+5)   0   5*      5,      �� 5-      $��Прізвище��5/      $	 200��50       �� DisplayMemberBinding 5.      �� *User1.Surname+50      �� 51      $��E-mail��53      $	 200��54       52      �� *User1.Email+54      �� 55      $!��Номер телефону��57      $	 150��58       56      �� *User1.PhoneNumber+58      59      	 � ContextMenu	 5;      �� 5<      .@�5=      m� -   5        $1��+Надіслати повідомлення��5=      
���z���$��14(�6q   m� 5>      -   5        $��Видалити��5>      
���z���$��14(�6K   6Y   5?      5A      �� 5B   
   $!��Добавити друга��6   $��1��6*   $��24(�67   
���z���
 �� TextAlignment$
 Center=�5C      $��Center=�6+   $
��Bold"�5D      �� 5E   
   $��2��6   $
��10 0q�6"   .+�5F      �� -   5         ��Name$ tbEmail��5G       (  $MaterialDesignFilledTextFieldTextBox#��[  5H      $	��Top=�5I       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5K      $	��400��5L      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-mail��5M      {�5N      ��  �� Path$ 	IsChecked� �� ElementName$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��5O      � 5P   
   $��3��6   $
��11,0q�6   .+�5Q      �� -   5        $��	btnCancle��5X      
���z��� # MaterialDesignRaisedLightButton#��[ 5T      $��40��5U      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5V       � ToolTip$8 2MaterialDesignRaisedLightButton with Round Corners��5W      .��5Y      �� $��18(�6   $��Добавити��5Z      5[      5\      5^      5_      