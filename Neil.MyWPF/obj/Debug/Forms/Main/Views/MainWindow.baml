   M S B A M L   `   `   `  ����E  ANeil.MyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Neil.MyWPF
Neil.MyWPF  5   	       Neil.MyWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +custnsclr-namespace:Neil.MyWPF     5   	     � Title$  
MainWindow��5	   	   $	��234��6   $	��301��6)    � 	Resources 5      $   Neil.MyWPF.MainWindowViewModel   MainWindowViewObj   TxtCustomerName��%,   &	          5   
   $
 Neil��5      5      .��5      � .+�5   
   �� -   5        $��lblName��5      $
��Left=�6{   $��
28,104,0,0q�6�   $	��Top=�6�   $��23��6�   $��40��6�   ��6   �� *TxtCustomerName+ �� Mode$ OneWay=� �� Source# [  6�   �� 5   
   -   5        $��btnCaculateTex��5      $��计算税金��6'   $
��Left=�66   $��31��6Q   $��121,149,0,0q�6]   $	��Top=�6r   $��71��6�    J� RenderTransformOrigin$ 0.296,0.194&�6�   ��6�   �� *
btnClick+$ OneWay=�# [  �� 5   
   -   5        $��	txtAmount��5      $
��Left=�6w   $��27��6�   $��
121,62,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��60��6�   ��6#   �� *	TxtAmount+# [  $ TwoWay=�6�   �� 5   
   -   5         ��Name$ lblTex��5      $
��Left=�6s   $��132,104,0,0q�6�   $	��Top=�6�   $��23��6�   $��40��6�   ��6    �� *TxtTax+$ OneWay=�# [  6�   �� 5   
   -   5        $��lblTime��5      $��Label��6   $
��Left=�6/   $��23��6J   $��	10,23,0,0q�6V   $	��Top=�6i   $	��273��6�   5      5      