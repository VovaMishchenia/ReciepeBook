   M S B A M L   `   `   `  ����F  BReciepeBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ReciepeBook.View.UserClientReciepeBook.View.UserClient  5   	   3    -ReciepeBook.View.UserClient.ShowMessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ReciepeBook.View.UserClient     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��515.855��5	   0   $��765.311��6A   
�������  � Title  6	   �� *Reciepe.ReciepeName+ � 	Resources 5       �� 
TargetType   Chapter �� Property �� Value  Chapter2��%  &	        &	 D    �� 5   
   " ��6   .�5      ��  � ��$ 22(�6)   �� 5       � ��$ Calibri)�6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       �@��TextAlignment$ Center=�6.   �� 5       � ��
 �z���6+   �� 5       �@��Padding$ 5q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ Calibri)�6+   �� 5       � ��$ 17(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��56* �6   �� 5      $
��429* �6   .+�5!   
   ��  �� Orientation$ 
Horizontal=�6   $��5q�6.   
���z���.+�5"      �� $��30(�6=   $
��Bold"�5#      $��Calibri)�5$      
�������$��Italic$�5&       �� TextAlignment$ Center=�5'      $	��675��5(      ��5"      �� *Reciepe.ReciepeName+5(      5)      �� 5,   
   $��1��6   
�������$��5q�6?   $ Vertical=�5-      .+�5.      �� $ 
Horizontal=�6   .+�5/      �� $��5q�6   $ Vertical=�6(   .+�50      �� $��Інгредієнти��6    #��[  51      $	��267��52      �� 53      $	��150��6   $��0 5 0 0q�6+   $��5q�54      
���z���
�������$��Calibri)�57      $��16(�58      $
��Bold"�59       �� AcceptsReturn . $	��267��5<      	 �� 
IsReadOnly	 . 
 �� TextWrapping$

 Wrap=�5>      " �� VerticalScrollBarVisibility$
 Auto=�5?      ��5;      �� *Reciepe.Ingredients+5?      5@      �� 5B      $��5q�6   $ Vertical=�6(   .+�5C      �� $��Опис��6    #��[  5D      $	��230��5E      �� 5F      $	��150��6!   $��0 5 0 0q�6.   
���z���$	��230��5G   3   .+�5H      ]� $��5q�6$   .+�5I      �� $��Категорія:��6(   #��[ 6:   �� 5J      $��Right=�6(   $��5 0 0 0q�5K   (   #��[ 5L   (   $��Light"�5N   (   ��5M   (   �� *Reciepe.ReciepeType.Name+5N   (   5O      ]� 5P      $��5q�6$   .+�5Q      �� $��Кухня:��6(   #��[ 66   �� 5R      $��Right=�6(   $��5 0 0 0q�5S   (   #��[ 5T   (   $��Light"�5V   (   ��5U   (   �� *Reciepe.Cuisine.Name+5V   (   5W      ]� 5X      $��5q�6$   .+�5Y      �� $��Час:��6(   #��[ 64   �� 5Z      $
��Left=�6(   $��5 0 5 0q�5[   (   #��[ 5\   (   $��Light"�5^   (   ��5]   (   �� *Reciepe.CookingTime+5^   (   �� 5_      $��Right=�6(   $
��хв��6?   $��Light"�5`   (   #��[ 5a   (   5b      ]� 5c      $��5q�6$   .+�5d      �� $��Рейтинг:��6(   #��[ 68   �� 5e      $��Right=�6(   $��5 0 0 0q�5f   (   #��[ 5g   (   $��Light"�5i   (   ��5h   (   �� *Reciepe.Raiting+5i   (   5j      ]� 5k      $��4q�6$   .+�5l      �� $��Калорійність:��6(   #��[ 6=   �� 5m      $��Right=�6(   $��5 0 0 0q�5n   (   #��[ 5o   (   $��Light"�5q   (   ��5p   (   �� *Reciepe.Calories+5q   (   5r      5s      5t      �� 5u      $��5q�6   $ Vertical=�6(   .+�5v      �� $��Повідомлення��6    #��[  5w      $	��220��5x      �� 5y      $	��150��6   $��0 5 0 0q�6+   $��5q�5z      
���z���
�������$��Calibri)�5}      $��16(�5~      $
��Bold"�5       . $	��220��5�      	 . $

 Wrap=�5�      $
 Auto=�5�      ��5�      �� *Text+5�      5�      5�      �� 5�      $��5,5,5,5q�6   
���z���
�������$��Calibri)�5�      $��16(�5�       . $	��210��5�      $��5q�5�      $	��750��5�      	 . $

 Wrap=�5�      $
 Auto=�5�      $
��Bold"�5�      ��5�      �� *Reciepe.Instruction+5�      5�      5�      