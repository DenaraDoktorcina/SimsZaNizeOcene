   M S B A M L   `   `   `  ����K  GHotelsManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:HotelsManagerApp.View.AdminViewHotelsManagerApp.View.AdminView  5   	   <    6HotelsManagerApp.View.AdminView.RegisterNewOwnerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:HotelsManagerApp.View.AdminView     5   	     � Title$  RegisterNewOwnerWindow��5   	   $	��450��6(   $	��800��65    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��JMBG:��6   $��25(�6!   $��0��6/   $��0��6?   �� 5   
   $��Email:��6   $��25(�6"   $��0��60   $��1��6@   �� 5   
   $��	Password:��6   $��25(�6%   $��0��63   $��2��6C   �� 5   
   $��Name:��6   $��25(�6!   $��0��6/   $��3��6?   �� 5   
   $��Surname:��6   $��25(�6$   $��0��62   $��4��6B   �� 5   
   $��Telephone number:��6   $��25(�6-   $��0��6;   $��5��6K   �� 5!   
   $��1��65   $��0��6E   $��3q�6R   
���   ���6   �� *Jmbg+ �� Mode$ TwoWay=�6]   �� 5"   
   $��1��66   $��1��6F   $��3q�6S   
���   ���6   �� *Email+$ TwoWay=�6^   �� 5#   
   $��1��69   $��2��6I   $��3q�6V   
���   ���6   �� *
Password+$ TwoWay=�6a   �� 5$   
   $��1��65   $��3��6E   $��3q�6R   
���   ���6   �� *Name+$ TwoWay=�6]   �� 5%   
   $��1��68   $��4��6H   $��3q�6U   
���   ���6   �� *	Surname+$ TwoWay=�6`   �� 5&   
   $��1��6@   $��5��6P   $��3q�6]   
���   ���6   �� *TelephoneNumber+$ TwoWay=�6h   �� 5(   
   $��Cancel��6   $��3q�6"   $��6��6-   $��0��6:   $��30��6l   $��Bottom=�6x   ��6J   �� *CancelCommand+��6�   ��  �� RelativeSource ��  �� AncestorType
 Window�� 5)   
   $��Submit��6   $��3q�6"   $��6��6-   $��1��6:   $��30��6l   $��Bottom=�6x   ��6J   �� *SubmitCommand+��6�   ��  �� 
 Window5*      5+      