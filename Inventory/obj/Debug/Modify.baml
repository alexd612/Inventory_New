   M S B A M L   `   `   `  ����D  @Inventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Inventory	Inventory  5   	       Inventory.Modify   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Inventory     5   	   -   5          � Title$  Modify��5   	   $��491.913��6   $��432.134��6)    � WindowStartupLocation$ CenterScreen=�69    � 
ResizeMode$ NoResize=�6^    � Icon$ inventory.png��6�   .��5	      � -   5         �Name$ grid_modify��5	      .+�5
   
   �� $��Serial Number:��6   $
��Left=�6)   $��	10,19,0,0q�6D   $	��Top=�6W   $��Calibri)�6o   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Equipment Type:��6   $
��Left=�6*   $��9,52,0,0q�6E   $	��Top=�6W    J� RenderTransformOrigin$ 0.553,0.462&�6o   $��Calibri)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Status:��6   $
��Left=�6"   $��	12,86,0,0q�6=   $	��Top=�6P   $��Calibri)�6h   $��14(�6}   $
��Bold"�6�   �� 5   
   $��Deployed To:��6   $
��Left=�6'   $��
10,116,0,0q�6B   $	��Top=�6V   $��Calibri)�6n   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Make:��6   $
��Left=�6    $��
10,143,0,0q�6;   $	��Top=�6O   $��Calibri)�6g   $��14(�6|   $
��Bold"�6�   �� 5   
   $��Model:��6   $
��Left=�6!   $��	9,171,0,0q�6<   $	��Top=�6O   $��Calibri)�6g   $��14(�6|   $
��Bold"�6�   �� 5   
   $��Machine Name:��6   $
��Left=�6(   $��	9,202,0,0q�6C   $	��Top=�6V   $ 0.579,0.154&�6n   $��Calibri)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Conway Tag:��6   $
��Left=�6&   $��	8,236,0,0q�6A   $	��Top=�6T   $��Calibri)�6l   $��14(�6�   $
��Bold"�6�   �� 5   
   $��Notes:��6   $
��Left=�6!   $��	9,265,0,0q�6<   $	��Top=�6O   $��Calibri)�6g   $��14(�6|   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txt_serial_number��5      $
��Left=�6-   $��23��6H   $��
152,22,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��237��6�   ���	#FFECECEC
�������$��Calibri)�6�   ��6�   �� *Serial_Number+�� 5   
   -   5         ��Name$ cbx_equip_type��5      $
��Left=�6+   $��
151,56,0,0q�6F   $	��Top=�6Z   $	��237��6r   $��Calibri)�6~   	 �� 
IsEditable	 . 
 �� Text
 6�   �� *Equipment_Type+5      �� 5   
   -   5        $ 
cbx_status��5      $
��Left=�6'   $��
152,86,0,0q�6B   $	��Top=�6V   $	��110��6n   $��Calibri)�6z   
 6�   �� *Status+.@�5      �� -   5        $
��cbi1��5      .��6'   
Deployed61   �� 5      -   5        $
��cbi2��5      .��6'   Deployed/Remote68   �� 5      -   5        $
��cbi3��5      .��6'   In Server Room67   �� 5      -	   5        $
��cbi4��5      .��6'   
Recylced61   5      �� 5   
   -
   5        $ cbx_Deployed_To��5      $
��Left=�6,   $��152,116,0,0q�6G   $	��Top=�6\   $	��237��6t   $��Calibri)�6�   	 . 
 6�   �� *Deployed_To+5#      �� 5$   
   -   5        $ txt_make��5$      $
��Left=�6$   $��23��6?   $��153,145,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��236��6�   ���	#FFECECEC$��Calibri)�6�   ��6�   �� *Make+�� 5%   
   -   5        $ 	txt_model��5%      $
��Left=�6%   $��23��6@   $��153,174,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��235��6�   ���	#FFECECEC$��Calibri)�6�   ��6�   �� *Model+�� 5&   
   -   5        $ txt_machine_name��5&      $
��Left=�6,   $��23��6G   $��153,206,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��235��6�   ���	#FFECECEC$��Calibri)�6�   ��6�   �� *Machine_Name+�� 5'   
   -   5        $ txt_conway_tag��5'      $
��Left=�6*   $��23��6E   $��153,237,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��111��6�   ���	#FFECECEC$��Calibri)�6�   ��6�   �� *
Conway_Tag+�� 5(   
   -   5        $ 	txt_notes��5(      $
��Left=�6%   $��91��6@   $��153,272,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��235��6�   ���	#FFECECEC$��Calibri)�6�   ��6�   �� *Notes+�� 5)   
   -   5         ��Name$ 
btn_submit��5)      $��Submit��6%   $
��Left=�66   $��285,385,0,0q�6Q   $	��Top=�6f   $	��103��6~   $��34��6�   $��Calibri)�6�   $
��Bold"�6�   
�������6�   5*      5+      