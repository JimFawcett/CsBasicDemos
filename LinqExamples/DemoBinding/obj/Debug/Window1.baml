   M S B A M L   `   `   `  ����  DemoBinding    DemoBinding.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	      8x,http://schemas.microsoft.com/winfx/2006/xaml    5
      -   5          � Title$"  CSE775 - Distributed Objects��5      $	��334��6*   $	��473��67   
������� � 	Resources 5         
BindingXml � Source � XPath��%K   &	        � 5      $ DemoBinding.xml?�6)   $ DataBindDemo��6B   5      .��5      � 
������� � ColumnDefinitions 5      �� 5      $
��277* �6   �� 5      $��* �6   .+�5      �� -   5        $��listBox1��5   "   $��
48,49,0,31q�6   $
��Left=�5   )   $	��152��6D   ��5      ��  �� Source# [   �� XPath$ /DataBindDemo/item��5   D   �� 5      -   5        $��listBox2��5   >   $��Right=�6   $��
0,48,61,32q�6*   $	��139��6N   �� 5      -   5        $��
textBlock1��5   J   $��21��6   $
��Left=�6   $��	48,18,0,0q�67   $	��Top=�6\   $	��152��6t   $��XPath Binding��6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   
����d�
�������6�   �� 6�   -   5        $��
textBlock2��5   5  $��21��6�   $��Right=�6  $��	0,18,61,0q�6"  $	��Top=�6G  $	��139��6_  $��Linq Binding��6k  
����d�
�������$
��Bold"�6�  $ Center=�6�  $
��None{�6�  5      5      