   M S B A M L   `   `   `  ����D  @Inventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Inventory	Inventory  5   	       Inventory.New   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Inventory     5   	   -   5          � Title$	  New��5   	   $��492.913��6   $��432.134��6'    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6]    � Icon$ inventory.png��6s   .��5	      � .+�5
   
   � -   5         �Name$ grid_modify��5
      $��	0,0,-2,-2q�6$    � ColumnDefinitions 5      �� 5      .+�5      �� $��Serial Number:��6   $
��Left=�6-   $��	10,42,0,0q�6H   $	��Top=�6[   $��Calibri)�6s   $��14(�6�   $
��Bold"�6�   �� 5      $��Equipment Type:��6   $
��Left=�6.   $��	10,76,0,0q�6I   $	��Top=�6\    J� RenderTransformOrigin$ 0.553,0.462&�6t   $��Calibri)�6�   $��14(�6�   $
��Bold"�6�   �� 5      $��Status:��6   $
��Left=�6&   $��
11,109,0,0q�6A   $	��Top=�6U   $��Calibri)�6m   $��14(�6�   $
��Bold"�6�   �� 5      $��Deployed To:��6   $
��Left=�6+   $��
10,139,0,0q�6F   $	��Top=�6Z   $��Calibri)�6r   $��14(�6�   $
��Bold"�6�   �� 5      $��Make:��6   $
��Left=�6$   $��
10,166,0,0q�6?   $	��Top=�6S   $��Calibri)�6k   $��14(�6�   $
��Bold"�6�   �� 5      $��Model:��6   $
��Left=�6%   $��	9,194,0,0q�6@   $	��Top=�6S   $��Calibri)�6k   $��14(�6�   $
��Bold"�6�   �� 5      $��Machine Name:��6   $
��Left=�6,   $��	9,225,0,0q�6G   $	��Top=�6Z   $ 0.579,0.154&�6r   $��Calibri)�6�   $��14(�6�   $
��Bold"�6�   �� 5      $��Conway Tag:��6   $
��Left=�6*   $��	8,259,0,0q�6E   $	��Top=�6X   $��Calibri)�6p   $��14(�6�   $
��Bold"�6�   �� 5      $��Notes:��6   $
��Left=�6%   $��	9,288,0,0q�6@   $	��Top=�6S   $��Calibri)�6k   $��14(�6�   $
��Bold"�6�   �� 5      -   5         ��Name$ txt_serial_number��5      $
��Left=�61   $��23��6L   $��
152,45,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��237��6�   ���	#FFECECEC
�������$��Calibri)�6�   $
��Bold"�6�   ��6�   �� *Serial_Number+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5      -   5        
 ��Name$
 cbx_equip_type��5      $
��Left=�6/   $��
151,79,0,0q�6J   $	��Top=�6^   $	��237��6v   $��Calibri)�6�    �� 
IsEditable . $
��Bold"�6�    �� Text 6�   �� *Equipment_Type+$	 PropertyChanged=��� 5      -   5        $
 
cbx_status��5      $
��Left=�6+   $��152,109,0,0q�6F   $	��Top=�6[   $	��110��6s   $��Calibri)�6   $
��Bold"�6�   .@�5      �� -   5        $
��cbi1��5      .��6+   
Deployed65   �� 5      -   5        $
��cbi2��5      .��6+   Deployed/Remote6<   �� 5      -   5        $
��cbi3��5      .��6+   In Server Room6;   �� 5      -	   5        $
��cbi4��5      .��6+   
Recylced65   5      �� 5      -
   5        $
 cbx_deployed_to��5      $
��Left=�60   $��152,139,0,0q�6K   $	��Top=�6`   $	��237��6x   $��Calibri)�6�    . $
��Bold"�6�    6�   �� *Deployed_To+$	 PropertyChanged=��� 5       -   5        $ txt_make��5       $
��Left=�6(   $��23��6C   $��153,168,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��236��6�   ���	#FFECECEC$��Calibri)�6�   $
��Bold"�6�   ��6�   �� *Make+$	 PropertyChanged=��� 5!      -   5        $ 	txt_model��5!      $
��Left=�6)   $��23��6D   $��153,197,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��235��6�   ���	#FFECECEC$��Calibri)�6�   $
��Bold"�6�   ��6�   �� *Model+$	 PropertyChanged=��� 5"      -   5        $ txt_machine_name��5"      $
��Left=�60   $��23��6K   $��153,229,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��235��6�   ���	#FFECECEC$��Calibri)�6�   $
��Bold"�6�   ��6�   �� *Machine_Name+$	 PropertyChanged=��� 5#      -   5        $ txt_conway_tag��5#      $
��Left=�6.   $��23��6I   $��153,260,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��111��6�   ���	#FFECECEC$��Calibri)�6�   $
��Bold"�6�   ��6�   �� *
Conway_Tag+$	 PropertyChanged=��� 5$      -   5        $ 	txt_notes��5$      $
��Left=�6)   $��91��6D   $��153,295,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��235��6�   ���	#FFECECEC$��Calibri)�6�   $
��Bold"�6�   ��6�   �� *Notes+$	 PropertyChanged=��� 5%      -   5         ��Name$ 
btn_submit��5%      $��Submit��6)   $
��Left=�6:   $��286,407,0,0q�6U   $	��Top=�6j   $	��103��6�   $��34��6�   $��Calibri)�6�   
�������$��14(�6�   $
��Bold"�6�   5&      5(      5)      