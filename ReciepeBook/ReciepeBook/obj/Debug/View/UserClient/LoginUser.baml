   M S B A M L   `   `   `  ����F  BReciepeBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ReciepeBook.View.UserClientReciepeBook.View.UserClient  5   	   +    %ReciepeBook.View.UserClient.LoginUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ReciepeBook.View.UserClient     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  	LoginUser��5
   	   $��506.4��6   $	��326��6*   .��5      �  � RowDefinitions 5   
   �� 5      $	��60* �6   �� 5      $	��86* �6   �� 5      $	��86* �6   �� 5      $	��94* �6   �� 5      $	��93* �6   .+�5   
   �� $��../../img/main.png��6   $	��0 5q�6,    J� Opacity$ .8Q�69   �� 5   
   $��1��6   $��5q�6"   .+�5      �� -   5         ��Name$ tbemail��5       (  $MaterialDesignFilledTextFieldTextBox#��[  5      $	��Top=�5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5      $	��400��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-mail��5      {�5      ��  �� Path$ 	IsChecked� �� ElementName$9 3MaterialDesignFilledTextFieldTextBoxEnabledComboBox��5      �� 5   
   $��2��6   $��5q�6"   .+�5       G� -   5        $��
tbPassword��5!       0 ,MaterialDesignFilledPasswordFieldPasswordBox#��[ 5"      $	��Top=�5#      $ Пароль��5%      {�5$      �� $ 	IsChecked�$A ;MaterialDesignFilledPasswordFieldPasswordBoxEnabledComboBox��5%      5&      � 5'   
   $��3��6   $	��124��5(      .+�5)      �� -   5         # MaterialDesignRaisedLightButton#��[ 5+      $��50��5,      
���z���+  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 5��5.      
 � ToolTip$8
 2MaterialDesignRaisedLightButton with Round Corners��5/      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�50      .��51      �� $��Вхід��6   52      53      �� 54   
   $��4��6   $
��5 10q�6"   .+�55      �� $��16(�6   
���  �� �� TextAlignment$
 Left=�56      �� 57      -   5        $��btnCreateAcc��5=      $
��0 10q�58      
���z���   MaterialDesignOutlinedButton#��[ 5:      $"
 MaterialDesignOutlinedButton��5;      
���z���.��5>   ,   !Створити аккаунт5@      5A      5B      5C      