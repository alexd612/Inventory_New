   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics  5      P LDataGridFilterLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:DataGridFilterLibrary;assembly=DataGridFilterLibraryDataGridFilterLibrary 5      D @Inventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Inventory	Inventory 5   	      Inventory.Mainwindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   Mdiagnostics5clr-namespace:System.Diagnostics;assembly=WindowsBase      5      UfilterBclr-namespace:DataGridFilterLibrary;assembly=DataGridFilterLibrary      5      )localclr-namespace:Inventory      5   	   -   5          � Title$  
Mainwindow��5   	   $��1207.38��6   $��1082.483��6-    � WindowState$ 	Maximized=�6?    � WindowStartupLocation$ CenterScreen=�6x   $��Calibri)�6�    � Icon$ inventory.png��6�   .��5      � $��0,0,0,-3q�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ scroll_main��5      $��-1,56,-1,-421q�6,   $
��1544��6C   $	��Top=�6Q    J� RenderTransformOrigin$ 0.5,0.5&�6i   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ -0.06Q�6$   �� 5      T� 5       T� X$ 0.499Q�6)   5      ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ 	#FFECECEC��6#    � Offset$ 0.691Q�65   � 5       $ 	#FFCDCECF��6#   $ 0.791Q�65   5!      .��5#      � -   5         �Name$ 	grid_main��5#      $
��Left=�6&   $
��1773��6A   $	��Top=�6O   $
��1006��6g   .+�5$      r� -   5         r�Name$ 
media_load��5$      $��10,10,0,1699q�63   $
��Left=�6l   $	��166��6�   $y�Hidden=�6�    r� Source$ loading.gif?�6�   �� 5%      -   5         ��Name$ image_inventory��5%      $��	0,31,33,0q�61   $��Right=�6D   $	��132��6`   $��inventory.png��6l   $	��111��6�   $	��Top=�6�   5'      �� 5(      -   5         ��Name$ 	grp_count��5(      $��0,25,521,1637q�6.   $��Right=�6E   $	��478��6a   
�������.��5)      � .+�5*      �� -   5         ��Name$ 
lbl_laptop��5*       $��Label��64   $
��Left=�6D   $��8,12,0,0q�6_   $	��Top=�6q   $��14(�6�   $
��Bold"�6�   �� 5+      -   5        $ lbl_laptop_back��5+       $��Label��69   $
��Left=�6I   $��
220,12,0,0q�6d   $	��Top=�6x   $��14(�6�   $
��Bold"�6�   �� 5,      -	   5        $ lbl_desktop��5,       $��Label��65   $
��Left=�6E   $��8,40,0,0q�6`   $	��Top=�6r   $��14(�6�   $
��Bold"�6�   �� 5-      -
   5        $ lbl_desktop_back��5-       $��Label��6:   $
��Left=�6J   $��
220,40,0,0q�6e   $	��Top=�6y   $��14(�6�   $
��Bold"�6�   $ 0.451,0.463&�6�   �� 5.      -   5        $ lbl_printer��5.       $��Label��65   $
��Left=�6E   $��8,67,0,0q�6`   $	��Top=�6r   $��14(�6�   $
��Bold"�6�   5/      51      &   System.Windows.Controls.DataGrid  56      -   5          Name$ dg_inventory��5>   H   $	��560��6^   $��4,190,187,0q�6k   $	��Top=�6�      
IsReadOnly . $��Calibri)�6�   $��16(�6�      GridLinesVisibility$
 None=�6�      ColumnHeaderStyle 57      �� *��  �� TypeInTargetAssembly7  1DataGridFilterLibrary.DataGridHeaderFilterControl"   �� 
ResourceId$&  DataGridHeaderFilterControlStyle��+��5>      ��  �� BindsDirectlyToSource . ��6A  Z� ��6W  Z�  � ContextMenu 5?      �� 5@      .@�5A      m� -   5        $
��Edit��5A   '   65   5B      5F        5G      -   5        $ 
dg_history��5G   N   $	��205��6b   $��9,1188,187,0q�6o   $	��Top=�6�    . $��Calibri)�6�   $��16(�6�   $
 None=�6
  ��6   ��  . ��6%  Z� ��6;  Z� 5I        5J      -   5        $ dg_field_equipment��5J   N   $	��302��6j   $��-5,850,201,0q�6w   $	��Top=�6�   $��16(�6�    . $
 None=�6  ��6   ��  . ��6   Z� ��66  Z�  5K      �� 5L      .@�5M      m� -   5        $
��Edit��5M   '   65   5N      5R      5S      5X      � 5Y   
   $��56��6   $	��Top=�6   ���	#FFA8A8A8.+�5Z      �� -   5         ��Name$ btn_new_equip��5Z      $��53��6,   $��58��68   $��0,3,0,0q�6�   $
��Left=�6�   ��6C   Z� ��6u   Z� .��5\      �� $��44��6   $��51��6%   $��add.png��60   5`      �� 5a      -   5        $ 
btn_export��5a      $��53��6)   $��56��65   $��63,3,0,0q�6�   $
��Left=�6�   ��6@   Z� ��6V   Z� .��5b      �� $��
export.png��6   $��40��6,   5d      �� 5e      -   5        $ 
btn_search��5e      $��49��6)   $��	124,3,0,3q�6{   $
��Left=�6�   ��64   Z� ��6K   Z� .��5g      �� $��44��6   $��49��6%   $��magnifier.png��60   5k      5l      5o      5p      