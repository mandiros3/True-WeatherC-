   M S B A M L   `   `   `  ����  True Weather    True_Weather.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
Weather v1��5   	   $	��500��6   $	��530��6)   $	��500��6P   $	��530��6_   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��112* �6    � RowDefinitions 5
   
   �� 5      $	��72* �6   �� 5      $
��363* �6   �� 5      $	��64* �6   .+�5   
   �� $
��Left=�6   $��	10,27,0,0q�6/   $
��Wrap=�6B   $��Please Enter a ZIP:��6V   $	��Top=�6q   $
��Bold"�6�   $	��166��6�   $��16��6�   �� 5   
   -   5         ��Name$ zipQuery��5      $
��Left=�6$   $��23��6?   $��
166,25,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��125��6�   6�   �� 5   
   -   5         ��Name$ 
findButton��5      $
��Find��6%   $
��Left=�64   $��
373,27,0,0q�6O   $	��Top=�6c   $	��107��6{    J� RenderTransformOrigin$ 
1.009,0.55&�6�   $��20��6�   �� 5   
   -   5         ��Name$
 lblW��5      $�� ��6   $
��Left=�6)   $��
296,25,0,0q�6D   $	��Top=�6X   $��99��6p   $��26��6{   �� 5   
   -   5         ��Name$ location��5      $
��Left=�6&   $��	10,25,0,0q�6A   $��1��6T   $
��Wrap=�6a   $	��Top=�6u   $	��497��6�   $��38��6�   $��20(�6�   �� 5   
   -   5        $ errorBox��5      $
��Left=�6&   $��52��6A   $��10,2,0,0q�6M   $��2��6_   $
��Wrap=�6l   $	��Top=�6�   $	��497��6�   $��36(�6�   �� 5   
   -   5        $ 	condition��5      $
��Left=�6'   $��	10,68,0,0q�6B   $��1��6U   $
��Wrap=�6b   $	��Top=�6v   $��22(�6�   $	��396��6�   $��29��6�   5      5      