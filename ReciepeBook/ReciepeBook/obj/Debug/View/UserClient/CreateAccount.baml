   M S B A M L   `   `   `  ����F  BReciepeBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ReciepeBook.View.UserClientReciepeBook.View.UserClient  5   	   /    )ReciepeBook.View.UserClient.CreateAccount   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ReciepeBook.View.UserClient     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   
�������  � Title$  CreateAccount��5
   	   $��529.2��6   $	��476��6.   .��5      �  � RowDefinitions 5   
   �� 5      $	��88* �6   �� 5      $	��76* �6   �� 5      $	��76* �6   �� 5      $	��76* �6   �� 5      $	��76* �6   �� 5      $	��76* �6   �� 5      $	��76* �6   .+�5   
   �� $��../../img/main.png��6   $	��0 5q�6,    J� Opacity$ .8Q�69   �� 5   
   $��1��6   $��5q�6"   .+�5      �� -   5        $��tbEmail��5       (  $MaterialDesignFilledTextFieldTextBox#��[  5      $	��Top=�5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5      $	��400��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-mail��5      {�5      ��  �� Path$ 	IsChecked� �� ElementName$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��5       �� 5!   
   $��2��6   $��5q�6"   .+�5"      �� -   5        $��
tbPassword��5#      #��[  5$      $	��Top=�5%       . $
 Wrap=�5'      $	��400��5(      $ Пароль��5)      {�5*      �� $ 	IsChecked�$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��5+      �� 5,   
   $��3��6   $��5q�6"   .+�5-      �� -   5        $��tbName��5.      #��[  5/      $	��Top=�50       . $
 Wrap=�52      $	��400��53      $ Ім'я��54      {�55      �� $ 	IsChecked�$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��56      �� 57   
   $��4��6   $��5q�6"   .+�58      �� -   5        $��	tbSurname��59      #��[  5:      $	��Top=�5;       . $
 Wrap=�5=      $	��400��5>      $ Прізвище��5?      {�5@      �� $ 	IsChecked�$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��5A      �� 5B   
   $��5��6   $��5q�6"   .+�5C      �� -   5         ��Name$ tbPhoneNumber��5D      #��[  5E      $	��Top=�5F       . $
 Wrap=�5H      $	��400��5I      $! Номер телефону��5J      {�5K      �� $ 	IsChecked�$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��5L      � 5M   
   $��6��6   $	��124��5N      .+�5O      �� -   5         # MaterialDesignRaisedLightButton#��[ 5Q      $��50��5R      
���z���+  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 5��5T      
 � ToolTip$8
 2MaterialDesignRaisedLightButton with Round Corners��5U      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�5V      $��-25,8,-17,9q�66   .��5W      �� $$��Зареєструватись��6   5X      5Y      5Z      5[      