   M S B A M L   `   `   `  ����K  GHotelsManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:HotelsManagerApp.View.AdminViewHotelsManagerApp.View.AdminView  5   	   4    .HotelsManagerApp.View.AdminView.NewHotelWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:HotelsManagerApp.View.AdminView     5   	     � Title$  NewHotelWindow��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Name:��6   $��0��6!   $��0��6.   $��25(�6>   �� 5   
   $��Year of construction:��6   $��1��61   $��0��6>   $��25(�6N   �� 5   
   $��Number of stars:��6   $��2��6,   $��0��69   $��25(�6I   �� 5   
   $��Owners JMBG:��6   $��3��6(   $��0��65   $��25(�6E   �� 5   
   $��1��65   $��0��6E   
���   �$��3q�6f   ��6   �� *Name+ �� Mode$ TwoWay=�6f   �� 5   
   $��1��6A   $��1��6Q   
���   �$��3q�6r   ��6   �� *ConstructionYear+$ TwoWay=�6r   �� 5    
   $��1��6<   $��2��6L   
���   �$��3q�6m   ��6   �� *StarsNumber+$ TwoWay=�6m   �� 5!   
   $��1��6   $��3��6#   $��3q�60   ��5"      �� *OwnersJmbgList+ �� SelectedItem 5#      �� *SelectedOwnerJmbg+$ TwoWay=���5$      �� 5%      .R�5&      �� ��5'      `� 5(       �� StringFormat$ 	{0} ({1})��6+   .1�5)   "   ��  �� Path$
 Name�6*   �� 5*   "   $
 Jmbg�6*   5+      5-      5.      50      �� 53   
   $��5��6   $��0��6   $��Cancel��6.   $��5q�6a   $��40��6l   $��Bottom=�6x   ��6?   �� *CancelCommand+��6�   ��  �� RelativeSource �� 	 �� AncestorType
	 Window�� 54   
   $��5��6   $��1��6   $��Submit��6.   $��5q�6a   $��40��6l   $��Bottom=�6x   ��6?   �� *SubmitCommand+��6�   ��  �� 
	 Window55      56      