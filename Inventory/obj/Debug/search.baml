   M S B A M L   `   `   `  ����D  @Inventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Inventory	Inventory  5   	       Inventory.search   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Inventory     5   	     � Title$  search��5   	   $	��450��6   $��820.412��6%    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5	      � .+�5
   
   �� $��Serial Number:��6   $
��Left=�6)   $	��Top=�6D   $��Calibri)�6\   $��16(�6q   $
��Bold"�6   $��	39,17,0,0q�6�   $��30��6�   $	��120��6�   �� 5   
   -   5         ��Name$ txt_serial_number��5      $
��Left=�6-   $��31��6H   $��	10,52,0,0q�6T    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��181��6�   $��Calibri)�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 
btn_search��5      $��197,42,0,334q�6%   $
��Left=�6�   $��74��6�   ��6;   Z� ��6Q   Z� .��5      �� $��magnifiersearch.png��6   $��44��61   5      5      �� 5   
   -   5        $��
lv_results��5   )   $��10,140,10,10q�6   ��5      �� 5      .R�5      � .+�5      �� $��Serial_Number: ��6$   �� 5      $
��Bold"�6C   ��6$   �� *Serial_Number+6C   �� 5      $��, ��6$   �� 5      $��Make: ��6$   �� 5      $
��Bold"�6:   ��6$   �� *Make+6:   �� 5      $�� (��6$   �� 5       $
��Bold"�6<   ��6$   �� *Model+6<   �� 5!      $��)��6$   �� 5"      $��, ��6$   �� 5#      $��Machine Name: ��6$   �� 5$      $
��Bold"�6C   ��6$   �� *Machine_Name+6C   �� 5%      $��, ��6$   �� 5&      $��Conway Tag: ��6$   �� 5'      $
��Bold"�6A   ��6$   �� *
Conway_Tag+6A   �� 5(      $��, ��6$   �� 5)      $��Deployed To: ��6$   �� 5*      $
��Bold"�6B   ��6$   �� *Deployed_To+6B   5+      5,      5.      5/      50      